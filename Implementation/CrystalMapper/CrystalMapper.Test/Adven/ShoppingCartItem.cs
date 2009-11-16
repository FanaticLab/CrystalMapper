/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: ShoppingCartItem
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
    public partial class ShoppingCartItem : Entity< ShoppingCartItem>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.ShoppingCartItem";	
     
		public const string COL_SHOPPINGCARTITEMID = "ShoppingCartItemID";
		public const string COL_SHOPPINGCARTID = "ShoppingCartID";
		public const string COL_QUANTITY = "Quantity";
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_DATECREATED = "DateCreated";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SHOPPINGCARTITEMID = "@ShoppingCartItemID";	
        public const string PARAM_SHOPPINGCARTID = "@ShoppingCartID";	
        public const string PARAM_QUANTITY = "@Quantity";	
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_DATECREATED = "@DateCreated";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SHOPPINGCARTITEM = "INSERT INTO Sales.ShoppingCartItem([ShoppingCartID],[Quantity],[ProductID],[DateCreated],[ModifiedDate]) VALUES (@ShoppingCartID,@Quantity,@ProductID,@DateCreated,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_SHOPPINGCARTITEM = "UPDATE Sales.ShoppingCartItem SET  [ShoppingCartID] = @ShoppingCartID, [Quantity] = @Quantity, [ProductID] = @ProductID, [DateCreated] = @DateCreated, [ModifiedDate] = @ModifiedDate WHERE [ShoppingCartItemID] = @ShoppingCartItemID";
		
		private const string SQL_DELETE_SHOPPINGCARTITEM = "DELETE FROM Sales.ShoppingCartItem WHERE  [ShoppingCartItemID] = @ShoppingCartItemID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int shoppingcartitemid = default(int);
	
		protected string shoppingcartid = default(string);
	
		protected int quantity = default(int);
	
		protected int productid = default(int);
	
		protected System.DateTime datecreated = default(System.DateTime);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected Product productEntity;
	
        #endregion

 		#region Properties	

        [Column( COL_SHOPPINGCARTITEMID, PARAM_SHOPPINGCARTITEMID, default(int))]
                              public virtual int ShoppingCartItemID 
        {
            get { return this.shoppingcartitemid; }
			set	{ 
                  if(this.shoppingcartitemid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ShoppingCartItemID"));  
                        this.shoppingcartitemid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ShoppingCartItemID"));
                    }   
                }
        }	
		
        [Column( COL_SHOPPINGCARTID, PARAM_SHOPPINGCARTID )]
                              public virtual string ShoppingCartID 
        {
            get { return this.shoppingcartid; }
			set	{ 
                  if(this.shoppingcartid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ShoppingCartID"));  
                        this.shoppingcartid = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ShoppingCartID"));
                    }   
                }
        }	
		
        [Column( COL_QUANTITY, PARAM_QUANTITY, default(int))]
                              public virtual int Quantity 
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
		
        [Column( COL_DATECREATED, PARAM_DATECREATED, typeof(System.DateTime))]
                              public virtual System.DateTime DateCreated 
        {
            get { return this.datecreated; }
			set	{ 
                  if(this.datecreated != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("DateCreated"));  
                        this.datecreated = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("DateCreated"));
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
		
        
        #endregion        
        
        #region Methods     
		
        public ShoppingCartItem()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.shoppingcartitemid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            ShoppingCartItem entity = obj as ShoppingCartItem;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.ShoppingCartItemID == entity.ShoppingCartItemID
                        && this.ShoppingCartItemID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.shoppingcartitemid = (int)reader[COL_SHOPPINGCARTITEMID];
			this.shoppingcartid = (string)reader[COL_SHOPPINGCARTID];
			this.quantity = (int)reader[COL_QUANTITY];
			this.productid = (int)reader[COL_PRODUCTID];
			this.datecreated = (System.DateTime)reader[COL_DATECREATED];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SHOPPINGCARTITEM))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ShoppingCartID, PARAM_SHOPPINGCARTID));
				command.Parameters.Add(dataContext.CreateParameter(this.Quantity, PARAM_QUANTITY));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.DateCreated, PARAM_DATECREATED));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.ShoppingCartItemID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SHOPPINGCARTITEM))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ShoppingCartItemID, PARAM_SHOPPINGCARTITEMID));
				command.Parameters.Add(dataContext.CreateParameter(this.ShoppingCartID, PARAM_SHOPPINGCARTID));
				command.Parameters.Add(dataContext.CreateParameter(this.Quantity, PARAM_QUANTITY));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.DateCreated, PARAM_DATECREATED));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SHOPPINGCARTITEM))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ShoppingCartItemID, PARAM_SHOPPINGCARTITEMID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
