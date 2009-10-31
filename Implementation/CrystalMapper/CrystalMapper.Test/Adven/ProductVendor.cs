/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: ProductVendor
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
    public partial class ProductVendor : Entity< ProductVendor>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Purchasing.ProductVendor";	
     
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_VENDORID = "VendorID";
		public const string COL_AVERAGELEADTIME = "AverageLeadTime";
		public const string COL_STANDARDPRICE = "StandardPrice";
		public const string COL_LASTRECEIPTCOST = "LastReceiptCost";
		public const string COL_LASTRECEIPTDATE = "LastReceiptDate";
		public const string COL_MINORDERQTY = "MinOrderQty";
		public const string COL_MAXORDERQTY = "MaxOrderQty";
		public const string COL_ONORDERQTY = "OnOrderQty";
		public const string COL_UNITMEASURECODE = "UnitMeasureCode";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_VENDORID = "@VendorID";	
        public const string PARAM_AVERAGELEADTIME = "@AverageLeadTime";	
        public const string PARAM_STANDARDPRICE = "@StandardPrice";	
        public const string PARAM_LASTRECEIPTCOST = "@LastReceiptCost";	
        public const string PARAM_LASTRECEIPTDATE = "@LastReceiptDate";	
        public const string PARAM_MINORDERQTY = "@MinOrderQty";	
        public const string PARAM_MAXORDERQTY = "@MaxOrderQty";	
        public const string PARAM_ONORDERQTY = "@OnOrderQty";	
        public const string PARAM_UNITMEASURECODE = "@UnitMeasureCode";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PRODUCTVENDOR = "INSERT INTO Purchasing.ProductVendor([ProductID],[VendorID],[AverageLeadTime],[StandardPrice],[LastReceiptCost],[LastReceiptDate],[MinOrderQty],[MaxOrderQty],[OnOrderQty],[UnitMeasureCode],[ModifiedDate]) VALUES (@ProductID,@VendorID,@AverageLeadTime,@StandardPrice,@LastReceiptCost,@LastReceiptDate,@MinOrderQty,@MaxOrderQty,@OnOrderQty,@UnitMeasureCode,@ModifiedDate);";
		
		private const string SQL_UPDATE_PRODUCTVENDOR = "UPDATE Purchasing.ProductVendor SET [AverageLeadTime] = @AverageLeadTime, [StandardPrice] = @StandardPrice, [LastReceiptCost] = @LastReceiptCost, [LastReceiptDate] = @LastReceiptDate, [MinOrderQty] = @MinOrderQty, [MaxOrderQty] = @MaxOrderQty, [OnOrderQty] = @OnOrderQty, [UnitMeasureCode] = @UnitMeasureCode, [ModifiedDate] = @ModifiedDate,  WHERE [ProductID] = @ProductID AND [VendorID] = @VendorID";
		
		private const string SQL_DELETE_PRODUCTVENDOR = "DELETE FROM Purchasing.ProductVendor WHERE  [ProductID] = @ProductID AND [VendorID] = @VendorID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID  { get; set; }		
		[Column( COL_VENDORID, PARAM_VENDORID, default(int))]
                              public virtual int VendorID  { get; set; }		
		
        
	    [Column( COL_AVERAGELEADTIME, PARAM_AVERAGELEADTIME, default(int))]
                              public virtual int AverageLeadTime  { get; set; }	      
        
	    [Column( COL_STANDARDPRICE, PARAM_STANDARDPRICE, typeof(decimal))]
                              public virtual decimal StandardPrice  { get; set; }	      
        
	    [Column( COL_LASTRECEIPTCOST, PARAM_LASTRECEIPTCOST )]
                              public virtual decimal? LastReceiptCost  { get; set; }	      
        
	    [Column( COL_LASTRECEIPTDATE, PARAM_LASTRECEIPTDATE )]
                              public virtual System.DateTime? LastReceiptDate  { get; set; }	      
        
	    [Column( COL_MINORDERQTY, PARAM_MINORDERQTY, default(int))]
                              public virtual int MinOrderQty  { get; set; }	      
        
	    [Column( COL_MAXORDERQTY, PARAM_MAXORDERQTY, default(int))]
                              public virtual int MaxOrderQty  { get; set; }	      
        
	    [Column( COL_ONORDERQTY, PARAM_ONORDERQTY )]
                              public virtual int? OnOrderQty  { get; set; }	      
        
	    [Column( COL_UNITMEASURECODE, PARAM_UNITMEASURECODE )]
                              public virtual string UnitMeasureCode  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.ProductID = (int)reader[COL_PRODUCTID];
			this.VendorID = (int)reader[COL_VENDORID];
			this.AverageLeadTime = (int)reader[COL_AVERAGELEADTIME];
			this.StandardPrice = (decimal)reader[COL_STANDARDPRICE];
			this.LastReceiptCost = DbConvert.ToNullable< decimal >(reader[COL_LASTRECEIPTCOST]);
			this.LastReceiptDate = DbConvert.ToNullable< System.DateTime >(reader[COL_LASTRECEIPTDATE]);
			this.MinOrderQty = (int)reader[COL_MINORDERQTY];
			this.MaxOrderQty = (int)reader[COL_MAXORDERQTY];
			this.OnOrderQty = DbConvert.ToNullable< int >(reader[COL_ONORDERQTY]);
			this.UnitMeasureCode = (string)reader[COL_UNITMEASURECODE];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTVENDOR))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.VendorID, PARAM_VENDORID));
				command.Parameters.Add(dataContext.CreateParameter(this.AverageLeadTime, PARAM_AVERAGELEADTIME));
				command.Parameters.Add(dataContext.CreateParameter(this.StandardPrice, PARAM_STANDARDPRICE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.LastReceiptCost), PARAM_LASTRECEIPTCOST));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.LastReceiptDate), PARAM_LASTRECEIPTDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.MinOrderQty, PARAM_MINORDERQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.MaxOrderQty, PARAM_MAXORDERQTY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.OnOrderQty), PARAM_ONORDERQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitMeasureCode, PARAM_UNITMEASURECODE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCTVENDOR))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.VendorID, PARAM_VENDORID));
				command.Parameters.Add(dataContext.CreateParameter(this.AverageLeadTime, PARAM_AVERAGELEADTIME));
				command.Parameters.Add(dataContext.CreateParameter(this.StandardPrice, PARAM_STANDARDPRICE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.LastReceiptCost), PARAM_LASTRECEIPTCOST));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.LastReceiptDate), PARAM_LASTRECEIPTDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.MinOrderQty, PARAM_MINORDERQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.MaxOrderQty, PARAM_MAXORDERQTY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.OnOrderQty), PARAM_ONORDERQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitMeasureCode, PARAM_UNITMEASURECODE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCTVENDOR))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));				
				command.Parameters.Add(dataContext.CreateParameter(this.VendorID, PARAM_VENDORID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
