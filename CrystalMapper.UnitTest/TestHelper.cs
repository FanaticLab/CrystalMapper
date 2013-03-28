using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Context;
using System.Data.Common;
using CoreSystem.Data;

namespace CrystalMapper.UnitTest
{
    public static class TestHelper
    {
        public static object ExecuteScalar(string sqlQuery)
        {
            using (DataContext dataContext = new DataContext())
            {
                using (DbCommand command = dataContext.CreateCommand(sqlQuery))
                {
                    return DbConvert.CLRValue(command.ExecuteScalar());
                }
            }
        }

        public static T ExecuteScalar<T>(string sqlQuery)
        {   
            Type typeOfT = typeof(T);
            if (typeOfT.IsGenericType && typeOfT.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                object value = ExecuteScalar(sqlQuery);
                if(value != null)
                    return (T)Convert.ChangeType(value, typeOfT.GetGenericArguments()[0]);

                return (T)Activator.CreateInstance(typeOfT);
            }

            return (T)Convert.ChangeType(ExecuteScalar(sqlQuery), typeof(T));
        }
    }
}
