/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, March 10, 2010 9:38 PM
 * 
 * Class: OrderDetail
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
using CrystalMapper.Generic;
using CrystalMapper.Generic.Collection;

namespace CrystalMapper.Test.Northwind
{
	[Table(TABLE_NAME)]
    public partial class OrderDetail : Entity< OrderDetail>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "dbo.[Order Details]";	
     
		public const string COL_ORDERID = "OrderID";
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_UNITPRICE = "UnitPrice";
		public const string COL_QUANTITY = "Quantity";
		public const string COL_DISCOUNT = "Discount";
		
        public const string PARAM_ORDERID = "@OrderID";	
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_UNITPRICE = "@UnitPrice";	
        public const string PARAM_QUANTITY = "@Quantity";	
        public const string PARAM_DISCOUNT = "@Discount";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_ORDER_DETAILS = "INSERT INTO dbo.Order Details( [OrderID], [ProductID], [UnitPrice], [Quantity], [Discount]) VALUES ( @OrderID, @ProductID, @UnitPrice, @Quantity, @Discount);"  ;
		
		private const string SQL_UPDATE_ORDER_DETAILS = "UPDATE dbo.Order Details SET  [UnitPrice] = @UnitPrice, [Quantity] = @Quantity, [Discount] = @Discount WHERE [OrderID] = @OrderID AND [ProductID] = @ProductID";
		
		private const string SQL_DELETE_ORDER_DETAILS = "DELETE FROM dbo.Order Details WHERE  [OrderID] = @OrderID AND [ProductID] = @ProductID ";
		
        #endregion
        	  	
        #region Declarations
        
		protected int orderid = default(int);
	
		protected int productid = default(int);
	
		protected decimal unitprice = default(decimal);
	
		protected short quantity = default(short);
	
		protected float discount = default(float);
	
		protected Order orderRef;
	
		protected Product productRef;
	
        #endregion

 		#region Properties	

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
		
        [Column( COL_QUANTITY, PARAM_QUANTITY, default(short))]
                              public virtual short Quantity 
        {
            get { return this.quantity; }
			set	{ 
                  if(this.quantity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Quantity"));  
                        this.quantity = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Quantity"));
                    }   
                }
        }	
		
        [Column( COL_DISCOUNT, PARAM_DISCOUNT, default(float))]
                              public virtual float Discount 
        {
            get { return this.discount; }
			set	{ 
                  if(this.discount != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Discount"));  
                        this.discount = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Discount"));
                    }   
                }
        }	
		
        [Column( COL_ORDERID, PARAM_ORDERID, default(int))]
                              public virtual int OrderID                
        {
            get
            {
                if(this.orderRef == null)
                    return this.orderid ;
                
                return this.orderRef.OrderID;            
            }
            set
            {
                if(this.orderid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("OrderID"));                    
                    this.orderid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("OrderID"));
                    
                    this.orderRef = null;
                }                
            }          
        }	
        
        [Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID                
        {
            get
            {
                if(this.productRef == null)
                    return this.productid ;
                
                return this.productRef.ProductID;            
            }
            set
            {
                if(this.productid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ProductID"));                    
                    this.productid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ProductID"));
                    
                    this.productRef = null;
                }                
            }          
        }	
        
        public Order OrderRef
        {
            get { 
                    if(this.orderRef == null
                       && this.orderid != default(int)) 
                    {
                        Order orderQuery = new Order {
                                                        OrderID = this.orderid  
                                                        };
                        
                        Order[]  orders = orderQuery.ToList();                        
                        if(orders.Length == 1)
                            this.orderRef = orders[0];                        
                    }
                    
                    return this.orderRef; 
                }
			set	{ 
                  if(this.orderRef != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("OrderRef"));
                        if (this.orderRef != null)
                            this.Parents.Remove(this.orderRef);                            
                        
                        if((this.orderRef = value) != null) 
                        {
                            this.Parents.Add(this.orderRef); 
                            this.orderid = this.orderRef.OrderID;
                        }
                        else
                        {
		                    this.orderid = default(int);
                        }
                        this.OnPropertyChanged(new PropertyChangedEventArgs("OrderRef"));
                    }   
                }
        }	
		
        public Product ProductRef
        {
            get { 
                    if(this.productRef == null
                       && this.productid != default(int)) 
                    {
                        Product productQuery = new Product {
                                                        ProductID = this.productid  
                                                        };
                        
                        Product[]  products = productQuery.ToList();                        
                        if(products.Length == 1)
                            this.productRef = products[0];                        
                    }
                    
                    return this.productRef; 
                }
			set	{ 
                  if(this.productRef != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductRef"));
                        if (this.productRef != null)
                            this.Parents.Remove(this.productRef);                            
                        
                        if((this.productRef = value) != null) 
                        {
                            this.Parents.Add(this.productRef); 
                            this.productid = this.productRef.ProductID;
                        }
                        else
                        {
		                    this.productid = default(int);
                        }
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductRef"));
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
		
       public OrderDetail()
        {
        }
        
        public override bool Equals(object obj)
        {
            OrderDetail entity = obj as OrderDetail;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.OrderID == entity.OrderID
                        && this.ProductID == entity.ProductID
                        && this.OrderID != default(int)
                        && this.ProductID != default(int)
                        )
                    );           
        }
        
        public override int GetHashCode()
        {
            
            int hashCode = 7;
            
            hashCode = (11 * hashCode) + this.orderid.GetHashCode();
            hashCode = (11 * hashCode) + this.productid.GetHashCode();
                        
            return hashCode;          
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.orderid = (int)reader[COL_ORDERID];
			this.productid = (int)reader[COL_PRODUCTID];
			this.unitprice = (decimal)reader[COL_UNITPRICE];
			this.quantity = (short)reader[COL_QUANTITY];
			this.discount = (float)reader[COL_DISCOUNT];
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_ORDER_DETAILS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.OrderID, PARAM_ORDERID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitPrice, PARAM_UNITPRICE));
				command.Parameters.Add(dataContext.CreateParameter(this.Quantity, PARAM_QUANTITY));
				command.Parameters.Add(dataContext.CreateParameter(this.Discount, PARAM_DISCOUNT));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_ORDER_DETAILS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.OrderID, PARAM_ORDERID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.UnitPrice, PARAM_UNITPRICE));
				command.Parameters.Add(dataContext.CreateParameter(this.Quantity, PARAM_QUANTITY));
				command.Parameters.Add(dataContext.CreateParameter(this.Discount, PARAM_DISCOUNT));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_ORDER_DETAILS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.OrderID, PARAM_ORDERID));				
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
