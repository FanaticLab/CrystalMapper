/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * className: Product
 * 
 * Email: mk.faraz@gmail.com
 * 
 * Blogs: http://csharplive.wordpress.com, http://farazmasoodkhan.wordpress.com
 *
 * Website: http://www.linkedin.com/in/farazmasoodkhan
 *
 * Copyright: Faraz Masood Khan @ Copyright 2009
 *
/*/

using System;
using System.Data.Common;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;

using CoreSystem.Data;

using CrystalMapper;
using CrystalMapper.Data;
using CrystalMapper.Mapping;

namespace feedbook.Model
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
		public const string COL_className = "className";
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
        public const string PARAM_className = "@className";	
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
		
		private const string SQL_INSERT_PRODUCT = "INSERT INTO Production.Product([Name],[ProductNumber],[MakeFlag],[FinishedGoodsFlag],[Color],[SafetyStockLevel],[ReorderPoint],[StandardCost],[ListPrice],[Size],[SizeUnitMeasureCode],[WeightUnitMeasureCode],[Weight],[DaysToManufacture],[ProductLine],[className],[Style],[ProductSubcategoryID],[ProductModelID],[SellStartDate],[SellEndDate],[DiscontinuedDate],[rowguid],[ModifiedDate]) VALUES (@Name,@ProductNumber,@MakeFlag,@FinishedGoodsFlag,@Color,@SafetyStockLevel,@ReorderPoint,@StandardCost,@ListPrice,@Size,@SizeUnitMeasureCode,@WeightUnitMeasureCode,@Weight,@DaysToManufacture,@ProductLine,@className,@Style,@ProductSubcategoryID,@ProductModelID,@SellStartDate,@SellEndDate,@DiscontinuedDate,@rowguid,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_PRODUCT = "UPDATE Production.Product SET  [Name] = @Name, [ProductNumber] = @ProductNumber, [MakeFlag] = @MakeFlag, [FinishedGoodsFlag] = @FinishedGoodsFlag, [Color] = @Color, [SafetyStockLevel] = @SafetyStockLevel, [ReorderPoint] = @ReorderPoint, [StandardCost] = @StandardCost, [ListPrice] = @ListPrice, [Size] = @Size, [SizeUnitMeasureCode] = @SizeUnitMeasureCode, [WeightUnitMeasureCode] = @WeightUnitMeasureCode, [Weight] = @Weight, [DaysToManufacture] = @DaysToManufacture, [ProductLine] = @ProductLine, [className] = @className, [Style] = @Style, [ProductSubcategoryID] = @ProductSubcategoryID, [ProductModelID] = @ProductModelID, [SellStartDate] = @SellStartDate, [SellEndDate] = @SellEndDate, [DiscontinuedDate] = @DiscontinuedDate, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate WHERE [ProductID] = @ProductID";
		
		private const string SQL_DELETE_PRODUCT = "DELETE FROM Production.Product WHERE  [ProductID] = @ProductID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int productid = default(int);
	
		protected string name = default(string);
	
		protected string productnumber = default(string);
	
		protected bool makeflag = default(bool);
	
		protected bool finishedgoodsflag = default(bool);
	
		protected string color = default(string);
	
		protected short safetystocklevel = default(short);
	
		protected short reorderpoint = default(short);
	
		protected decimal standardcost = default(decimal);
	
		protected decimal listprice = default(decimal);
	
		protected string size = default(string);
	
		protected string sizeunitmeasurecode = default(string);
	
		protected string weightunitmeasurecode = default(string);
	
		protected decimal? weight = default(decimal?);
	
		protected int daystomanufacture = default(int);
	
		protected string productline = default(string);
	
		protected string className = default(string);
	
		protected string style = default(string);
	
		protected int? productsubcategoryid = default(int?);
	
		protected int? productmodelid = default(int?);
	
		protected System.DateTime sellstartdate = default(System.DateTime);
	
		protected System.DateTime? sellenddate = default(System.DateTime?);
	
		protected System.DateTime? discontinueddate = default(System.DateTime?);
	
		protected System.Guid rowguid = default(System.Guid);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected ProductModel productModelEntity;
	
		protected ProductSubcategory productSubcategoryEntity;
	
		protected UnitMeasure sizeunitmeasureEntity;
	
		protected UnitMeasure weightunitmeasureEntity;
	
        protected EntityCollection< BillOfMaterial> billOfMaterialComponents ;
        
        protected EntityCollection< BillOfMaterial> billOfMaterialProductAssemblies ;
        
        protected EntityCollection< ProductCostHistory> productCostHistories ;
        
        protected EntityCollection< ProductDocument> productDocuments ;
        
        protected EntityCollection< ProductInventory> productInventories ;
        
        protected EntityCollection< ProductListPriceHistory> productListPriceHistories ;
        
        protected EntityCollection< ProductProductPhoto> productProductPhotos ;
        
        protected EntityCollection< ProductReview> productReviews ;
        
        protected EntityCollection< TransactionHistory> transactionHistories ;
        
        protected EntityCollection< WorkOrder> workOrders ;
        
        protected EntityCollection< ProductVendor> productVendors ;
        
        protected EntityCollection< PurchaseOrderDetail> purchaseOrderDetails ;
        
        protected EntityCollection< ShoppingCartItem> shoppingCartItems ;
        
        protected EntityCollection< SpecialOfferProduct> specialOfferProducts ;
        
        #endregion

 		#region Properties	

        [Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID 
        {
            get { return this.productid; }
			set	{ 
                  if(this.productid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductID"));  
                        this.productid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductID"));
                    }   
                }
        }	
		
        [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name 
        {
            get { return this.name; }
			set	{ 
                  if(this.name != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Name"));  
                        this.name = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Name"));
                    }   
                }
        }	
		
        [Column( COL_PRODUCTNUMBER, PARAM_PRODUCTNUMBER )]
                              public virtual string ProductNumber 
        {
            get { return this.productnumber; }
			set	{ 
                  if(this.productnumber != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductNumber"));  
                        this.productnumber = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductNumber"));
                    }   
                }
        }	
		
        [Column( COL_MAKEFLAG, PARAM_MAKEFLAG, default(bool))]
                              public virtual bool MakeFlag 
        {
            get { return this.makeflag; }
			set	{ 
                  if(this.makeflag != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("MakeFlag"));  
                        this.makeflag = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("MakeFlag"));
                    }   
                }
        }	
		
        [Column( COL_FINISHEDGOODSFLAG, PARAM_FINISHEDGOODSFLAG, default(bool))]
                              public virtual bool FinishedGoodsFlag 
        {
            get { return this.finishedgoodsflag; }
			set	{ 
                  if(this.finishedgoodsflag != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("FinishedGoodsFlag"));  
                        this.finishedgoodsflag = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("FinishedGoodsFlag"));
                    }   
                }
        }	
		
        [Column( COL_COLOR, PARAM_COLOR )]
                              public virtual string Color 
        {
            get { return this.color; }
			set	{ 
                  if(this.color != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Color"));  
                        this.color = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Color"));
                    }   
                }
        }	
		
        [Column( COL_SAFETYSTOCKLEVEL, PARAM_SAFETYSTOCKLEVEL, default(short))]
                              public virtual short SafetyStockLevel 
        {
            get { return this.safetystocklevel; }
			set	{ 
                  if(this.safetystocklevel != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SafetyStockLevel"));  
                        this.safetystocklevel = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SafetyStockLevel"));
                    }   
                }
        }	
		
        [Column( COL_REORDERPOINT, PARAM_REORDERPOINT, default(short))]
                              public virtual short ReorderPoint 
        {
            get { return this.reorderpoint; }
			set	{ 
                  if(this.reorderpoint != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ReorderPoint"));  
                        this.reorderpoint = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ReorderPoint"));
                    }   
                }
        }	
		
        [Column( COL_STANDARDCOST, PARAM_STANDARDCOST, typeof(decimal))]
                              public virtual decimal StandardCost 
        {
            get { return this.standardcost; }
			set	{ 
                  if(this.standardcost != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("StandardCost"));  
                        this.standardcost = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("StandardCost"));
                    }   
                }
        }	
		
        [Column( COL_LISTPRICE, PARAM_LISTPRICE, typeof(decimal))]
                              public virtual decimal ListPrice 
        {
            get { return this.listprice; }
			set	{ 
                  if(this.listprice != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ListPrice"));  
                        this.listprice = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ListPrice"));
                    }   
                }
        }	
		
        [Column( COL_SIZE, PARAM_SIZE )]
                              public virtual string Size 
        {
            get { return this.size; }
			set	{ 
                  if(this.size != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Size"));  
                        this.size = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Size"));
                    }   
                }
        }	
		
        [Column( COL_WEIGHT, PARAM_WEIGHT )]
                              public virtual decimal? Weight 
        {
            get { return this.weight; }
			set	{ 
                  if(this.weight != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Weight"));  
                        this.weight = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Weight"));
                    }   
                }
        }	
		
        [Column( COL_DAYSTOMANUFACTURE, PARAM_DAYSTOMANUFACTURE, default(int))]
                              public virtual int DaysToManufacture 
        {
            get { return this.daystomanufacture; }
			set	{ 
                  if(this.daystomanufacture != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("DaysToManufacture"));  
                        this.daystomanufacture = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("DaysToManufacture"));
                    }   
                }
        }	
		
        [Column( COL_PRODUCTLINE, PARAM_PRODUCTLINE )]
                              public virtual string ProductLine 
        {
            get { return this.productline; }
			set	{ 
                  if(this.productline != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductLine"));  
                        this.productline = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductLine"));
                    }   
                }
        }	
		
        [Column( COL_className, PARAM_className )]
                              public virtual string ClassName 
        {
            get { return this.className; }
			set	{ 
                  if(this.className != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("className"));  
                        this.className = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("className"));
                    }   
                }
        }	
		
        [Column( COL_STYLE, PARAM_STYLE )]
                              public virtual string Style 
        {
            get { return this.style; }
			set	{ 
                  if(this.style != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Style"));  
                        this.style = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Style"));
                    }   
                }
        }	
		
        [Column( COL_SELLSTARTDATE, PARAM_SELLSTARTDATE, typeof(System.DateTime))]
                              public virtual System.DateTime SellStartDate 
        {
            get { return this.sellstartdate; }
			set	{ 
                  if(this.sellstartdate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SellStartDate"));  
                        this.sellstartdate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SellStartDate"));
                    }   
                }
        }	
		
        [Column( COL_SELLENDDATE, PARAM_SELLENDDATE )]
                              public virtual System.DateTime? SellEndDate 
        {
            get { return this.sellenddate; }
			set	{ 
                  if(this.sellenddate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SellEndDate"));  
                        this.sellenddate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SellEndDate"));
                    }   
                }
        }	
		
        [Column( COL_DISCONTINUEDDATE, PARAM_DISCONTINUEDDATE )]
                              public virtual System.DateTime? DiscontinuedDate 
        {
            get { return this.discontinueddate; }
			set	{ 
                  if(this.discontinueddate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("DiscontinuedDate"));  
                        this.discontinueddate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("DiscontinuedDate"));
                    }   
                }
        }	
		
        [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid 
        {
            get { return this.rowguid; }
			set	{ 
                  if(this.rowguid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Rowguid"));  
                        this.rowguid = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Rowguid"));
                    }   
                }
        }	
		
        [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate 
        {
            get { return this.modifieddate; }
			set	{ 
                  if(this.modifieddate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ModifiedDate"));  
                        this.modifieddate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ModifiedDate"));
                    }   
                }
        }	
		
        [Column( COL_PRODUCTMODELID, PARAM_PRODUCTMODELID )]
                              public virtual int? ProductModelID                
        {
            get
            {
                if(this.productModelEntity == null)
                    return this.productmodelid ;
                
                return this.productModelEntity.ProductModelID;            
            }
            set
            {
                if(this.productmodelid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ProductModelID"));                    
                    this.productmodelid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ProductModelID"));
                    
                    this.productModelEntity = null;
                }                
            }          
        }	
        
        [Column( COL_PRODUCTSUBCATEGORYID, PARAM_PRODUCTSUBCATEGORYID )]
                              public virtual int? ProductSubcategoryID                
        {
            get
            {
                if(this.productSubcategoryEntity == null)
                    return this.productsubcategoryid ;
                
                return this.productSubcategoryEntity.ProductSubcategoryID;            
            }
            set
            {
                if(this.productsubcategoryid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ProductSubcategoryID"));                    
                    this.productsubcategoryid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ProductSubcategoryID"));
                    
                    this.productSubcategoryEntity = null;
                }                
            }          
        }	
        
        [Column( COL_SIZEUNITMEASURECODE, PARAM_SIZEUNITMEASURECODE )]
                              public virtual string SizeUnitMeasureCode                
        {
            get
            {
                if(this.sizeunitmeasureEntity == null)
                    return this.sizeunitmeasurecode ;
                
                return this.sizeunitmeasureEntity.UnitMeasureCode;            
            }
            set
            {
                if(this.sizeunitmeasurecode != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("SizeUnitMeasureCode"));                    
                    this.sizeunitmeasurecode = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("SizeUnitMeasureCode"));
                    
                    this.sizeunitmeasureEntity = null;
                }                
            }          
        }	
        
        [Column( COL_WEIGHTUNITMEASURECODE, PARAM_WEIGHTUNITMEASURECODE )]
                              public virtual string WeightUnitMeasureCode                
        {
            get
            {
                if(this.weightunitmeasureEntity == null)
                    return this.weightunitmeasurecode ;
                
                return this.weightunitmeasureEntity.UnitMeasureCode;            
            }
            set
            {
                if(this.weightunitmeasurecode != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("WeightUnitMeasureCode"));                    
                    this.weightunitmeasurecode = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("WeightUnitMeasureCode"));
                    
                    this.weightunitmeasureEntity = null;
                }                
            }          
        }	
        
        public ProductModel ProductModelEntity
        {
            get { 
                    if(this.productModelEntity == null
                       && this.productmodelid.HasValue )
                    {
                        ProductModel productModelQuery = new ProductModel {
                                                        ProductModelID = this.productmodelid.Value  
                                                        };
                        
                        ProductModel[]  productModels = productModelQuery.ToList();                        
                        if(productModels.Length == 1)
                            this.productModelEntity = productModels[0];                        
                    }
                    
                    return this.productModelEntity; 
                }
			set	{ 
                  if(this.productModelEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductModelEntity"));
                        if (this.productModelEntity != null)
                            this.Parents.Remove(this.productModelEntity);                            
                        
                        if((this.productModelEntity = value) != null) 
                            this.Parents.Add(this.productModelEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductModelEntity"));
                        
                        this.productmodelid = this.ProductModelEntity.ProductModelID;
                    }   
                }
        }	
		
        public ProductSubcategory ProductSubcategoryEntity
        {
            get { 
                    if(this.productSubcategoryEntity == null
                       && this.productsubcategoryid.HasValue )
                    {
                        ProductSubcategory productSubcategoryQuery = new ProductSubcategory {
                                                        ProductSubcategoryID = this.productsubcategoryid.Value  
                                                        };
                        
                        ProductSubcategory[]  productSubcategories = productSubcategoryQuery.ToList();                        
                        if(productSubcategories.Length == 1)
                            this.productSubcategoryEntity = productSubcategories[0];                        
                    }
                    
                    return this.productSubcategoryEntity; 
                }
			set	{ 
                  if(this.productSubcategoryEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductSubcategoryEntity"));
                        if (this.productSubcategoryEntity != null)
                            this.Parents.Remove(this.productSubcategoryEntity);                            
                        
                        if((this.productSubcategoryEntity = value) != null) 
                            this.Parents.Add(this.productSubcategoryEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductSubcategoryEntity"));
                        
                        this.productsubcategoryid = this.ProductSubcategoryEntity.ProductSubcategoryID;
                    }   
                }
        }	
		
        public UnitMeasure SizeUnitMeasureEntity
        {
            get { 
                    if(this.sizeunitmeasureEntity == null
                       && this.sizeunitmeasurecode != default(string)) 
                    {
                        UnitMeasure unitMeasureQuery = new UnitMeasure {
                                                        UnitMeasureCode = this.sizeunitmeasurecode  
                                                        };
                        
                        UnitMeasure[]  unitMeasures = unitMeasureQuery.ToList();                        
                        if(unitMeasures.Length == 1)
                            this.sizeunitmeasureEntity = unitMeasures[0];                        
                    }
                    
                    return this.sizeunitmeasureEntity; 
                }
			set	{ 
                  if(this.sizeunitmeasureEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SizeUnitMeasureEntity"));
                        if (this.sizeunitmeasureEntity != null)
                            this.Parents.Remove(this.sizeunitmeasureEntity);                            
                        
                        if((this.sizeunitmeasureEntity = value) != null) 
                            this.Parents.Add(this.sizeunitmeasureEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SizeUnitMeasureEntity"));
                        
                        this.sizeunitmeasurecode = this.SizeUnitMeasureEntity.UnitMeasureCode;
                    }   
                }
        }	
		
        public UnitMeasure WeightUnitMeasureEntity
        {
            get { 
                    if(this.weightunitmeasureEntity == null
                       && this.weightunitmeasurecode != default(string)) 
                    {
                        UnitMeasure unitMeasureQuery = new UnitMeasure {
                                                        UnitMeasureCode = this.weightunitmeasurecode  
                                                        };
                        
                        UnitMeasure[]  unitMeasures = unitMeasureQuery.ToList();                        
                        if(unitMeasures.Length == 1)
                            this.weightunitmeasureEntity = unitMeasures[0];                        
                    }
                    
                    return this.weightunitmeasureEntity; 
                }
			set	{ 
                  if(this.weightunitmeasureEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("WeightUnitMeasureEntity"));
                        if (this.weightunitmeasureEntity != null)
                            this.Parents.Remove(this.weightunitmeasureEntity);                            
                        
                        if((this.weightunitmeasureEntity = value) != null) 
                            this.Parents.Add(this.weightunitmeasureEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("WeightUnitMeasureEntity"));
                        
                        this.weightunitmeasurecode = this.WeightUnitMeasureEntity.UnitMeasureCode;
                    }   
                }
        }	
		
        public EntityCollection< BillOfMaterial> BillOfMaterialComponents 
        {
            get { return this.billOfMaterialComponents;}
        }
        
        public EntityCollection< BillOfMaterial> BillOfMaterialProductAssemblies 
        {
            get { return this.billOfMaterialProductAssemblies;}
        }
        
        public EntityCollection< ProductCostHistory> ProductCostHistories 
        {
            get { return this.productCostHistories;}
        }
        
        public EntityCollection< ProductDocument> ProductDocuments 
        {
            get { return this.productDocuments;}
        }
        
        public EntityCollection< ProductInventory> ProductInventories 
        {
            get { return this.productInventories;}
        }
        
        public EntityCollection< ProductListPriceHistory> ProductListPriceHistories 
        {
            get { return this.productListPriceHistories;}
        }
        
        public EntityCollection< ProductProductPhoto> ProductProductPhotos 
        {
            get { return this.productProductPhotos;}
        }
        
        public EntityCollection< ProductReview> ProductReviews 
        {
            get { return this.productReviews;}
        }
        
        public EntityCollection< TransactionHistory> TransactionHistories 
        {
            get { return this.transactionHistories;}
        }
        
        public EntityCollection< WorkOrder> WorkOrders 
        {
            get { return this.workOrders;}
        }
        
        public EntityCollection< ProductVendor> ProductVendors 
        {
            get { return this.productVendors;}
        }
        
        public EntityCollection< PurchaseOrderDetail> PurchaseOrderDetails 
        {
            get { return this.purchaseOrderDetails;}
        }
        
        public EntityCollection< ShoppingCartItem> ShoppingCartItems 
        {
            get { return this.shoppingCartItems;}
        }
        
        public EntityCollection< SpecialOfferProduct> SpecialOfferProducts 
        {
            get { return this.specialOfferProducts;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public Product()
        {
             this.billOfMaterialComponents = new EntityCollection< BillOfMaterial>(this, new Associate< BillOfMaterial>(this.AssociateBillOfMaterialComponents), new DeAssociate< BillOfMaterial>(this.DeAssociateBillOfMaterialComponents), new GetChildren< BillOfMaterial>(this.GetChildrenBillOfMaterialComponents));
             this.billOfMaterialProductAssemblies = new EntityCollection< BillOfMaterial>(this, new Associate< BillOfMaterial>(this.AssociateBillOfMaterialProductAssemblies), new DeAssociate< BillOfMaterial>(this.DeAssociateBillOfMaterialProductAssemblies), new GetChildren< BillOfMaterial>(this.GetChildrenBillOfMaterialProductAssemblies));
             this.productCostHistories = new EntityCollection< ProductCostHistory>(this, new Associate< ProductCostHistory>(this.AssociateProductCostHistories), new DeAssociate< ProductCostHistory>(this.DeAssociateProductCostHistories), new GetChildren< ProductCostHistory>(this.GetChildrenProductCostHistories));
             this.productDocuments = new EntityCollection< ProductDocument>(this, new Associate< ProductDocument>(this.AssociateProductDocuments), new DeAssociate< ProductDocument>(this.DeAssociateProductDocuments), new GetChildren< ProductDocument>(this.GetChildrenProductDocuments));
             this.productInventories = new EntityCollection< ProductInventory>(this, new Associate< ProductInventory>(this.AssociateProductInventories), new DeAssociate< ProductInventory>(this.DeAssociateProductInventories), new GetChildren< ProductInventory>(this.GetChildrenProductInventories));
             this.productListPriceHistories = new EntityCollection< ProductListPriceHistory>(this, new Associate< ProductListPriceHistory>(this.AssociateProductListPriceHistories), new DeAssociate< ProductListPriceHistory>(this.DeAssociateProductListPriceHistories), new GetChildren< ProductListPriceHistory>(this.GetChildrenProductListPriceHistories));
             this.productProductPhotos = new EntityCollection< ProductProductPhoto>(this, new Associate< ProductProductPhoto>(this.AssociateProductProductPhotos), new DeAssociate< ProductProductPhoto>(this.DeAssociateProductProductPhotos), new GetChildren< ProductProductPhoto>(this.GetChildrenProductProductPhotos));
             this.productReviews = new EntityCollection< ProductReview>(this, new Associate< ProductReview>(this.AssociateProductReviews), new DeAssociate< ProductReview>(this.DeAssociateProductReviews), new GetChildren< ProductReview>(this.GetChildrenProductReviews));
             this.transactionHistories = new EntityCollection< TransactionHistory>(this, new Associate< TransactionHistory>(this.AssociateTransactionHistories), new DeAssociate< TransactionHistory>(this.DeAssociateTransactionHistories), new GetChildren< TransactionHistory>(this.GetChildrenTransactionHistories));
             this.workOrders = new EntityCollection< WorkOrder>(this, new Associate< WorkOrder>(this.AssociateWorkOrders), new DeAssociate< WorkOrder>(this.DeAssociateWorkOrders), new GetChildren< WorkOrder>(this.GetChildrenWorkOrders));
             this.productVendors = new EntityCollection< ProductVendor>(this, new Associate< ProductVendor>(this.AssociateProductVendors), new DeAssociate< ProductVendor>(this.DeAssociateProductVendors), new GetChildren< ProductVendor>(this.GetChildrenProductVendors));
             this.purchaseOrderDetails = new EntityCollection< PurchaseOrderDetail>(this, new Associate< PurchaseOrderDetail>(this.AssociatePurchaseOrderDetails), new DeAssociate< PurchaseOrderDetail>(this.DeAssociatePurchaseOrderDetails), new GetChildren< PurchaseOrderDetail>(this.GetChildrenPurchaseOrderDetails));
             this.shoppingCartItems = new EntityCollection< ShoppingCartItem>(this, new Associate< ShoppingCartItem>(this.AssociateShoppingCartItems), new DeAssociate< ShoppingCartItem>(this.DeAssociateShoppingCartItems), new GetChildren< ShoppingCartItem>(this.GetChildrenShoppingCartItems));
             this.specialOfferProducts = new EntityCollection< SpecialOfferProduct>(this, new Associate< SpecialOfferProduct>(this.AssociateSpecialOfferProducts), new DeAssociate< SpecialOfferProduct>(this.DeAssociateSpecialOfferProducts), new GetChildren< SpecialOfferProduct>(this.GetChildrenSpecialOfferProducts));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.productid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            Product entity = obj as Product;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.ProductID == entity.ProductID
                        && this.ProductID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.productid = (int)reader[COL_PRODUCTID];
			this.name = (string)reader[COL_NAME];
			this.productnumber = (string)reader[COL_PRODUCTNUMBER];
			this.makeflag = (bool)reader[COL_MAKEFLAG];
			this.finishedgoodsflag = (bool)reader[COL_FINISHEDGOODSFLAG];
			this.color = DbConvert.ToString(reader[COL_COLOR]);
			this.safetystocklevel = (short)reader[COL_SAFETYSTOCKLEVEL];
			this.reorderpoint = (short)reader[COL_REORDERPOINT];
			this.standardcost = (decimal)reader[COL_STANDARDCOST];
			this.listprice = (decimal)reader[COL_LISTPRICE];
			this.size = DbConvert.ToString(reader[COL_SIZE]);
			this.sizeunitmeasurecode = DbConvert.ToString(reader[COL_SIZEUNITMEASURECODE]);
			this.weightunitmeasurecode = DbConvert.ToString(reader[COL_WEIGHTUNITMEASURECODE]);
			this.weight = DbConvert.ToNullable< decimal >(reader[COL_WEIGHT]);
			this.daystomanufacture = (int)reader[COL_DAYSTOMANUFACTURE];
			this.productline = DbConvert.ToString(reader[COL_PRODUCTLINE]);
			this.className = DbConvert.ToString(reader[COL_className]);
			this.style = DbConvert.ToString(reader[COL_STYLE]);
			this.productsubcategoryid = DbConvert.ToNullable< int >(reader[COL_PRODUCTSUBCATEGORYID]);
			this.productmodelid = DbConvert.ToNullable< int >(reader[COL_PRODUCTMODELID]);
			this.sellstartdate = (System.DateTime)reader[COL_SELLSTARTDATE];
			this.sellenddate = DbConvert.ToNullable< System.DateTime >(reader[COL_SELLENDDATE]);
			this.discontinueddate = DbConvert.ToNullable< System.DateTime >(reader[COL_DISCONTINUEDDATE]);
			this.rowguid = (System.Guid)reader[COL_ROWGUID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
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
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.className), PARAM_className));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Style), PARAM_STYLE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ProductSubcategoryID), PARAM_PRODUCTSUBCATEGORYID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ProductModelID), PARAM_PRODUCTMODELID));
				command.Parameters.Add(dataContext.CreateParameter(this.SellStartDate, PARAM_SELLSTARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.SellEndDate), PARAM_SELLENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.DiscontinuedDate), PARAM_DISCONTINUEDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.ProductID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
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
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.className), PARAM_className));
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
        
        #region Entity Relationship Functions
        
        private void AssociateBillOfMaterialComponents(BillOfMaterial billOfMaterial)
        {
           billOfMaterial.ComponentEntity = this;
        }
        
        private void DeAssociateBillOfMaterialComponents(BillOfMaterial billOfMaterial)
        {
          if(billOfMaterial.ComponentEntity == this)
             billOfMaterial.ComponentEntity = null;
        }
        
        private BillOfMaterial[] GetChildrenBillOfMaterialComponents()
        {
            BillOfMaterial childrenQuery = new BillOfMaterial();
            childrenQuery.ComponentEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateBillOfMaterialProductAssemblies(BillOfMaterial billOfMaterial)
        {
           billOfMaterial.ProductAssemblyEntity = this;
        }
        
        private void DeAssociateBillOfMaterialProductAssemblies(BillOfMaterial billOfMaterial)
        {
          if(billOfMaterial.ProductAssemblyEntity == this)
             billOfMaterial.ProductAssemblyEntity = null;
        }
        
        private BillOfMaterial[] GetChildrenBillOfMaterialProductAssemblies()
        {
            BillOfMaterial childrenQuery = new BillOfMaterial();
            childrenQuery.ProductAssemblyEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateProductCostHistories(ProductCostHistory productCostHistory)
        {
           productCostHistory.ProductEntity = this;
        }
        
        private void DeAssociateProductCostHistories(ProductCostHistory productCostHistory)
        {
          if(productCostHistory.ProductEntity == this)
             productCostHistory.ProductEntity = null;
        }
        
        private ProductCostHistory[] GetChildrenProductCostHistories()
        {
            ProductCostHistory childrenQuery = new ProductCostHistory();
            childrenQuery.ProductEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateProductDocuments(ProductDocument productDocument)
        {
           productDocument.ProductEntity = this;
        }
        
        private void DeAssociateProductDocuments(ProductDocument productDocument)
        {
          if(productDocument.ProductEntity == this)
             productDocument.ProductEntity = null;
        }
        
        private ProductDocument[] GetChildrenProductDocuments()
        {
            ProductDocument childrenQuery = new ProductDocument();
            childrenQuery.ProductEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateProductInventories(ProductInventory productInventory)
        {
           productInventory.ProductEntity = this;
        }
        
        private void DeAssociateProductInventories(ProductInventory productInventory)
        {
          if(productInventory.ProductEntity == this)
             productInventory.ProductEntity = null;
        }
        
        private ProductInventory[] GetChildrenProductInventories()
        {
            ProductInventory childrenQuery = new ProductInventory();
            childrenQuery.ProductEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateProductListPriceHistories(ProductListPriceHistory productListPriceHistory)
        {
           productListPriceHistory.ProductEntity = this;
        }
        
        private void DeAssociateProductListPriceHistories(ProductListPriceHistory productListPriceHistory)
        {
          if(productListPriceHistory.ProductEntity == this)
             productListPriceHistory.ProductEntity = null;
        }
        
        private ProductListPriceHistory[] GetChildrenProductListPriceHistories()
        {
            ProductListPriceHistory childrenQuery = new ProductListPriceHistory();
            childrenQuery.ProductEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateProductProductPhotos(ProductProductPhoto productProductPhoto)
        {
           productProductPhoto.ProductEntity = this;
        }
        
        private void DeAssociateProductProductPhotos(ProductProductPhoto productProductPhoto)
        {
          if(productProductPhoto.ProductEntity == this)
             productProductPhoto.ProductEntity = null;
        }
        
        private ProductProductPhoto[] GetChildrenProductProductPhotos()
        {
            ProductProductPhoto childrenQuery = new ProductProductPhoto();
            childrenQuery.ProductEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateProductReviews(ProductReview productReview)
        {
           productReview.ProductEntity = this;
        }
        
        private void DeAssociateProductReviews(ProductReview productReview)
        {
          if(productReview.ProductEntity == this)
             productReview.ProductEntity = null;
        }
        
        private ProductReview[] GetChildrenProductReviews()
        {
            ProductReview childrenQuery = new ProductReview();
            childrenQuery.ProductEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateTransactionHistories(TransactionHistory transactionHistory)
        {
           transactionHistory.ProductEntity = this;
        }
        
        private void DeAssociateTransactionHistories(TransactionHistory transactionHistory)
        {
          if(transactionHistory.ProductEntity == this)
             transactionHistory.ProductEntity = null;
        }
        
        private TransactionHistory[] GetChildrenTransactionHistories()
        {
            TransactionHistory childrenQuery = new TransactionHistory();
            childrenQuery.ProductEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateWorkOrders(WorkOrder workOrder)
        {
           workOrder.ProductEntity = this;
        }
        
        private void DeAssociateWorkOrders(WorkOrder workOrder)
        {
          if(workOrder.ProductEntity == this)
             workOrder.ProductEntity = null;
        }
        
        private WorkOrder[] GetChildrenWorkOrders()
        {
            WorkOrder childrenQuery = new WorkOrder();
            childrenQuery.ProductEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateProductVendors(ProductVendor productVendor)
        {
           productVendor.ProductEntity = this;
        }
        
        private void DeAssociateProductVendors(ProductVendor productVendor)
        {
          if(productVendor.ProductEntity == this)
             productVendor.ProductEntity = null;
        }
        
        private ProductVendor[] GetChildrenProductVendors()
        {
            ProductVendor childrenQuery = new ProductVendor();
            childrenQuery.ProductEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociatePurchaseOrderDetails(PurchaseOrderDetail purchaseOrderDetail)
        {
           purchaseOrderDetail.ProductEntity = this;
        }
        
        private void DeAssociatePurchaseOrderDetails(PurchaseOrderDetail purchaseOrderDetail)
        {
          if(purchaseOrderDetail.ProductEntity == this)
             purchaseOrderDetail.ProductEntity = null;
        }
        
        private PurchaseOrderDetail[] GetChildrenPurchaseOrderDetails()
        {
            PurchaseOrderDetail childrenQuery = new PurchaseOrderDetail();
            childrenQuery.ProductEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateShoppingCartItems(ShoppingCartItem shoppingCartItem)
        {
           shoppingCartItem.ProductEntity = this;
        }
        
        private void DeAssociateShoppingCartItems(ShoppingCartItem shoppingCartItem)
        {
          if(shoppingCartItem.ProductEntity == this)
             shoppingCartItem.ProductEntity = null;
        }
        
        private ShoppingCartItem[] GetChildrenShoppingCartItems()
        {
            ShoppingCartItem childrenQuery = new ShoppingCartItem();
            childrenQuery.ProductEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateSpecialOfferProducts(SpecialOfferProduct specialOfferProduct)
        {
           specialOfferProduct.ProductEntity = this;
        }
        
        private void DeAssociateSpecialOfferProducts(SpecialOfferProduct specialOfferProduct)
        {
          if(specialOfferProduct.ProductEntity == this)
             specialOfferProduct.ProductEntity = null;
        }
        
        private SpecialOfferProduct[] GetChildrenSpecialOfferProducts()
        {
            SpecialOfferProduct childrenQuery = new SpecialOfferProduct();
            childrenQuery.ProductEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
