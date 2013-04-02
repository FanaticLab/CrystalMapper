/************************************************************************************************
 * Author: Faraz Masood Khan 
 * Description: This class represents a single database that will be used to query that database
 * Project: http://crystalmapper.codeplex.com
 * Copyright (c) 2013 FanaticLab
 ************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Linq;
using CoreSystem.Util;
using CoreSystem.Dynamic;

namespace CrystalMapper.Context
{
    /// <summary>
    /// Database connection string wrapper/context; holding database connection string reference via connection string name
    /// </summary>
    public class DbContext
    {
        /// <summary>
        /// Default database connection string name "Default-Db" which will be used if not connection string name passed.
        /// </summary>
        public const string DefaultDb = "Default-Db";

        /// <summary>
        /// Connection string name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///Creates DbContext for "Default-Db" connection string
        /// </summary>
        public DbContext()
            : this(DbContext.DefaultDb)
        { }

        /// <summary>
        /// Creates DbContext for provided name of connection string
        /// </summary>
        /// <param name="name"></param>
        public DbContext(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Query object for database entity
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <returns>Query object for T entity</returns>
        public IQueryable<T> Query<T>() where T : IRecord, new()
        {
            return new Query<T>(this.Name);
        }

        /// <summary>
        /// Create a new record in database
        /// </summary>
        /// <param name="record">A new record</param>
        public void Create(IRecord record)
        {
            using (var dataContext = this.GetDataContext())
            {
                dataContext.Create(record);
            }
        }

        /// <summary>
        /// Create new records in database in a transaction
        /// </summary>
        /// <param name="records">New records to create</param>
        public void Create(IEnumerable<IRecord> records)
        {
            using (var dataContext = this.GetDataContext())
            {
                dataContext.BeginTransaction();

                dataContext.Create(records);

                dataContext.CommitTransaction();
            }
        }

        /// <summary>
        /// Update a record in database
        /// </summary>
        /// <param name="record">Record to update</param>
        public void Update(IRecord record)
        {
            using (var dataContext = this.GetDataContext())
            {
                dataContext.Update(record);
            }
        }

        /// <summary>
        /// Update records in a transaction
        /// </summary>
        /// <param name="records">Records to update</param>
        public void Update(IEnumerable<IRecord> records)
        {
            using (var dataContext = this.GetDataContext())
            {
                dataContext.BeginTransaction();

                dataContext.Update(records);

                dataContext.CommitTransaction();
            }
        }

        /// <summary>
        /// Returns all records of T entity in array from database
        /// </summary>
        /// <typeparam name="T">Record entity type</typeparam>
        /// <returns>All records</returns>
        public T[] ToArray<T>() where T : IRecord, new()
        {
            return this.Query<T>().ToArray();
        }

        /// <summary>
        /// Execute specified SQL query in database and return result in array
        /// </summary>
        /// <typeparam name="T">Type of record you want to load result in</typeparam>
        /// <param name="sqlQuery">SQL query to execute in database</param>
        /// <returns>Result of query</returns>
        public T[] ToArray<T>(string sqlQuery) where T : IRecord, new()
        {
            return this.ToList<T>(sqlQuery).ToArray();
        }

        /// <summary>
        /// Execute specified SQL query in database and return result in array
        /// </summary>
        /// <typeparam name="T">Type of record you want to load result in</typeparam>
        /// <param name="sqlQuery">SQL query to execute in database</param>
        /// <param name="parameters">SQL parameters</param>
        /// <returns>Result of query</returns>
        public T[] ToArray<T>(string sqlQuery, Dictionary<string, object> parameters) where T : IRecord, new()
        {
            return this.ToList<T>(sqlQuery, parameters).ToArray();
        }

        /// <summary>
        /// Returns all records of T entity in list from database
        /// </summary>
        /// <typeparam name="T">Record entity type</typeparam>
        /// <returns>All records</returns>
        public List<T> ToList<T>() where T : IRecord, new()
        {
            return this.Query<T>().ToList();
        }

        /// <summary>
        /// Execute specified SQL query in database and return result in list
        /// </summary>
        /// <typeparam name="T">Type of record you want to load result in</typeparam>
        /// <param name="sqlQuery">SQL query to execute in database</param>
        /// <returns>Result of query</returns>
        public List<T> ToList<T>(string sqlQuery) where T : IRecord, new()
        {
            using (DataContext dataContext = this.GetDataContext())
            {
                return dataContext.ToList<T>(sqlQuery);
            }
        }

        /// <summary>
        /// Execute specified SQL query in database and return result in list
        /// </summary>
        /// <typeparam name="T">Type of record you want to load result in</typeparam>
        /// <param name="sqlQuery">SQL query to execute in database</param>
        /// <param name="parameters">SQL parameters</param>
        /// <returns>Result of query</returns>
        public List<T> ToList<T>(string sqlQuery, Dictionary<string, object> parameters) where T : IRecord, new()
        {
            using (DataContext dataContext = this.GetDataContext())
            {
                return dataContext.ToList<T>(sqlQuery);
            }
        }

        /// <summary>
        /// Execute specified query in current connection and return list of dynamic objects
        /// </summary>
        /// <param name="cmdText">SQL query to execute in current connection</param>
        /// <returns>Result of query</returns>
        public List<Donymous> ToDonymous(string cmdText)
        {
            using (var dataContext = this.GetDataContext())
            {
                return dataContext.ToDonymous(cmdText);
            }
        }

        /// <summary>
        /// Execute specified query in current connection and return list of dynamic objects
        /// </summary>
        /// <param name="cmdText">SQL query to execute in current connection</param>
        /// <param name="parameters">SQL parameters</param>
        /// <returns>Result of query</returns>
        public List<Donymous> ToDonymous(string cmdText, Dictionary<string, object> parameters)
        {
            using (var dataContext = this.GetDataContext())
            {
                return dataContext.ToDonymous(cmdText, parameters);
            }
        }

        /// <summary>
        /// Returns and opened database connection
        /// </summary>
        /// <returns>Databse connection wrapper</returns>
        public DataContext GetDataContext()
        {
            return new DataContext(this.Name);
        }
    }
}
