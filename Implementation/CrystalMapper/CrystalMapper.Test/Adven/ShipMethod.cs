/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: ShipMethod
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
    public partial class ShipMethod : Entity< ShipMethod>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Purchasing.ShipMethod";	
     
		public const string COL_SHIPMETHODID = "ShipMethodID";
		public const string COL_NAME = "Name";
		public const string COL_SHIPBASE = "ShipBase";
		public const string COL_SHIPRATE = "ShipRate";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SHIPMETHODID = "@ShipMethodID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_SHIPBASE = "@ShipBase";	
        public const string PARAM_SHIPRATE = "@ShipRate";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SHIPMETHOD = "INSERT INTO Purchasing.ShipMethod([Name],[ShipBase],[ShipRate],[rowguid],[ModifiedDate]) VALUES (@Name,@ShipBase,@ShipRate,@rowguid,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_SHIPMETHOD = "UPDATE Purchasing.ShipMethod SET  [Name] = @Name, [ShipBase] = @ShipBase, [ShipRate] = @ShipRate, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate WHERE [ShipMethodID] = @ShipMethodID";
		
		private const string SQL_DELETE_SHIPMETHOD = "DELETE FROM Purchasing.ShipMethod WHERE  [ShipMethodID] = @ShipMethodID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int shipmethodid = default(int);
	
		protected string name = default(string);
	
		protected decimal shipbase = default(decimal);
	
		protected decimal shiprate = default(decimal);
	
		protected System.Guid rowguid = default(System.Guid);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
        protected EntityCollection< PurchaseOrderHeader> purchaseOrderHeaders ;
        
        protected EntityCollection< SalesOrderHeader> salesOrderHeaders ;
        
        #endregion

 		#region Properties	

        [Column( COL_SHIPMETHODID, PARAM_SHIPMETHODID, default(int))]
                              public virtual int ShipMethodID 
        {
            get { return this.shipmethodid; }
			set	{ 
                  if(this.shipmethodid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ShipMethodID"));  
                        this.shipmethodid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ShipMethodID"));
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
		
        [Column( COL_SHIPBASE, PARAM_SHIPBASE, typeof(decimal))]
                              public virtual decimal ShipBase 
        {
            get { return this.shipbase; }
			set	{ 
                  if(this.shipbase != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ShipBase"));  
                        this.shipbase = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ShipBase"));
                    }   
                }
        }	
		
        [Column( COL_SHIPRATE, PARAM_SHIPRATE, typeof(decimal))]
                              public virtual decimal ShipRate 
        {
            get { return this.shiprate; }
			set	{ 
                  if(this.shiprate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ShipRate"));  
                        this.shiprate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ShipRate"));
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
		
        public EntityCollection< PurchaseOrderHeader> PurchaseOrderHeaders 
        {
            get { return this.purchaseOrderHeaders;}
        }
        
        public EntityCollection< SalesOrderHeader> SalesOrderHeaders 
        {
            get { return this.salesOrderHeaders;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public ShipMethod()
        {
             this.purchaseOrderHeaders = new EntityCollection< PurchaseOrderHeader>(this, new Associate< PurchaseOrderHeader>(this.AssociatePurchaseOrderHeaders), new DeAssociate< PurchaseOrderHeader>(this.DeAssociatePurchaseOrderHeaders), new GetChildren< PurchaseOrderHeader>(this.GetChildrenPurchaseOrderHeaders));
             this.salesOrderHeaders = new EntityCollection< SalesOrderHeader>(this, new Associate< SalesOrderHeader>(this.AssociateSalesOrderHeaders), new DeAssociate< SalesOrderHeader>(this.DeAssociateSalesOrderHeaders), new GetChildren< SalesOrderHeader>(this.GetChildrenSalesOrderHeaders));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.shipmethodid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            ShipMethod entity = obj as ShipMethod;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.ShipMethodID == entity.ShipMethodID
                        && this.ShipMethodID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.shipmethodid = (int)reader[COL_SHIPMETHODID];
			this.name = (string)reader[COL_NAME];
			this.shipbase = (decimal)reader[COL_SHIPBASE];
			this.shiprate = (decimal)reader[COL_SHIPRATE];
			this.rowguid = (System.Guid)reader[COL_ROWGUID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SHIPMETHOD))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ShipBase, PARAM_SHIPBASE));
				command.Parameters.Add(dataContext.CreateParameter(this.ShipRate, PARAM_SHIPRATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.ShipMethodID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SHIPMETHOD))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ShipMethodID, PARAM_SHIPMETHODID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ShipBase, PARAM_SHIPBASE));
				command.Parameters.Add(dataContext.CreateParameter(this.ShipRate, PARAM_SHIPRATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SHIPMETHOD))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ShipMethodID, PARAM_SHIPMETHODID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociatePurchaseOrderHeaders(PurchaseOrderHeader purchaseOrderHeader)
        {
           purchaseOrderHeader.ShipMethodEntity = this;
        }
        
        private void DeAssociatePurchaseOrderHeaders(PurchaseOrderHeader purchaseOrderHeader)
        {
          if(purchaseOrderHeader.ShipMethodEntity == this)
             purchaseOrderHeader.ShipMethodEntity = null;
        }
        
        private PurchaseOrderHeader[] GetChildrenPurchaseOrderHeaders()
        {
            PurchaseOrderHeader childrenQuery = new PurchaseOrderHeader();
            childrenQuery.ShipMethodEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateSalesOrderHeaders(SalesOrderHeader salesOrderHeader)
        {
           salesOrderHeader.ShipMethodEntity = this;
        }
        
        private void DeAssociateSalesOrderHeaders(SalesOrderHeader salesOrderHeader)
        {
          if(salesOrderHeader.ShipMethodEntity == this)
             salesOrderHeader.ShipMethodEntity = null;
        }
        
        private SalesOrderHeader[] GetChildrenSalesOrderHeaders()
        {
            SalesOrderHeader childrenQuery = new SalesOrderHeader();
            childrenQuery.ShipMethodEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
