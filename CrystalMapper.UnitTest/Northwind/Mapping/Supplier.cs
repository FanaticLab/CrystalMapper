/*********************************************************************
 * Author: CrystalMapper (Generated)
 * Date:  Saturday, March 30, 2013 6:00 PM
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

namespace CrystalMapper.UnitTest.Northwind
{
	[Table(TABLE_NAME)]
    public partial class Supplier : IRecord, INotifyPropertyChanging, INotifyPropertyChanged
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "dbo.Suppliers";	
     
		public const string COL_SUPPLIERID = "SupplierID";
		public const string COL_COMPANYNAME = "CompanyName";
		public const string COL_CONTACTNAME = "ContactName";
		public const string COL_CONTACTTITLE = "ContactTitle";
		public const string COL_ADDRESS = "Address";
		public const string COL_CITY = "City";
		public const string COL_REGION = "Region";
		public const string COL_POSTALCODE = "PostalCode";
		public const string COL_COUNTRY = "Country";
		public const string COL_PHONE = "Phone";
		public const string COL_FAX = "Fax";
		public const string COL_HOMEPAGE = "HomePage";
		
        public const string PARAM_SUPPLIERID = "@SupplierID";	
        public const string PARAM_COMPANYNAME = "@CompanyName";	
        public const string PARAM_CONTACTNAME = "@ContactName";	
        public const string PARAM_CONTACTTITLE = "@ContactTitle";	
        public const string PARAM_ADDRESS = "@Address";	
        public const string PARAM_CITY = "@City";	
        public const string PARAM_REGION = "@Region";	
        public const string PARAM_POSTALCODE = "@PostalCode";	
        public const string PARAM_COUNTRY = "@Country";	
        public const string PARAM_PHONE = "@Phone";	
        public const string PARAM_FAX = "@Fax";	
        public const string PARAM_HOMEPAGE = "@HomePage";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SUPPLIERS = "INSERT INTO dbo.Suppliers ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [HomePage]) VALUES ( @CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax, @HomePage);"   + " SELECT SCOPE_IDENTITY();" ;
		
		private const string SQL_UPDATE_SUPPLIERS = "UPDATE dbo.Suppliers SET [CompanyName] = @CompanyName, [ContactName] = @ContactName, [ContactTitle] = @ContactTitle, [Address] = @Address, [City] = @City, [Region] = @Region, [PostalCode] = @PostalCode, [Country] = @Country, [Phone] = @Phone, [Fax] = @Fax, [HomePage] = @HomePage WHERE [SupplierID] = @SupplierID";
		
		private const string SQL_DELETE_SUPPLIERS = "DELETE FROM dbo.Suppliers WHERE  [SupplierID] = @SupplierID ";
		
        #endregion
        	  	
        #region Declarations

		protected int supplierid = default(int);
	
		protected string companyname = default(string);
	
		protected string contactname = default(string);
	
		protected string contacttitle = default(string);
	
		protected string address = default(string);
	
		protected string city = default(string);
	
		protected string region = default(string);
	
		protected string postalcode = default(string);
	
		protected string country = default(string);
	
		protected string phone = default(string);
	
		protected string fax = default(string);
	
		protected string homepage = default(string);
	
        
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

        [Column(COL_SUPPLIERID, PARAM_SUPPLIERID, default(int))]
        public virtual int SupplierID 
        {
            get { return this.supplierid; }
			set	{ 
                  if(this.supplierid != value)
                    {
                        this.OnPropertyChanging("SupplierID");  
                        this.supplierid = value;                        
                        this.OnPropertyChanged("SupplierID");
                    }   
                }
        }	
		
        [Column(COL_COMPANYNAME, PARAM_COMPANYNAME )]
        public virtual string CompanyName 
        {
            get { return this.companyname; }
			set	{ 
                  if(this.companyname != value)
                    {
                        this.OnPropertyChanging("CompanyName");  
                        this.companyname = value;                        
                        this.OnPropertyChanged("CompanyName");
                    }   
                }
        }	
		
        [Column(COL_CONTACTNAME, PARAM_CONTACTNAME )]
        public virtual string ContactName 
        {
            get { return this.contactname; }
			set	{ 
                  if(this.contactname != value)
                    {
                        this.OnPropertyChanging("ContactName");  
                        this.contactname = value;                        
                        this.OnPropertyChanged("ContactName");
                    }   
                }
        }	
		
        [Column(COL_CONTACTTITLE, PARAM_CONTACTTITLE )]
        public virtual string ContactTitle 
        {
            get { return this.contacttitle; }
			set	{ 
                  if(this.contacttitle != value)
                    {
                        this.OnPropertyChanging("ContactTitle");  
                        this.contacttitle = value;                        
                        this.OnPropertyChanged("ContactTitle");
                    }   
                }
        }	
		
        [Column(COL_ADDRESS, PARAM_ADDRESS )]
        public virtual string Address 
        {
            get { return this.address; }
			set	{ 
                  if(this.address != value)
                    {
                        this.OnPropertyChanging("Address");  
                        this.address = value;                        
                        this.OnPropertyChanged("Address");
                    }   
                }
        }	
		
        [Column(COL_CITY, PARAM_CITY )]
        public virtual string City 
        {
            get { return this.city; }
			set	{ 
                  if(this.city != value)
                    {
                        this.OnPropertyChanging("City");  
                        this.city = value;                        
                        this.OnPropertyChanged("City");
                    }   
                }
        }	
		
        [Column(COL_REGION, PARAM_REGION )]
        public virtual string Region 
        {
            get { return this.region; }
			set	{ 
                  if(this.region != value)
                    {
                        this.OnPropertyChanging("Region");  
                        this.region = value;                        
                        this.OnPropertyChanged("Region");
                    }   
                }
        }	
		
        [Column(COL_POSTALCODE, PARAM_POSTALCODE )]
        public virtual string PostalCode 
        {
            get { return this.postalcode; }
			set	{ 
                  if(this.postalcode != value)
                    {
                        this.OnPropertyChanging("PostalCode");  
                        this.postalcode = value;                        
                        this.OnPropertyChanged("PostalCode");
                    }   
                }
        }	
		
        [Column(COL_COUNTRY, PARAM_COUNTRY )]
        public virtual string Country 
        {
            get { return this.country; }
			set	{ 
                  if(this.country != value)
                    {
                        this.OnPropertyChanging("Country");  
                        this.country = value;                        
                        this.OnPropertyChanged("Country");
                    }   
                }
        }	
		
        [Column(COL_PHONE, PARAM_PHONE )]
        public virtual string Phone 
        {
            get { return this.phone; }
			set	{ 
                  if(this.phone != value)
                    {
                        this.OnPropertyChanging("Phone");  
                        this.phone = value;                        
                        this.OnPropertyChanged("Phone");
                    }   
                }
        }	
		
        [Column(COL_FAX, PARAM_FAX )]
        public virtual string Fax 
        {
            get { return this.fax; }
			set	{ 
                  if(this.fax != value)
                    {
                        this.OnPropertyChanging("Fax");  
                        this.fax = value;                        
                        this.OnPropertyChanged("Fax");
                    }   
                }
        }	
		
        [Column(COL_HOMEPAGE, PARAM_HOMEPAGE )]
        public virtual string HomePage 
        {
            get { return this.homepage; }
			set	{ 
                  if(this.homepage != value)
                    {
                        this.OnPropertyChanging("HomePage");  
                        this.homepage = value;                        
                        this.OnPropertyChanged("HomePage");
                    }   
                }
        }	
		
        public IQueryable<Product> Products 
        {
            get { return this.CreateQuery<Product>().Where(r => r.SupplierID == SupplierID); }
        }
       
        #endregion        
        
        #region Methods
        
        public override bool Equals(object obj)
        {
            Supplier record = obj as Supplier;           
            
            return (object.ReferenceEquals(this, record)                    
                    || (record != null            
                        && this.SupplierID == record.SupplierID
                        && this.SupplierID != default(int)
                        )
                    );           
        }
        
        public override int GetHashCode()
        {            
            int hashCode = 7;
            
            hashCode = (11 * hashCode) + this.supplierid.GetHashCode();
                        
            return hashCode;          
        }
        
		void IRecord.Read(DbDataReader reader)
		{       
			this.supplierid = (int)reader[COL_SUPPLIERID];
			this.companyname = (string)reader[COL_COMPANYNAME];
			this.contactname = DbConvert.ToString(reader[COL_CONTACTNAME]);
			this.contacttitle = DbConvert.ToString(reader[COL_CONTACTTITLE]);
			this.address = DbConvert.ToString(reader[COL_ADDRESS]);
			this.city = DbConvert.ToString(reader[COL_CITY]);
			this.region = DbConvert.ToString(reader[COL_REGION]);
			this.postalcode = DbConvert.ToString(reader[COL_POSTALCODE]);
			this.country = DbConvert.ToString(reader[COL_COUNTRY]);
			this.phone = DbConvert.ToString(reader[COL_PHONE]);
			this.fax = DbConvert.ToString(reader[COL_FAX]);
			this.homepage = DbConvert.ToString(reader[COL_HOMEPAGE]);
		}
		
		bool IRecord.Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SUPPLIERS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(PARAM_COMPANYNAME, this.CompanyName));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CONTACTNAME, DbConvert.DbValue(this.ContactName)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CONTACTTITLE, DbConvert.DbValue(this.ContactTitle)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_ADDRESS, DbConvert.DbValue(this.Address)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CITY, DbConvert.DbValue(this.City)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_REGION, DbConvert.DbValue(this.Region)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_POSTALCODE, DbConvert.DbValue(this.PostalCode)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_COUNTRY, DbConvert.DbValue(this.Country)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_PHONE, DbConvert.DbValue(this.Phone)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_FAX, DbConvert.DbValue(this.Fax)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_HOMEPAGE, DbConvert.DbValue(this.HomePage)));
                this.SupplierID = Convert.ToInt32(command.ExecuteScalar());
                return true;
            }
        }

		bool IRecord.Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SUPPLIERS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_SUPPLIERID, this.SupplierID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_COMPANYNAME, this.CompanyName));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CONTACTNAME, DbConvert.DbValue(this.ContactName)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CONTACTTITLE, DbConvert.DbValue(this.ContactTitle)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_ADDRESS, DbConvert.DbValue(this.Address)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CITY, DbConvert.DbValue(this.City)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_REGION, DbConvert.DbValue(this.Region)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_POSTALCODE, DbConvert.DbValue(this.PostalCode)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_COUNTRY, DbConvert.DbValue(this.Country)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_PHONE, DbConvert.DbValue(this.Phone)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_FAX, DbConvert.DbValue(this.Fax)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_HOMEPAGE, DbConvert.DbValue(this.HomePage)));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		bool IRecord.Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SUPPLIERS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_SUPPLIERID, this.SupplierID));
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