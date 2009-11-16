/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: SalesReason
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
    public partial class SalesReason : Entity< SalesReason>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.SalesReason";	
     
		public const string COL_SALESREASONID = "SalesReasonID";
		public const string COL_NAME = "Name";
		public const string COL_REASONTYPE = "ReasonType";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SALESREASONID = "@SalesReasonID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_REASONTYPE = "@ReasonType";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SALESREASON = "INSERT INTO Sales.SalesReason([Name],[ReasonType],[ModifiedDate]) VALUES (@Name,@ReasonType,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_SALESREASON = "UPDATE Sales.SalesReason SET  [Name] = @Name, [ReasonType] = @ReasonType, [ModifiedDate] = @ModifiedDate WHERE [SalesReasonID] = @SalesReasonID";
		
		private const string SQL_DELETE_SALESREASON = "DELETE FROM Sales.SalesReason WHERE  [SalesReasonID] = @SalesReasonID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int salesreasonid = default(int);
	
		protected string name = default(string);
	
		protected string reasontype = default(string);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
        protected EntityCollection< SalesOrderHeaderSalesReason> salesOrderHeaderSalesReasons ;
        
        #endregion

 		#region Properties	

        [Column( COL_SALESREASONID, PARAM_SALESREASONID, default(int))]
                              public virtual int SalesReasonID 
        {
            get { return this.salesreasonid; }
			set	{ 
                  if(this.salesreasonid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SalesReasonID"));  
                        this.salesreasonid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SalesReasonID"));
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
		
        [Column( COL_REASONTYPE, PARAM_REASONTYPE )]
                              public virtual string ReasonType 
        {
            get { return this.reasontype; }
			set	{ 
                  if(this.reasontype != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ReasonType"));  
                        this.reasontype = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ReasonType"));
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
		
        public EntityCollection< SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons 
        {
            get { return this.salesOrderHeaderSalesReasons;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public SalesReason()
        {
             this.salesOrderHeaderSalesReasons = new EntityCollection< SalesOrderHeaderSalesReason>(this, new Associate< SalesOrderHeaderSalesReason>(this.AssociateSalesOrderHeaderSalesReasons), new DeAssociate< SalesOrderHeaderSalesReason>(this.DeAssociateSalesOrderHeaderSalesReasons), new GetChildren< SalesOrderHeaderSalesReason>(this.GetChildrenSalesOrderHeaderSalesReasons));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.salesreasonid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            SalesReason entity = obj as SalesReason;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.SalesReasonID == entity.SalesReasonID
                        && this.SalesReasonID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.salesreasonid = (int)reader[COL_SALESREASONID];
			this.name = (string)reader[COL_NAME];
			this.reasontype = (string)reader[COL_REASONTYPE];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SALESREASON))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ReasonType, PARAM_REASONTYPE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.SalesReasonID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SALESREASON))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SalesReasonID, PARAM_SALESREASONID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ReasonType, PARAM_REASONTYPE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SALESREASON))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SalesReasonID, PARAM_SALESREASONID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateSalesOrderHeaderSalesReasons(SalesOrderHeaderSalesReason salesOrderHeaderSalesReason)
        {
           salesOrderHeaderSalesReason.SalesReasonEntity = this;
        }
        
        private void DeAssociateSalesOrderHeaderSalesReasons(SalesOrderHeaderSalesReason salesOrderHeaderSalesReason)
        {
          if(salesOrderHeaderSalesReason.SalesReasonEntity == this)
             salesOrderHeaderSalesReason.SalesReasonEntity = null;
        }
        
        private SalesOrderHeaderSalesReason[] GetChildrenSalesOrderHeaderSalesReasons()
        {
            SalesOrderHeaderSalesReason childrenQuery = new SalesOrderHeaderSalesReason();
            childrenQuery.SalesReasonEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
