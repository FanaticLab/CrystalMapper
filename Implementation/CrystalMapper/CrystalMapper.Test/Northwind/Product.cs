/*
 * Author: CrystalMapper
 * 
 * Date:  Sunday, November 01, 2009 2:37 AM
 * 
 * Class: Product
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
    public partial class Product : Entity< Product>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Products";	
     
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_PRODUCTNAME = "ProductName";
		public const string COL_SUPPLIERID = "SupplierID";
		public const string COL_CATEGORYID = "CategoryID";
		public const string COL_QUANTITYPERUNIT = "QuantityPerUnit";
		public const string COL_UNITPRICE = "UnitPrice";
		public const string COL_UNITSINSTOCK = "UnitsInStock";
		public const string COL_UNITSONORDER = "UnitsOnOrder";
		public const string COL_REORDERLEVEL = "ReorderLevel";
		public const string COL_DISCONTINUED = "Discontinued";
		public const string COL_DISCONTINUEDDATE = "DiscontinuedDate";
		
        public const string PARAM_PRODUCTID = ":ProductID";	
        public const string PARAM_PRODUCTNAME = ":ProductName";	
        public const string PARAM_SUPPLIERID = ":SupplierID";	
        public const string PARAM_CATEGORYID = ":CategoryID";	
        public const string PARAM_QUANTITYPERUNIT = ":QuantityPerUnit";	
        public const string PARAM_UNITPRICE = ":UnitPrice";	
        public const string PARAM_UNITSINSTOCK = ":UnitsInStock";	
        public const string PARAM_UNITSONORDER = ":UnitsOnOrder";	
        public const string PARAM_REORDERLEVEL = ":ReorderLevel";	
        public const string PARAM_DISCONTINUED = ":Discontinued";	
        public const string PARAM_DISCONTINUEDDATE = ":DiscontinuedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PRODUCTS = "INSERT INTO Products([ProductName],[SupplierID],[CategoryID],[QuantityPerUnit],[UnitPrice],[UnitsInStock],[UnitsOnOrder],[ReorderLevel],[Discontinued],[DiscontinuedDate]) VALUES (:ProductName,:SupplierID,:CategoryID,:QuantityPerUnit,:UnitPrice,:UnitsInStock,:UnitsOnOrder,:ReorderLevel,:Discontinued,:DiscontinuedDate);"   + "SELECT last_insert_rowid();" ;
		
		private const string SQL_UPDATE_PRODUCTS = "UPDATE Products SET [ProductName] = :ProductName, [SupplierID] = :SupplierID, [CategoryID] = :CategoryID, [QuantityPerUnit] = :QuantityPerUnit, [UnitPrice] = :UnitPrice, [UnitsInStock] = :UnitsInStock, [UnitsOnOrder] = :UnitsOnOrder, [ReorderLevel] = :ReorderLevel, [Discontinued] = :Discontinued, [DiscontinuedDate] = :DiscontinuedDate,  WHERE [ProductID] = :ProductID";
		
		private const string SQL_DELETE_PRODUCTS = "DELETE FROM Products WHERE  [ProductID] = :ProductID ";
		
        #endregion
        
        #region Properties	
		
		[Column( COL_PRODUCTID, PARAM_PRODUCTID, default(long))]
                              public virtual long ProductID  { get; set; }		
		
        
	    [Column( COL_PRODUCTNAME, PARAM_PRODUCTNAME )]
                              public virtual string ProductName  { get; set; }	      
        
	    [Column( COL_SUPPLIERID, PARAM_SUPPLIERID )]
                              public virtual long? SupplierID  { get; set; }	      
        
	    [Column( COL_CATEGORYID, PARAM_CATEGORYID )]
                              public virtual long? CategoryID  { get; set; }	      
        
	    [Column( COL_QUANTITYPERUNIT, PARAM_QUANTITYPERUNIT )]
                              public virtual string QuantityPerUnit  { get; set; }	      
        
	    [Column( COL_UNITPRICE, PARAM_UNITPRICE )]
                              public virtual decimal? UnitPrice  { get; set; }	      
        
	    [Column( COL_UNITSINSTOCK, PARAM_UNITSINSTOCK )]
                              public virtual short? UnitsInStock  { get; set; }	      
        
	    [Column( COL_UNITSONORDER, PARAM_UNITSONORDER )]
                              public virtual short? UnitsOnOrder  { get; set; }	      
        
	    [Column( COL_REORDERLEVEL, PARAM_REORDERLEVEL )]
                              public virtual short? ReorderLevel  { get; set; }	      
        
	    [Column( COL_DISCONTINUED, PARAM_DISCONTINUED, default(bool))]
                              public virtual bool Discontinued  { get; set; }	      
        
	    [Column( COL_DISCONTINUEDDATE, PARAM_DISCONTINUEDDATE )]
                              public virtual System.DateTime? DiscontinuedDate  { get; set; }	      
        
        public IEnumerable< OrderDetail> OrderDetails
        {
            get {
                  foreach(OrderDetail orderDetail in OrderDetailList())
                    yield return orderDetail; 
                }
        }
        
        #endregion        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.ProductID = (long)reader[COL_PRODUCTID];
			this.ProductName = (string)reader[COL_PRODUCTNAME];
			this.SupplierID = DbConvert.ToNullable< long >(reader[COL_SUPPLIERID]);
			this.CategoryID = DbConvert.ToNullable< long >(reader[COL_CATEGORYID]);
			this.QuantityPerUnit = DbConvert.ToString(reader[COL_QUANTITYPERUNIT]);
			this.UnitPrice = DbConvert.ToNullable< decimal >(reader[COL_UNITPRICE]);
			this.UnitsInStock = DbConvert.ToNullable< short >(reader[COL_UNITSINSTOCK]);
			this.UnitsOnOrder = DbConvert.ToNullable< short >(reader[COL_UNITSONORDER]);
			this.ReorderLevel = DbConvert.ToNullable< short >(reader[COL_REORDERLEVEL]);
			this.Discontinued = (bool)reader[COL_DISCONTINUED];
			this.DiscontinuedDate = DbConvert.ToNullable< System.DateTime >(reader[COL_DISCONTINUEDDATE]);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ProductName, PARAM_PRODUCTNAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.SupplierID), PARAM_SUPPLIERID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CategoryID), PARAM_CATEGORYID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.QuantityPerUnit), PARAM_QUANTITYPERUNIT));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.UnitPrice), PARAM_UNITPRICE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.UnitsInStock), PARAM_UNITSINSTOCK));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.UnitsOnOrder), PARAM_UNITSONORDER));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ReorderLevel), PARAM_REORDERLEVEL));
				command.Parameters.Add(dataContext.CreateParameter(this.Discontinued, PARAM_DISCONTINUED));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.DiscontinuedDate), PARAM_DISCONTINUEDDATE));
                this.ProductID = Convert.ToInt64(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCTS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductName, PARAM_PRODUCTNAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.SupplierID), PARAM_SUPPLIERID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CategoryID), PARAM_CATEGORYID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.QuantityPerUnit), PARAM_QUANTITYPERUNIT));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.UnitPrice), PARAM_UNITPRICE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.UnitsInStock), PARAM_UNITSINSTOCK));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.UnitsOnOrder), PARAM_UNITSONORDER));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ReorderLevel), PARAM_REORDERLEVEL));
				command.Parameters.Add(dataContext.CreateParameter(this.Discontinued, PARAM_DISCONTINUED));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.DiscontinuedDate), PARAM_DISCONTINUEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCTS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public OrderDetail GetOrderDetailsQuery()
        {
            return new OrderDetail {                
                                                                            ProductID = this.ProductID  
                                                                            };
        }
        
        public OrderDetail[] OrderDetailList()
        {
            return GetOrderDetailsQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
