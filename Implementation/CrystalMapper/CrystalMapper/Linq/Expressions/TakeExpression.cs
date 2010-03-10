using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Lang;

namespace CrystalMapper.Linq.Expressions
{
    internal class TakeExpression : IndirectExpression
    {
        public int Count { get; private set; }

        public bool UseDefault { get; private set; }

        public bool IsReverse { get; private set; }

        public TakeExpression(int count, bool useDefault, bool isReverse, DbExpression source)
            : base(source, DbExpressionType.Take, typeof(int))
        {
            this.Count = count; 
            this.UseDefault = useDefault;
            this.IsReverse = isReverse;
        }

        public override void WriteQuery(SqlLang sqlLang, QueryWriter queryWriter)
        {
            switch (sqlLang.SqlLangType)
            {
                case SqlLangType.TSql:
                    queryWriter.Write(" TOP ").Write(this.Count).Write(" ");
                    break;
                case SqlLangType.Sqlite:
                    queryWriter.Write("LIMIT ").Write(this.Count).Write(" ");
                    break;
                case SqlLangType.PSql:
                    queryWriter.Write(" (ROWNUM <= ").Write(this.Count).Write(") ");
                    break;
                default:
                    throw new NotSupportedException(string.Format("Unable to transform take expression for lang: '{0}'", sqlLang.SqlLangType));
            }

        }
    }
}
