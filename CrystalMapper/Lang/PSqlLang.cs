using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace CrystalMapper.Lang
{
    // Overrides SQL language operators for Oracle
    internal class PSqlLang : SqlLang
    {
        public override SqlLangType SqlLangType
        {
            get { return Lang.SqlLangType.PSql; }
        }

        public override string GetParameter(string parameter)
        {
            return ":" + parameter;
        }
    }
}
