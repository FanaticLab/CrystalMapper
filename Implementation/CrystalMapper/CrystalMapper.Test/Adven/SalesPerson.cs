/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: SalesPerson
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
    public partial class SalesPerson : Entity< SalesPerson>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.SalesPerson";	
     
		public const string COL_SALESPERSONID = "SalesPersonID";
		public const string COL_TERRITORYID = "TerritoryID";
		public const string COL_SALESQUOTA = "SalesQuota";
		public const string COL_BONUS = "Bonus";
		public const string COL_COMMISSIONPCT = "CommissionPct";
		public const string COL_SALESYTD = "SalesYTD";
		public const string COL_SALESLASTYEAR = "SalesLastYear";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SALESPERSONID = "@SalesPersonID";	
        public const string PARAM_TERRITORYID = "@TerritoryID";	
        public const string PARAM_SALESQUOTA = "@SalesQuota";	
        public const string PARAM_BONUS = "@Bonus";	
        public const string PARAM_COMMISSIONPCT = "@CommissionPct";	
        public const string PARAM_SALESYTD = "@SalesYTD";	
        public const string PARAM_SALESLASTYEAR = "@SalesLastYear";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SALESPERSON = "INSERT INTO Sales.SalesPerson([SalesPersonID],[TerritoryID],[SalesQuota],[Bonus],[CommissionPct],[SalesYTD],[SalesLastYear],[rowguid],[ModifiedDate]) VALUES (@SalesPersonID,@TerritoryID,@SalesQuota,@Bonus,@CommissionPct,@SalesYTD,@SalesLastYear,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_SALESPERSON = "UPDATE Sales.SalesPerson SET [TerritoryID] = @TerritoryID, [SalesQuota] = @SalesQuota, [Bonus] = @Bonus, [CommissionPct] = @CommissionPct, [SalesYTD] = @SalesYTD, [SalesLastYear] = @SalesLastYear, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [SalesPersonID] = @SalesPersonID";
		
		private const string SQL_DELETE_SALESPERSON = "DELETE FROM Sales.SalesPerson WHERE  [SalesPersonID] = @SalesPersonID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_SALESPERSONID, PARAM_SALESPERSONID, default(int))]
                              public virtual int SalesPersonID  { get; set; }		
		
        
	    [Column( COL_TERRITORYID, PARAM_TERRITORYID )]
                              public virtual int? TerritoryID  { get; set; }	      
        
	    [Column( COL_SALESQUOTA, PARAM_SALESQUOTA )]
                              public virtual decimal? SalesQuota  { get; set; }	      
        
	    [Column( COL_BONUS, PARAM_BONUS, typeof(decimal))]
                              public virtual decimal Bonus  { get; set; }	      
        
	    [Column( COL_COMMISSIONPCT, PARAM_COMMISSIONPCT, typeof(decimal))]
                              public virtual decimal CommissionPct  { get; set; }	      
        
	    [Column( COL_SALESYTD, PARAM_SALESYTD, typeof(decimal))]
                              public virtual decimal SalesYTD  { get; set; }	      
        
	    [Column( COL_SALESLASTYEAR, PARAM_SALESLASTYEAR, typeof(decimal))]
                              public virtual decimal SalesLastYear  { get; set; }	      
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< SalesOrderHeader> SalesOrderHeaders
        {
            get {
                  foreach(SalesOrderHeader salesOrderHeader in SalesOrderHeaderList())
                    yield return salesOrderHeader; 
                }
        }
        
        public IEnumerable< SalesPersonQuotaHistory> SalesPersonQuotaHistories
        {
            get {
                  foreach(SalesPersonQuotaHistory salesPersonQuotaHistory in SalesPersonQuotaHistoryList())
                    yield return salesPersonQuotaHistory; 
                }
        }
        
        public IEnumerable< SalesTerritoryHistory> SalesTerritoryHistories
        {
            get {
                  foreach(SalesTerritoryHistory salesTerritoryHistory in SalesTerritoryHistoryList())
                    yield return salesTerritoryHistory; 
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
			this.SalesPersonID = (int)reader[COL_SALESPERSONID];
			this.TerritoryID = DbConvert.ToNullable< int >(reader[COL_TERRITORYID]);
			this.SalesQuota = DbConvert.ToNullable< decimal >(reader[COL_SALESQUOTA]);
			this.Bonus = (decimal)reader[COL_BONUS];
			this.CommissionPct = (decimal)reader[COL_COMMISSIONPCT];
			this.SalesYTD = (decimal)reader[COL_SALESYTD];
			this.SalesLastYear = (decimal)reader[COL_SALESLASTYEAR];
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SALESPERSON))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.SalesPersonID, PARAM_SALESPERSONID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.TerritoryID), PARAM_TERRITORYID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.SalesQuota), PARAM_SALESQUOTA));
				command.Parameters.Add(dataContext.CreateParameter(this.Bonus, PARAM_BONUS));
				command.Parameters.Add(dataContext.CreateParameter(this.CommissionPct, PARAM_COMMISSIONPCT));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesYTD, PARAM_SALESYTD));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesLastYear, PARAM_SALESLASTYEAR));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SALESPERSON))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SalesPersonID, PARAM_SALESPERSONID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.TerritoryID), PARAM_TERRITORYID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.SalesQuota), PARAM_SALESQUOTA));
				command.Parameters.Add(dataContext.CreateParameter(this.Bonus, PARAM_BONUS));
				command.Parameters.Add(dataContext.CreateParameter(this.CommissionPct, PARAM_COMMISSIONPCT));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesYTD, PARAM_SALESYTD));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesLastYear, PARAM_SALESLASTYEAR));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SALESPERSON))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SalesPersonID, PARAM_SALESPERSONID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public SalesOrderHeader GetSalesOrderHeadersQuery()
        {
            return new SalesOrderHeader {                
                                                                            SalesPersonID = this.SalesPersonID  
                                                                            };
        }
        
        public SalesOrderHeader[] SalesOrderHeaderList()
        {
            return GetSalesOrderHeadersQuery().ToList();
        }  
        
        public SalesPersonQuotaHistory GetSalesPersonQuotaHistoriesQuery()
        {
            return new SalesPersonQuotaHistory {                
                                                                            SalesPersonID = this.SalesPersonID  
                                                                            };
        }
        
        public SalesPersonQuotaHistory[] SalesPersonQuotaHistoryList()
        {
            return GetSalesPersonQuotaHistoriesQuery().ToList();
        }  
        
        public SalesTerritoryHistory GetSalesTerritoryHistoriesQuery()
        {
            return new SalesTerritoryHistory {                
                                                                            SalesPersonID = this.SalesPersonID  
                                                                            };
        }
        
        public SalesTerritoryHistory[] SalesTerritoryHistoryList()
        {
            return GetSalesTerritoryHistoriesQuery().ToList();
        }  
        
        public Store GetStoresQuery()
        {
            return new Store {                
                                                                            SalesPersonID = this.SalesPersonID  
                                                                            };
        }
        
        public Store[] StoreList()
        {
            return GetStoresQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
