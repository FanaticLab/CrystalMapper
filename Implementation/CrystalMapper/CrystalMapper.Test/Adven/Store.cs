/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: Store
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
    public partial class Store : Entity< Store>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.Store";	
     
		public const string COL_BUSINESSENTITYID = "BusinessEntityID";
		public const string COL_NAME = "Name";
		public const string COL_SALESPERSONID = "SalesPersonID";
		public const string COL_DEMOGRAPHICS = "Demographics";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_BUSINESSENTITYID = "@BusinessEntityID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_SALESPERSONID = "@SalesPersonID";	
        public const string PARAM_DEMOGRAPHICS = "@Demographics";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_STORE = "INSERT INTO Sales.Store([BusinessEntityID],[Name],[SalesPersonID],[Demographics],[rowguid],[ModifiedDate]) VALUES (@BusinessEntityID,@Name,@SalesPersonID,@Demographics,@rowguid,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_STORE = "UPDATE Sales.Store SET  [Name] = @Name, [SalesPersonID] = @SalesPersonID, [Demographics] = @Demographics, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate WHERE [BusinessEntityID] = @BusinessEntityID";
		
		private const string SQL_DELETE_STORE = "DELETE FROM Sales.Store WHERE  [BusinessEntityID] = @BusinessEntityID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int businessentityid = default(int);
	
		protected string name = default(string);
	
		protected int? salespersonid = default(int?);
	
		protected System.Xml.XmlDocument demographic = default(System.Xml.XmlDocument);
	
		protected System.Guid rowguid = default(System.Guid);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected BusinessEntity businessEntityEntity;
	
		protected SalesPerson salesPersonEntity;
	
        protected EntityCollection< Customer> customers ;
        
        #endregion

 		#region Properties	

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
		
        [Column( COL_DEMOGRAPHICS, PARAM_DEMOGRAPHICS )]
                              public virtual System.Xml.XmlDocument Demographics 
        {
            get { return this.demographic; }
			set	{ 
                  if(this.demographic != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Demographics"));  
                        this.demographic = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Demographics"));
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
		
        [Column( COL_BUSINESSENTITYID, PARAM_BUSINESSENTITYID, default(int))]
                              public virtual int BusinessEntityID                
        {
            get
            {
                if(this.businessEntityEntity == null)
                    return this.businessentityid ;
                
                return this.businessEntityEntity.BusinessEntityID;            
            }
            set
            {
                if(this.businessentityid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("BusinessEntityID"));                    
                    this.businessentityid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("BusinessEntityID"));
                    
                    this.businessEntityEntity = null;
                }                
            }          
        }	
        
        [Column( COL_SALESPERSONID, PARAM_SALESPERSONID )]
                              public virtual int? SalesPersonID                
        {
            get
            {
                if(this.salesPersonEntity == null)
                    return this.salespersonid ;
                
                return this.salesPersonEntity.BusinessEntityID;            
            }
            set
            {
                if(this.salespersonid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("SalesPersonID"));                    
                    this.salespersonid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("SalesPersonID"));
                    
                    this.salesPersonEntity = null;
                }                
            }          
        }	
        
        public BusinessEntity BusinessEntityEntity
        {
            get { 
                    if(this.businessEntityEntity == null
                       && this.businessentityid != default(int)) 
                    {
                        BusinessEntity businessEntityQuery = new BusinessEntity {
                                                        BusinessEntityID = this.businessentityid  
                                                        };
                        
                        BusinessEntity[]  businessEntities = businessEntityQuery.ToList();                        
                        if(businessEntities.Length == 1)
                            this.businessEntityEntity = businessEntities[0];                        
                    }
                    
                    return this.businessEntityEntity; 
                }
			set	{ 
                  if(this.businessEntityEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("BusinessEntityEntity"));
                        if (this.businessEntityEntity != null)
                            this.Parents.Remove(this.businessEntityEntity);                            
                        
                        if((this.businessEntityEntity = value) != null) 
                            this.Parents.Add(this.businessEntityEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("BusinessEntityEntity"));
                        
                        this.businessentityid = this.BusinessEntityEntity.BusinessEntityID;
                    }   
                }
        }	
		
        public SalesPerson SalesPersonEntity
        {
            get { 
                    if(this.salesPersonEntity == null
                       && this.salespersonid.HasValue )
                    {
                        SalesPerson salesPersonQuery = new SalesPerson {
                                                        BusinessEntityID = this.salespersonid.Value  
                                                        };
                        
                        SalesPerson[]  salesPeople = salesPersonQuery.ToList();                        
                        if(salesPeople.Length == 1)
                            this.salesPersonEntity = salesPeople[0];                        
                    }
                    
                    return this.salesPersonEntity; 
                }
			set	{ 
                  if(this.salesPersonEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SalesPersonEntity"));
                        if (this.salesPersonEntity != null)
                            this.Parents.Remove(this.salesPersonEntity);                            
                        
                        if((this.salesPersonEntity = value) != null) 
                            this.Parents.Add(this.salesPersonEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SalesPersonEntity"));
                        
                        this.salespersonid = this.SalesPersonEntity.BusinessEntityID;
                    }   
                }
        }	
		
        public EntityCollection< Customer> Customers 
        {
            get { return this.customers;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public Store()
        {
             this.customers = new EntityCollection< Customer>(this, new Associate< Customer>(this.AssociateCustomers), new DeAssociate< Customer>(this.DeAssociateCustomers), new GetChildren< Customer>(this.GetChildrenCustomers));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.businessentityid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            Store entity = obj as Store;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.BusinessEntityID == entity.BusinessEntityID
                        && this.BusinessEntityID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.businessentityid = (int)reader[COL_BUSINESSENTITYID];
			this.name = (string)reader[COL_NAME];
			this.salespersonid = DbConvert.ToNullable< int >(reader[COL_SALESPERSONID]);
			this.demographic = (System.Xml.XmlDocument)reader[COL_DEMOGRAPHICS];
			this.rowguid = (System.Guid)reader[COL_ROWGUID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_STORE))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.SalesPersonID), PARAM_SALESPERSONID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Demographics), PARAM_DEMOGRAPHICS));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_STORE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.SalesPersonID), PARAM_SALESPERSONID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Demographics), PARAM_DEMOGRAPHICS));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_STORE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateCustomers(Customer customer)
        {
           customer.StoreEntity = this;
        }
        
        private void DeAssociateCustomers(Customer customer)
        {
          if(customer.StoreEntity == this)
             customer.StoreEntity = null;
        }
        
        private Customer[] GetChildrenCustomers()
        {
            Customer childrenQuery = new Customer();
            childrenQuery.StoreEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
