/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:51 PM
 * 
 * Class: SalesTerritory
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
    public partial class SalesTerritory : Entity< SalesTerritory>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.SalesTerritory";	
     
		public const string COL_TERRITORYID = "TerritoryID";
		public const string COL_NAME = "Name";
		public const string COL_COUNTRYREGIONCODE = "CountryRegionCode";
		public const string COL_GROUP = "Group";
		public const string COL_SALESYTD = "SalesYTD";
		public const string COL_SALESLASTYEAR = "SalesLastYear";
		public const string COL_COSTYTD = "CostYTD";
		public const string COL_COSTLASTYEAR = "CostLastYear";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_TERRITORYID = "@TerritoryID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_COUNTRYREGIONCODE = "@CountryRegionCode";	
        public const string PARAM_GROUP = "@Group";	
        public const string PARAM_SALESYTD = "@SalesYTD";	
        public const string PARAM_SALESLASTYEAR = "@SalesLastYear";	
        public const string PARAM_COSTYTD = "@CostYTD";	
        public const string PARAM_COSTLASTYEAR = "@CostLastYear";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SALESTERRITORY = "INSERT INTO Sales.SalesTerritory([Name],[CountryRegionCode],[Group],[SalesYTD],[SalesLastYear],[CostYTD],[CostLastYear],[rowguid],[ModifiedDate]) VALUES (@Name,@CountryRegionCode,@Group,@SalesYTD,@SalesLastYear,@CostYTD,@CostLastYear,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_SALESTERRITORY = "UPDATE Sales.SalesTerritory SET [Name] = @Name, [CountryRegionCode] = @CountryRegionCode, [Group] = @Group, [SalesYTD] = @SalesYTD, [SalesLastYear] = @SalesLastYear, [CostYTD] = @CostYTD, [CostLastYear] = @CostLastYear, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [TerritoryID] = @TerritoryID";
		
		private const string SQL_DELETE_SALESTERRITORY = "DELETE FROM Sales.SalesTerritory WHERE  [TerritoryID] = @TerritoryID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_TERRITORYID, PARAM_TERRITORYID, default(int))]
                              public virtual int TerritoryID  { get; set; }		
		
        
	    [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name  { get; set; }	      
        
	    [Column( COL_COUNTRYREGIONCODE, PARAM_COUNTRYREGIONCODE )]
                              public virtual string CountryRegionCode  { get; set; }	      
        
	    [Column( COL_GROUP, PARAM_GROUP )]
                              public virtual string Group  { get; set; }	      
        
	    [Column( COL_SALESYTD, PARAM_SALESYTD, typeof(decimal))]
                              public virtual decimal SalesYTD  { get; set; }	      
        
	    [Column( COL_SALESLASTYEAR, PARAM_SALESLASTYEAR, typeof(decimal))]
                              public virtual decimal SalesLastYear  { get; set; }	      
        
	    [Column( COL_COSTYTD, PARAM_COSTYTD, typeof(decimal))]
                              public virtual decimal CostYTD  { get; set; }	      
        
	    [Column( COL_COSTLASTYEAR, PARAM_COSTLASTYEAR, typeof(decimal))]
                              public virtual decimal CostLastYear  { get; set; }	      
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< StateProvince> StateProvinces
        {
            get {
                  foreach(StateProvince stateProvince in StateProvinceList())
                    yield return stateProvince; 
                }
        }
        
        public IEnumerable< Customer> Customers
        {
            get {
                  foreach(Customer customer in CustomerList())
                    yield return customer; 
                }
        }
        
        public IEnumerable< SalesOrderHeader> SalesOrderHeaders
        {
            get {
                  foreach(SalesOrderHeader salesOrderHeader in SalesOrderHeaderList())
                    yield return salesOrderHeader; 
                }
        }
        
        public IEnumerable< SalesPerson> SalesPeople
        {
            get {
                  foreach(SalesPerson salesPerson in SalesPersonList())
                    yield return salesPerson; 
                }
        }
        
        public IEnumerable< SalesTerritoryHistory> SalesTerritoryHistories
        {
            get {
                  foreach(SalesTerritoryHistory salesTerritoryHistory in SalesTerritoryHistoryList())
                    yield return salesTerritoryHistory; 
                }
        }
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.TerritoryID = (int)reader[COL_TERRITORYID];
			this.Name = (string)reader[COL_NAME];
			this.CountryRegionCode = (string)reader[COL_COUNTRYREGIONCODE];
			this.Group = (string)reader[COL_GROUP];
			this.SalesYTD = (decimal)reader[COL_SALESYTD];
			this.SalesLastYear = (decimal)reader[COL_SALESLASTYEAR];
			this.CostYTD = (decimal)reader[COL_COSTYTD];
			this.CostLastYear = (decimal)reader[COL_COSTLASTYEAR];
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SALESTERRITORY))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.CountryRegionCode, PARAM_COUNTRYREGIONCODE));
				command.Parameters.Add(dataContext.CreateParameter(this.Group, PARAM_GROUP));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesYTD, PARAM_SALESYTD));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesLastYear, PARAM_SALESLASTYEAR));
				command.Parameters.Add(dataContext.CreateParameter(this.CostYTD, PARAM_COSTYTD));
				command.Parameters.Add(dataContext.CreateParameter(this.CostLastYear, PARAM_COSTLASTYEAR));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.TerritoryID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SALESTERRITORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.CountryRegionCode, PARAM_COUNTRYREGIONCODE));
				command.Parameters.Add(dataContext.CreateParameter(this.Group, PARAM_GROUP));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesYTD, PARAM_SALESYTD));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesLastYear, PARAM_SALESLASTYEAR));
				command.Parameters.Add(dataContext.CreateParameter(this.CostYTD, PARAM_COSTYTD));
				command.Parameters.Add(dataContext.CreateParameter(this.CostLastYear, PARAM_COSTLASTYEAR));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SALESTERRITORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public StateProvince GetStateProvincesQuery()
        {
            return new StateProvince {                
                                                                            TerritoryID = this.TerritoryID  
                                                                            };
        }
        
        public StateProvince[] StateProvinceList()
        {
            return GetStateProvincesQuery().ToList();
        }  
        
        public Customer GetCustomersQuery()
        {
            return new Customer {                
                                                                            TerritoryID = this.TerritoryID  
                                                                            };
        }
        
        public Customer[] CustomerList()
        {
            return GetCustomersQuery().ToList();
        }  
        
        public SalesOrderHeader GetSalesOrderHeadersQuery()
        {
            return new SalesOrderHeader {                
                                                                            TerritoryID = this.TerritoryID  
                                                                            };
        }
        
        public SalesOrderHeader[] SalesOrderHeaderList()
        {
            return GetSalesOrderHeadersQuery().ToList();
        }  
        
        public SalesPerson GetSalesPeopleQuery()
        {
            return new SalesPerson {                
                                                                            TerritoryID = this.TerritoryID  
                                                                            };
        }
        
        public SalesPerson[] SalesPersonList()
        {
            return GetSalesPeopleQuery().ToList();
        }  
        
        public SalesTerritoryHistory GetSalesTerritoryHistoriesQuery()
        {
            return new SalesTerritoryHistory {                
                                                                            TerritoryID = this.TerritoryID  
                                                                            };
        }
        
        public SalesTerritoryHistory[] SalesTerritoryHistoryList()
        {
            return GetSalesTerritoryHistoriesQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
