/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: TransactionHistoryArchive
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
    public partial class TransactionHistoryArchive : Entity< TransactionHistoryArchive>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.TransactionHistoryArchive";	
     
		public const string COL_TRANSACTIONID = "TransactionID";
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_REFERENCEORDERID = "ReferenceOrderID";
		public const string COL_REFERENCEORDERLINEID = "ReferenceOrderLineID";
		public const string COL_TRANSACTIONDATE = "TransactionDate";
		public const string COL_TRANSACTIONTYPE = "TransactionType";
		public const string COL_QUANTITY = "Quantity";
		public const string COL_ACTUALCOST = "ActualCost";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_TRANSACTIONID = "@TransactionID";	
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_REFERENCEORDERID = "@ReferenceOrderID";	
        public const string PARAM_REFERENCEORDERLINEID = "@ReferenceOrderLineID";	
        public const string PARAM_TRANSACTIONDATE = "@TransactionDate";	
        public const string PARAM_TRANSACTIONTYPE = "@TransactionType";	
        public const string PARAM_QUANTITY = "@Quantity";	
        public const string PARAM_ACTUALCOST = "@ActualCost";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_TRANSACTIONHISTORYARCHIVE = "INSERT INTO Production.TransactionHistoryArchive([TransactionID],[ProductID],[ReferenceOrderID],[ReferenceOrderLineID],[TransactionDate],[TransactionType],[Quantity],[ActualCost],[ModifiedDate]) VALUES (@TransactionID,@ProductID,@ReferenceOrderID,@ReferenceOrderLineID,@TransactionDate,@TransactionType,@Quantity,@ActualCost,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_TRANSACTIONHISTORYARCHIVE = "UPDATE Production.TransactionHistoryArchive SET  [ProductID] = @ProductID, [ReferenceOrderID] = @ReferenceOrderID, [ReferenceOrderLineID] = @ReferenceOrderLineID, [TransactionDate] = @TransactionDate, [TransactionType] = @TransactionType, [Quantity] = @Quantity, [ActualCost] = @ActualCost, [ModifiedDate] = @ModifiedDate WHERE [TransactionID] = @TransactionID";
		
		private const string SQL_DELETE_TRANSACTIONHISTORYARCHIVE = "DELETE FROM Production.TransactionHistoryArchive WHERE  [TransactionID] = @TransactionID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int transactionid = default(int);
	
		protected int productid = default(int);
	
		protected int referenceorderid = default(int);
	
		protected int referenceorderlineid = default(int);
	
		protected System.DateTime transactiondate = default(System.DateTime);
	
		protected string transactiontype = default(string);
	
		protected int quantity = default(int);
	
		protected decimal actualcost = default(decimal);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
        #endregion

 		#region Properties	

        [Column( COL_TRANSACTIONID, PARAM_TRANSACTIONID, default(int))]
                              public virtual int TransactionID 
        {
            get { return this.transactionid; }
			set	{ 
                  if(this.transactionid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("TransactionID"));  
                        this.transactionid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("TransactionID"));
                    }   
                }
        }	
		
        [Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID 
        {
            get { return this.productid; }
			set	{ 
                  if(this.productid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductID"));  
                        this.productid = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductID"));
                    }   
                }
        }	
		
        [Column( COL_REFERENCEORDERID, PARAM_REFERENCEORDERID, default(int))]
                              public virtual int ReferenceOrderID 
        {
            get { return this.referenceorderid; }
			set	{ 
                  if(this.referenceorderid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ReferenceOrderID"));  
                        this.referenceorderid = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ReferenceOrderID"));
                    }   
                }
        }	
		
        [Column( COL_REFERENCEORDERLINEID, PARAM_REFERENCEORDERLINEID, default(int))]
                              public virtual int ReferenceOrderLineID 
        {
            get { return this.referenceorderlineid; }
			set	{ 
                  if(this.referenceorderlineid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ReferenceOrderLineID"));  
                        this.referenceorderlineid = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ReferenceOrderLineID"));
                    }   
                }
        }	
		
        [Column( COL_TRANSACTIONDATE, PARAM_TRANSACTIONDATE, typeof(System.DateTime))]
                              public virtual System.DateTime TransactionDate 
        {
            get { return this.transactiondate; }
			set	{ 
                  if(this.transactiondate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("TransactionDate"));  
                        this.transactiondate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("TransactionDate"));
                    }   
                }
        }	
		
        [Column( COL_TRANSACTIONTYPE, PARAM_TRANSACTIONTYPE )]
                              public virtual string TransactionType 
        {
            get { return this.transactiontype; }
			set	{ 
                  if(this.transactiontype != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("TransactionType"));  
                        this.transactiontype = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("TransactionType"));
                    }   
                }
        }	
		
        [Column( COL_QUANTITY, PARAM_QUANTITY, default(int))]
                              public virtual int Quantity 
        {
            get { return this.quantity; }
			set	{ 
                  if(this.quantity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Quantity"));  
                        this.quantity = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Quantity"));
                    }   
                }
        }	
		
        [Column( COL_ACTUALCOST, PARAM_ACTUALCOST, typeof(decimal))]
                              public virtual decimal ActualCost 
        {
            get { return this.actualcost; }
			set	{ 
                  if(this.actualcost != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ActualCost"));  
                        this.actualcost = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ActualCost"));
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
		
        
        #endregion        
        
        #region Methods     
		
        public TransactionHistoryArchive()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.transactionid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            TransactionHistoryArchive entity = obj as TransactionHistoryArchive;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.TransactionID == entity.TransactionID
                        && this.TransactionID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.transactionid = (int)reader[COL_TRANSACTIONID];
			this.productid = (int)reader[COL_PRODUCTID];
			this.referenceorderid = (int)reader[COL_REFERENCEORDERID];
			this.referenceorderlineid = (int)reader[COL_REFERENCEORDERLINEID];
			this.transactiondate = (System.DateTime)reader[COL_TRANSACTIONDATE];
			this.transactiontype = (string)reader[COL_TRANSACTIONTYPE];
			this.quantity = (int)reader[COL_QUANTITY];
			this.actualcost = (decimal)reader[COL_ACTUALCOST];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_TRANSACTIONHISTORYARCHIVE))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.TransactionID, PARAM_TRANSACTIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.ReferenceOrderID, PARAM_REFERENCEORDERID));
				command.Parameters.Add(dataContext.CreateParameter(this.ReferenceOrderLineID, PARAM_REFERENCEORDERLINEID));
				command.Parameters.Add(dataContext.CreateParameter(this.TransactionDate, PARAM_TRANSACTIONDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.TransactionType, PARAM_TRANSACTIONTYPE));
				command.Parameters.Add(dataContext.CreateParameter(this.Quantity, PARAM_QUANTITY));
				command.Parameters.Add(dataContext.CreateParameter(this.ActualCost, PARAM_ACTUALCOST));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_TRANSACTIONHISTORYARCHIVE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.TransactionID, PARAM_TRANSACTIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.ReferenceOrderID, PARAM_REFERENCEORDERID));
				command.Parameters.Add(dataContext.CreateParameter(this.ReferenceOrderLineID, PARAM_REFERENCEORDERLINEID));
				command.Parameters.Add(dataContext.CreateParameter(this.TransactionDate, PARAM_TRANSACTIONDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.TransactionType, PARAM_TRANSACTIONTYPE));
				command.Parameters.Add(dataContext.CreateParameter(this.Quantity, PARAM_QUANTITY));
				command.Parameters.Add(dataContext.CreateParameter(this.ActualCost, PARAM_ACTUALCOST));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_TRANSACTIONHISTORYARCHIVE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.TransactionID, PARAM_TRANSACTIONID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
