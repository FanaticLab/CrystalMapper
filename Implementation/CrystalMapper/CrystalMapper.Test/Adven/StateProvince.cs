/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: StateProvince
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
    public partial class StateProvince : Entity< StateProvince>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Person.StateProvince";	
     
		public const string COL_STATEPROVINCEID = "StateProvinceID";
		public const string COL_STATEPROVINCECODE = "StateProvinceCode";
		public const string COL_COUNTRYREGIONCODE = "CountryRegionCode";
		public const string COL_ISONLYSTATEPROVINCEFLAG = "IsOnlyStateProvinceFlag";
		public const string COL_NAME = "Name";
		public const string COL_TERRITORYID = "TerritoryID";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_STATEPROVINCEID = "@StateProvinceID";	
        public const string PARAM_STATEPROVINCECODE = "@StateProvinceCode";	
        public const string PARAM_COUNTRYREGIONCODE = "@CountryRegionCode";	
        public const string PARAM_ISONLYSTATEPROVINCEFLAG = "@IsOnlyStateProvinceFlag";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_TERRITORYID = "@TerritoryID";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_STATEPROVINCE = "INSERT INTO Person.StateProvince([StateProvinceCode],[CountryRegionCode],[IsOnlyStateProvinceFlag],[Name],[TerritoryID],[rowguid],[ModifiedDate]) VALUES (@StateProvinceCode,@CountryRegionCode,@IsOnlyStateProvinceFlag,@Name,@TerritoryID,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_STATEPROVINCE = "UPDATE Person.StateProvince SET [StateProvinceCode] = @StateProvinceCode, [CountryRegionCode] = @CountryRegionCode, [IsOnlyStateProvinceFlag] = @IsOnlyStateProvinceFlag, [Name] = @Name, [TerritoryID] = @TerritoryID, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [StateProvinceID] = @StateProvinceID";
		
		private const string SQL_DELETE_STATEPROVINCE = "DELETE FROM Person.StateProvince WHERE  [StateProvinceID] = @StateProvinceID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_STATEPROVINCEID, PARAM_STATEPROVINCEID, default(int))]
                              public virtual int StateProvinceID  { get; set; }		
		
        
	    [Column( COL_STATEPROVINCECODE, PARAM_STATEPROVINCECODE )]
                              public virtual string StateProvinceCode  { get; set; }	      
        
	    [Column( COL_COUNTRYREGIONCODE, PARAM_COUNTRYREGIONCODE )]
                              public virtual string CountryRegionCode  { get; set; }	      
        
	    [Column( COL_ISONLYSTATEPROVINCEFLAG, PARAM_ISONLYSTATEPROVINCEFLAG, default(bool))]
                              public virtual bool IsOnlyStateProvinceFlag  { get; set; }	      
        
	    [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name  { get; set; }	      
        
	    [Column( COL_TERRITORYID, PARAM_TERRITORYID, default(int))]
                              public virtual int TerritoryID  { get; set; }	      
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< address> address
        {
            get {
                  foreach(address address in addressList())
                    yield return address; 
                }
        }
        
        public IEnumerable< SalesTaxRate> SalesTaxRates
        {
            get {
                  foreach(SalesTaxRate salesTaxRate in SalesTaxRateList())
                    yield return salesTaxRate; 
                }
        }
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.StateProvinceID = (int)reader[COL_STATEPROVINCEID];
			this.StateProvinceCode = (string)reader[COL_STATEPROVINCECODE];
			this.CountryRegionCode = (string)reader[COL_COUNTRYREGIONCODE];
			this.IsOnlyStateProvinceFlag = (bool)reader[COL_ISONLYSTATEPROVINCEFLAG];
			this.Name = (string)reader[COL_NAME];
			this.TerritoryID = (int)reader[COL_TERRITORYID];
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_STATEPROVINCE))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.StateProvinceCode, PARAM_STATEPROVINCECODE));
				command.Parameters.Add(dataContext.CreateParameter(this.CountryRegionCode, PARAM_COUNTRYREGIONCODE));
				command.Parameters.Add(dataContext.CreateParameter(this.IsOnlyStateProvinceFlag, PARAM_ISONLYSTATEPROVINCEFLAG));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.StateProvinceID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_STATEPROVINCE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.StateProvinceID, PARAM_STATEPROVINCEID));
				command.Parameters.Add(dataContext.CreateParameter(this.StateProvinceCode, PARAM_STATEPROVINCECODE));
				command.Parameters.Add(dataContext.CreateParameter(this.CountryRegionCode, PARAM_COUNTRYREGIONCODE));
				command.Parameters.Add(dataContext.CreateParameter(this.IsOnlyStateProvinceFlag, PARAM_ISONLYSTATEPROVINCEFLAG));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_STATEPROVINCE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.StateProvinceID, PARAM_STATEPROVINCEID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public address GetaddressQuery()
        {
            return new address {                
                                                                            StateProvinceID = this.StateProvinceID  
                                                                            };
        }
        
        public address[] addressList()
        {
            return GetaddressQuery().ToList();
        }  
        
        public SalesTaxRate GetSalesTaxRatesQuery()
        {
            return new SalesTaxRate {                
                                                                            StateProvinceID = this.StateProvinceID  
                                                                            };
        }
        
        public SalesTaxRate[] SalesTaxRateList()
        {
            return GetSalesTaxRatesQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
