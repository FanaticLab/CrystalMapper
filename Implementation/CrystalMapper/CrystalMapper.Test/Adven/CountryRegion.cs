/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: CountryRegion
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
		
		private const string SQL_INSERT_COUNTRYREGION = "INSERT INTO Person.CountryRegion([CountryRegionCode],[Name],[ModifiedDate]) VALUES (@CountryRegionCode,@Name,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_COUNTRYREGION = "UPDATE Person.CountryRegion SET  [Name] = @Name, [ModifiedDate] = @ModifiedDate WHERE [CountryRegionCode] = @CountryRegionCode";
		
		private const string SQL_DELETE_COUNTRYREGION = "DELETE FROM Person.CountryRegion WHERE  [CountryRegionCode] = @CountryRegionCode ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected string countryregioncode = default(string);
	
		protected string name = default(string);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
        protected EntityCollection< StateProvince> stateProvinces ;
        
        protected EntityCollection< CountryRegionCurrency> countryRegionCurrencies ;
        
        protected EntityCollection< SalesTerritory> salesTerritories ;
        
        #endregion

 		#region Properties	

        [Column( COL_COUNTRYREGIONCODE, PARAM_COUNTRYREGIONCODE )]
                              public virtual string CountryRegionCode 
        {
            get { return this.countryregioncode; }
			set	{ 
                  if(this.countryregioncode != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CountryRegionCode"));  
                        this.countryregioncode = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CountryRegionCode"));
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
		
        public EntityCollection< StateProvince> StateProvinces 
        {
            get { return this.stateProvinces;}
        }
        
        public EntityCollection< CountryRegionCurrency> CountryRegionCurrencies 
        {
            get { return this.countryRegionCurrencies;}
        }
        
        public EntityCollection< SalesTerritory> SalesTerritories 
        {
            get { return this.salesTerritories;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public CountryRegion()
        {
             this.stateProvinces = new EntityCollection< StateProvince>(this, new Associate< StateProvince>(this.AssociateStateProvinces), new DeAssociate< StateProvince>(this.DeAssociateStateProvinces), new GetChildren< StateProvince>(this.GetChildrenStateProvinces));
             this.countryRegionCurrencies = new EntityCollection< CountryRegionCurrency>(this, new Associate< CountryRegionCurrency>(this.AssociateCountryRegionCurrencies), new DeAssociate< CountryRegionCurrency>(this.DeAssociateCountryRegionCurrencies), new GetChildren< CountryRegionCurrency>(this.GetChildrenCountryRegionCurrencies));
             this.salesTerritories = new EntityCollection< SalesTerritory>(this, new Associate< SalesTerritory>(this.AssociateSalesTerritories), new DeAssociate< SalesTerritory>(this.DeAssociateSalesTerritories), new GetChildren< SalesTerritory>(this.GetChildrenSalesTerritories));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.countryregioncode.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            CountryRegion entity = obj as CountryRegion;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.CountryRegionCode == entity.CountryRegionCode
                        && this.CountryRegionCode != default(string)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.countryregioncode = (string)reader[COL_COUNTRYREGIONCODE];
			this.name = (string)reader[COL_NAME];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
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
        
        #region Entity Relationship Functions
        
        private void AssociateStateProvinces(StateProvince stateProvince)
        {
           stateProvince.CountryRegionEntity = this;
        }
        
        private void DeAssociateStateProvinces(StateProvince stateProvince)
        {
          if(stateProvince.CountryRegionEntity == this)
             stateProvince.CountryRegionEntity = null;
        }
        
        private StateProvince[] GetChildrenStateProvinces()
        {
            StateProvince childrenQuery = new StateProvince();
            childrenQuery.CountryRegionEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateCountryRegionCurrencies(CountryRegionCurrency countryRegionCurrency)
        {
           countryRegionCurrency.CountryRegionEntity = this;
        }
        
        private void DeAssociateCountryRegionCurrencies(CountryRegionCurrency countryRegionCurrency)
        {
          if(countryRegionCurrency.CountryRegionEntity == this)
             countryRegionCurrency.CountryRegionEntity = null;
        }
        
        private CountryRegionCurrency[] GetChildrenCountryRegionCurrencies()
        {
            CountryRegionCurrency childrenQuery = new CountryRegionCurrency();
            childrenQuery.CountryRegionEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateSalesTerritories(SalesTerritory salesTerritory)
        {
           salesTerritory.CountryRegionEntity = this;
        }
        
        private void DeAssociateSalesTerritories(SalesTerritory salesTerritory)
        {
          if(salesTerritory.CountryRegionEntity == this)
             salesTerritory.CountryRegionEntity = null;
        }
        
        private SalesTerritory[] GetChildrenSalesTerritories()
        {
            SalesTerritory childrenQuery = new SalesTerritory();
            childrenQuery.CountryRegionEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
