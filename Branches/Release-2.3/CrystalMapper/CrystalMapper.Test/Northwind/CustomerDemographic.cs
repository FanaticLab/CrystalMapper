/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, March 10, 2010 9:38 PM
 * 
 * Class: CustomerDemographic
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
    public partial class CustomerDemographic : Entity< CustomerDemographic>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "dbo.CustomerDemographics";	
     
		public const string COL_CUSTOMERTYPEID = "CustomerTypeID";
		public const string COL_CUSTOMERDESC = "CustomerDesc";
		
        public const string PARAM_CUSTOMERTYPEID = "@CustomerTypeID";	
        public const string PARAM_CUSTOMERDESC = "@CustomerDesc";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_CUSTOMERDEMOGRAPHICS = "INSERT INTO dbo.CustomerDemographics( [CustomerTypeID], [CustomerDesc]) VALUES ( @CustomerTypeID, @CustomerDesc);"  ;
		
		private const string SQL_UPDATE_CUSTOMERDEMOGRAPHICS = "UPDATE dbo.CustomerDemographics SET  [CustomerDesc] = @CustomerDesc WHERE [CustomerTypeID] = @CustomerTypeID";
		
		private const string SQL_DELETE_CUSTOMERDEMOGRAPHICS = "DELETE FROM dbo.CustomerDemographics WHERE  [CustomerTypeID] = @CustomerTypeID ";
		
        #endregion
        	  	
        #region Declarations
        
		protected string customertypeid = default(string);
	
		protected string customerdesc = default(string);
	
        protected EntityCollection< CustomerCustomerDemo> customerCustomerDemos ;
        
        protected EntityCollection< Customer> customers ;
        
        #endregion

 		#region Properties	

        [Column( COL_CUSTOMERTYPEID, PARAM_CUSTOMERTYPEID )]
                              public virtual string CustomerTypeID 
        {
            get { return this.customertypeid; }
			set	{ 
                  if(this.customertypeid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CustomerTypeID"));  
                        this.customertypeid = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CustomerTypeID"));
                    }   
                }
        }	
		
        [Column( COL_CUSTOMERDESC, PARAM_CUSTOMERDESC )]
                              public virtual string CustomerDesc 
        {
            get { return this.customerdesc; }
			set	{ 
                  if(this.customerdesc != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CustomerDesc"));  
                        this.customerdesc = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CustomerDesc"));
                    }   
                }
        }	
		
        public EntityCollection< CustomerCustomerDemo> CustomerCustomerDemos 
        {
            get { return this.customerCustomerDemos;}
        }
        
        public EntityCollection< Customer> Customers 
        {
            get { return this.customers;}
        }  
        
        
        #endregion        
        
        #region Methods     
		
       public CustomerDemographic()
        {
             this.customerCustomerDemos = new EntityCollection< CustomerCustomerDemo>(this, new Associate< CustomerCustomerDemo>(this.AssociateCustomerCustomerDemos), new DeAssociate< CustomerCustomerDemo>(this.DeAssociateCustomerCustomerDemos), new GetChildren< CustomerCustomerDemo>(this.GetChildrenCustomerCustomerDemos));
            this.customers = new EntityCollection< Customer>(this, new Associate< Customer>(this.AssociateCustomers), new DeAssociate< Customer>(this.DeAssociateCustomers), new GetChildren< Customer>(this.GetChildrenCustomers));
        }
        
        public override bool Equals(object obj)
        {
            CustomerDemographic entity = obj as CustomerDemographic;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.CustomerTypeID == entity.CustomerTypeID
                        && this.CustomerTypeID != default(string)
                        )
                    );           
        }
        
        public override int GetHashCode()
        {
            
            int hashCode = 7;
            
            hashCode = (11 * hashCode) + this.customertypeid.GetHashCode();
                        
            return hashCode;          
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.customertypeid = (string)reader[COL_CUSTOMERTYPEID];
			this.customerdesc = DbConvert.ToString(reader[COL_CUSTOMERDESC]);
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_CUSTOMERDEMOGRAPHICS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerTypeID, PARAM_CUSTOMERTYPEID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CustomerDesc), PARAM_CUSTOMERDESC));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_CUSTOMERDEMOGRAPHICS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerTypeID, PARAM_CUSTOMERTYPEID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CustomerDesc), PARAM_CUSTOMERDESC));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_CUSTOMERDEMOGRAPHICS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerTypeID, PARAM_CUSTOMERTYPEID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateCustomerCustomerDemos(CustomerCustomerDemo customerCustomerDemo)
        {
           customerCustomerDemo.CustomerDemographicRef = this;
        }
        
        private void DeAssociateCustomerCustomerDemos(CustomerCustomerDemo customerCustomerDemo)
        {
          if(customerCustomerDemo.CustomerDemographicRef == this)
             customerCustomerDemo.CustomerDemographicRef = null;
        }
        
            
        private CustomerCustomerDemo[] GetChildrenCustomerCustomerDemos()
        {
            if (this.customertypeid != default(string))
            {  
                CustomerCustomerDemo childrenQuery = new CustomerCustomerDemo();
                childrenQuery.CustomerDemographicRef = this;
                
                return childrenQuery.ToList(); 
            } else return null;
        }
        
        private void AssociateCustomers(Customer customer)
        {
           CustomerCustomerDemo customerCustomerDemo = new  CustomerCustomerDemo();                   
           customerCustomerDemo.CustomerRef = customer;
           
           this.customerCustomerDemos.Add(customerCustomerDemo); 
           customer.CustomerCustomerDemos.AddOnly(customerCustomerDemo);
        }
        
        private void DeAssociateCustomers(Customer customer)
        {
           CustomerCustomerDemo removeCustomerCustomerDemo = null; 
           foreach(CustomerCustomerDemo customerCustomerDemo  in  this.customerCustomerDemos)
             if(customerCustomerDemo.CustomerRef == customer)
             {
                customerCustomerDemo.CustomerRef = null;
                removeCustomerCustomerDemo = customerCustomerDemo;
                break;
             }            
            
            if(removeCustomerCustomerDemo != null)
            {
                this.customerCustomerDemos.Remove(removeCustomerCustomerDemo); 
                customer.CustomerCustomerDemos.RemoveOnly(removeCustomerCustomerDemo);
            }
        }
        
        private Customer[] GetChildrenCustomers()
        {
            if (this.customertypeid != default(string))
            {
                this.customerCustomerDemos.Load() ;
                
                string sqlQuery = @"SELECT dbo.Customers.*
                                    FROM dbo.CustomerCustomerDemo
                                    INNER JOIN dbo.Customers ON                                                                            
                                    dbo.CustomerCustomerDemo.[CustomerID] = dbo.Customers.[CustomerID] AND
                                    dbo.CustomerCustomerDemo.[CustomerTypeID] = @CustomerTypeID  
                                    ";
                                    
                Dictionary<string, object> parameterValues = new Dictionary<string, object>();
                parameterValues.Add(PARAM_CUSTOMERTYPEID, this.CustomerTypeID);
                
                return Customer.ToList(sqlQuery, parameterValues);            
            }
            else return null;            
        }  
        
        #endregion
    }
}
