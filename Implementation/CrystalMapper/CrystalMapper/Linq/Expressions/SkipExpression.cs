using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Lang;

namespace CrystalMapper.Linq.Expressions
{
    internal class SkipExpression : IndirectExpression
    {
        public int Count { get; private set; }

        public SkipExpression(int count, DbExpression source)
            : base(source, DbExpressionType.Skip, typeof(int))
        {
            this.Count = count; 
        }

        public override void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter)
        {
            switch (sqlLang.SqlLangType)
            {               
                case SqlLangType.MySql:
                case SqlLangType.Sqlite:                
                    queryWriter.Write("LIMIT ").Write(this.Count).Write(", ").Write(int.MaxValue);
                    break;
                case SqlLangType.PSql:
                    queryWriter.Write(" (ROWNUM > ").Write(this.Count).Write(") ");
                    break;
                default:
                    throw new NotSupportedException(string.Format("Unable to transform skip expression for lang: '{0}'", sqlLang.SqlLangType));
            }
        }
    }
}
