using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using CrystalMapper.Lang;
using CrystalMapper.Linq.Metadata;
using System.Reflection;
using System.Data.Common;
using CoreSystem.Data;
using System.Collections;
using CrystalMapper.ObjectModel;
using System.Linq.Expressions;

namespace CrystalMapper.Linq.Expressions
{
    internal class ProjectionExpression : DbExpression
    {
        public ReadOnlyCollection<ColumnExpression> Columns { get; private set; }

        public Delegate ProjectionFunction { get; private set; }

        public ReadOnlyCollection<MemberBinding> Bindings { get; private set; }

        public ProjectionExpression(ReadOnlyCollection<ColumnExpression> columns, Type type)
            : base(DbExpressionType.Projection, type)
        {
            this.Columns = columns;
        }

        public ProjectionExpression(ReadOnlyCollection<ColumnExpression> columns, Type type, Delegate projectionFunction)
            : this(columns, type, projectionFunction, null)
        { }

        public ProjectionExpression(ReadOnlyCollection<ColumnExpression> columns, Type type, ReadOnlyCollection<MemberBinding> bindings)
            : this(columns, type, null, bindings)
        { }

        public ProjectionExpression(ReadOnlyCollection<ColumnExpression> columns, Type type, Delegate projectionFunction, ReadOnlyCollection<MemberBinding> bindings)
            : base(DbExpressionType.Projection, type)
        {
            this.Columns = columns;
            this.Bindings = bindings;
            this.ProjectionFunction = projectionFunction;
        }

        public override void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter)
        {
            bool isFirst = true;
            foreach (var column in this.Columns)
            {
                if (!isFirst)
                    queryWriter.Write(", ");
                else
                    isFirst = false;

                column.WriteQuery(sqlLang, queryWriter);
            }
        }

        public override IEnumerable<DbExpression> GetNodes()
        {
            yield return this;

            foreach (ColumnExpression column in this.Columns)
                foreach (DbExpression expression in column.GetNodes())
                    yield return expression;
        }

        public IEnumerable<object> Translate(QueryInfo queryInfo, DbDataReader reader)
        {
            if (typeof(IRecord).IsAssignableFrom(queryInfo.ReturnType))
            {
                while (reader.Read())
                {
                    var record = (IRecord)Activator.CreateInstance(queryInfo.ReturnType);
                    record.Read(reader);
                    yield return record;
                }
            }
            else if (queryInfo.ReturnType.IsPrimitive || queryInfo.ReturnType == typeof(DateTime))
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var value = reader.GetValue(i);
                        yield return (value == DBNull.Value)
                            ? Activator.CreateInstance(queryInfo.ReturnType)
                            : System.Convert.ChangeType(reader.GetValue(i), queryInfo.ReturnType);
                    }
                }
            }
            else if (queryInfo.ReturnType == typeof(string)
                 || (queryInfo.ReturnType.IsGenericType && queryInfo.ReturnType.GetGenericTypeDefinition() == typeof(Nullable<>)))
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        yield return DbConvert.CLRValue(reader.GetValue(i));
                }
            }
            else if (queryInfo.ReturnType == this.Type)
            {
                int index = 0;
                var constructor = this.Type.GetConstructors()[0];

                if (this.Bindings != null)
                {
                    while (reader.Read())
                    {
                        var value = constructor.Invoke(null);

                        foreach (MemberAssignment binding in this.Bindings)
                            binding.Member.SetValue(value, GetObject(binding.Expression.Type, reader, ref index));

                        yield return value;

                        index = 0;
                    }
                }
                else
                {
                    while (reader.Read())
                    {
                        yield return this.GetObject(this.Type, reader, ref index);
                        index = 0;
                    }
                }
            }
            else
                throw new InvalidOperationException(string.Format("Cannot translate result into type '{0}'", queryInfo.ReturnType));
        }

        public override object Clone()
        {
            return new ProjectionExpression(this.Columns.Select(c => (ColumnExpression)c.Clone()).ToReadOnly(), this.Type, this.ProjectionFunction, this.Bindings);
        }

        private object GetObject(Type type, DbDataReader reader, ref int index)
        {
            if (IsMemberType(type))
            {
                try
                {
                    //if (type.IsAssignableFrom(reader.GetFieldType(index)))
                        return DbConvert.CLRValue(reader[index++]);

                    return System.Convert.ChangeType(reader[index++], type);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Cannot assign value for column: {reader.GetName(index - 1)} at index: {index - 1}", ex);
                }
            }

            if (typeof(IRecord).IsAssignableFrom(type))
            {
                object entity = Activator.CreateInstance(type);
                TableMetadata entityMetadata = MetadataProvider.GetMetadata(type);

                foreach (MemberMetadata mbMetadata in entityMetadata.Members)
                    ((PropertyInfo)mbMetadata.Member).SetValue(entity, DbConvert.CLRValue(reader[index++]), null);

                return entity;
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                Type[] genericTypes = type.GetGenericArguments();
                IList list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(genericTypes));
                list.Add(GetObject(genericTypes[0], reader, ref index));

                return list;
                //throw new InvalidOperationException(string.Format("IEnumerable<T> type cannot be projected", type.GetGenericArguments()[0]));
            }

            if (type.Name.Contains("AnonymousType") && type.IsClass)
            {
                List<object> parameters = new List<object>();
                foreach (PropertyInfo propInfo in type.GetProperties())
                {
                    parameters.Add(GetObject(propInfo.PropertyType, reader, ref index));
                }

                return Activator.CreateInstance(type, parameters.ToArray());
            }

            var record = Activator.CreateInstance(type);
            foreach (var propInfo in this.Columns.Select(c => c.Member.Member as PropertyInfo).Where(m => m.DeclaringType == type))
            {
                propInfo.SetValue(record, GetObject(propInfo.PropertyType, reader, ref index));
            }

            return record;
        }

        private IEnumerable<ColumnExpression> GetColumns(Type type)
        {
            TableMetadata tableMetadata = MetadataProvider.GetMetadata(type);
            if (tableMetadata != null)
                foreach (ColumnExpression column in tableMetadata.Members.Select(m => new ColumnExpression(m, new DbMemberExpression(m))))
                    yield return column;
            else
            {
                foreach (PropertyInfo propInfo in type.GetProperties())
                {
                    if (IsMemberType(propInfo.PropertyType))
                        yield return new ColumnExpression(new MemberMetadata(propInfo), new DbMemberExpression(new MemberMetadata(propInfo)));

                    foreach (ColumnExpression column in GetColumns(propInfo.PropertyType))
                        yield return column;
                }
            }
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
