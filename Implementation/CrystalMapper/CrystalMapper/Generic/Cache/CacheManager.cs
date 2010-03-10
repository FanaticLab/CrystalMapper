﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Data;
using CrystalMapper.Policy;
using CrystalMapper.Helper;
using System.Data;
using CrystalMapper.Mapping;
using System.Threading;
using System.Data.Common;
using System.Reflection;
using CoreSystem.Data;
using CrystalMapper.Generic;

namespace CrystalMapper.Cache
{
    public static class CacheManager
    {
        public static void Initialize()
        {
            CacheProvider.Initialize();
            CreateCacheSchema();
        }

        public static DataContext GetDataContext<T>()
            where T : Entity<T>, new()
        {
            CachePolicy cachePolicy = PolicyHelper<T>.CachePolicy;
            if (cachePolicy != null)
                if (cachePolicy.IsExpired)
                    RefreshCache<T>(cachePolicy);
                else
                    return CacheProvider.GetCacheContext();

            return null;
        }

        private static void RefreshCache<T>(CachePolicy cachePolicy)
            where T : Entity<T>, new()
        {
            if (!Monitor.TryEnter(cachePolicy))
                return;
            try
            {
                Thread thread = new Thread(new ParameterizedThreadStart(AsyncRefresh<T>));
                thread.Start(cachePolicy);
            }
            finally
            {
                Monitor.Exit(cachePolicy);
            }
        }

        private static void AsyncRefresh<T>(object cachePolicy)
            where T : Entity<T>, new()
        {
            lock (cachePolicy)
            {
                CachePolicy cachePlcy = cachePolicy as CachePolicy;
                if (cachePlcy != null)
                {
                    int result = 0;
                    string dropTableStatement = PrepareDropTableStatement<T>();
                    string createTableStatement = PrepareCreateTableStatement<T>();
                    string InsertTableStatement = PrepareInsertStatement<T>();

                    T[] entities = Entity<T>.List(); 

                    using (DataContext dataContext = CacheProvider.GetCacheContext())
                    {
                        dataContext.BeginTransaction();

                        using (DbCommand command = dataContext.CreateCommand(dropTableStatement))
                        {
                            try { result = command.ExecuteNonQuery(); }
                            catch { }

                            command.CommandText = createTableStatement;
                            result = command.ExecuteNonQuery();

                            command.CommandText = InsertTableStatement;

                            foreach (T entity in entities)
                            {
                                command.Parameters.Clear();
                                for (int i = 0; i < EntityQuery<T>.ColumnInfos.Length; i++)
                                {
                                    PropertyInfo propertyInfo = EntityQuery<T>.ColumnProperties[i];
                                    ColumnAttribute colAttribute = EntityQuery<T>.ColumnInfos[i];
                                    DbParameter dbParam = dataContext.CreateParameter(propertyInfo.GetValue(entity, null) ?? DBNull.Value, colAttribute.ParamName);
                                    if (dbParam.Value is DateTime)
                                        dbParam.DbType = DbType.DateTime;
                                    command.Parameters.Add(dbParam);
                                }

                                result = command.ExecuteNonQuery();
                            }
                        }

                        dataContext.CommitTransaction();
                        cachePlcy.ExpireTime = DateTime.Now.Add(cachePlcy.ExpireDuration);
                    }
                }
            }
        }

        private static string PrepareCreateTableStatement<T>()
                  where T : Entity<T>, new()
        {
            string createTableQuery = "CREATE TABLE [" + EntityQuery<T>.TableName + "] (";

            for (int i = 0; i < EntityQuery<T>.ColumnInfos.Length; i++)
            {
                PropertyInfo propertyInfo = EntityQuery<T>.ColumnProperties[i];
                ColumnAttribute columnAttribute = EntityQuery<T>.ColumnInfos[i];
                createTableQuery += " [" + columnAttribute.ColumnName + "] " + CacheProvider.GetProviderType(propertyInfo.PropertyType) + ",";
            }

            createTableQuery = createTableQuery.TrimEnd(',') + ");";

            return createTableQuery;
        }

        private static string PrepareDropTableStatement<T>()
            where T : Entity<T>, new()
        {
            return "DROP TABLE [" + EntityQuery<T>.TableName + "];";
        }

        private static string PrepareInsertStatement<T>()
            where T : Entity<T>, new()
        {
            string insertAutoQuery = "INSERT INTO [" + EntityQuery<T>.TableName + "] (";
            foreach (ColumnAttribute columnAttribute in EntityQuery<T>.ColumnInfos)
                insertAutoQuery += " [" + columnAttribute.ColumnName + "],";

            insertAutoQuery = insertAutoQuery.TrimEnd(',') + ") VALUES (";

            foreach (ColumnAttribute columnAttribute in EntityQuery<T>.ColumnInfos)
                insertAutoQuery += columnAttribute.ParamName + ",";

            insertAutoQuery = insertAutoQuery.TrimEnd(',') + ");";

            return insertAutoQuery;
        }

        private static void CreateCacheSchema()
        {
            // throw new NotImplementedException();
        }

    }
}
