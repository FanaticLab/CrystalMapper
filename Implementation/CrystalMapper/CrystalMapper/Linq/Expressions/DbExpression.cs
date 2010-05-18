using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using System.Reflection;
using CrystalMapper.Lang;
using CrystalMapper.Linq.Metadata;


namespace CrystalMapper.Linq.Expressions
{
    internal abstract class DbExpression : Expression, ICloneable
    {
        public DbExpressionType DbNodeType { get { return (DbExpressionType)this.NodeType; } }

        public DbExpression(DbExpressionType nodeType)
            : this(nodeType, typeof(void))
        { }

        public DbExpression(DbExpressionType nodeType, Type type)
            : base((ExpressionType)nodeType, type)
        { }

        public abstract void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter);

        public virtual IEnumerable<DbExpression> GetNodes()
        {
            yield return this;
        }

        public override string ToString()
        {
            QueryWriter queryWriter = new QueryWriter();

            this.WriteQuery(SqlLang.GetDefaultSqlLang(), queryWriter);

            return queryWriter.ToString();
        }

        #region ICloneable Members

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
}
