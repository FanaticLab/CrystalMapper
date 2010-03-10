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
using CrystalMapper.Linq.Metadata;
using CrystalMapper.Generic;
using System.Diagnostics;
using CoreSystem.Data;
using CoreSystem.ValueTypeExtension;

namespace CrystalMapper.Linq.Translator
{
    internal class QueryTranslator : ExpressionVisitor
    {
        private int tableAliasCount = 0;

        public QueryInfo Translate(SqlLang sqlLang, Expression expression)
        {
            ResultShape resultShape = GetResultShape(expression);
            expression = this.Visit(expression);
            SelectExpression selectExpression = this.MakeSelectExpression(expression as DbExpression);

            if (selectExpression != null)
            {
                QueryWriter queryWriter = new QueryWriter();
                selectExpression.WriteQuery(sqlLang, queryWriter);

                string sqlQuery = queryWriter.ToString();

                if (sqlQuery != null && sqlQuery.StartsWith("("))
                {
                    sqlQuery = sqlQuery.Substring(sqlQuery.IndexOf('(') + 1);
                    sqlQuery = sqlQuery.Substring(0, sqlQuery.LastIndexOf(')'));
                }

                return new QueryInfo(resultShape, selectExpression.UseDefault, selectExpression.ReturnType, sqlQuery, null);
            }

            throw new InvalidOperationException(string.Format("Failed to translate expression in to select expression, top node expression is: '{0}. Try to wrap it in select clause'", expression));
        }

        private SelectExpression MakeSelectExpression(DbExpression dbExpression)
        {
            switch (dbExpression.DbNodeType)
            {
                case DbExpressionType.Select:
                    return (SelectExpression)dbExpression;
                case DbExpressionType.Table:
                    {
                        var columns = from m in (dbExpression as TableExpression).TableMetadata.Members
                                      select new ColumnExpression(m, new DbMemberExpression(m));

                        return new SelectExpression(this.GetNextTableAlias(), dbExpression, new ProjectionExpression(columns.ToList().AsReadOnly(), dbExpression.Type, null));
                    }
            }

            if ((dbExpression as IndirectExpression) != null)
            {
                DbExpression source = dbExpression;
                while (!(source is TableExpression) && !(source is SelectExpression))
                {
                    IndirectExpression indirectExpression = source as IndirectExpression;

                    if (indirectExpression == null)
                        throw new InvalidOperationException(string.Format("Unable to find source expression: '{0}'", source));

                    source = indirectExpression.Source;
                }

                if (source.DbNodeType == DbExpressionType.Table)
                {
                    var columns = from m in (source as TableExpression).TableMetadata.Members
                                  select new ColumnExpression(m, new DbMemberExpression(m));

                    return new SelectExpression(this.GetNextTableAlias(), dbExpression, new ProjectionExpression(columns.ToList().AsReadOnly(), source.Type, null));
                }
                else
                {
                    SelectExpression selectExp = (source as SelectExpression);
                    var columns = selectExp.Projection.Columns.Select(c => new ColumnExpression(c.Member, new DbMemberExpression(c.Member))).ToList();
                    return new SelectExpression(this.GetNextTableAlias(), dbExpression, new ProjectionExpression(columns.AsReadOnly(), selectExp.Projection.Type, null));
                }
            }

            throw new InvalidOperationException(string.Format("Unable to directly transform {0} Expression into Select Expression", dbExpression.DbNodeType));
        }

        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            if (m.Method.DeclaringType == typeof(Queryable))
            {

                switch (m.Method.Name)
                {
                    case "Select":
                        return new SelectExpression(this.GetNextTableAlias(), (DbExpression)this.Visit(m.Arguments[0]), GetProjectionExpression(m.Arguments[1]));

                    case "SelectMany":
                        Expression[] exps = new Expression[] { m.Arguments[0], m.Arguments[1] };
                        return new MultiSourceExpression(exps.Select(e => (SourceExpression)this.Visit(e)));

                    case "Where":
                        return new WhereExpression((DbExpression)this.Visit(m.Arguments[0]), (DbBinaryExpression)this.Visit(GetLambda(m.Arguments[1])));

                    case "Take":
                        return new TakeExpression((int)(m.Arguments[1] as ConstantExpression).Value, false, false, (DbExpression)this.Visit(m.Arguments[0]));

                    case "First":
                    case "Single":
                        if (m.Arguments.Count == 2)
                            return new TakeExpression(1, false, false, new WhereExpression((DbExpression)this.Visit(m.Arguments[0]), (DbBinaryExpression)this.Visit(GetLambda(m.Arguments[1]))));

                        return new TakeExpression(1, false, false, (DbExpression)this.Visit(m.Arguments[0]));

                    case "FirstOrDefault":
                    case "SingleOrDefault":
                        if (m.Arguments.Count == 2)
                            return new TakeExpression(1, true, false, new WhereExpression((DbExpression)this.Visit(m.Arguments[0]), (DbBinaryExpression)this.Visit(GetLambda(m.Arguments[1]))));

                        return new TakeExpression(1, true, false, (DbExpression)this.Visit(m.Arguments[0]));

                    case "Last":
                        if (m.Arguments.Count == 2)
                            return new TakeExpression(1, false, true, new WhereExpression((DbExpression)this.Visit(m.Arguments[0]), (DbBinaryExpression)this.Visit(GetLambda(m.Arguments[1]))));

                        return new TakeExpression(1, false, true, (DbExpression)this.Visit(m.Arguments[0]));

                    case "LastOrDefault":
                        if (m.Arguments.Count == 2)
                            return new TakeExpression(1, true, true, new WhereExpression((DbExpression)this.Visit(m.Arguments[0]), (DbBinaryExpression)this.Visit(GetLambda(m.Arguments[1]))));

                        return new TakeExpression(1, true, true, (DbExpression)this.Visit(m.Arguments[0]));

                    case "Distinct":
                        {
                            if (m.Arguments.Count == 2)
                                throw new InvalidOperationException("IEqualityComparer<T> argument into sql query");

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
            else if (m.Method.DeclaringType.IsGenericType && m.Method.DeclaringType.GetGenericTypeDefinition() == typeof(Entity<>) && m.Method.Name == "Query")
            {
                IQueryable queryable = m.Method.Invoke(null, null) as IQueryable;
                if (queryable != null)
                    return this.Visit(queryable.Expression);
            }

            return new DbMethodCallExpression((DbExpression)this.Visit(m.Object), m.Method, (IEnumerable<DbExpression>)m.Arguments.Select(a => this.Visit(a)));
        }

        protected override Expression VisitConstant(ConstantExpression c)
        {
            if (c != null && c.Type.IsGenericType && c.Type.GetGenericTypeDefinition() == typeof(Query<>))
            {
                Type type = c.Type.GetGenericArguments()[0];

                TableMetadata tableMetadata = MetadataProvider.GetMetadata(type);

                if (tableMetadata == null)
                    throw new Exception(string.Format("It was not possible to get metadata for {0}!", type.Name));

                return new TableExpression(this.GetNextTableAlias(), tableMetadata);
            }

            return new DbParameterExpression(c.Value);
        }

        protected override Expression VisitMemberAccess(MemberExpression m)
        {
            Type declaringType = m.Member.DeclaringType;
            // use the mapping metadata and find the name of this member in the database
            TableMetadata tableMetadata = MetadataProvider.GetMetadata(declaringType);

            if (tableMetadata != null)
            {
                MemberMetadata memberMetadata = tableMetadata.Members.FirstOrDefault(md => md.Member == m.Member);

                if (memberMetadata != null)
                    return new DbMemberExpression(memberMetadata);
            }

            return new DbMemberExpression(new MemberMetadata(m.Member));
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

                    if (!members[index].PropertyType.IsPrimitive
                        && members[index].PropertyType != typeof(string)
                        && !members[index].PropertyType.IsGenericType && members[index].PropertyType.GetGenericTypeDefinition() != typeof(Nullable<>))
                        throw new NotSupportedException(string.Format("Type: {0} is not supported in projection expression (new) for database queries, only primitive types are supported", members[index].PropertyType));

                    if (dbExpression is DbMemberExpression && string.Equals(memberName, ((DbMemberExpression)dbExpression).MemberMetadata.ColumnName))
                        columns.Add(new ColumnExpression(new MemberMetadata(members[index]), dbExpression));
                    else
                        columns.Add(new ColumnExpression(new MemberMetadata(members[index]), dbExpression, memberName));

                    index++;
                }

                return new ProjectionExpression(columns.AsReadOnly(), nex.Type, lambda.Compile());
            }

            return this.Visit(lambda.Body);
        }

        protected override Expression VisitBinary(BinaryExpression b)
        {
            return new DbBinaryExpression((DbExpression)this.Visit(b.Left), (DbExpression)this.Visit(b.Right), b);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            if (p != null && p.Type.IsSubclassOf(typeof(Entity)))
            {
                TableMetadata tableMetadata = MetadataProvider.GetMetadata(p.Type);

                if (tableMetadata == null)
                    throw new Exception(string.Format("It was not possible to get metadata for {0}!", p.Type.Name));

                return new TableExpression(this.GetNextTableAlias(), tableMetadata);
            }

            return base.VisitParameter(p);
        }

        protected override Expression VisitUnary(UnaryExpression u)
        {
            return Visit(u.Operand);
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
            {
                expression = ((UnaryExpression)expression).Operand;
            }
            return expression;
        }

        [DebuggerStepThrough]
        private string GetNextTableAlias()
        {
            return "[t" + tableAliasCount++ + ']';
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
            if (methodExp != null && ((methodExp.Method.DeclaringType == typeof(Queryable)) || (methodExp.Method.DeclaringType == typeof(Enumerable))))
            {
                string str = methodExp.Method.Name;
                if (str != null && str.In("First", "FirstOrDefault", "Single", "SingleOrDefault", "Last", "LastOrDefault", "Count", "LongCount", "Sum", "Min", "Max", "Average"))
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
                return new ProjectionExpression(columns.AsReadOnly(), expression.Type, null);
            }

            if (expression is TableExpression)
            {
                var columns = from m in (expression as TableExpression).TableMetadata.Members
                              select new ColumnExpression(m, new DbMemberExpression(m));

                return new ProjectionExpression(columns.ToList().AsReadOnly(), expression.Type, null);
            }

            {
                List<ColumnExpression> columns = new List<ColumnExpression>();
                columns.Add(new ColumnExpression(null, (DbExpression)expression));
                return new ProjectionExpression(columns.AsReadOnly(), expression.Type, null);
            }
        }
    }
}
