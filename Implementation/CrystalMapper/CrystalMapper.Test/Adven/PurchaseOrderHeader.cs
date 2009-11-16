/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: PurchaseOrderHeader
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
		
		private const string SQL_INSERT_PURCHASEORDERHEADER = "INSERT INTO Purchasing.PurchaseOrderHeader([RevisionNumber],[Status],[EmployeeID],[VendorID],[ShipMethodID],[OrderDate],[ShipDate],[SubTotal],[TaxAmt],[Freight],[TotalDue],[ModifiedDate]) VALUES (@RevisionNumber,@Status,@EmployeeID,@VendorID,@ShipMethodID,@OrderDate,@ShipDate,@SubTotal,@TaxAmt,@Freight,@TotalDue,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_PURCHASEORDERHEADER = "UPDATE Purchasing.PurchaseOrderHeader SET  [RevisionNumber] = @RevisionNumber, [Status] = @Status, [EmployeeID] = @EmployeeID, [VendorID] = @VendorID, [ShipMethodID] = @ShipMethodID, [OrderDate] = @OrderDate, [ShipDate] = @ShipDate, [SubTotal] = @SubTotal, [TaxAmt] = @TaxAmt, [Freight] = @Freight, [TotalDue] = @TotalDue, [ModifiedDate] = @ModifiedDate WHERE [PurchaseOrderID] = @PurchaseOrderID";
		
		private const string SQL_DELETE_PURCHASEORDERHEADER = "DELETE FROM Purchasing.PurchaseOrderHeader WHERE  [PurchaseOrderID] = @PurchaseOrderID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int purchaseorderid = default(int);
	
		protected byte revisionnumber = default(byte);
	
		protected byte status = default(byte);
	
		protected int employeeid = default(int);
	
		protected int vendorid = default(int);
	
		protected int shipmethodid = default(int);
	
		protected System.DateTime orderdate = default(System.DateTime);
	
		protected System.DateTime? shipdate = default(System.DateTime?);
	
		protected decimal subtotal = default(decimal);
	
		protected decimal taxamt = default(decimal);
	
		protected decimal freight = default(decimal);
	
		protected decimal totaldue = default(decimal);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected Employee employeeEntity;
	
		protected ShipMethod shipMethodEntity;
	
		protected Vendor vendorEntity;
	
        protected EntityCollection< PurchaseOrderDetail> purchaseOrderDetails ;
        
        #endregion

 		#region Properties	

        [Column( COL_PURCHASEORDERID, PARAM_PURCHASEORDERID, default(int))]
                              public virtual int PurchaseOrderID 
        {
            get { return this.purchaseorderid; }
			set	{ 
                  if(this.purchaseorderid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("PurchaseOrderID"));  
                        this.purchaseorderid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("PurchaseOrderID"));
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
		
        [Column( COL_EMPLOYEEID, PARAM_EMPLOYEEID, default(int))]
                              public virtual int EmployeeID                
        {
            get
            {
                if(this.employeeEntity == null)
                    return this.employeeid ;
                
                return this.employeeEntity.BusinessEntityID;            
            }
            set
            {
                if(this.employeeid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("EmployeeID"));                    
                    this.employeeid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("EmployeeID"));
                    
                    this.employeeEntity = null;
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
        
        [Column( COL_VENDORID, PARAM_VENDORID, default(int))]
                              public virtual int VendorID                
        {
            get
            {
                if(this.vendorEntity == null)
                    return this.vendorid ;
                
                return this.vendorEntity.BusinessEntityID;            
            }
            set
            {
                if(this.vendorid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("VendorID"));                    
                    this.vendorid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("VendorID"));
                    
                    this.vendorEntity = null;
                }                
            }          
        }	
        
        public Employee EmployeeEntity
        {
            get { 
                    if(this.employeeEntity == null
                       && this.employeeid != default(int)) 
                    {
                        Employee employeeQuery = new Employee {
                                                        BusinessEntityID = this.employeeid  
                                                        };
                        
                        Employee[]  employees = employeeQuery.ToList();                        
                        if(employees.Length == 1)
                            this.employeeEntity = employees[0];                        
                    }
                    
                    return this.employeeEntity; 
                }
			set	{ 
                  if(this.employeeEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("EmployeeEntity"));
                        if (this.employeeEntity != null)
                            this.Parents.Remove(this.employeeEntity);                            
                        
                        if((this.employeeEntity = value) != null) 
                            this.Parents.Add(this.employeeEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("EmployeeEntity"));
                        
                        this.employeeid = this.EmployeeEntity.BusinessEntityID;
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
		
        public Vendor VendorEntity
        {
            get { 
                    if(this.vendorEntity == null
                       && this.vendorid != default(int)) 
                    {
                        Vendor vendorQuery = new Vendor {
                                                        BusinessEntityID = this.vendorid  
                                                        };
                        
                        Vendor[]  vendors = vendorQuery.ToList();                        
                        if(vendors.Length == 1)
                            this.vendorEntity = vendors[0];                        
                    }
                    
                    return this.vendorEntity; 
                }
			set	{ 
                  if(this.vendorEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("VendorEntity"));
                        if (this.vendorEntity != null)
                            this.Parents.Remove(this.vendorEntity);                            
                        
                        if((this.vendorEntity = value) != null) 
                            this.Parents.Add(this.vendorEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("VendorEntity"));
                        
                        this.vendorid = this.VendorEntity.BusinessEntityID;
                    }   
                }
        }	
		
        public EntityCollection< PurchaseOrderDetail> PurchaseOrderDetails 
        {
            get { return this.purchaseOrderDetails;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public PurchaseOrderHeader()
        {
             this.purchaseOrderDetails = new EntityCollection< PurchaseOrderDetail>(this, new Associate< PurchaseOrderDetail>(this.AssociatePurchaseOrderDetails), new DeAssociate< PurchaseOrderDetail>(this.DeAssociatePurchaseOrderDetails), new GetChildren< PurchaseOrderDetail>(this.GetChildrenPurchaseOrderDetails));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.purchaseorderid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            PurchaseOrderHeader entity = obj as PurchaseOrderHeader;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.PurchaseOrderID == entity.PurchaseOrderID
                        && this.PurchaseOrderID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.purchaseorderid = (int)reader[COL_PURCHASEORDERID];
			this.revisionnumber = (byte)reader[COL_REVISIONNUMBER];
			this.status = (byte)reader[COL_STATUS];
			this.employeeid = (int)reader[COL_EMPLOYEEID];
			this.vendorid = (int)reader[COL_VENDORID];
			this.shipmethodid = (int)reader[COL_SHIPMETHODID];
			this.orderdate = (System.DateTime)reader[COL_ORDERDATE];
			this.shipdate = DbConvert.ToNullable< System.DateTime >(reader[COL_SHIPDATE]);
			this.subtotal = (decimal)reader[COL_SUBTOTAL];
			this.taxamt = (decimal)reader[COL_TAXAMT];
			this.freight = (decimal)reader[COL_FREIGHT];
			this.totaldue = (decimal)reader[COL_TOTALDUE];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
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
                this.PurchaseOrderID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
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
        
        #region Entity Relationship Functions
        
        private void AssociatePurchaseOrderDetails(PurchaseOrderDetail purchaseOrderDetail)
        {
           purchaseOrderDetail.PurchaseOrderHeaderEntity = this;
        }
        
        private void DeAssociatePurchaseOrderDetails(PurchaseOrderDetail purchaseOrderDetail)
        {
          if(purchaseOrderDetail.PurchaseOrderHeaderEntity == this)
             purchaseOrderDetail.PurchaseOrderHeaderEntity = null;
        }
        
        private PurchaseOrderDetail[] GetChildrenPurchaseOrderDetails()
        {
            PurchaseOrderDetail childrenQuery = new PurchaseOrderDetail();
            childrenQuery.PurchaseOrderHeaderEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
