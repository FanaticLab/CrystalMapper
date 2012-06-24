using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystalMapper.Lang
{
    internal class TSqlLang : SqlLang
    {
        public override SqlLangType SqlLangType
        {
            get { return Lang.SqlLangType.TSql; }
        }

        public override string SqlAggregateName(string aggregateName)
        {
            return aggregateName == "LongCount" ? "COUNT_BIG" : base.SqlAggregateName(aggregateName);
        }
    }
}
