/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, March 10, 2010 9:38 PM
 * 
 * Class: Shipper
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
    public partial class Shipper : Entity< Shipper>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "dbo.Shippers";	
     
		public const string COL_SHIPPERID = "ShipperID";
		public const string COL_COMPANYNAME = "CompanyName";
		public const string COL_PHONE = "Phone";
		
        public const string PARAM_SHIPPERID = "@ShipperID";	
        public const string PARAM_COMPANYNAME = "@CompanyName";	
        public const string PARAM_PHONE = "@Phone";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SHIPPERS = "INSERT INTO dbo.Shippers( [CompanyName], [Phone]) VALUES ( @CompanyName, @Phone);"   + "SELECT SCOPE_IDENTITY();" ;
		
		private const string SQL_UPDATE_SHIPPERS = "UPDATE dbo.Shippers SET  [CompanyName] = @CompanyName, [Phone] = @Phone WHERE [ShipperID] = @ShipperID";
		
		private const string SQL_DELETE_SHIPPERS = "DELETE FROM dbo.Shippers WHERE  [ShipperID] = @ShipperID ";
		
        #endregion
        	  	
        #region Declarations
        
		protected int shipperid = default(int);
	
		protected string companyname = default(string);
	
		protected string phone = default(string);
	
        protected EntityCollection< Order> orders ;
        
        #endregion

 		#region Properties	

        [Column( COL_SHIPPERID, PARAM_SHIPPERID, default(int))]
                              public virtual int ShipperID 
        {
            get { return this.shipperid; }
			set	{ 
                  if(this.shipperid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ShipperID"));  
                        this.shipperid = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ShipperID"));
                    }   
                }
        }	
		
        [Column( COL_COMPANYNAME, PARAM_COMPANYNAME )]
                              public virtual string CompanyName 
        {
            get { return this.companyname; }
			set	{ 
                  if(this.companyname != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CompanyName"));  
                        this.companyname = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CompanyName"));
                    }   
                }
        }	
		
        [Column( COL_PHONE, PARAM_PHONE )]
                              public virtual string Phone 
        {
            get { return this.phone; }
			set	{ 
                  if(this.phone != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Phone"));  
                        this.phone = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Phone"));
                    }   
                }
        }	
		
        public EntityCollection< Order> Orders 
        {
            get { return this.orders;}
        }
        
        
        #endregion        
        
        #region Methods     
		
       public Shipper()
        {
             this.orders = new EntityCollection< Order>(this, new Associate< Order>(this.AssociateOrders), new DeAssociate< Order>(this.DeAssociateOrders), new GetChildren< Order>(this.GetChildrenOrders));
        }
        
        public override bool Equals(object obj)
        {
            Shipper entity = obj as Shipper;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.ShipperID == entity.ShipperID
                        && this.ShipperID != default(int)
                        )
                    );           
        }
        
        public override int GetHashCode()
        {
            
            int hashCode = 7;
            
            hashCode = (11 * hashCode) + this.shipperid.GetHashCode();
                        
            return hashCode;          
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.shipperid = (int)reader[COL_SHIPPERID];
			this.companyname = (string)reader[COL_COMPANYNAME];
			this.phone = DbConvert.ToString(reader[COL_PHONE]);
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SHIPPERS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.CompanyName, PARAM_COMPANYNAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Phone), PARAM_PHONE));
                this.ShipperID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SHIPPERS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ShipperID, PARAM_SHIPPERID));
				command.Parameters.Add(dataContext.CreateParameter(this.CompanyName, PARAM_COMPANYNAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Phone), PARAM_PHONE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SHIPPERS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ShipperID, PARAM_SHIPPERID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateOrders(Order order)
        {
           order.ShipperRef = this;
        }
        
        private void DeAssociateOrders(Order order)
        {
          if(order.ShipperRef == this)
             order.ShipperRef = null;
        }
        
            
        private Order[] GetChildrenOrders()
        {
            if (this.shipperid != default(int))
            {  
                Order childrenQuery = new Order();
                childrenQuery.ShipperRef = this;
                
                return childrenQuery.ToList(); 
            } else return null;
        }
        
        #endregion
    }
}
