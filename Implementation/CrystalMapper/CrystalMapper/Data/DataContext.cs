/*
 * Author: Faraz Masood Khan 
 * 
 * Date: 6/5/2009 2:09:52 PM
 * 
 * Class: DataContext
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
using System.Data.Common;
using System.Collections.Generic;

using CoreSystem.Data;
using CoreSystem.Dynamic;

namespace CrystalMapper.Data
{
    public class DataContext : IDisposable
    {
        private bool disposeConnection = false;
        private Database database;
        private DbConnection connection;
        private DbTransaction transaction;

        public DataContext()
            : this(DbFactory.GetDefaultDatabase())
        { }

        public DataContext(string name)
            : this(DbFactory.GetDatabase(name))
        { }

        public DataContext(Database database)
            : this(database, database.CreateConnection())
        {
            disposeConnection = true;
        }

        public DataContext(Database database, DbConnection connection)
        {
            this.database = database;
            this.connection = connection;
        }

        public Database Database
        {
            get { return this.database; }
        }

        public DbConnection Connection 
        {
            get { return this.connection; }
        }
        
        public DbTransaction Transaction 
        {
            get { return this.transaction; }
        }

        public void BeginTransaction()
        {
            this.transaction = this.connection.BeginTransaction();
        }

        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            this.transaction = this.connection.BeginTransaction(isolationLevel);
        }

        public DbCommand CreateCommand(string cmdText)
        {
            return (this.transaction != null ?
                this.database.CreateCommand(cmdText, transaction) : this.database.CreateCommand(cmdText, this.connection));
        }

        public List<Donymous> ExecuteToDonymous(string cmdText)
        {
            return this.transaction != null ? this.database.ExecuteToDonymous(cmdText, this.transaction) : this.database.ExecuteToDonymous(cmdText, this.connection);
        }

        public List<Donymous> ExecuteToDonymous(DbCommand command)
        {
            return this.database.ExecuteToDonymous(command);
        }

        public DbParameter CreateParameter()
        {
            return this.database.CreateParameter();
        }

        public DbParameter CreateParameter(object value, string paramName)
        {
            return this.database.CreateParameter(value, paramName);
        }                 

        public void CommitTransaction()
        {
            if (this.transaction != null)
            {
                transaction.Commit();
                transaction = null;
            }
        }    

        public void RollbackTransaction()
        {
            if (this.transaction != null)
            {
                transaction.Rollback();
                transaction = null;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);              
        }

        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.transaction != null)
                    this.transaction.Dispose();

                if (this.disposeConnection)
                    this.connection.Dispose();
            }
        }
    }
}
