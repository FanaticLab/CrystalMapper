/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: ProductDescription
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
		
		private const string SQL_INSERT_PRODUCTDESCRIPTION = "INSERT INTO Production.ProductDescription([Description],[rowguid],[ModifiedDate]) VALUES (@Description,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_PRODUCTDESCRIPTION = "UPDATE Production.ProductDescription SET [Description] = @Description, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [ProductDescriptionID] = @ProductDescriptionID";
		
		private const string SQL_DELETE_PRODUCTDESCRIPTION = "DELETE FROM Production.ProductDescription WHERE  [ProductDescriptionID] = @ProductDescriptionID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_PRODUCTDESCRIPTIONID, PARAM_PRODUCTDESCRIPTIONID, default(int))]
                              public virtual int ProductDescriptionID  { get; set; }		
		
        
	    [Column( COL_DESCRIPTION, PARAM_DESCRIPTION )]
                              public virtual string Description  { get; set; }	      
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures
        {
            get {
                  foreach(ProductModelProductDescriptionCulture productModelProductDescriptionCulture in ProductModelProductDescriptionCultureList())
                    yield return productModelProductDescriptionCulture; 
                }
        }
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.ProductDescriptionID = (int)reader[COL_PRODUCTDESCRIPTIONID];
			this.Description = (string)reader[COL_DESCRIPTION];
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTDESCRIPTION))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Description, PARAM_DESCRIPTION));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.ProductDescriptionID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
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
        
        #region Children
        
        public ProductModelProductDescriptionCulture GetProductModelProductDescriptionCulturesQuery()
        {
            return new ProductModelProductDescriptionCulture {                
                                                                            ProductDescriptionID = this.ProductDescriptionID  
                                                                            };
        }
        
        public ProductModelProductDescriptionCulture[] ProductModelProductDescriptionCultureList()
        {
            return GetProductModelProductDescriptionCulturesQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
