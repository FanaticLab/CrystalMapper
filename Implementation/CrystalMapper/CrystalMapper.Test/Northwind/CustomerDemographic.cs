/*
 * Author: CrystalMapper 
 * 
 * Date:  Saturday, September 22, 2012 8:41 PM
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
		
		private const string SQL_INSERT_CUSTOMERDEMOGRAPHICS = "INSERT INTO dbo.CustomerDemographics ( [CustomerTypeID], [CustomerDesc]) VALUES ( @CustomerTypeID, @CustomerDesc);"  ;
		
		private const string SQL_UPDATE_CUSTOMERDEMOGRAPHICS = "UPDATE dbo.CustomerDemographics SET [CustomerDesc] = @CustomerDesc WHERE [CustomerTypeID] = @CustomerTypeID";
		
		private const string SQL_DELETE_CUSTOMERDEMOGRAPHICS = "DELETE FROM dbo.CustomerDemographics WHERE  [CustomerTypeID] = @CustomerTypeID ";
		
        #endregion
        	  	
        #region Declarations
        
		protected string customertypeid = default(string);
	
		protected string customerdesc = default(string);
	
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
		
        
        #endregion        
        
        #region Methods     
        
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
    }
}
