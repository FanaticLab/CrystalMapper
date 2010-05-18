using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystalMapper.Lang
{
    internal enum SqlLangType
    {
        TSql,
        Sqlite,
        PSql
    }

    internal abstract class SqlLang
    {
        public abstract SqlLangType SqlLangType { get; }

        public static SqlLang GetSqlLang(SqlLangType sqlLangType)
        {
            switch (sqlLangType)
            {
                case SqlLangType.TSql:
                    return new TSqlLang();
                case SqlLangType.Sqlite:
                    return new SqliteLang();
                case SqlLangType.PSql:
                    return new PSqlLang();
                default:
                    throw new NotSupportedException(string.Format("CrystalMapper does not support Sql Language Type: {0}", sqlLangType));
            }
        }

        public virtual string GetParameter(string parameter)
        {
            return "@" + parameter;
        }

        public static SqlLang GetDefaultSqlLang()
        {
            return new TSqlLang();
        }

        public virtual bool IsAggregateSupportted(string aggregateName)
        {
            switch (aggregateName)
            {
                case "Count":
                case "LongCount":
                case "Sum":
                case "Min":
                case "Max":
                case "Average":
                    return true;
            }

            return false;
        }

        public virtual string SqlAggregateName(string aggregateName)
        {
            switch (aggregateName)
            {
                case "Average":
                    return "AVG";
                case "LongCount":
                    return "COUNT";
                default:
                    return aggregateName.ToUpper();
            }
        }

        public virtual bool AggregateArgumentIsPredicate(string aggregateName)
        {
            return aggregateName == "Count" || aggregateName == "LongCount";
        }
    }
}
