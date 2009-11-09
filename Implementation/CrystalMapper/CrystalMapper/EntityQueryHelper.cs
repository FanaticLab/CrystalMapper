using System;
using System.Reflection;
using CrystalMapper.Mapping;
using System.Text;
using System.Collections.Generic;

namespace CrystalMapper
{
    public static class EntityQuery<T>
        where T : Entity<T>, new()
    {
        #region SQL Operators

        private const string SQL_AND = " AND ";
        private const string SQL_SELECT = " SELECT ";
        private const string SQL_WHERE = " WHERE ";
        private const string SQL_FROM = " FROM ";

        #endregion

        private static readonly string SelectQuery;

        private static readonly PropertyInfo[] ColumnProperties;
        private static readonly ColumnAttribute[] ColumnInfos;

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
            selectQuery.Remove(selectQuery.Length - 1, 1).Append(SQL_FROM);

            TableAttribute[] tableAttr = (TableAttribute[])objectType.GetCustomAttributes(typeof(TableAttribute), true);
            if (tableAttr == null || tableAttr.Length != 1)
                throw new InvalidOperationException(string.Format("Class: '{0}' is not decorated with Table Name mapping attribute", objectType.Name));

            selectQuery.Append(tableAttr[0].TableName);

            SelectQuery = selectQuery.ToString();

            List<PropertyInfo> columnProperties = new List<PropertyInfo>();
            List<ColumnAttribute> columnInfos = new List<ColumnAttribute>();

            foreach (PropertyInfo propertyInfo in objectType.GetProperties())
            {
                ColumnAttribute[] dbColumnAttributes;
                if ((dbColumnAttributes = (ColumnAttribute[])propertyInfo.GetCustomAttributes(typeof(ColumnAttribute), true)) != null && dbColumnAttributes.Length == 1)
                {
                    columnProperties.Add(propertyInfo);
                    columnInfos.Add(dbColumnAttributes[0]);
                }
            }

            ColumnProperties = columnProperties.ToArray();
            ColumnInfos = columnInfos.ToArray();
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
            for (int i = 0; i < ColumnProperties.Length; i++)
            {
                PropertyInfo propertyInfo = ColumnProperties[i];
                ColumnAttribute columnInfo = ColumnInfos[i];

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
