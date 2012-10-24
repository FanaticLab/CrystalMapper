/*
 * Author: CrystalMapper 
 * 
 * Date:  Saturday, September 22, 2012 8:42 PM
 * 
 * Class: Supplier
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
using CrystalMapper.Generic;

namespace CrystalMapper.UnitTest.Northwind
{
	[Table(TABLE_NAME)]
    public partial class Supplier : Entity< Supplier>  
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
	
        #endregion

 		#region Properties	

        [Column( COL_SUPPLIERID, PARAM_SUPPLIERID, default(int))]
                              public virtual int SupplierID 
        {
            get { return this.supplierid; }
			set	{ 
                  if(this.supplierid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SupplierID"));  
                        this.supplierid = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SupplierID"));
                    }   
                }
        }	
		
        [Column( COL_COMPANYNAME, PARAM_COMPANYNAME )]
                              public virtual string CompanyName 
        {
            get { return this.companyname; }
			set	{ 
                  if(this.companyname != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CompanyName"));  
                        this.companyname = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CompanyName"));
                    }   
                }
        }	
		
        [Column( COL_CONTACTNAME, PARAM_CONTACTNAME )]
                              public virtual string ContactName 
        {
            get { return this.contactname; }
			set	{ 
                  if(this.contactname != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ContactName"));  
                        this.contactname = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ContactName"));
                    }   
                }
        }	
		
        [Column( COL_CONTACTTITLE, PARAM_CONTACTTITLE )]
                              public virtual string ContactTitle 
        {
            get { return this.contacttitle; }
			set	{ 
                  if(this.contacttitle != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ContactTitle"));  
                        this.contacttitle = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ContactTitle"));
                    }   
                }
        }	
		
        [Column( COL_ADDRESS, PARAM_ADDRESS )]
                              public virtual string Address 
        {
            get { return this.address; }
			set	{ 
                  if(this.address != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Address"));  
                        this.address = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Address"));
                    }   
                }
        }	
		
        [Column( COL_CITY, PARAM_CITY )]
                              public virtual string City 
        {
            get { return this.city; }
			set	{ 
                  if(this.city != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("City"));  
                        this.city = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("City"));
                    }   
                }
        }	
		
        [Column( COL_REGION, PARAM_REGION )]
                              public virtual string Region 
        {
            get { return this.region; }
			set	{ 
                  if(this.region != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Region"));  
                        this.region = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Region"));
                    }   
                }
        }	
		
        [Column( COL_POSTALCODE, PARAM_POSTALCODE )]
                              public virtual string PostalCode 
        {
            get { return this.postalcode; }
			set	{ 
                  if(this.postalcode != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("PostalCode"));  
                        this.postalcode = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("PostalCode"));
                    }   
                }
        }	
		
        [Column( COL_COUNTRY, PARAM_COUNTRY )]
                              public virtual string Country 
        {
            get { return this.country; }
			set	{ 
                  if(this.country != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Country"));  
                        this.country = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Country"));
                    }   
                }
        }	
		
        [Column( COL_PHONE, PARAM_PHONE )]
                              public virtual string Phone 
        {
            get { return this.phone; }
			set	{ 
                  if(this.phone != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Phone"));  
                        this.phone = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Phone"));
                    }   
                }
        }	
		
        [Column( COL_FAX, PARAM_FAX )]
                              public virtual string Fax 
        {
            get { return this.fax; }
			set	{ 
                  if(this.fax != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Fax"));  
                        this.fax = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Fax"));
                    }   
                }
        }	
		
        [Column( COL_HOMEPAGE, PARAM_HOMEPAGE )]
                              public virtual string HomePage 
        {
            get { return this.homepage; }
			set	{ 
                  if(this.homepage != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("HomePage"));  
                        this.homepage = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("HomePage"));
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
        
        public override bool Equals(object obj)
        {
            Supplier entity = obj as Supplier;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.SupplierID == entity.SupplierID
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
        
		public override void Read(DbDataReader reader)
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
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SUPPLIERS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.CompanyName, PARAM_COMPANYNAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ContactName), PARAM_CONTACTNAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ContactTitle), PARAM_CONTACTTITLE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Address), PARAM_ADDRESS));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.City), PARAM_CITY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Region), PARAM_REGION));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.PostalCode), PARAM_POSTALCODE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Country), PARAM_COUNTRY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Phone), PARAM_PHONE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Fax), PARAM_FAX));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.HomePage), PARAM_HOMEPAGE));
                this.SupplierID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SUPPLIERS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SupplierID, PARAM_SUPPLIERID));
				command.Parameters.Add(dataContext.CreateParameter(this.CompanyName, PARAM_COMPANYNAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ContactName), PARAM_CONTACTNAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ContactTitle), PARAM_CONTACTTITLE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Address), PARAM_ADDRESS));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.City), PARAM_CITY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Region), PARAM_REGION));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.PostalCode), PARAM_POSTALCODE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Country), PARAM_COUNTRY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Phone), PARAM_PHONE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Fax), PARAM_FAX));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.HomePage), PARAM_HOMEPAGE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SUPPLIERS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SupplierID, PARAM_SUPPLIERID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
    }
}
