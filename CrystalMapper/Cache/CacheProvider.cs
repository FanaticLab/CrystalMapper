using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Context;
using CoreSystem.Data;
using System.Data.Common;

namespace CrystalMapper.Cache
{
    public static class CacheProvider
    {
        private const string CONNECTION_STRING = "Data Source=:memory:;Version=3;New=True;Pooling=True;Max Pool Size=1;";

        private const string PROVIDER_NAME = "System.Data.SQLite";

        private const string CACHE_DB_NAME = "Cache-Db";
        
        private static Database CacheDb;

        public static void Initialize()
        {           
            CacheProvider.CacheDb = new Database(CACHE_DB_NAME, PROVIDER_NAME, CONNECTION_STRING);
        }

        public static DataContext GetCacheContext()
        {
            return new DataContext(CacheProvider.CacheDb);  
        }

        //public static DataContext GetCacheContext(DbConnection connection)
        //{
        //    return new DataContext(CacheDb, connection);
        //}

        public static string GetProviderType(Type type)
        {
            if (type.IsGenericType)
                type = type.GetGenericArguments()[0];

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean:
                    return "BIT";
                case TypeCode.DateTime:
                    return "SMALLDATE";
                case TypeCode.Decimal:
                    return "NUMERIC";
                case TypeCode.Double:
                    return "DOUBLE";                
                case TypeCode.Byte:
                case TypeCode.SByte:
                    return "TINYINT";              
                case TypeCode.Int16:
                case TypeCode.UInt16:
                    return "SMALLINT";
                case TypeCode.Int32:
                case TypeCode.UInt32:
                    return "INT";
                case TypeCode.Int64:
                case TypeCode.UInt64: 
                    return "BIGINT";
                case TypeCode.Single:
                    return "FLOAT";
                case TypeCode.Object:
                    return "BLOB";
                case TypeCode.Char:
                case TypeCode.String:
                    return "TEXT COLLATE NOCASE";
                case TypeCode.DBNull:
                case TypeCode.Empty:                    
                default:
                    return "NONE";
            }
        }
    }
}
