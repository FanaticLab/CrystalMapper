/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: ProductDocument
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
    public partial class ProductDocument : Entity< ProductDocument>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.ProductDocument";	
     
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_DOCUMENTID = "DocumentID";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_DOCUMENTID = "@DocumentID";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PRODUCTDOCUMENT = "INSERT INTO Production.ProductDocument([ProductID],[DocumentID],[ModifiedDate]) VALUES (@ProductID,@DocumentID,@ModifiedDate);";
		
		private const string SQL_UPDATE_PRODUCTDOCUMENT = "UPDATE Production.ProductDocument SET [ModifiedDate] = @ModifiedDate,  WHERE [ProductID] = @ProductID AND [DocumentID] = @DocumentID";
		
		private const string SQL_DELETE_PRODUCTDOCUMENT = "DELETE FROM Production.ProductDocument WHERE  [ProductID] = @ProductID AND [DocumentID] = @DocumentID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID  { get; set; }		
		[Column( COL_DOCUMENTID, PARAM_DOCUMENTID, default(int))]
                              public virtual int DocumentID  { get; set; }		
		
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.ProductID = (int)reader[COL_PRODUCTID];
			this.DocumentID = (int)reader[COL_DOCUMENTID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTDOCUMENT))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.DocumentID, PARAM_DOCUMENTID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCTDOCUMENT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.DocumentID, PARAM_DOCUMENTID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCTDOCUMENT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));				
				command.Parameters.Add(dataContext.CreateParameter(this.DocumentID, PARAM_DOCUMENTID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
