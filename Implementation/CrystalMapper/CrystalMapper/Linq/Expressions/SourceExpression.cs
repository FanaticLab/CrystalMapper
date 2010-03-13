using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystalMapper.Linq.Expressions
{
    internal abstract class SourceExpression : DbExpression
    {
        public string Alias { get; private set; }

        public ProjectionExpression Projection { get; private set; }

        public SourceExpression(string alias, ProjectionExpression projection, DbExpressionType DbNodeType, Type type)
            : base(DbNodeType, type)
        {           
            this.Alias = alias;
            this.Projection = projection;
        }

        public abstract string GetAlias(Type type);
    }
}
