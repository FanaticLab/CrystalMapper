/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: SalesOrderHeader
 * 
 * Email: mk.faraz@gmail.com
 * 
 * Blogs: http://csharplive.wordpress.com, http://farazmasoodkhan.wordpress.com
 *
 * Website: http://www.linkedin.com/in/farazmasoodkhan
 *
 * Copyright: Faraz Masood Khan @ Copyright 2009
 *
/*/

using System;
using System.Data.Common;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;

using CoreSystem.Data;

using CrystalMapper;
using CrystalMapper.Data;
using CrystalMapper.Mapping;

namespace feedbook.Model
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
		
		private const string SQL_INSERT_SALESORDERHEADER = "INSERT INTO Sales.SalesOrderHeader([RevisionNumber],[OrderDate],[DueDate],[ShipDate],[Status],[OnlineOrderFlag],[SalesOrderNumber],[PurchaseOrderNumber],[AccountNumber],[CustomerID],[SalesPersonID],[TerritoryID],[BillToAddressID],[ShipToAddressID],[ShipMethodID],[CreditCardID],[CreditCardApprovalCode],[CurrencyRateID],[SubTotal],[TaxAmt],[Freight],[TotalDue],[Comment],[rowguid],[ModifiedDate]) VALUES (@RevisionNumber,@OrderDate,@DueDate,@ShipDate,@Status,@OnlineOrderFlag,@SalesOrderNumber,@PurchaseOrderNumber,@AccountNumber,@CustomerID,@SalesPersonID,@TerritoryID,@BillToAddressID,@ShipToAddressID,@ShipMethodID,@CreditCardID,@CreditCardApprovalCode,@CurrencyRateID,@SubTotal,@TaxAmt,@Freight,@TotalDue,@Comment,@rowguid,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_SALESORDERHEADER = "UPDATE Sales.SalesOrderHeader SET  [RevisionNumber] = @RevisionNumber, [OrderDate] = @OrderDate, [DueDate] = @DueDate, [ShipDate] = @ShipDate, [Status] = @Status, [OnlineOrderFlag] = @OnlineOrderFlag, [SalesOrderNumber] = @SalesOrderNumber, [PurchaseOrderNumber] = @PurchaseOrderNumber, [AccountNumber] = @AccountNumber, [CustomerID] = @CustomerID, [SalesPersonID] = @SalesPersonID, [TerritoryID] = @TerritoryID, [BillToAddressID] = @BillToAddressID, [ShipToAddressID] = @ShipToAddressID, [ShipMethodID] = @ShipMethodID, [CreditCardID] = @CreditCardID, [CreditCardApprovalCode] = @CreditCardApprovalCode, [CurrencyRateID] = @CurrencyRateID, [SubTotal] = @SubTotal, [TaxAmt] = @TaxAmt, [Freight] = @Freight, [TotalDue] = @TotalDue, [Comment] = @Comment, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate WHERE [SalesOrderID] = @SalesOrderID";
		
		private const string SQL_DELETE_SALESORDERHEADER = "DELETE FROM Sales.SalesOrderHeader WHERE  [SalesOrderID] = @SalesOrderID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int salesorderid = default(int);
	
		protected byte revisionnumber = default(byte);
	
		protected System.DateTime orderdate = default(System.DateTime);
	
		protected System.DateTime duedate = default(System.DateTime);
	
		protected System.DateTime? shipdate = default(System.DateTime?);
	
		protected byte status = default(byte);
	
		protected bool onlineorderflag = default(bool);
	
		protected string salesordernumber = default(string);
	
		protected string purchaseordernumber = default(string);
	
		protected string accountnumber = default(string);
	
		protected int customerid = default(int);
	
		protected int? salespersonid = default(int?);
	
		protected int? territoryid = default(int?);
	
		protected int billtoaddressid = default(int);
	
		protected int shiptoaddressid = default(int);
	
		protected int shipmethodid = default(int);
	
		protected int? creditcardid = default(int?);
	
		protected string creditcardapprovalcode = default(string);
	
		protected int? currencyrateid = default(int?);
	
		protected decimal subtotal = default(decimal);
	
		protected decimal taxamt = default(decimal);
	
		protected decimal freight = default(decimal);
	
		protected decimal totaldue = default(decimal);
	
		protected string comment = default(string);
	
		protected System.Guid rowguid = default(System.Guid);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected address billtoaddressEntity;
	
		protected address shiptoaddressEntity;
	
		protected CreditCard creditCardEntity;
	
		protected CurrencyRate currencyRateEntity;
	
		protected Customer customerEntity;
	
		protected SalesPerson salesPersonEntity;
	
		protected SalesTerritory salesTerritoryEntity;
	
		protected ShipMethod shipMethodEntity;
	
        protected EntityCollection< SalesOrderDetail> salesOrderDetails ;
        
        protected EntityCollection< SalesOrderHeaderSalesReason> salesOrderHeaderSalesReasons ;
        
        #endregion

 		#region Properties	

        [Column( COL_SALESORDERID, PARAM_SALESORDERID, default(int))]
                              public virtual int SalesOrderID 
        {
            get { return this.salesorderid; }
			set	{ 
                  if(this.salesorderid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SalesOrderID"));  
                        this.salesorderid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SalesOrderID"));
                    }   
                }
        }	
		
        [Column( COL_REVISIONNUMBER, PARAM_REVISIONNUMBER, default(byte))]
                              public virtual byte RevisionNumber 
        {
            get { return this.revisionnumber; }
			set	{ 
                  if(this.revisionnumber != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("RevisionNumber"));  
                        this.revisionnumber = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("RevisionNumber"));
                    }   
                }
        }	
		
        [Column( COL_ORDERDATE, PARAM_ORDERDATE, typeof(System.DateTime))]
                              public virtual System.DateTime OrderDate 
        {
            get { return this.orderdate; }
			set	{ 
                  if(this.orderdate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("OrderDate"));  
                        this.orderdate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("OrderDate"));
                    }   
                }
        }	
		
        [Column( COL_DUEDATE, PARAM_DUEDATE, typeof(System.DateTime))]
                              public virtual System.DateTime DueDate 
        {
            get { return this.duedate; }
			set	{ 
                  if(this.duedate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("DueDate"));  
                        this.duedate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("DueDate"));
                    }   
                }
        }	
		
        [Column( COL_SHIPDATE, PARAM_SHIPDATE )]
                              public virtual System.DateTime? ShipDate 
        {
            get { return this.shipdate; }
			set	{ 
                  if(this.shipdate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ShipDate"));  
                        this.shipdate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ShipDate"));
                    }   
                }
        }	
		
        [Column( COL_STATUS, PARAM_STATUS, default(byte))]
                              public virtual byte Status 
        {
            get { return this.status; }
			set	{ 
                  if(this.status != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Status"));  
                        this.status = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Status"));
                    }   
                }
        }	
		
        [Column( COL_ONLINEORDERFLAG, PARAM_ONLINEORDERFLAG, default(bool))]
                              public virtual bool OnlineOrderFlag 
        {
            get { return this.onlineorderflag; }
			set	{ 
                  if(this.onlineorderflag != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("OnlineOrderFlag"));  
                        this.onlineorderflag = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("OnlineOrderFlag"));
                    }   
                }
        }	
		
        [Column( COL_SALESORDERNUMBER, PARAM_SALESORDERNUMBER )]
                              public virtual string SalesOrderNumber 
        {
            get { return this.salesordernumber; }
			set	{ 
                  if(this.salesordernumber != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SalesOrderNumber"));  
                        this.salesordernumber = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SalesOrderNumber"));
                    }   
                }
        }	
		
        [Column( COL_PURCHASEORDERNUMBER, PARAM_PURCHASEORDERNUMBER )]
                              public virtual string PurchaseOrderNumber 
        {
            get { return this.purchaseordernumber; }
			set	{ 
                  if(this.purchaseordernumber != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("PurchaseOrderNumber"));  
                        this.purchaseordernumber = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("PurchaseOrderNumber"));
                    }   
                }
        }	
		
        [Column( COL_ACCOUNTNUMBER, PARAM_ACCOUNTNUMBER )]
                              public virtual string AccountNumber 
        {
            get { return this.accountnumber; }
			set	{ 
                  if(this.accountnumber != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("AccountNumber"));  
                        this.accountnumber = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("AccountNumber"));
                    }   
                }
        }	
		
        [Column( COL_CREDITCARDAPPROVALCODE, PARAM_CREDITCARDAPPROVALCODE )]
                              public virtual string CreditCardApprovalCode 
        {
            get { return this.creditcardapprovalcode; }
			set	{ 
                  if(this.creditcardapprovalcode != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CreditCardApprovalCode"));  
                        this.creditcardapprovalcode = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CreditCardApprovalCode"));
                    }   
                }
        }	
		
        [Column( COL_SUBTOTAL, PARAM_SUBTOTAL, typeof(decimal))]
                              public virtual decimal SubTotal 
        {
            get { return this.subtotal; }
			set	{ 
                  if(this.subtotal != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SubTotal"));  
                        this.subtotal = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SubTotal"));
                    }   
                }
        }	
		
        [Column( COL_TAXAMT, PARAM_TAXAMT, typeof(decimal))]
                              public virtual decimal TaxAmt 
        {
            get { return this.taxamt; }
			set	{ 
                  if(this.taxamt != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("TaxAmt"));  
                        this.taxamt = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("TaxAmt"));
                    }   
                }
        }	
		
        [Column( COL_FREIGHT, PARAM_FREIGHT, typeof(decimal))]
                              public virtual decimal Freight 
        {
            get { return this.freight; }
			set	{ 
                  if(this.freight != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Freight"));  
                        this.freight = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Freight"));
                    }   
                }
        }	
		
        [Column( COL_TOTALDUE, PARAM_TOTALDUE, typeof(decimal))]
                              public virtual decimal TotalDue 
        {
            get { return this.totaldue; }
			set	{ 
                  if(this.totaldue != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("TotalDue"));  
                        this.totaldue = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("TotalDue"));
                    }   
                }
        }	
		
        [Column( COL_COMMENT, PARAM_COMMENT )]
                              public virtual string Comment 
        {
            get { return this.comment; }
			set	{ 
                  if(this.comment != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Comment"));  
                        this.comment = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Comment"));
                    }   
                }
        }	
		
        [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid 
        {
            get { return this.rowguid; }
			set	{ 
                  if(this.rowguid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Rowguid"));  
                        this.rowguid = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Rowguid"));
                    }   
                }
        }	
		
        [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate 
        {
            get { return this.modifieddate; }
			set	{ 
                  if(this.modifieddate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ModifiedDate"));  
                        this.modifieddate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ModifiedDate"));
                    }   
                }
        }	
		
        [Column( COL_BILLTOADDRESSID, PARAM_BILLTOADDRESSID, default(int))]
                              public virtual int BillToAddressID                
        {
            get
            {
                if(this.billtoaddressEntity == null)
                    return this.billtoaddressid ;
                
                return this.billtoaddressEntity.AddressID;            
            }
            set
            {
                if(this.billtoaddressid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("BillToAddressID"));                    
                    this.billtoaddressid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("BillToAddressID"));
                    
                    this.billtoaddressEntity = null;
                }                
            }          
        }	
        
        [Column( COL_SHIPTOADDRESSID, PARAM_SHIPTOADDRESSID, default(int))]
                              public virtual int ShipToAddressID                
        {
            get
            {
                if(this.shiptoaddressEntity == null)
                    return this.shiptoaddressid ;
                
                return this.shiptoaddressEntity.AddressID;            
            }
            set
            {
                if(this.shiptoaddressid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ShipToAddressID"));                    
                    this.shiptoaddressid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ShipToAddressID"));
                    
                    this.shiptoaddressEntity = null;
                }                
            }          
        }	
        
        [Column( COL_CREDITCARDID, PARAM_CREDITCARDID )]
                              public virtual int? CreditCardID                
        {
            get
            {
                if(this.creditCardEntity == null)
                    return this.creditcardid ;
                
                return this.creditCardEntity.CreditCardID;            
            }
            set
            {
                if(this.creditcardid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("CreditCardID"));                    
                    this.creditcardid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("CreditCardID"));
                    
                    this.creditCardEntity = null;
                }                
            }          
        }	
        
        [Column( COL_CURRENCYRATEID, PARAM_CURRENCYRATEID )]
                              public virtual int? CurrencyRateID                
        {
            get
            {
                if(this.currencyRateEntity == null)
                    return this.currencyrateid ;
                
                return this.currencyRateEntity.CurrencyRateID;            
            }
            set
            {
                if(this.currencyrateid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("CurrencyRateID"));                    
                    this.currencyrateid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("CurrencyRateID"));
                    
                    this.currencyRateEntity = null;
                }                
            }          
        }	
        
        [Column( COL_CUSTOMERID, PARAM_CUSTOMERID, default(int))]
                              public virtual int CustomerID                
        {
            get
            {
                if(this.customerEntity == null)
                    return this.customerid ;
                
                return this.customerEntity.CustomerID;            
            }
            set
            {
                if(this.customerid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("CustomerID"));                    
                    this.customerid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("CustomerID"));
                    
                    this.customerEntity = null;
                }                
            }          
        }	
        
        [Column( COL_SALESPERSONID, PARAM_SALESPERSONID )]
                              public virtual int? SalesPersonID                
        {
            get
            {
                if(this.salesPersonEntity == null)
                    return this.salespersonid ;
                
                return this.salesPersonEntity.BusinessEntityID;            
            }
            set
            {
                if(this.salespersonid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("SalesPersonID"));                    
                    this.salespersonid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("SalesPersonID"));
                    
                    this.salesPersonEntity = null;
                }                
            }          
        }	
        
        [Column( COL_TERRITORYID, PARAM_TERRITORYID )]
                              public virtual int? TerritoryID                
        {
            get
            {
                if(this.salesTerritoryEntity == null)
                    return this.territoryid ;
                
                return this.salesTerritoryEntity.TerritoryID;            
            }
            set
            {
                if(this.territoryid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("TerritoryID"));                    
                    this.territoryid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("TerritoryID"));
                    
                    this.salesTerritoryEntity = null;
                }                
            }          
        }	
        
        [Column( COL_SHIPMETHODID, PARAM_SHIPMETHODID, default(int))]
                              public virtual int ShipMethodID                
        {
            get
            {
                if(this.shipMethodEntity == null)
                    return this.shipmethodid ;
                
                return this.shipMethodEntity.ShipMethodID;            
            }
            set
            {
                if(this.shipmethodid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ShipMethodID"));                    
                    this.shipmethodid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ShipMethodID"));
                    
                    this.shipMethodEntity = null;
                }                
            }          
        }	
        
        public address BillToAddressEntity
        {
            get { 
                    if(this.billtoaddressEntity == null
                       && this.billtoaddressid != default(int)) 
                    {
                        address addressQuery = new address {
                                                        AddressID = this.billtoaddressid  
                                                        };
                        
                        address[]  address = addressQuery.ToList();                        
                        if(address.Length == 1)
                            this.billtoaddressEntity = address[0];                        
                    }
                    
                    return this.billtoaddressEntity; 
                }
			set	{ 
                  if(this.billtoaddressEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("BillToAddressEntity"));
                        if (this.billtoaddressEntity != null)
                            this.Parents.Remove(this.billtoaddressEntity);                            
                        
                        if((this.billtoaddressEntity = value) != null) 
                            this.Parents.Add(this.billtoaddressEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("BillToAddressEntity"));
                        
                        this.billtoaddressid = this.BillToAddressEntity.AddressID;
                    }   
                }
        }	
		
        public address ShipToAddressEntity
        {
            get { 
                    if(this.shiptoaddressEntity == null
                       && this.shiptoaddressid != default(int)) 
                    {
                        address addressQuery = new address {
                                                        AddressID = this.shiptoaddressid  
                                                        };
                        
                        address[]  address = addressQuery.ToList();                        
                        if(address.Length == 1)
                            this.shiptoaddressEntity = address[0];                        
                    }
                    
                    return this.shiptoaddressEntity; 
                }
			set	{ 
                  if(this.shiptoaddressEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ShipToAddressEntity"));
                        if (this.shiptoaddressEntity != null)
                            this.Parents.Remove(this.shiptoaddressEntity);                            
                        
                        if((this.shiptoaddressEntity = value) != null) 
                            this.Parents.Add(this.shiptoaddressEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ShipToAddressEntity"));
                        
                        this.shiptoaddressid = this.ShipToAddressEntity.AddressID;
                    }   
                }
        }	
		
        public CreditCard CreditCardEntity
        {
            get { 
                    if(this.creditCardEntity == null
                       && this.creditcardid.HasValue )
                    {
                        CreditCard creditCardQuery = new CreditCard {
                                                        CreditCardID = this.creditcardid.Value  
                                                        };
                        
                        CreditCard[]  creditCards = creditCardQuery.ToList();                        
                        if(creditCards.Length == 1)
                            this.creditCardEntity = creditCards[0];                        
                    }
                    
                    return this.creditCardEntity; 
                }
			set	{ 
                  if(this.creditCardEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CreditCardEntity"));
                        if (this.creditCardEntity != null)
                            this.Parents.Remove(this.creditCardEntity);                            
                        
                        if((this.creditCardEntity = value) != null) 
                            this.Parents.Add(this.creditCardEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CreditCardEntity"));
                        
                        this.creditcardid = this.CreditCardEntity.CreditCardID;
                    }   
                }
        }	
		
        public CurrencyRate CurrencyRateEntity
        {
            get { 
                    if(this.currencyRateEntity == null
                       && this.currencyrateid.HasValue )
                    {
                        CurrencyRate currencyRateQuery = new CurrencyRate {
                                                        CurrencyRateID = this.currencyrateid.Value  
                                                        };
                        
                        CurrencyRate[]  currencyRates = currencyRateQuery.ToList();                        
                        if(currencyRates.Length == 1)
                            this.currencyRateEntity = currencyRates[0];                        
                    }
                    
                    return this.currencyRateEntity; 
                }
			set	{ 
                  if(this.currencyRateEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CurrencyRateEntity"));
                        if (this.currencyRateEntity != null)
                            this.Parents.Remove(this.currencyRateEntity);                            
                        
                        if((this.currencyRateEntity = value) != null) 
                            this.Parents.Add(this.currencyRateEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CurrencyRateEntity"));
                        
                        this.currencyrateid = this.CurrencyRateEntity.CurrencyRateID;
                    }   
                }
        }	
		
        public Customer CustomerEntity
        {
            get { 
                    if(this.customerEntity == null
                       && this.customerid != default(int)) 
                    {
                        Customer customerQuery = new Customer {
                                                        CustomerID = this.customerid  
                                                        };
                        
                        Customer[]  customers = customerQuery.ToList();                        
                        if(customers.Length == 1)
                            this.customerEntity = customers[0];                        
                    }
                    
                    return this.customerEntity; 
                }
			set	{ 
                  if(this.customerEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CustomerEntity"));
                        if (this.customerEntity != null)
                            this.Parents.Remove(this.customerEntity);                            
                        
                        if((this.customerEntity = value) != null) 
                            this.Parents.Add(this.customerEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CustomerEntity"));
                        
                        this.customerid = this.CustomerEntity.CustomerID;
                    }   
                }
        }	
		
        public SalesPerson SalesPersonEntity
        {
            get { 
                    if(this.salesPersonEntity == null
                       && this.salespersonid.HasValue )
                    {
                        SalesPerson salesPersonQuery = new SalesPerson {
                                                        BusinessEntityID = this.salespersonid.Value  
                                                        };
                        
                        SalesPerson[]  salesPeople = salesPersonQuery.ToList();                        
                        if(salesPeople.Length == 1)
                            this.salesPersonEntity = salesPeople[0];                        
                    }
                    
                    return this.salesPersonEntity; 
                }
			set	{ 
                  if(this.salesPersonEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SalesPersonEntity"));
                        if (this.salesPersonEntity != null)
                            this.Parents.Remove(this.salesPersonEntity);                            
                        
                        if((this.salesPersonEntity = value) != null) 
                            this.Parents.Add(this.salesPersonEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SalesPersonEntity"));
                        
                        this.salespersonid = this.SalesPersonEntity.BusinessEntityID;
                    }   
                }
        }	
		
        public SalesTerritory SalesTerritoryEntity
        {
            get { 
                    if(this.salesTerritoryEntity == null
                       && this.territoryid.HasValue )
                    {
                        SalesTerritory salesTerritoryQuery = new SalesTerritory {
                                                        TerritoryID = this.territoryid.Value  
                                                        };
                        
                        SalesTerritory[]  salesTerritories = salesTerritoryQuery.ToList();                        
                        if(salesTerritories.Length == 1)
                            this.salesTerritoryEntity = salesTerritories[0];                        
                    }
                    
                    return this.salesTerritoryEntity; 
                }
			set	{ 
                  if(this.salesTerritoryEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SalesTerritoryEntity"));
                        if (this.salesTerritoryEntity != null)
                            this.Parents.Remove(this.salesTerritoryEntity);                            
                        
                        if((this.salesTerritoryEntity = value) != null) 
                            this.Parents.Add(this.salesTerritoryEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SalesTerritoryEntity"));
                        
                        this.territoryid = this.SalesTerritoryEntity.TerritoryID;
                    }   
                }
        }	
		
        public ShipMethod ShipMethodEntity
        {
            get { 
                    if(this.shipMethodEntity == null
                       && this.shipmethodid != default(int)) 
                    {
                        ShipMethod shipMethodQuery = new ShipMethod {
                                                        ShipMethodID = this.shipmethodid  
                                                        };
                        
                        ShipMethod[]  shipMethods = shipMethodQuery.ToList();                        
                        if(shipMethods.Length == 1)
                            this.shipMethodEntity = shipMethods[0];                        
                    }
                    
                    return this.shipMethodEntity; 
                }
			set	{ 
                  if(this.shipMethodEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ShipMethodEntity"));
                        if (this.shipMethodEntity != null)
                            this.Parents.Remove(this.shipMethodEntity);                            
                        
                        if((this.shipMethodEntity = value) != null) 
                            this.Parents.Add(this.shipMethodEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ShipMethodEntity"));
                        
                        this.shipmethodid = this.ShipMethodEntity.ShipMethodID;
                    }   
                }
        }	
		
        public EntityCollection< SalesOrderDetail> SalesOrderDetails 
        {
            get { return this.salesOrderDetails;}
        }
        
        public EntityCollection< SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons 
        {
            get { return this.salesOrderHeaderSalesReasons;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public SalesOrderHeader()
        {
             this.salesOrderDetails = new EntityCollection< SalesOrderDetail>(this, new Associate< SalesOrderDetail>(this.AssociateSalesOrderDetails), new DeAssociate< SalesOrderDetail>(this.DeAssociateSalesOrderDetails), new GetChildren< SalesOrderDetail>(this.GetChildrenSalesOrderDetails));
             this.salesOrderHeaderSalesReasons = new EntityCollection< SalesOrderHeaderSalesReason>(this, new Associate< SalesOrderHeaderSalesReason>(this.AssociateSalesOrderHeaderSalesReasons), new DeAssociate< SalesOrderHeaderSalesReason>(this.DeAssociateSalesOrderHeaderSalesReasons), new GetChildren< SalesOrderHeaderSalesReason>(this.GetChildrenSalesOrderHeaderSalesReasons));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.salesorderid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            SalesOrderHeader entity = obj as SalesOrderHeader;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.SalesOrderID == entity.SalesOrderID
                        && this.SalesOrderID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.salesorderid = (int)reader[COL_SALESORDERID];
			this.revisionnumber = (byte)reader[COL_REVISIONNUMBER];
			this.orderdate = (System.DateTime)reader[COL_ORDERDATE];
			this.duedate = (System.DateTime)reader[COL_DUEDATE];
			this.shipdate = DbConvert.ToNullable< System.DateTime >(reader[COL_SHIPDATE]);
			this.status = (byte)reader[COL_STATUS];
			this.onlineorderflag = (bool)reader[COL_ONLINEORDERFLAG];
			this.salesordernumber = (string)reader[COL_SALESORDERNUMBER];
			this.purchaseordernumber = DbConvert.ToString(reader[COL_PURCHASEORDERNUMBER]);
			this.accountnumber = DbConvert.ToString(reader[COL_ACCOUNTNUMBER]);
			this.customerid = (int)reader[COL_CUSTOMERID];
			this.salespersonid = DbConvert.ToNullable< int >(reader[COL_SALESPERSONID]);
			this.territoryid = DbConvert.ToNullable< int >(reader[COL_TERRITORYID]);
			this.billtoaddressid = (int)reader[COL_BILLTOADDRESSID];
			this.shiptoaddressid = (int)reader[COL_SHIPTOADDRESSID];
			this.shipmethodid = (int)reader[COL_SHIPMETHODID];
			this.creditcardid = DbConvert.ToNullable< int >(reader[COL_CREDITCARDID]);
			this.creditcardapprovalcode = DbConvert.ToString(reader[COL_CREDITCARDAPPROVALCODE]);
			this.currencyrateid = DbConvert.ToNullable< int >(reader[COL_CURRENCYRATEID]);
			this.subtotal = (decimal)reader[COL_SUBTOTAL];
			this.taxamt = (decimal)reader[COL_TAXAMT];
			this.freight = (decimal)reader[COL_FREIGHT];
			this.totaldue = (decimal)reader[COL_TOTALDUE];
			this.comment = DbConvert.ToString(reader[COL_COMMENT]);
			this.rowguid = (System.Guid)reader[COL_ROWGUID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
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
                this.SalesOrderID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
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
        
        #region Entity Relationship Functions
        
        private void AssociateSalesOrderDetails(SalesOrderDetail salesOrderDetail)
        {
           salesOrderDetail.SalesOrderHeaderEntity = this;
        }
        
        private void DeAssociateSalesOrderDetails(SalesOrderDetail salesOrderDetail)
        {
          if(salesOrderDetail.SalesOrderHeaderEntity == this)
             salesOrderDetail.SalesOrderHeaderEntity = null;
        }
        
        private SalesOrderDetail[] GetChildrenSalesOrderDetails()
        {
            SalesOrderDetail childrenQuery = new SalesOrderDetail();
            childrenQuery.SalesOrderHeaderEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateSalesOrderHeaderSalesReasons(SalesOrderHeaderSalesReason salesOrderHeaderSalesReason)
        {
           salesOrderHeaderSalesReason.SalesOrderHeaderEntity = this;
        }
        
        private void DeAssociateSalesOrderHeaderSalesReasons(SalesOrderHeaderSalesReason salesOrderHeaderSalesReason)
        {
          if(salesOrderHeaderSalesReason.SalesOrderHeaderEntity == this)
             salesOrderHeaderSalesReason.SalesOrderHeaderEntity = null;
        }
        
        private SalesOrderHeaderSalesReason[] GetChildrenSalesOrderHeaderSalesReasons()
        {
            SalesOrderHeaderSalesReason childrenQuery = new SalesOrderHeaderSalesReason();
            childrenQuery.SalesOrderHeaderEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
