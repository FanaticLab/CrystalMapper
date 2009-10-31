/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: PurchaseOrderDetail
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
    public partial class PurchaseOrderDetail : Entity< PurchaseOrderDetail>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Purchasing.PurchaseOrderDetail";	
     
		public const string COL_PURCHASEORDERID = "PurchaseOrderID";
		public const string COL_PURCHASEORDERDETAILID = "PurchaseOrderDetailID";
		public const string COL_DUEDATE = "DueDate";
		public const string COL_ORDERQTY = "OrderQty";
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_UNITPRICE = "UnitPrice";
		public const string COL_LINETOTAL = "LineTotal";
		public const string COL_RECEIVEDQTY = "ReceivedQty";
		public const string COL_REJECTEDQTY = "RejectedQty";
		public const string COL_STOCKEDQTY = "StockedQty";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PURCHASEORDERID = "@PurchaseOrderID";	
        public const string PARAM_PURCHASEORDERDETAILID = "@PurchaseOrderDetailID";	
        public const string PARAM_DUEDATE = "@DueDate";	
        public const string PARAM_ORDERQTY = "@OrderQty";	
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_UNITPRICE = "@UnitPrice";	
        public const string PARAM_LINETOTAL = "@LineTotal";	
        public const string PARAM_RECEIVEDQTY = "@ReceivedQty";	
        public const string PARAM_REJECTEDQTY = "@RejectedQty";	
        public const string PARAM_STOCKEDQTY = "@StockedQty";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PURCHASEORDERDETAIL = "INSERT INTO Purchasing.PurchaseOrderDetail([PurchaseOrderID],[DueDate],[OrderQty],[ProductID],[UnitPrice],[LineTotal],[ReceivedQty],[RejectedQty],[StockedQty],[ModifiedDate]) VALUES (@PurchaseOrderID,@DueDate,@OrderQty,@ProductID,@UnitPrice,@LineTotal,@ReceivedQty,@RejectedQty,@StockedQty,@ModifiedDate);";
		
		private const string SQL_UPDATE_PURCHASEORDERDETAIL = "UPDATE Purchasing.PurchaseOrderDetail SET [DueDate] = @DueDate, [OrderQty] = @OrderQty, [ProductID] = @ProductID, [UnitPrice] = @UnitPrice, [LineTotal] = @LineTotal, [ReceivedQty] = @ReceivedQty, [RejectedQty] = @RejectedQty, [StockedQty] = @StockedQty, [ModifiedDate] = @ModifiedDate,  WHERE [PurchaseOrderID] = @PurchaseOrderID AND [PurchaseOrderDetailID] = @PurchaseOrderDetailID";
		
		private const string SQL_DELETE_PURCHASEORDERDETAIL = "DELETE FROM Purchasing.PurchaseOrderDetail WHERE  [PurchaseOrderID] = @PurchaseOrderID AND [PurchaseOrderDetailID] = @PurchaseOrderDetailID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_PURCHASEORDERID, PARAM_PURCHASEORDERID, default(int))]
                              public virtual int PurchaseOrderID  { get; set; }		
		[Column( COL_PURCHASEORDERDETAILID, PARAM_PURCHASEORDERDETAILID, default(int))]
                              public virtual int PurchaseOrderDetailID  { get; set; }		
		
        
	    [Column( COL_DUEDATE, PARAM_DUEDATE, typeof(System.DateTime))]
                              public virtual System.DateTime DueDate  { get; set; }	      
        
	    [Column( COL_ORDERQTY, PARAM_ORDERQTY, default(short))]
                              public virtual short OrderQty  { get; set; }	      
        
	    [Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID  { get; set; }	      
        
	    [Column( COL_UNITPRICE, PARAM_UNITPRICE, typeof(decimal))]
                              public virtual decimal UnitPrice  { get; set; }	      
        
	    [Column( COL_LINETOTAL, PARAM_LINETOTAL, typeof(decimal))]
                              public virtual decimal LineTotal  { get; set; }	      
        
	    [Column( COL_RECEIVEDQTY, PARAM_RECEIVEDQTY, typeof(decimal))]
                              public virtual decimal ReceivedQty  { get; set; }	      
        
	    [Column( COL_REJECTEDQTY, PARAM_REJECTEDQTY, typeof(decimal))]
                              public virtual decimal RejectedQty  { get; set; }	      
        
	    [Column( COL_STOCKEDQTY, PARAM_STOCKEDQTY, typeof(decimal))]
                              public virtual decimal StockedQty  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.PurchaseOrderID = (int)reader[COL_PURCHASEORDERID];
			this.PurchaseOrderDetailID = (int)reader[COL_PURCHASEORDERDETAILID];
			this.DueDate = (System.DateTime)reader[COL_DUEDATE];
			this.OrderQty = (short)reader[COL_ORDERQTY];
			this.ProductID = (int)reader[COL_PRODUCTID];
			this.UnitPrice = (decimal)reader[COL_UNITPRICE];
			this.LineTotal = (decimal)reader[COL_LINETOTAL];
			this.ReceivedQty = (decimal)reader[COL_RECEIVEDQTY];
			this.RejectedQty = (decimal)reader[COL_REJECTEDQTY];
			this.StockedQty = (decimal)reader[COL_STOCKEDQTY];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PURCHASEORDERDETAIL))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.PurchaseOrderID, PARAM_PURCHASEORDERID));
				command.Parameters.Add(dataContext.CreateParameter(this.DueDate, PARAM_DUEDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.OrderQty, PARAM_ORDERQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitPrice, PARAM_UNITPRICE));
				command.Parameters.Add(dataContext.CreateParameter(this.LineTotal, PARAM_LINETOTAL));
				command.Parameters.Add(dataContext.CreateParameter(this.ReceivedQty, PARAM_RECEIVEDQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.RejectedQty, PARAM_REJECTEDQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.StockedQty, PARAM_STOCKEDQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.PurchaseOrderDetailID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PURCHASEORDERDETAIL))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.PurchaseOrderID, PARAM_PURCHASEORDERID));
				command.Parameters.Add(dataContext.CreateParameter(this.PurchaseOrderDetailID, PARAM_PURCHASEORDERDETAILID));
				command.Parameters.Add(dataContext.CreateParameter(this.DueDate, PARAM_DUEDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.OrderQty, PARAM_ORDERQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitPrice, PARAM_UNITPRICE));
				command.Parameters.Add(dataContext.CreateParameter(this.LineTotal, PARAM_LINETOTAL));
				command.Parameters.Add(dataContext.CreateParameter(this.ReceivedQty, PARAM_RECEIVEDQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.RejectedQty, PARAM_REJECTEDQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.StockedQty, PARAM_STOCKEDQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PURCHASEORDERDETAIL))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.PurchaseOrderID, PARAM_PURCHASEORDERID));				
				command.Parameters.Add(dataContext.CreateParameter(this.PurchaseOrderDetailID, PARAM_PURCHASEORDERDETAILID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
