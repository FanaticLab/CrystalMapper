/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: SalesTerritory
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
    public partial class SalesTerritory : Entity< SalesTerritory>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.SalesTerritory";	
     
		public const string COL_TERRITORYID = "TerritoryID";
		public const string COL_NAME = "Name";
		public const string COL_COUNTRYREGIONCODE = "CountryRegionCode";
		public const string COL_GROUP = "Group";
		public const string COL_SALESYTD = "SalesYTD";
		public const string COL_SALESLASTYEAR = "SalesLastYear";
		public const string COL_COSTYTD = "CostYTD";
		public const string COL_COSTLASTYEAR = "CostLastYear";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_TERRITORYID = "@TerritoryID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_COUNTRYREGIONCODE = "@CountryRegionCode";	
        public const string PARAM_GROUP = "@Group";	
        public const string PARAM_SALESYTD = "@SalesYTD";	
        public const string PARAM_SALESLASTYEAR = "@SalesLastYear";	
        public const string PARAM_COSTYTD = "@CostYTD";	
        public const string PARAM_COSTLASTYEAR = "@CostLastYear";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SALESTERRITORY = "INSERT INTO Sales.SalesTerritory([Name],[CountryRegionCode],[Group],[SalesYTD],[SalesLastYear],[CostYTD],[CostLastYear],[rowguid],[ModifiedDate]) VALUES (@Name,@CountryRegionCode,@Group,@SalesYTD,@SalesLastYear,@CostYTD,@CostLastYear,@rowguid,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_SALESTERRITORY = "UPDATE Sales.SalesTerritory SET  [Name] = @Name, [CountryRegionCode] = @CountryRegionCode, [Group] = @Group, [SalesYTD] = @SalesYTD, [SalesLastYear] = @SalesLastYear, [CostYTD] = @CostYTD, [CostLastYear] = @CostLastYear, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate WHERE [TerritoryID] = @TerritoryID";
		
		private const string SQL_DELETE_SALESTERRITORY = "DELETE FROM Sales.SalesTerritory WHERE  [TerritoryID] = @TerritoryID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int territoryid = default(int);
	
		protected string name = default(string);
	
		protected string countryregioncode = default(string);
	
		protected string group = default(string);
	
		protected decimal salesytd = default(decimal);
	
		protected decimal saleslastyear = default(decimal);
	
		protected decimal costytd = default(decimal);
	
		protected decimal costlastyear = default(decimal);
	
		protected System.Guid rowguid = default(System.Guid);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected CountryRegion countryRegionEntity;
	
        protected EntityCollection< StateProvince> stateProvinces ;
        
        protected EntityCollection< Customer> customers ;
        
        protected EntityCollection< SalesOrderHeader> salesOrderHeaders ;
        
        protected EntityCollection< SalesPerson> salesPeople ;
        
        protected EntityCollection< SalesTerritoryHistory> salesTerritoryHistories ;
        
        #endregion

 		#region Properties	

        [Column( COL_TERRITORYID, PARAM_TERRITORYID, default(int))]
                              public virtual int TerritoryID 
        {
            get { return this.territoryid; }
			set	{ 
                  if(this.territoryid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("TerritoryID"));  
                        this.territoryid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("TerritoryID"));
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
		
        [Column( COL_GROUP, PARAM_GROUP )]
                              public virtual string Group 
        {
            get { return this.group; }
			set	{ 
                  if(this.group != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Group"));  
                        this.group = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Group"));
                    }   
                }
        }	
		
        [Column( COL_SALESYTD, PARAM_SALESYTD, typeof(decimal))]
                              public virtual decimal SalesYTD 
        {
            get { return this.salesytd; }
			set	{ 
                  if(this.salesytd != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SalesYTD"));  
                        this.salesytd = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SalesYTD"));
                    }   
                }
        }	
		
        [Column( COL_SALESLASTYEAR, PARAM_SALESLASTYEAR, typeof(decimal))]
                              public virtual decimal SalesLastYear 
        {
            get { return this.saleslastyear; }
			set	{ 
                  if(this.saleslastyear != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SalesLastYear"));  
                        this.saleslastyear = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SalesLastYear"));
                    }   
                }
        }	
		
        [Column( COL_COSTYTD, PARAM_COSTYTD, typeof(decimal))]
                              public virtual decimal CostYTD 
        {
            get { return this.costytd; }
			set	{ 
                  if(this.costytd != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CostYTD"));  
                        this.costytd = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CostYTD"));
                    }   
                }
        }	
		
        [Column( COL_COSTLASTYEAR, PARAM_COSTLASTYEAR, typeof(decimal))]
                              public virtual decimal CostLastYear 
        {
            get { return this.costlastyear; }
			set	{ 
                  if(this.costlastyear != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CostLastYear"));  
                        this.costlastyear = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CostLastYear"));
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
		
        public EntityCollection< StateProvince> StateProvinces 
        {
            get { return this.stateProvinces;}
        }
        
        public EntityCollection< Customer> Customers 
        {
            get { return this.customers;}
        }
        
        public EntityCollection< SalesOrderHeader> SalesOrderHeaders 
        {
            get { return this.salesOrderHeaders;}
        }
        
        public EntityCollection< SalesPerson> SalesPeople 
        {
            get { return this.salesPeople;}
        }
        
        public EntityCollection< SalesTerritoryHistory> SalesTerritoryHistories 
        {
            get { return this.salesTerritoryHistories;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public SalesTerritory()
        {
             this.stateProvinces = new EntityCollection< StateProvince>(this, new Associate< StateProvince>(this.AssociateStateProvinces), new DeAssociate< StateProvince>(this.DeAssociateStateProvinces), new GetChildren< StateProvince>(this.GetChildrenStateProvinces));
             this.customers = new EntityCollection< Customer>(this, new Associate< Customer>(this.AssociateCustomers), new DeAssociate< Customer>(this.DeAssociateCustomers), new GetChildren< Customer>(this.GetChildrenCustomers));
             this.salesOrderHeaders = new EntityCollection< SalesOrderHeader>(this, new Associate< SalesOrderHeader>(this.AssociateSalesOrderHeaders), new DeAssociate< SalesOrderHeader>(this.DeAssociateSalesOrderHeaders), new GetChildren< SalesOrderHeader>(this.GetChildrenSalesOrderHeaders));
             this.salesPeople = new EntityCollection< SalesPerson>(this, new Associate< SalesPerson>(this.AssociateSalesPeople), new DeAssociate< SalesPerson>(this.DeAssociateSalesPeople), new GetChildren< SalesPerson>(this.GetChildrenSalesPeople));
             this.salesTerritoryHistories = new EntityCollection< SalesTerritoryHistory>(this, new Associate< SalesTerritoryHistory>(this.AssociateSalesTerritoryHistories), new DeAssociate< SalesTerritoryHistory>(this.DeAssociateSalesTerritoryHistories), new GetChildren< SalesTerritoryHistory>(this.GetChildrenSalesTerritoryHistories));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.territoryid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            SalesTerritory entity = obj as SalesTerritory;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.TerritoryID == entity.TerritoryID
                        && this.TerritoryID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.territoryid = (int)reader[COL_TERRITORYID];
			this.name = (string)reader[COL_NAME];
			this.countryregioncode = (string)reader[COL_COUNTRYREGIONCODE];
			this.group = (string)reader[COL_GROUP];
			this.salesytd = (decimal)reader[COL_SALESYTD];
			this.saleslastyear = (decimal)reader[COL_SALESLASTYEAR];
			this.costytd = (decimal)reader[COL_COSTYTD];
			this.costlastyear = (decimal)reader[COL_COSTLASTYEAR];
			this.rowguid = (System.Guid)reader[COL_ROWGUID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SALESTERRITORY))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.CountryRegionCode, PARAM_COUNTRYREGIONCODE));
				command.Parameters.Add(dataContext.CreateParameter(this.Group, PARAM_GROUP));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesYTD, PARAM_SALESYTD));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesLastYear, PARAM_SALESLASTYEAR));
				command.Parameters.Add(dataContext.CreateParameter(this.CostYTD, PARAM_COSTYTD));
				command.Parameters.Add(dataContext.CreateParameter(this.CostLastYear, PARAM_COSTLASTYEAR));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.TerritoryID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SALESTERRITORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.CountryRegionCode, PARAM_COUNTRYREGIONCODE));
				command.Parameters.Add(dataContext.CreateParameter(this.Group, PARAM_GROUP));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesYTD, PARAM_SALESYTD));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesLastYear, PARAM_SALESLASTYEAR));
				command.Parameters.Add(dataContext.CreateParameter(this.CostYTD, PARAM_COSTYTD));
				command.Parameters.Add(dataContext.CreateParameter(this.CostLastYear, PARAM_COSTLASTYEAR));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SALESTERRITORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateStateProvinces(StateProvince stateProvince)
        {
           stateProvince.SalesTerritoryEntity = this;
        }
        
        private void DeAssociateStateProvinces(StateProvince stateProvince)
        {
          if(stateProvince.SalesTerritoryEntity == this)
             stateProvince.SalesTerritoryEntity = null;
        }
        
        private StateProvince[] GetChildrenStateProvinces()
        {
            StateProvince childrenQuery = new StateProvince();
            childrenQuery.SalesTerritoryEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateCustomers(Customer customer)
        {
           customer.SalesTerritoryEntity = this;
        }
        
        private void DeAssociateCustomers(Customer customer)
        {
          if(customer.SalesTerritoryEntity == this)
             customer.SalesTerritoryEntity = null;
        }
        
        private Customer[] GetChildrenCustomers()
        {
            Customer childrenQuery = new Customer();
            childrenQuery.SalesTerritoryEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateSalesOrderHeaders(SalesOrderHeader salesOrderHeader)
        {
           salesOrderHeader.SalesTerritoryEntity = this;
        }
        
        private void DeAssociateSalesOrderHeaders(SalesOrderHeader salesOrderHeader)
        {
          if(salesOrderHeader.SalesTerritoryEntity == this)
             salesOrderHeader.SalesTerritoryEntity = null;
        }
        
        private SalesOrderHeader[] GetChildrenSalesOrderHeaders()
        {
            SalesOrderHeader childrenQuery = new SalesOrderHeader();
            childrenQuery.SalesTerritoryEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateSalesPeople(SalesPerson salesPerson)
        {
           salesPerson.SalesTerritoryEntity = this;
        }
        
        private void DeAssociateSalesPeople(SalesPerson salesPerson)
        {
          if(salesPerson.SalesTerritoryEntity == this)
             salesPerson.SalesTerritoryEntity = null;
        }
        
        private SalesPerson[] GetChildrenSalesPeople()
        {
            SalesPerson childrenQuery = new SalesPerson();
            childrenQuery.SalesTerritoryEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateSalesTerritoryHistories(SalesTerritoryHistory salesTerritoryHistory)
        {
           salesTerritoryHistory.SalesTerritoryEntity = this;
        }
        
        private void DeAssociateSalesTerritoryHistories(SalesTerritoryHistory salesTerritoryHistory)
        {
          if(salesTerritoryHistory.SalesTerritoryEntity == this)
             salesTerritoryHistory.SalesTerritoryEntity = null;
        }
        
        private SalesTerritoryHistory[] GetChildrenSalesTerritoryHistories()
        {
            SalesTerritoryHistory childrenQuery = new SalesTerritoryHistory();
            childrenQuery.SalesTerritoryEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
