/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: Product
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
    public partial class Product : Entity< Product>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.Product";	
     
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_NAME = "Name";
		public const string COL_PRODUCTNUMBER = "ProductNumber";
		public const string COL_MAKEFLAG = "MakeFlag";
		public const string COL_FINISHEDGOODSFLAG = "FinishedGoodsFlag";
		public const string COL_COLOR = "Color";
		public const string COL_SAFETYSTOCKLEVEL = "SafetyStockLevel";
		public const string COL_REORDERPOINT = "ReorderPoint";
		public const string COL_STANDARDCOST = "StandardCost";
		public const string COL_LISTPRICE = "ListPrice";
		public const string COL_SIZE = "Size";
		public const string COL_SIZEUNITMEASURECODE = "SizeUnitMeasureCode";
		public const string COL_WEIGHTUNITMEASURECODE = "WeightUnitMeasureCode";
		public const string COL_WEIGHT = "Weight";
		public const string COL_DAYSTOMANUFACTURE = "DaysToManufacture";
		public const string COL_PRODUCTLINE = "ProductLine";
		public const string COL_CLASS = "Class";
		public const string COL_STYLE = "Style";
		public const string COL_PRODUCTSUBCATEGORYID = "ProductSubcategoryID";
		public const string COL_PRODUCTMODELID = "ProductModelID";
		public const string COL_SELLSTARTDATE = "SellStartDate";
		public const string COL_SELLENDDATE = "SellEndDate";
		public const string COL_DISCONTINUEDDATE = "DiscontinuedDate";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_PRODUCTNUMBER = "@ProductNumber";	
        public const string PARAM_MAKEFLAG = "@MakeFlag";	
        public const string PARAM_FINISHEDGOODSFLAG = "@FinishedGoodsFlag";	
        public const string PARAM_COLOR = "@Color";	
        public const string PARAM_SAFETYSTOCKLEVEL = "@SafetyStockLevel";	
        public const string PARAM_REORDERPOINT = "@ReorderPoint";	
        public const string PARAM_STANDARDCOST = "@StandardCost";	
        public const string PARAM_LISTPRICE = "@ListPrice";	
        public const string PARAM_SIZE = "@Size";	
        public const string PARAM_SIZEUNITMEASURECODE = "@SizeUnitMeasureCode";	
        public const string PARAM_WEIGHTUNITMEASURECODE = "@WeightUnitMeasureCode";	
        public const string PARAM_WEIGHT = "@Weight";	
        public const string PARAM_DAYSTOMANUFACTURE = "@DaysToManufacture";	
        public const string PARAM_PRODUCTLINE = "@ProductLine";	
        public const string PARAM_CLASS = "@Class";	
        public const string PARAM_STYLE = "@Style";	
        public const string PARAM_PRODUCTSUBCATEGORYID = "@ProductSubcategoryID";	
        public const string PARAM_PRODUCTMODELID = "@ProductModelID";	
        public const string PARAM_SELLSTARTDATE = "@SellStartDate";	
        public const string PARAM_SELLENDDATE = "@SellEndDate";	
        public const string PARAM_DISCONTINUEDDATE = "@DiscontinuedDate";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PRODUCT = "INSERT INTO Production.Product([Name],[ProductNumber],[MakeFlag],[FinishedGoodsFlag],[Color],[SafetyStockLevel],[ReorderPoint],[StandardCost],[ListPrice],[Size],[SizeUnitMeasureCode],[WeightUnitMeasureCode],[Weight],[DaysToManufacture],[ProductLine],[Class],[Style],[ProductSubcategoryID],[ProductModelID],[SellStartDate],[SellEndDate],[DiscontinuedDate],[rowguid],[ModifiedDate]) VALUES (@Name,@ProductNumber,@MakeFlag,@FinishedGoodsFlag,@Color,@SafetyStockLevel,@ReorderPoint,@StandardCost,@ListPrice,@Size,@SizeUnitMeasureCode,@WeightUnitMeasureCode,@Weight,@DaysToManufacture,@ProductLine,@Class,@Style,@ProductSubcategoryID,@ProductModelID,@SellStartDate,@SellEndDate,@DiscontinuedDate,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_PRODUCT = "UPDATE Production.Product SET [Name] = @Name, [ProductNumber] = @ProductNumber, [MakeFlag] = @MakeFlag, [FinishedGoodsFlag] = @FinishedGoodsFlag, [Color] = @Color, [SafetyStockLevel] = @SafetyStockLevel, [ReorderPoint] = @ReorderPoint, [StandardCost] = @StandardCost, [ListPrice] = @ListPrice, [Size] = @Size, [SizeUnitMeasureCode] = @SizeUnitMeasureCode, [WeightUnitMeasureCode] = @WeightUnitMeasureCode, [Weight] = @Weight, [DaysToManufacture] = @DaysToManufacture, [ProductLine] = @ProductLine, [Class] = @Class, [Style] = @Style, [ProductSubcategoryID] = @ProductSubcategoryID, [ProductModelID] = @ProductModelID, [SellStartDate] = @SellStartDate, [SellEndDate] = @SellEndDate, [DiscontinuedDate] = @DiscontinuedDate, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [ProductID] = @ProductID";
		
		private const string SQL_DELETE_PRODUCT = "DELETE FROM Production.Product WHERE  [ProductID] = @ProductID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID  { get; set; }		
		
        
	    [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name  { get; set; }	      
        
	    [Column( COL_PRODUCTNUMBER, PARAM_PRODUCTNUMBER )]
                              public virtual string ProductNumber  { get; set; }	      
        
	    [Column( COL_MAKEFLAG, PARAM_MAKEFLAG, default(bool))]
                              public virtual bool MakeFlag  { get; set; }	      
        
	    [Column( COL_FINISHEDGOODSFLAG, PARAM_FINISHEDGOODSFLAG, default(bool))]
                              public virtual bool FinishedGoodsFlag  { get; set; }	      
        
	    [Column( COL_COLOR, PARAM_COLOR )]
                              public virtual string Color  { get; set; }	      
        
	    [Column( COL_SAFETYSTOCKLEVEL, PARAM_SAFETYSTOCKLEVEL, default(short))]
                              public virtual short SafetyStockLevel  { get; set; }	      
        
	    [Column( COL_REORDERPOINT, PARAM_REORDERPOINT, default(short))]
                              public virtual short ReorderPoint  { get; set; }	      
        
	    [Column( COL_STANDARDCOST, PARAM_STANDARDCOST, typeof(decimal))]
                              public virtual decimal StandardCost  { get; set; }	      
        
	    [Column( COL_LISTPRICE, PARAM_LISTPRICE, typeof(decimal))]
                              public virtual decimal ListPrice  { get; set; }	      
        
	    [Column( COL_SIZE, PARAM_SIZE )]
                              public virtual string Size  { get; set; }	      
        
	    [Column( COL_SIZEUNITMEASURECODE, PARAM_SIZEUNITMEASURECODE )]
                              public virtual string SizeUnitMeasureCode  { get; set; }	      
        
	    [Column( COL_WEIGHTUNITMEASURECODE, PARAM_WEIGHTUNITMEASURECODE )]
                              public virtual string WeightUnitMeasureCode  { get; set; }	      
        
	    [Column( COL_WEIGHT, PARAM_WEIGHT )]
                              public virtual decimal? Weight  { get; set; }	      
        
	    [Column( COL_DAYSTOMANUFACTURE, PARAM_DAYSTOMANUFACTURE, default(int))]
                              public virtual int DaysToManufacture  { get; set; }	      
        
	    [Column( COL_PRODUCTLINE, PARAM_PRODUCTLINE )]
                              public virtual string ProductLine  { get; set; }	      
        
	    [Column( COL_CLASS, PARAM_CLASS )]
                              public virtual string Class  { get; set; }	      
        
	    [Column( COL_STYLE, PARAM_STYLE )]
                              public virtual string Style  { get; set; }	      
        
	    [Column( COL_PRODUCTSUBCATEGORYID, PARAM_PRODUCTSUBCATEGORYID )]
                              public virtual int? ProductSubcategoryID  { get; set; }	      
        
	    [Column( COL_PRODUCTMODELID, PARAM_PRODUCTMODELID )]
                              public virtual int? ProductModelID  { get; set; }	      
        
	    [Column( COL_SELLSTARTDATE, PARAM_SELLSTARTDATE, typeof(System.DateTime))]
                              public virtual System.DateTime SellStartDate  { get; set; }	      
        
	    [Column( COL_SELLENDDATE, PARAM_SELLENDDATE )]
                              public virtual System.DateTime? SellEndDate  { get; set; }	      
        
	    [Column( COL_DISCONTINUEDDATE, PARAM_DISCONTINUEDDATE )]
                              public virtual System.DateTime? DiscontinuedDate  { get; set; }	      
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< BillOfMaterial> ComponentIDBillOfMaterials
        {
            get {
                  foreach(BillOfMaterial billOfMaterial in ComponentIDBillOfMaterialList())
                    yield return billOfMaterial; 
                }
        }
        
        public IEnumerable< BillOfMaterial> ProductAssemblyIDBillOfMaterials
        {
            get {
                  foreach(BillOfMaterial billOfMaterial in ProductAssemblyIDBillOfMaterialList())
                    yield return billOfMaterial; 
                }
        }
        
        public IEnumerable< ProductCostHistory> ProductCostHistories
        {
            get {
                  foreach(ProductCostHistory productCostHistory in ProductCostHistoryList())
                    yield return productCostHistory; 
                }
        }
        
        public IEnumerable< ProductDocument> ProductDocuments
        {
            get {
                  foreach(ProductDocument productDocument in ProductDocumentList())
                    yield return productDocument; 
                }
        }
        
        public IEnumerable< ProductInventory> ProductInventories
        {
            get {
                  foreach(ProductInventory productInventory in ProductInventoryList())
                    yield return productInventory; 
                }
        }
        
        public IEnumerable< ProductListPriceHistory> ProductListPriceHistories
        {
            get {
                  foreach(ProductListPriceHistory productListPriceHistory in ProductListPriceHistoryList())
                    yield return productListPriceHistory; 
                }
        }
        
        public IEnumerable< ProductProductPhoto> ProductProductPhotos
        {
            get {
                  foreach(ProductProductPhoto productProductPhoto in ProductProductPhotoList())
                    yield return productProductPhoto; 
                }
        }
        
        public IEnumerable< ProductReview> ProductReviews
        {
            get {
                  foreach(ProductReview productReview in ProductReviewList())
                    yield return productReview; 
                }
        }
        
        public IEnumerable< TransactionHistory> TransactionHistories
        {
            get {
                  foreach(TransactionHistory transactionHistory in TransactionHistoryList())
                    yield return transactionHistory; 
                }
        }
        
        public IEnumerable< WorkOrder> WorkOrders
        {
            get {
                  foreach(WorkOrder workOrder in WorkOrderList())
                    yield return workOrder; 
                }
        }
        
        public IEnumerable< ProductVendor> ProductVendors
        {
            get {
                  foreach(ProductVendor productVendor in ProductVendorList())
                    yield return productVendor; 
                }
        }
        
        public IEnumerable< PurchaseOrderDetail> PurchaseOrderDetails
        {
            get {
                  foreach(PurchaseOrderDetail purchaseOrderDetail in PurchaseOrderDetailList())
                    yield return purchaseOrderDetail; 
                }
        }
        
        public IEnumerable< ShoppingCartItem> ShoppingCartItems
        {
            get {
                  foreach(ShoppingCartItem shoppingCartItem in ShoppingCartItemList())
                    yield return shoppingCartItem; 
                }
        }
        
        public IEnumerable< SpecialOfferProduct> SpecialOfferProducts
        {
            get {
                  foreach(SpecialOfferProduct specialOfferProduct in SpecialOfferProductList())
                    yield return specialOfferProduct; 
                }
        }
        
        
        public IEnumerable< Document> Documents
        {
            get {           
                
                foreach(Document document in DocumentList())
                    yield return document; 
                }         
        }    
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.ProductID = (int)reader[COL_PRODUCTID];
			this.Name = (string)reader[COL_NAME];
			this.ProductNumber = (string)reader[COL_PRODUCTNUMBER];
			this.MakeFlag = (bool)reader[COL_MAKEFLAG];
			this.FinishedGoodsFlag = (bool)reader[COL_FINISHEDGOODSFLAG];
			this.Color = DbConvert.ToString(reader[COL_COLOR]);
			this.SafetyStockLevel = (short)reader[COL_SAFETYSTOCKLEVEL];
			this.ReorderPoint = (short)reader[COL_REORDERPOINT];
			this.StandardCost = (decimal)reader[COL_STANDARDCOST];
			this.ListPrice = (decimal)reader[COL_LISTPRICE];
			this.Size = DbConvert.ToString(reader[COL_SIZE]);
			this.SizeUnitMeasureCode = DbConvert.ToString(reader[COL_SIZEUNITMEASURECODE]);
			this.WeightUnitMeasureCode = DbConvert.ToString(reader[COL_WEIGHTUNITMEASURECODE]);
			this.Weight = DbConvert.ToNullable< decimal >(reader[COL_WEIGHT]);
			this.DaysToManufacture = (int)reader[COL_DAYSTOMANUFACTURE];
			this.ProductLine = DbConvert.ToString(reader[COL_PRODUCTLINE]);
			this.Class = DbConvert.ToString(reader[COL_CLASS]);
			this.Style = DbConvert.ToString(reader[COL_STYLE]);
			this.ProductSubcategoryID = DbConvert.ToNullable< int >(reader[COL_PRODUCTSUBCATEGORYID]);
			this.ProductModelID = DbConvert.ToNullable< int >(reader[COL_PRODUCTMODELID]);
			this.SellStartDate = (System.DateTime)reader[COL_SELLSTARTDATE];
			this.SellEndDate = DbConvert.ToNullable< System.DateTime >(reader[COL_SELLENDDATE]);
			this.DiscontinuedDate = DbConvert.ToNullable< System.DateTime >(reader[COL_DISCONTINUEDDATE]);
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCT))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductNumber, PARAM_PRODUCTNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.MakeFlag, PARAM_MAKEFLAG));
				command.Parameters.Add(dataContext.CreateParameter(this.FinishedGoodsFlag, PARAM_FINISHEDGOODSFLAG));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Color), PARAM_COLOR));
				command.Parameters.Add(dataContext.CreateParameter(this.SafetyStockLevel, PARAM_SAFETYSTOCKLEVEL));
				command.Parameters.Add(dataContext.CreateParameter(this.ReorderPoint, PARAM_REORDERPOINT));
				command.Parameters.Add(dataContext.CreateParameter(this.StandardCost, PARAM_STANDARDCOST));
				command.Parameters.Add(dataContext.CreateParameter(this.ListPrice, PARAM_LISTPRICE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Size), PARAM_SIZE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.SizeUnitMeasureCode), PARAM_SIZEUNITMEASURECODE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.WeightUnitMeasureCode), PARAM_WEIGHTUNITMEASURECODE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Weight), PARAM_WEIGHT));
				command.Parameters.Add(dataContext.CreateParameter(this.DaysToManufacture, PARAM_DAYSTOMANUFACTURE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ProductLine), PARAM_PRODUCTLINE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Class), PARAM_CLASS));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Style), PARAM_STYLE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ProductSubcategoryID), PARAM_PRODUCTSUBCATEGORYID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ProductModelID), PARAM_PRODUCTMODELID));
				command.Parameters.Add(dataContext.CreateParameter(this.SellStartDate, PARAM_SELLSTARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.SellEndDate), PARAM_SELLENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.DiscontinuedDate), PARAM_DISCONTINUEDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.ProductID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductNumber, PARAM_PRODUCTNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.MakeFlag, PARAM_MAKEFLAG));
				command.Parameters.Add(dataContext.CreateParameter(this.FinishedGoodsFlag, PARAM_FINISHEDGOODSFLAG));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Color), PARAM_COLOR));
				command.Parameters.Add(dataContext.CreateParameter(this.SafetyStockLevel, PARAM_SAFETYSTOCKLEVEL));
				command.Parameters.Add(dataContext.CreateParameter(this.ReorderPoint, PARAM_REORDERPOINT));
				command.Parameters.Add(dataContext.CreateParameter(this.StandardCost, PARAM_STANDARDCOST));
				command.Parameters.Add(dataContext.CreateParameter(this.ListPrice, PARAM_LISTPRICE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Size), PARAM_SIZE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.SizeUnitMeasureCode), PARAM_SIZEUNITMEASURECODE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.WeightUnitMeasureCode), PARAM_WEIGHTUNITMEASURECODE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Weight), PARAM_WEIGHT));
				command.Parameters.Add(dataContext.CreateParameter(this.DaysToManufacture, PARAM_DAYSTOMANUFACTURE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ProductLine), PARAM_PRODUCTLINE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Class), PARAM_CLASS));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Style), PARAM_STYLE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ProductSubcategoryID), PARAM_PRODUCTSUBCATEGORYID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ProductModelID), PARAM_PRODUCTMODELID));
				command.Parameters.Add(dataContext.CreateParameter(this.SellStartDate, PARAM_SELLSTARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.SellEndDate), PARAM_SELLENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.DiscontinuedDate), PARAM_DISCONTINUEDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public BillOfMaterial GetComponentIDBillOfMaterialsQuery()
        {
            return new BillOfMaterial {                
                                                                            ComponentID = this.ProductID  
                                                                            };
        }
        
        public BillOfMaterial[] ComponentIDBillOfMaterialList()
        {
            return GetComponentIDBillOfMaterialsQuery().ToList();
        }  
        
        public BillOfMaterial GetProductAssemblyIDBillOfMaterialsQuery()
        {
            return new BillOfMaterial {                
                                                                            ProductAssemblyID = this.ProductID  
                                                                            };
        }
        
        public BillOfMaterial[] ProductAssemblyIDBillOfMaterialList()
        {
            return GetProductAssemblyIDBillOfMaterialsQuery().ToList();
        }  
        
        public ProductCostHistory GetProductCostHistoriesQuery()
        {
            return new ProductCostHistory {                
                                                                            ProductID = this.ProductID  
                                                                            };
        }
        
        public ProductCostHistory[] ProductCostHistoryList()
        {
            return GetProductCostHistoriesQuery().ToList();
        }  
        
        public ProductDocument GetProductDocumentsQuery()
        {
            return new ProductDocument {                
                                                                            ProductID = this.ProductID  
                                                                            };
        }
        
        public ProductDocument[] ProductDocumentList()
        {
            return GetProductDocumentsQuery().ToList();
        }  
        
        public ProductInventory GetProductInventoriesQuery()
        {
            return new ProductInventory {                
                                                                            ProductID = this.ProductID  
                                                                            };
        }
        
        public ProductInventory[] ProductInventoryList()
        {
            return GetProductInventoriesQuery().ToList();
        }  
        
        public ProductListPriceHistory GetProductListPriceHistoriesQuery()
        {
            return new ProductListPriceHistory {                
                                                                            ProductID = this.ProductID  
                                                                            };
        }
        
        public ProductListPriceHistory[] ProductListPriceHistoryList()
        {
            return GetProductListPriceHistoriesQuery().ToList();
        }  
        
        public ProductProductPhoto GetProductProductPhotosQuery()
        {
            return new ProductProductPhoto {                
                                                                            ProductID = this.ProductID  
                                                                            };
        }
        
        public ProductProductPhoto[] ProductProductPhotoList()
        {
            return GetProductProductPhotosQuery().ToList();
        }  
        
        public ProductReview GetProductReviewsQuery()
        {
            return new ProductReview {                
                                                                            ProductID = this.ProductID  
                                                                            };
        }
        
        public ProductReview[] ProductReviewList()
        {
            return GetProductReviewsQuery().ToList();
        }  
        
        public TransactionHistory GetTransactionHistoriesQuery()
        {
            return new TransactionHistory {                
                                                                            ProductID = this.ProductID  
                                                                            };
        }
        
        public TransactionHistory[] TransactionHistoryList()
        {
            return GetTransactionHistoriesQuery().ToList();
        }  
        
        public WorkOrder GetWorkOrdersQuery()
        {
            return new WorkOrder {                
                                                                            ProductID = this.ProductID  
                                                                            };
        }
        
        public WorkOrder[] WorkOrderList()
        {
            return GetWorkOrdersQuery().ToList();
        }  
        
        public ProductVendor GetProductVendorsQuery()
        {
            return new ProductVendor {                
                                                                            ProductID = this.ProductID  
                                                                            };
        }
        
        public ProductVendor[] ProductVendorList()
        {
            return GetProductVendorsQuery().ToList();
        }  
        
        public PurchaseOrderDetail GetPurchaseOrderDetailsQuery()
        {
            return new PurchaseOrderDetail {                
                                                                            ProductID = this.ProductID  
                                                                            };
        }
        
        public PurchaseOrderDetail[] PurchaseOrderDetailList()
        {
            return GetPurchaseOrderDetailsQuery().ToList();
        }  
        
        public ShoppingCartItem GetShoppingCartItemsQuery()
        {
            return new ShoppingCartItem {                
                                                                            ProductID = this.ProductID  
                                                                            };
        }
        
        public ShoppingCartItem[] ShoppingCartItemList()
        {
            return GetShoppingCartItemsQuery().ToList();
        }  
        
        public SpecialOfferProduct GetSpecialOfferProductsQuery()
        {
            return new SpecialOfferProduct {                
                                                                            ProductID = this.ProductID  
                                                                            };
        }
        
        public SpecialOfferProduct[] SpecialOfferProductList()
        {
            return GetSpecialOfferProductsQuery().ToList();
        }  
        
        
        
        public Document[] DocumentList()
        {
            string sqlQuery = @"SELECT Production.Document.*
                                FROM Production.ProductDocument
                                INNER JOIN Production.Document ON                                                                            
                                Production.ProductDocument.[DocumentID] = Production.Document.[DocumentID] AND
                                Production.ProductDocument.[ProductID] = @ProductID  
                                ";
                                
            Dictionary<string, object> parameterValues = new Dictionary<string, object>();
            parameterValues.Add(PARAM_PRODUCTID, this.ProductID);
            
            return Document.ToList(sqlQuery, parameterValues);
            
        }    
        
        #endregion
    }
}
