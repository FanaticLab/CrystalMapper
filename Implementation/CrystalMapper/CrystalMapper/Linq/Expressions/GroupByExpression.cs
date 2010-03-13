using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Lang;

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
