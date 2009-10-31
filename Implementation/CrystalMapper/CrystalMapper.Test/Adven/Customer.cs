/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
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

namespace CrystalMapper.Generated.BusinessObjects
{
	[Table(TABLE_NAME)]
    public partial class Customer : Entity< Customer>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.Customer";	
     
		public const string COL_CUSTOMERID = "CustomerID";
		public const string COL_TERRITORYID = "TerritoryID";
		public const string COL_ACCOUNTNUMBER = "AccountNumber";
		public const string COL_CUSTOMERTYPE = "CustomerType";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_CUSTOMERID = "@CustomerID";	
        public const string PARAM_TERRITORYID = "@TerritoryID";	
        public const string PARAM_ACCOUNTNUMBER = "@AccountNumber";	
        public const string PARAM_CUSTOMERTYPE = "@CustomerType";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_CUSTOMER = "INSERT INTO Sales.Customer([TerritoryID],[AccountNumber],[CustomerType],[rowguid],[ModifiedDate]) VALUES (@TerritoryID,@AccountNumber,@CustomerType,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_CUSTOMER = "UPDATE Sales.Customer SET [TerritoryID] = @TerritoryID, [AccountNumber] = @AccountNumber, [CustomerType] = @CustomerType, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [CustomerID] = @CustomerID";
		
		private const string SQL_DELETE_CUSTOMER = "DELETE FROM Sales.Customer WHERE  [CustomerID] = @CustomerID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_CUSTOMERID, PARAM_CUSTOMERID, default(int))]
                              public virtual int CustomerID  { get; set; }		
		
        
	    [Column( COL_TERRITORYID, PARAM_TERRITORYID )]
                              public virtual int? TerritoryID  { get; set; }	      
        
	    [Column( COL_ACCOUNTNUMBER, PARAM_ACCOUNTNUMBER )]
                              public virtual string AccountNumber  { get; set; }	      
        
	    [Column( COL_CUSTOMERTYPE, PARAM_CUSTOMERTYPE )]
                              public virtual string CustomerType  { get; set; }	      
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< CustomerAddress> CustomerAddresses
        {
            get {
                  foreach(CustomerAddress customerAddress in CustomerAddressList())
                    yield return customerAddress; 
                }
        }
        
        public IEnumerable< Individual> Individuals
        {
            get {
                  foreach(Individual individual in IndividualList())
                    yield return individual; 
                }
        }
        
        public IEnumerable< SalesOrderHeader> SalesOrderHeaders
        {
            get {
                  foreach(SalesOrderHeader salesOrderHeader in SalesOrderHeaderList())
                    yield return salesOrderHeader; 
                }
        }
        
        public IEnumerable< Store> Stores
        {
            get {
                  foreach(Store store in StoreList())
                    yield return store; 
                }
        }
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.CustomerID = (int)reader[COL_CUSTOMERID];
			this.TerritoryID = DbConvert.ToNullable< int >(reader[COL_TERRITORYID]);
			this.AccountNumber = (string)reader[COL_ACCOUNTNUMBER];
			this.CustomerType = (string)reader[COL_CUSTOMERTYPE];
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_CUSTOMER))
            {	
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.TerritoryID), PARAM_TERRITORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.AccountNumber, PARAM_ACCOUNTNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerType, PARAM_CUSTOMERTYPE));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.CustomerID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_CUSTOMER))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.TerritoryID), PARAM_TERRITORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.AccountNumber, PARAM_ACCOUNTNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerType, PARAM_CUSTOMERTYPE));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_CUSTOMER))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public CustomerAddress GetCustomerAddressesQuery()
        {
            return new CustomerAddress {                
                                                                            CustomerID = this.CustomerID  
                                                                            };
        }
        
        public CustomerAddress[] CustomerAddressList()
        {
            return GetCustomerAddressesQuery().ToList();
        }  
        
        public Individual GetIndividualsQuery()
        {
            return new Individual {                
                                                                            CustomerID = this.CustomerID  
                                                                            };
        }
        
        public Individual[] IndividualList()
        {
            return GetIndividualsQuery().ToList();
        }  
        
        public SalesOrderHeader GetSalesOrderHeadersQuery()
        {
            return new SalesOrderHeader {                
                                                                            CustomerID = this.CustomerID  
                                                                            };
        }
        
        public SalesOrderHeader[] SalesOrderHeaderList()
        {
            return GetSalesOrderHeadersQuery().ToList();
        }  
        
        public Store GetStoresQuery()
        {
            return new Store {                
                                                                            CustomerID = this.CustomerID  
                                                                            };
        }
        
        public Store[] StoreList()
        {
            return GetStoresQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
