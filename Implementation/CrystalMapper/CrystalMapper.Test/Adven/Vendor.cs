/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: Vendor
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
    public partial class Vendor : Entity< Vendor>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Purchasing.Vendor";	
     
		public const string COL_BUSINESSENTITYID = "BusinessEntityID";
		public const string COL_ACCOUNTNUMBER = "AccountNumber";
		public const string COL_NAME = "Name";
		public const string COL_CREDITRATING = "CreditRating";
		public const string COL_PREFERREDVENDORSTATUS = "PreferredVendorStatus";
		public const string COL_ACTIVEFLAG = "ActiveFlag";
		public const string COL_PURCHASINGWEBSERVICEURL = "PurchasingWebServiceURL";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_BUSINESSENTITYID = "@BusinessEntityID";	
        public const string PARAM_ACCOUNTNUMBER = "@AccountNumber";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_CREDITRATING = "@CreditRating";	
        public const string PARAM_PREFERREDVENDORSTATUS = "@PreferredVendorStatus";	
        public const string PARAM_ACTIVEFLAG = "@ActiveFlag";	
        public const string PARAM_PURCHASINGWEBSERVICEURL = "@PurchasingWebServiceURL";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_VENDOR = "INSERT INTO Purchasing.Vendor([BusinessEntityID],[AccountNumber],[Name],[CreditRating],[PreferredVendorStatus],[ActiveFlag],[PurchasingWebServiceURL],[ModifiedDate]) VALUES (@BusinessEntityID,@AccountNumber,@Name,@CreditRating,@PreferredVendorStatus,@ActiveFlag,@PurchasingWebServiceURL,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_VENDOR = "UPDATE Purchasing.Vendor SET  [AccountNumber] = @AccountNumber, [Name] = @Name, [CreditRating] = @CreditRating, [PreferredVendorStatus] = @PreferredVendorStatus, [ActiveFlag] = @ActiveFlag, [PurchasingWebServiceURL] = @PurchasingWebServiceURL, [ModifiedDate] = @ModifiedDate WHERE [BusinessEntityID] = @BusinessEntityID";
		
		private const string SQL_DELETE_VENDOR = "DELETE FROM Purchasing.Vendor WHERE  [BusinessEntityID] = @BusinessEntityID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int businessentityid = default(int);
	
		protected string accountnumber = default(string);
	
		protected string name = default(string);
	
		protected byte creditrating = default(byte);
	
		protected bool preferredvendorstatus = default(bool);
	
		protected bool activeflag = default(bool);
	
		protected string purchasingwebserviceurl = default(string);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected BusinessEntity businessEntityEntity;
	
        protected EntityCollection< ProductVendor> productVendors ;
        
        protected EntityCollection< PurchaseOrderHeader> purchaseOrderHeaders ;
        
        #endregion

 		#region Properties	

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
		
        [Column( COL_CREDITRATING, PARAM_CREDITRATING, default(byte))]
                              public virtual byte CreditRating 
        {
            get { return this.creditrating; }
			set	{ 
                  if(this.creditrating != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CreditRating"));  
                        this.creditrating = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CreditRating"));
                    }   
                }
        }	
		
        [Column( COL_PREFERREDVENDORSTATUS, PARAM_PREFERREDVENDORSTATUS, default(bool))]
                              public virtual bool PreferredVendorStatus 
        {
            get { return this.preferredvendorstatus; }
			set	{ 
                  if(this.preferredvendorstatus != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("PreferredVendorStatus"));  
                        this.preferredvendorstatus = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("PreferredVendorStatus"));
                    }   
                }
        }	
		
        [Column( COL_ACTIVEFLAG, PARAM_ACTIVEFLAG, default(bool))]
                              public virtual bool ActiveFlag 
        {
            get { return this.activeflag; }
			set	{ 
                  if(this.activeflag != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ActiveFlag"));  
                        this.activeflag = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ActiveFlag"));
                    }   
                }
        }	
		
        [Column( COL_PURCHASINGWEBSERVICEURL, PARAM_PURCHASINGWEBSERVICEURL )]
                              public virtual string PurchasingWebServiceURL 
        {
            get { return this.purchasingwebserviceurl; }
			set	{ 
                  if(this.purchasingwebserviceurl != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("PurchasingWebServiceURL"));  
                        this.purchasingwebserviceurl = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("PurchasingWebServiceURL"));
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
		
        public EntityCollection< ProductVendor> ProductVendors 
        {
            get { return this.productVendors;}
        }
        
        public EntityCollection< PurchaseOrderHeader> PurchaseOrderHeaders 
        {
            get { return this.purchaseOrderHeaders;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public Vendor()
        {
             this.productVendors = new EntityCollection< ProductVendor>(this, new Associate< ProductVendor>(this.AssociateProductVendors), new DeAssociate< ProductVendor>(this.DeAssociateProductVendors), new GetChildren< ProductVendor>(this.GetChildrenProductVendors));
             this.purchaseOrderHeaders = new EntityCollection< PurchaseOrderHeader>(this, new Associate< PurchaseOrderHeader>(this.AssociatePurchaseOrderHeaders), new DeAssociate< PurchaseOrderHeader>(this.DeAssociatePurchaseOrderHeaders), new GetChildren< PurchaseOrderHeader>(this.GetChildrenPurchaseOrderHeaders));
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
            Vendor entity = obj as Vendor;           
            
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
			this.accountnumber = (string)reader[COL_ACCOUNTNUMBER];
			this.name = (string)reader[COL_NAME];
			this.creditrating = (byte)reader[COL_CREDITRATING];
			this.preferredvendorstatus = (bool)reader[COL_PREFERREDVENDORSTATUS];
			this.activeflag = (bool)reader[COL_ACTIVEFLAG];
			this.purchasingwebserviceurl = DbConvert.ToString(reader[COL_PURCHASINGWEBSERVICEURL]);
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_VENDOR))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));
				command.Parameters.Add(dataContext.CreateParameter(this.AccountNumber, PARAM_ACCOUNTNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.CreditRating, PARAM_CREDITRATING));
				command.Parameters.Add(dataContext.CreateParameter(this.PreferredVendorStatus, PARAM_PREFERREDVENDORSTATUS));
				command.Parameters.Add(dataContext.CreateParameter(this.ActiveFlag, PARAM_ACTIVEFLAG));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.PurchasingWebServiceURL), PARAM_PURCHASINGWEBSERVICEURL));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_VENDOR))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));
				command.Parameters.Add(dataContext.CreateParameter(this.AccountNumber, PARAM_ACCOUNTNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.CreditRating, PARAM_CREDITRATING));
				command.Parameters.Add(dataContext.CreateParameter(this.PreferredVendorStatus, PARAM_PREFERREDVENDORSTATUS));
				command.Parameters.Add(dataContext.CreateParameter(this.ActiveFlag, PARAM_ACTIVEFLAG));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.PurchasingWebServiceURL), PARAM_PURCHASINGWEBSERVICEURL));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_VENDOR))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateProductVendors(ProductVendor productVendor)
        {
           productVendor.VendorEntity = this;
        }
        
        private void DeAssociateProductVendors(ProductVendor productVendor)
        {
          if(productVendor.VendorEntity == this)
             productVendor.VendorEntity = null;
        }
        
        private ProductVendor[] GetChildrenProductVendors()
        {
            ProductVendor childrenQuery = new ProductVendor();
            childrenQuery.VendorEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociatePurchaseOrderHeaders(PurchaseOrderHeader purchaseOrderHeader)
        {
           purchaseOrderHeader.VendorEntity = this;
        }
        
        private void DeAssociatePurchaseOrderHeaders(PurchaseOrderHeader purchaseOrderHeader)
        {
          if(purchaseOrderHeader.VendorEntity == this)
             purchaseOrderHeader.VendorEntity = null;
        }
        
        private PurchaseOrderHeader[] GetChildrenPurchaseOrderHeaders()
        {
            PurchaseOrderHeader childrenQuery = new PurchaseOrderHeader();
            childrenQuery.VendorEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
