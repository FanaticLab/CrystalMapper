/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: Currency
 * 
 * Email: mk.faraz@gmail.com
 * 
 * Blogs: http://csharplive.wordpress.com, http://farazmasoodkhan.wordpress.com
 *
 * Website: http://www.linkedin.com/in/farazmasoodkhan
 *
 * Copyright: Faraz Masood Khan @ Copyright 2009
 *
/*/

using System;
using System.Data.Common;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;

using CoreSystem.Data;

using CrystalMapper;
using CrystalMapper.Data;
using CrystalMapper.Mapping;

namespace feedbook.Model
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
		
		private const string SQL_INSERT_CURRENCY = "INSERT INTO Sales.Currency([CurrencyCode],[Name],[ModifiedDate]) VALUES (@CurrencyCode,@Name,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_CURRENCY = "UPDATE Sales.Currency SET  [Name] = @Name, [ModifiedDate] = @ModifiedDate WHERE [CurrencyCode] = @CurrencyCode";
		
		private const string SQL_DELETE_CURRENCY = "DELETE FROM Sales.Currency WHERE  [CurrencyCode] = @CurrencyCode ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected string currencycode = default(string);
	
		protected string name = default(string);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
        protected EntityCollection< CountryRegionCurrency> countryRegionCurrencies ;
        
        protected EntityCollection< CurrencyRate> currencyRateFromCurrencyCodes ;
        
        protected EntityCollection< CurrencyRate> currencyRateToCurrencyCodes ;
        
        #endregion

 		#region Properties	

        [Column( COL_CURRENCYCODE, PARAM_CURRENCYCODE )]
                              public virtual string CurrencyCode 
        {
            get { return this.currencycode; }
			set	{ 
                  if(this.currencycode != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CurrencyCode"));  
                        this.currencycode = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CurrencyCode"));
                    }   
                }
        }	
		
        [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name 
        {
            get { return this.name; }
			set	{ 
                  if(this.name != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Name"));  
                        this.name = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Name"));
                    }   
                }
        }	
		
        [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate 
        {
            get { return this.modifieddate; }
			set	{ 
                  if(this.modifieddate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ModifiedDate"));  
                        this.modifieddate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ModifiedDate"));
                    }   
                }
        }	
		
        public EntityCollection< CountryRegionCurrency> CountryRegionCurrencies 
        {
            get { return this.countryRegionCurrencies;}
        }
        
        public EntityCollection< CurrencyRate> CurrencyRateFromCurrencyCodes 
        {
            get { return this.currencyRateFromCurrencyCodes;}
        }
        
        public EntityCollection< CurrencyRate> CurrencyRateToCurrencyCodes 
        {
            get { return this.currencyRateToCurrencyCodes;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public Currency()
        {
             this.countryRegionCurrencies = new EntityCollection< CountryRegionCurrency>(this, new Associate< CountryRegionCurrency>(this.AssociateCountryRegionCurrencies), new DeAssociate< CountryRegionCurrency>(this.DeAssociateCountryRegionCurrencies), new GetChildren< CountryRegionCurrency>(this.GetChildrenCountryRegionCurrencies));
             this.currencyRateFromCurrencyCodes = new EntityCollection< CurrencyRate>(this, new Associate< CurrencyRate>(this.AssociateCurrencyRateFromCurrencyCodes), new DeAssociate< CurrencyRate>(this.DeAssociateCurrencyRateFromCurrencyCodes), new GetChildren< CurrencyRate>(this.GetChildrenCurrencyRateFromCurrencyCodes));
             this.currencyRateToCurrencyCodes = new EntityCollection< CurrencyRate>(this, new Associate< CurrencyRate>(this.AssociateCurrencyRateToCurrencyCodes), new DeAssociate< CurrencyRate>(this.DeAssociateCurrencyRateToCurrencyCodes), new GetChildren< CurrencyRate>(this.GetChildrenCurrencyRateToCurrencyCodes));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.currencycode.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            Currency entity = obj as Currency;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.CurrencyCode == entity.CurrencyCode
                        && this.CurrencyCode != default(string)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.currencycode = (string)reader[COL_CURRENCYCODE];
			this.name = (string)reader[COL_NAME];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
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
        
        #region Entity Relationship Functions
        
        private void AssociateCountryRegionCurrencies(CountryRegionCurrency countryRegionCurrency)
        {
           countryRegionCurrency.CurrencyEntity = this;
        }
        
        private void DeAssociateCountryRegionCurrencies(CountryRegionCurrency countryRegionCurrency)
        {
          if(countryRegionCurrency.CurrencyEntity == this)
             countryRegionCurrency.CurrencyEntity = null;
        }
        
        private CountryRegionCurrency[] GetChildrenCountryRegionCurrencies()
        {
            CountryRegionCurrency childrenQuery = new CountryRegionCurrency();
            childrenQuery.CurrencyEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateCurrencyRateFromCurrencyCodes(CurrencyRate currencyRate)
        {
           currencyRate.FromCurrencyEntity = this;
        }
        
        private void DeAssociateCurrencyRateFromCurrencyCodes(CurrencyRate currencyRate)
        {
          if(currencyRate.FromCurrencyEntity == this)
             currencyRate.FromCurrencyEntity = null;
        }
        
        private CurrencyRate[] GetChildrenCurrencyRateFromCurrencyCodes()
        {
            CurrencyRate childrenQuery = new CurrencyRate();
            childrenQuery.FromCurrencyEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateCurrencyRateToCurrencyCodes(CurrencyRate currencyRate)
        {
           currencyRate.ToCurrencyEntity = this;
        }
        
        private void DeAssociateCurrencyRateToCurrencyCodes(CurrencyRate currencyRate)
        {
          if(currencyRate.ToCurrencyEntity == this)
             currencyRate.ToCurrencyEntity = null;
        }
        
        private CurrencyRate[] GetChildrenCurrencyRateToCurrencyCodes()
        {
            CurrencyRate childrenQuery = new CurrencyRate();
            childrenQuery.ToCurrencyEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
