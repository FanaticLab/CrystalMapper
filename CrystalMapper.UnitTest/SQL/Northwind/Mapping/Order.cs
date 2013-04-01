/*********************************************************************
 * Author: CrystalMapper (Generated)
 * Date:  Monday, April 01, 2013 7:10 PM
 * Project: http://crystalmapper.codeplex.com
 * Copyright (c) 2013 FanaticLab
 *********************************************************************/

using System;
using System.Linq;
using System.Data.Common;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;

using CoreSystem.Data;

using CrystalMapper;
using CrystalMapper.Linq;
using CrystalMapper.Context;
using CrystalMapper.Mapping;

namespace CrystalMapper.UnitTest.SQL.Northwind
{
	[Table(TABLE_NAME)]
    public partial class Order : IRecord, INotifyPropertyChanging, INotifyPropertyChanged
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "dbo.Orders";	
     
		public const string COL_ORDERID = "OrderID";
		public const string COL_CUSTOMERID = "CustomerID";
		public const string COL_EMPLOYEEID = "EmployeeID";
		public const string COL_ORDERDATE = "OrderDate";
		public const string COL_REQUIREDDATE = "RequiredDate";
		public const string COL_SHIPPEDDATE = "ShippedDate";
		public const string COL_SHIPVIA = "ShipVia";
		public const string COL_FREIGHT = "Freight";
		public const string COL_SHIPNAME = "ShipName";
		public const string COL_SHIPADDRESS = "ShipAddress";
		public const string COL_SHIPCITY = "ShipCity";
		public const string COL_SHIPREGION = "ShipRegion";
		public const string COL_SHIPPOSTALCODE = "ShipPostalCode";
		public const string COL_SHIPCOUNTRY = "ShipCountry";
		
        public const string PARAM_ORDERID = "@OrderID";	
        public const string PARAM_CUSTOMERID = "@CustomerID";	
        public const string PARAM_EMPLOYEEID = "@EmployeeID";	
        public const string PARAM_ORDERDATE = "@OrderDate";	
        public const string PARAM_REQUIREDDATE = "@RequiredDate";	
        public const string PARAM_SHIPPEDDATE = "@ShippedDate";	
        public const string PARAM_SHIPVIA = "@ShipVia";	
        public const string PARAM_FREIGHT = "@Freight";	
        public const string PARAM_SHIPNAME = "@ShipName";	
        public const string PARAM_SHIPADDRESS = "@ShipAddress";	
        public const string PARAM_SHIPCITY = "@ShipCity";	
        public const string PARAM_SHIPREGION = "@ShipRegion";	
        public const string PARAM_SHIPPOSTALCODE = "@ShipPostalCode";	
        public const string PARAM_SHIPCOUNTRY = "@ShipCountry";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_ORDERS = "INSERT INTO dbo.Orders (CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry) VALUES ( @CustomerID, @EmployeeID, @OrderDate, @RequiredDate, @ShippedDate, @ShipVia, @Freight, @ShipName, @ShipAddress, @ShipCity, @ShipRegion, @ShipPostalCode, @ShipCountry);"   + " SELECT SCOPE_IDENTITY();" ;
		
		private const string SQL_UPDATE_ORDERS = "UPDATE dbo.Orders SETCustomerID = @CustomerID, EmployeeID = @EmployeeID, OrderDate = @OrderDate, RequiredDate = @RequiredDate, ShippedDate = @ShippedDate, ShipVia = @ShipVia, Freight = @Freight, ShipName = @ShipName, ShipAddress = @ShipAddress, ShipCity = @ShipCity, ShipRegion = @ShipRegion, ShipPostalCode = @ShipPostalCode, ShipCountry = @ShipCountry WHERE OrderID = @OrderID";
		
		private const string SQL_DELETE_ORDERS = "DELETE FROM dbo.Orders WHERE  OrderID = @OrderID ";
		
        #endregion
        	  	
        #region Declarations

		protected int orderid = default(int);
	
		protected string customerid = default(string);
	
		protected int? employeeid = default(int?);
	
		protected System.DateTime? orderdate = default(System.DateTime?);
	
		protected System.DateTime? requireddate = default(System.DateTime?);
	
		protected System.DateTime? shippeddate = default(System.DateTime?);
	
		protected int? shipvium = default(int?);
	
		protected decimal? freight = default(decimal?);
	
		protected string shipname = default(string);
	
		protected string shipaddress = default(string);
	
		protected string shipcity = default(string);
	
		protected string shipregion = default(string);
	
		protected string shippostalcode = default(string);
	
		protected string shipcountry = default(string);
	
		protected Customer customerRef;
	
		protected Employee employeeRef;
	
		protected Shipper shipperRef;
	
        
        private event PropertyChangingEventHandler propertyChanging;
        
        private event PropertyChangedEventHandler propertyChanged;
        #endregion

 		#region Properties
        
        event PropertyChangingEventHandler INotifyPropertyChanging.PropertyChanging
        {
            add { this.propertyChanging += value; }
            remove { this.propertyChanging -= value; }
        }
        
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        { 
            add { this.propertyChanged += value; }
            remove { this.propertyChanged -= value; }
        }
        
        IQueryProvider IRecord.Provider { get; set; }

        [Column(COL_ORDERID, PARAM_ORDERID, default(int))]
        public virtual int OrderID 
        {
            get { return this.orderid; }
			set	{ 
                  if(this.orderid != value)
                    {
                        this.OnPropertyChanging("OrderID");  
                        this.orderid = value;                        
                        this.OnPropertyChanged("OrderID");
                    }   
                }
        }	
		
        [Column(COL_ORDERDATE, PARAM_ORDERDATE )]
        public virtual System.DateTime? OrderDate 
        {
            get { return this.orderdate; }
			set	{ 
                  if(this.orderdate != value)
                    {
                        this.OnPropertyChanging("OrderDate");  
                        this.orderdate = value;                        
                        this.OnPropertyChanged("OrderDate");
                    }   
                }
        }	
		
        [Column(COL_REQUIREDDATE, PARAM_REQUIREDDATE )]
        public virtual System.DateTime? RequiredDate 
        {
            get { return this.requireddate; }
			set	{ 
                  if(this.requireddate != value)
                    {
                        this.OnPropertyChanging("RequiredDate");  
                        this.requireddate = value;                        
                        this.OnPropertyChanged("RequiredDate");
                    }   
                }
        }	
		
        [Column(COL_SHIPPEDDATE, PARAM_SHIPPEDDATE )]
        public virtual System.DateTime? ShippedDate 
        {
            get { return this.shippeddate; }
			set	{ 
                  if(this.shippeddate != value)
                    {
                        this.OnPropertyChanging("ShippedDate");  
                        this.shippeddate = value;                        
                        this.OnPropertyChanged("ShippedDate");
                    }   
                }
        }	
		
        [Column(COL_FREIGHT, PARAM_FREIGHT )]
        public virtual decimal? Freight 
        {
            get { return this.freight; }
			set	{ 
                  if(this.freight != value)
                    {
                        this.OnPropertyChanging("Freight");  
                        this.freight = value;                        
                        this.OnPropertyChanged("Freight");
                    }   
                }
        }	
		
        [Column(COL_SHIPNAME, PARAM_SHIPNAME )]
        public virtual string ShipName 
        {
            get { return this.shipname; }
			set	{ 
                  if(this.shipname != value)
                    {
                        this.OnPropertyChanging("ShipName");  
                        this.shipname = value;                        
                        this.OnPropertyChanged("ShipName");
                    }   
                }
        }	
		
        [Column(COL_SHIPADDRESS, PARAM_SHIPADDRESS )]
        public virtual string ShipAddress 
        {
            get { return this.shipaddress; }
			set	{ 
                  if(this.shipaddress != value)
                    {
                        this.OnPropertyChanging("ShipAddress");  
                        this.shipaddress = value;                        
                        this.OnPropertyChanged("ShipAddress");
                    }   
                }
        }	
		
        [Column(COL_SHIPCITY, PARAM_SHIPCITY )]
        public virtual string ShipCity 
        {
            get { return this.shipcity; }
			set	{ 
                  if(this.shipcity != value)
                    {
                        this.OnPropertyChanging("ShipCity");  
                        this.shipcity = value;                        
                        this.OnPropertyChanged("ShipCity");
                    }   
                }
        }	
		
        [Column(COL_SHIPREGION, PARAM_SHIPREGION )]
        public virtual string ShipRegion 
        {
            get { return this.shipregion; }
			set	{ 
                  if(this.shipregion != value)
                    {
                        this.OnPropertyChanging("ShipRegion");  
                        this.shipregion = value;                        
                        this.OnPropertyChanged("ShipRegion");
                    }   
                }
        }	
		
        [Column(COL_SHIPPOSTALCODE, PARAM_SHIPPOSTALCODE )]
        public virtual string ShipPostalCode 
        {
            get { return this.shippostalcode; }
			set	{ 
                  if(this.shippostalcode != value)
                    {
                        this.OnPropertyChanging("ShipPostalCode");  
                        this.shippostalcode = value;                        
                        this.OnPropertyChanged("ShipPostalCode");
                    }   
                }
        }	
		
        [Column(COL_SHIPCOUNTRY, PARAM_SHIPCOUNTRY )]
        public virtual string ShipCountry 
        {
            get { return this.shipcountry; }
			set	{ 
                  if(this.shipcountry != value)
                    {
                        this.OnPropertyChanging("ShipCountry");  
                        this.shipcountry = value;                        
                        this.OnPropertyChanged("ShipCountry");
                    }   
                }
        }	
		
        [Column(COL_CUSTOMERID, PARAM_CUSTOMERID )]
        public virtual string CustomerID                
        {
            get
            {
                if(this.customerRef == null)
                    return this.customerid ;
                
                return this.customerRef.CustomerID;            
            }
            set
            {
                if(this.customerid != value)
                {
                    this.OnPropertyChanging("CustomerID");                    
                    this.customerid = value;                    
                    this.OnPropertyChanged("CustomerID");
                    
                    this.customerRef = null;
                }                
            }          
        }	
        
        [Column(COL_EMPLOYEEID, PARAM_EMPLOYEEID )]
        public virtual int? EmployeeID                
        {
            get
            {
                if(this.employeeRef == null)
                    return this.employeeid ;
                
                return this.employeeRef.EmployeeID;            
            }
            set
            {
                if(this.employeeid != value)
                {
                    this.OnPropertyChanging("EmployeeID");                    
                    this.employeeid = value;                    
                    this.OnPropertyChanged("EmployeeID");
                    
                    this.employeeRef = null;
                }                
            }          
        }	
        
        [Column(COL_SHIPVIA, PARAM_SHIPVIA )]
        public virtual int? ShipVia                
        {
            get
            {
                if(this.shipperRef == null)
                    return this.shipvium ;
                
                return this.shipperRef.ShipperID;            
            }
            set
            {
                if(this.shipvium != value)
                {
                    this.OnPropertyChanging("ShipVia");                    
                    this.shipvium = value;                    
                    this.OnPropertyChanged("ShipVia");
                    
                    this.shipperRef = null;
                }                
            }          
        }	
        
        public Customer CustomerRef
        {
            get 
            { 
                if(this.customerRef == null)
                    this.customerRef = this.CreateQuery<Customer>().First(p => p.CustomerID == this.CustomerID);                    
                
                return this.customerRef; 
            }
			set	
            { 
                if(this.customerRef != value)
                {
                    this.OnPropertyChanging("CustomerRef");
                    
                    this.customerid = (this.customerRef = value) != null ? this.customerRef.CustomerID : default(string);                  
                    
                    this.OnPropertyChanged("CustomerRef");
                }   
            }
        }	
		
        public Employee EmployeeRef
        {
            get 
            { 
                if(this.employeeRef == null)
                    this.employeeRef = this.CreateQuery<Employee>().First(p => p.EmployeeID == this.EmployeeID);                    
                
                return this.employeeRef; 
            }
			set	
            { 
                if(this.employeeRef != value)
                {
                    this.OnPropertyChanging("EmployeeRef");
                    
                    this.employeeid = (this.employeeRef = value) != null ? this.employeeRef.EmployeeID : default(int);                  
                    
                    this.OnPropertyChanged("EmployeeRef");
                }   
            }
        }	
		
        public Shipper ShipperRef
        {
            get 
            { 
                if(this.shipperRef == null)
                    this.shipperRef = this.CreateQuery<Shipper>().First(p => p.ShipperID == this.ShipVia);                    
                
                return this.shipperRef; 
            }
			set	
            { 
                if(this.shipperRef != value)
                {
                    this.OnPropertyChanging("ShipperRef");
                    
                    this.shipvium = (this.shipperRef = value) != null ? this.shipperRef.ShipperID : default(int);                  
                    
                    this.OnPropertyChanged("ShipperRef");
                }   
            }
        }	
		
        public IQueryable<OrderDetail> OrderDetails 
        {
            get { return this.CreateQuery<OrderDetail>().Where(r => r.OrderID == OrderID); }
        }
       
        #endregion        
        
        #region Methods
        
        public override bool Equals(object obj)
        {
            Order record = obj as Order;           
            
            return (object.ReferenceEquals(this, record)                    
                    || (record != null            
                        && this.OrderID == record.OrderID
                        && this.OrderID != default(int)
                        )
                    );           
        }
        
        public override int GetHashCode()
        {            
            int hashCode = 7;
            
            hashCode = (11 * hashCode) + this.orderid.GetHashCode();
                        
            return hashCode;          
        }
        
		void IRecord.Read(DbDataReader reader)
		{       
			this.orderid = (int)reader[COL_ORDERID];
			this.customerid = DbConvert.ToString(reader[COL_CUSTOMERID]);
			this.employeeid = DbConvert.ToNullable< int >(reader[COL_EMPLOYEEID]);
			this.orderdate = DbConvert.ToNullable< System.DateTime >(reader[COL_ORDERDATE]);
			this.requireddate = DbConvert.ToNullable< System.DateTime >(reader[COL_REQUIREDDATE]);
			this.shippeddate = DbConvert.ToNullable< System.DateTime >(reader[COL_SHIPPEDDATE]);
			this.shipvium = DbConvert.ToNullable< int >(reader[COL_SHIPVIA]);
			this.freight = DbConvert.ToNullable< decimal >(reader[COL_FREIGHT]);
			this.shipname = DbConvert.ToString(reader[COL_SHIPNAME]);
			this.shipaddress = DbConvert.ToString(reader[COL_SHIPADDRESS]);
			this.shipcity = DbConvert.ToString(reader[COL_SHIPCITY]);
			this.shipregion = DbConvert.ToString(reader[COL_SHIPREGION]);
			this.shippostalcode = DbConvert.ToString(reader[COL_SHIPPOSTALCODE]);
			this.shipcountry = DbConvert.ToString(reader[COL_SHIPCOUNTRY]);
		}
		
		bool IRecord.Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_ORDERS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CUSTOMERID, DbConvert.DbValue(this.CustomerID)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_EMPLOYEEID, DbConvert.DbValue(this.EmployeeID)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_ORDERDATE, DbConvert.DbValue(this.OrderDate)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_REQUIREDDATE, DbConvert.DbValue(this.RequiredDate)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_SHIPPEDDATE, DbConvert.DbValue(this.ShippedDate)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_SHIPVIA, DbConvert.DbValue(this.ShipVia)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_FREIGHT, DbConvert.DbValue(this.Freight)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_SHIPNAME, DbConvert.DbValue(this.ShipName)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_SHIPADDRESS, DbConvert.DbValue(this.ShipAddress)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_SHIPCITY, DbConvert.DbValue(this.ShipCity)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_SHIPREGION, DbConvert.DbValue(this.ShipRegion)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_SHIPPOSTALCODE, DbConvert.DbValue(this.ShipPostalCode)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_SHIPCOUNTRY, DbConvert.DbValue(this.ShipCountry)));
                this.OrderID = Convert.ToInt32(command.ExecuteScalar());
                return true;
            }
        }

		bool IRecord.Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_ORDERS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_ORDERID, this.OrderID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CUSTOMERID, DbConvert.DbValue(this.CustomerID)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_EMPLOYEEID, DbConvert.DbValue(this.EmployeeID)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_ORDERDATE, DbConvert.DbValue(this.OrderDate)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_REQUIREDDATE, DbConvert.DbValue(this.RequiredDate)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_SHIPPEDDATE, DbConvert.DbValue(this.ShippedDate)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_SHIPVIA, DbConvert.DbValue(this.ShipVia)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_FREIGHT, DbConvert.DbValue(this.Freight)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_SHIPNAME, DbConvert.DbValue(this.ShipName)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_SHIPADDRESS, DbConvert.DbValue(this.ShipAddress)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_SHIPCITY, DbConvert.DbValue(this.ShipCity)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_SHIPREGION, DbConvert.DbValue(this.ShipRegion)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_SHIPPOSTALCODE, DbConvert.DbValue(this.ShipPostalCode)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_SHIPCOUNTRY, DbConvert.DbValue(this.ShipCountry)));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		bool IRecord.Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_ORDERS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_ORDERID, this.OrderID));
                return (command.ExecuteNonQuery() == 1);
            }
        }
        
        protected virtual void OnPropertyChanging(string propertyName)
        {
            if(this.propertyChanging != null)
                this.propertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if(this.propertyChanged != null)
                this.propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}