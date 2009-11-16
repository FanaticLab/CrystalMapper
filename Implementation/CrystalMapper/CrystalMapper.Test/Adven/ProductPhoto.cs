/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: ProductPhoto
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
    public partial class ProductPhoto : Entity< ProductPhoto>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.ProductPhoto";	
     
		public const string COL_PRODUCTPHOTOID = "ProductPhotoID";
		public const string COL_THUMBNAILPHOTO = "ThumbNailPhoto";
		public const string COL_THUMBNAILPHOTOFILENAME = "ThumbnailPhotoFileName";
		public const string COL_LARGEPHOTO = "LargePhoto";
		public const string COL_LARGEPHOTOFILENAME = "LargePhotoFileName";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PRODUCTPHOTOID = "@ProductPhotoID";	
        public const string PARAM_THUMBNAILPHOTO = "@ThumbNailPhoto";	
        public const string PARAM_THUMBNAILPHOTOFILENAME = "@ThumbnailPhotoFileName";	
        public const string PARAM_LARGEPHOTO = "@LargePhoto";	
        public const string PARAM_LARGEPHOTOFILENAME = "@LargePhotoFileName";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PRODUCTPHOTO = "INSERT INTO Production.ProductPhoto([ThumbNailPhoto],[ThumbnailPhotoFileName],[LargePhoto],[LargePhotoFileName],[ModifiedDate]) VALUES (@ThumbNailPhoto,@ThumbnailPhotoFileName,@LargePhoto,@LargePhotoFileName,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_PRODUCTPHOTO = "UPDATE Production.ProductPhoto SET  [ThumbNailPhoto] = @ThumbNailPhoto, [ThumbnailPhotoFileName] = @ThumbnailPhotoFileName, [LargePhoto] = @LargePhoto, [LargePhotoFileName] = @LargePhotoFileName, [ModifiedDate] = @ModifiedDate WHERE [ProductPhotoID] = @ProductPhotoID";
		
		private const string SQL_DELETE_PRODUCTPHOTO = "DELETE FROM Production.ProductPhoto WHERE  [ProductPhotoID] = @ProductPhotoID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int productphotoid = default(int);
	
		protected byte[] thumbnailphoto = default(byte[]);
	
		protected string thumbnailphotofilename = default(string);
	
		protected byte[] largephoto = default(byte[]);
	
		protected string largephotofilename = default(string);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
        protected EntityCollection< ProductProductPhoto> productProductPhotos ;
        
        #endregion

 		#region Properties	

        [Column( COL_PRODUCTPHOTOID, PARAM_PRODUCTPHOTOID, default(int))]
                              public virtual int ProductPhotoID 
        {
            get { return this.productphotoid; }
			set	{ 
                  if(this.productphotoid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductPhotoID"));  
                        this.productphotoid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductPhotoID"));
                    }   
                }
        }	
		
        [Column( COL_THUMBNAILPHOTO, PARAM_THUMBNAILPHOTO )]
                              public virtual byte[] ThumbNailPhoto 
        {
            get { return this.thumbnailphoto; }
			set	{ 
                  if(this.thumbnailphoto != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ThumbNailPhoto"));  
                        this.thumbnailphoto = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ThumbNailPhoto"));
                    }   
                }
        }	
		
        [Column( COL_THUMBNAILPHOTOFILENAME, PARAM_THUMBNAILPHOTOFILENAME )]
                              public virtual string ThumbnailPhotoFileName 
        {
            get { return this.thumbnailphotofilename; }
			set	{ 
                  if(this.thumbnailphotofilename != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ThumbnailPhotoFileName"));  
                        this.thumbnailphotofilename = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ThumbnailPhotoFileName"));
                    }   
                }
        }	
		
        [Column( COL_LARGEPHOTO, PARAM_LARGEPHOTO )]
                              public virtual byte[] LargePhoto 
        {
            get { return this.largephoto; }
			set	{ 
                  if(this.largephoto != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("LargePhoto"));  
                        this.largephoto = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("LargePhoto"));
                    }   
                }
        }	
		
        [Column( COL_LARGEPHOTOFILENAME, PARAM_LARGEPHOTOFILENAME )]
                              public virtual string LargePhotoFileName 
        {
            get { return this.largephotofilename; }
			set	{ 
                  if(this.largephotofilename != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("LargePhotoFileName"));  
                        this.largephotofilename = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("LargePhotoFileName"));
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
		
        public EntityCollection< ProductProductPhoto> ProductProductPhotos 
        {
            get { return this.productProductPhotos;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public ProductPhoto()
        {
             this.productProductPhotos = new EntityCollection< ProductProductPhoto>(this, new Associate< ProductProductPhoto>(this.AssociateProductProductPhotos), new DeAssociate< ProductProductPhoto>(this.DeAssociateProductProductPhotos), new GetChildren< ProductProductPhoto>(this.GetChildrenProductProductPhotos));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.productphotoid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            ProductPhoto entity = obj as ProductPhoto;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.ProductPhotoID == entity.ProductPhotoID
                        && this.ProductPhotoID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.productphotoid = (int)reader[COL_PRODUCTPHOTOID];
			this.thumbnailphoto = (byte[])reader[COL_THUMBNAILPHOTO];
			this.thumbnailphotofilename = DbConvert.ToString(reader[COL_THUMBNAILPHOTOFILENAME]);
			this.largephoto = (byte[])reader[COL_LARGEPHOTO];
			this.largephotofilename = DbConvert.ToString(reader[COL_LARGEPHOTOFILENAME]);
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTPHOTO))
            {	
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ThumbNailPhoto), PARAM_THUMBNAILPHOTO));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ThumbnailPhotoFileName), PARAM_THUMBNAILPHOTOFILENAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.LargePhoto), PARAM_LARGEPHOTO));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.LargePhotoFileName), PARAM_LARGEPHOTOFILENAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.ProductPhotoID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCTPHOTO))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductPhotoID, PARAM_PRODUCTPHOTOID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ThumbNailPhoto), PARAM_THUMBNAILPHOTO));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ThumbnailPhotoFileName), PARAM_THUMBNAILPHOTOFILENAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.LargePhoto), PARAM_LARGEPHOTO));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.LargePhotoFileName), PARAM_LARGEPHOTOFILENAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCTPHOTO))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductPhotoID, PARAM_PRODUCTPHOTOID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateProductProductPhotos(ProductProductPhoto productProductPhoto)
        {
           productProductPhoto.ProductPhotoEntity = this;
        }
        
        private void DeAssociateProductProductPhotos(ProductProductPhoto productProductPhoto)
        {
          if(productProductPhoto.ProductPhotoEntity == this)
             productProductPhoto.ProductPhotoEntity = null;
        }
        
        private ProductProductPhoto[] GetChildrenProductProductPhotos()
        {
            ProductProductPhoto childrenQuery = new ProductProductPhoto();
            childrenQuery.ProductPhotoEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
