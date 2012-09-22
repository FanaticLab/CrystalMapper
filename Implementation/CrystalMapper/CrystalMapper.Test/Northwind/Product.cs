/*
 * Author: CrystalMapper 
 * 
 * Date:  Saturday, September 22, 2012 8:41 PM
 * 
 * Class: Product
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

namespace CrystalMapper.Test.Northwind
{
	[Table(TABLE_NAME)]
    public partial class Product : Entity< Product>  
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

        [Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID 
        {
            get { return this.productid; }
			set	{ 
                  if(this.productid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductID"));  
                        this.productid = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductID"));
                    }   
                }
        }	
		
        [Column( COL_PRODUCTNAME, PARAM_PRODUCTNAME )]
                              public virtual string ProductName 
        {
            get { return this.productname; }
			set	{ 
                  if(this.productname != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductName"));  
                        this.productname = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductName"));
                    }   
                }
        }	
		
        [Column( COL_QUANTITYPERUNIT, PARAM_QUANTITYPERUNIT )]
                              public virtual string QuantityPerUnit 
        {
            get { return this.quantityperunit; }
			set	{ 
                  if(this.quantityperunit != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("QuantityPerUnit"));  
                        this.quantityperunit = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("QuantityPerUnit"));
                    }   
                }
        }	
		
        [Column( COL_UNITPRICE, PARAM_UNITPRICE )]
                              public virtual decimal? UnitPrice 
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
		
        [Column( COL_UNITSINSTOCK, PARAM_UNITSINSTOCK )]
                              public virtual short? UnitsInStock 
        {
            get { return this.unitsinstock; }
			set	{ 
                  if(this.unitsinstock != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("UnitsInStock"));  
                        this.unitsinstock = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("UnitsInStock"));
                    }   
                }
        }	
		
        [Column( COL_UNITSONORDER, PARAM_UNITSONORDER )]
                              public virtual short? UnitsOnOrder 
        {
            get { return this.unitsonorder; }
			set	{ 
                  if(this.unitsonorder != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("UnitsOnOrder"));  
                        this.unitsonorder = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("UnitsOnOrder"));
                    }   
                }
        }	
		
        [Column( COL_REORDERLEVEL, PARAM_REORDERLEVEL )]
                              public virtual short? ReorderLevel 
        {
            get { return this.reorderlevel; }
			set	{ 
                  if(this.reorderlevel != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ReorderLevel"));  
                        this.reorderlevel = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ReorderLevel"));
                    }   
                }
        }	
		
        [Column( COL_DISCONTINUED, PARAM_DISCONTINUED, default(bool))]
                              public virtual bool Discontinued 
        {
            get { return this.discontinued; }
			set	{ 
                  if(this.discontinued != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Discontinued"));  
                        this.discontinued = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Discontinued"));
                    }   
                }
        }	
		
        [Column( COL_CATEGORYID, PARAM_CATEGORYID )]
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
                    this.OnPropertyChanging(new PropertyChangingEventArgs("CategoryID"));                    
                    this.categoryid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("CategoryID"));
                    
                    this.categoryRef = null;
                }                
            }          
        }	
        
        [Column( COL_SUPPLIERID, PARAM_SUPPLIERID )]
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
                    this.OnPropertyChanging(new PropertyChangingEventArgs("SupplierID"));                    
                    this.supplierid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("SupplierID"));
                    
                    this.supplierRef = null;
                }                
            }          
        }	
        
        public Category CategoryRef
        {
            get { 
                    if(this.categoryRef == null
                       && this.categoryid.HasValue )
                    {
                        Category categoryQuery = new Category {
                                                        CategoryID = this.categoryid.Value  
                                                        };
                        
                        Category[]  categories = categoryQuery.ToList();                        
                        if(categories.Length == 1)
                            this.categoryRef = categories[0];                        
                    }
                    
                    return this.categoryRef; 
                }
			set	{ 
                  if(this.categoryRef != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CategoryRef"));
                        if (this.categoryRef != null)
                            this.Parents.Remove(this.categoryRef);                            
                        
                        if((this.categoryRef = value) != null) 
                        {
                            this.Parents.Add(this.categoryRef); 
                            this.categoryid = this.categoryRef.CategoryID;
                        }
                        else
                        {
		                    this.categoryid = default(int);
                        }
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CategoryRef"));
                    }   
                }
        }	
		
        public Supplier SupplierRef
        {
            get { 
                    if(this.supplierRef == null
                       && this.supplierid.HasValue )
                    {
                        Supplier supplierQuery = new Supplier {
                                                        SupplierID = this.supplierid.Value  
                                                        };
                        
                        Supplier[]  suppliers = supplierQuery.ToList();                        
                        if(suppliers.Length == 1)
                            this.supplierRef = suppliers[0];                        
                    }
                    
                    return this.supplierRef; 
                }
			set	{ 
                  if(this.supplierRef != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SupplierRef"));
                        if (this.supplierRef != null)
                            this.Parents.Remove(this.supplierRef);                            
                        
                        if((this.supplierRef = value) != null) 
                        {
                            this.Parents.Add(this.supplierRef); 
                            this.supplierid = this.supplierRef.SupplierID;
                        }
                        else
                        {
		                    this.supplierid = default(int);
                        }
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SupplierRef"));
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
        
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
        
        public override int GetHashCode()
        {
            
            int hashCode = 7;
            
            hashCode = (11 * hashCode) + this.productid.GetHashCode();
                        
            return hashCode;          
        }
        
		public override void Read(DbDataReader reader)
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
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ProductName, PARAM_PRODUCTNAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.SupplierID), PARAM_SUPPLIERID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CategoryID), PARAM_CATEGORYID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.QuantityPerUnit), PARAM_QUANTITYPERUNIT));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.UnitPrice), PARAM_UNITPRICE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.UnitsInStock), PARAM_UNITSINSTOCK));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.UnitsOnOrder), PARAM_UNITSONORDER));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ReorderLevel), PARAM_REORDERLEVEL));
				command.Parameters.Add(dataContext.CreateParameter(this.Discontinued, PARAM_DISCONTINUED));
                this.ProductID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCTS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductName, PARAM_PRODUCTNAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.SupplierID), PARAM_SUPPLIERID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CategoryID), PARAM_CATEGORYID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.QuantityPerUnit), PARAM_QUANTITYPERUNIT));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.UnitPrice), PARAM_UNITPRICE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.UnitsInStock), PARAM_UNITSINSTOCK));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.UnitsOnOrder), PARAM_UNITSONORDER));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ReorderLevel), PARAM_REORDERLEVEL));
				command.Parameters.Add(dataContext.CreateParameter(this.Discontinued, PARAM_DISCONTINUED));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCTS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
    }
}
