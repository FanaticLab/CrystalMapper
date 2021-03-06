﻿/*********************************************************************
 * Author: CrystalMapper (Generated)
 * Date:  Monday, April 01, 2013 7:10 PM
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

namespace CrystalMapper.UnitTest.SQL.Northwind
{
	[Table(TABLE_NAME)]
    public partial class CustomerCustomerDemo : IRecord, INotifyPropertyChanging, INotifyPropertyChanged
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "dbo.CustomerCustomerDemo";	
     
		public const string COL_CUSTOMERID = "CustomerID";
		public const string COL_CUSTOMERTYPEID = "CustomerTypeID";
		
        public const string PARAM_CUSTOMERID = "@CustomerID";	
        public const string PARAM_CUSTOMERTYPEID = "@CustomerTypeID";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_CUSTOMERCUSTOMERDEMO = "INSERT INTO dbo.CustomerCustomerDemo (CustomerID, CustomerTypeID) VALUES ( @CustomerID, @CustomerTypeID);"  ;
		
		private const string SQL_UPDATE_CUSTOMERCUSTOMERDEMO = "UPDATE dbo.CustomerCustomerDemo SET WHERE CustomerID = @CustomerID AND CustomerTypeID = @CustomerTypeID";
		
		private const string SQL_DELETE_CUSTOMERCUSTOMERDEMO = "DELETE FROM dbo.CustomerCustomerDemo WHERE  CustomerID = @CustomerID AND CustomerTypeID = @CustomerTypeID ";
		
        #endregion
        	  	
        #region Declarations

		protected string customerid = default(string);
	
		protected string customertypeid = default(string);
	
		protected CustomerDemographic customerDemographicRef;
	
		protected Customer customerRef;
	
        
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

        [Column(COL_CUSTOMERTYPEID, PARAM_CUSTOMERTYPEID )]
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
                    this.OnPropertyChanging("CustomerTypeID");                    
                    this.customertypeid = value;                    
                    this.OnPropertyChanged("CustomerTypeID");
                    
                    this.customerDemographicRef = null;
                }                
            }          
        }	
        
        [Column(COL_CUSTOMERID, PARAM_CUSTOMERID )]
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
                    this.OnPropertyChanging("CustomerID");                    
                    this.customerid = value;                    
                    this.OnPropertyChanged("CustomerID");
                    
                    this.customerRef = null;
                }                
            }          
        }	
        
        public CustomerDemographic CustomerDemographicRef
        {
            get 
            { 
                if(this.customerDemographicRef == null)
                    this.customerDemographicRef = this.CreateQuery<CustomerDemographic>().First(p => p.CustomerTypeID == this.CustomerTypeID);                    
                
                return this.customerDemographicRef; 
            }
			set	
            { 
                if(this.customerDemographicRef != value)
                {
                    this.OnPropertyChanging("CustomerDemographicRef");
                    
                    this.customertypeid = (this.customerDemographicRef = value) != null ? this.customerDemographicRef.CustomerTypeID : default(string);                  
                    
                    this.OnPropertyChanged("CustomerDemographicRef");
                }   
            }
        }	
		
        public Customer CustomerRef
        {
            get 
            { 
                if(this.customerRef == null)
                    this.customerRef = this.CreateQuery<Customer>().First(p => p.CustomerID == this.CustomerID);                    
                
                return this.customerRef; 
            }
			set	
            { 
                if(this.customerRef != value)
                {
                    this.OnPropertyChanging("CustomerRef");
                    
                    this.customerid = (this.customerRef = value) != null ? this.customerRef.CustomerID : default(string);                  
                    
                    this.OnPropertyChanged("CustomerRef");
                }   
            }
        }	
		
        #endregion        
        
        #region Methods
        
        public override bool Equals(object obj)
        {
            CustomerCustomerDemo record = obj as CustomerCustomerDemo;           
            
            return (object.ReferenceEquals(this, record)                    
                    || (record != null            
                        && this.CustomerID == record.CustomerID
                        && this.CustomerTypeID == record.CustomerTypeID
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
        
		void IRecord.Read(DbDataReader reader)
		{       
			this.customerid = (string)reader[COL_CUSTOMERID];
			this.customertypeid = (string)reader[COL_CUSTOMERTYPEID];
		}
		
		bool IRecord.Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_CUSTOMERCUSTOMERDEMO))
            {	
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CUSTOMERID, this.CustomerID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CUSTOMERTYPEID, this.CustomerTypeID));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		bool IRecord.Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_CUSTOMERCUSTOMERDEMO))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CUSTOMERID, this.CustomerID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CUSTOMERTYPEID, this.CustomerTypeID));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		bool IRecord.Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_CUSTOMERCUSTOMERDEMO))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CUSTOMERID, this.CustomerID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CUSTOMERTYPEID, this.CustomerTypeID));
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