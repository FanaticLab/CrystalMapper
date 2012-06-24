using System;
using System.Reflection;
using CrystalMapper.Mapping;
using System.Text;
using System.Collections.Generic;
using CrystalMapper.Generic;

namespace CrystalMapper.Helper
{
    public static class EntityQuery<T>
        where T : Entity<T>, new()
    {
        #region SQL Operators

        private const string SQL_AND = " AND ";
        private const string SQL_SELECT = " SELECT ";
        private const string SQL_WHERE = " WHERE ";
        private const string SQL_FROM = " FROM ";
        private const string SQL_ASTERISK = " * ";

        #endregion

        public static readonly string SelectQuery;
        public static readonly string TableName;

        private static readonly PropertyInfo[] columnProperties;
        private static readonly ColumnAttribute[] columnInfos;

        public static PropertyInfo[] ColumnProperties
        {
            get { return columnProperties; }
        }

        public static ColumnAttribute[] ColumnInfos
        {
            get { return columnInfos; }
        }

        static EntityQuery()
        {
            Type objectType = typeof(T);

            StringBuilder selectQuery = new StringBuilder(SQL_SELECT);
            foreach (PropertyInfo propertyInfo in objectType.GetProperties())
            {
                ColumnAttribute[] dbColumnAttributes;
                if ((dbColumnAttributes = (ColumnAttribute[])propertyInfo.GetCustomAttributes(typeof(ColumnAttribute), true)) != null
                    && dbColumnAttributes.Length == 1)
                    selectQuery.Append("[").Append(dbColumnAttributes[0].ColumnName).Append("],");
            }

            if (selectQuery.Length == SQL_SELECT.Length)
                selectQuery.Append(SQL_ASTERISK).Append(' ');

            selectQuery.Remove(selectQuery.Length - 1, 1).Append(SQL_FROM);

            TableAttribute[] tableAttr = (TableAttribute[])objectType.GetCustomAttributes(typeof(TableAttribute), true);

            TableName = (tableAttr != null || tableAttr.Length > 0) ? tableAttr[0].TableName : objectType.Name;

            selectQuery.Append(TableName);

            SelectQuery = selectQuery.ToString();

            List<PropertyInfo> columnPropertyList = new List<PropertyInfo>();
            List<ColumnAttribute> columnInfoList = new List<ColumnAttribute>();

            foreach (PropertyInfo propertyInfo in objectType.GetProperties())
            {
                ColumnAttribute[] dbColumnAttributes;
                if ((dbColumnAttributes = (ColumnAttribute[])propertyInfo.GetCustomAttributes(typeof(ColumnAttribute), true)) != null && dbColumnAttributes.Length == 1)
                {
                    columnPropertyList.Add(propertyInfo);
                    columnInfoList.Add(dbColumnAttributes[0]);
                }
            }

            columnProperties = columnPropertyList.ToArray();
            columnInfos = columnInfoList.ToArray();
        }

        public static string GetQuery()
        {
            return EntityQuery<T>.SelectQuery;
        }

        public static string GetQuery(Entity<T> entity, out Dictionary<string, object> parameterValues)
        {
            StringBuilder query = new StringBuilder(SelectQuery);
            parameterValues = new Dictionary<string, object>();

            query.Append(SQL_WHERE);
            for (int i = 0; i < columnProperties.Length; i++)
            {
                PropertyInfo propertyInfo = columnProperties[i];
                ColumnAttribute columnInfo = columnInfos[i];

                object propertyValue = propertyInfo.GetValue(entity, null);

                if (propertyValue != null)
                {
                    if (propertyValue is string && !propertyValue.Equals(columnInfo.DefTypeValue))
                    {
                        string propertyValueStr = (string)propertyValue;
                        query.Append("[").Append(columnInfo.ColumnName);
                        query.Append((propertyValueStr.Contains("*") || propertyValueStr.Contains("%")) ? "] Like " : "] = ");
                        query.Append(columnInfo.ParamName).Append(SQL_AND);
                        parameterValues.Add(columnInfo.ParamName, propertyValue);

                    }
                    else if (!propertyValue.Equals(columnInfo.DefTypeValue))
                    {
                        query.Append(" [").Append(columnInfo.ColumnName).Append("] = ").Append(columnInfo.ParamName).Append(SQL_AND);
                        parameterValues.Add(columnInfo.ParamName, propertyValue);

                    }
                }
            }

            if (parameterValues.Count > 0)
                query.Remove(query.Length - SQL_AND.Length, SQL_AND.Length);
            else
                query.Remove(query.Length - SQL_WHERE.Length, SQL_WHERE.Length);

            return query.ToString();
        }
    }
}
