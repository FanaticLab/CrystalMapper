﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using CrystalMapper.Lang;
using CrystalMapper.Linq.Metadata;
using System.Reflection;
using System.Data.Common;
using CoreSystem.Data;

namespace CrystalMapper.Linq.Expressions
{
    internal class ProjectionExpression : DbExpression
    {
        public ReadOnlyCollection<ColumnExpression> Columns { get; private set; }

        public Delegate ProjectionFunction { get; private set; }

        public ProjectionExpression(ReadOnlyCollection<ColumnExpression> columns, Type type, Delegate projectionFunction)
            : base(DbExpressionType.Projection, type)
        {
            this.Columns = columns;
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
            if (queryInfo.ReturnType.IsSubclassOf(typeof(Entity)))
            {
                while (reader.Read())
                {
                    Entity entity = (Entity)Activator.CreateInstance(queryInfo.ReturnType);
                    entity.Read(reader);
                    yield return entity;
                }
            }
            else if (queryInfo.ReturnType.IsPrimitive)
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        yield return System.Convert.ChangeType(reader.GetValue(i), queryInfo.ReturnType);
                }
            }
            else if (queryInfo.ReturnType == typeof(string))
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        object value = reader.GetValue(i);
                        yield return value == DBNull.Value ? null : value;
                    }
                }
            }
            else if (queryInfo.ReturnType == this.Type)
            {
                ConstructorInfo constructor = this.Type.GetConstructors()[0];
                PropertyInfo[] members = this.Type.GetProperties();

                while (reader.Read())
                {
                    int index = 0;
                    List<object> parameters = new List<object>();

                    foreach (PropertyInfo prop in members)
                        parameters.Add(GetObject(prop.PropertyType, reader, ref index));

                    yield return constructor.Invoke(parameters.ToArray());
                }
            }
            else
                throw new InvalidOperationException(string.Format("Cannot translate result into type '{0}'", queryInfo.ReturnType));
        }

        private object GetObject(Type type, DbDataReader reader, ref int index)
        {
            if (IsMemberType(type))
                return reader[index++];

            if (type.IsSubclassOf(typeof(Entity)))
            {
                object entity = Activator.CreateInstance(type);
                TableMetadata entityMetadata = MetadataProvider.GetMetadata(type);

                foreach (MemberMetadata memberMeta in entityMetadata.Members)
                    ((PropertyInfo)memberMeta.Member).SetValue(entity, DbConvert.ToObject(reader[index++]), null);

                return entity;
            }

            List<object> parameters = new List<object>();
            foreach (PropertyInfo propInfo in type.GetProperties())
            {
                if (IsMemberType(propInfo.PropertyType))
                    parameters.Add(reader[index++]);
                else
                    parameters.Add(GetObject(propInfo.PropertyType, reader, ref index));
            }

            return Activator.CreateInstance(type, parameters.ToArray());
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
                   || (type.IsGenericType
                       && type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
    }
}
