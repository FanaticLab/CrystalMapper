/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: Currency
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
    public partial class Currency : Entity< Currency>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.Currency";	
     
		public const string COL_CURRENCYCODE = "CurrencyCode";
		public const string COL_NAME = "Name";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_CURRENCYCODE = "@CurrencyCode";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_CURRENCY = "INSERT INTO Sales.Currency([CurrencyCode],[Name],[ModifiedDate]) VALUES (@CurrencyCode,@Name,@ModifiedDate);";
		
		private const string SQL_UPDATE_CURRENCY = "UPDATE Sales.Currency SET [Name] = @Name, [ModifiedDate] = @ModifiedDate,  WHERE [CurrencyCode] = @CurrencyCode";
		
		private const string SQL_DELETE_CURRENCY = "DELETE FROM Sales.Currency WHERE  [CurrencyCode] = @CurrencyCode ";
		
        #endregion
        #region Properties	
		
		[Column( COL_CURRENCYCODE, PARAM_CURRENCYCODE )]
                              public virtual string CurrencyCode  { get; set; }		
		
        
	    [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< CountryRegionCurrency> CountryRegionCurrencies
        {
            get {
                  foreach(CountryRegionCurrency countryRegionCurrency in CountryRegionCurrencyList())
                    yield return countryRegionCurrency; 
                }
        }
        
        public IEnumerable< CurrencyRate> FromCurrencyCodeCurrencyRates
        {
            get {
                  foreach(CurrencyRate currencyRate in FromCurrencyCodeCurrencyRateList())
                    yield return currencyRate; 
                }
        }
        
        public IEnumerable< CurrencyRate> ToCurrencyCodeCurrencyRates
        {
            get {
                  foreach(CurrencyRate currencyRate in ToCurrencyCodeCurrencyRateList())
                    yield return currencyRate; 
                }
        }
        
        
        public IEnumerable< CountryRegion> CountryRegions
        {
            get {           
                
                foreach(CountryRegion countryRegion in CountryRegionList())
                    yield return countryRegion; 
                }         
        }    
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.CurrencyCode = (string)reader[COL_CURRENCYCODE];
			this.Name = (string)reader[COL_NAME];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_CURRENCY))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.CurrencyCode, PARAM_CURRENCYCODE));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_CURRENCY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CurrencyCode, PARAM_CURRENCYCODE));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_CURRENCY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CurrencyCode, PARAM_CURRENCYCODE));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public CountryRegionCurrency GetCountryRegionCurrenciesQuery()
        {
            return new CountryRegionCurrency {                
                                                                            CurrencyCode = this.CurrencyCode  
                                                                            };
        }
        
        public CountryRegionCurrency[] CountryRegionCurrencyList()
        {
            return GetCountryRegionCurrenciesQuery().ToList();
        }  
        
        public CurrencyRate GetFromCurrencyCodeCurrencyRatesQuery()
        {
            return new CurrencyRate {                
                                                                            FromCurrencyCode = this.CurrencyCode  
                                                                            };
        }
        
        public CurrencyRate[] FromCurrencyCodeCurrencyRateList()
        {
            return GetFromCurrencyCodeCurrencyRatesQuery().ToList();
        }  
        
        public CurrencyRate GetToCurrencyCodeCurrencyRatesQuery()
        {
            return new CurrencyRate {                
                                                                            ToCurrencyCode = this.CurrencyCode  
                                                                            };
        }
        
        public CurrencyRate[] ToCurrencyCodeCurrencyRateList()
        {
            return GetToCurrencyCodeCurrencyRatesQuery().ToList();
        }  
        
        
        
        public CountryRegion[] CountryRegionList()
        {
            string sqlQuery = @"SELECT Person.CountryRegion.*
                                FROM Sales.CountryRegionCurrency
                                INNER JOIN Person.CountryRegion ON                                                                            
                                Sales.CountryRegionCurrency.[CountryRegionCode] = Person.CountryRegion.[CountryRegionCode] AND
                                Sales.CountryRegionCurrency.[CurrencyCode] = @CurrencyCode  
                                ";
                                
            Dictionary<string, object> parameterValues = new Dictionary<string, object>();
            parameterValues.Add(PARAM_CURRENCYCODE, this.CurrencyCode);
            
            return CountryRegion.ToList(sqlQuery, parameterValues);
            
        }    
        
        #endregion
    }
}
