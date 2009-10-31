/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: SalesPersonQuotaHistory
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
    public partial class SalesPersonQuotaHistory : Entity< SalesPersonQuotaHistory>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.SalesPersonQuotaHistory";	
     
		public const string COL_SALESPERSONID = "SalesPersonID";
		public const string COL_QUOTADATE = "QuotaDate";
		public const string COL_SALESQUOTA = "SalesQuota";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SALESPERSONID = "@SalesPersonID";	
        public const string PARAM_QUOTADATE = "@QuotaDate";	
        public const string PARAM_SALESQUOTA = "@SalesQuota";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SALESPERSONQUOTAHISTORY = "INSERT INTO Sales.SalesPersonQuotaHistory([SalesPersonID],[QuotaDate],[SalesQuota],[rowguid],[ModifiedDate]) VALUES (@SalesPersonID,@QuotaDate,@SalesQuota,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_SALESPERSONQUOTAHISTORY = "UPDATE Sales.SalesPersonQuotaHistory SET [SalesQuota] = @SalesQuota, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [SalesPersonID] = @SalesPersonID AND [QuotaDate] = @QuotaDate";
		
		private const string SQL_DELETE_SALESPERSONQUOTAHISTORY = "DELETE FROM Sales.SalesPersonQuotaHistory WHERE  [SalesPersonID] = @SalesPersonID AND [QuotaDate] = @QuotaDate ";
		
        #endregion
        #region Properties	
		
		[Column( COL_SALESPERSONID, PARAM_SALESPERSONID, default(int))]
                              public virtual int SalesPersonID  { get; set; }		
		[Column( COL_QUOTADATE, PARAM_QUOTADATE, typeof(System.DateTime))]
                              public virtual System.DateTime QuotaDate  { get; set; }		
		
        
	    [Column( COL_SALESQUOTA, PARAM_SALESQUOTA, typeof(decimal))]
                              public virtual decimal SalesQuota  { get; set; }	      
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.SalesPersonID = (int)reader[COL_SALESPERSONID];
			this.QuotaDate = (System.DateTime)reader[COL_QUOTADATE];
			this.SalesQuota = (decimal)reader[COL_SALESQUOTA];
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SALESPERSONQUOTAHISTORY))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.SalesPersonID, PARAM_SALESPERSONID));
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
				command.Parameters.Add(dataContext.CreateParameter(this.SalesPersonID, PARAM_SALESPERSONID));
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
				command.Parameters.Add(dataContext.CreateParameter(this.SalesPersonID, PARAM_SALESPERSONID));				
				command.Parameters.Add(dataContext.CreateParameter(this.QuotaDate, PARAM_QUOTADATE));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
