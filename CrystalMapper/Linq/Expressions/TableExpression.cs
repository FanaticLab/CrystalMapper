using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Linq.Metadata;
using CrystalMapper.Lang;
using System.Reflection;
using System.Collections.Concurrent;

namespace CrystalMapper.Linq.Expressions
{
    internal class TableExpression : SourceExpression
    {
        private static ConcurrentDictionary<Type, TableExpression> TableExpressions = new ConcurrentDictionary<Type, TableExpression>();

        public TableMetadata TableMetadata { get; private set; }

        public TableExpression(string alias, TableMetadata metadata)
            : this(alias, metadata, GetProjectionExpression(alias, metadata))
        { }

        public TableExpression(string alias, TableMetadata metadata, ProjectionExpression projection)
            :base(alias, projection, DbExpressionType.Table, metadata.Type)
        {
            if (metadata == null)
                throw new ArgumentNullException("metadata");

            this.TableMetadata = metadata;
        }

        public override void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter)
        {
            queryWriter.Write(this.TableMetadata.TableName).Write(" AS ").Write(this.Alias);
        }

        public override string GetAlias(MemberInfo memberInfo)
        {
            return ( memberInfo.DeclaringType == this.TableMetadata.Type || memberInfo == this.TableMetadata.Type) ? this.Alias : null;
        }

        public static ProjectionExpression GetProjectionExpression(string tableAlias, TableMetadata tableMetadata)
        {
            var columns = from m in tableMetadata.Members
                          select new ColumnExpression(m, new DbMemberExpression(m));

            return new ProjectionExpression(columns.ToList().AsReadOnly(), tableMetadata.Type);
        }

        public static TableExpression GetExpression(string alias, Type type)
        {
            if(!TableExpressions.TryGetValue(type, out TableExpression expression))
            {
                expression = new TableExpression(alias, MetadataProvider.GetMetadata(type));
                TableExpressions.TryAdd(type, expression);
            }

            return new TableExpression(alias, expression.TableMetadata, expression.Projection);
        }
    }
}
