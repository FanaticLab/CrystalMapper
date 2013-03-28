/*
 * Author: CrystalMapper (Generated)
 * 
 * Date:  Thursday, March 28, 2013 7:47 PM
 * 
 * Class: CustomerDemographic
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

namespace CrystalMapper.UnitTest.Northwind
{
	[Table(TABLE_NAME)]
    public partial class CustomerDemographic : IRecord 
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "dbo.CustomerDemographics";	
     
		public const string COL_CUSTOMERTYPEID = "CustomerTypeID";
		public const string COL_CUSTOMERDESC = "CustomerDesc";
		
        public const string PARAM_CUSTOMERTYPEID = "@CustomerTypeID";	
        public const string PARAM_CUSTOMERDESC = "@CustomerDesc";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_CUSTOMERDEMOGRAPHICS = "INSERT INTO dbo.CustomerDemographics ( [CustomerTypeID], [CustomerDesc]) VALUES ( @CustomerTypeID, @CustomerDesc);"  ;
		
		private const string SQL_UPDATE_CUSTOMERDEMOGRAPHICS = "UPDATE dbo.CustomerDemographics SET [CustomerDesc] = @CustomerDesc WHERE [CustomerTypeID] = @CustomerTypeID";
		
		private const string SQL_DELETE_CUSTOMERDEMOGRAPHICS = "DELETE FROM dbo.CustomerDemographics WHERE  [CustomerTypeID] = @CustomerTypeID ";
		
        #endregion
        	  	
        #region Declarations
        
		protected string customertypeid = default(string);
	
		protected string customerdesc = default(string);
	
        #endregion

 		#region Properties	
        
        public event PropertyChangedEventHandler PropertyChanged;

        public event PropertyChangingEventHandler PropertyChanging;

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
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_CUSTOMERDEMOGRAPHICS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CUSTOMERTYPEID, this.CustomerTypeID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CUSTOMERDESC, DbConvert.DbValue(this.CustomerDesc)));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		bool IRecord.Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_CUSTOMERDEMOGRAPHICS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CUSTOMERTYPEID, this.CustomerTypeID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CUSTOMERDESC, DbConvert.DbValue(this.CustomerDesc)));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		bool IRecord.Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_CUSTOMERDEMOGRAPHICS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CUSTOMERTYPEID, this.CustomerTypeID));
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