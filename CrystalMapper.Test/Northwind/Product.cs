/*
 * Author: CrystalMapper (Generated)
 * 
 * Date:  Thursday, March 28, 2013 7:07 PM
 * 
 * Class: Product
 * 
 * Email: info@fanaticlab.com
 * 
 * Project: http://crystalmapper.codeplex.com
 *
 * Copyright (c) 2013 FanaticLab
 *
/*/

using System;
using System.Data.Common;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;

using CoreSystem.Data;

using CrystalMapper;
using CrystalMapper.Context;
using CrystalMapper.Mapping;

namespace CrystalMapper.Test.Northwind
{
	[Table(TABLE_NAME)]
    public partial class Product : IRecord 
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "dbo.Products";	
     
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_PRODUCTNAME = "ProductName";
		public const string COL_SUPPLIERID = "SupplierID";
		public const string COL_CATEGORYID = "CategoryID";
		public const string COL_QUANTITYPERUNIT = "QuantityPerUnit";
		public const string COL_UNITPRICE = "UnitPrice";
		public const string COL_UNITSINSTOCK = "UnitsInStock";
		public const string COL_UNITSONORDER = "UnitsOnOrder";
		public const string COL_REORDERLEVEL = "ReorderLevel";
		public const string COL_DISCONTINUED = "Discontinued";
		
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_PRODUCTNAME = "@ProductName";	
        public const string PARAM_SUPPLIERID = "@SupplierID";	
        public const string PARAM_CATEGORYID = "@CategoryID";	
        public const string PARAM_QUANTITYPERUNIT = "@QuantityPerUnit";	
        public const string PARAM_UNITPRICE = "@UnitPrice";	
        public const string PARAM_UNITSINSTOCK = "@UnitsInStock";	
        public const string PARAM_UNITSONORDER = "@UnitsOnOrder";	
        public const string PARAM_REORDERLEVEL = "@ReorderLevel";	
        public const string PARAM_DISCONTINUED = "@Discontinued";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PRODUCTS = "INSERT INTO dbo.Products ( [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES ( @ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued);"   + " SELECT SCOPE_IDENTITY();" ;
		
		private const string SQL_UPDATE_PRODUCTS = "UPDATE dbo.Products SET [ProductName] = @ProductName, [SupplierID] = @SupplierID, [CategoryID] = @CategoryID, [QuantityPerUnit] = @QuantityPerUnit, [UnitPrice] = @UnitPrice, [UnitsInStock] = @UnitsInStock, [UnitsOnOrder] = @UnitsOnOrder, [ReorderLevel] = @ReorderLevel, [Discontinued] = @Discontinued WHERE [ProductID] = @ProductID";
		
		private const string SQL_DELETE_PRODUCTS = "DELETE FROM dbo.Products WHERE  [ProductID] = @ProductID ";
		
        #endregion
        	  	
        #region Declarations
        
		protected int productid = default(int);
	
		protected string productname = default(string);
	
		protected int? supplierid = default(int?);
	
		protected int? categoryid = default(int?);
	
		protected string quantityperunit = default(string);
	
		protected decimal? unitprice = default(decimal?);
	
		protected short? unitsinstock = default(short?);
	
		protected short? unitsonorder = default(short?);
	
		protected short? reorderlevel = default(short?);
	
		protected bool discontinued = default(bool);
	
		protected Category categoryRef;
	
		protected Supplier supplierRef;
	
        #endregion

 		#region Properties	
        
        public event PropertyChangedEventHandler PropertyChanged;

        public event PropertyChangingEventHandler PropertyChanging;

        [Column(COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
        public virtual int ProductID 
        {
            get { return this.productid; }
			set	{ 
                  if(this.productid != value)
                    {
                        this.OnPropertyChanging("ProductID");  
                        this.productid = value;                        
                        this.OnPropertyChanged("ProductID");
                    }   
                }
        }	
		
        [Column(COL_PRODUCTNAME, PARAM_PRODUCTNAME )]
        public virtual string ProductName 
        {
            get { return this.productname; }
			set	{ 
                  if(this.productname != value)
                    {
                        this.OnPropertyChanging("ProductName");  
                        this.productname = value;                        
                        this.OnPropertyChanged("ProductName");
                    }   
                }
        }	
		
        [Column(COL_QUANTITYPERUNIT, PARAM_QUANTITYPERUNIT )]
        public virtual string QuantityPerUnit 
        {
            get { return this.quantityperunit; }
			set	{ 
                  if(this.quantityperunit != value)
                    {
                        this.OnPropertyChanging("QuantityPerUnit");  
                        this.quantityperunit = value;                        
                        this.OnPropertyChanged("QuantityPerUnit");
                    }   
                }
        }	
		
        [Column(COL_UNITPRICE, PARAM_UNITPRICE )]
        public virtual decimal? UnitPrice 
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
		
        [Column(COL_UNITSINSTOCK, PARAM_UNITSINSTOCK )]
        public virtual short? UnitsInStock 
        {
            get { return this.unitsinstock; }
			set	{ 
                  if(this.unitsinstock != value)
                    {
                        this.OnPropertyChanging("UnitsInStock");  
                        this.unitsinstock = value;                        
                        this.OnPropertyChanged("UnitsInStock");
                    }   
                }
        }	
		
        [Column(COL_UNITSONORDER, PARAM_UNITSONORDER )]
        public virtual short? UnitsOnOrder 
        {
            get { return this.unitsonorder; }
			set	{ 
                  if(this.unitsonorder != value)
                    {
                        this.OnPropertyChanging("UnitsOnOrder");  
                        this.unitsonorder = value;                        
                        this.OnPropertyChanged("UnitsOnOrder");
                    }   
                }
        }	
		
        [Column(COL_REORDERLEVEL, PARAM_REORDERLEVEL )]
        public virtual short? ReorderLevel 
        {
            get { return this.reorderlevel; }
			set	{ 
                  if(this.reorderlevel != value)
                    {
                        this.OnPropertyChanging("ReorderLevel");  
                        this.reorderlevel = value;                        
                        this.OnPropertyChanged("ReorderLevel");
                    }   
                }
        }	
		
        [Column(COL_DISCONTINUED, PARAM_DISCONTINUED, default(bool))]
        public virtual bool Discontinued 
        {
            get { return this.discontinued; }
			set	{ 
                  if(this.discontinued != value)
                    {
                        this.OnPropertyChanging("Discontinued");  
                        this.discontinued = value;                        
                        this.OnPropertyChanged("Discontinued");
                    }   
                }
        }	
		
        [Column(COL_CATEGORYID, PARAM_CATEGORYID )]
        public virtual int? CategoryID                
        {
            get
            {
                if(this.categoryRef == null)
                    return this.categoryid ;
                
                return this.categoryRef.CategoryID;            
            }
            set
            {
                if(this.categoryid != value)
                {
                    this.OnPropertyChanging("CategoryID");                    
                    this.categoryid = value;                    
                    this.OnPropertyChanged("CategoryID");
                    
                    this.categoryRef = null;
                }                
            }          
        }	
        
        [Column(COL_SUPPLIERID, PARAM_SUPPLIERID )]
        public virtual int? SupplierID                
        {
            get
            {
                if(this.supplierRef == null)
                    return this.supplierid ;
                
                return this.supplierRef.SupplierID;            
            }
            set
            {
                if(this.supplierid != value)
                {
                    this.OnPropertyChanging("SupplierID");                    
                    this.supplierid = value;                    
                    this.OnPropertyChanged("SupplierID");
                    
                    this.supplierRef = null;
                }                
            }          
        }	
        
        public Category CategoryRef
        {
            get { return this.categoryRef; }
			set	
            { 
                if(this.categoryRef != value)
                {
                    this.OnPropertyChanging("CategoryRef");
                    
                    if((this.categoryRef = value) != null) 
                    {
                        this.categoryid = this.categoryRef.CategoryID;
                    }
                    else
                    {
		                this.categoryid = default(int);
                    }
                    
                    this.OnPropertyChanged("CategoryRef");
                }   
             }
        }	
		
        public Supplier SupplierRef
        {
            get { return this.supplierRef; }
			set	
            { 
                if(this.supplierRef != value)
                {
                    this.OnPropertyChanging("SupplierRef");
                    
                    if((this.supplierRef = value) != null) 
                    {
                        this.supplierid = this.supplierRef.SupplierID;
                    }
                    else
                    {
		                this.supplierid = default(int);
                    }
                    
                    this.OnPropertyChanged("SupplierRef");
                }   
             }
        }	
		
        #endregion        
        
        #region Methods     
        
        public override bool Equals(object obj)
        {
            Product record = obj as Product;           
            
            return (object.ReferenceEquals(this, record)                    
                    || (record != null            
                        && this.ProductID == record.ProductID
                        && this.ProductID != default(int)
                        )
                    );           
        }
        
        public override int GetHashCode()
        {            
            int hashCode = 7;
            
            hashCode = (11 * hashCode) + this.productid.GetHashCode();
                        
            return hashCode;          
        }
        
		void IRecord.Read(DbDataReader reader)
		{       
			this.productid = (int)reader[COL_PRODUCTID];
			this.productname = (string)reader[COL_PRODUCTNAME];
			this.supplierid = DbConvert.ToNullable< int >(reader[COL_SUPPLIERID]);
			this.categoryid = DbConvert.ToNullable< int >(reader[COL_CATEGORYID]);
			this.quantityperunit = DbConvert.ToString(reader[COL_QUANTITYPERUNIT]);
			this.unitprice = DbConvert.ToNullable< decimal >(reader[COL_UNITPRICE]);
			this.unitsinstock = DbConvert.ToNullable< short >(reader[COL_UNITSINSTOCK]);
			this.unitsonorder = DbConvert.ToNullable< short >(reader[COL_UNITSONORDER]);
			this.reorderlevel = DbConvert.ToNullable< short >(reader[COL_REORDERLEVEL]);
			this.discontinued = (bool)reader[COL_DISCONTINUED];
		}
		
		bool IRecord.Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(PARAM_PRODUCTNAME, this.ProductName));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_SUPPLIERID, DbConvert.DbValue(this.SupplierID)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CATEGORYID, DbConvert.DbValue(this.CategoryID)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_QUANTITYPERUNIT, DbConvert.DbValue(this.QuantityPerUnit)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_UNITPRICE, DbConvert.DbValue(this.UnitPrice)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_UNITSINSTOCK, DbConvert.DbValue(this.UnitsInStock)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_UNITSONORDER, DbConvert.DbValue(this.UnitsOnOrder)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_REORDERLEVEL, DbConvert.DbValue(this.ReorderLevel)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_DISCONTINUED, this.Discontinued));
                this.ProductID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		bool IRecord.Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCTS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_PRODUCTID, this.ProductID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_PRODUCTNAME, this.ProductName));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_SUPPLIERID, DbConvert.DbValue(this.SupplierID)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CATEGORYID, DbConvert.DbValue(this.CategoryID)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_QUANTITYPERUNIT, DbConvert.DbValue(this.QuantityPerUnit)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_UNITPRICE, DbConvert.DbValue(this.UnitPrice)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_UNITSINSTOCK, DbConvert.DbValue(this.UnitsInStock)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_UNITSONORDER, DbConvert.DbValue(this.UnitsOnOrder)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_REORDERLEVEL, DbConvert.DbValue(this.ReorderLevel)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_DISCONTINUED, this.Discontinued));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		bool IRecord.Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCTS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_PRODUCTID, this.ProductID));
                return (command.ExecuteNonQuery() == 1);
            }
        }
        
        protected virtual void OnPropertyChanging(string propertyName)
        {
            if(this.PropertyChanging != null)
                this.PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if(this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}