/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: SalesOrderDetail
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

namespace CrystalMapper.Generated.BusinessObjects
{
	[Table(TABLE_NAME)]
    public partial class SalesOrderDetail : Entity< SalesOrderDetail>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.SalesOrderDetail";	
     
		public const string COL_SALESORDERID = "SalesOrderID";
		public const string COL_SALESORDERDETAILID = "SalesOrderDetailID";
		public const string COL_CARRIERTRACKINGNUMBER = "CarrierTrackingNumber";
		public const string COL_ORDERQTY = "OrderQty";
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_SPECIALOFFERID = "SpecialOfferID";
		public const string COL_UNITPRICE = "UnitPrice";
		public const string COL_UNITPRICEDISCOUNT = "UnitPriceDiscount";
		public const string COL_LINETOTAL = "LineTotal";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SALESORDERID = "@SalesOrderID";	
        public const string PARAM_SALESORDERDETAILID = "@SalesOrderDetailID";	
        public const string PARAM_CARRIERTRACKINGNUMBER = "@CarrierTrackingNumber";	
        public const string PARAM_ORDERQTY = "@OrderQty";	
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_SPECIALOFFERID = "@SpecialOfferID";	
        public const string PARAM_UNITPRICE = "@UnitPrice";	
        public const string PARAM_UNITPRICEDISCOUNT = "@UnitPriceDiscount";	
        public const string PARAM_LINETOTAL = "@LineTotal";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SALESORDERDETAIL = "INSERT INTO Sales.SalesOrderDetail([SalesOrderID],[CarrierTrackingNumber],[OrderQty],[ProductID],[SpecialOfferID],[UnitPrice],[UnitPriceDiscount],[LineTotal],[rowguid],[ModifiedDate]) VALUES (@SalesOrderID,@CarrierTrackingNumber,@OrderQty,@ProductID,@SpecialOfferID,@UnitPrice,@UnitPriceDiscount,@LineTotal,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_SALESORDERDETAIL = "UPDATE Sales.SalesOrderDetail SET [CarrierTrackingNumber] = @CarrierTrackingNumber, [OrderQty] = @OrderQty, [ProductID] = @ProductID, [SpecialOfferID] = @SpecialOfferID, [UnitPrice] = @UnitPrice, [UnitPriceDiscount] = @UnitPriceDiscount, [LineTotal] = @LineTotal, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [SalesOrderID] = @SalesOrderID AND [SalesOrderDetailID] = @SalesOrderDetailID";
		
		private const string SQL_DELETE_SALESORDERDETAIL = "DELETE FROM Sales.SalesOrderDetail WHERE  [SalesOrderID] = @SalesOrderID AND [SalesOrderDetailID] = @SalesOrderDetailID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_SALESORDERID, PARAM_SALESORDERID, default(int))]
                              public virtual int SalesOrderID  { get; set; }		
		[Column( COL_SALESORDERDETAILID, PARAM_SALESORDERDETAILID, default(int))]
                              public virtual int SalesOrderDetailID  { get; set; }		
		
        
	    [Column( COL_CARRIERTRACKINGNUMBER, PARAM_CARRIERTRACKINGNUMBER )]
                              public virtual string CarrierTrackingNumber  { get; set; }	      
        
	    [Column( COL_ORDERQTY, PARAM_ORDERQTY, default(short))]
                              public virtual short OrderQty  { get; set; }	      
        
	    [Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID  { get; set; }	      
        
	    [Column( COL_SPECIALOFFERID, PARAM_SPECIALOFFERID, default(int))]
                              public virtual int SpecialOfferID  { get; set; }	      
        
	    [Column( COL_UNITPRICE, PARAM_UNITPRICE, typeof(decimal))]
                              public virtual decimal UnitPrice  { get; set; }	      
        
	    [Column( COL_UNITPRICEDISCOUNT, PARAM_UNITPRICEDISCOUNT, typeof(decimal))]
                              public virtual decimal UnitPriceDiscount  { get; set; }	      
        
	    [Column( COL_LINETOTAL, PARAM_LINETOTAL, typeof(decimal))]
                              public virtual decimal LineTotal  { get; set; }	      
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.SalesOrderID = (int)reader[COL_SALESORDERID];
			this.SalesOrderDetailID = (int)reader[COL_SALESORDERDETAILID];
			this.CarrierTrackingNumber = DbConvert.ToString(reader[COL_CARRIERTRACKINGNUMBER]);
			this.OrderQty = (short)reader[COL_ORDERQTY];
			this.ProductID = (int)reader[COL_PRODUCTID];
			this.SpecialOfferID = (int)reader[COL_SPECIALOFFERID];
			this.UnitPrice = (decimal)reader[COL_UNITPRICE];
			this.UnitPriceDiscount = (decimal)reader[COL_UNITPRICEDISCOUNT];
			this.LineTotal = (decimal)reader[COL_LINETOTAL];
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SALESORDERDETAIL))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.SalesOrderID, PARAM_SALESORDERID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CarrierTrackingNumber), PARAM_CARRIERTRACKINGNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.OrderQty, PARAM_ORDERQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.SpecialOfferID, PARAM_SPECIALOFFERID));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitPrice, PARAM_UNITPRICE));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitPriceDiscount, PARAM_UNITPRICEDISCOUNT));
				command.Parameters.Add(dataContext.CreateParameter(this.LineTotal, PARAM_LINETOTAL));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.SalesOrderDetailID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SALESORDERDETAIL))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SalesOrderID, PARAM_SALESORDERID));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesOrderDetailID, PARAM_SALESORDERDETAILID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CarrierTrackingNumber), PARAM_CARRIERTRACKINGNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.OrderQty, PARAM_ORDERQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.SpecialOfferID, PARAM_SPECIALOFFERID));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitPrice, PARAM_UNITPRICE));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitPriceDiscount, PARAM_UNITPRICEDISCOUNT));
				command.Parameters.Add(dataContext.CreateParameter(this.LineTotal, PARAM_LINETOTAL));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SALESORDERDETAIL))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SalesOrderID, PARAM_SALESORDERID));				
				command.Parameters.Add(dataContext.CreateParameter(this.SalesOrderDetailID, PARAM_SALESORDERDETAILID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
