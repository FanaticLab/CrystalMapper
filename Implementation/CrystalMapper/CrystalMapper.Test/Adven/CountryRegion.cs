/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: CountryRegion
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
    public partial class CountryRegion : Entity< CountryRegion>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Person.CountryRegion";	
     
		public const string COL_COUNTRYREGIONCODE = "CountryRegionCode";
		public const string COL_NAME = "Name";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_COUNTRYREGIONCODE = "@CountryRegionCode";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_COUNTRYREGION = "INSERT INTO Person.CountryRegion([CountryRegionCode],[Name],[ModifiedDate]) VALUES (@CountryRegionCode,@Name,@ModifiedDate);";
		
		private const string SQL_UPDATE_COUNTRYREGION = "UPDATE Person.CountryRegion SET [Name] = @Name, [ModifiedDate] = @ModifiedDate,  WHERE [CountryRegionCode] = @CountryRegionCode";
		
		private const string SQL_DELETE_COUNTRYREGION = "DELETE FROM Person.CountryRegion WHERE  [CountryRegionCode] = @CountryRegionCode ";
		
        #endregion
        #region Properties	
		
		[Column( COL_COUNTRYREGIONCODE, PARAM_COUNTRYREGIONCODE )]
                              public virtual string CountryRegionCode  { get; set; }		
		
        
	    [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< StateProvince> StateProvinces
        {
            get {
                  foreach(StateProvince stateProvince in StateProvinceList())
                    yield return stateProvince; 
                }
        }
        
        public IEnumerable< CountryRegionCurrency> CountryRegionCurrencies
        {
            get {
                  foreach(CountryRegionCurrency countryRegionCurrency in CountryRegionCurrencyList())
                    yield return countryRegionCurrency; 
                }
        }
        
        
        public IEnumerable< Currency> Currencies
        {
            get {           
                
                foreach(Currency currency in CurrencyList())
                    yield return currency; 
                }         
        }    
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.CountryRegionCode = (string)reader[COL_COUNTRYREGIONCODE];
			this.Name = (string)reader[COL_NAME];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_COUNTRYREGION))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.CountryRegionCode, PARAM_COUNTRYREGIONCODE));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_COUNTRYREGION))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CountryRegionCode, PARAM_COUNTRYREGIONCODE));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_COUNTRYREGION))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CountryRegionCode, PARAM_COUNTRYREGIONCODE));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public StateProvince GetStateProvincesQuery()
        {
            return new StateProvince {                
                                                                            CountryRegionCode = this.CountryRegionCode  
                                                                            };
        }
        
        public StateProvince[] StateProvinceList()
        {
            return GetStateProvincesQuery().ToList();
        }  
        
        public CountryRegionCurrency GetCountryRegionCurrenciesQuery()
        {
            return new CountryRegionCurrency {                
                                                                            CountryRegionCode = this.CountryRegionCode  
                                                                            };
        }
        
        public CountryRegionCurrency[] CountryRegionCurrencyList()
        {
            return GetCountryRegionCurrenciesQuery().ToList();
        }  
        
        
        
        public Currency[] CurrencyList()
        {
            string sqlQuery = @"SELECT Sales.Currency.*
                                FROM Sales.CountryRegionCurrency
                                INNER JOIN Sales.Currency ON                                                                            
                                Sales.CountryRegionCurrency.[CurrencyCode] = Sales.Currency.[CurrencyCode] AND
                                Sales.CountryRegionCurrency.[CountryRegionCode] = @CountryRegionCode  
                                ";
                                
            Dictionary<string, object> parameterValues = new Dictionary<string, object>();
            parameterValues.Add(PARAM_COUNTRYREGIONCODE, this.CountryRegionCode);
            
            return Currency.ToList(sqlQuery, parameterValues);
            
        }    
        
        #endregion
    }
}
