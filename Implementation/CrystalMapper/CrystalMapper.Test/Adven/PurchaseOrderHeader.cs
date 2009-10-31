/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: PurchaseOrderHeader
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
    public partial class PurchaseOrderHeader : Entity< PurchaseOrderHeader>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Purchasing.PurchaseOrderHeader";	
     
		public const string COL_PURCHASEORDERID = "PurchaseOrderID";
		public const string COL_REVISIONNUMBER = "RevisionNumber";
		public const string COL_STATUS = "Status";
		public const string COL_EMPLOYEEID = "EmployeeID";
		public const string COL_VENDORID = "VendorID";
		public const string COL_SHIPMETHODID = "ShipMethodID";
		public const string COL_ORDERDATE = "OrderDate";
		public const string COL_SHIPDATE = "ShipDate";
		public const string COL_SUBTOTAL = "SubTotal";
		public const string COL_TAXAMT = "TaxAmt";
		public const string COL_FREIGHT = "Freight";
		public const string COL_TOTALDUE = "TotalDue";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PURCHASEORDERID = "@PurchaseOrderID";	
        public const string PARAM_REVISIONNUMBER = "@RevisionNumber";	
        public const string PARAM_STATUS = "@Status";	
        public const string PARAM_EMPLOYEEID = "@EmployeeID";	
        public const string PARAM_VENDORID = "@VendorID";	
        public const string PARAM_SHIPMETHODID = "@ShipMethodID";	
        public const string PARAM_ORDERDATE = "@OrderDate";	
        public const string PARAM_SHIPDATE = "@ShipDate";	
        public const string PARAM_SUBTOTAL = "@SubTotal";	
        public const string PARAM_TAXAMT = "@TaxAmt";	
        public const string PARAM_FREIGHT = "@Freight";	
        public const string PARAM_TOTALDUE = "@TotalDue";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PURCHASEORDERHEADER = "INSERT INTO Purchasing.PurchaseOrderHeader([RevisionNumber],[Status],[EmployeeID],[VendorID],[ShipMethodID],[OrderDate],[ShipDate],[SubTotal],[TaxAmt],[Freight],[TotalDue],[ModifiedDate]) VALUES (@RevisionNumber,@Status,@EmployeeID,@VendorID,@ShipMethodID,@OrderDate,@ShipDate,@SubTotal,@TaxAmt,@Freight,@TotalDue,@ModifiedDate);";
		
		private const string SQL_UPDATE_PURCHASEORDERHEADER = "UPDATE Purchasing.PurchaseOrderHeader SET [RevisionNumber] = @RevisionNumber, [Status] = @Status, [EmployeeID] = @EmployeeID, [VendorID] = @VendorID, [ShipMethodID] = @ShipMethodID, [OrderDate] = @OrderDate, [ShipDate] = @ShipDate, [SubTotal] = @SubTotal, [TaxAmt] = @TaxAmt, [Freight] = @Freight, [TotalDue] = @TotalDue, [ModifiedDate] = @ModifiedDate,  WHERE [PurchaseOrderID] = @PurchaseOrderID";
		
		private const string SQL_DELETE_PURCHASEORDERHEADER = "DELETE FROM Purchasing.PurchaseOrderHeader WHERE  [PurchaseOrderID] = @PurchaseOrderID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_PURCHASEORDERID, PARAM_PURCHASEORDERID, default(int))]
                              public virtual int PurchaseOrderID  { get; set; }		
		
        
	    [Column( COL_REVISIONNUMBER, PARAM_REVISIONNUMBER, default(byte))]
                              public virtual byte RevisionNumber  { get; set; }	      
        
	    [Column( COL_STATUS, PARAM_STATUS, default(byte))]
                              public virtual byte Status  { get; set; }	      
        
	    [Column( COL_EMPLOYEEID, PARAM_EMPLOYEEID, default(int))]
                              public virtual int EmployeeID  { get; set; }	      
        
	    [Column( COL_VENDORID, PARAM_VENDORID, default(int))]
                              public virtual int VendorID  { get; set; }	      
        
	    [Column( COL_SHIPMETHODID, PARAM_SHIPMETHODID, default(int))]
                              public virtual int ShipMethodID  { get; set; }	      
        
	    [Column( COL_ORDERDATE, PARAM_ORDERDATE, typeof(System.DateTime))]
                              public virtual System.DateTime OrderDate  { get; set; }	      
        
	    [Column( COL_SHIPDATE, PARAM_SHIPDATE )]
                              public virtual System.DateTime? ShipDate  { get; set; }	      
        
	    [Column( COL_SUBTOTAL, PARAM_SUBTOTAL, typeof(decimal))]
                              public virtual decimal SubTotal  { get; set; }	      
        
	    [Column( COL_TAXAMT, PARAM_TAXAMT, typeof(decimal))]
                              public virtual decimal TaxAmt  { get; set; }	      
        
	    [Column( COL_FREIGHT, PARAM_FREIGHT, typeof(decimal))]
                              public virtual decimal Freight  { get; set; }	      
        
	    [Column( COL_TOTALDUE, PARAM_TOTALDUE, typeof(decimal))]
                              public virtual decimal TotalDue  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< PurchaseOrderDetail> PurchaseOrderDetails
        {
            get {
                  foreach(PurchaseOrderDetail purchaseOrderDetail in PurchaseOrderDetailList())
                    yield return purchaseOrderDetail; 
                }
        }
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.PurchaseOrderID = (int)reader[COL_PURCHASEORDERID];
			this.RevisionNumber = (byte)reader[COL_REVISIONNUMBER];
			this.Status = (byte)reader[COL_STATUS];
			this.EmployeeID = (int)reader[COL_EMPLOYEEID];
			this.VendorID = (int)reader[COL_VENDORID];
			this.ShipMethodID = (int)reader[COL_SHIPMETHODID];
			this.OrderDate = (System.DateTime)reader[COL_ORDERDATE];
			this.ShipDate = DbConvert.ToNullable< System.DateTime >(reader[COL_SHIPDATE]);
			this.SubTotal = (decimal)reader[COL_SUBTOTAL];
			this.TaxAmt = (decimal)reader[COL_TAXAMT];
			this.Freight = (decimal)reader[COL_FREIGHT];
			this.TotalDue = (decimal)reader[COL_TOTALDUE];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PURCHASEORDERHEADER))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.RevisionNumber, PARAM_REVISIONNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.Status, PARAM_STATUS));
				command.Parameters.Add(dataContext.CreateParameter(this.EmployeeID, PARAM_EMPLOYEEID));
				command.Parameters.Add(dataContext.CreateParameter(this.VendorID, PARAM_VENDORID));
				command.Parameters.Add(dataContext.CreateParameter(this.ShipMethodID, PARAM_SHIPMETHODID));
				command.Parameters.Add(dataContext.CreateParameter(this.OrderDate, PARAM_ORDERDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipDate), PARAM_SHIPDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.SubTotal, PARAM_SUBTOTAL));
				command.Parameters.Add(dataContext.CreateParameter(this.TaxAmt, PARAM_TAXAMT));
				command.Parameters.Add(dataContext.CreateParameter(this.Freight, PARAM_FREIGHT));
				command.Parameters.Add(dataContext.CreateParameter(this.TotalDue, PARAM_TOTALDUE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.PurchaseOrderID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PURCHASEORDERHEADER))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.PurchaseOrderID, PARAM_PURCHASEORDERID));
				command.Parameters.Add(dataContext.CreateParameter(this.RevisionNumber, PARAM_REVISIONNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.Status, PARAM_STATUS));
				command.Parameters.Add(dataContext.CreateParameter(this.EmployeeID, PARAM_EMPLOYEEID));
				command.Parameters.Add(dataContext.CreateParameter(this.VendorID, PARAM_VENDORID));
				command.Parameters.Add(dataContext.CreateParameter(this.ShipMethodID, PARAM_SHIPMETHODID));
				command.Parameters.Add(dataContext.CreateParameter(this.OrderDate, PARAM_ORDERDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipDate), PARAM_SHIPDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.SubTotal, PARAM_SUBTOTAL));
				command.Parameters.Add(dataContext.CreateParameter(this.TaxAmt, PARAM_TAXAMT));
				command.Parameters.Add(dataContext.CreateParameter(this.Freight, PARAM_FREIGHT));
				command.Parameters.Add(dataContext.CreateParameter(this.TotalDue, PARAM_TOTALDUE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PURCHASEORDERHEADER))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.PurchaseOrderID, PARAM_PURCHASEORDERID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public PurchaseOrderDetail GetPurchaseOrderDetailsQuery()
        {
            return new PurchaseOrderDetail {                
                                                                            PurchaseOrderID = this.PurchaseOrderID  
                                                                            };
        }
        
        public PurchaseOrderDetail[] PurchaseOrderDetailList()
        {
            return GetPurchaseOrderDetailsQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
