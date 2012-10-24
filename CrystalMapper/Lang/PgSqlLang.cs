using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystalMapper.Lang
{
    internal class PgSqlLang : SqlLang
    {
        public override SqlLangType SqlLangType
        {
            get { return SqlLangType.PgSql; }
        }

        public override string Wrap(string name)
        {
            return name;
        }
    }
}
