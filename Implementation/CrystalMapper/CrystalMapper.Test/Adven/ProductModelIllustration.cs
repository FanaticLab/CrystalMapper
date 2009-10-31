/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: ProductModelIllustration
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
    public partial class ProductModelIllustration : Entity< ProductModelIllustration>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.ProductModelIllustration";	
     
		public const string COL_PRODUCTMODELID = "ProductModelID";
		public const string COL_ILLUSTRATIONID = "IllustrationID";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PRODUCTMODELID = "@ProductModelID";	
        public const string PARAM_ILLUSTRATIONID = "@IllustrationID";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PRODUCTMODELILLUSTRATION = "INSERT INTO Production.ProductModelIllustration([ProductModelID],[IllustrationID],[ModifiedDate]) VALUES (@ProductModelID,@IllustrationID,@ModifiedDate);";
		
		private const string SQL_UPDATE_PRODUCTMODELILLUSTRATION = "UPDATE Production.ProductModelIllustration SET [ModifiedDate] = @ModifiedDate,  WHERE [ProductModelID] = @ProductModelID AND [IllustrationID] = @IllustrationID";
		
		private const string SQL_DELETE_PRODUCTMODELILLUSTRATION = "DELETE FROM Production.ProductModelIllustration WHERE  [ProductModelID] = @ProductModelID AND [IllustrationID] = @IllustrationID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_PRODUCTMODELID, PARAM_PRODUCTMODELID, default(int))]
                              public virtual int ProductModelID  { get; set; }		
		[Column( COL_ILLUSTRATIONID, PARAM_ILLUSTRATIONID, default(int))]
                              public virtual int IllustrationID  { get; set; }		
		
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.ProductModelID = (int)reader[COL_PRODUCTMODELID];
			this.IllustrationID = (int)reader[COL_ILLUSTRATIONID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTMODELILLUSTRATION))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ProductModelID, PARAM_PRODUCTMODELID));
				command.Parameters.Add(dataContext.CreateParameter(this.IllustrationID, PARAM_ILLUSTRATIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCTMODELILLUSTRATION))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductModelID, PARAM_PRODUCTMODELID));
				command.Parameters.Add(dataContext.CreateParameter(this.IllustrationID, PARAM_ILLUSTRATIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCTMODELILLUSTRATION))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductModelID, PARAM_PRODUCTMODELID));				
				command.Parameters.Add(dataContext.CreateParameter(this.IllustrationID, PARAM_ILLUSTRATIONID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
