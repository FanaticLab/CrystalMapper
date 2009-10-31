/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: ProductModelProductDescriptionCulture
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
    public partial class ProductModelProductDescriptionCulture : Entity< ProductModelProductDescriptionCulture>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.ProductModelProductDescriptionCulture";	
     
		public const string COL_PRODUCTMODELID = "ProductModelID";
		public const string COL_PRODUCTDESCRIPTIONID = "ProductDescriptionID";
		public const string COL_CULTUREID = "CultureID";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PRODUCTMODELID = "@ProductModelID";	
        public const string PARAM_PRODUCTDESCRIPTIONID = "@ProductDescriptionID";	
        public const string PARAM_CULTUREID = "@CultureID";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PRODUCTMODELPRODUCTDESCRIPTIONCULTURE = "INSERT INTO Production.ProductModelProductDescriptionCulture([ProductModelID],[ProductDescriptionID],[CultureID],[ModifiedDate]) VALUES (@ProductModelID,@ProductDescriptionID,@CultureID,@ModifiedDate);";
		
		private const string SQL_UPDATE_PRODUCTMODELPRODUCTDESCRIPTIONCULTURE = "UPDATE Production.ProductModelProductDescriptionCulture SET [ModifiedDate] = @ModifiedDate,  WHERE [ProductModelID] = @ProductModelID AND [ProductDescriptionID] = @ProductDescriptionID AND [CultureID] = @CultureID";
		
		private const string SQL_DELETE_PRODUCTMODELPRODUCTDESCRIPTIONCULTURE = "DELETE FROM Production.ProductModelProductDescriptionCulture WHERE  [ProductModelID] = @ProductModelID AND [ProductDescriptionID] = @ProductDescriptionID AND [CultureID] = @CultureID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_PRODUCTMODELID, PARAM_PRODUCTMODELID, default(int))]
                              public virtual int ProductModelID  { get; set; }		
		[Column( COL_PRODUCTDESCRIPTIONID, PARAM_PRODUCTDESCRIPTIONID, default(int))]
                              public virtual int ProductDescriptionID  { get; set; }		
		[Column( COL_CULTUREID, PARAM_CULTUREID )]
                              public virtual string CultureID  { get; set; }		
		
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.ProductModelID = (int)reader[COL_PRODUCTMODELID];
			this.ProductDescriptionID = (int)reader[COL_PRODUCTDESCRIPTIONID];
			this.CultureID = (string)reader[COL_CULTUREID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTMODELPRODUCTDESCRIPTIONCULTURE))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ProductModelID, PARAM_PRODUCTMODELID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductDescriptionID, PARAM_PRODUCTDESCRIPTIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.CultureID, PARAM_CULTUREID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCTMODELPRODUCTDESCRIPTIONCULTURE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductModelID, PARAM_PRODUCTMODELID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductDescriptionID, PARAM_PRODUCTDESCRIPTIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.CultureID, PARAM_CULTUREID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCTMODELPRODUCTDESCRIPTIONCULTURE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductModelID, PARAM_PRODUCTMODELID));				
				command.Parameters.Add(dataContext.CreateParameter(this.ProductDescriptionID, PARAM_PRODUCTDESCRIPTIONID));				
				command.Parameters.Add(dataContext.CreateParameter(this.CultureID, PARAM_CULTUREID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
