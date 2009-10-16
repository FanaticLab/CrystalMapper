/*
 * Author: Faraz Masood Khan 
 * 
 * Date: 6/5/2009 2:09:52 PM
 * 
 * Class: TableAttribute
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

namespace CrystalMapper.Data
{
    public class DataContext : IDisposable
    {
        private bool disposeConnection = false;
        private Database database;
        private DbConnection connection;
        private DbTransaction transaction;   

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

        public DbParameter CreateParameter()
        {
            return this.database.CreateParameter();
        }

        public DbParameter CreateParameter(object value, string paramName)
        {
            return this.database.CreateParameter(value, paramName);
        }

        public string ToString(object value)
        {
            return this.database.ToString(value);
        }      

        public void CommitTransaction()
        {
            if (this.transaction != null)
                transaction.Commit();   
        }    

        public void RollbackTransaction()
        {
            if (this.transaction != null)
                transaction.Rollback();
            this.transaction = null;
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (this.transaction != null)
                this.transaction.Dispose();

            if (this.disposeConnection)
                this.connection.Dispose();
              
        }

        #endregion
    }
}
