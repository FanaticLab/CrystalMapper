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
using System.Data;
using System.Reflection;
using System.Data.Common;
using System.ComponentModel;
using System.Collections.Generic;

using CoreSystem.Data;

using CrystalMapper.Data;
using CrystalMapper.Mapping;
using CoreSystem.Collections;


namespace CrystalMapper
{
    public abstract class Entity<T> : INotifyPropertyChanged, INotifyPropertyChanging
        where T : Entity<T>, new()
    {
        #region Events

        private DispatchEvent propertyChanged = new DispatchEvent();

        private DispatchEvent propertyChanging = new DispatchEvent();

        public event PropertyChangedEventHandler PropertyChanged
        {
            add { propertyChanged.Add(value); }
            remove { propertyChanged.Remove(value); }
        }

        public event PropertyChangingEventHandler PropertyChanging
        {
            add { propertyChanging.Add(value); }
            remove { propertyChanging.Remove(value); }
        }

        #endregion

        #region Methods

        #region Member Methods

        #region Event Methods

        protected void NotifyPropertyChanging(string propertyName)
        {
            this.propertyChanging.Fire(this, new PropertyChangingEventArgs(propertyName));
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            this.propertyChanged.Fire(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Abstract Methods

        public abstract void Read(DbDataReader reader);

        public abstract bool Update(DataContext dataContext);

        public abstract bool Create(DataContext dataContext);

        public abstract bool Delete(DataContext dataContext);

        #endregion               

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
            String query = EntityQuery<T>.GetQuery(this, out parameterValues);

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

        #endregion

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

        public static T[] ToList(String sqlQuery, Dictionary<string, object> parameterValues)
        {
            using (DataContext dataContext = new DataContext(DbFactory.GetDefaultDatabase()))
            {
                using (DbCommand command = dataContext.CreateCommand(sqlQuery))
                {
                    if (parameterValues != null)
                        foreach (string param in parameterValues.Keys)
                            command.Parameters.Add(dataContext.CreateParameter(parameterValues[param], param));

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

        #endregion

        #endregion
    }
}

