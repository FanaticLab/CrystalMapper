using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using CrystalMapper.Linq.Expressions;
using System.Collections.ObjectModel;
using System.Reflection;
using CrystalMapper.Lang;
using System.Data.Linq;
using CrystalMapper.ObjectModel;
using CrystalMapper.Linq.Metadata;
using System.Diagnostics;
using CoreSystem.Data;
using CoreSystem.ValueTypeExtension;

namespace CrystalMapper.Linq.Translator
{
    internal class QueryTranslator : ExpressionVisitor
    {
        private int parameterCount = 0;

        private int tableAliasCount = 0;

        private List<DbParameterExpression> parameters = new List<DbParameterExpression>();

        public QueryInfo Translate(SqlLang sqlLang, Expression expression)
        {
            ResultShape resultShape = GetResultShape(expression);
            var dbExpression = this.Visit(expression);
            SelectExpression selectExpression = this.MakeSelect(dbExpression as DbExpression);
            Dictionary<string, object> parameterValues = new Dictionary<string, object>();
            foreach (var dbParameter in this.parameters)
                if (!dbParameter.IsDBNull)
                    parameterValues.Add(sqlLang.GetParameter(dbParameter.Parameter), dbParameter.Value);

            if (selectExpression != null)
            {
                selectExpression.WrapInBracks = false;
                QueryWriter queryWriter = new QueryWriter();
                selectExpression.WriteQuery(sqlLang, queryWriter);

                return new QueryInfo(resultShape, selectExpression.UseDefault, selectExpression.ReturnType, selectExpression.Projection, queryWriter.ToString(), parameterValues);
            }

            throw new InvalidOperationException(string.Format("Failed to translate expression in to select expression, top node expression is: '{0}. Try to wrap it in select clause'", dbExpression));
        }

        private SelectExpression MakeSelect(DbExpression dbExpression)
        {
            if (dbExpression.DbNodeType == DbExpressionType.Select)
                return (SelectExpression)dbExpression;

            if ((dbExpression as SourceExpression) != null)
                return new SelectExpression(this.GetNextTableAlias(), dbExpression, this.GetSourceProjection((SourceExpression)dbExpression));

            if ((dbExpression as IndirectExpression) != null)
            {
                DbExpression source = dbExpression;
                while (source as SourceExpression == null)
                {
                    IndirectExpression indirectExpression = source as IndirectExpression;

                    if (indirectExpression == null)
                        throw new InvalidOperationException(string.Format("Unable to find source expression: '{0}'", source));

                    source = indirectExpression.Source;
                }

                return new SelectExpression(this.GetNextTableAlias(), dbExpression, GetSourceProjection((SourceExpression)source));
            }

            throw new InvalidOperationException(string.Format("Unable to directly transform {0} Expression into Select Expression", dbExpression.DbNodeType));
        }

        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            var declaringType = m.Method.DeclaringType;
            if (declaringType == typeof(Queryable) || declaringType == typeof(Enumerable) || declaringType == typeof(LinqExtension))
            {

                switch (m.Method.Name)
                {
                    case "Select":
                        return new SelectExpression(this.GetNextTableAlias(), (DbExpression)this.Visit(m.Arguments[0]), GetProjectionExpression(m.Arguments[1]));

                    case "ForUpdateAll":
                        if (m.Arguments.Count == 2)
                            return new ForUpdateExpression(new WhereExpression((DbExpression)this.Visit(m.Arguments[0]), (DbExpression)this.Visit(GetLambda(m.Arguments[1]))));

                        return new ForUpdateExpression((DbExpression)this.Visit(m.Arguments[0]));
                    case "SelectMany":

                        MethodCallExpression mcs = this.GetLambda(m.Arguments[1]).Body as MethodCallExpression;

                        if (mcs != null && mcs.Method.Name == "DefaultIfEmpty" && (mcs.Method.DeclaringType == typeof(Queryable) || mcs.Method.DeclaringType == typeof(Enumerable)))
                        {
                            JoinExpression joinExpression = (JoinExpression)this.Visit(m.Arguments[0]);

                            return new JoinExpression(joinExpression.Outer, joinExpression.Inner, JoinType.LeftOuterJoin, joinExpression.Join, this.GetProjectionExpression(this.GetLambda(m.Arguments[2])));
                        }
                        DbExpression outer = (DbExpression)this.Visit(this.RemoveQuotes(m.Arguments[0]));
                        DbExpression inner = (DbExpression)this.Visit(this.RemoveQuotes(m.Arguments[1]));

                        outer = outer as SourceExpression != null ? outer : this.MakeSelect(outer);
                        inner = inner as SourceExpression != null ? inner : this.MakeSelect(inner);

                        return new JoinExpression((SourceExpression)outer, (SourceExpression)inner, JoinType.CrossJoin, null, this.GetProjectionExpression(this.GetLambda(m.Arguments[2])));
                    case "Where":
                        return new WhereExpression((DbExpression)this.Visit(m.Arguments[0]), (DbExpression)this.Visit(GetLambda(m.Arguments[1])));

                    case "Take":
                        return new TakeExpression((int)(m.Arguments[1] as ConstantExpression).Value, false, false, (DbExpression)this.Visit(m.Arguments[0]));

                    case "Skip":
                        return new SkipExpression((int)(m.Arguments[1] as ConstantExpression).Value, (DbExpression)this.Visit(m.Arguments[0]));

                    case "First":
                    case "Single":
                        if (m.Arguments.Count == 2)
                            return new TakeExpression(1, false, false, new WhereExpression((DbExpression)this.Visit(m.Arguments[0]), (DbExpression)this.Visit(GetLambda(m.Arguments[1]))));

                        return new TakeExpression(1, false, false, (DbExpression)this.Visit(m.Arguments[0]));

                    case "ForUpdate":
                        if (m.Arguments.Count == 2)
                            return new TakeExpression(1, true, false, new ForUpdateExpression(new WhereExpression((DbExpression)this.Visit(m.Arguments[0]), (DbExpression)this.Visit(GetLambda(m.Arguments[1])))));

                        return new TakeExpression(1, true, false, new ForUpdateExpression((DbExpression)this.Visit(m.Arguments[0])));
                    case "FirstOrDefault":
                    case "SingleOrDefault":
                        if (m.Arguments.Count == 2)
                            return new TakeExpression(1, true, false, new WhereExpression((DbExpression)this.Visit(m.Arguments[0]), (DbExpression)this.Visit(GetLambda(m.Arguments[1]))));

                        return new TakeExpression(1, true, false, (DbExpression)this.Visit(m.Arguments[0]));

                    case "Last":
                        if (m.Arguments.Count == 2)
                            return new TakeExpression(1, false, true, new WhereExpression((DbExpression)this.Visit(m.Arguments[0]), (DbExpression)this.Visit(GetLambda(m.Arguments[1]))));

                        return new TakeExpression(1, false, true, (DbExpression)this.Visit(m.Arguments[0]));

                    case "LastOrDefault":
                        if (m.Arguments.Count == 2)
                            return new TakeExpression(1, true, true, new WhereExpression((DbExpression)this.Visit(m.Arguments[0]), (DbExpression)this.Visit(GetLambda(m.Arguments[1]))));

                        return new TakeExpression(1, true, true, (DbExpression)this.Visit(m.Arguments[0]));

                    case "Distinct":
                        {
                            if (m.Arguments.Count == 2)
                                throw new InvalidOperationException(string.Format("Cannot translate IEqualityComparer<T> ({0}) into sql query", m.Arguments[1]));

                            return new DistinctExpression((DbExpression)this.Visit(m.Arguments[0]));
                        }
                    case "OrderBy":
                        return new OrderByExpression(SortDirection.Asc, (DbExpression)this.Visit(GetLambda(m.Arguments[1])), (DbExpression)this.Visit(m.Arguments[0]));
                    case "OrderByDescending":
                        return new OrderByExpression(SortDirection.Desc, (DbExpression)this.Visit(GetLambda(m.Arguments[1])), (DbExpression)this.Visit(m.Arguments[0]));
                    case "ThenBy":
                        return new ThenByExpression(SortDirection.Asc, (DbExpression)this.Visit(GetLambda(m.Arguments[1])), (DbExpression)this.Visit(m.Arguments[0]));
                    case "ThenByDescending":
                        return new ThenByExpression(SortDirection.Desc, (DbExpression)this.Visit(GetLambda(m.Arguments[1])), (DbExpression)this.Visit(m.Arguments[0]));

                    case "Count":
                    case "LongCount":
                        if (m.Arguments.Count == 2)
                            return new AggregateExpression(new WhereExpression((DbExpression)this.Visit(m.Arguments[0]), (DbBinaryExpression)this.Visit(this.GetLambda(m.Arguments[1]))), null, DbConvert.ToEnum<DbExpressionType>(m.Method.Name), m.Method.ReturnType);

                        return new AggregateExpression((DbExpression)this.Visit(m.Arguments[0]), null, DbConvert.ToEnum<DbExpressionType>(m.Method.Name), m.Method.ReturnType);

                    case "Sum":
                    case "Min":
                    case "Max":
                    case "Average":
                        if (m.Arguments.Count == 2)
                            return new AggregateExpression((DbExpression)this.Visit(m.Arguments[0]), (DbExpression)this.Visit(this.GetLambda(m.Arguments[1])), DbConvert.ToEnum<DbExpressionType>(m.Method.Name), m.Method.ReturnType);

                        return new AggregateExpression((DbExpression)this.Visit(m.Arguments[0]), null, DbConvert.ToEnum<DbExpressionType>(m.Method.Name), m.Method.ReturnType);

                    case "Join":
                    case "GroupJoin":
                        DbExpression outerKey = (DbExpression)this.Visit(this.GetLambda(m.Arguments[2]));
                        DbExpression innerKey = (DbExpression)this.Visit(this.GetLambda(m.Arguments[3]));
                        DbBinaryExpression keyExpression = null;

                        if (outerKey as ProjectionExpression != null)
                        {
                            ProjectionExpression outerCompositeKey = (ProjectionExpression)outerKey;
                            ProjectionExpression innerCompositeKey = innerKey as ProjectionExpression;

                            if (innerCompositeKey == null || outerCompositeKey.Columns.Count != innerCompositeKey.Columns.Count)
                                throw new InvalidOperationException(string.Format("Join inner key '{0}' must contains same number of elements as in outer key '{1}'", this.GetLambda(m.Arguments[3]), this.GetLambda(m.Arguments[2])));

                            int index = 0;
                            foreach (ColumnExpression column in outerCompositeKey.Columns)
                            {
                                if (keyExpression == null)
                                    keyExpression = new DbBinaryExpression(column.Column, innerCompositeKey.Columns[index].Column, ExpressionType.Equal, typeof(bool));
                                else
                                {
                                    DbBinaryExpression right = new DbBinaryExpression(column.Column, innerCompositeKey.Columns[index].Column, ExpressionType.Equal, typeof(bool));
                                    keyExpression = new DbBinaryExpression(keyExpression, right, ExpressionType.AndAlso, typeof(bool));
                                }
                                index++;
                            }
                        }
                        else
                            keyExpression = new DbBinaryExpression(outerKey, innerKey, ExpressionType.Equal, typeof(bool));

                        var outerSource = this.Visit(m.Arguments[0]);
                        var innerSource = this.Visit(m.Arguments[1]);

                        if (!(outerSource is SourceExpression))
                            outerSource = this.MakeSelect((DbExpression)outerSource);

                        if (!(innerSource is SourceExpression))
                            innerSource = this.MakeSelect((DbExpression)innerSource);

                        return new JoinExpression((SourceExpression)outerSource, (SourceExpression)innerSource, JoinType.InnerJoin, keyExpression, this.GetProjectionExpression(this.GetLambda(m.Arguments[4])));

                    case "Contains":
                        SourceExpression source = (SourceExpression)this.Visit(m.Arguments[0]);
                        DbExpression member = (DbExpression)this.Visit(m.Arguments[1]);

                        return new InExpression(member, source);

                    case "GroupBy":
                        return new GroupByExpression((DbExpression)this.Visit(m.Arguments[0]), (DbExpression)this.Visit(this.GetLambda(m.Arguments[1])));

                    default:
                    case "Any":
                    case "All":
                    case "Cast":
                    case "Reverse":
                    case "Intersect":
                    case "Except":
                        throw new NotSupportedException(string.Format("CrystalMapper doesn't support the '{0}' operation", m.Method.Name));
                }
            }
            else if (m.Method.DeclaringType == typeof(Decimal))
            {
                switch (m.Method.Name)
                {
                    case "Add":
                        return this.Visit(BinaryExpression.Add(m.Arguments[0], m.Arguments[1]));
                    case "Subtract":
                        return this.Visit(BinaryExpression.Subtract(m.Arguments[0], m.Arguments[1]));
                    case "Multiply":
                        return this.Visit(BinaryExpression.Multiply(m.Arguments[0], m.Arguments[1]));
                    case "Divide":
                        return this.Visit(BinaryExpression.Divide(m.Arguments[0], m.Arguments[1]));
                    case "Remainder":
                        return DbBinaryExpression.RemainderExpression((DbExpression)this.Visit(m.Arguments[0]), (DbExpression)this.Visit(m.Arguments[1]), m.Method.ReturnType);
                    case "Negate":
                        return this.Visit(BinaryExpression.Negate(m.Arguments[0]));
                    case "Compare":
                        return this.Visit(Expression.Condition(
                            Expression.Equal(m.Arguments[0], m.Arguments[1]),
                            Expression.Constant(0),
                            Expression.Condition(
                                Expression.LessThan(m.Arguments[0], m.Arguments[1]),
                                Expression.Constant(-1),
                                Expression.Constant(1)
                                )));
                }
            }
            else if (m.Method.Name == "ToString" && m.Object.Type == typeof(string))
            {
                return this.Visit(m.Object);  // no op
            }
            else if (m.Method.Name == "Equals")
            {
                if (m.Method.IsStatic && m.Method.DeclaringType == typeof(object))
                    return this.Visit(Expression.Equal(m.Arguments[0], m.Arguments[1]));

                else if (!m.Method.IsStatic && m.Arguments.Count == 1 && m.Arguments[0].Type == m.Object.Type)
                    return this.Visit(Expression.Equal(m.Object, m.Arguments[0]));
            }
            else if (typeof(IQueryable).IsAssignableFrom(m.Method.ReturnType))
            {
                var constantExpression = this.Visit(m.Object) as ConstantExpression;
                if (constantExpression != null)
                {
                    var arguments = m.Arguments.Select(a => this.Visit(a)).Where(a => a is ConstantExpression).Select(a => ((ConstantExpression)a).Value).ToArray();
                    IQueryable queryable = m.Method.Invoke(constantExpression.Value, arguments) as IQueryable;
                    if (constantExpression != null && queryable != null)
                        return this.Visit(queryable.Expression);
                }
            }
            else if (m.Method.DeclaringType == typeof(Enumerable))
            {
                switch (m.Method.Name)
                {
                    case "DefaultIfEmpty":
                        return this.Visit(m.Arguments[0]);
                }
            }

            return new DbMethodCallExpression((DbExpression)this.Visit(m.Object), m.Method, (IEnumerable<DbExpression>)m.Arguments.Select(a => (DbExpression)this.Visit(a)));
        }

        protected override Expression VisitConstant(ConstantExpression c)
        {
            if (c != null && c.Type.IsGenericType && c.Type.GetGenericTypeDefinition() == typeof(Query<>))
            {
                Type type = c.Type.GetGenericArguments()[0];

                TableMetadata tableMetadata = MetadataProvider.GetMetadata(type);
                return new TableExpression(this.GetNextTableAlias(), tableMetadata);
            }

            DbParameterExpression dbParameter = new DbParameterExpression(this.GetNextParameter(), c.Value);
            this.parameters.Add(dbParameter);

            return dbParameter;
        }

        protected override Expression VisitMemberAccess(MemberExpression m)
        {
            ConstantExpression constant = m.Expression as ConstantExpression;
            if (constant != null)
            {
                var memberType = m.Member.GetMemberType();
                if (IsMemberType(memberType))
                    return this.Visit(Expression.Constant(m.Member.GetValue(constant.Value)));
                else if (memberType.IsArray && IsMemberType(memberType.GetElementType()))
                {
                    List<DbParameterExpression> arrayParameters = new List<DbParameterExpression>();
                    foreach (var parameter in (Array)m.Member.GetValue(constant.Value))
                    {
                        var dbParameter = new DbParameterExpression(this.GetNextParameter(), parameter);
                        arrayParameters.Add(dbParameter);
                        this.parameters.Add(dbParameter);
                    }

                    return new ArrayExpression(arrayParameters.AsReadOnly(), memberType.GetElementType());
                }

                return (memberType.IsGenericType && memberType.GetGenericTypeDefinition() == typeof(IQueryable<>))
                        ? this.Visit(((IQueryable)m.Member.GetValue(constant.Value)).Expression)
                        : Expression.Constant(m.Member.GetValue(constant.Value));
            }

            if (m.Expression is MemberExpression)
                return this.Visit(Expression.MakeMemberAccess(this.Visit(m.Expression), m.Member));

            Type declaringType = m.Member.DeclaringType;
            // use the mapping metadata and find the name of this member in the database
            TableMetadata tableMetadata = MetadataProvider.GetMetadata(declaringType);

            if (tableMetadata != null)
            {
                MemberMetadata memberMetadata = tableMetadata.Members.FirstOrDefault(md => md.Member == m.Member);
                if (memberMetadata != null)
                    return new DbMemberExpression(memberMetadata);

                if (typeof(IQueryable).IsAssignableFrom(m.Member.GetMemberType()))
                    throw new InvalidOperationException(string.Format("Instance member cannot be used as query source, please use join expression: {0}", m.Member));
            }

            tableMetadata = MetadataProvider.GetMetadata(m.Member.GetMemberType());
            if (tableMetadata != null)
                return new TableExpression(null, tableMetadata);

            if (IsMemberType(m.Member.GetMemberType()))
                return new DbMemberExpression(new MemberMetadata(m.Member));

            return new ProjectionExpression(m.Type.GetProperties().Select(p => new ColumnExpression(new MemberMetadata(p), new DbMemberExpression(new MemberMetadata(p)))).ToReadOnly(), m.Type);
        }

        protected override Expression VisitLambda(LambdaExpression lambda)
        {
            if (lambda.Body is NewExpression)
            {
                NewExpression nex = (NewExpression)lambda.Body;
                List<ColumnExpression> columns = new List<ColumnExpression>();
                int index = 0;
                string memberName;
                PropertyInfo[] members = nex.Type.GetProperties();

                foreach (Expression ex in nex.Arguments)
                {
                    DbExpression dbExpression = this.Visit(ex) as DbExpression;
                    memberName = members[index].Name;

                    if (IsMemberType(members[index].PropertyType))
                        columns.Add(new ColumnExpression(new MemberMetadata(members[index]), dbExpression, memberName));
                    else
                        columns.AddRange(GetColumns(members[index].PropertyType));

                    index++;
                }

                return new ProjectionExpression(columns.AsReadOnly(), nex.Type, lambda.Compile());
            }
            else if (lambda.Body is MemberInitExpression)
            {
                MemberInitExpression iex = (MemberInitExpression)lambda.Body;
                NewExpression nex = (NewExpression)iex.NewExpression;
                List<ColumnExpression> columns = new List<ColumnExpression>();

                foreach (MemberAssignment binding in iex.Bindings)
                {
                    DbExpression dbExpression = this.Visit(binding.Expression) as DbExpression;

                    if (IsMemberType(binding.Member.GetMemberType()))
                        columns.Add(new ColumnExpression(new MemberMetadata(binding.Member), dbExpression, binding.Member.Name));
                    else
                        columns.AddRange(GetColumns(binding.Member.GetMemberType()));
                }

                return new ProjectionExpression(columns.AsReadOnly(), nex.Type, iex.Bindings);
            }

            return this.Visit(lambda.Body);
        }

        private IEnumerable<ColumnExpression> GetColumns(Type type)
        {
            //It should not be ienumerable type, needs to be fix
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                type = type.GetGenericArguments()[0];

            TableMetadata tableMetadata = MetadataProvider.GetMetadata(type);
            if (tableMetadata != null)
                foreach (MemberMetadata memberMetadata in tableMetadata.Members)
                    yield return new ColumnExpression(memberMetadata, new DbMemberExpression(memberMetadata));
            else
            {
                foreach (PropertyInfo propInfo in type.GetProperties())
                {
                    if (IsMemberType(propInfo.PropertyType))
                        yield return new ColumnExpression(new MemberMetadata(propInfo), new DbMemberExpression(new MemberMetadata(propInfo)));
                    else
                        foreach (ColumnExpression column in GetColumns(propInfo.PropertyType))
                            yield return column;
                }
            }
        }

        protected override Expression VisitBinary(BinaryExpression b)
        {
            return new DbBinaryExpression((DbExpression)this.Visit(b.Left), (DbExpression)this.Visit(b.Right), b);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            if (p != null && typeof(IRecord).IsAssignableFrom(p.Type))
            {
                TableMetadata tableMetadata = MetadataProvider.GetMetadata(p.Type);

                if (tableMetadata == null)
                    throw new Exception(string.Format("It was not possible to get metadata for {0}!", p.Type.Name));

                return new TableExpression(this.GetNextTableAlias(), tableMetadata);
            }

            if (p.Type.IsGenericType && p.Type.GetGenericTypeDefinition() == typeof(IGrouping<,>))
                return this.Visit(Expression.Parameter(p.Type.GetGenericArguments()[1], "g"));

            List<ColumnExpression> columns = new List<ColumnExpression>();
            foreach (var property in p.Type.GetProperties())
                columns.Add(new ColumnExpression(new MemberMetadata(property), new DbMemberExpression(new MemberMetadata(property))));

            return new ProjectionExpression(columns.ToReadOnly(), p.Type);
        }

        protected override Expression VisitUnary(UnaryExpression u)
        {
            return new DbUnaryExpression((DbExpression)this.Visit(u.Operand), u.NodeType, u.Type);
        }

        private bool IsLambda(Expression expression)
        {
            return RemoveQuotes(expression).NodeType == ExpressionType.Lambda;
        }

        private LambdaExpression GetLambda(Expression expression)
        {
            return RemoveQuotes(expression) as LambdaExpression;
        }

        private Expression RemoveQuotes(Expression expression)
        {
            while (expression.NodeType == ExpressionType.Quote)
                expression = ((UnaryExpression)expression).Operand;

            return expression;
        }

        [DebuggerStepThrough]
        private string GetNextTableAlias()
        {
            return "t" + tableAliasCount++;
        }

        private string GetNextParameter()
        {
            return "p" + parameterCount++;
        }

        private ResultShape GetResultShape(Expression expression)
        {
            LambdaExpression lambda = expression as LambdaExpression;
            if (lambda != null)
                expression = lambda.Body;

            if (expression.Type == typeof(void))
                return ResultShape.None;

            if (expression.Type == typeof(IMultipleResults))
                throw new NotSupportedException("Multiple result shape is not supported");

            MethodCallExpression methodExp = expression as MethodCallExpression;
            if (methodExp != null && ((methodExp.Method.DeclaringType == typeof(Queryable)) || (methodExp.Method.DeclaringType == typeof(Enumerable)) || methodExp.Method.DeclaringType == typeof(LinqExtension)))
            {
                string str = methodExp.Method.Name;
                if (str != null && str.In("First", "FirstOrDefault", "Single", "SingleOrDefault", "Last", "LastOrDefault", "Count", "LongCount", "Sum", "Min", "Max", "Average", "ForUpdate"))
                    return ResultShape.Singleton;
            }

            return ResultShape.Sequence;
        }

        private ProjectionExpression GetProjectionExpression(Expression expression)
        {
            expression = this.Visit(this.GetLambda(expression));

            if (expression is ProjectionExpression)
                return (ProjectionExpression)expression;

            if (expression is DbMemberExpression)
            {
                DbMemberExpression dbMember = (DbMemberExpression)expression;
                List<ColumnExpression> columns = new List<ColumnExpression>();
                columns.Add(new ColumnExpression(dbMember.MemberMetadata, dbMember));
                return new ProjectionExpression(columns.AsReadOnly(), expression.Type);
            }

            if (expression is TableExpression)
            {
                var columns = from m in (expression as TableExpression).TableMetadata.Members
                              select new ColumnExpression(m, new DbMemberExpression(m));

                return new ProjectionExpression(columns.ToList().AsReadOnly(), expression.Type);
            }

            {
                List<ColumnExpression> columns = new List<ColumnExpression>();
                columns.Add(new ColumnExpression(null, (DbExpression)expression));
                return new ProjectionExpression(columns.AsReadOnly(), expression.Type);
            }
        }

        private ProjectionExpression GetSourceProjection(SourceExpression source)
        {
            if (source is JoinExpression)
                return source.Projection;

            var projection = source.Projection;
            return new ProjectionExpression(projection.Columns.Select(c => new ColumnExpression(c.Member, new DbMemberExpression(c.Member))).ToReadOnly(), projection.Type, projection.ProjectionFunction, projection.Bindings);
        }

        private bool IsMemberType(Type type)
        {
            return type.IsPrimitive
                   || type == typeof(string)
                   || type == typeof(DateTime)
                   || (type.IsGenericType
                       && type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }


    }
}
