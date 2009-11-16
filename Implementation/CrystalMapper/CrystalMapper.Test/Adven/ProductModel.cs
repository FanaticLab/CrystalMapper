/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: ProductModel
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
    public partial class ProductModel : Entity< ProductModel>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.ProductModel";	
     
		public const string COL_PRODUCTMODELID = "ProductModelID";
		public const string COL_NAME = "Name";
		public const string COL_CATALOGDESCRIPTION = "CatalogDescription";
		public const string COL_INSTRUCTIONS = "Instructions";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PRODUCTMODELID = "@ProductModelID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_CATALOGDESCRIPTION = "@CatalogDescription";	
        public const string PARAM_INSTRUCTIONS = "@Instructions";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PRODUCTMODEL = "INSERT INTO Production.ProductModel([Name],[CatalogDescription],[Instructions],[rowguid],[ModifiedDate]) VALUES (@Name,@CatalogDescription,@Instructions,@rowguid,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_PRODUCTMODEL = "UPDATE Production.ProductModel SET  [Name] = @Name, [CatalogDescription] = @CatalogDescription, [Instructions] = @Instructions, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate WHERE [ProductModelID] = @ProductModelID";
		
		private const string SQL_DELETE_PRODUCTMODEL = "DELETE FROM Production.ProductModel WHERE  [ProductModelID] = @ProductModelID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int productmodelid = default(int);
	
		protected string name = default(string);
	
		protected System.Xml.XmlDocument catalogdescription = default(System.Xml.XmlDocument);
	
		protected System.Xml.XmlDocument instruction = default(System.Xml.XmlDocument);
	
		protected System.Guid rowguid = default(System.Guid);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
        protected EntityCollection< Product> products ;
        
        protected EntityCollection< ProductModelIllustration> productModelIllustrations ;
        
        protected EntityCollection< ProductModelProductDescriptionCulture> productModelProductDescriptionCultures ;
        
        #endregion

 		#region Properties	

        [Column( COL_PRODUCTMODELID, PARAM_PRODUCTMODELID, default(int))]
                              public virtual int ProductModelID 
        {
            get { return this.productmodelid; }
			set	{ 
                  if(this.productmodelid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductModelID"));  
                        this.productmodelid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductModelID"));
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
		
        [Column( COL_CATALOGDESCRIPTION, PARAM_CATALOGDESCRIPTION )]
                              public virtual System.Xml.XmlDocument CatalogDescription 
        {
            get { return this.catalogdescription; }
			set	{ 
                  if(this.catalogdescription != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CatalogDescription"));  
                        this.catalogdescription = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CatalogDescription"));
                    }   
                }
        }	
		
        [Column( COL_INSTRUCTIONS, PARAM_INSTRUCTIONS )]
                              public virtual System.Xml.XmlDocument Instructions 
        {
            get { return this.instruction; }
			set	{ 
                  if(this.instruction != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Instructions"));  
                        this.instruction = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Instructions"));
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
		
        public EntityCollection< Product> Products 
        {
            get { return this.products;}
        }
        
        public EntityCollection< ProductModelIllustration> ProductModelIllustrations 
        {
            get { return this.productModelIllustrations;}
        }
        
        public EntityCollection< ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures 
        {
            get { return this.productModelProductDescriptionCultures;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public ProductModel()
        {
             this.products = new EntityCollection< Product>(this, new Associate< Product>(this.AssociateProducts), new DeAssociate< Product>(this.DeAssociateProducts), new GetChildren< Product>(this.GetChildrenProducts));
             this.productModelIllustrations = new EntityCollection< ProductModelIllustration>(this, new Associate< ProductModelIllustration>(this.AssociateProductModelIllustrations), new DeAssociate< ProductModelIllustration>(this.DeAssociateProductModelIllustrations), new GetChildren< ProductModelIllustration>(this.GetChildrenProductModelIllustrations));
             this.productModelProductDescriptionCultures = new EntityCollection< ProductModelProductDescriptionCulture>(this, new Associate< ProductModelProductDescriptionCulture>(this.AssociateProductModelProductDescriptionCultures), new DeAssociate< ProductModelProductDescriptionCulture>(this.DeAssociateProductModelProductDescriptionCultures), new GetChildren< ProductModelProductDescriptionCulture>(this.GetChildrenProductModelProductDescriptionCultures));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.productmodelid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            ProductModel entity = obj as ProductModel;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.ProductModelID == entity.ProductModelID
                        && this.ProductModelID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.productmodelid = (int)reader[COL_PRODUCTMODELID];
			this.name = (string)reader[COL_NAME];
			this.catalogdescription = (System.Xml.XmlDocument)reader[COL_CATALOGDESCRIPTION];
			this.instruction = (System.Xml.XmlDocument)reader[COL_INSTRUCTIONS];
			this.rowguid = (System.Guid)reader[COL_ROWGUID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTMODEL))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CatalogDescription), PARAM_CATALOGDESCRIPTION));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Instructions), PARAM_INSTRUCTIONS));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.ProductModelID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCTMODEL))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductModelID, PARAM_PRODUCTMODELID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CatalogDescription), PARAM_CATALOGDESCRIPTION));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Instructions), PARAM_INSTRUCTIONS));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCTMODEL))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductModelID, PARAM_PRODUCTMODELID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateProducts(Product product)
        {
           product.ProductModelEntity = this;
        }
        
        private void DeAssociateProducts(Product product)
        {
          if(product.ProductModelEntity == this)
             product.ProductModelEntity = null;
        }
        
        private Product[] GetChildrenProducts()
        {
            Product childrenQuery = new Product();
            childrenQuery.ProductModelEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateProductModelIllustrations(ProductModelIllustration productModelIllustration)
        {
           productModelIllustration.ProductModelEntity = this;
        }
        
        private void DeAssociateProductModelIllustrations(ProductModelIllustration productModelIllustration)
        {
          if(productModelIllustration.ProductModelEntity == this)
             productModelIllustration.ProductModelEntity = null;
        }
        
        private ProductModelIllustration[] GetChildrenProductModelIllustrations()
        {
            ProductModelIllustration childrenQuery = new ProductModelIllustration();
            childrenQuery.ProductModelEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateProductModelProductDescriptionCultures(ProductModelProductDescriptionCulture productModelProductDescriptionCulture)
        {
           productModelProductDescriptionCulture.ProductModelEntity = this;
        }
        
        private void DeAssociateProductModelProductDescriptionCultures(ProductModelProductDescriptionCulture productModelProductDescriptionCulture)
        {
          if(productModelProductDescriptionCulture.ProductModelEntity == this)
             productModelProductDescriptionCulture.ProductModelEntity = null;
        }
        
        private ProductModelProductDescriptionCulture[] GetChildrenProductModelProductDescriptionCultures()
        {
            ProductModelProductDescriptionCulture childrenQuery = new ProductModelProductDescriptionCulture();
            childrenQuery.ProductModelEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
