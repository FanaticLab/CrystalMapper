/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: StateProvince
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
		
		private const string SQL_INSERT_STATEPROVINCE = "INSERT INTO Person.StateProvince([StateProvinceCode],[CountryRegionCode],[IsOnlyStateProvinceFlag],[Name],[TerritoryID],[rowguid],[ModifiedDate]) VALUES (@StateProvinceCode,@CountryRegionCode,@IsOnlyStateProvinceFlag,@Name,@TerritoryID,@rowguid,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_STATEPROVINCE = "UPDATE Person.StateProvince SET  [StateProvinceCode] = @StateProvinceCode, [CountryRegionCode] = @CountryRegionCode, [IsOnlyStateProvinceFlag] = @IsOnlyStateProvinceFlag, [Name] = @Name, [TerritoryID] = @TerritoryID, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate WHERE [StateProvinceID] = @StateProvinceID";
		
		private const string SQL_DELETE_STATEPROVINCE = "DELETE FROM Person.StateProvince WHERE  [StateProvinceID] = @StateProvinceID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int stateprovinceid = default(int);
	
		protected string stateprovincecode = default(string);
	
		protected string countryregioncode = default(string);
	
		protected bool isonlystateprovinceflag = default(bool);
	
		protected string name = default(string);
	
		protected int territoryid = default(int);
	
		protected System.Guid rowguid = default(System.Guid);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected CountryRegion countryRegionEntity;
	
		protected SalesTerritory salesTerritoryEntity;
	
        protected EntityCollection< address> addresses ;
        
        protected EntityCollection< SalesTaxRate> salesTaxRates ;
        
        #endregion

 		#region Properties	

        [Column( COL_STATEPROVINCEID, PARAM_STATEPROVINCEID, default(int))]
                              public virtual int StateProvinceID 
        {
            get { return this.stateprovinceid; }
			set	{ 
                  if(this.stateprovinceid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("StateProvinceID"));  
                        this.stateprovinceid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("StateProvinceID"));
                    }   
                }
        }	
		
        [Column( COL_STATEPROVINCECODE, PARAM_STATEPROVINCECODE )]
                              public virtual string StateProvinceCode 
        {
            get { return this.stateprovincecode; }
			set	{ 
                  if(this.stateprovincecode != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("StateProvinceCode"));  
                        this.stateprovincecode = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("StateProvinceCode"));
                    }   
                }
        }	
		
        [Column( COL_ISONLYSTATEPROVINCEFLAG, PARAM_ISONLYSTATEPROVINCEFLAG, default(bool))]
                              public virtual bool IsOnlyStateProvinceFlag 
        {
            get { return this.isonlystateprovinceflag; }
			set	{ 
                  if(this.isonlystateprovinceflag != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("IsOnlyStateProvinceFlag"));  
                        this.isonlystateprovinceflag = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("IsOnlyStateProvinceFlag"));
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
		
        [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid 
        {
            get { return this.rowguid; }
			set	{ 
                  if(this.rowguid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Rowguid"));  
                        this.rowguid = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Rowguid"));
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
        
        [Column( COL_TERRITORYID, PARAM_TERRITORYID, default(int))]
                              public virtual int TerritoryID                
        {
            get
            {
                if(this.salesTerritoryEntity == null)
                    return this.territoryid ;
                
                return this.salesTerritoryEntity.TerritoryID;            
            }
            set
            {
                if(this.territoryid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("TerritoryID"));                    
                    this.territoryid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("TerritoryID"));
                    
                    this.salesTerritoryEntity = null;
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
		
        public SalesTerritory SalesTerritoryEntity
        {
            get { 
                    if(this.salesTerritoryEntity == null
                       && this.territoryid != default(int)) 
                    {
                        SalesTerritory salesTerritoryQuery = new SalesTerritory {
                                                        TerritoryID = this.territoryid  
                                                        };
                        
                        SalesTerritory[]  salesTerritories = salesTerritoryQuery.ToList();                        
                        if(salesTerritories.Length == 1)
                            this.salesTerritoryEntity = salesTerritories[0];                        
                    }
                    
                    return this.salesTerritoryEntity; 
                }
			set	{ 
                  if(this.salesTerritoryEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SalesTerritoryEntity"));
                        if (this.salesTerritoryEntity != null)
                            this.Parents.Remove(this.salesTerritoryEntity);                            
                        
                        if((this.salesTerritoryEntity = value) != null) 
                            this.Parents.Add(this.salesTerritoryEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SalesTerritoryEntity"));
                        
                        this.territoryid = this.SalesTerritoryEntity.TerritoryID;
                    }   
                }
        }	
		
        public EntityCollection< address> Addresses 
        {
            get { return this.addresses;}
        }
        
        public EntityCollection< SalesTaxRate> SalesTaxRates 
        {
            get { return this.salesTaxRates;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public StateProvince()
        {
             this.addresses = new EntityCollection< address>(this, new Associate< address>(this.AssociateAddresses), new DeAssociate< address>(this.DeAssociateAddresses), new GetChildren< address>(this.GetChildrenAddresses));
             this.salesTaxRates = new EntityCollection< SalesTaxRate>(this, new Associate< SalesTaxRate>(this.AssociateSalesTaxRates), new DeAssociate< SalesTaxRate>(this.DeAssociateSalesTaxRates), new GetChildren< SalesTaxRate>(this.GetChildrenSalesTaxRates));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.stateprovinceid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            StateProvince entity = obj as StateProvince;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.StateProvinceID == entity.StateProvinceID
                        && this.StateProvinceID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.stateprovinceid = (int)reader[COL_STATEPROVINCEID];
			this.stateprovincecode = (string)reader[COL_STATEPROVINCECODE];
			this.countryregioncode = (string)reader[COL_COUNTRYREGIONCODE];
			this.isonlystateprovinceflag = (bool)reader[COL_ISONLYSTATEPROVINCEFLAG];
			this.name = (string)reader[COL_NAME];
			this.territoryid = (int)reader[COL_TERRITORYID];
			this.rowguid = (System.Guid)reader[COL_ROWGUID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
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
                this.StateProvinceID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
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
        
        #region Entity Relationship Functions
        
        private void AssociateAddresses(address address)
        {
           address.StateProvinceEntity = this;
        }
        
        private void DeAssociateAddresses(address address)
        {
          if(address.StateProvinceEntity == this)
             address.StateProvinceEntity = null;
        }
        
        private address[] GetChildrenAddresses()
        {
            address childrenQuery = new address();
            childrenQuery.StateProvinceEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateSalesTaxRates(SalesTaxRate salesTaxRate)
        {
           salesTaxRate.StateProvinceEntity = this;
        }
        
        private void DeAssociateSalesTaxRates(SalesTaxRate salesTaxRate)
        {
          if(salesTaxRate.StateProvinceEntity == this)
             salesTaxRate.StateProvinceEntity = null;
        }
        
        private SalesTaxRate[] GetChildrenSalesTaxRates()
        {
            SalesTaxRate childrenQuery = new SalesTaxRate();
            childrenQuery.StateProvinceEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
