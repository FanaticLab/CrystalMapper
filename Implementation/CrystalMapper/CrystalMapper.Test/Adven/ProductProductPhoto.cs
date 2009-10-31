/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: ProductProductPhoto
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
		
		private const string SQL_INSERT_PRODUCTPRODUCTPHOTO = "INSERT INTO Production.ProductProductPhoto([ProductID],[ProductPhotoID],[Primary],[ModifiedDate]) VALUES (@ProductID,@ProductPhotoID,@Primary,@ModifiedDate);";
		
		private const string SQL_UPDATE_PRODUCTPRODUCTPHOTO = "UPDATE Production.ProductProductPhoto SET [Primary] = @Primary, [ModifiedDate] = @ModifiedDate,  WHERE [ProductID] = @ProductID AND [ProductPhotoID] = @ProductPhotoID";
		
		private const string SQL_DELETE_PRODUCTPRODUCTPHOTO = "DELETE FROM Production.ProductProductPhoto WHERE  [ProductID] = @ProductID AND [ProductPhotoID] = @ProductPhotoID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID  { get; set; }		
		[Column( COL_PRODUCTPHOTOID, PARAM_PRODUCTPHOTOID, default(int))]
                              public virtual int ProductPhotoID  { get; set; }		
		
        
	    [Column( COL_PRIMARY, PARAM_PRIMARY, default(bool))]
                              public virtual bool Primary  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.ProductID = (int)reader[COL_PRODUCTID];
			this.ProductPhotoID = (int)reader[COL_PRODUCTPHOTOID];
			this.Primary = (bool)reader[COL_PRIMARY];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
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
        
        #region Children
        
        
        
        
        #endregion
    }
}
