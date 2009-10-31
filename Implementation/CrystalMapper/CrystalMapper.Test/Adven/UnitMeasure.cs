/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: UnitMeasure
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
    public partial class UnitMeasure : Entity< UnitMeasure>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.UnitMeasure";	
     
		public const string COL_UNITMEASURECODE = "UnitMeasureCode";
		public const string COL_NAME = "Name";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_UNITMEASURECODE = "@UnitMeasureCode";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_UNITMEASURE = "INSERT INTO Production.UnitMeasure([UnitMeasureCode],[Name],[ModifiedDate]) VALUES (@UnitMeasureCode,@Name,@ModifiedDate);";
		
		private const string SQL_UPDATE_UNITMEASURE = "UPDATE Production.UnitMeasure SET [Name] = @Name, [ModifiedDate] = @ModifiedDate,  WHERE [UnitMeasureCode] = @UnitMeasureCode";
		
		private const string SQL_DELETE_UNITMEASURE = "DELETE FROM Production.UnitMeasure WHERE  [UnitMeasureCode] = @UnitMeasureCode ";
		
        #endregion
        #region Properties	
		
		[Column( COL_UNITMEASURECODE, PARAM_UNITMEASURECODE )]
                              public virtual string UnitMeasureCode  { get; set; }		
		
        
	    [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< BillOfMaterial> BillOfMaterials
        {
            get {
                  foreach(BillOfMaterial billOfMaterial in BillOfMaterialList())
                    yield return billOfMaterial; 
                }
        }
        
        public IEnumerable< Product> SizeUnitMeasureCodeProducts
        {
            get {
                  foreach(Product product in SizeUnitMeasureCodeProductList())
                    yield return product; 
                }
        }
        
        public IEnumerable< Product> WeightUnitMeasureCodeProducts
        {
            get {
                  foreach(Product product in WeightUnitMeasureCodeProductList())
                    yield return product; 
                }
        }
        
        public IEnumerable< ProductVendor> ProductVendors
        {
            get {
                  foreach(ProductVendor productVendor in ProductVendorList())
                    yield return productVendor; 
                }
        }
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.UnitMeasureCode = (string)reader[COL_UNITMEASURECODE];
			this.Name = (string)reader[COL_NAME];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_UNITMEASURE))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.UnitMeasureCode, PARAM_UNITMEASURECODE));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_UNITMEASURE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.UnitMeasureCode, PARAM_UNITMEASURECODE));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_UNITMEASURE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.UnitMeasureCode, PARAM_UNITMEASURECODE));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public BillOfMaterial GetBillOfMaterialsQuery()
        {
            return new BillOfMaterial {                
                                                                            UnitMeasureCode = this.UnitMeasureCode  
                                                                            };
        }
        
        public BillOfMaterial[] BillOfMaterialList()
        {
            return GetBillOfMaterialsQuery().ToList();
        }  
        
        public Product GetSizeUnitMeasureCodeProductsQuery()
        {
            return new Product {                
                                                                            SizeUnitMeasureCode = this.UnitMeasureCode  
                                                                            };
        }
        
        public Product[] SizeUnitMeasureCodeProductList()
        {
            return GetSizeUnitMeasureCodeProductsQuery().ToList();
        }  
        
        public Product GetWeightUnitMeasureCodeProductsQuery()
        {
            return new Product {                
                                                                            WeightUnitMeasureCode = this.UnitMeasureCode  
                                                                            };
        }
        
        public Product[] WeightUnitMeasureCodeProductList()
        {
            return GetWeightUnitMeasureCodeProductsQuery().ToList();
        }  
        
        public ProductVendor GetProductVendorsQuery()
        {
            return new ProductVendor {                
                                                                            UnitMeasureCode = this.UnitMeasureCode  
                                                                            };
        }
        
        public ProductVendor[] ProductVendorList()
        {
            return GetProductVendorsQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
