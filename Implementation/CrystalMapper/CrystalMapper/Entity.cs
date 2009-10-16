/*
 * Author: Faraz Masood Khan 
 * 
 * Date: 6/5/2009 1:20:46 PM
 * 
 * Class: Entity
 * 
 * Copyright: Faraz Masood Khan @ Copyright ©  2009
 * 
 * Email: mk.faraz@gmail.com
 * 
 * Blogs: http://csharplive.wordpress.com, http://farazmasoodkhan.wordpress.com
 * 
 */


using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.Serialization;

using CrystalMapper.Data;
using CrystalMapper.Mapping;

using CoreSystem.Data;

namespace CrystalMapper
{
    public abstract class Entity<T>
        where T : Entity<T>, new()
    {
        #region SQL Operators

        private const string SQL_AND = " AND ";
        private const string SQL_SELECT = " SELECT ";
        private const string SQL_WHERE = " WHERE ";
        private const string SQL_FROM = " FROM ";

        #endregion

        #region  Types

        private static readonly Type StringType = typeof(string);
        private static readonly Type DecimalType = typeof(decimal);
        private static readonly Type DateTimeType = typeof(DateTime);

        #endregion

        #region Default Primitive Values

        private static readonly int DefInt32 = default(int);
        private static readonly string DefString = default(string);
        private static readonly decimal DefDecimal = default(decimal);
        private static readonly DateTime DefDateTime = default(DateTime);

        #endregion

        public abstract void Read(DbDataReader reader);

        public abstract bool Update(DataContext dataContext);

        public abstract bool Create(DataContext dataContext);

        public abstract bool Delete(DataContext dataContext);

        public bool Create()
        {
            Database db = DbFactory.GetDefaultDatabase();
            using (DataContext dataContext = new DataContext(db))
            {
                dataContext.BeginTransaction();
                bool retVal = this.Create(dataContext);
                dataContext.CommitTransaction();

                return retVal;
            }

        }

        public bool Update()
        {
            Database db = DbFactory.GetDefaultDatabase();
            using (DataContext dataContext = new DataContext(db))
            {
                dataContext.BeginTransaction();
                bool retVal = this.Update(dataContext);
                dataContext.CommitTransaction();
                return retVal;
            }
        }

        public bool Delete()
        {
            Database db = DbFactory.GetDefaultDatabase();
            using (DataContext dataContext = new DataContext(db))
            {
                dataContext.BeginTransaction();
                bool retVal = this.Delete(dataContext);
                dataContext.CommitTransaction();

                return retVal;
            }
        }

        public T[] ToList()
        {
            using (DataContext dataContext = new DataContext(DbFactory.GetDefaultDatabase()))
            {
                return this.ToList(dataContext);
            }
        }

        public T[] ToList(DataContext dataContext)
        {
            Dictionary<string, object> parameterValues;
            String query = this.GetQuery(out parameterValues);

            using (DbCommand command = dataContext.CreateCommand(query))
            {
                foreach (string param in parameterValues.Keys)
                    command.Parameters.Add(dataContext.CreateParameter(parameterValues[param], param));
                using (DbDataReader reader = command.ExecuteReader())
                {
                    return ToList(reader);
                }
            }
        }
      
        protected string GetQuery(out Dictionary<string, object> parameterValues)
        {
            Type objectType = this.GetType();
            StringBuilder query = new StringBuilder(SQL_SELECT);

            foreach (PropertyInfo propertyInfo in objectType.GetProperties())
            {
                ColumnAttribute[] dbColumnAttributes;
                if ((dbColumnAttributes = (ColumnAttribute[])propertyInfo.GetCustomAttributes(typeof(ColumnAttribute), true)) != null
                    && dbColumnAttributes.Length == 1)
                {
                    if (dbColumnAttributes[0].IsSensitiveColumn)
                    {
                        object propertyValue = propertyInfo.GetValue(this, null);
                        if (StringType.Equals(propertyInfo.PropertyType))
                            query.Append("'' ").Append(dbColumnAttributes[0].ColumnName).Append(",");
                        else if (DecimalType.Equals(propertyInfo.PropertyType))
                            query.Append("0 ").Append(dbColumnAttributes[0].ColumnName).Append(",");
                        else if (DateTimeType.Equals(propertyInfo.PropertyType))
                            query.Append("SYSDATE ").Append(dbColumnAttributes[0].ColumnName).Append(",");
                    }
                    else
                        query.Append(dbColumnAttributes[0].ColumnName).Append(",");
                }
            }
            query.Remove(query.Length - 1, 1).Append(SQL_FROM);

            TableAttribute[] tableAttr = (TableAttribute[])objectType.GetCustomAttributes(typeof(TableAttribute), true);
            if (tableAttr == null || tableAttr.Length != 1)
                throw new InvalidOperationException(string.Format("Class: '{0}' is not decorated with Table Name mapping attribute", objectType.Name));

            parameterValues = new Dictionary<string, object>();
            query.Append(tableAttr[0].TableName).Append(SQL_WHERE);

            foreach (PropertyInfo propertyInfo in objectType.GetProperties())
            {
                ColumnAttribute[] dbColumnAttributes;
                if ((dbColumnAttributes = (ColumnAttribute[])propertyInfo.GetCustomAttributes(typeof(ColumnAttribute), true)) != null
                    && dbColumnAttributes.Length == 1)
                {
                    object propertyValue = propertyInfo.GetValue(this, null);

                    if (propertyValue is string && ((string)propertyValue) != DefString)
                    {
                        query.Append(" LOWER(").Append(dbColumnAttributes[0].ColumnName).Append(") Like LOWER(").Append(dbColumnAttributes[0].ParamName).Append(")").Append(SQL_AND);
                        parameterValues.Add(dbColumnAttributes[0].ParamName, propertyValue);

                    }
                       
                    else if (propertyValue is decimal && ((decimal)propertyValue) != DefDecimal)
                    {
                        query.Append(" ").Append(dbColumnAttributes[0].ColumnName).Append(" = ").Append(dbColumnAttributes[0].ParamName).Append(SQL_AND);
                        parameterValues.Add(dbColumnAttributes[0].ParamName, propertyValue);

                    }
                    else if (propertyValue is DateTime && ((DateTime)propertyValue) != DefDateTime)
                    {
                        query.Append(" ").Append(dbColumnAttributes[0].ColumnName).Append(" = ").Append(dbColumnAttributes[0].ParamName).Append(SQL_AND);
                        parameterValues.Add(dbColumnAttributes[0].ParamName, propertyValue);
                    }
                    else if (propertyValue is int && ((int)propertyValue) != DefInt32)
                    {
                        query.Append(" ").Append(dbColumnAttributes[0].ColumnName).Append(" = ").Append(dbColumnAttributes[0].ParamName).Append(SQL_AND);
                        parameterValues.Add(dbColumnAttributes[0].ParamName, propertyValue);
                    }
                }
            }

            string queryStr = query.ToString();
            if (queryStr.EndsWith(SQL_AND))
                query.Remove(query.Length - SQL_AND.Length, SQL_AND.Length);
            else if (queryStr.EndsWith(SQL_WHERE))
                query.Remove(query.Length - SQL_WHERE.Length, SQL_WHERE.Length);

            return query.ToString();
        }

        public static T[] ToList(DbDataReader reader)
        {
            List<T> listOfT = new List<T>();
            while (reader.Read())
            {
                T objectOfT = new T();
                objectOfT.Read(reader);
                listOfT.Add(objectOfT);
            }

            return listOfT.ToArray();
        }

        public static T[] ToList(String sqlQuery)
        {
            using (DataContext dataContext = new DataContext(DbFactory.GetDefaultDatabase()))
            {
                using (DbCommand command = dataContext.CreateCommand(sqlQuery))
                {
                    return ToList(command.ExecuteReader(CommandBehavior.SequentialAccess));
                }
            }
        }

        /// <summary>
        /// Update all entities in a transaction
        /// </summary>
        /// <param name="entities">Entities to update in database</param>
        /// <returns>Return number of entities updated successfuly</returns>
        public static int Update(params T[] entities)
        {
            int retVal = 0;
            Database db = DbFactory.GetDefaultDatabase();

            using (DataContext dataContext = new DataContext(db))
            {
                dataContext.BeginTransaction();

                foreach (T entity in entities)
                    if (entity.Update(dataContext))
                        retVal++;

                dataContext.CommitTransaction();
            }

            return retVal;
        }
    }
}

