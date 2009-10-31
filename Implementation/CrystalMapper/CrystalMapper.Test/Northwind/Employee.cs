/*
 * Author: CrystalMapper
 * 
 * Date:  Sunday, November 01, 2009 2:37 AM
 * 
 * Class: Employee
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

namespace Northwind
{
	[Table(TABLE_NAME)]
    public partial class Employee : Entity< Employee>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Employees";	
     
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
		public const string COL_PHOTOPATH = "PhotoPath";
		
        public const string PARAM_EMPLOYEEID = ":EmployeeID";	
        public const string PARAM_LASTNAME = ":LastName";	
        public const string PARAM_FIRSTNAME = ":FirstName";	
        public const string PARAM_TITLE = ":Title";	
        public const string PARAM_TITLEOFCOURTESY = ":TitleOfCourtesy";	
        public const string PARAM_BIRTHDATE = ":BirthDate";	
        public const string PARAM_HIREDATE = ":HireDate";	
        public const string PARAM_ADDRESS = ":Address";	
        public const string PARAM_CITY = ":City";	
        public const string PARAM_REGION = ":Region";	
        public const string PARAM_POSTALCODE = ":PostalCode";	
        public const string PARAM_COUNTRY = ":Country";	
        public const string PARAM_HOMEPHONE = ":HomePhone";	
        public const string PARAM_EXTENSION = ":Extension";	
        public const string PARAM_PHOTO = ":Photo";	
        public const string PARAM_NOTES = ":Notes";	
        public const string PARAM_PHOTOPATH = ":PhotoPath";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_EMPLOYEES = "INSERT INTO Employees([LastName],[FirstName],[Title],[TitleOfCourtesy],[BirthDate],[HireDate],[Address],[City],[Region],[PostalCode],[Country],[HomePhone],[Extension],[Photo],[Notes],[PhotoPath]) VALUES (:LastName,:FirstName,:Title,:TitleOfCourtesy,:BirthDate,:HireDate,:Address,:City,:Region,:PostalCode,:Country,:HomePhone,:Extension,:Photo,:Notes,:PhotoPath);"   + "SELECT last_insert_rowid();" ;
		
		private const string SQL_UPDATE_EMPLOYEES = "UPDATE Employees SET [LastName] = :LastName, [FirstName] = :FirstName, [Title] = :Title, [TitleOfCourtesy] = :TitleOfCourtesy, [BirthDate] = :BirthDate, [HireDate] = :HireDate, [Address] = :Address, [City] = :City, [Region] = :Region, [PostalCode] = :PostalCode, [Country] = :Country, [HomePhone] = :HomePhone, [Extension] = :Extension, [Photo] = :Photo, [Notes] = :Notes, [PhotoPath] = :PhotoPath,  WHERE [EmployeeID] = :EmployeeID";
		
		private const string SQL_DELETE_EMPLOYEES = "DELETE FROM Employees WHERE  [EmployeeID] = :EmployeeID ";
		
        #endregion
        
        #region Properties	
		
		[Column( COL_EMPLOYEEID, PARAM_EMPLOYEEID, default(long))]
                              public virtual long EmployeeID  { get; set; }		
		
        
	    [Column( COL_LASTNAME, PARAM_LASTNAME )]
                              public virtual string LastName  { get; set; }	      
        
	    [Column( COL_FIRSTNAME, PARAM_FIRSTNAME )]
                              public virtual string FirstName  { get; set; }	      
        
	    [Column( COL_TITLE, PARAM_TITLE )]
                              public virtual string Title  { get; set; }	      
        
	    [Column( COL_TITLEOFCOURTESY, PARAM_TITLEOFCOURTESY )]
                              public virtual string TitleOfCourtesy  { get; set; }	      
        
	    [Column( COL_BIRTHDATE, PARAM_BIRTHDATE )]
                              public virtual System.DateTime? BirthDate  { get; set; }	      
        
	    [Column( COL_HIREDATE, PARAM_HIREDATE )]
                              public virtual System.DateTime? HireDate  { get; set; }	      
        
	    [Column( COL_ADDRESS, PARAM_ADDRESS )]
                              public virtual string Address  { get; set; }	      
        
	    [Column( COL_CITY, PARAM_CITY )]
                              public virtual string City  { get; set; }	      
        
	    [Column( COL_REGION, PARAM_REGION )]
                              public virtual string Region  { get; set; }	      
        
	    [Column( COL_POSTALCODE, PARAM_POSTALCODE )]
                              public virtual string PostalCode  { get; set; }	      
        
	    [Column( COL_COUNTRY, PARAM_COUNTRY )]
                              public virtual string Country  { get; set; }	      
        
	    [Column( COL_HOMEPHONE, PARAM_HOMEPHONE )]
                              public virtual string HomePhone  { get; set; }	      
        
	    [Column( COL_EXTENSION, PARAM_EXTENSION )]
                              public virtual string Extension  { get; set; }	      
        
	    [Column( COL_PHOTO, PARAM_PHOTO )]
                              public virtual byte[] Photo  { get; set; }	      
        
	    [Column( COL_NOTES, PARAM_NOTES )]
                              public virtual string Notes  { get; set; }	      
        
	    [Column( COL_PHOTOPATH, PARAM_PHOTOPATH )]
                              public virtual string PhotoPath  { get; set; }	      
        
        public IEnumerable< EmployeesTerritory> EmployeesTerritories
        {
            get {
                  foreach(EmployeesTerritory employeesTerritory in EmployeesTerritoryList())
                    yield return employeesTerritory; 
                }
        }
        
        public IEnumerable< Territory> Territories
        {
            get {                         
                    foreach(Territory territory in TerritoryList())
                        yield return territory; 
                }         
        }    
        #endregion        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.EmployeeID = (long)reader[COL_EMPLOYEEID];
			this.LastName = (string)reader[COL_LASTNAME];
			this.FirstName = (string)reader[COL_FIRSTNAME];
			this.Title = DbConvert.ToString(reader[COL_TITLE]);
			this.TitleOfCourtesy = DbConvert.ToString(reader[COL_TITLEOFCOURTESY]);
			this.BirthDate = DbConvert.ToNullable< System.DateTime >(reader[COL_BIRTHDATE]);
			this.HireDate = DbConvert.ToNullable< System.DateTime >(reader[COL_HIREDATE]);
			this.Address = DbConvert.ToString(reader[COL_ADDRESS]);
			this.City = DbConvert.ToString(reader[COL_CITY]);
			this.Region = DbConvert.ToString(reader[COL_REGION]);
			this.PostalCode = DbConvert.ToString(reader[COL_POSTALCODE]);
			this.Country = DbConvert.ToString(reader[COL_COUNTRY]);
			this.HomePhone = DbConvert.ToString(reader[COL_HOMEPHONE]);
			this.Extension = DbConvert.ToString(reader[COL_EXTENSION]);
			this.Photo = (byte[])reader[COL_PHOTO];
			this.Notes = DbConvert.ToString(reader[COL_NOTES]);
			this.PhotoPath = DbConvert.ToString(reader[COL_PHOTOPATH]);
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
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.PhotoPath), PARAM_PHOTOPATH));
                this.EmployeeID = Convert.ToInt64(command.ExecuteScalar());
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
        
        #region Children
        
        public EmployeesTerritory GetEmployeesTerritoriesQuery()
        {
            return new EmployeesTerritory {                
                                                                            EmployeeID = this.EmployeeID  
                                                                            };
        }
        
        public EmployeesTerritory[] EmployeesTerritoryList()
        {
            return GetEmployeesTerritoriesQuery().ToList();
        }  
        
        
        
        public Territory[] TerritoryList()
        {
            string sqlQuery = @"SELECT Territories.*
                                FROM EmployeesTerritories
                                INNER JOIN Territories ON                                                                            
                                EmployeesTerritories.[TerritoryID] = Territories.[TerritoryID] AND
                                EmployeesTerritories.[EmployeeID] = :EmployeeID  
                                ";
                                
            Dictionary<string, object> parameterValues = new Dictionary<string, object>();
            parameterValues.Add(PARAM_EMPLOYEEID, this.EmployeeID);
            
            return Territory.ToList(sqlQuery, parameterValues);
            
        }    
        
        #endregion
    }
}
