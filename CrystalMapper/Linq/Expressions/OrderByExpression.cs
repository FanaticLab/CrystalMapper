using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystalMapper.Linq.Expressions
{
    internal class OrderByExpression : SortExpression
    {
        public OrderByExpression(SortDirection sortDirection, DbExpression by, DbExpression source)
            : base(DbExpressionType.OrderBy, sortDirection, by, source)
        { }
    }
}
