/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: ProductInventory
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
    public partial class ProductInventory : Entity< ProductInventory>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.ProductInventory";	
     
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_LOCATIONID = "LocationID";
		public const string COL_SHELF = "Shelf";
		public const string COL_BIN = "Bin";
		public const string COL_QUANTITY = "Quantity";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_LOCATIONID = "@LocationID";	
        public const string PARAM_SHELF = "@Shelf";	
        public const string PARAM_BIN = "@Bin";	
        public const string PARAM_QUANTITY = "@Quantity";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PRODUCTINVENTORY = "INSERT INTO Production.ProductInventory([ProductID],[LocationID],[Shelf],[Bin],[Quantity],[rowguid],[ModifiedDate]) VALUES (@ProductID,@LocationID,@Shelf,@Bin,@Quantity,@rowguid,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_PRODUCTINVENTORY = "UPDATE Production.ProductInventory SET  [Shelf] = @Shelf, [Bin] = @Bin, [Quantity] = @Quantity, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate WHERE [ProductID] = @ProductID AND [LocationID] = @LocationID";
		
		private const string SQL_DELETE_PRODUCTINVENTORY = "DELETE FROM Production.ProductInventory WHERE  [ProductID] = @ProductID AND [LocationID] = @LocationID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int productid = default(int);
	
		protected short locationid = default(short);
	
		protected string shelf = default(string);
	
		protected byte bin = default(byte);
	
		protected short quantity = default(short);
	
		protected System.Guid rowguid = default(System.Guid);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected Location locationEntity;
	
		protected Product productEntity;
	
        #endregion

 		#region Properties	

        [Column( COL_SHELF, PARAM_SHELF )]
                              public virtual string Shelf 
        {
            get { return this.shelf; }
			set	{ 
                  if(this.shelf != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Shelf"));  
                        this.shelf = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Shelf"));
                    }   
                }
        }	
		
        [Column( COL_BIN, PARAM_BIN, default(byte))]
                              public virtual byte Bin 
        {
            get { return this.bin; }
			set	{ 
                  if(this.bin != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Bin"));  
                        this.bin = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Bin"));
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
		
        [Column( COL_LOCATIONID, PARAM_LOCATIONID, default(short))]
                              public virtual short LocationID                
        {
            get
            {
                if(this.locationEntity == null)
                    return this.locationid ;
                
                return this.locationEntity.LocationID;            
            }
            set
            {
                if(this.locationid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("LocationID"));                    
                    this.locationid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("LocationID"));
                    
                    this.locationEntity = null;
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
        
        public Location LocationEntity
        {
            get { 
                    if(this.locationEntity == null
                       && this.locationid != default(short)) 
                    {
                        Location locationQuery = new Location {
                                                        LocationID = this.locationid  
                                                        };
                        
                        Location[]  locations = locationQuery.ToList();                        
                        if(locations.Length == 1)
                            this.locationEntity = locations[0];                        
                    }
                    
                    return this.locationEntity; 
                }
			set	{ 
                  if(this.locationEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("LocationEntity"));
                        if (this.locationEntity != null)
                            this.Parents.Remove(this.locationEntity);                            
                        
                        if((this.locationEntity = value) != null) 
                            this.Parents.Add(this.locationEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("LocationEntity"));
                        
                        this.locationid = this.LocationEntity.LocationID;
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
		
        public ProductInventory()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.productid.GetHashCode();
                result = (11 * result) + this.locationid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            ProductInventory entity = obj as ProductInventory;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.ProductID == entity.ProductID
                        && this.LocationID == entity.LocationID
                        && this.ProductID != default(int)
                        && this.LocationID != default(short)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.productid = (int)reader[COL_PRODUCTID];
			this.locationid = (short)reader[COL_LOCATIONID];
			this.shelf = (string)reader[COL_SHELF];
			this.bin = (byte)reader[COL_BIN];
			this.quantity = (short)reader[COL_QUANTITY];
			this.rowguid = (System.Guid)reader[COL_ROWGUID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTINVENTORY))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.LocationID, PARAM_LOCATIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.Shelf, PARAM_SHELF));
				command.Parameters.Add(dataContext.CreateParameter(this.Bin, PARAM_BIN));
				command.Parameters.Add(dataContext.CreateParameter(this.Quantity, PARAM_QUANTITY));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCTINVENTORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.LocationID, PARAM_LOCATIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.Shelf, PARAM_SHELF));
				command.Parameters.Add(dataContext.CreateParameter(this.Bin, PARAM_BIN));
				command.Parameters.Add(dataContext.CreateParameter(this.Quantity, PARAM_QUANTITY));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCTINVENTORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));				
				command.Parameters.Add(dataContext.CreateParameter(this.LocationID, PARAM_LOCATIONID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
