using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystalMapper.Linq.Expressions
{
    internal abstract class SourceExpression : DbExpression
    {
        public string Alias { get; private set; }        

        public SourceExpression(string alias, DbExpressionType DbNodeType, Type type)
            : base(DbNodeType, type)
        {           
            this.Alias = alias;
        }

        public abstract string GetAlias(Type type);
    }
}
