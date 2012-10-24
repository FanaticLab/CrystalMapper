/*
 * Author: CrystalMapper 
 * 
 * Date:  Saturday, September 22, 2012 8:42 PM
 * 
 * Class: Employee
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
    public partial class Employee : Entity< Employee>  
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

        [Column( COL_EMPLOYEEID, PARAM_EMPLOYEEID, default(int))]
                              public virtual int EmployeeID 
        {
            get { return this.employeeid; }
			set	{ 
                  if(this.employeeid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("EmployeeID"));  
                        this.employeeid = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("EmployeeID"));
                    }   
                }
        }	
		
        [Column( COL_LASTNAME, PARAM_LASTNAME )]
                              public virtual string LastName 
        {
            get { return this.lastname; }
			set	{ 
                  if(this.lastname != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("LastName"));  
                        this.lastname = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("LastName"));
                    }   
                }
        }	
		
        [Column( COL_FIRSTNAME, PARAM_FIRSTNAME )]
                              public virtual string FirstName 
        {
            get { return this.firstname; }
			set	{ 
                  if(this.firstname != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("FirstName"));  
                        this.firstname = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("FirstName"));
                    }   
                }
        }	
		
        [Column( COL_TITLE, PARAM_TITLE )]
                              public virtual string Title 
        {
            get { return this.title; }
			set	{ 
                  if(this.title != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Title"));  
                        this.title = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Title"));
                    }   
                }
        }	
		
        [Column( COL_TITLEOFCOURTESY, PARAM_TITLEOFCOURTESY )]
                              public virtual string TitleOfCourtesy 
        {
            get { return this.titleofcourtesy; }
			set	{ 
                  if(this.titleofcourtesy != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("TitleOfCourtesy"));  
                        this.titleofcourtesy = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("TitleOfCourtesy"));
                    }   
                }
        }	
		
        [Column( COL_BIRTHDATE, PARAM_BIRTHDATE )]
                              public virtual System.DateTime? BirthDate 
        {
            get { return this.birthdate; }
			set	{ 
                  if(this.birthdate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("BirthDate"));  
                        this.birthdate = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("BirthDate"));
                    }   
                }
        }	
		
        [Column( COL_HIREDATE, PARAM_HIREDATE )]
                              public virtual System.DateTime? HireDate 
        {
            get { return this.hiredate; }
			set	{ 
                  if(this.hiredate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("HireDate"));  
                        this.hiredate = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("HireDate"));
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
		
        [Column( COL_HOMEPHONE, PARAM_HOMEPHONE )]
                              public virtual string HomePhone 
        {
            get { return this.homephone; }
			set	{ 
                  if(this.homephone != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("HomePhone"));  
                        this.homephone = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("HomePhone"));
                    }   
                }
        }	
		
        [Column( COL_EXTENSION, PARAM_EXTENSION )]
                              public virtual string Extension 
        {
            get { return this.extension; }
			set	{ 
                  if(this.extension != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Extension"));  
                        this.extension = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Extension"));
                    }   
                }
        }	
		
        [Column( COL_PHOTO, PARAM_PHOTO )]
                              public virtual byte[] Photo 
        {
            get { return this.photo; }
			set	{ 
                  if(this.photo != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Photo"));  
                        this.photo = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Photo"));
                    }   
                }
        }	
		
        [Column( COL_NOTES, PARAM_NOTES )]
                              public virtual string Notes 
        {
            get { return this.note; }
			set	{ 
                  if(this.note != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Notes"));  
                        this.note = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Notes"));
                    }   
                }
        }	
		
        [Column( COL_PHOTOPATH, PARAM_PHOTOPATH )]
                              public virtual string PhotoPath 
        {
            get { return this.photopath; }
			set	{ 
                  if(this.photopath != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("PhotoPath"));  
                        this.photopath = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("PhotoPath"));
                    }   
                }
        }	
		
        [Column( COL_REPORTSTO, PARAM_REPORTSTO )]
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
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ReportsTo"));                    
                    this.reportsto = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ReportsTo"));
                    
                    this.reportstoRef = null;
                }                
            }          
        }	
        
        public Employee ReportsToRef
        {
            get { 
                    if(this.reportstoRef == null
                       && this.reportsto.HasValue )
                    {
                        Employee employeeQuery = new Employee {
                                                        EmployeeID = this.reportsto.Value  
                                                        };
                        
                        Employee[]  employees = employeeQuery.ToList();                        
                        if(employees.Length == 1)
                            this.reportstoRef = employees[0];                        
                    }
                    
                    return this.reportstoRef; 
                }
			set	{ 
                  if(this.reportstoRef != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ReportsToRef"));
                        if (this.reportstoRef != null)
                            this.Parents.Remove(this.reportstoRef);                            
                        
                        if((this.reportstoRef = value) != null) 
                        {
                            this.Parents.Add(this.reportstoRef); 
                            this.reportsto = this.reportstoRef.EmployeeID;
                        }
                        else
                        {
		                    this.reportsto = default(int);
                        }
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ReportsToRef"));
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
        
        public override bool Equals(object obj)
        {
            Employee entity = obj as Employee;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.EmployeeID == entity.EmployeeID
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
        
		public override void Read(DbDataReader reader)
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
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_EMPLOYEES))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.LastName, PARAM_LASTNAME));
				command.Parameters.Add(dataContext.CreateParameter(this.FirstName, PARAM_FIRSTNAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Title), PARAM_TITLE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.TitleOfCourtesy), PARAM_TITLEOFCOURTESY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.BirthDate), PARAM_BIRTHDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.HireDate), PARAM_HIREDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Address), PARAM_ADDRESS));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.City), PARAM_CITY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Region), PARAM_REGION));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.PostalCode), PARAM_POSTALCODE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Country), PARAM_COUNTRY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.HomePhone), PARAM_HOMEPHONE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Extension), PARAM_EXTENSION));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Photo), PARAM_PHOTO));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Notes), PARAM_NOTES));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ReportsTo), PARAM_REPORTSTO));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.PhotoPath), PARAM_PHOTOPATH));
                this.EmployeeID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_EMPLOYEES))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.EmployeeID, PARAM_EMPLOYEEID));
				command.Parameters.Add(dataContext.CreateParameter(this.LastName, PARAM_LASTNAME));
				command.Parameters.Add(dataContext.CreateParameter(this.FirstName, PARAM_FIRSTNAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Title), PARAM_TITLE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.TitleOfCourtesy), PARAM_TITLEOFCOURTESY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.BirthDate), PARAM_BIRTHDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.HireDate), PARAM_HIREDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Address), PARAM_ADDRESS));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.City), PARAM_CITY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Region), PARAM_REGION));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.PostalCode), PARAM_POSTALCODE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Country), PARAM_COUNTRY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.HomePhone), PARAM_HOMEPHONE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Extension), PARAM_EXTENSION));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Photo), PARAM_PHOTO));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Notes), PARAM_NOTES));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ReportsTo), PARAM_REPORTSTO));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.PhotoPath), PARAM_PHOTOPATH));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_EMPLOYEES))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.EmployeeID, PARAM_EMPLOYEEID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
    }
}
