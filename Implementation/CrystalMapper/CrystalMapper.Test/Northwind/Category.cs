/*
 * Author: CrystalMapper
 * 
 * Date:  Sunday, November 01, 2009 2:37 AM
 * 
 * Class: Category
 *    
 */

using System;
using System.Data.Common;
using System.Diagnostics;
using System.Collections.Generic;

using CoreSystem.Data;

using CrystalMapper;
using CrystalMapper.Data;
using CrystalMapper.Mapping;

namespace Northwind
{
    [Table(TABLE_NAME)]
    public partial class Category : Entity<Category>
    {
        #region Table Schema

        public const string TABLE_NAME = "Categories";

        public const string COL_CATEGORYID = "CategoryID";
        public const string COL_CATEGORYNAME = "CategoryName";
        public const string COL_DESCRIPTION = "Description";
        public const string COL_PICTURE = "Picture";

        public const string PARAM_CATEGORYID = ":CategoryID";
        public const string PARAM_CATEGORYNAME = ":CategoryName";
        public const string PARAM_DESCRIPTION = ":Description";
        public const string PARAM_PICTURE = ":Picture";

        #endregion

        #region Queries

        private const string SQL_INSERT_CATEGORIES = "INSERT INTO Categories([CategoryName],[Description],[Picture]) VALUES (:CategoryName,:Description,:Picture);" + "SELECT last_insert_rowid();";

        private const string SQL_UPDATE_CATEGORIES = "UPDATE Categories SET [CategoryName] = :CategoryName, [Description] = :Description, [Picture] = :Picture,  WHERE [CategoryID] = :CategoryID";

        private const string SQL_DELETE_CATEGORIES = "DELETE FROM Categories WHERE  [CategoryID] = :CategoryID ";

        #endregion

        #region Properties

        [Column(COL_CATEGORYID, PARAM_CATEGORYID, default(long))]
        public virtual long CategoryID { get; set; }


        [Column(COL_CATEGORYNAME, PARAM_CATEGORYNAME)]
        public virtual string CategoryName { get; set; }

        [Column(COL_DESCRIPTION, PARAM_DESCRIPTION)]
        public virtual string Description { get; set; }

        [Column(COL_PICTURE, PARAM_PICTURE)]
        public virtual byte[] Picture { get; set; }

        public IEnumerable<Product> Products
        {
            get
            {
                foreach (Product product in ProductList())
                    yield return product;
            }
        }

        #endregion

        #region Methods

        public override void Read(DbDataReader reader)
        {
            this.CategoryID = (long)reader[COL_CATEGORYID];
            this.CategoryName = (string)reader[COL_CATEGORYNAME];
            this.Description = DbConvert.ToString(reader[COL_DESCRIPTION]);
            this.Picture = (byte[])reader[COL_PICTURE];
        }

        public override bool Create(DataContext dataContext)
        {
            using (DbCommand command = dataContext.CreateCommand(SQL_INSERT_CATEGORIES))
            {
                command.Parameters.Add(dataContext.CreateParameter(this.CategoryName, PARAM_CATEGORYNAME));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Description), PARAM_DESCRIPTION));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Picture), PARAM_PICTURE));
                this.CategoryID = Convert.ToInt64(command.ExecuteScalar());
                return true;
            }
        }

        public override bool Update(DataContext dataContext)
        {
            using (DbCommand command = dataContext.CreateCommand(SQL_UPDATE_CATEGORIES))
            {
                command.Parameters.Add(dataContext.CreateParameter(this.CategoryID, PARAM_CATEGORYID));
                command.Parameters.Add(dataContext.CreateParameter(this.CategoryName, PARAM_CATEGORYNAME));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Description), PARAM_DESCRIPTION));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Picture), PARAM_PICTURE));

                return (command.ExecuteNonQuery() == 1);
            }
        }

        public override bool Delete(DataContext dataContext)
        {
            using (DbCommand command = dataContext.CreateCommand(SQL_DELETE_CATEGORIES))
            {
                command.Parameters.Add(dataContext.CreateParameter(this.CategoryID, PARAM_CATEGORYID));
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion

        #region Children

        public Product GetProductsQuery()
        {
            return new Product
            {
                CategoryID = this.CategoryID
            };
        }

        public Product[] ProductList()
        {
            return GetProductsQuery().ToList();
        }




        #endregion
    }
}
