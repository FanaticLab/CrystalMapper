/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: SpecialOfferProduct
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
    public partial class SpecialOfferProduct : Entity< SpecialOfferProduct>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.SpecialOfferProduct";	
     
		public const string COL_SPECIALOFFERID = "SpecialOfferID";
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SPECIALOFFERID = "@SpecialOfferID";	
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SPECIALOFFERPRODUCT = "INSERT INTO Sales.SpecialOfferProduct([SpecialOfferID],[ProductID],[rowguid],[ModifiedDate]) VALUES (@SpecialOfferID,@ProductID,@rowguid,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_SPECIALOFFERPRODUCT = "UPDATE Sales.SpecialOfferProduct SET  [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate WHERE [SpecialOfferID] = @SpecialOfferID AND [ProductID] = @ProductID";
		
		private const string SQL_DELETE_SPECIALOFFERPRODUCT = "DELETE FROM Sales.SpecialOfferProduct WHERE  [SpecialOfferID] = @SpecialOfferID AND [ProductID] = @ProductID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int specialofferid = default(int);
	
		protected int productid = default(int);
	
		protected System.Guid rowguid = default(System.Guid);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected Product productEntity;
	
		protected SpecialOffer specialOfferEntity;
	
        protected EntityCollection< SalesOrderDetail> salesOrderDetails ;
        
        #endregion

 		#region Properties	

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
		
        [Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID                
        {
            get
            {
                if(this.productEntity == null)
                    return this.productid ;
                
                return this.productEntity.ProductID;            
            }
            set
            {
                if(this.productid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ProductID"));                    
                    this.productid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ProductID"));
                    
                    this.productEntity = null;
                }                
            }          
        }	
        
        [Column( COL_SPECIALOFFERID, PARAM_SPECIALOFFERID, default(int))]
                              public virtual int SpecialOfferID                
        {
            get
            {
                if(this.specialOfferEntity == null)
                    return this.specialofferid ;
                
                return this.specialOfferEntity.SpecialOfferID;            
            }
            set
            {
                if(this.specialofferid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("SpecialOfferID"));                    
                    this.specialofferid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("SpecialOfferID"));
                    
                    this.specialOfferEntity = null;
                }                
            }          
        }	
        
        public Product ProductEntity
        {
            get { 
                    if(this.productEntity == null
                       && this.productid != default(int)) 
                    {
                        Product productQuery = new Product {
                                                        ProductID = this.productid  
                                                        };
                        
                        Product[]  products = productQuery.ToList();                        
                        if(products.Length == 1)
                            this.productEntity = products[0];                        
                    }
                    
                    return this.productEntity; 
                }
			set	{ 
                  if(this.productEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductEntity"));
                        if (this.productEntity != null)
                            this.Parents.Remove(this.productEntity);                            
                        
                        if((this.productEntity = value) != null) 
                            this.Parents.Add(this.productEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductEntity"));
                        
                        this.productid = this.ProductEntity.ProductID;
                    }   
                }
        }	
		
        public SpecialOffer SpecialOfferEntity
        {
            get { 
                    if(this.specialOfferEntity == null
                       && this.specialofferid != default(int)) 
                    {
                        SpecialOffer specialOfferQuery = new SpecialOffer {
                                                        SpecialOfferID = this.specialofferid  
                                                        };
                        
                        SpecialOffer[]  specialOffers = specialOfferQuery.ToList();                        
                        if(specialOffers.Length == 1)
                            this.specialOfferEntity = specialOffers[0];                        
                    }
                    
                    return this.specialOfferEntity; 
                }
			set	{ 
                  if(this.specialOfferEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SpecialOfferEntity"));
                        if (this.specialOfferEntity != null)
                            this.Parents.Remove(this.specialOfferEntity);                            
                        
                        if((this.specialOfferEntity = value) != null) 
                            this.Parents.Add(this.specialOfferEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SpecialOfferEntity"));
                        
                        this.specialofferid = this.SpecialOfferEntity.SpecialOfferID;
                    }   
                }
        }	
		
        public EntityCollection< SalesOrderDetail> SalesOrderDetails 
        {
            get { return this.salesOrderDetails;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public SpecialOfferProduct()
        {
             this.salesOrderDetails = new EntityCollection< SalesOrderDetail>(this, new Associate< SalesOrderDetail>(this.AssociateSalesOrderDetails), new DeAssociate< SalesOrderDetail>(this.DeAssociateSalesOrderDetails), new GetChildren< SalesOrderDetail>(this.GetChildrenSalesOrderDetails));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.specialofferid.GetHashCode();
                result = (11 * result) + this.productid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            SpecialOfferProduct entity = obj as SpecialOfferProduct;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.SpecialOfferID == entity.SpecialOfferID
                        && this.ProductID == entity.ProductID
                        && this.SpecialOfferID != default(int)
                        && this.ProductID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.specialofferid = (int)reader[COL_SPECIALOFFERID];
			this.productid = (int)reader[COL_PRODUCTID];
			this.rowguid = (System.Guid)reader[COL_ROWGUID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SPECIALOFFERPRODUCT))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.SpecialOfferID, PARAM_SPECIALOFFERID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SPECIALOFFERPRODUCT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SpecialOfferID, PARAM_SPECIALOFFERID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SPECIALOFFERPRODUCT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SpecialOfferID, PARAM_SPECIALOFFERID));				
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateSalesOrderDetails(SalesOrderDetail salesOrderDetail)
        {
           salesOrderDetail.SpecialOfferProductEntity = this;
        }
        
        private void DeAssociateSalesOrderDetails(SalesOrderDetail salesOrderDetail)
        {
          if(salesOrderDetail.SpecialOfferProductEntity == this)
             salesOrderDetail.SpecialOfferProductEntity = null;
        }
        
        private SalesOrderDetail[] GetChildrenSalesOrderDetails()
        {
            SalesOrderDetail childrenQuery = new SalesOrderDetail();
            childrenQuery.SpecialOfferProductEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
