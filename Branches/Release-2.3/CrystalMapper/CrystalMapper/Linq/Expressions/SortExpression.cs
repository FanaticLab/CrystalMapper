using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Lang;

namespace CrystalMapper.Linq.Expressions
{
    internal abstract class SortExpression : IndirectExpression
    {
        public SortDirection SortDirection { get; private set; }

        public DbExpression By { get; private set; }

        public SortExpression(DbExpressionType dbNodeType, SortDirection sortDirection, DbExpression by, DbExpression source)
            : base(source, dbNodeType, typeof(void))
        {
            this.SortDirection = sortDirection;
            this.By = by;
        }

        public override void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter)
        {
            By.WriteQuery(sqlLang, queryWriter);

            queryWriter.Write(" ").Write(this.SortDirection.ToString().ToLower());
        }

        public void ReverseSortDirection()
        {
            this.SortDirection = this.SortDirection == SortDirection.Asc ? SortDirection.Desc : SortDirection.Asc;
        }

        public override IEnumerable<DbExpression> GetNodes()
        {
            yield return this;

            foreach (DbExpression expression in this.By.GetNodes())
                yield return expression;
        }
    }
}
