/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:51 PM
 * 
 * Class: SalesTerritoryHistory
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
    public partial class SalesTerritoryHistory : Entity< SalesTerritoryHistory>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.SalesTerritoryHistory";	
     
		public const string COL_SALESPERSONID = "SalesPersonID";
		public const string COL_TERRITORYID = "TerritoryID";
		public const string COL_STARTDATE = "StartDate";
		public const string COL_ENDDATE = "EndDate";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SALESPERSONID = "@SalesPersonID";	
        public const string PARAM_TERRITORYID = "@TerritoryID";	
        public const string PARAM_STARTDATE = "@StartDate";	
        public const string PARAM_ENDDATE = "@EndDate";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SALESTERRITORYHISTORY = "INSERT INTO Sales.SalesTerritoryHistory([SalesPersonID],[TerritoryID],[StartDate],[EndDate],[rowguid],[ModifiedDate]) VALUES (@SalesPersonID,@TerritoryID,@StartDate,@EndDate,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_SALESTERRITORYHISTORY = "UPDATE Sales.SalesTerritoryHistory SET [EndDate] = @EndDate, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [SalesPersonID] = @SalesPersonID AND [StartDate] = @StartDate AND [TerritoryID] = @TerritoryID";
		
		private const string SQL_DELETE_SALESTERRITORYHISTORY = "DELETE FROM Sales.SalesTerritoryHistory WHERE  [SalesPersonID] = @SalesPersonID AND [StartDate] = @StartDate AND [TerritoryID] = @TerritoryID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_SALESPERSONID, PARAM_SALESPERSONID, default(int))]
                              public virtual int SalesPersonID  { get; set; }		
		[Column( COL_STARTDATE, PARAM_STARTDATE, typeof(System.DateTime))]
                              public virtual System.DateTime StartDate  { get; set; }		
		[Column( COL_TERRITORYID, PARAM_TERRITORYID, default(int))]
                              public virtual int TerritoryID  { get; set; }		
		
        
	    [Column( COL_ENDDATE, PARAM_ENDDATE )]
                              public virtual System.DateTime? EndDate  { get; set; }	      
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.SalesPersonID = (int)reader[COL_SALESPERSONID];
			this.TerritoryID = (int)reader[COL_TERRITORYID];
			this.StartDate = (System.DateTime)reader[COL_STARTDATE];
			this.EndDate = DbConvert.ToNullable< System.DateTime >(reader[COL_ENDDATE]);
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SALESTERRITORYHISTORY))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.SalesPersonID, PARAM_SALESPERSONID));
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EndDate), PARAM_ENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SALESTERRITORYHISTORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SalesPersonID, PARAM_SALESPERSONID));
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EndDate), PARAM_ENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SALESTERRITORYHISTORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SalesPersonID, PARAM_SALESPERSONID));				
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));				
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
