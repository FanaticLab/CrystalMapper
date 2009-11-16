/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: ProductProductPhoto
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
    public partial class ProductProductPhoto : Entity< ProductProductPhoto>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.ProductProductPhoto";	
     
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_PRODUCTPHOTOID = "ProductPhotoID";
		public const string COL_PRIMARY = "Primary";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_PRODUCTPHOTOID = "@ProductPhotoID";	
        public const string PARAM_PRIMARY = "@Primary";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PRODUCTPRODUCTPHOTO = "INSERT INTO Production.ProductProductPhoto([ProductID],[ProductPhotoID],[Primary],[ModifiedDate]) VALUES (@ProductID,@ProductPhotoID,@Primary,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_PRODUCTPRODUCTPHOTO = "UPDATE Production.ProductProductPhoto SET  [Primary] = @Primary, [ModifiedDate] = @ModifiedDate WHERE [ProductID] = @ProductID AND [ProductPhotoID] = @ProductPhotoID";
		
		private const string SQL_DELETE_PRODUCTPRODUCTPHOTO = "DELETE FROM Production.ProductProductPhoto WHERE  [ProductID] = @ProductID AND [ProductPhotoID] = @ProductPhotoID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int productid = default(int);
	
		protected int productphotoid = default(int);
	
		protected bool primary = default(bool);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected Product productEntity;
	
		protected ProductPhoto productPhotoEntity;
	
        #endregion

 		#region Properties	

        [Column( COL_PRIMARY, PARAM_PRIMARY, default(bool))]
                              public virtual bool Primary 
        {
            get { return this.primary; }
			set	{ 
                  if(this.primary != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Primary"));  
                        this.primary = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Primary"));
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
        
        [Column( COL_PRODUCTPHOTOID, PARAM_PRODUCTPHOTOID, default(int))]
                              public virtual int ProductPhotoID                
        {
            get
            {
                if(this.productPhotoEntity == null)
                    return this.productphotoid ;
                
                return this.productPhotoEntity.ProductPhotoID;            
            }
            set
            {
                if(this.productphotoid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ProductPhotoID"));                    
                    this.productphotoid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ProductPhotoID"));
                    
                    this.productPhotoEntity = null;
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
		
        public ProductPhoto ProductPhotoEntity
        {
            get { 
                    if(this.productPhotoEntity == null
                       && this.productphotoid != default(int)) 
                    {
                        ProductPhoto productPhotoQuery = new ProductPhoto {
                                                        ProductPhotoID = this.productphotoid  
                                                        };
                        
                        ProductPhoto[]  productPhotos = productPhotoQuery.ToList();                        
                        if(productPhotos.Length == 1)
                            this.productPhotoEntity = productPhotos[0];                        
                    }
                    
                    return this.productPhotoEntity; 
                }
			set	{ 
                  if(this.productPhotoEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductPhotoEntity"));
                        if (this.productPhotoEntity != null)
                            this.Parents.Remove(this.productPhotoEntity);                            
                        
                        if((this.productPhotoEntity = value) != null) 
                            this.Parents.Add(this.productPhotoEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductPhotoEntity"));
                        
                        this.productphotoid = this.ProductPhotoEntity.ProductPhotoID;
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
		
        public ProductProductPhoto()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.productid.GetHashCode();
                result = (11 * result) + this.productphotoid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            ProductProductPhoto entity = obj as ProductProductPhoto;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.ProductID == entity.ProductID
                        && this.ProductPhotoID == entity.ProductPhotoID
                        && this.ProductID != default(int)
                        && this.ProductPhotoID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.productid = (int)reader[COL_PRODUCTID];
			this.productphotoid = (int)reader[COL_PRODUCTPHOTOID];
			this.primary = (bool)reader[COL_PRIMARY];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTPRODUCTPHOTO))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductPhotoID, PARAM_PRODUCTPHOTOID));
				command.Parameters.Add(dataContext.CreateParameter(this.Primary, PARAM_PRIMARY));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCTPRODUCTPHOTO))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductPhotoID, PARAM_PRODUCTPHOTOID));
				command.Parameters.Add(dataContext.CreateParameter(this.Primary, PARAM_PRIMARY));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCTPRODUCTPHOTO))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));				
				command.Parameters.Add(dataContext.CreateParameter(this.ProductPhotoID, PARAM_PRODUCTPHOTOID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
