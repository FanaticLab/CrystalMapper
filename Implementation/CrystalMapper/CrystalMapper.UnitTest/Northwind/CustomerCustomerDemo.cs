/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, March 10, 2010 9:38 PM
 * 
 * Class: CustomerCustomerDemo
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

namespace CrystalMapper.UnitTest.Northwind
{
	[Table(TABLE_NAME)]
    public partial class CustomerCustomerDemo : Entity< CustomerCustomerDemo>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "dbo.CustomerCustomerDemo";	
     
		public const string COL_CUSTOMERID = "CustomerID";
		public const string COL_CUSTOMERTYPEID = "CustomerTypeID";
		
        public const string PARAM_CUSTOMERID = "@CustomerID";	
        public const string PARAM_CUSTOMERTYPEID = "@CustomerTypeID";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_CUSTOMERCUSTOMERDEMO = "INSERT INTO dbo.CustomerCustomerDemo( [CustomerID], [CustomerTypeID]) VALUES ( @CustomerID, @CustomerTypeID);"  ;
		
		private const string SQL_UPDATE_CUSTOMERCUSTOMERDEMO = "UPDATE dbo.CustomerCustomerDemo SET  WHERE [CustomerID] = @CustomerID AND [CustomerTypeID] = @CustomerTypeID";
		
		private const string SQL_DELETE_CUSTOMERCUSTOMERDEMO = "DELETE FROM dbo.CustomerCustomerDemo WHERE  [CustomerID] = @CustomerID AND [CustomerTypeID] = @CustomerTypeID ";
		
        #endregion
        	  	
        #region Declarations
        
		protected string customerid = default(string);
	
		protected string customertypeid = default(string);
	
		protected CustomerDemographic customerDemographicRef;
	
		protected Customer customerRef;
	
        #endregion

 		#region Properties	

        [Column( COL_CUSTOMERTYPEID, PARAM_CUSTOMERTYPEID )]
                              public virtual string CustomerTypeID                
        {
            get
            {
                if(this.customerDemographicRef == null)
                    return this.customertypeid ;
                
                return this.customerDemographicRef.CustomerTypeID;            
            }
            set
            {
                if(this.customertypeid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("CustomerTypeID"));                    
                    this.customertypeid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("CustomerTypeID"));
                    
                    this.customerDemographicRef = null;
                }                
            }          
        }	
        
        [Column( COL_CUSTOMERID, PARAM_CUSTOMERID )]
                              public virtual string CustomerID                
        {
            get
            {
                if(this.customerRef == null)
                    return this.customerid ;
                
                return this.customerRef.CustomerID;            
            }
            set
            {
                if(this.customerid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("CustomerID"));                    
                    this.customerid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("CustomerID"));
                    
                    this.customerRef = null;
                }                
            }          
        }	
        
        public CustomerDemographic CustomerDemographicRef
        {
            get { 
                    if(this.customerDemographicRef == null
                       && this.customertypeid != default(string)) 
                    {
                        CustomerDemographic customerDemographicQuery = new CustomerDemographic {
                                                        CustomerTypeID = this.customertypeid  
                                                        };
                        
                        CustomerDemographic[]  customerDemographics = customerDemographicQuery.ToList();                        
                        if(customerDemographics.Length == 1)
                            this.customerDemographicRef = customerDemographics[0];                        
                    }
                    
                    return this.customerDemographicRef; 
                }
			set	{ 
                  if(this.customerDemographicRef != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CustomerDemographicRef"));
                        if (this.customerDemographicRef != null)
                            this.Parents.Remove(this.customerDemographicRef);                            
                        
                        if((this.customerDemographicRef = value) != null) 
                        {
                            this.Parents.Add(this.customerDemographicRef); 
                            this.customertypeid = this.customerDemographicRef.CustomerTypeID;
                        }
                        else
                        {
		                    this.customertypeid = default(string);
                        }
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CustomerDemographicRef"));
                    }   
                }
        }	
		
        public Customer CustomerRef
        {
            get { 
                    if(this.customerRef == null
                       && this.customerid != default(string)) 
                    {
                        Customer customerQuery = new Customer {
                                                        CustomerID = this.customerid  
                                                        };
                        
                        Customer[]  customers = customerQuery.ToList();                        
                        if(customers.Length == 1)
                            this.customerRef = customers[0];                        
                    }
                    
                    return this.customerRef; 
                }
			set	{ 
                  if(this.customerRef != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CustomerRef"));
                        if (this.customerRef != null)
                            this.Parents.Remove(this.customerRef);                            
                        
                        if((this.customerRef = value) != null) 
                        {
                            this.Parents.Add(this.customerRef); 
                            this.customerid = this.customerRef.CustomerID;
                        }
                        else
                        {
		                    this.customerid = default(string);
                        }
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CustomerRef"));
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
		
       public CustomerCustomerDemo()
        {
        }
        
        public override bool Equals(object obj)
        {
            CustomerCustomerDemo entity = obj as CustomerCustomerDemo;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.CustomerID == entity.CustomerID
                        && this.CustomerTypeID == entity.CustomerTypeID
                        && this.CustomerID != default(string)
                        && this.CustomerTypeID != default(string)
                        )
                    );           
        }
        
        public override int GetHashCode()
        {
            
            int hashCode = 7;
            
            hashCode = (11 * hashCode) + this.customerid.GetHashCode();
            hashCode = (11 * hashCode) + this.customertypeid.GetHashCode();
                        
            return hashCode;          
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.customerid = (string)reader[COL_CUSTOMERID];
			this.customertypeid = (string)reader[COL_CUSTOMERTYPEID];
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_CUSTOMERCUSTOMERDEMO))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerTypeID, PARAM_CUSTOMERTYPEID));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_CUSTOMERCUSTOMERDEMO))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerTypeID, PARAM_CUSTOMERTYPEID));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_CUSTOMERCUSTOMERDEMO))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));				
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerTypeID, PARAM_CUSTOMERTYPEID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
