using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Linq.Metadata;
using CrystalMapper.Lang;

namespace CrystalMapper.Linq.Expressions
{
    internal class TableExpression : SourceExpression
    {
        public TableMetadata TableMetadata { get; private set; }

        public TableExpression(string alias, TableMetadata tableMetadata)
            : base(alias, GetProjectionExpression(tableMetadata), DbExpressionType.Table, tableMetadata.Type)
        {
            if (tableMetadata == null)
                throw new ArgumentNullException("tableMetadata");

            this.TableMetadata = tableMetadata;
        }

        public override void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter)
        {
            queryWriter.Write(this.TableMetadata.TableName).Write(" AS ").Write(this.Alias);
        }

        public override string GetAlias(Type type)
        {
            return (type == this.TableMetadata.Type) ? this.Alias : null;
        }

        public static ProjectionExpression GetProjectionExpression(TableMetadata tableMetadata)
        {
            var columns = from m in tableMetadata.Members
                          select new ColumnExpression(m, new DbMemberExpression(m));

            return new ProjectionExpression(columns.ToList().AsReadOnly(), tableMetadata.Type);
        }
    }
}
