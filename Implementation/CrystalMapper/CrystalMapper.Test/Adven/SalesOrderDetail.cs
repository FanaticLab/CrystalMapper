/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: SalesOrderDetail
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
    public partial class SalesOrderDetail : Entity< SalesOrderDetail>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.SalesOrderDetail";	
     
		public const string COL_SALESORDERID = "SalesOrderID";
		public const string COL_SALESORDERDETAILID = "SalesOrderDetailID";
		public const string COL_CARRIERTRACKINGNUMBER = "CarrierTrackingNumber";
		public const string COL_ORDERQTY = "OrderQty";
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_SPECIALOFFERID = "SpecialOfferID";
		public const string COL_UNITPRICE = "UnitPrice";
		public const string COL_UNITPRICEDISCOUNT = "UnitPriceDiscount";
		public const string COL_LINETOTAL = "LineTotal";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SALESORDERID = "@SalesOrderID";	
        public const string PARAM_SALESORDERDETAILID = "@SalesOrderDetailID";	
        public const string PARAM_CARRIERTRACKINGNUMBER = "@CarrierTrackingNumber";	
        public const string PARAM_ORDERQTY = "@OrderQty";	
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_SPECIALOFFERID = "@SpecialOfferID";	
        public const string PARAM_UNITPRICE = "@UnitPrice";	
        public const string PARAM_UNITPRICEDISCOUNT = "@UnitPriceDiscount";	
        public const string PARAM_LINETOTAL = "@LineTotal";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SALESORDERDETAIL = "INSERT INTO Sales.SalesOrderDetail([SalesOrderID],[CarrierTrackingNumber],[OrderQty],[ProductID],[SpecialOfferID],[UnitPrice],[UnitPriceDiscount],[LineTotal],[rowguid],[ModifiedDate]) VALUES (@SalesOrderID,@CarrierTrackingNumber,@OrderQty,@ProductID,@SpecialOfferID,@UnitPrice,@UnitPriceDiscount,@LineTotal,@rowguid,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_SALESORDERDETAIL = "UPDATE Sales.SalesOrderDetail SET  [CarrierTrackingNumber] = @CarrierTrackingNumber, [OrderQty] = @OrderQty, [ProductID] = @ProductID, [SpecialOfferID] = @SpecialOfferID, [UnitPrice] = @UnitPrice, [UnitPriceDiscount] = @UnitPriceDiscount, [LineTotal] = @LineTotal, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate WHERE [SalesOrderID] = @SalesOrderID AND [SalesOrderDetailID] = @SalesOrderDetailID";
		
		private const string SQL_DELETE_SALESORDERDETAIL = "DELETE FROM Sales.SalesOrderDetail WHERE  [SalesOrderID] = @SalesOrderID AND [SalesOrderDetailID] = @SalesOrderDetailID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int salesorderid = default(int);
	
		protected int salesorderdetailid = default(int);
	
		protected string carriertrackingnumber = default(string);
	
		protected short orderqty = default(short);
	
		protected int productid = default(int);
	
		protected int specialofferid = default(int);
	
		protected decimal unitprice = default(decimal);
	
		protected decimal unitpricediscount = default(decimal);
	
		protected decimal linetotal = default(decimal);
	
		protected System.Guid rowguid = default(System.Guid);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected SalesOrderHeader salesOrderHeaderEntity;
	
		protected SpecialOfferProduct specialOfferProductEntity;
	
        #endregion

 		#region Properties	

        [Column( COL_SALESORDERDETAILID, PARAM_SALESORDERDETAILID, default(int))]
                              public virtual int SalesOrderDetailID 
        {
            get { return this.salesorderdetailid; }
			set	{ 
                  if(this.salesorderdetailid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SalesOrderDetailID"));  
                        this.salesorderdetailid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SalesOrderDetailID"));
                    }   
                }
        }	
		
        [Column( COL_CARRIERTRACKINGNUMBER, PARAM_CARRIERTRACKINGNUMBER )]
                              public virtual string CarrierTrackingNumber 
        {
            get { return this.carriertrackingnumber; }
			set	{ 
                  if(this.carriertrackingnumber != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CarrierTrackingNumber"));  
                        this.carriertrackingnumber = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CarrierTrackingNumber"));
                    }   
                }
        }	
		
        [Column( COL_ORDERQTY, PARAM_ORDERQTY, default(short))]
                              public virtual short OrderQty 
        {
            get { return this.orderqty; }
			set	{ 
                  if(this.orderqty != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("OrderQty"));  
                        this.orderqty = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("OrderQty"));
                    }   
                }
        }	
		
        [Column( COL_UNITPRICE, PARAM_UNITPRICE, typeof(decimal))]
                              public virtual decimal UnitPrice 
        {
            get { return this.unitprice; }
			set	{ 
                  if(this.unitprice != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("UnitPrice"));  
                        this.unitprice = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("UnitPrice"));
                    }   
                }
        }	
		
        [Column( COL_UNITPRICEDISCOUNT, PARAM_UNITPRICEDISCOUNT, typeof(decimal))]
                              public virtual decimal UnitPriceDiscount 
        {
            get { return this.unitpricediscount; }
			set	{ 
                  if(this.unitpricediscount != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("UnitPriceDiscount"));  
                        this.unitpricediscount = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("UnitPriceDiscount"));
                    }   
                }
        }	
		
        [Column( COL_LINETOTAL, PARAM_LINETOTAL, typeof(decimal))]
                              public virtual decimal LineTotal 
        {
            get { return this.linetotal; }
			set	{ 
                  if(this.linetotal != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("LineTotal"));  
                        this.linetotal = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("LineTotal"));
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
		
        [Column( COL_SALESORDERID, PARAM_SALESORDERID, default(int))]
                              public virtual int SalesOrderID                
        {
            get
            {
                if(this.salesOrderHeaderEntity == null)
                    return this.salesorderid ;
                
                return this.salesOrderHeaderEntity.SalesOrderID;            
            }
            set
            {
                if(this.salesorderid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("SalesOrderID"));                    
                    this.salesorderid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("SalesOrderID"));
                    
                    this.salesOrderHeaderEntity = null;
                }                
            }          
        }	
        
        [Column( COL_SPECIALOFFERID, PARAM_SPECIALOFFERID, default(int))]
                              public virtual int SpecialOfferID                
        {
            get
            {
                if(this.specialOfferProductEntity == null)
                    return this.specialofferid ;
                
                return this.specialOfferProductEntity.SpecialOfferID;            
            }
            set
            {
                if(this.specialofferid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("SpecialOfferID"));                    
                    this.specialofferid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("SpecialOfferID"));
                    
                    this.specialOfferProductEntity = null;
                }                
            }          
        }	
        
        [Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID                
        {
            get
            {
                if(this.specialOfferProductEntity == null)
                    return this.productid ;
                
                return this.specialOfferProductEntity.ProductID;            
            }
            set
            {
                if(this.productid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ProductID"));                    
                    this.productid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ProductID"));
                    
                    this.specialOfferProductEntity = null;
                }                
            }          
        }	
        
        public SalesOrderHeader SalesOrderHeaderEntity
        {
            get { 
                    if(this.salesOrderHeaderEntity == null
                       && this.salesorderid != default(int)) 
                    {
                        SalesOrderHeader salesOrderHeaderQuery = new SalesOrderHeader {
                                                        SalesOrderID = this.salesorderid  
                                                        };
                        
                        SalesOrderHeader[]  salesOrderHeaders = salesOrderHeaderQuery.ToList();                        
                        if(salesOrderHeaders.Length == 1)
                            this.salesOrderHeaderEntity = salesOrderHeaders[0];                        
                    }
                    
                    return this.salesOrderHeaderEntity; 
                }
			set	{ 
                  if(this.salesOrderHeaderEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SalesOrderHeaderEntity"));
                        if (this.salesOrderHeaderEntity != null)
                            this.Parents.Remove(this.salesOrderHeaderEntity);                            
                        
                        if((this.salesOrderHeaderEntity = value) != null) 
                            this.Parents.Add(this.salesOrderHeaderEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SalesOrderHeaderEntity"));
                        
                        this.salesorderid = this.SalesOrderHeaderEntity.SalesOrderID;
                    }   
                }
        }	
		
        public SpecialOfferProduct SpecialOfferProductEntity
        {
            get { 
                    if(this.specialOfferProductEntity == null
                       && this.specialofferid != default(int) 
                       && this.productid != default(int)) 
                    {
                        SpecialOfferProduct specialOfferProductQuery = new SpecialOfferProduct {
                                                        SpecialOfferID = this.specialofferid  ,
                                                        ProductID = this.productid  
                                                        };
                        
                        SpecialOfferProduct[]  specialOfferProducts = specialOfferProductQuery.ToList();                        
                        if(specialOfferProducts.Length == 1)
                            this.specialOfferProductEntity = specialOfferProducts[0];                        
                    }
                    
                    return this.specialOfferProductEntity; 
                }
			set	{ 
                  if(this.specialOfferProductEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SpecialOfferProductEntity"));
                        if (this.specialOfferProductEntity != null)
                            this.Parents.Remove(this.specialOfferProductEntity);                            
                        
                        if((this.specialOfferProductEntity = value) != null) 
                            this.Parents.Add(this.specialOfferProductEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SpecialOfferProductEntity"));
                        
                        this.specialofferid = this.SpecialOfferProductEntity.SpecialOfferID;
                        this.productid = this.SpecialOfferProductEntity.ProductID;
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
		
        public SalesOrderDetail()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.salesorderid.GetHashCode();
                result = (11 * result) + this.salesorderdetailid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            SalesOrderDetail entity = obj as SalesOrderDetail;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.SalesOrderID == entity.SalesOrderID
                        && this.SalesOrderDetailID == entity.SalesOrderDetailID
                        && this.SalesOrderID != default(int)
                        && this.SalesOrderDetailID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.salesorderid = (int)reader[COL_SALESORDERID];
			this.salesorderdetailid = (int)reader[COL_SALESORDERDETAILID];
			this.carriertrackingnumber = DbConvert.ToString(reader[COL_CARRIERTRACKINGNUMBER]);
			this.orderqty = (short)reader[COL_ORDERQTY];
			this.productid = (int)reader[COL_PRODUCTID];
			this.specialofferid = (int)reader[COL_SPECIALOFFERID];
			this.unitprice = (decimal)reader[COL_UNITPRICE];
			this.unitpricediscount = (decimal)reader[COL_UNITPRICEDISCOUNT];
			this.linetotal = (decimal)reader[COL_LINETOTAL];
			this.rowguid = (System.Guid)reader[COL_ROWGUID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SALESORDERDETAIL))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.SalesOrderID, PARAM_SALESORDERID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CarrierTrackingNumber), PARAM_CARRIERTRACKINGNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.OrderQty, PARAM_ORDERQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.SpecialOfferID, PARAM_SPECIALOFFERID));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitPrice, PARAM_UNITPRICE));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitPriceDiscount, PARAM_UNITPRICEDISCOUNT));
				command.Parameters.Add(dataContext.CreateParameter(this.LineTotal, PARAM_LINETOTAL));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.SalesOrderDetailID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SALESORDERDETAIL))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SalesOrderID, PARAM_SALESORDERID));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesOrderDetailID, PARAM_SALESORDERDETAILID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CarrierTrackingNumber), PARAM_CARRIERTRACKINGNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.OrderQty, PARAM_ORDERQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.SpecialOfferID, PARAM_SPECIALOFFERID));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitPrice, PARAM_UNITPRICE));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitPriceDiscount, PARAM_UNITPRICEDISCOUNT));
				command.Parameters.Add(dataContext.CreateParameter(this.LineTotal, PARAM_LINETOTAL));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SALESORDERDETAIL))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SalesOrderID, PARAM_SALESORDERID));				
				command.Parameters.Add(dataContext.CreateParameter(this.SalesOrderDetailID, PARAM_SALESORDERDETAILID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
