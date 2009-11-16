/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: PurchaseOrderDetail
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
    public partial class PurchaseOrderDetail : Entity< PurchaseOrderDetail>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Purchasing.PurchaseOrderDetail";	
     
		public const string COL_PURCHASEORDERID = "PurchaseOrderID";
		public const string COL_PURCHASEORDERDETAILID = "PurchaseOrderDetailID";
		public const string COL_DUEDATE = "DueDate";
		public const string COL_ORDERQTY = "OrderQty";
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_UNITPRICE = "UnitPrice";
		public const string COL_LINETOTAL = "LineTotal";
		public const string COL_RECEIVEDQTY = "ReceivedQty";
		public const string COL_REJECTEDQTY = "RejectedQty";
		public const string COL_STOCKEDQTY = "StockedQty";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PURCHASEORDERID = "@PurchaseOrderID";	
        public const string PARAM_PURCHASEORDERDETAILID = "@PurchaseOrderDetailID";	
        public const string PARAM_DUEDATE = "@DueDate";	
        public const string PARAM_ORDERQTY = "@OrderQty";	
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_UNITPRICE = "@UnitPrice";	
        public const string PARAM_LINETOTAL = "@LineTotal";	
        public const string PARAM_RECEIVEDQTY = "@ReceivedQty";	
        public const string PARAM_REJECTEDQTY = "@RejectedQty";	
        public const string PARAM_STOCKEDQTY = "@StockedQty";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PURCHASEORDERDETAIL = "INSERT INTO Purchasing.PurchaseOrderDetail([PurchaseOrderID],[DueDate],[OrderQty],[ProductID],[UnitPrice],[LineTotal],[ReceivedQty],[RejectedQty],[StockedQty],[ModifiedDate]) VALUES (@PurchaseOrderID,@DueDate,@OrderQty,@ProductID,@UnitPrice,@LineTotal,@ReceivedQty,@RejectedQty,@StockedQty,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_PURCHASEORDERDETAIL = "UPDATE Purchasing.PurchaseOrderDetail SET  [DueDate] = @DueDate, [OrderQty] = @OrderQty, [ProductID] = @ProductID, [UnitPrice] = @UnitPrice, [LineTotal] = @LineTotal, [ReceivedQty] = @ReceivedQty, [RejectedQty] = @RejectedQty, [StockedQty] = @StockedQty, [ModifiedDate] = @ModifiedDate WHERE [PurchaseOrderID] = @PurchaseOrderID AND [PurchaseOrderDetailID] = @PurchaseOrderDetailID";
		
		private const string SQL_DELETE_PURCHASEORDERDETAIL = "DELETE FROM Purchasing.PurchaseOrderDetail WHERE  [PurchaseOrderID] = @PurchaseOrderID AND [PurchaseOrderDetailID] = @PurchaseOrderDetailID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int purchaseorderid = default(int);
	
		protected int purchaseorderdetailid = default(int);
	
		protected System.DateTime duedate = default(System.DateTime);
	
		protected short orderqty = default(short);
	
		protected int productid = default(int);
	
		protected decimal unitprice = default(decimal);
	
		protected decimal linetotal = default(decimal);
	
		protected decimal receivedqty = default(decimal);
	
		protected decimal rejectedqty = default(decimal);
	
		protected decimal stockedqty = default(decimal);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected Product productEntity;
	
		protected PurchaseOrderHeader purchaseOrderHeaderEntity;
	
        #endregion

 		#region Properties	

        [Column( COL_PURCHASEORDERDETAILID, PARAM_PURCHASEORDERDETAILID, default(int))]
                              public virtual int PurchaseOrderDetailID 
        {
            get { return this.purchaseorderdetailid; }
			set	{ 
                  if(this.purchaseorderdetailid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("PurchaseOrderDetailID"));  
                        this.purchaseorderdetailid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("PurchaseOrderDetailID"));
                    }   
                }
        }	
		
        [Column( COL_DUEDATE, PARAM_DUEDATE, typeof(System.DateTime))]
                              public virtual System.DateTime DueDate 
        {
            get { return this.duedate; }
			set	{ 
                  if(this.duedate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("DueDate"));  
                        this.duedate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("DueDate"));
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
		
        [Column( COL_RECEIVEDQTY, PARAM_RECEIVEDQTY, typeof(decimal))]
                              public virtual decimal ReceivedQty 
        {
            get { return this.receivedqty; }
			set	{ 
                  if(this.receivedqty != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ReceivedQty"));  
                        this.receivedqty = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ReceivedQty"));
                    }   
                }
        }	
		
        [Column( COL_REJECTEDQTY, PARAM_REJECTEDQTY, typeof(decimal))]
                              public virtual decimal RejectedQty 
        {
            get { return this.rejectedqty; }
			set	{ 
                  if(this.rejectedqty != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("RejectedQty"));  
                        this.rejectedqty = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("RejectedQty"));
                    }   
                }
        }	
		
        [Column( COL_STOCKEDQTY, PARAM_STOCKEDQTY, typeof(decimal))]
                              public virtual decimal StockedQty 
        {
            get { return this.stockedqty; }
			set	{ 
                  if(this.stockedqty != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("StockedQty"));  
                        this.stockedqty = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("StockedQty"));
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
        
        [Column( COL_PURCHASEORDERID, PARAM_PURCHASEORDERID, default(int))]
                              public virtual int PurchaseOrderID                
        {
            get
            {
                if(this.purchaseOrderHeaderEntity == null)
                    return this.purchaseorderid ;
                
                return this.purchaseOrderHeaderEntity.PurchaseOrderID;            
            }
            set
            {
                if(this.purchaseorderid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("PurchaseOrderID"));                    
                    this.purchaseorderid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("PurchaseOrderID"));
                    
                    this.purchaseOrderHeaderEntity = null;
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
		
        public PurchaseOrderHeader PurchaseOrderHeaderEntity
        {
            get { 
                    if(this.purchaseOrderHeaderEntity == null
                       && this.purchaseorderid != default(int)) 
                    {
                        PurchaseOrderHeader purchaseOrderHeaderQuery = new PurchaseOrderHeader {
                                                        PurchaseOrderID = this.purchaseorderid  
                                                        };
                        
                        PurchaseOrderHeader[]  purchaseOrderHeaders = purchaseOrderHeaderQuery.ToList();                        
                        if(purchaseOrderHeaders.Length == 1)
                            this.purchaseOrderHeaderEntity = purchaseOrderHeaders[0];                        
                    }
                    
                    return this.purchaseOrderHeaderEntity; 
                }
			set	{ 
                  if(this.purchaseOrderHeaderEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("PurchaseOrderHeaderEntity"));
                        if (this.purchaseOrderHeaderEntity != null)
                            this.Parents.Remove(this.purchaseOrderHeaderEntity);                            
                        
                        if((this.purchaseOrderHeaderEntity = value) != null) 
                            this.Parents.Add(this.purchaseOrderHeaderEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("PurchaseOrderHeaderEntity"));
                        
                        this.purchaseorderid = this.PurchaseOrderHeaderEntity.PurchaseOrderID;
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
		
        public PurchaseOrderDetail()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.purchaseorderid.GetHashCode();
                result = (11 * result) + this.purchaseorderdetailid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            PurchaseOrderDetail entity = obj as PurchaseOrderDetail;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.PurchaseOrderID == entity.PurchaseOrderID
                        && this.PurchaseOrderDetailID == entity.PurchaseOrderDetailID
                        && this.PurchaseOrderID != default(int)
                        && this.PurchaseOrderDetailID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.purchaseorderid = (int)reader[COL_PURCHASEORDERID];
			this.purchaseorderdetailid = (int)reader[COL_PURCHASEORDERDETAILID];
			this.duedate = (System.DateTime)reader[COL_DUEDATE];
			this.orderqty = (short)reader[COL_ORDERQTY];
			this.productid = (int)reader[COL_PRODUCTID];
			this.unitprice = (decimal)reader[COL_UNITPRICE];
			this.linetotal = (decimal)reader[COL_LINETOTAL];
			this.receivedqty = (decimal)reader[COL_RECEIVEDQTY];
			this.rejectedqty = (decimal)reader[COL_REJECTEDQTY];
			this.stockedqty = (decimal)reader[COL_STOCKEDQTY];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PURCHASEORDERDETAIL))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.PurchaseOrderID, PARAM_PURCHASEORDERID));
				command.Parameters.Add(dataContext.CreateParameter(this.DueDate, PARAM_DUEDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.OrderQty, PARAM_ORDERQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitPrice, PARAM_UNITPRICE));
				command.Parameters.Add(dataContext.CreateParameter(this.LineTotal, PARAM_LINETOTAL));
				command.Parameters.Add(dataContext.CreateParameter(this.ReceivedQty, PARAM_RECEIVEDQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.RejectedQty, PARAM_REJECTEDQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.StockedQty, PARAM_STOCKEDQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.PurchaseOrderDetailID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PURCHASEORDERDETAIL))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.PurchaseOrderID, PARAM_PURCHASEORDERID));
				command.Parameters.Add(dataContext.CreateParameter(this.PurchaseOrderDetailID, PARAM_PURCHASEORDERDETAILID));
				command.Parameters.Add(dataContext.CreateParameter(this.DueDate, PARAM_DUEDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.OrderQty, PARAM_ORDERQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitPrice, PARAM_UNITPRICE));
				command.Parameters.Add(dataContext.CreateParameter(this.LineTotal, PARAM_LINETOTAL));
				command.Parameters.Add(dataContext.CreateParameter(this.ReceivedQty, PARAM_RECEIVEDQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.RejectedQty, PARAM_REJECTEDQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.StockedQty, PARAM_STOCKEDQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PURCHASEORDERDETAIL))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.PurchaseOrderID, PARAM_PURCHASEORDERID));				
				command.Parameters.Add(dataContext.CreateParameter(this.PurchaseOrderDetailID, PARAM_PURCHASEORDERDETAILID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
