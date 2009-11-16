/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: CountryRegionCurrency
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
		
		private const string SQL_INSERT_COUNTRYREGIONCURRENCY = "INSERT INTO Sales.CountryRegionCurrency([CountryRegionCode],[CurrencyCode],[ModifiedDate]) VALUES (@CountryRegionCode,@CurrencyCode,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_COUNTRYREGIONCURRENCY = "UPDATE Sales.CountryRegionCurrency SET  [ModifiedDate] = @ModifiedDate WHERE [CountryRegionCode] = @CountryRegionCode AND [CurrencyCode] = @CurrencyCode";
		
		private const string SQL_DELETE_COUNTRYREGIONCURRENCY = "DELETE FROM Sales.CountryRegionCurrency WHERE  [CountryRegionCode] = @CountryRegionCode AND [CurrencyCode] = @CurrencyCode ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected string countryregioncode = default(string);
	
		protected string currencycode = default(string);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected CountryRegion countryRegionEntity;
	
		protected Currency currencyEntity;
	
        #endregion

 		#region Properties	

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
		
        [Column( COL_COUNTRYREGIONCODE, PARAM_COUNTRYREGIONCODE )]
                              public virtual string CountryRegionCode                
        {
            get
            {
                if(this.countryRegionEntity == null)
                    return this.countryregioncode ;
                
                return this.countryRegionEntity.CountryRegionCode;            
            }
            set
            {
                if(this.countryregioncode != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("CountryRegionCode"));                    
                    this.countryregioncode = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("CountryRegionCode"));
                    
                    this.countryRegionEntity = null;
                }                
            }          
        }	
        
        [Column( COL_CURRENCYCODE, PARAM_CURRENCYCODE )]
                              public virtual string CurrencyCode                
        {
            get
            {
                if(this.currencyEntity == null)
                    return this.currencycode ;
                
                return this.currencyEntity.CurrencyCode;            
            }
            set
            {
                if(this.currencycode != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("CurrencyCode"));                    
                    this.currencycode = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("CurrencyCode"));
                    
                    this.currencyEntity = null;
                }                
            }          
        }	
        
        public CountryRegion CountryRegionEntity
        {
            get { 
                    if(this.countryRegionEntity == null
                       && this.countryregioncode != default(string)) 
                    {
                        CountryRegion countryRegionQuery = new CountryRegion {
                                                        CountryRegionCode = this.countryregioncode  
                                                        };
                        
                        CountryRegion[]  countryRegions = countryRegionQuery.ToList();                        
                        if(countryRegions.Length == 1)
                            this.countryRegionEntity = countryRegions[0];                        
                    }
                    
                    return this.countryRegionEntity; 
                }
			set	{ 
                  if(this.countryRegionEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CountryRegionEntity"));
                        if (this.countryRegionEntity != null)
                            this.Parents.Remove(this.countryRegionEntity);                            
                        
                        if((this.countryRegionEntity = value) != null) 
                            this.Parents.Add(this.countryRegionEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CountryRegionEntity"));
                        
                        this.countryregioncode = this.CountryRegionEntity.CountryRegionCode;
                    }   
                }
        }	
		
        public Currency CurrencyEntity
        {
            get { 
                    if(this.currencyEntity == null
                       && this.currencycode != default(string)) 
                    {
                        Currency currencyQuery = new Currency {
                                                        CurrencyCode = this.currencycode  
                                                        };
                        
                        Currency[]  currencies = currencyQuery.ToList();                        
                        if(currencies.Length == 1)
                            this.currencyEntity = currencies[0];                        
                    }
                    
                    return this.currencyEntity; 
                }
			set	{ 
                  if(this.currencyEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CurrencyEntity"));
                        if (this.currencyEntity != null)
                            this.Parents.Remove(this.currencyEntity);                            
                        
                        if((this.currencyEntity = value) != null) 
                            this.Parents.Add(this.currencyEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CurrencyEntity"));
                        
                        this.currencycode = this.CurrencyEntity.CurrencyCode;
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
		
        public CountryRegionCurrency()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.countryregioncode.GetHashCode();
                result = (11 * result) + this.currencycode.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            CountryRegionCurrency entity = obj as CountryRegionCurrency;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.CountryRegionCode == entity.CountryRegionCode
                        && this.CurrencyCode == entity.CurrencyCode
                        && this.CountryRegionCode != default(string)
                        && this.CurrencyCode != default(string)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.countryregioncode = (string)reader[COL_COUNTRYREGIONCODE];
			this.currencycode = (string)reader[COL_CURRENCYCODE];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
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
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
