/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: SalesOrderHeaderSalesReason
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
		
		private const string SQL_INSERT_SALESORDERHEADERSALESREASON = "INSERT INTO Sales.SalesOrderHeaderSalesReason([SalesOrderID],[SalesReasonID],[ModifiedDate]) VALUES (@SalesOrderID,@SalesReasonID,@ModifiedDate);";
		
		private const string SQL_UPDATE_SALESORDERHEADERSALESREASON = "UPDATE Sales.SalesOrderHeaderSalesReason SET [ModifiedDate] = @ModifiedDate,  WHERE [SalesOrderID] = @SalesOrderID AND [SalesReasonID] = @SalesReasonID";
		
		private const string SQL_DELETE_SALESORDERHEADERSALESREASON = "DELETE FROM Sales.SalesOrderHeaderSalesReason WHERE  [SalesOrderID] = @SalesOrderID AND [SalesReasonID] = @SalesReasonID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_SALESORDERID, PARAM_SALESORDERID, default(int))]
                              public virtual int SalesOrderID  { get; set; }		
		[Column( COL_SALESREASONID, PARAM_SALESREASONID, default(int))]
                              public virtual int SalesReasonID  { get; set; }		
		
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.SalesOrderID = (int)reader[COL_SALESORDERID];
			this.SalesReasonID = (int)reader[COL_SALESREASONID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
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
        
        #region Children
        
        
        
        
        #endregion
    }
}
