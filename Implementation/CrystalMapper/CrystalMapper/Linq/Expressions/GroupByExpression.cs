using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Lang;
using CoreSystem.RefTypeExtension;

namespace CrystalMapper.Linq.Expressions
{
    internal class GroupByExpression : IndirectExpression
    {
        public DbExpression ByColumn { get; private set; }

        public GroupByExpression(DbExpression source, DbExpression byColumn)
            : base(source, DbExpressionType.GroupBy, typeof(void))
        {
            this.ByColumn = byColumn;
        }

        public override void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter)
        {
            if (this.ByColumn is ProjectionExpression)
            {
                bool isFirst = true;
                foreach (var column in ((ProjectionExpression)this.ByColumn).Columns)
                {
                    if (!isFirst)
                        queryWriter.Write(", ");
                    else
                        isFirst = false;

                    column.Column.WriteQuery(sqlLang, queryWriter);
                }
            }
            else
                this.ByColumn.WriteQuery(sqlLang, queryWriter);
        }

        public override IEnumerable<DbExpression> GetNodes()
        {
            yield return this;

            foreach (DbExpression exp in this.ByColumn.GetNodes())
                yield return exp;
        }
    }
}
