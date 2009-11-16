/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: SalesOrderHeaderSalesReason
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
    public partial class SalesOrderHeaderSalesReason : Entity< SalesOrderHeaderSalesReason>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.SalesOrderHeaderSalesReason";	
     
		public const string COL_SALESORDERID = "SalesOrderID";
		public const string COL_SALESREASONID = "SalesReasonID";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SALESORDERID = "@SalesOrderID";	
        public const string PARAM_SALESREASONID = "@SalesReasonID";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SALESORDERHEADERSALESREASON = "INSERT INTO Sales.SalesOrderHeaderSalesReason([SalesOrderID],[SalesReasonID],[ModifiedDate]) VALUES (@SalesOrderID,@SalesReasonID,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_SALESORDERHEADERSALESREASON = "UPDATE Sales.SalesOrderHeaderSalesReason SET  [ModifiedDate] = @ModifiedDate WHERE [SalesOrderID] = @SalesOrderID AND [SalesReasonID] = @SalesReasonID";
		
		private const string SQL_DELETE_SALESORDERHEADERSALESREASON = "DELETE FROM Sales.SalesOrderHeaderSalesReason WHERE  [SalesOrderID] = @SalesOrderID AND [SalesReasonID] = @SalesReasonID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int salesorderid = default(int);
	
		protected int salesreasonid = default(int);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected SalesOrderHeader salesOrderHeaderEntity;
	
		protected SalesReason salesReasonEntity;
	
        #endregion

 		#region Properties	

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
		
        [Column( COL_SALESORDERID, PARAM_SALESORDERID, default(int))]
                              public virtual int SalesOrderID                
        {
            get
            {
                if(this.salesOrderHeaderEntity == null)
                    return this.salesorderid ;
                
                return this.salesOrderHeaderEntity.SalesOrderID;            
            }
            set
            {
                if(this.salesorderid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("SalesOrderID"));                    
                    this.salesorderid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("SalesOrderID"));
                    
                    this.salesOrderHeaderEntity = null;
                }                
            }          
        }	
        
        [Column( COL_SALESREASONID, PARAM_SALESREASONID, default(int))]
                              public virtual int SalesReasonID                
        {
            get
            {
                if(this.salesReasonEntity == null)
                    return this.salesreasonid ;
                
                return this.salesReasonEntity.SalesReasonID;            
            }
            set
            {
                if(this.salesreasonid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("SalesReasonID"));                    
                    this.salesreasonid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("SalesReasonID"));
                    
                    this.salesReasonEntity = null;
                }                
            }          
        }	
        
        public SalesOrderHeader SalesOrderHeaderEntity
        {
            get { 
                    if(this.salesOrderHeaderEntity == null
                       && this.salesorderid != default(int)) 
                    {
                        SalesOrderHeader salesOrderHeaderQuery = new SalesOrderHeader {
                                                        SalesOrderID = this.salesorderid  
                                                        };
                        
                        SalesOrderHeader[]  salesOrderHeaders = salesOrderHeaderQuery.ToList();                        
                        if(salesOrderHeaders.Length == 1)
                            this.salesOrderHeaderEntity = salesOrderHeaders[0];                        
                    }
                    
                    return this.salesOrderHeaderEntity; 
                }
			set	{ 
                  if(this.salesOrderHeaderEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SalesOrderHeaderEntity"));
                        if (this.salesOrderHeaderEntity != null)
                            this.Parents.Remove(this.salesOrderHeaderEntity);                            
                        
                        if((this.salesOrderHeaderEntity = value) != null) 
                            this.Parents.Add(this.salesOrderHeaderEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SalesOrderHeaderEntity"));
                        
                        this.salesorderid = this.SalesOrderHeaderEntity.SalesOrderID;
                    }   
                }
        }	
		
        public SalesReason SalesReasonEntity
        {
            get { 
                    if(this.salesReasonEntity == null
                       && this.salesreasonid != default(int)) 
                    {
                        SalesReason salesReasonQuery = new SalesReason {
                                                        SalesReasonID = this.salesreasonid  
                                                        };
                        
                        SalesReason[]  salesReasons = salesReasonQuery.ToList();                        
                        if(salesReasons.Length == 1)
                            this.salesReasonEntity = salesReasons[0];                        
                    }
                    
                    return this.salesReasonEntity; 
                }
			set	{ 
                  if(this.salesReasonEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SalesReasonEntity"));
                        if (this.salesReasonEntity != null)
                            this.Parents.Remove(this.salesReasonEntity);                            
                        
                        if((this.salesReasonEntity = value) != null) 
                            this.Parents.Add(this.salesReasonEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SalesReasonEntity"));
                        
                        this.salesreasonid = this.SalesReasonEntity.SalesReasonID;
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
		
        public SalesOrderHeaderSalesReason()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.salesorderid.GetHashCode();
                result = (11 * result) + this.salesreasonid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            SalesOrderHeaderSalesReason entity = obj as SalesOrderHeaderSalesReason;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.SalesOrderID == entity.SalesOrderID
                        && this.SalesReasonID == entity.SalesReasonID
                        && this.SalesOrderID != default(int)
                        && this.SalesReasonID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.salesorderid = (int)reader[COL_SALESORDERID];
			this.salesreasonid = (int)reader[COL_SALESREASONID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SALESORDERHEADERSALESREASON))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.SalesOrderID, PARAM_SALESORDERID));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesReasonID, PARAM_SALESREASONID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SALESORDERHEADERSALESREASON))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SalesOrderID, PARAM_SALESORDERID));
				command.Parameters.Add(dataContext.CreateParameter(this.SalesReasonID, PARAM_SALESREASONID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SALESORDERHEADERSALESREASON))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SalesOrderID, PARAM_SALESORDERID));				
				command.Parameters.Add(dataContext.CreateParameter(this.SalesReasonID, PARAM_SALESREASONID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
