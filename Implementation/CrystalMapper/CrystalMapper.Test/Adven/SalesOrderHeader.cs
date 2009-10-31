/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: SalesOrderHeader
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
    public partial class SalesOrderHeader : Entity< SalesOrderHeader>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.SalesOrderHeader";	
     
		public const string COL_SALESORDERID = "SalesOrderID";
		public const string COL_REVISIONNUMBER = "RevisionNumber";
		public const string COL_ORDERDATE = "OrderDate";
		public const string COL_DUEDATE = "DueDate";
		public const string COL_SHIPDATE = "ShipDate";
		public const string COL_STATUS = "Status";
		public const string COL_ONLINEORDERFLAG = "OnlineOrderFlag";
		public const string COL_SALESORDERNUMBER = "SalesOrderNumber";
		public const string COL_PURCHASEORDERNUMBER = "PurchaseOrderNumber";
		public const string COL_ACCOUNTNUMBER = "AccountNumber";
		public const string COL_CUSTOMERID = "CustomerID";
		public const string COL_CONTACTID = "ContactID";
		public const string COL_SALESPERSONID = "SalesPersonID";
		public const string COL_TERRITORYID = "TerritoryID";
		public const string COL_BILLTOADDRESSID = "BillToAddressID";
		public const string COL_SHIPTOADDRESSID = "ShipToAddressID";
		public const string COL_SHIPMETHODID = "ShipMethodID";
		public const string COL_CREDITCARDID = "CreditCardID";
		public const string COL_CREDITCARDAPPROVALCODE = "CreditCardApprovalCode";
		public const string COL_CURRENCYRATEID = "CurrencyRateID";
		public const string COL_SUBTOTAL = "SubTotal";
		public const string COL_TAXAMT = "TaxAmt";
		public const string COL_FREIGHT = "Freight";
		public const string COL_TOTALDUE = "TotalDue";
		public const string COL_COMMENT = "Comment";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SALESORDERID = "@SalesOrderID";	
        public const string PARAM_REVISIONNUMBER = "@RevisionNumber";	
        public const string PARAM_ORDERDATE = "@OrderDate";	
        public const string PARAM_DUEDATE = "@DueDate";	
        public const string PARAM_SHIPDATE = "@ShipDate";	
        public const string PARAM_STATUS = "@Status";	
        public const string PARAM_ONLINEORDERFLAG = "@OnlineOrderFlag";	
        public const string PARAM_SALESORDERNUMBER = "@SalesOrderNumber";	
        public const string PARAM_PURCHASEORDERNUMBER = "@PurchaseOrderNumber";	
        public const string PARAM_ACCOUNTNUMBER = "@AccountNumber";	
        public const string PARAM_CUSTOMERID = "@CustomerID";	
        public const string PARAM_CONTACTID = "@ContactID";	
        public const string PARAM_SALESPERSONID = "@SalesPersonID";	
        public const string PARAM_TERRITORYID = "@TerritoryID";	
        public const string PARAM_BILLTOADDRESSID = "@BillToAddressID";	
        public const string PARAM_SHIPTOADDRESSID = "@ShipToAddressID";	
        public const string PARAM_SHIPMETHODID = "@ShipMethodID";	
        public const string PARAM_CREDITCARDID = "@CreditCardID";	
        public const string PARAM_CREDITCARDAPPROVALCODE = "@CreditCardApprovalCode";	
        public const string PARAM_CURRENCYRATEID = "@CurrencyRateID";	
        public const string PARAM_SUBTOTAL = "@SubTotal";	
        public const string PARAM_TAXAMT = "@TaxAmt";	
        public const string PARAM_FREIGHT = "@Freight";	
        public const string PARAM_TOTALDUE = "@TotalDue";	
        public const string PARAM_COMMENT = "@Comment";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SALESORDERHEADER = "INSERT INTO Sales.SalesOrderHeader([RevisionNumber],[OrderDate],[DueDate],[ShipDate],[Status],[OnlineOrderFlag],[SalesOrderNumber],[PurchaseOrderNumber],[AccountNumber],[CustomerID],[ContactID],[SalesPersonID],[TerritoryID],[BillToAddressID],[ShipToAddressID],[ShipMethodID],[CreditCardID],[CreditCardApprovalCode],[CurrencyRateID],[SubTotal],[TaxAmt],[Freight],[TotalDue],[Comment],[rowguid],[ModifiedDate]) VALUES (@RevisionNumber,@OrderDate,@DueDate,@ShipDate,@Status,@OnlineOrderFlag,@SalesOrderNumber,@PurchaseOrderNumber,@AccountNumber,@CustomerID,@ContactID,@SalesPersonID,@TerritoryID,@BillToAddressID,@ShipToAddressID,@ShipMethodID,@CreditCardID,@CreditCardApprovalCode,@CurrencyRateID,@SubTotal,@TaxAmt,@Freight,@TotalDue,@Comment,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_SALESORDERHEADER = "UPDATE Sales.SalesOrderHeader SET [RevisionNumber] = @RevisionNumber, [OrderDate] = @OrderDate, [DueDate] = @DueDate, [ShipDate] = @ShipDate, [Status] = @Status, [OnlineOrderFlag] = @OnlineOrderFlag, [SalesOrderNumber] = @SalesOrderNumber, [PurchaseOrderNumber] = @PurchaseOrderNumber, [AccountNumber] = @AccountNumber, [CustomerID] = @CustomerID, [ContactID] = @ContactID, [SalesPersonID] = @SalesPersonID, [TerritoryID] = @TerritoryID, [BillToAddressID] = @BillToAddressID, [ShipToAddressID] = @ShipToAddressID, [ShipMethodID] = @ShipMethodID, [CreditCardID] = @CreditCardID, [CreditCardApprovalCode] = @CreditCardApprovalCode, [CurrencyRateID] = @CurrencyRateID, [SubTotal] = @SubTotal, [TaxAmt] = @TaxAmt, [Freight] = @Freight, [TotalDue] = @TotalDue, [Comment] = @Comment, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [SalesOrderID] = @SalesOrderID";
		
		private const string SQL_DELETE_SALESORDERHEADER = "DELETE FROM Sales.SalesOrderHeader WHERE  [SalesOrderID] = @SalesOrderID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_SALESORDERID, PARAM_SALESORDERID, default(int))]
                              public virtual int SalesOrderID  { get; set; }		
		
        
	    [Column( COL_REVISIONNUMBER, PARAM_REVISIONNUMBER, default(byte))]
                              public virtual byte RevisionNumber  { get; set; }	      
        
	    [Column( COL_ORDERDATE, PARAM_ORDERDATE, typeof(System.DateTime))]
                              public virtual System.DateTime OrderDate  { get; set; }	      
        
	    [Column( COL_DUEDATE, PARAM_DUEDATE, typeof(System.DateTime))]
                              public virtual System.DateTime DueDate  { get; set; }	      
        
	    [Column( COL_SHIPDATE, PARAM_SHIPDATE )]
                              public virtual System.DateTime? ShipDate  { get; set; }	      
        
	    [Column( COL_STATUS, PARAM_STATUS, default(byte))]
                              public virtual byte Status  { get; set; }	      
        
	    [Column( COL_ONLINEORDERFLAG, PARAM_ONLINEORDERFLAG, default(bool))]
                              public virtual bool OnlineOrderFlag  { get; set; }	      
        
	    [Column( COL_SALESORDERNUMBER, PARAM_SALESORDERNUMBER )]
                              public virtual string SalesOrderNumber  { get; set; }	      
        
	    [Column( COL_PURCHASEORDERNUMBER, PARAM_PURCHASEORDERNUMBER )]
                              public virtual string PurchaseOrderNumber  { get; set; }	      
        
	    [Column( COL_ACCOUNTNUMBER, PARAM_ACCOUNTNUMBER )]
                              public virtual string AccountNumber  { get; set; }	      
        
	    [Column( COL_CUSTOMERID, PARAM_CUSTOMERID, default(int))]
                              public virtual int CustomerID  { get; set; }	      
        
	    [Column( COL_CONTACTID, PARAM_CONTACTID, default(int))]
                              public virtual int ContactID  { get; set; }	      
        
	    [Column( COL_SALESPERSONID, PARAM_SALESPERSONID )]
                              public virtual int? SalesPersonID  { get; set; }	      
        
	    [Column( COL_TERRITORYID, PARAM_TERRITORYID )]
                              public virtual int? TerritoryID  { get; set; }	      
        
	    [Column( COL_BILLTOADDRESSID, PARAM_BILLTOADDRESSID, default(int))]
                              public virtual int BillToAddressID  { get; set; }	      
        
	    [Column( COL_SHIPTOADDRESSID, PARAM_SHIPTOADDRESSID, default(int))]
                              public virtual int ShipToAddressID  { get; set; }	      
        
	    [Column( COL_SHIPMETHODID, PARAM_SHIPMETHODID, default(int))]
                              public virtual int ShipMethodID  { get; set; }	      
        
	    [Column( COL_CREDITCARDID, PARAM_CREDITCARDID )]
                              public virtual int? CreditCardID  { get; set; }	      
        
	    [Column( COL_CREDITCARDAPPROVALCODE, PARAM_CREDITCARDAPPROVALCODE )]
                              public virtual string CreditCardApprovalCode  { get; set; }	      
        
	    [Column( COL_CURRENCYRATEID, PARAM_CURRENCYRATEID )]
                              public virtual int? CurrencyRateID  { get; set; }	      
        
	    [Column( COL_SUBTOTAL, PARAM_SUBTOTAL, typeof(decimal))]
                              public virtual decimal SubTotal  { get; set; }	      
        
	    [Column( COL_TAXAMT, PARAM_TAXAMT, typeof(decimal))]
                              public virtual decimal TaxAmt  { get; set; }	      
        
	    [Column( COL_FREIGHT, PARAM_FREIGHT, typeof(decimal))]
                              public virtual decimal Freight  { get; set; }	      
        
	    [Column( COL_TOTALDUE, PARAM_TOTALDUE, typeof(decimal))]
                              public virtual decimal TotalDue  { get; set; }	      
        
	    [Column( COL_COMMENT, PARAM_COMMENT )]
                              public virtual string Comment  { get; set; }	      
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< SalesOrderDetail> SalesOrderDetails
        {
            get {
                  foreach(SalesOrderDetail salesOrderDetail in SalesOrderDetailList())
                    yield return salesOrderDetail; 
                }
        }
        
        public IEnumerable< SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons
        {
            get {
                  foreach(SalesOrderHeaderSalesReason salesOrderHeaderSalesReason in SalesOrderHeaderSalesReasonList())
                    yield return salesOrderHeaderSalesReason; 
                }
        }
        
        
        public IEnumerable< SalesReason> SalesReasons
        {
            get {           
                
                foreach(SalesReason salesReason in SalesReasonList())
                    yield return salesReason; 
                }         
        }    
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.SalesOrderID = (int)reader[COL_SALESORDERID];
			this.RevisionNumber = (byte)reader[COL_REVISIONNUMBER];
			this.OrderDate = (System.DateTime)reader[COL_ORDERDATE];
			this.DueDate = (System.DateTime)reader[COL_DUEDATE];
			this.ShipDate = DbConvert.ToNullable< System.DateTime >(reader[COL_SHIPDATE]);
			this.Status = (byte)reader[COL_STATUS];
			this.OnlineOrderFlag = (bool)reader[COL_ONLINEORDERFLAG];
			this.SalesOrderNumber = (string)reader[COL_SALESORDERNUMBER];
			this.PurchaseOrderNumber = DbConvert.ToString(reader[COL_PURCHASEORDERNUMBER]);
			this.AccountNumber = DbConvert.ToString(reader[COL_ACCOUNTNUMBER]);
			this.CustomerID = (int)reader[COL_CUSTOMERID];
			this.ContactID = (int)reader[COL_CONTACTID];
			this.SalesPersonID = DbConvert.ToNullable< int >(reader[COL_SALESPERSONID]);
			this.TerritoryID = DbConvert.ToNullable< int >(reader[COL_TERRITORYID]);
			this.BillToAddressID = (int)reader[COL_BILLTOADDRESSID];
			this.ShipToAddressID = (int)reader[COL_SHIPTOADDRESSID];
			this.ShipMethodID = (int)reader[COL_SHIPMETHODID];
			this.CreditCardID = DbConvert.ToNullable< int >(reader[COL_CREDITCARDID]);
			this.CreditCardApprovalCode = DbConvert.ToString(reader[COL_CREDITCARDAPPROVALCODE]);
			this.CurrencyRateID = DbConvert.ToNullable< int >(reader[COL_CURRENCYRATEID]);
			this.SubTotal = (decimal)reader[COL_SUBTOTAL];
			this.TaxAmt = (decimal)reader[COL_TAXAMT];
			this.Freight = (decimal)reader[COL_FREIGHT];
			this.TotalDue = (decimal)reader[COL_TOTALDUE];
			this.Comment = DbConvert.ToString(reader[COL_COMMENT]);
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SALESORDERHEADER))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.RevisionNumber, PARAM_REVISIONNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.OrderDate, PARAM_ORDERDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.DueDate, PARAM_DUEDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipDate), PARAM_SHIPDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Status, PARAM_STATUS));
				command.Parameters.Add(dataContext.CreateParameter(this.OnlineOrderFlag, PARAM_ONLINEORDERFLAG));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesOrderNumber, PARAM_SALESORDERNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.PurchaseOrderNumber), PARAM_PURCHASEORDERNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.AccountNumber), PARAM_ACCOUNTNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));
				command.Parameters.Add(dataContext.CreateParameter(this.ContactID, PARAM_CONTACTID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.SalesPersonID), PARAM_SALESPERSONID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.TerritoryID), PARAM_TERRITORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.BillToAddressID, PARAM_BILLTOADDRESSID));
				command.Parameters.Add(dataContext.CreateParameter(this.ShipToAddressID, PARAM_SHIPTOADDRESSID));
				command.Parameters.Add(dataContext.CreateParameter(this.ShipMethodID, PARAM_SHIPMETHODID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CreditCardID), PARAM_CREDITCARDID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CreditCardApprovalCode), PARAM_CREDITCARDAPPROVALCODE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CurrencyRateID), PARAM_CURRENCYRATEID));
				command.Parameters.Add(dataContext.CreateParameter(this.SubTotal, PARAM_SUBTOTAL));
				command.Parameters.Add(dataContext.CreateParameter(this.TaxAmt, PARAM_TAXAMT));
				command.Parameters.Add(dataContext.CreateParameter(this.Freight, PARAM_FREIGHT));
				command.Parameters.Add(dataContext.CreateParameter(this.TotalDue, PARAM_TOTALDUE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Comment), PARAM_COMMENT));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.SalesOrderID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SALESORDERHEADER))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SalesOrderID, PARAM_SALESORDERID));
				command.Parameters.Add(dataContext.CreateParameter(this.RevisionNumber, PARAM_REVISIONNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.OrderDate, PARAM_ORDERDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.DueDate, PARAM_DUEDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipDate), PARAM_SHIPDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Status, PARAM_STATUS));
				command.Parameters.Add(dataContext.CreateParameter(this.OnlineOrderFlag, PARAM_ONLINEORDERFLAG));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesOrderNumber, PARAM_SALESORDERNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.PurchaseOrderNumber), PARAM_PURCHASEORDERNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.AccountNumber), PARAM_ACCOUNTNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));
				command.Parameters.Add(dataContext.CreateParameter(this.ContactID, PARAM_CONTACTID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.SalesPersonID), PARAM_SALESPERSONID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.TerritoryID), PARAM_TERRITORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.BillToAddressID, PARAM_BILLTOADDRESSID));
				command.Parameters.Add(dataContext.CreateParameter(this.ShipToAddressID, PARAM_SHIPTOADDRESSID));
				command.Parameters.Add(dataContext.CreateParameter(this.ShipMethodID, PARAM_SHIPMETHODID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CreditCardID), PARAM_CREDITCARDID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CreditCardApprovalCode), PARAM_CREDITCARDAPPROVALCODE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CurrencyRateID), PARAM_CURRENCYRATEID));
				command.Parameters.Add(dataContext.CreateParameter(this.SubTotal, PARAM_SUBTOTAL));
				command.Parameters.Add(dataContext.CreateParameter(this.TaxAmt, PARAM_TAXAMT));
				command.Parameters.Add(dataContext.CreateParameter(this.Freight, PARAM_FREIGHT));
				command.Parameters.Add(dataContext.CreateParameter(this.TotalDue, PARAM_TOTALDUE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Comment), PARAM_COMMENT));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SALESORDERHEADER))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SalesOrderID, PARAM_SALESORDERID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public SalesOrderDetail GetSalesOrderDetailsQuery()
        {
            return new SalesOrderDetail {                
                                                                            SalesOrderID = this.SalesOrderID  
                                                                            };
        }
        
        public SalesOrderDetail[] SalesOrderDetailList()
        {
            return GetSalesOrderDetailsQuery().ToList();
        }  
        
        public SalesOrderHeaderSalesReason GetSalesOrderHeaderSalesReasonsQuery()
        {
            return new SalesOrderHeaderSalesReason {                
                                                                            SalesOrderID = this.SalesOrderID  
                                                                            };
        }
        
        public SalesOrderHeaderSalesReason[] SalesOrderHeaderSalesReasonList()
        {
            return GetSalesOrderHeaderSalesReasonsQuery().ToList();
        }  
        
        
        
        public SalesReason[] SalesReasonList()
        {
            string sqlQuery = @"SELECT Sales.SalesReason.*
                                FROM Sales.SalesOrderHeaderSalesReason
                                INNER JOIN Sales.SalesReason ON                                                                            
                                Sales.SalesOrderHeaderSalesReason.[SalesReasonID] = Sales.SalesReason.[SalesReasonID] AND
                                Sales.SalesOrderHeaderSalesReason.[SalesOrderID] = @SalesOrderID  
                                ";
                                
            Dictionary<string, object> parameterValues = new Dictionary<string, object>();
            parameterValues.Add(PARAM_SALESORDERID, this.SalesOrderID);
            
            return SalesReason.ToList(sqlQuery, parameterValues);
            
        }    
        
        #endregion
    }
}
