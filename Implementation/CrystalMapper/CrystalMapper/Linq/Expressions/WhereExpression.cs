using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Lang;

namespace CrystalMapper.Linq.Expressions
{
    internal class WhereExpression : IndirectExpression
    {
        public DbExpression BinaryExpression { get; private set; }

        public WhereExpression(DbExpression source, DbExpression expression)
            : base(source, DbExpressionType.Where, typeof(bool))
        {
            if (expression is DbBinaryExpression || expression is DbMethodCallExpression)
                this.BinaryExpression = expression;
            else
                throw new InvalidOperationException("Where should have method call or binary expression");
        }

        public override void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter)
        {
            this.BinaryExpression.WriteQuery(sqlLang, queryWriter);
        }

        public override IEnumerable<DbExpression> GetNodes()
        {
            yield return this;

            foreach (DbExpression expression in this.BinaryExpression.GetNodes())
                yield return expression;
        }
    }
}
