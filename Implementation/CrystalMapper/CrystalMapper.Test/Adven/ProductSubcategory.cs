/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: ProductSubcategory
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
    public partial class ProductSubcategory : Entity< ProductSubcategory>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.ProductSubcategory";	
     
		public const string COL_PRODUCTSUBCATEGORYID = "ProductSubcategoryID";
		public const string COL_PRODUCTCATEGORYID = "ProductCategoryID";
		public const string COL_NAME = "Name";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PRODUCTSUBCATEGORYID = "@ProductSubcategoryID";	
        public const string PARAM_PRODUCTCATEGORYID = "@ProductCategoryID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PRODUCTSUBCATEGORY = "INSERT INTO Production.ProductSubcategory([ProductCategoryID],[Name],[rowguid],[ModifiedDate]) VALUES (@ProductCategoryID,@Name,@rowguid,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_PRODUCTSUBCATEGORY = "UPDATE Production.ProductSubcategory SET  [ProductCategoryID] = @ProductCategoryID, [Name] = @Name, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate WHERE [ProductSubcategoryID] = @ProductSubcategoryID";
		
		private const string SQL_DELETE_PRODUCTSUBCATEGORY = "DELETE FROM Production.ProductSubcategory WHERE  [ProductSubcategoryID] = @ProductSubcategoryID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int productsubcategoryid = default(int);
	
		protected int productcategoryid = default(int);
	
		protected string name = default(string);
	
		protected System.Guid rowguid = default(System.Guid);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected ProductCategory productCategoryEntity;
	
        protected EntityCollection< Product> products ;
        
        #endregion

 		#region Properties	

        [Column( COL_PRODUCTSUBCATEGORYID, PARAM_PRODUCTSUBCATEGORYID, default(int))]
                              public virtual int ProductSubcategoryID 
        {
            get { return this.productsubcategoryid; }
			set	{ 
                  if(this.productsubcategoryid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductSubcategoryID"));  
                        this.productsubcategoryid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductSubcategoryID"));
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
		
        [Column( COL_PRODUCTCATEGORYID, PARAM_PRODUCTCATEGORYID, default(int))]
                              public virtual int ProductCategoryID                
        {
            get
            {
                if(this.productCategoryEntity == null)
                    return this.productcategoryid ;
                
                return this.productCategoryEntity.ProductCategoryID;            
            }
            set
            {
                if(this.productcategoryid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ProductCategoryID"));                    
                    this.productcategoryid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ProductCategoryID"));
                    
                    this.productCategoryEntity = null;
                }                
            }          
        }	
        
        public ProductCategory ProductCategoryEntity
        {
            get { 
                    if(this.productCategoryEntity == null
                       && this.productcategoryid != default(int)) 
                    {
                        ProductCategory productCategoryQuery = new ProductCategory {
                                                        ProductCategoryID = this.productcategoryid  
                                                        };
                        
                        ProductCategory[]  productCategories = productCategoryQuery.ToList();                        
                        if(productCategories.Length == 1)
                            this.productCategoryEntity = productCategories[0];                        
                    }
                    
                    return this.productCategoryEntity; 
                }
			set	{ 
                  if(this.productCategoryEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductCategoryEntity"));
                        if (this.productCategoryEntity != null)
                            this.Parents.Remove(this.productCategoryEntity);                            
                        
                        if((this.productCategoryEntity = value) != null) 
                            this.Parents.Add(this.productCategoryEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductCategoryEntity"));
                        
                        this.productcategoryid = this.ProductCategoryEntity.ProductCategoryID;
                    }   
                }
        }	
		
        public EntityCollection< Product> Products 
        {
            get { return this.products;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public ProductSubcategory()
        {
             this.products = new EntityCollection< Product>(this, new Associate< Product>(this.AssociateProducts), new DeAssociate< Product>(this.DeAssociateProducts), new GetChildren< Product>(this.GetChildrenProducts));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.productsubcategoryid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            ProductSubcategory entity = obj as ProductSubcategory;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.ProductSubcategoryID == entity.ProductSubcategoryID
                        && this.ProductSubcategoryID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.productsubcategoryid = (int)reader[COL_PRODUCTSUBCATEGORYID];
			this.productcategoryid = (int)reader[COL_PRODUCTCATEGORYID];
			this.name = (string)reader[COL_NAME];
			this.rowguid = (System.Guid)reader[COL_ROWGUID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTSUBCATEGORY))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ProductCategoryID, PARAM_PRODUCTCATEGORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.ProductSubcategoryID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCTSUBCATEGORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductSubcategoryID, PARAM_PRODUCTSUBCATEGORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductCategoryID, PARAM_PRODUCTCATEGORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCTSUBCATEGORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductSubcategoryID, PARAM_PRODUCTSUBCATEGORYID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateProducts(Product product)
        {
           product.ProductSubcategoryEntity = this;
        }
        
        private void DeAssociateProducts(Product product)
        {
          if(product.ProductSubcategoryEntity == this)
             product.ProductSubcategoryEntity = null;
        }
        
        private Product[] GetChildrenProducts()
        {
            Product childrenQuery = new Product();
            childrenQuery.ProductSubcategoryEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
