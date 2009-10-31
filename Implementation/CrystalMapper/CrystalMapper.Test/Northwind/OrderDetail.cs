/*
 * Author: CrystalMapper
 * 
 * Date:  Sunday, November 01, 2009 2:37 AM
 * 
 * Class: OrderDetail
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
    public partial class OrderDetail : Entity< OrderDetail>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "OrderDetails";	
     
		public const string COL_ORDERID = "OrderID";
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_UNITPRICE = "UnitPrice";
		public const string COL_QUANTITY = "Quantity";
		public const string COL_DISCOUNT = "Discount";
		
        public const string PARAM_ORDERID = ":OrderID";	
        public const string PARAM_PRODUCTID = ":ProductID";	
        public const string PARAM_UNITPRICE = ":UnitPrice";	
        public const string PARAM_QUANTITY = ":Quantity";	
        public const string PARAM_DISCOUNT = ":Discount";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_ORDERDETAILS = "INSERT INTO OrderDetails([OrderID],[ProductID],[UnitPrice],[Quantity],[Discount]) VALUES (:OrderID,:ProductID,:UnitPrice,:Quantity,:Discount);"  ;
		
		private const string SQL_UPDATE_ORDERDETAILS = "UPDATE OrderDetails SET [UnitPrice] = :UnitPrice, [Quantity] = :Quantity, [Discount] = :Discount,  WHERE [OrderID] = :OrderID AND [ProductID] = :ProductID";
		
		private const string SQL_DELETE_ORDERDETAILS = "DELETE FROM OrderDetails WHERE  [OrderID] = :OrderID AND [ProductID] = :ProductID ";
		
        #endregion
        
        #region Properties	
		
		[Column( COL_ORDERID, PARAM_ORDERID, default(long))]
                              public virtual long OrderID  { get; set; }		
		[Column( COL_PRODUCTID, PARAM_PRODUCTID, default(long))]
                              public virtual long ProductID  { get; set; }		
		
        
	    [Column( COL_UNITPRICE, PARAM_UNITPRICE, typeof(decimal))]
                              public virtual decimal UnitPrice  { get; set; }	      
        
	    [Column( COL_QUANTITY, PARAM_QUANTITY, default(short))]
                              public virtual short Quantity  { get; set; }	      
        
	    [Column( COL_DISCOUNT, PARAM_DISCOUNT, default(float))]
                              public virtual float Discount  { get; set; }	      
        
        #endregion        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.OrderID = (long)reader[COL_ORDERID];
			this.ProductID = (long)reader[COL_PRODUCTID];
			this.UnitPrice = (decimal)reader[COL_UNITPRICE];
			this.Quantity = (short)reader[COL_QUANTITY];
			this.Discount = (float)reader[COL_DISCOUNT];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_ORDERDETAILS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.OrderID, PARAM_ORDERID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitPrice, PARAM_UNITPRICE));
				command.Parameters.Add(dataContext.CreateParameter(this.Quantity, PARAM_QUANTITY));
				command.Parameters.Add(dataContext.CreateParameter(this.Discount, PARAM_DISCOUNT));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_ORDERDETAILS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.OrderID, PARAM_ORDERID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitPrice, PARAM_UNITPRICE));
				command.Parameters.Add(dataContext.CreateParameter(this.Quantity, PARAM_QUANTITY));
				command.Parameters.Add(dataContext.CreateParameter(this.Discount, PARAM_DISCOUNT));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_ORDERDETAILS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.OrderID, PARAM_ORDERID));				
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
