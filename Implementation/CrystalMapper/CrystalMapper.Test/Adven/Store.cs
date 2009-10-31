/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:51 PM
 * 
 * Class: Store
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
    public partial class Store : Entity< Store>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.Store";	
     
		public const string COL_CUSTOMERID = "CustomerID";
		public const string COL_NAME = "Name";
		public const string COL_SALESPERSONID = "SalesPersonID";
		public const string COL_DEMOGRAPHICS = "Demographics";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_CUSTOMERID = "@CustomerID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_SALESPERSONID = "@SalesPersonID";	
        public const string PARAM_DEMOGRAPHICS = "@Demographics";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_STORE = "INSERT INTO Sales.Store([CustomerID],[Name],[SalesPersonID],[Demographics],[rowguid],[ModifiedDate]) VALUES (@CustomerID,@Name,@SalesPersonID,@Demographics,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_STORE = "UPDATE Sales.Store SET [Name] = @Name, [SalesPersonID] = @SalesPersonID, [Demographics] = @Demographics, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [CustomerID] = @CustomerID";
		
		private const string SQL_DELETE_STORE = "DELETE FROM Sales.Store WHERE  [CustomerID] = @CustomerID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_CUSTOMERID, PARAM_CUSTOMERID, default(int))]
                              public virtual int CustomerID  { get; set; }		
		
        
	    [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name  { get; set; }	      
        
	    [Column( COL_SALESPERSONID, PARAM_SALESPERSONID )]
                              public virtual int? SalesPersonID  { get; set; }	      
        
	    [Column( COL_DEMOGRAPHICS, PARAM_DEMOGRAPHICS )]
                              public virtual System.Xml.XmlDocument Demographics  { get; set; }	      
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< StoreContact> StoreContacts
        {
            get {
                  foreach(StoreContact storeContact in StoreContactList())
                    yield return storeContact; 
                }
        }
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.CustomerID = (int)reader[COL_CUSTOMERID];
			this.Name = (string)reader[COL_NAME];
			this.SalesPersonID = DbConvert.ToNullable< int >(reader[COL_SALESPERSONID]);
			this.Demographics = (System.Xml.XmlDocument)reader[COL_DEMOGRAPHICS];
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_STORE))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.SalesPersonID), PARAM_SALESPERSONID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Demographics), PARAM_DEMOGRAPHICS));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_STORE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.SalesPersonID), PARAM_SALESPERSONID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Demographics), PARAM_DEMOGRAPHICS));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_STORE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public StoreContact GetStoreContactsQuery()
        {
            return new StoreContact {                
                                                                            CustomerID = this.CustomerID  
                                                                            };
        }
        
        public StoreContact[] StoreContactList()
        {
            return GetStoreContactsQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
