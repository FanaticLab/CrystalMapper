using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystalMapper.Linq.Expressions
{
    internal abstract class IndirectExpression : DbExpression
    {
        public DbExpression Source { get; private set; }

        public IndirectExpression(DbExpression source, DbExpressionType dbNodeType, Type type)
            : base(dbNodeType, type)
        {
            this.Source = source;
        }
    }
}
