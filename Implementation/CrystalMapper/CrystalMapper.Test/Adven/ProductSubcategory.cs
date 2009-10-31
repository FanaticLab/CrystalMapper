/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: ProductSubcategory
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
    public partial class ProductSubcategory : Entity< ProductSubcategory>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.ProductSubcategory";	
     
		public const string COL_PRODUCTSUBCATEGORYID = "ProductSubcategoryID";
		public const string COL_PRODUCTCATEGORYID = "ProductCategoryID";
		public const string COL_NAME = "Name";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PRODUCTSUBCATEGORYID = "@ProductSubcategoryID";	
        public const string PARAM_PRODUCTCATEGORYID = "@ProductCategoryID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PRODUCTSUBCATEGORY = "INSERT INTO Production.ProductSubcategory([ProductCategoryID],[Name],[rowguid],[ModifiedDate]) VALUES (@ProductCategoryID,@Name,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_PRODUCTSUBCATEGORY = "UPDATE Production.ProductSubcategory SET [ProductCategoryID] = @ProductCategoryID, [Name] = @Name, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [ProductSubcategoryID] = @ProductSubcategoryID";
		
		private const string SQL_DELETE_PRODUCTSUBCATEGORY = "DELETE FROM Production.ProductSubcategory WHERE  [ProductSubcategoryID] = @ProductSubcategoryID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_PRODUCTSUBCATEGORYID, PARAM_PRODUCTSUBCATEGORYID, default(int))]
                              public virtual int ProductSubcategoryID  { get; set; }		
		
        
	    [Column( COL_PRODUCTCATEGORYID, PARAM_PRODUCTCATEGORYID, default(int))]
                              public virtual int ProductCategoryID  { get; set; }	      
        
	    [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name  { get; set; }	      
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< Product> Products
        {
            get {
                  foreach(Product product in ProductList())
                    yield return product; 
                }
        }
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.ProductSubcategoryID = (int)reader[COL_PRODUCTSUBCATEGORYID];
			this.ProductCategoryID = (int)reader[COL_PRODUCTCATEGORYID];
			this.Name = (string)reader[COL_NAME];
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTSUBCATEGORY))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ProductCategoryID, PARAM_PRODUCTCATEGORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.ProductSubcategoryID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCTSUBCATEGORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductSubcategoryID, PARAM_PRODUCTSUBCATEGORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductCategoryID, PARAM_PRODUCTCATEGORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCTSUBCATEGORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductSubcategoryID, PARAM_PRODUCTSUBCATEGORYID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public Product GetProductsQuery()
        {
            return new Product {                
                                                                            ProductSubcategoryID = this.ProductSubcategoryID  
                                                                            };
        }
        
        public Product[] ProductList()
        {
            return GetProductsQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
