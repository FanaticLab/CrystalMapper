using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Lang;
using CrystalMapper.Linq.Helper;

namespace CrystalMapper.Linq.Expressions
{
    internal class DbParameterExpression : DbExpression
    {
        public object Value { get; private set; }

        public bool IsDBNull { get { return this.Value == DBNull.Value; } }

        public DbParameterExpression(object value)
            : base(DbExpressionType.Parameter, value != null ? value.GetType() : typeof(DBNull))
        {
            this.Value = value != null ? value : DBNull.Value;
        }

        public override void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter)
        {
            queryWriter.Write(FormatHelper.FormatDbValue(this.Value == DBNull.Value ? null : this.Value));
        }

    }
}
