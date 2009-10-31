/*
 * Author: CrystalMapper
 * 
 * Date:  Sunday, November 01, 2009 2:37 AM
 * 
 * Class: Customer
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
    public partial class Customer : Entity< Customer>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Customers";	
     
		public const string COL_CUSTOMERID = "CustomerID";
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
		
        public const string PARAM_CUSTOMERID = ":CustomerID";	
        public const string PARAM_COMPANYNAME = ":CompanyName";	
        public const string PARAM_CONTACTNAME = ":ContactName";	
        public const string PARAM_CONTACTTITLE = ":ContactTitle";	
        public const string PARAM_ADDRESS = ":Address";	
        public const string PARAM_CITY = ":City";	
        public const string PARAM_REGION = ":Region";	
        public const string PARAM_POSTALCODE = ":PostalCode";	
        public const string PARAM_COUNTRY = ":Country";	
        public const string PARAM_PHONE = ":Phone";	
        public const string PARAM_FAX = ":Fax";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_CUSTOMERS = "INSERT INTO Customers([CustomerID],[CompanyName],[ContactName],[ContactTitle],[Address],[City],[Region],[PostalCode],[Country],[Phone],[Fax]) VALUES (:CustomerID,:CompanyName,:ContactName,:ContactTitle,:Address,:City,:Region,:PostalCode,:Country,:Phone,:Fax);"  ;
		
		private const string SQL_UPDATE_CUSTOMERS = "UPDATE Customers SET [CompanyName] = :CompanyName, [ContactName] = :ContactName, [ContactTitle] = :ContactTitle, [Address] = :Address, [City] = :City, [Region] = :Region, [PostalCode] = :PostalCode, [Country] = :Country, [Phone] = :Phone, [Fax] = :Fax,  WHERE [CustomerID] = :CustomerID";
		
		private const string SQL_DELETE_CUSTOMERS = "DELETE FROM Customers WHERE  [CustomerID] = :CustomerID ";
		
        #endregion
        
        #region Properties	
		
		[Column( COL_CUSTOMERID, PARAM_CUSTOMERID )]
                              public virtual string CustomerID  { get; set; }		
		
        
	    [Column( COL_COMPANYNAME, PARAM_COMPANYNAME )]
                              public virtual string CompanyName  { get; set; }	      
        
	    [Column( COL_CONTACTNAME, PARAM_CONTACTNAME )]
                              public virtual string ContactName  { get; set; }	      
        
	    [Column( COL_CONTACTTITLE, PARAM_CONTACTTITLE )]
                              public virtual string ContactTitle  { get; set; }	      
        
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
        
	    [Column( COL_PHONE, PARAM_PHONE )]
                              public virtual string Phone  { get; set; }	      
        
	    [Column( COL_FAX, PARAM_FAX )]
                              public virtual string Fax  { get; set; }	      
        
        public IEnumerable< Order> Orders
        {
            get {
                  foreach(Order order in OrderList())
                    yield return order; 
                }
        }
        
        #endregion        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.CustomerID = (string)reader[COL_CUSTOMERID];
			this.CompanyName = (string)reader[COL_COMPANYNAME];
			this.ContactName = DbConvert.ToString(reader[COL_CONTACTNAME]);
			this.ContactTitle = DbConvert.ToString(reader[COL_CONTACTTITLE]);
			this.Address = DbConvert.ToString(reader[COL_ADDRESS]);
			this.City = DbConvert.ToString(reader[COL_CITY]);
			this.Region = DbConvert.ToString(reader[COL_REGION]);
			this.PostalCode = DbConvert.ToString(reader[COL_POSTALCODE]);
			this.Country = DbConvert.ToString(reader[COL_COUNTRY]);
			this.Phone = DbConvert.ToString(reader[COL_PHONE]);
			this.Fax = DbConvert.ToString(reader[COL_FAX]);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_CUSTOMERS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));
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
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_CUSTOMERS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));
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
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_CUSTOMERS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public Order GetOrdersQuery()
        {
            return new Order {                
                                                                            CustomerID = this.CustomerID  
                                                                            };
        }
        
        public Order[] OrderList()
        {
            return GetOrdersQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
