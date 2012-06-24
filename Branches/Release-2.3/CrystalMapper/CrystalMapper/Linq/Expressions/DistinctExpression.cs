using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Lang;

namespace CrystalMapper.Linq.Expressions
{
    internal class DistinctExpression : IndirectExpression
    {
        public DistinctExpression(DbExpression source)
            : base(source, DbExpressionType.Distinct, typeof(int))
        { }

        public override void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter)
        {
            queryWriter.Write(" DISTINCT ");
        }
    }
}
