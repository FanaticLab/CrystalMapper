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

using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using CoreSystem.Data;

using CrystalMapper.Data;
using CrystalMapper.Helper;
using CrystalMapper.Cache;
using System.Linq;
using CrystalMapper.Linq;
using System;


namespace CrystalMapper.Generic
{    
    public abstract class Entity<T> : Entity
        where T : Entity<T>, new()
    {
        public static IQueryable<T> Query()
        {
            return new Query<T>();
        }

        public static IQueryable<T> Query(string name)
        {
            return new Query<T>(name);
        }

        public static IQueryable<T> Query(DataContext dataContext)
        {
            return new Query<T>(dataContext);
        }    

        #region Methods

        private static DataContext GetDataContext()
        {
            return CacheManager.GetDataContext<T>() ?? new DataContext();
        }

        public T[] ToList()
        {
            using (DataContext dataContext = GetDataContext())
            {
                return this.ToList(dataContext);
            }
        }

        public T[] ToList(DataContext dataContext)
        {
            Dictionary<string, object> parameterValues;
            string query = EntityQuery<T>.GetQuery(this, out parameterValues);
       
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

        #region Static Methods

        public static T[] List()
        {
            return ToList(EntityQuery<T>.GetQuery());
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

        public static T[] ToList(string sqlQuery)
        {
            using (DataContext dataContext = new DataContext())
            {
                return ToList(sqlQuery, dataContext);
            }
        }

        public static T[] ToList(string sqlQuery, DataContext dataContext)
        {
            using (DbCommand command = dataContext.CreateCommand(sqlQuery))
            {
                using (DbDataReader reader = command.ExecuteReader())
                {
                    return ToList(reader);
                }
            }
        }

        public static T[] ToList(string sqlQuery, Dictionary<string, object> parameterValues)
        {
            using (DataContext dataContext = GetDataContext())
            {
                return ToList(sqlQuery, parameterValues, dataContext);
            }
        }

        public static T[] ToList(string sqlQuery, Dictionary<string, object> parameterValues, DataContext dataContext)
        {
            using (DbCommand command = dataContext.CreateCommand(sqlQuery))
            {
                if (parameterValues != null)
                    foreach (string param in parameterValues.Keys)
                        command.Parameters.Add(dataContext.CreateParameter(parameterValues[param], param));

                using (DbDataReader reader = command.ExecuteReader())
                {
                    return ToList(reader);
                }
            }
        }

        /// <summary>
        /// Update all entities in a transaction
        /// </summary>
        /// <param name="entities">Entities to update in database</param>
        /// <returns>Return number of entities updated successfuly</returns>
        public static int Update(T[] entities)
        {
            int retVal = 0;
            
            using (DataContext dataContext = new DataContext())
            {
                dataContext.BeginTransaction();

                foreach (T entity in entities)
                    if (entity.Update(dataContext))
                        retVal++;

                dataContext.CommitTransaction();
            }

            return retVal;
        }

        public static void Delete(IEnumerable<T> entities)
        {
            Entity.Delete(ConvertToEntity(entities));
        }

        public static void Delete(IEnumerable<T> entities, DataContext dataContext)
        {
            Entity.Delete(ConvertToEntity(entities), dataContext);
        }

        public static void SaveChanges(IEnumerable<T> entities)
        {
            Entity.SaveChanges(ConvertToEntity(entities));
        }

        public static void SaveChanges(IEnumerable<T> entities, DataContext dataContext)
        {
            Entity.SaveChanges(ConvertToEntity(entities), dataContext);
        }

        private static IEnumerable<Entity> ConvertToEntity(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
                yield return entity;
        }

        #endregion

        #endregion
    }
}

