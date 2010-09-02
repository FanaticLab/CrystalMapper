﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystalMapper.Lang
{
    internal class MySqlLang : SqlLang
    {
        public override SqlLangType SqlLangType
        {
            get { return SqlLangType.MySql; }
        }

        public override string Wrap(string name)
        {
            return name;
        }
    }
}
