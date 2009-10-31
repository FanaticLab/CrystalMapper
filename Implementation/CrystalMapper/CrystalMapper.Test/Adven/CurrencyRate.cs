/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: CurrencyRate
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
    public partial class CurrencyRate : Entity< CurrencyRate>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.CurrencyRate";	
     
		public const string COL_CURRENCYRATEID = "CurrencyRateID";
		public const string COL_CURRENCYRATEDATE = "CurrencyRateDate";
		public const string COL_FROMCURRENCYCODE = "FromCurrencyCode";
		public const string COL_TOCURRENCYCODE = "ToCurrencyCode";
		public const string COL_AVERAGERATE = "AverageRate";
		public const string COL_ENDOFDAYRATE = "EndOfDayRate";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_CURRENCYRATEID = "@CurrencyRateID";	
        public const string PARAM_CURRENCYRATEDATE = "@CurrencyRateDate";	
        public const string PARAM_FROMCURRENCYCODE = "@FromCurrencyCode";	
        public const string PARAM_TOCURRENCYCODE = "@ToCurrencyCode";	
        public const string PARAM_AVERAGERATE = "@AverageRate";	
        public const string PARAM_ENDOFDAYRATE = "@EndOfDayRate";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_CURRENCYRATE = "INSERT INTO Sales.CurrencyRate([CurrencyRateDate],[FromCurrencyCode],[ToCurrencyCode],[AverageRate],[EndOfDayRate],[ModifiedDate]) VALUES (@CurrencyRateDate,@FromCurrencyCode,@ToCurrencyCode,@AverageRate,@EndOfDayRate,@ModifiedDate);";
		
		private const string SQL_UPDATE_CURRENCYRATE = "UPDATE Sales.CurrencyRate SET [CurrencyRateDate] = @CurrencyRateDate, [FromCurrencyCode] = @FromCurrencyCode, [ToCurrencyCode] = @ToCurrencyCode, [AverageRate] = @AverageRate, [EndOfDayRate] = @EndOfDayRate, [ModifiedDate] = @ModifiedDate,  WHERE [CurrencyRateID] = @CurrencyRateID";
		
		private const string SQL_DELETE_CURRENCYRATE = "DELETE FROM Sales.CurrencyRate WHERE  [CurrencyRateID] = @CurrencyRateID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_CURRENCYRATEID, PARAM_CURRENCYRATEID, default(int))]
                              public virtual int CurrencyRateID  { get; set; }		
		
        
	    [Column( COL_CURRENCYRATEDATE, PARAM_CURRENCYRATEDATE, typeof(System.DateTime))]
                              public virtual System.DateTime CurrencyRateDate  { get; set; }	      
        
	    [Column( COL_FROMCURRENCYCODE, PARAM_FROMCURRENCYCODE )]
                              public virtual string FromCurrencyCode  { get; set; }	      
        
	    [Column( COL_TOCURRENCYCODE, PARAM_TOCURRENCYCODE )]
                              public virtual string ToCurrencyCode  { get; set; }	      
        
	    [Column( COL_AVERAGERATE, PARAM_AVERAGERATE, typeof(decimal))]
                              public virtual decimal AverageRate  { get; set; }	      
        
	    [Column( COL_ENDOFDAYRATE, PARAM_ENDOFDAYRATE, typeof(decimal))]
                              public virtual decimal EndOfDayRate  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< SalesOrderHeader> SalesOrderHeaders
        {
            get {
                  foreach(SalesOrderHeader salesOrderHeader in SalesOrderHeaderList())
                    yield return salesOrderHeader; 
                }
        }
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.CurrencyRateID = (int)reader[COL_CURRENCYRATEID];
			this.CurrencyRateDate = (System.DateTime)reader[COL_CURRENCYRATEDATE];
			this.FromCurrencyCode = (string)reader[COL_FROMCURRENCYCODE];
			this.ToCurrencyCode = (string)reader[COL_TOCURRENCYCODE];
			this.AverageRate = (decimal)reader[COL_AVERAGERATE];
			this.EndOfDayRate = (decimal)reader[COL_ENDOFDAYRATE];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_CURRENCYRATE))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.CurrencyRateDate, PARAM_CURRENCYRATEDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.FromCurrencyCode, PARAM_FROMCURRENCYCODE));
				command.Parameters.Add(dataContext.CreateParameter(this.ToCurrencyCode, PARAM_TOCURRENCYCODE));
				command.Parameters.Add(dataContext.CreateParameter(this.AverageRate, PARAM_AVERAGERATE));
				command.Parameters.Add(dataContext.CreateParameter(this.EndOfDayRate, PARAM_ENDOFDAYRATE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.CurrencyRateID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_CURRENCYRATE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CurrencyRateID, PARAM_CURRENCYRATEID));
				command.Parameters.Add(dataContext.CreateParameter(this.CurrencyRateDate, PARAM_CURRENCYRATEDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.FromCurrencyCode, PARAM_FROMCURRENCYCODE));
				command.Parameters.Add(dataContext.CreateParameter(this.ToCurrencyCode, PARAM_TOCURRENCYCODE));
				command.Parameters.Add(dataContext.CreateParameter(this.AverageRate, PARAM_AVERAGERATE));
				command.Parameters.Add(dataContext.CreateParameter(this.EndOfDayRate, PARAM_ENDOFDAYRATE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_CURRENCYRATE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CurrencyRateID, PARAM_CURRENCYRATEID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public SalesOrderHeader GetSalesOrderHeadersQuery()
        {
            return new SalesOrderHeader {                
                                                                            CurrencyRateID = this.CurrencyRateID  
                                                                            };
        }
        
        public SalesOrderHeader[] SalesOrderHeaderList()
        {
            return GetSalesOrderHeadersQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
