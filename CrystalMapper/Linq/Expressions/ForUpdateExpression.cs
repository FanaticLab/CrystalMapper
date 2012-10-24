using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Lang;

namespace CrystalMapper.Linq.Expressions
{
    internal class ForUpdateExpression : IndirectExpression
    {
        public ForUpdateExpression(DbExpression source)
            : base(source, DbExpressionType.ForUpdate, typeof(void))
        { }

        public override void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter)
        {
            queryWriter.Write("\nFOR UPDATE ");
        }
    }
}
