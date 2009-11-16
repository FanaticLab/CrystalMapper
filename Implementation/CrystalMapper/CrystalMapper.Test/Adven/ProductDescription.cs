/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: ProductDescription
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
    public partial class ProductDescription : Entity< ProductDescription>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.ProductDescription";	
     
		public const string COL_PRODUCTDESCRIPTIONID = "ProductDescriptionID";
		public const string COL_DESCRIPTION = "Description";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PRODUCTDESCRIPTIONID = "@ProductDescriptionID";	
        public const string PARAM_DESCRIPTION = "@Description";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PRODUCTDESCRIPTION = "INSERT INTO Production.ProductDescription([Description],[rowguid],[ModifiedDate]) VALUES (@Description,@rowguid,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_PRODUCTDESCRIPTION = "UPDATE Production.ProductDescription SET  [Description] = @Description, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate WHERE [ProductDescriptionID] = @ProductDescriptionID";
		
		private const string SQL_DELETE_PRODUCTDESCRIPTION = "DELETE FROM Production.ProductDescription WHERE  [ProductDescriptionID] = @ProductDescriptionID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int productdescriptionid = default(int);
	
		protected string description = default(string);
	
		protected System.Guid rowguid = default(System.Guid);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
        protected EntityCollection< ProductModelProductDescriptionCulture> productModelProductDescriptionCultures ;
        
        #endregion

 		#region Properties	

        [Column( COL_PRODUCTDESCRIPTIONID, PARAM_PRODUCTDESCRIPTIONID, default(int))]
                              public virtual int ProductDescriptionID 
        {
            get { return this.productdescriptionid; }
			set	{ 
                  if(this.productdescriptionid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductDescriptionID"));  
                        this.productdescriptionid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductDescriptionID"));
                    }   
                }
        }	
		
        [Column( COL_DESCRIPTION, PARAM_DESCRIPTION )]
                              public virtual string Description 
        {
            get { return this.description; }
			set	{ 
                  if(this.description != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Description"));  
                        this.description = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Description"));
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
		
        public EntityCollection< ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures 
        {
            get { return this.productModelProductDescriptionCultures;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public ProductDescription()
        {
             this.productModelProductDescriptionCultures = new EntityCollection< ProductModelProductDescriptionCulture>(this, new Associate< ProductModelProductDescriptionCulture>(this.AssociateProductModelProductDescriptionCultures), new DeAssociate< ProductModelProductDescriptionCulture>(this.DeAssociateProductModelProductDescriptionCultures), new GetChildren< ProductModelProductDescriptionCulture>(this.GetChildrenProductModelProductDescriptionCultures));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.productdescriptionid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            ProductDescription entity = obj as ProductDescription;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.ProductDescriptionID == entity.ProductDescriptionID
                        && this.ProductDescriptionID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.productdescriptionid = (int)reader[COL_PRODUCTDESCRIPTIONID];
			this.description = (string)reader[COL_DESCRIPTION];
			this.rowguid = (System.Guid)reader[COL_ROWGUID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTDESCRIPTION))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Description, PARAM_DESCRIPTION));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.ProductDescriptionID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCTDESCRIPTION))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductDescriptionID, PARAM_PRODUCTDESCRIPTIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.Description, PARAM_DESCRIPTION));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCTDESCRIPTION))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductDescriptionID, PARAM_PRODUCTDESCRIPTIONID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateProductModelProductDescriptionCultures(ProductModelProductDescriptionCulture productModelProductDescriptionCulture)
        {
           productModelProductDescriptionCulture.ProductDescriptionEntity = this;
        }
        
        private void DeAssociateProductModelProductDescriptionCultures(ProductModelProductDescriptionCulture productModelProductDescriptionCulture)
        {
          if(productModelProductDescriptionCulture.ProductDescriptionEntity == this)
             productModelProductDescriptionCulture.ProductDescriptionEntity = null;
        }
        
        private ProductModelProductDescriptionCulture[] GetChildrenProductModelProductDescriptionCultures()
        {
            ProductModelProductDescriptionCulture childrenQuery = new ProductModelProductDescriptionCulture();
            childrenQuery.ProductDescriptionEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
