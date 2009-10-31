/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: CountryRegionCurrency
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
    public partial class CountryRegionCurrency : Entity< CountryRegionCurrency>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.CountryRegionCurrency";	
     
		public const string COL_COUNTRYREGIONCODE = "CountryRegionCode";
		public const string COL_CURRENCYCODE = "CurrencyCode";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_COUNTRYREGIONCODE = "@CountryRegionCode";	
        public const string PARAM_CURRENCYCODE = "@CurrencyCode";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_COUNTRYREGIONCURRENCY = "INSERT INTO Sales.CountryRegionCurrency([CountryRegionCode],[CurrencyCode],[ModifiedDate]) VALUES (@CountryRegionCode,@CurrencyCode,@ModifiedDate);";
		
		private const string SQL_UPDATE_COUNTRYREGIONCURRENCY = "UPDATE Sales.CountryRegionCurrency SET [ModifiedDate] = @ModifiedDate,  WHERE [CountryRegionCode] = @CountryRegionCode AND [CurrencyCode] = @CurrencyCode";
		
		private const string SQL_DELETE_COUNTRYREGIONCURRENCY = "DELETE FROM Sales.CountryRegionCurrency WHERE  [CountryRegionCode] = @CountryRegionCode AND [CurrencyCode] = @CurrencyCode ";
		
        #endregion
        #region Properties	
		
		[Column( COL_COUNTRYREGIONCODE, PARAM_COUNTRYREGIONCODE )]
                              public virtual string CountryRegionCode  { get; set; }		
		[Column( COL_CURRENCYCODE, PARAM_CURRENCYCODE )]
                              public virtual string CurrencyCode  { get; set; }		
		
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.CountryRegionCode = (string)reader[COL_COUNTRYREGIONCODE];
			this.CurrencyCode = (string)reader[COL_CURRENCYCODE];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_COUNTRYREGIONCURRENCY))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.CountryRegionCode, PARAM_COUNTRYREGIONCODE));
				command.Parameters.Add(dataContext.CreateParameter(this.CurrencyCode, PARAM_CURRENCYCODE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_COUNTRYREGIONCURRENCY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CountryRegionCode, PARAM_COUNTRYREGIONCODE));
				command.Parameters.Add(dataContext.CreateParameter(this.CurrencyCode, PARAM_CURRENCYCODE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_COUNTRYREGIONCURRENCY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CountryRegionCode, PARAM_COUNTRYREGIONCODE));				
				command.Parameters.Add(dataContext.CreateParameter(this.CurrencyCode, PARAM_CURRENCYCODE));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
