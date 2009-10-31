/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: ProductPhoto
 *    
 */

using System;
using System.Data.Common;
using System.Diagnostics;
using System.Collections.Generic;

using CoreSystem.Data;

using CrystalMapper;
using CrystalMapper.Data;
using CrystalMapper.Mapping;

namespace CrystalMapper.Generated.BusinessObjects
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
		
		private const string SQL_INSERT_PRODUCTPHOTO = "INSERT INTO Production.ProductPhoto([ThumbNailPhoto],[ThumbnailPhotoFileName],[LargePhoto],[LargePhotoFileName],[ModifiedDate]) VALUES (@ThumbNailPhoto,@ThumbnailPhotoFileName,@LargePhoto,@LargePhotoFileName,@ModifiedDate);";
		
		private const string SQL_UPDATE_PRODUCTPHOTO = "UPDATE Production.ProductPhoto SET [ThumbNailPhoto] = @ThumbNailPhoto, [ThumbnailPhotoFileName] = @ThumbnailPhotoFileName, [LargePhoto] = @LargePhoto, [LargePhotoFileName] = @LargePhotoFileName, [ModifiedDate] = @ModifiedDate,  WHERE [ProductPhotoID] = @ProductPhotoID";
		
		private const string SQL_DELETE_PRODUCTPHOTO = "DELETE FROM Production.ProductPhoto WHERE  [ProductPhotoID] = @ProductPhotoID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_PRODUCTPHOTOID, PARAM_PRODUCTPHOTOID, default(int))]
                              public virtual int ProductPhotoID  { get; set; }		
		
        
	    [Column( COL_THUMBNAILPHOTO, PARAM_THUMBNAILPHOTO )]
                              public virtual byte[] ThumbNailPhoto  { get; set; }	      
        
	    [Column( COL_THUMBNAILPHOTOFILENAME, PARAM_THUMBNAILPHOTOFILENAME )]
                              public virtual string ThumbnailPhotoFileName  { get; set; }	      
        
	    [Column( COL_LARGEPHOTO, PARAM_LARGEPHOTO )]
                              public virtual byte[] LargePhoto  { get; set; }	      
        
	    [Column( COL_LARGEPHOTOFILENAME, PARAM_LARGEPHOTOFILENAME )]
                              public virtual string LargePhotoFileName  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< ProductProductPhoto> ProductProductPhotos
        {
            get {
                  foreach(ProductProductPhoto productProductPhoto in ProductProductPhotoList())
                    yield return productProductPhoto; 
                }
        }
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.ProductPhotoID = (int)reader[COL_PRODUCTPHOTOID];
			this.ThumbNailPhoto = (byte[])reader[COL_THUMBNAILPHOTO];
			this.ThumbnailPhotoFileName = DbConvert.ToString(reader[COL_THUMBNAILPHOTOFILENAME]);
			this.LargePhoto = (byte[])reader[COL_LARGEPHOTO];
			this.LargePhotoFileName = DbConvert.ToString(reader[COL_LARGEPHOTOFILENAME]);
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
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
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.ProductPhotoID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
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
        
        #region Children
        
        public ProductProductPhoto GetProductProductPhotosQuery()
        {
            return new ProductProductPhoto {                
                                                                            ProductPhotoID = this.ProductPhotoID  
                                                                            };
        }
        
        public ProductProductPhoto[] ProductProductPhotoList()
        {
            return GetProductProductPhotosQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
