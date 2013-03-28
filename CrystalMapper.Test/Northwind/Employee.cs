/*
 * Author: CrystalMapper (Generated)
 * 
 * Date:  Thursday, March 28, 2013 7:07 PM
 * 
 * Class: Employee
 * 
 * Email: info@fanaticlab.com
 * 
 * Project: http://crystalmapper.codeplex.com
 *
 * Copyright (c) 2013 FanaticLab
 *
/*/

using System;
using System.Data.Common;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;

using CoreSystem.Data;

using CrystalMapper;
using CrystalMapper.Context;
using CrystalMapper.Mapping;

namespace CrystalMapper.Test.Northwind
{
	[Table(TABLE_NAME)]
    public partial class Employee : IRecord 
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "dbo.Employees";	
     
		public const string COL_EMPLOYEEID = "EmployeeID";
		public const string COL_LASTNAME = "LastName";
		public const string COL_FIRSTNAME = "FirstName";
		public const string COL_TITLE = "Title";
		public const string COL_TITLEOFCOURTESY = "TitleOfCourtesy";
		public const string COL_BIRTHDATE = "BirthDate";
		public const string COL_HIREDATE = "HireDate";
		public const string COL_ADDRESS = "Address";
		public const string COL_CITY = "City";
		public const string COL_REGION = "Region";
		public const string COL_POSTALCODE = "PostalCode";
		public const string COL_COUNTRY = "Country";
		public const string COL_HOMEPHONE = "HomePhone";
		public const string COL_EXTENSION = "Extension";
		public const string COL_PHOTO = "Photo";
		public const string COL_NOTES = "Notes";
		public const string COL_REPORTSTO = "ReportsTo";
		public const string COL_PHOTOPATH = "PhotoPath";
		
        public const string PARAM_EMPLOYEEID = "@EmployeeID";	
        public const string PARAM_LASTNAME = "@LastName";	
        public const string PARAM_FIRSTNAME = "@FirstName";	
        public const string PARAM_TITLE = "@Title";	
        public const string PARAM_TITLEOFCOURTESY = "@TitleOfCourtesy";	
        public const string PARAM_BIRTHDATE = "@BirthDate";	
        public const string PARAM_HIREDATE = "@HireDate";	
        public const string PARAM_ADDRESS = "@Address";	
        public const string PARAM_CITY = "@City";	
        public const string PARAM_REGION = "@Region";	
        public const string PARAM_POSTALCODE = "@PostalCode";	
        public const string PARAM_COUNTRY = "@Country";	
        public const string PARAM_HOMEPHONE = "@HomePhone";	
        public const string PARAM_EXTENSION = "@Extension";	
        public const string PARAM_PHOTO = "@Photo";	
        public const string PARAM_NOTES = "@Notes";	
        public const string PARAM_REPORTSTO = "@ReportsTo";	
        public const string PARAM_PHOTOPATH = "@PhotoPath";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_EMPLOYEES = "INSERT INTO dbo.Employees ( [LastName], [FirstName], [Title], [TitleOfCourtesy], [BirthDate], [HireDate], [Address], [City], [Region], [PostalCode], [Country], [HomePhone], [Extension], [Photo], [Notes], [ReportsTo], [PhotoPath]) VALUES ( @LastName, @FirstName, @Title, @TitleOfCourtesy, @BirthDate, @HireDate, @Address, @City, @Region, @PostalCode, @Country, @HomePhone, @Extension, @Photo, @Notes, @ReportsTo, @PhotoPath);"   + " SELECT SCOPE_IDENTITY();" ;
		
		private const string SQL_UPDATE_EMPLOYEES = "UPDATE dbo.Employees SET [LastName] = @LastName, [FirstName] = @FirstName, [Title] = @Title, [TitleOfCourtesy] = @TitleOfCourtesy, [BirthDate] = @BirthDate, [HireDate] = @HireDate, [Address] = @Address, [City] = @City, [Region] = @Region, [PostalCode] = @PostalCode, [Country] = @Country, [HomePhone] = @HomePhone, [Extension] = @Extension, [Photo] = @Photo, [Notes] = @Notes, [ReportsTo] = @ReportsTo, [PhotoPath] = @PhotoPath WHERE [EmployeeID] = @EmployeeID";
		
		private const string SQL_DELETE_EMPLOYEES = "DELETE FROM dbo.Employees WHERE  [EmployeeID] = @EmployeeID ";
		
        #endregion
        	  	
        #region Declarations
        
		protected int employeeid = default(int);
	
		protected string lastname = default(string);
	
		protected string firstname = default(string);
	
		protected string title = default(string);
	
		protected string titleofcourtesy = default(string);
	
		protected System.DateTime? birthdate = default(System.DateTime?);
	
		protected System.DateTime? hiredate = default(System.DateTime?);
	
		protected string address = default(string);
	
		protected string city = default(string);
	
		protected string region = default(string);
	
		protected string postalcode = default(string);
	
		protected string country = default(string);
	
		protected string homephone = default(string);
	
		protected string extension = default(string);
	
		protected byte[] photo = default(byte[]);
	
		protected string note = default(string);
	
		protected int? reportsto = default(int?);
	
		protected string photopath = default(string);
	
		protected Employee reportstoRef;
	
        #endregion

 		#region Properties	
        
        public event PropertyChangedEventHandler PropertyChanged;

        public event PropertyChangingEventHandler PropertyChanging;

        [Column(COL_EMPLOYEEID, PARAM_EMPLOYEEID, default(int))]
        public virtual int EmployeeID 
        {
            get { return this.employeeid; }
			set	{ 
                  if(this.employeeid != value)
                    {
                        this.OnPropertyChanging("EmployeeID");  
                        this.employeeid = value;                        
                        this.OnPropertyChanged("EmployeeID");
                    }   
                }
        }	
		
        [Column(COL_LASTNAME, PARAM_LASTNAME )]
        public virtual string LastName 
        {
            get { return this.lastname; }
			set	{ 
                  if(this.lastname != value)
                    {
                        this.OnPropertyChanging("LastName");  
                        this.lastname = value;                        
                        this.OnPropertyChanged("LastName");
                    }   
                }
        }	
		
        [Column(COL_FIRSTNAME, PARAM_FIRSTNAME )]
        public virtual string FirstName 
        {
            get { return this.firstname; }
			set	{ 
                  if(this.firstname != value)
                    {
                        this.OnPropertyChanging("FirstName");  
                        this.firstname = value;                        
                        this.OnPropertyChanged("FirstName");
                    }   
                }
        }	
		
        [Column(COL_TITLE, PARAM_TITLE )]
        public virtual string Title 
        {
            get { return this.title; }
			set	{ 
                  if(this.title != value)
                    {
                        this.OnPropertyChanging("Title");  
                        this.title = value;                        
                        this.OnPropertyChanged("Title");
                    }   
                }
        }	
		
        [Column(COL_TITLEOFCOURTESY, PARAM_TITLEOFCOURTESY )]
        public virtual string TitleOfCourtesy 
        {
            get { return this.titleofcourtesy; }
			set	{ 
                  if(this.titleofcourtesy != value)
                    {
                        this.OnPropertyChanging("TitleOfCourtesy");  
                        this.titleofcourtesy = value;                        
                        this.OnPropertyChanged("TitleOfCourtesy");
                    }   
                }
        }	
		
        [Column(COL_BIRTHDATE, PARAM_BIRTHDATE )]
        public virtual System.DateTime? BirthDate 
        {
            get { return this.birthdate; }
			set	{ 
                  if(this.birthdate != value)
                    {
                        this.OnPropertyChanging("BirthDate");  
                        this.birthdate = value;                        
                        this.OnPropertyChanged("BirthDate");
                    }   
                }
        }	
		
        [Column(COL_HIREDATE, PARAM_HIREDATE )]
        public virtual System.DateTime? HireDate 
        {
            get { return this.hiredate; }
			set	{ 
                  if(this.hiredate != value)
                    {
                        this.OnPropertyChanging("HireDate");  
                        this.hiredate = value;                        
                        this.OnPropertyChanged("HireDate");
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
		
        [Column(COL_HOMEPHONE, PARAM_HOMEPHONE )]
        public virtual string HomePhone 
        {
            get { return this.homephone; }
			set	{ 
                  if(this.homephone != value)
                    {
                        this.OnPropertyChanging("HomePhone");  
                        this.homephone = value;                        
                        this.OnPropertyChanged("HomePhone");
                    }   
                }
        }	
		
        [Column(COL_EXTENSION, PARAM_EXTENSION )]
        public virtual string Extension 
        {
            get { return this.extension; }
			set	{ 
                  if(this.extension != value)
                    {
                        this.OnPropertyChanging("Extension");  
                        this.extension = value;                        
                        this.OnPropertyChanged("Extension");
                    }   
                }
        }	
		
        [Column(COL_PHOTO, PARAM_PHOTO )]
        public virtual byte[] Photo 
        {
            get { return this.photo; }
			set	{ 
                  if(this.photo != value)
                    {
                        this.OnPropertyChanging("Photo");  
                        this.photo = value;                        
                        this.OnPropertyChanged("Photo");
                    }   
                }
        }	
		
        [Column(COL_NOTES, PARAM_NOTES )]
        public virtual string Notes 
        {
            get { return this.note; }
			set	{ 
                  if(this.note != value)
                    {
                        this.OnPropertyChanging("Notes");  
                        this.note = value;                        
                        this.OnPropertyChanged("Notes");
                    }   
                }
        }	
		
        [Column(COL_PHOTOPATH, PARAM_PHOTOPATH )]
        public virtual string PhotoPath 
        {
            get { return this.photopath; }
			set	{ 
                  if(this.photopath != value)
                    {
                        this.OnPropertyChanging("PhotoPath");  
                        this.photopath = value;                        
                        this.OnPropertyChanged("PhotoPath");
                    }   
                }
        }	
		
        [Column(COL_REPORTSTO, PARAM_REPORTSTO )]
        public virtual int? ReportsTo                
        {
            get
            {
                if(this.reportstoRef == null)
                    return this.reportsto ;
                
                return this.reportstoRef.EmployeeID;            
            }
            set
            {
                if(this.reportsto != value)
                {
                    this.OnPropertyChanging("ReportsTo");                    
                    this.reportsto = value;                    
                    this.OnPropertyChanged("ReportsTo");
                    
                    this.reportstoRef = null;
                }                
            }          
        }	
        
        public Employee ReportsToRef
        {
            get { return this.reportstoRef; }
			set	
            { 
                if(this.reportstoRef != value)
                {
                    this.OnPropertyChanging("ReportsToRef");
                    
                    if((this.reportstoRef = value) != null) 
                    {
                        this.reportsto = this.reportstoRef.EmployeeID;
                    }
                    else
                    {
		                this.reportsto = default(int);
                    }
                    
                    this.OnPropertyChanged("ReportsToRef");
                }   
             }
        }	
		
        #endregion        
        
        #region Methods     
        
        public override bool Equals(object obj)
        {
            Employee record = obj as Employee;           
            
            return (object.ReferenceEquals(this, record)                    
                    || (record != null            
                        && this.EmployeeID == record.EmployeeID
                        && this.EmployeeID != default(int)
                        )
                    );           
        }
        
        public override int GetHashCode()
        {            
            int hashCode = 7;
            
            hashCode = (11 * hashCode) + this.employeeid.GetHashCode();
                        
            return hashCode;          
        }
        
		void IRecord.Read(DbDataReader reader)
		{       
			this.employeeid = (int)reader[COL_EMPLOYEEID];
			this.lastname = (string)reader[COL_LASTNAME];
			this.firstname = (string)reader[COL_FIRSTNAME];
			this.title = DbConvert.ToString(reader[COL_TITLE]);
			this.titleofcourtesy = DbConvert.ToString(reader[COL_TITLEOFCOURTESY]);
			this.birthdate = DbConvert.ToNullable< System.DateTime >(reader[COL_BIRTHDATE]);
			this.hiredate = DbConvert.ToNullable< System.DateTime >(reader[COL_HIREDATE]);
			this.address = DbConvert.ToString(reader[COL_ADDRESS]);
			this.city = DbConvert.ToString(reader[COL_CITY]);
			this.region = DbConvert.ToString(reader[COL_REGION]);
			this.postalcode = DbConvert.ToString(reader[COL_POSTALCODE]);
			this.country = DbConvert.ToString(reader[COL_COUNTRY]);
			this.homephone = DbConvert.ToString(reader[COL_HOMEPHONE]);
			this.extension = DbConvert.ToString(reader[COL_EXTENSION]);
			this.photo = (byte[])reader[COL_PHOTO];
			this.note = DbConvert.ToString(reader[COL_NOTES]);
			this.reportsto = DbConvert.ToNullable< int >(reader[COL_REPORTSTO]);
			this.photopath = DbConvert.ToString(reader[COL_PHOTOPATH]);
		}
		
		bool IRecord.Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_EMPLOYEES))
            {	
				command.Parameters.Add(dataContext.CreateParameter(PARAM_LASTNAME, this.LastName));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_FIRSTNAME, this.FirstName));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_TITLE, DbConvert.DbValue(this.Title)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_TITLEOFCOURTESY, DbConvert.DbValue(this.TitleOfCourtesy)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_BIRTHDATE, DbConvert.DbValue(this.BirthDate)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_HIREDATE, DbConvert.DbValue(this.HireDate)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_ADDRESS, DbConvert.DbValue(this.Address)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CITY, DbConvert.DbValue(this.City)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_REGION, DbConvert.DbValue(this.Region)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_POSTALCODE, DbConvert.DbValue(this.PostalCode)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_COUNTRY, DbConvert.DbValue(this.Country)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_HOMEPHONE, DbConvert.DbValue(this.HomePhone)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_EXTENSION, DbConvert.DbValue(this.Extension)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_PHOTO, DbConvert.DbValue(this.Photo)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_NOTES, DbConvert.DbValue(this.Notes)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_REPORTSTO, DbConvert.DbValue(this.ReportsTo)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_PHOTOPATH, DbConvert.DbValue(this.PhotoPath)));
                this.EmployeeID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		bool IRecord.Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_EMPLOYEES))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_EMPLOYEEID, this.EmployeeID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_LASTNAME, this.LastName));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_FIRSTNAME, this.FirstName));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_TITLE, DbConvert.DbValue(this.Title)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_TITLEOFCOURTESY, DbConvert.DbValue(this.TitleOfCourtesy)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_BIRTHDATE, DbConvert.DbValue(this.BirthDate)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_HIREDATE, DbConvert.DbValue(this.HireDate)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_ADDRESS, DbConvert.DbValue(this.Address)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CITY, DbConvert.DbValue(this.City)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_REGION, DbConvert.DbValue(this.Region)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_POSTALCODE, DbConvert.DbValue(this.PostalCode)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_COUNTRY, DbConvert.DbValue(this.Country)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_HOMEPHONE, DbConvert.DbValue(this.HomePhone)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_EXTENSION, DbConvert.DbValue(this.Extension)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_PHOTO, DbConvert.DbValue(this.Photo)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_NOTES, DbConvert.DbValue(this.Notes)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_REPORTSTO, DbConvert.DbValue(this.ReportsTo)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_PHOTOPATH, DbConvert.DbValue(this.PhotoPath)));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		bool IRecord.Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_EMPLOYEES))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_EMPLOYEEID, this.EmployeeID));
                return (command.ExecuteNonQuery() == 1);
            }
        }
        
        protected virtual void OnPropertyChanging(string propertyName)
        {
            if(this.PropertyChanging != null)
                this.PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if(this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}