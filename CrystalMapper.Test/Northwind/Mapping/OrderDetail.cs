/*********************************************************************
 * Author: CrystalMapper (Generated)
 * Date:  Saturday, March 30, 2013 6:24 PM
 * Project: http://www.fanaticlab.com/projects/crystalmapper/
 * Copyright (c) 2013 FanaticLab
 *********************************************************************/

using System;
using System.Linq;
using System.Data.Common;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;

using CoreSystem.Data;

using CrystalMapper;
using CrystalMapper.Linq;
using CrystalMapper.Context;
using CrystalMapper.Mapping;

namespace CrystalMapper.Test.Northwind
{
	[Table(TABLE_NAME)]
    public partial class OrderDetail : IRecord, INotifyPropertyChanging, INotifyPropertyChanged
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Order Details";	
     
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
		
		private const string SQL_INSERT_ORDER_DETAILS = "INSERT INTO Order Details ( [OrderID], [ProductID], [UnitPrice], [Quantity], [Discount]) VALUES ( @OrderID, @ProductID, @UnitPrice, @Quantity, @Discount);"  ;
		
		private const string SQL_UPDATE_ORDER_DETAILS = "UPDATE Order Details SET [UnitPrice] = @UnitPrice, [Quantity] = @Quantity, [Discount] = @Discount WHERE [OrderID] = @OrderID AND [ProductID] = @ProductID";
		
		private const string SQL_DELETE_ORDER_DETAILS = "DELETE FROM Order Details WHERE  [OrderID] = @OrderID AND [ProductID] = @ProductID ";
		
        #endregion
        	  	
        #region Declarations

		protected int orderid = default(int);
	
		protected int productid = default(int);
	
		protected decimal unitprice = default(decimal);
	
		protected short quantity = default(short);
	
		protected float discount = default(float);
	
		protected Order orderRef;
	
		protected Product productRef;
	
        
        private event PropertyChangingEventHandler propertyChanging;
        
        private event PropertyChangedEventHandler propertyChanged;
        #endregion

 		#region Properties
        
        event PropertyChangingEventHandler INotifyPropertyChanging.PropertyChanging
        {
            add { this.propertyChanging += value; }
            remove { this.propertyChanging -= value; }
        }
        
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        { 
            add { this.propertyChanged += value; }
            remove { this.propertyChanged -= value; }
        }
        
        IQueryProvider IRecord.Provider { get; set; }

        [Column(COL_UNITPRICE, PARAM_UNITPRICE, typeof(decimal))]
        public virtual decimal UnitPrice 
        {
            get { return this.unitprice; }
			set	{ 
                  if(this.unitprice != value)
                    {
                        this.OnPropertyChanging("UnitPrice");  
                        this.unitprice = value;                        
                        this.OnPropertyChanged("UnitPrice");
                    }   
                }
        }	
		
        [Column(COL_QUANTITY, PARAM_QUANTITY, default(short))]
        public virtual short Quantity 
        {
            get { return this.quantity; }
			set	{ 
                  if(this.quantity != value)
                    {
                        this.OnPropertyChanging("Quantity");  
                        this.quantity = value;                        
                        this.OnPropertyChanged("Quantity");
                    }   
                }
        }	
		
        [Column(COL_DISCOUNT, PARAM_DISCOUNT, default(float))]
        public virtual float Discount 
        {
            get { return this.discount; }
			set	{ 
                  if(this.discount != value)
                    {
                        this.OnPropertyChanging("Discount");  
                        this.discount = value;                        
                        this.OnPropertyChanged("Discount");
                    }   
                }
        }	
		
        [Column(COL_ORDERID, PARAM_ORDERID, default(int))]
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
                    this.OnPropertyChanging("OrderID");                    
                    this.orderid = value;                    
                    this.OnPropertyChanged("OrderID");
                    
                    this.orderRef = null;
                }                
            }          
        }	
        
        [Column(COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
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
                    this.OnPropertyChanging("ProductID");                    
                    this.productid = value;                    
                    this.OnPropertyChanged("ProductID");
                    
                    this.productRef = null;
                }                
            }          
        }	
        
        public Order OrderRef
        {
            get 
            { 
                if(this.orderRef == null)
                    this.orderRef = this.CreateQuery<Order>().First(p => p.OrderID == this.OrderID);                    
                
                return this.orderRef; 
            }
			set	
            { 
                if(this.orderRef != value)
                {
                    this.OnPropertyChanging("OrderRef");
                    
                    this.orderid = (this.orderRef = value) != null ? this.orderRef.OrderID : default(int);                  
                    
                    this.OnPropertyChanged("OrderRef");
                }   
            }
        }	
		
        public Product ProductRef
        {
            get 
            { 
                if(this.productRef == null)
                    this.productRef = this.CreateQuery<Product>().First(p => p.ProductID == this.ProductID);                    
                
                return this.productRef; 
            }
			set	
            { 
                if(this.productRef != value)
                {
                    this.OnPropertyChanging("ProductRef");
                    
                    this.productid = (this.productRef = value) != null ? this.productRef.ProductID : default(int);                  
                    
                    this.OnPropertyChanged("ProductRef");
                }   
            }
        }	
		
        #endregion        
        
        #region Methods
        
        public override bool Equals(object obj)
        {
            OrderDetail record = obj as OrderDetail;           
            
            return (object.ReferenceEquals(this, record)                    
                    || (record != null            
                        && this.OrderID == record.OrderID
                        && this.ProductID == record.ProductID
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
        
		void IRecord.Read(DbDataReader reader)
		{       
			this.orderid = (int)reader[COL_ORDERID];
			this.productid = (int)reader[COL_PRODUCTID];
			this.unitprice = (decimal)reader[COL_UNITPRICE];
			this.quantity = (short)reader[COL_QUANTITY];
			this.discount = (float)reader[COL_DISCOUNT];
		}
		
		bool IRecord.Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_ORDER_DETAILS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(PARAM_ORDERID, this.OrderID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_PRODUCTID, this.ProductID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_UNITPRICE, this.UnitPrice));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_QUANTITY, this.Quantity));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_DISCOUNT, this.Discount));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		bool IRecord.Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_ORDER_DETAILS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_ORDERID, this.OrderID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_PRODUCTID, this.ProductID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_UNITPRICE, this.UnitPrice));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_QUANTITY, this.Quantity));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_DISCOUNT, this.Discount));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		bool IRecord.Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_ORDER_DETAILS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_ORDERID, this.OrderID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_PRODUCTID, this.ProductID));
                return (command.ExecuteNonQuery() == 1);
            }
        }
        
        protected virtual void OnPropertyChanging(string propertyName)
        {
            if(this.propertyChanging != null)
                this.propertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if(this.propertyChanged != null)
                this.propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}