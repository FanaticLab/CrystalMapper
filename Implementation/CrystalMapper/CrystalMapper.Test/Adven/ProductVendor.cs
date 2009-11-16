/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: ProductVendor
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
    public partial class ProductVendor : Entity< ProductVendor>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Purchasing.ProductVendor";	
     
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_BUSINESSENTITYID = "BusinessEntityID";
		public const string COL_AVERAGELEADTIME = "AverageLeadTime";
		public const string COL_STANDARDPRICE = "StandardPrice";
		public const string COL_LASTRECEIPTCOST = "LastReceiptCost";
		public const string COL_LASTRECEIPTDATE = "LastReceiptDate";
		public const string COL_MINORDERQTY = "MinOrderQty";
		public const string COL_MAXORDERQTY = "MaxOrderQty";
		public const string COL_ONORDERQTY = "OnOrderQty";
		public const string COL_UNITMEASURECODE = "UnitMeasureCode";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_BUSINESSENTITYID = "@BusinessEntityID";	
        public const string PARAM_AVERAGELEADTIME = "@AverageLeadTime";	
        public const string PARAM_STANDARDPRICE = "@StandardPrice";	
        public const string PARAM_LASTRECEIPTCOST = "@LastReceiptCost";	
        public const string PARAM_LASTRECEIPTDATE = "@LastReceiptDate";	
        public const string PARAM_MINORDERQTY = "@MinOrderQty";	
        public const string PARAM_MAXORDERQTY = "@MaxOrderQty";	
        public const string PARAM_ONORDERQTY = "@OnOrderQty";	
        public const string PARAM_UNITMEASURECODE = "@UnitMeasureCode";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PRODUCTVENDOR = "INSERT INTO Purchasing.ProductVendor([ProductID],[BusinessEntityID],[AverageLeadTime],[StandardPrice],[LastReceiptCost],[LastReceiptDate],[MinOrderQty],[MaxOrderQty],[OnOrderQty],[UnitMeasureCode],[ModifiedDate]) VALUES (@ProductID,@BusinessEntityID,@AverageLeadTime,@StandardPrice,@LastReceiptCost,@LastReceiptDate,@MinOrderQty,@MaxOrderQty,@OnOrderQty,@UnitMeasureCode,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_PRODUCTVENDOR = "UPDATE Purchasing.ProductVendor SET  [AverageLeadTime] = @AverageLeadTime, [StandardPrice] = @StandardPrice, [LastReceiptCost] = @LastReceiptCost, [LastReceiptDate] = @LastReceiptDate, [MinOrderQty] = @MinOrderQty, [MaxOrderQty] = @MaxOrderQty, [OnOrderQty] = @OnOrderQty, [UnitMeasureCode] = @UnitMeasureCode, [ModifiedDate] = @ModifiedDate WHERE [ProductID] = @ProductID AND [BusinessEntityID] = @BusinessEntityID";
		
		private const string SQL_DELETE_PRODUCTVENDOR = "DELETE FROM Purchasing.ProductVendor WHERE  [ProductID] = @ProductID AND [BusinessEntityID] = @BusinessEntityID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int productid = default(int);
	
		protected int businessentityid = default(int);
	
		protected int averageleadtime = default(int);
	
		protected decimal standardprice = default(decimal);
	
		protected decimal? lastreceiptcost = default(decimal?);
	
		protected System.DateTime? lastreceiptdate = default(System.DateTime?);
	
		protected int minorderqty = default(int);
	
		protected int maxorderqty = default(int);
	
		protected int? onorderqty = default(int?);
	
		protected string unitmeasurecode = default(string);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected Product productEntity;
	
		protected UnitMeasure unitMeasureEntity;
	
		protected Vendor vendorEntity;
	
        #endregion

 		#region Properties	

        [Column( COL_AVERAGELEADTIME, PARAM_AVERAGELEADTIME, default(int))]
                              public virtual int AverageLeadTime 
        {
            get { return this.averageleadtime; }
			set	{ 
                  if(this.averageleadtime != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("AverageLeadTime"));  
                        this.averageleadtime = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("AverageLeadTime"));
                    }   
                }
        }	
		
        [Column( COL_STANDARDPRICE, PARAM_STANDARDPRICE, typeof(decimal))]
                              public virtual decimal StandardPrice 
        {
            get { return this.standardprice; }
			set	{ 
                  if(this.standardprice != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("StandardPrice"));  
                        this.standardprice = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("StandardPrice"));
                    }   
                }
        }	
		
        [Column( COL_LASTRECEIPTCOST, PARAM_LASTRECEIPTCOST )]
                              public virtual decimal? LastReceiptCost 
        {
            get { return this.lastreceiptcost; }
			set	{ 
                  if(this.lastreceiptcost != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("LastReceiptCost"));  
                        this.lastreceiptcost = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("LastReceiptCost"));
                    }   
                }
        }	
		
        [Column( COL_LASTRECEIPTDATE, PARAM_LASTRECEIPTDATE )]
                              public virtual System.DateTime? LastReceiptDate 
        {
            get { return this.lastreceiptdate; }
			set	{ 
                  if(this.lastreceiptdate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("LastReceiptDate"));  
                        this.lastreceiptdate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("LastReceiptDate"));
                    }   
                }
        }	
		
        [Column( COL_MINORDERQTY, PARAM_MINORDERQTY, default(int))]
                              public virtual int MinOrderQty 
        {
            get { return this.minorderqty; }
			set	{ 
                  if(this.minorderqty != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("MinOrderQty"));  
                        this.minorderqty = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("MinOrderQty"));
                    }   
                }
        }	
		
        [Column( COL_MAXORDERQTY, PARAM_MAXORDERQTY, default(int))]
                              public virtual int MaxOrderQty 
        {
            get { return this.maxorderqty; }
			set	{ 
                  if(this.maxorderqty != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("MaxOrderQty"));  
                        this.maxorderqty = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("MaxOrderQty"));
                    }   
                }
        }	
		
        [Column( COL_ONORDERQTY, PARAM_ONORDERQTY )]
                              public virtual int? OnOrderQty 
        {
            get { return this.onorderqty; }
			set	{ 
                  if(this.onorderqty != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("OnOrderQty"));  
                        this.onorderqty = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("OnOrderQty"));
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
		
        [Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID                
        {
            get
            {
                if(this.productEntity == null)
                    return this.productid ;
                
                return this.productEntity.ProductID;            
            }
            set
            {
                if(this.productid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ProductID"));                    
                    this.productid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ProductID"));
                    
                    this.productEntity = null;
                }                
            }          
        }	
        
        [Column( COL_UNITMEASURECODE, PARAM_UNITMEASURECODE )]
                              public virtual string UnitMeasureCode                
        {
            get
            {
                if(this.unitMeasureEntity == null)
                    return this.unitmeasurecode ;
                
                return this.unitMeasureEntity.UnitMeasureCode;            
            }
            set
            {
                if(this.unitmeasurecode != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("UnitMeasureCode"));                    
                    this.unitmeasurecode = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("UnitMeasureCode"));
                    
                    this.unitMeasureEntity = null;
                }                
            }          
        }	
        
        [Column( COL_BUSINESSENTITYID, PARAM_BUSINESSENTITYID, default(int))]
                              public virtual int BusinessEntityID                
        {
            get
            {
                if(this.vendorEntity == null)
                    return this.businessentityid ;
                
                return this.vendorEntity.BusinessEntityID;            
            }
            set
            {
                if(this.businessentityid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("BusinessEntityID"));                    
                    this.businessentityid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("BusinessEntityID"));
                    
                    this.vendorEntity = null;
                }                
            }          
        }	
        
        public Product ProductEntity
        {
            get { 
                    if(this.productEntity == null
                       && this.productid != default(int)) 
                    {
                        Product productQuery = new Product {
                                                        ProductID = this.productid  
                                                        };
                        
                        Product[]  products = productQuery.ToList();                        
                        if(products.Length == 1)
                            this.productEntity = products[0];                        
                    }
                    
                    return this.productEntity; 
                }
			set	{ 
                  if(this.productEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductEntity"));
                        if (this.productEntity != null)
                            this.Parents.Remove(this.productEntity);                            
                        
                        if((this.productEntity = value) != null) 
                            this.Parents.Add(this.productEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductEntity"));
                        
                        this.productid = this.ProductEntity.ProductID;
                    }   
                }
        }	
		
        public UnitMeasure UnitMeasureEntity
        {
            get { 
                    if(this.unitMeasureEntity == null
                       && this.unitmeasurecode != default(string)) 
                    {
                        UnitMeasure unitMeasureQuery = new UnitMeasure {
                                                        UnitMeasureCode = this.unitmeasurecode  
                                                        };
                        
                        UnitMeasure[]  unitMeasures = unitMeasureQuery.ToList();                        
                        if(unitMeasures.Length == 1)
                            this.unitMeasureEntity = unitMeasures[0];                        
                    }
                    
                    return this.unitMeasureEntity; 
                }
			set	{ 
                  if(this.unitMeasureEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("UnitMeasureEntity"));
                        if (this.unitMeasureEntity != null)
                            this.Parents.Remove(this.unitMeasureEntity);                            
                        
                        if((this.unitMeasureEntity = value) != null) 
                            this.Parents.Add(this.unitMeasureEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("UnitMeasureEntity"));
                        
                        this.unitmeasurecode = this.UnitMeasureEntity.UnitMeasureCode;
                    }   
                }
        }	
		
        public Vendor VendorEntity
        {
            get { 
                    if(this.vendorEntity == null
                       && this.businessentityid != default(int)) 
                    {
                        Vendor vendorQuery = new Vendor {
                                                        BusinessEntityID = this.businessentityid  
                                                        };
                        
                        Vendor[]  vendors = vendorQuery.ToList();                        
                        if(vendors.Length == 1)
                            this.vendorEntity = vendors[0];                        
                    }
                    
                    return this.vendorEntity; 
                }
			set	{ 
                  if(this.vendorEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("VendorEntity"));
                        if (this.vendorEntity != null)
                            this.Parents.Remove(this.vendorEntity);                            
                        
                        if((this.vendorEntity = value) != null) 
                            this.Parents.Add(this.vendorEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("VendorEntity"));
                        
                        this.businessentityid = this.VendorEntity.BusinessEntityID;
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
		
        public ProductVendor()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.productid.GetHashCode();
                result = (11 * result) + this.businessentityid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            ProductVendor entity = obj as ProductVendor;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.ProductID == entity.ProductID
                        && this.BusinessEntityID == entity.BusinessEntityID
                        && this.ProductID != default(int)
                        && this.BusinessEntityID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.productid = (int)reader[COL_PRODUCTID];
			this.businessentityid = (int)reader[COL_BUSINESSENTITYID];
			this.averageleadtime = (int)reader[COL_AVERAGELEADTIME];
			this.standardprice = (decimal)reader[COL_STANDARDPRICE];
			this.lastreceiptcost = DbConvert.ToNullable< decimal >(reader[COL_LASTRECEIPTCOST]);
			this.lastreceiptdate = DbConvert.ToNullable< System.DateTime >(reader[COL_LASTRECEIPTDATE]);
			this.minorderqty = (int)reader[COL_MINORDERQTY];
			this.maxorderqty = (int)reader[COL_MAXORDERQTY];
			this.onorderqty = DbConvert.ToNullable< int >(reader[COL_ONORDERQTY]);
			this.unitmeasurecode = (string)reader[COL_UNITMEASURECODE];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTVENDOR))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));
				command.Parameters.Add(dataContext.CreateParameter(this.AverageLeadTime, PARAM_AVERAGELEADTIME));
				command.Parameters.Add(dataContext.CreateParameter(this.StandardPrice, PARAM_STANDARDPRICE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.LastReceiptCost), PARAM_LASTRECEIPTCOST));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.LastReceiptDate), PARAM_LASTRECEIPTDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.MinOrderQty, PARAM_MINORDERQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.MaxOrderQty, PARAM_MAXORDERQTY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.OnOrderQty), PARAM_ONORDERQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitMeasureCode, PARAM_UNITMEASURECODE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCTVENDOR))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));
				command.Parameters.Add(dataContext.CreateParameter(this.AverageLeadTime, PARAM_AVERAGELEADTIME));
				command.Parameters.Add(dataContext.CreateParameter(this.StandardPrice, PARAM_STANDARDPRICE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.LastReceiptCost), PARAM_LASTRECEIPTCOST));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.LastReceiptDate), PARAM_LASTRECEIPTDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.MinOrderQty, PARAM_MINORDERQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.MaxOrderQty, PARAM_MAXORDERQTY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.OnOrderQty), PARAM_ONORDERQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitMeasureCode, PARAM_UNITMEASURECODE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCTVENDOR))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));				
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
