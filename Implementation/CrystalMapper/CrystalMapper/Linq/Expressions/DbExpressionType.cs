using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystalMapper.Linq.Expressions
{
    internal enum DbExpressionType
    {
        Select = 1000,
        Table,
        Parameter,
        Projection,
        Column,
        Binary,
        Where,
        Member,
        Take,
        Remainder,
        Distinct,
        OrderBy,
        ThenBy,
        MultiSource,
        Method,
        Count,
        LongCount,
        Sum,
        Min,
        Max,
        Average,
        Join,
        In,
        GroupBy,
        Array
    }

}
