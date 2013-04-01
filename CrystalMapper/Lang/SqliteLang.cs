using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystalMapper.Lang
{
    // Overrides SQL language operators for SQLite
    internal class SqliteLang : SqlLang
    {
        public override SqlLangType SqlLangType
        {
            get { return Lang.SqlLangType.Sqlite; }
        }

        public override string GetParameter(string parameter)
        {
            return ":" + parameter;
        }
    }
}
