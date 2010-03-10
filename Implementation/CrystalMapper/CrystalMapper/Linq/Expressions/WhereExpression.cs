using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Lang;

namespace CrystalMapper.Linq.Expressions
{
    internal class WhereExpression : IndirectExpression
    {
        public DbBinaryExpression BinaryExpression { get; private set; }

        public WhereExpression(DbExpression source, DbBinaryExpression binaryExpression)
            : base(source, DbExpressionType.Where, typeof(bool))
        {
            this.BinaryExpression = binaryExpression;
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
