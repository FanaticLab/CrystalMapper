using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystalMapper.Linq.Expressions
{
    internal class ThenByExpression : SortExpression
    {
        public ThenByExpression(SortDirection sortDirection, DbExpression by, DbExpression source)
            : base(DbExpressionType.ThenBy, sortDirection, by, source)
        { }
    }
}
