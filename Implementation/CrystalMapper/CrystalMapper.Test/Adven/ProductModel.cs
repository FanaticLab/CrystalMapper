/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: ProductModel
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
    public partial class ProductModel : Entity< ProductModel>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.ProductModel";	
     
		public const string COL_PRODUCTMODELID = "ProductModelID";
		public const string COL_NAME = "Name";
		public const string COL_CATALOGDESCRIPTION = "CatalogDescription";
		public const string COL_INSTRUCTIONS = "Instructions";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PRODUCTMODELID = "@ProductModelID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_CATALOGDESCRIPTION = "@CatalogDescription";	
        public const string PARAM_INSTRUCTIONS = "@Instructions";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PRODUCTMODEL = "INSERT INTO Production.ProductModel([Name],[CatalogDescription],[Instructions],[rowguid],[ModifiedDate]) VALUES (@Name,@CatalogDescription,@Instructions,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_PRODUCTMODEL = "UPDATE Production.ProductModel SET [Name] = @Name, [CatalogDescription] = @CatalogDescription, [Instructions] = @Instructions, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [ProductModelID] = @ProductModelID";
		
		private const string SQL_DELETE_PRODUCTMODEL = "DELETE FROM Production.ProductModel WHERE  [ProductModelID] = @ProductModelID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_PRODUCTMODELID, PARAM_PRODUCTMODELID, default(int))]
                              public virtual int ProductModelID  { get; set; }		
		
        
	    [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name  { get; set; }	      
        
	    [Column( COL_CATALOGDESCRIPTION, PARAM_CATALOGDESCRIPTION )]
                              public virtual System.Xml.XmlDocument CatalogDescription  { get; set; }	      
        
	    [Column( COL_INSTRUCTIONS, PARAM_INSTRUCTIONS )]
                              public virtual System.Xml.XmlDocument Instructions  { get; set; }	      
        
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
        
        public IEnumerable< ProductModelIllustration> ProductModelIllustrations
        {
            get {
                  foreach(ProductModelIllustration productModelIllustration in ProductModelIllustrationList())
                    yield return productModelIllustration; 
                }
        }
        
        public IEnumerable< ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures
        {
            get {
                  foreach(ProductModelProductDescriptionCulture productModelProductDescriptionCulture in ProductModelProductDescriptionCultureList())
                    yield return productModelProductDescriptionCulture; 
                }
        }
        
        
        public IEnumerable< Illustration> Illustrations
        {
            get {           
                
                foreach(Illustration illustration in IllustrationList())
                    yield return illustration; 
                }         
        }    
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.ProductModelID = (int)reader[COL_PRODUCTMODELID];
			this.Name = (string)reader[COL_NAME];
			this.CatalogDescription = (System.Xml.XmlDocument)reader[COL_CATALOGDESCRIPTION];
			this.Instructions = (System.Xml.XmlDocument)reader[COL_INSTRUCTIONS];
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTMODEL))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CatalogDescription), PARAM_CATALOGDESCRIPTION));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Instructions), PARAM_INSTRUCTIONS));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.ProductModelID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCTMODEL))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductModelID, PARAM_PRODUCTMODELID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CatalogDescription), PARAM_CATALOGDESCRIPTION));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Instructions), PARAM_INSTRUCTIONS));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCTMODEL))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductModelID, PARAM_PRODUCTMODELID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public Product GetProductsQuery()
        {
            return new Product {                
                                                                            ProductModelID = this.ProductModelID  
                                                                            };
        }
        
        public Product[] ProductList()
        {
            return GetProductsQuery().ToList();
        }  
        
        public ProductModelIllustration GetProductModelIllustrationsQuery()
        {
            return new ProductModelIllustration {                
                                                                            ProductModelID = this.ProductModelID  
                                                                            };
        }
        
        public ProductModelIllustration[] ProductModelIllustrationList()
        {
            return GetProductModelIllustrationsQuery().ToList();
        }  
        
        public ProductModelProductDescriptionCulture GetProductModelProductDescriptionCulturesQuery()
        {
            return new ProductModelProductDescriptionCulture {                
                                                                            ProductModelID = this.ProductModelID  
                                                                            };
        }
        
        public ProductModelProductDescriptionCulture[] ProductModelProductDescriptionCultureList()
        {
            return GetProductModelProductDescriptionCulturesQuery().ToList();
        }  
        
        
        
        public Illustration[] IllustrationList()
        {
            string sqlQuery = @"SELECT Production.Illustration.*
                                FROM Production.ProductModelIllustration
                                INNER JOIN Production.Illustration ON                                                                            
                                Production.ProductModelIllustration.[IllustrationID] = Production.Illustration.[IllustrationID] AND
                                Production.ProductModelIllustration.[ProductModelID] = @ProductModelID  
                                ";
                                
            Dictionary<string, object> parameterValues = new Dictionary<string, object>();
            parameterValues.Add(PARAM_PRODUCTMODELID, this.ProductModelID);
            
            return Illustration.ToList(sqlQuery, parameterValues);
            
        }    
        
        #endregion
    }
}
