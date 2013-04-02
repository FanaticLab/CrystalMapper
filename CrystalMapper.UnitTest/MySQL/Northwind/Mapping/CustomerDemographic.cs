/*********************************************************************
 * Author: CrystalMapper (Generated)
 * Date:  Monday, April 01, 2013 8:25 PM
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

namespace CrystalMapper.UnitTest.MySQL.Northwind
{
	[Table(TABLE_NAME)]
    public partial class CustomerDemographic : IRecord, INotifyPropertyChanging, INotifyPropertyChanged
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "customer_demographics";	
     
		public const string COL_CUSTOMERTYPEID = "CustomerTypeID";
		public const string COL_CUSTOMERDESC = "CustomerDesc";
		
        public const string PARAM_CUSTOMERTYPEID = "@CustomerTypeID";	
        public const string PARAM_CUSTOMERDESC = "@CustomerDesc";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_CUSTOMER_DEMOGRAPHICS = "INSERT INTO customer_demographics (CustomerTypeID, CustomerDesc) VALUES ( @CustomerTypeID, @CustomerDesc);"  ;
		
		private const string SQL_UPDATE_CUSTOMER_DEMOGRAPHICS = "UPDATE customer_demographics SETCustomerDesc = @CustomerDesc WHERE CustomerTypeID = @CustomerTypeID";
		
		private const string SQL_DELETE_CUSTOMER_DEMOGRAPHICS = "DELETE FROM customer_demographics WHERE  CustomerTypeID = @CustomerTypeID ";
		
        #endregion
        	  	
        #region Declarations

		protected string customertypeid = default(string);
	
		protected string customerdesc = default(string);
	
        
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
            get { return this.customertypeid; }
			set	{ 
                  if(this.customertypeid != value)
                    {
                        this.OnPropertyChanging("CustomerTypeID");  
                        this.customertypeid = value;                        
                        this.OnPropertyChanged("CustomerTypeID");
                    }   
                }
        }	
		
        [Column(COL_CUSTOMERDESC, PARAM_CUSTOMERDESC )]
        public virtual string CustomerDesc 
        {
            get { return this.customerdesc; }
			set	{ 
                  if(this.customerdesc != value)
                    {
                        this.OnPropertyChanging("CustomerDesc");  
                        this.customerdesc = value;                        
                        this.OnPropertyChanged("CustomerDesc");
                    }   
                }
        }	
		
        public IQueryable<CustomerCustomerDemo> CustomerCustomerDemos 
        { 
            get { return this.CreateQuery<CustomerCustomerDemo>().Where(r => r.CustomerTypeID == CustomerTypeID); }
        }
        
        #endregion        
        
        #region Methods
        
        public override bool Equals(object obj)
        {
            CustomerDemographic record = obj as CustomerDemographic;           
            
            return (object.ReferenceEquals(this, record)                    
                    || (record != null            
                        && this.CustomerTypeID == record.CustomerTypeID
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
        
		void IRecord.Read(DbDataReader reader)
		{       
			this.customertypeid = (string)reader[COL_CUSTOMERTYPEID];
			this.customerdesc = DbConvert.ToString(reader[COL_CUSTOMERDESC]);
		}
		
		bool IRecord.Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_CUSTOMER_DEMOGRAPHICS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CUSTOMERTYPEID, this.CustomerTypeID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CUSTOMERDESC, DbConvert.DbValue(this.CustomerDesc)));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		bool IRecord.Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_CUSTOMER_DEMOGRAPHICS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CUSTOMERTYPEID, this.CustomerTypeID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CUSTOMERDESC, DbConvert.DbValue(this.CustomerDesc)));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		bool IRecord.Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_CUSTOMER_DEMOGRAPHICS))
            {							
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