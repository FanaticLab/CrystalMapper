/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: Customer
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
    public partial class Customer : Entity< Customer>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.Customer";	
     
		public const string COL_CUSTOMERID = "CustomerID";
		public const string COL_PERSONID = "PersonID";
		public const string COL_STOREID = "StoreID";
		public const string COL_TERRITORYID = "TerritoryID";
		public const string COL_ACCOUNTNUMBER = "AccountNumber";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_CUSTOMERID = "@CustomerID";	
        public const string PARAM_PERSONID = "@PersonID";	
        public const string PARAM_STOREID = "@StoreID";	
        public const string PARAM_TERRITORYID = "@TerritoryID";	
        public const string PARAM_ACCOUNTNUMBER = "@AccountNumber";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_CUSTOMER = "INSERT INTO Sales.Customer([PersonID],[StoreID],[TerritoryID],[AccountNumber],[rowguid],[ModifiedDate]) VALUES (@PersonID,@StoreID,@TerritoryID,@AccountNumber,@rowguid,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_CUSTOMER = "UPDATE Sales.Customer SET  [PersonID] = @PersonID, [StoreID] = @StoreID, [TerritoryID] = @TerritoryID, [AccountNumber] = @AccountNumber, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate WHERE [CustomerID] = @CustomerID";
		
		private const string SQL_DELETE_CUSTOMER = "DELETE FROM Sales.Customer WHERE  [CustomerID] = @CustomerID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int customerid = default(int);
	
		protected int? personid = default(int?);
	
		protected int? storeid = default(int?);
	
		protected int? territoryid = default(int?);
	
		protected string accountnumber = default(string);
	
		protected System.Guid rowguid = default(System.Guid);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected Person personEntity;
	
		protected SalesTerritory salesTerritoryEntity;
	
		protected Store storeEntity;
	
        protected EntityCollection< SalesOrderHeader> salesOrderHeaders ;
        
        #endregion

 		#region Properties	

        [Column( COL_CUSTOMERID, PARAM_CUSTOMERID, default(int))]
                              public virtual int CustomerID 
        {
            get { return this.customerid; }
			set	{ 
                  if(this.customerid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CustomerID"));  
                        this.customerid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CustomerID"));
                    }   
                }
        }	
		
        [Column( COL_ACCOUNTNUMBER, PARAM_ACCOUNTNUMBER )]
                              public virtual string AccountNumber 
        {
            get { return this.accountnumber; }
			set	{ 
                  if(this.accountnumber != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("AccountNumber"));  
                        this.accountnumber = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("AccountNumber"));
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
		
        [Column( COL_PERSONID, PARAM_PERSONID )]
                              public virtual int? PersonID                
        {
            get
            {
                if(this.personEntity == null)
                    return this.personid ;
                
                return this.personEntity.BusinessEntityID;            
            }
            set
            {
                if(this.personid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("PersonID"));                    
                    this.personid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("PersonID"));
                    
                    this.personEntity = null;
                }                
            }          
        }	
        
        [Column( COL_TERRITORYID, PARAM_TERRITORYID )]
                              public virtual int? TerritoryID                
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
        
        [Column( COL_STOREID, PARAM_STOREID )]
                              public virtual int? StoreID                
        {
            get
            {
                if(this.storeEntity == null)
                    return this.storeid ;
                
                return this.storeEntity.BusinessEntityID;            
            }
            set
            {
                if(this.storeid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("StoreID"));                    
                    this.storeid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("StoreID"));
                    
                    this.storeEntity = null;
                }                
            }          
        }	
        
        public Person PersonEntity
        {
            get { 
                    if(this.personEntity == null
                       && this.personid.HasValue )
                    {
                        Person personQuery = new Person {
                                                        BusinessEntityID = this.personid.Value  
                                                        };
                        
                        Person[]  people = personQuery.ToList();                        
                        if(people.Length == 1)
                            this.personEntity = people[0];                        
                    }
                    
                    return this.personEntity; 
                }
			set	{ 
                  if(this.personEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("PersonEntity"));
                        if (this.personEntity != null)
                            this.Parents.Remove(this.personEntity);                            
                        
                        if((this.personEntity = value) != null) 
                            this.Parents.Add(this.personEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("PersonEntity"));
                        
                        this.personid = this.PersonEntity.BusinessEntityID;
                    }   
                }
        }	
		
        public SalesTerritory SalesTerritoryEntity
        {
            get { 
                    if(this.salesTerritoryEntity == null
                       && this.territoryid.HasValue )
                    {
                        SalesTerritory salesTerritoryQuery = new SalesTerritory {
                                                        TerritoryID = this.territoryid.Value  
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
		
        public Store StoreEntity
        {
            get { 
                    if(this.storeEntity == null
                       && this.storeid.HasValue )
                    {
                        Store storeQuery = new Store {
                                                        BusinessEntityID = this.storeid.Value  
                                                        };
                        
                        Store[]  stores = storeQuery.ToList();                        
                        if(stores.Length == 1)
                            this.storeEntity = stores[0];                        
                    }
                    
                    return this.storeEntity; 
                }
			set	{ 
                  if(this.storeEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("StoreEntity"));
                        if (this.storeEntity != null)
                            this.Parents.Remove(this.storeEntity);                            
                        
                        if((this.storeEntity = value) != null) 
                            this.Parents.Add(this.storeEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("StoreEntity"));
                        
                        this.storeid = this.StoreEntity.BusinessEntityID;
                    }   
                }
        }	
		
        public EntityCollection< SalesOrderHeader> SalesOrderHeaders 
        {
            get { return this.salesOrderHeaders;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public Customer()
        {
             this.salesOrderHeaders = new EntityCollection< SalesOrderHeader>(this, new Associate< SalesOrderHeader>(this.AssociateSalesOrderHeaders), new DeAssociate< SalesOrderHeader>(this.DeAssociateSalesOrderHeaders), new GetChildren< SalesOrderHeader>(this.GetChildrenSalesOrderHeaders));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.customerid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            Customer entity = obj as Customer;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.CustomerID == entity.CustomerID
                        && this.CustomerID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.customerid = (int)reader[COL_CUSTOMERID];
			this.personid = DbConvert.ToNullable< int >(reader[COL_PERSONID]);
			this.storeid = DbConvert.ToNullable< int >(reader[COL_STOREID]);
			this.territoryid = DbConvert.ToNullable< int >(reader[COL_TERRITORYID]);
			this.accountnumber = (string)reader[COL_ACCOUNTNUMBER];
			this.rowguid = (System.Guid)reader[COL_ROWGUID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_CUSTOMER))
            {	
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.PersonID), PARAM_PERSONID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.StoreID), PARAM_STOREID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.TerritoryID), PARAM_TERRITORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.AccountNumber, PARAM_ACCOUNTNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.CustomerID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_CUSTOMER))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.PersonID), PARAM_PERSONID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.StoreID), PARAM_STOREID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.TerritoryID), PARAM_TERRITORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.AccountNumber, PARAM_ACCOUNTNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_CUSTOMER))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateSalesOrderHeaders(SalesOrderHeader salesOrderHeader)
        {
           salesOrderHeader.CustomerEntity = this;
        }
        
        private void DeAssociateSalesOrderHeaders(SalesOrderHeader salesOrderHeader)
        {
          if(salesOrderHeader.CustomerEntity == this)
             salesOrderHeader.CustomerEntity = null;
        }
        
        private SalesOrderHeader[] GetChildrenSalesOrderHeaders()
        {
            SalesOrderHeader childrenQuery = new SalesOrderHeader();
            childrenQuery.CustomerEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
