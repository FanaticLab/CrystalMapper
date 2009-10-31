/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: WorkOrderRouting
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
    public partial class WorkOrderRouting : Entity< WorkOrderRouting>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.WorkOrderRouting";	
     
		public const string COL_WORKORDERID = "WorkOrderID";
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_OPERATIONSEQUENCE = "OperationSequence";
		public const string COL_LOCATIONID = "LocationID";
		public const string COL_SCHEDULEDSTARTDATE = "ScheduledStartDate";
		public const string COL_SCHEDULEDENDDATE = "ScheduledEndDate";
		public const string COL_ACTUALSTARTDATE = "ActualStartDate";
		public const string COL_ACTUALENDDATE = "ActualEndDate";
		public const string COL_ACTUALRESOURCEHRS = "ActualResourceHrs";
		public const string COL_PLANNEDCOST = "PlannedCost";
		public const string COL_ACTUALCOST = "ActualCost";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_WORKORDERID = "@WorkOrderID";	
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_OPERATIONSEQUENCE = "@OperationSequence";	
        public const string PARAM_LOCATIONID = "@LocationID";	
        public const string PARAM_SCHEDULEDSTARTDATE = "@ScheduledStartDate";	
        public const string PARAM_SCHEDULEDENDDATE = "@ScheduledEndDate";	
        public const string PARAM_ACTUALSTARTDATE = "@ActualStartDate";	
        public const string PARAM_ACTUALENDDATE = "@ActualEndDate";	
        public const string PARAM_ACTUALRESOURCEHRS = "@ActualResourceHrs";	
        public const string PARAM_PLANNEDCOST = "@PlannedCost";	
        public const string PARAM_ACTUALCOST = "@ActualCost";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_WORKORDERROUTING = "INSERT INTO Production.WorkOrderRouting([WorkOrderID],[ProductID],[OperationSequence],[LocationID],[ScheduledStartDate],[ScheduledEndDate],[ActualStartDate],[ActualEndDate],[ActualResourceHrs],[PlannedCost],[ActualCost],[ModifiedDate]) VALUES (@WorkOrderID,@ProductID,@OperationSequence,@LocationID,@ScheduledStartDate,@ScheduledEndDate,@ActualStartDate,@ActualEndDate,@ActualResourceHrs,@PlannedCost,@ActualCost,@ModifiedDate);";
		
		private const string SQL_UPDATE_WORKORDERROUTING = "UPDATE Production.WorkOrderRouting SET [LocationID] = @LocationID, [ScheduledStartDate] = @ScheduledStartDate, [ScheduledEndDate] = @ScheduledEndDate, [ActualStartDate] = @ActualStartDate, [ActualEndDate] = @ActualEndDate, [ActualResourceHrs] = @ActualResourceHrs, [PlannedCost] = @PlannedCost, [ActualCost] = @ActualCost, [ModifiedDate] = @ModifiedDate,  WHERE [WorkOrderID] = @WorkOrderID AND [ProductID] = @ProductID AND [OperationSequence] = @OperationSequence";
		
		private const string SQL_DELETE_WORKORDERROUTING = "DELETE FROM Production.WorkOrderRouting WHERE  [WorkOrderID] = @WorkOrderID AND [ProductID] = @ProductID AND [OperationSequence] = @OperationSequence ";
		
        #endregion
        #region Properties	
		
		[Column( COL_WORKORDERID, PARAM_WORKORDERID, default(int))]
                              public virtual int WorkOrderID  { get; set; }		
		[Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID  { get; set; }		
		[Column( COL_OPERATIONSEQUENCE, PARAM_OPERATIONSEQUENCE, default(short))]
                              public virtual short OperationSequence  { get; set; }		
		
        
	    [Column( COL_LOCATIONID, PARAM_LOCATIONID, default(short))]
                              public virtual short LocationID  { get; set; }	      
        
	    [Column( COL_SCHEDULEDSTARTDATE, PARAM_SCHEDULEDSTARTDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ScheduledStartDate  { get; set; }	      
        
	    [Column( COL_SCHEDULEDENDDATE, PARAM_SCHEDULEDENDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ScheduledEndDate  { get; set; }	      
        
	    [Column( COL_ACTUALSTARTDATE, PARAM_ACTUALSTARTDATE )]
                              public virtual System.DateTime? ActualStartDate  { get; set; }	      
        
	    [Column( COL_ACTUALENDDATE, PARAM_ACTUALENDDATE )]
                              public virtual System.DateTime? ActualEndDate  { get; set; }	      
        
	    [Column( COL_ACTUALRESOURCEHRS, PARAM_ACTUALRESOURCEHRS )]
                              public virtual decimal? ActualResourceHrs  { get; set; }	      
        
	    [Column( COL_PLANNEDCOST, PARAM_PLANNEDCOST, typeof(decimal))]
                              public virtual decimal PlannedCost  { get; set; }	      
        
	    [Column( COL_ACTUALCOST, PARAM_ACTUALCOST )]
                              public virtual decimal? ActualCost  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.WorkOrderID = (int)reader[COL_WORKORDERID];
			this.ProductID = (int)reader[COL_PRODUCTID];
			this.OperationSequence = (short)reader[COL_OPERATIONSEQUENCE];
			this.LocationID = (short)reader[COL_LOCATIONID];
			this.ScheduledStartDate = (System.DateTime)reader[COL_SCHEDULEDSTARTDATE];
			this.ScheduledEndDate = (System.DateTime)reader[COL_SCHEDULEDENDDATE];
			this.ActualStartDate = DbConvert.ToNullable< System.DateTime >(reader[COL_ACTUALSTARTDATE]);
			this.ActualEndDate = DbConvert.ToNullable< System.DateTime >(reader[COL_ACTUALENDDATE]);
			this.ActualResourceHrs = DbConvert.ToNullable< decimal >(reader[COL_ACTUALRESOURCEHRS]);
			this.PlannedCost = (decimal)reader[COL_PLANNEDCOST];
			this.ActualCost = DbConvert.ToNullable< decimal >(reader[COL_ACTUALCOST]);
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_WORKORDERROUTING))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.WorkOrderID, PARAM_WORKORDERID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.OperationSequence, PARAM_OPERATIONSEQUENCE));
				command.Parameters.Add(dataContext.CreateParameter(this.LocationID, PARAM_LOCATIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.ScheduledStartDate, PARAM_SCHEDULEDSTARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.ScheduledEndDate, PARAM_SCHEDULEDENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ActualStartDate), PARAM_ACTUALSTARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ActualEndDate), PARAM_ACTUALENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ActualResourceHrs), PARAM_ACTUALRESOURCEHRS));
				command.Parameters.Add(dataContext.CreateParameter(this.PlannedCost, PARAM_PLANNEDCOST));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ActualCost), PARAM_ACTUALCOST));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_WORKORDERROUTING))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.WorkOrderID, PARAM_WORKORDERID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.OperationSequence, PARAM_OPERATIONSEQUENCE));
				command.Parameters.Add(dataContext.CreateParameter(this.LocationID, PARAM_LOCATIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.ScheduledStartDate, PARAM_SCHEDULEDSTARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.ScheduledEndDate, PARAM_SCHEDULEDENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ActualStartDate), PARAM_ACTUALSTARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ActualEndDate), PARAM_ACTUALENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ActualResourceHrs), PARAM_ACTUALRESOURCEHRS));
				command.Parameters.Add(dataContext.CreateParameter(this.PlannedCost, PARAM_PLANNEDCOST));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ActualCost), PARAM_ACTUALCOST));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_WORKORDERROUTING))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.WorkOrderID, PARAM_WORKORDERID));				
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));				
				command.Parameters.Add(dataContext.CreateParameter(this.OperationSequence, PARAM_OPERATIONSEQUENCE));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
