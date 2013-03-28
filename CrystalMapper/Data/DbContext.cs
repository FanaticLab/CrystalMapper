using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Linq;
using CoreSystem.Util;

namespace CrystalMapper.Data
{
    public class DbContext
    {
        public const string DefaultDb = "Default-Db";

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

        public IQueryable<T> Query<T>()
        {
            return new Query<T>(this.Name);
        }

        public DataContext GetContext()
        {
            return new DataContext(this.Name);
        }
    }
}
