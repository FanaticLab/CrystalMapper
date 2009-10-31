/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: TransactionHistory
 *    
 */

using System;
using System.Data.Common;
using System.Diagnostics;
using System.Collections.Generic;

using CoreSystem.Data;

using CrystalMapper;
using CrystalMapper.Data;
using CrystalMapper.Mapping;

namespace CrystalMapper.Generated.BusinessObjects
{
	[Table(TABLE_NAME)]
    public partial class TransactionHistory : Entity< TransactionHistory>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.TransactionHistory";	
     
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
		
		private const string SQL_INSERT_TRANSACTIONHISTORY = "INSERT INTO Production.TransactionHistory([ProductID],[ReferenceOrderID],[ReferenceOrderLineID],[TransactionDate],[TransactionType],[Quantity],[ActualCost],[ModifiedDate]) VALUES (@ProductID,@ReferenceOrderID,@ReferenceOrderLineID,@TransactionDate,@TransactionType,@Quantity,@ActualCost,@ModifiedDate);";
		
		private const string SQL_UPDATE_TRANSACTIONHISTORY = "UPDATE Production.TransactionHistory SET [ProductID] = @ProductID, [ReferenceOrderID] = @ReferenceOrderID, [ReferenceOrderLineID] = @ReferenceOrderLineID, [TransactionDate] = @TransactionDate, [TransactionType] = @TransactionType, [Quantity] = @Quantity, [ActualCost] = @ActualCost, [ModifiedDate] = @ModifiedDate,  WHERE [TransactionID] = @TransactionID";
		
		private const string SQL_DELETE_TRANSACTIONHISTORY = "DELETE FROM Production.TransactionHistory WHERE  [TransactionID] = @TransactionID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_TRANSACTIONID, PARAM_TRANSACTIONID, default(int))]
                              public virtual int TransactionID  { get; set; }		
		
        
	    [Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID  { get; set; }	      
        
	    [Column( COL_REFERENCEORDERID, PARAM_REFERENCEORDERID, default(int))]
                              public virtual int ReferenceOrderID  { get; set; }	      
        
	    [Column( COL_REFERENCEORDERLINEID, PARAM_REFERENCEORDERLINEID, default(int))]
                              public virtual int ReferenceOrderLineID  { get; set; }	      
        
	    [Column( COL_TRANSACTIONDATE, PARAM_TRANSACTIONDATE, typeof(System.DateTime))]
                              public virtual System.DateTime TransactionDate  { get; set; }	      
        
	    [Column( COL_TRANSACTIONTYPE, PARAM_TRANSACTIONTYPE )]
                              public virtual string TransactionType  { get; set; }	      
        
	    [Column( COL_QUANTITY, PARAM_QUANTITY, default(int))]
                              public virtual int Quantity  { get; set; }	      
        
	    [Column( COL_ACTUALCOST, PARAM_ACTUALCOST, typeof(decimal))]
                              public virtual decimal ActualCost  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.TransactionID = (int)reader[COL_TRANSACTIONID];
			this.ProductID = (int)reader[COL_PRODUCTID];
			this.ReferenceOrderID = (int)reader[COL_REFERENCEORDERID];
			this.ReferenceOrderLineID = (int)reader[COL_REFERENCEORDERLINEID];
			this.TransactionDate = (System.DateTime)reader[COL_TRANSACTIONDATE];
			this.TransactionType = (string)reader[COL_TRANSACTIONTYPE];
			this.Quantity = (int)reader[COL_QUANTITY];
			this.ActualCost = (decimal)reader[COL_ACTUALCOST];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_TRANSACTIONHISTORY))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.ReferenceOrderID, PARAM_REFERENCEORDERID));
				command.Parameters.Add(dataContext.CreateParameter(this.ReferenceOrderLineID, PARAM_REFERENCEORDERLINEID));
				command.Parameters.Add(dataContext.CreateParameter(this.TransactionDate, PARAM_TRANSACTIONDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.TransactionType, PARAM_TRANSACTIONTYPE));
				command.Parameters.Add(dataContext.CreateParameter(this.Quantity, PARAM_QUANTITY));
				command.Parameters.Add(dataContext.CreateParameter(this.ActualCost, PARAM_ACTUALCOST));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.TransactionID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_TRANSACTIONHISTORY))
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
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_TRANSACTIONHISTORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.TransactionID, PARAM_TRANSACTIONID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
