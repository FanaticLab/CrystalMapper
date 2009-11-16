/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: SalesPersonQuotaHistory
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
    public partial class SalesPersonQuotaHistory : Entity< SalesPersonQuotaHistory>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.SalesPersonQuotaHistory";	
     
		public const string COL_BUSINESSENTITYID = "BusinessEntityID";
		public const string COL_QUOTADATE = "QuotaDate";
		public const string COL_SALESQUOTA = "SalesQuota";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_BUSINESSENTITYID = "@BusinessEntityID";	
        public const string PARAM_QUOTADATE = "@QuotaDate";	
        public const string PARAM_SALESQUOTA = "@SalesQuota";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SALESPERSONQUOTAHISTORY = "INSERT INTO Sales.SalesPersonQuotaHistory([BusinessEntityID],[QuotaDate],[SalesQuota],[rowguid],[ModifiedDate]) VALUES (@BusinessEntityID,@QuotaDate,@SalesQuota,@rowguid,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_SALESPERSONQUOTAHISTORY = "UPDATE Sales.SalesPersonQuotaHistory SET  [SalesQuota] = @SalesQuota, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate WHERE [BusinessEntityID] = @BusinessEntityID AND [QuotaDate] = @QuotaDate";
		
		private const string SQL_DELETE_SALESPERSONQUOTAHISTORY = "DELETE FROM Sales.SalesPersonQuotaHistory WHERE  [BusinessEntityID] = @BusinessEntityID AND [QuotaDate] = @QuotaDate ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int businessentityid = default(int);
	
		protected System.DateTime quotadate = default(System.DateTime);
	
		protected decimal salesquotum = default(decimal);
	
		protected System.Guid rowguid = default(System.Guid);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected SalesPerson salesPersonEntity;
	
        #endregion

 		#region Properties	

        [Column( COL_QUOTADATE, PARAM_QUOTADATE, typeof(System.DateTime))]
                              public virtual System.DateTime QuotaDate 
        {
            get { return this.quotadate; }
			set	{ 
                  if(this.quotadate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("QuotaDate"));  
                        this.quotadate = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("QuotaDate"));
                    }   
                }
        }	
		
        [Column( COL_SALESQUOTA, PARAM_SALESQUOTA, typeof(decimal))]
                              public virtual decimal SalesQuota 
        {
            get { return this.salesquotum; }
			set	{ 
                  if(this.salesquotum != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SalesQuota"));  
                        this.salesquotum = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SalesQuota"));
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
		
        [Column( COL_BUSINESSENTITYID, PARAM_BUSINESSENTITYID, default(int))]
                              public virtual int BusinessEntityID                
        {
            get
            {
                if(this.salesPersonEntity == null)
                    return this.businessentityid ;
                
                return this.salesPersonEntity.BusinessEntityID;            
            }
            set
            {
                if(this.businessentityid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("BusinessEntityID"));                    
                    this.businessentityid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("BusinessEntityID"));
                    
                    this.salesPersonEntity = null;
                }                
            }          
        }	
        
        public SalesPerson SalesPersonEntity
        {
            get { 
                    if(this.salesPersonEntity == null
                       && this.businessentityid != default(int)) 
                    {
                        SalesPerson salesPersonQuery = new SalesPerson {
                                                        BusinessEntityID = this.businessentityid  
                                                        };
                        
                        SalesPerson[]  salesPeople = salesPersonQuery.ToList();                        
                        if(salesPeople.Length == 1)
                            this.salesPersonEntity = salesPeople[0];                        
                    }
                    
                    return this.salesPersonEntity; 
                }
			set	{ 
                  if(this.salesPersonEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SalesPersonEntity"));
                        if (this.salesPersonEntity != null)
                            this.Parents.Remove(this.salesPersonEntity);                            
                        
                        if((this.salesPersonEntity = value) != null) 
                            this.Parents.Add(this.salesPersonEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SalesPersonEntity"));
                        
                        this.businessentityid = this.SalesPersonEntity.BusinessEntityID;
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
		
        public SalesPersonQuotaHistory()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.businessentityid.GetHashCode();
                result = (11 * result) + this.quotadate.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            SalesPersonQuotaHistory entity = obj as SalesPersonQuotaHistory;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.BusinessEntityID == entity.BusinessEntityID
                        && this.QuotaDate == entity.QuotaDate
                        && this.BusinessEntityID != default(int)
                        && this.QuotaDate != default(System.DateTime)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.businessentityid = (int)reader[COL_BUSINESSENTITYID];
			this.quotadate = (System.DateTime)reader[COL_QUOTADATE];
			this.salesquotum = (decimal)reader[COL_SALESQUOTA];
			this.rowguid = (System.Guid)reader[COL_ROWGUID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SALESPERSONQUOTAHISTORY))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));
				command.Parameters.Add(dataContext.CreateParameter(this.QuotaDate, PARAM_QUOTADATE));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesQuota, PARAM_SALESQUOTA));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SALESPERSONQUOTAHISTORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));
				command.Parameters.Add(dataContext.CreateParameter(this.QuotaDate, PARAM_QUOTADATE));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesQuota, PARAM_SALESQUOTA));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SALESPERSONQUOTAHISTORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));				
				command.Parameters.Add(dataContext.CreateParameter(this.QuotaDate, PARAM_QUOTADATE));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
