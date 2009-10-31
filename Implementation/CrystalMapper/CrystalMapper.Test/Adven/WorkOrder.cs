/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: WorkOrder
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
    public partial class WorkOrder : Entity< WorkOrder>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.WorkOrder";	
     
		public const string COL_WORKORDERID = "WorkOrderID";
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_ORDERQTY = "OrderQty";
		public const string COL_STOCKEDQTY = "StockedQty";
		public const string COL_SCRAPPEDQTY = "ScrappedQty";
		public const string COL_STARTDATE = "StartDate";
		public const string COL_ENDDATE = "EndDate";
		public const string COL_DUEDATE = "DueDate";
		public const string COL_SCRAPREASONID = "ScrapReasonID";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_WORKORDERID = "@WorkOrderID";	
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_ORDERQTY = "@OrderQty";	
        public const string PARAM_STOCKEDQTY = "@StockedQty";	
        public const string PARAM_SCRAPPEDQTY = "@ScrappedQty";	
        public const string PARAM_STARTDATE = "@StartDate";	
        public const string PARAM_ENDDATE = "@EndDate";	
        public const string PARAM_DUEDATE = "@DueDate";	
        public const string PARAM_SCRAPREASONID = "@ScrapReasonID";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_WORKORDER = "INSERT INTO Production.WorkOrder([ProductID],[OrderQty],[StockedQty],[ScrappedQty],[StartDate],[EndDate],[DueDate],[ScrapReasonID],[ModifiedDate]) VALUES (@ProductID,@OrderQty,@StockedQty,@ScrappedQty,@StartDate,@EndDate,@DueDate,@ScrapReasonID,@ModifiedDate);";
		
		private const string SQL_UPDATE_WORKORDER = "UPDATE Production.WorkOrder SET [ProductID] = @ProductID, [OrderQty] = @OrderQty, [StockedQty] = @StockedQty, [ScrappedQty] = @ScrappedQty, [StartDate] = @StartDate, [EndDate] = @EndDate, [DueDate] = @DueDate, [ScrapReasonID] = @ScrapReasonID, [ModifiedDate] = @ModifiedDate,  WHERE [WorkOrderID] = @WorkOrderID";
		
		private const string SQL_DELETE_WORKORDER = "DELETE FROM Production.WorkOrder WHERE  [WorkOrderID] = @WorkOrderID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_WORKORDERID, PARAM_WORKORDERID, default(int))]
                              public virtual int WorkOrderID  { get; set; }		
		
        
	    [Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID  { get; set; }	      
        
	    [Column( COL_ORDERQTY, PARAM_ORDERQTY, default(int))]
                              public virtual int OrderQty  { get; set; }	      
        
	    [Column( COL_STOCKEDQTY, PARAM_STOCKEDQTY, default(int))]
                              public virtual int StockedQty  { get; set; }	      
        
	    [Column( COL_SCRAPPEDQTY, PARAM_SCRAPPEDQTY, default(short))]
                              public virtual short ScrappedQty  { get; set; }	      
        
	    [Column( COL_STARTDATE, PARAM_STARTDATE, typeof(System.DateTime))]
                              public virtual System.DateTime StartDate  { get; set; }	      
        
	    [Column( COL_ENDDATE, PARAM_ENDDATE )]
                              public virtual System.DateTime? EndDate  { get; set; }	      
        
	    [Column( COL_DUEDATE, PARAM_DUEDATE, typeof(System.DateTime))]
                              public virtual System.DateTime DueDate  { get; set; }	      
        
	    [Column( COL_SCRAPREASONID, PARAM_SCRAPREASONID )]
                              public virtual short? ScrapReasonID  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< WorkOrderRouting> WorkOrderRoutings
        {
            get {
                  foreach(WorkOrderRouting workOrderRouting in WorkOrderRoutingList())
                    yield return workOrderRouting; 
                }
        }
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.WorkOrderID = (int)reader[COL_WORKORDERID];
			this.ProductID = (int)reader[COL_PRODUCTID];
			this.OrderQty = (int)reader[COL_ORDERQTY];
			this.StockedQty = (int)reader[COL_STOCKEDQTY];
			this.ScrappedQty = (short)reader[COL_SCRAPPEDQTY];
			this.StartDate = (System.DateTime)reader[COL_STARTDATE];
			this.EndDate = DbConvert.ToNullable< System.DateTime >(reader[COL_ENDDATE]);
			this.DueDate = (System.DateTime)reader[COL_DUEDATE];
			this.ScrapReasonID = DbConvert.ToNullable< short >(reader[COL_SCRAPREASONID]);
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_WORKORDER))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.OrderQty, PARAM_ORDERQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.StockedQty, PARAM_STOCKEDQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.ScrappedQty, PARAM_SCRAPPEDQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EndDate), PARAM_ENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.DueDate, PARAM_DUEDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ScrapReasonID), PARAM_SCRAPREASONID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.WorkOrderID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_WORKORDER))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.WorkOrderID, PARAM_WORKORDERID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.OrderQty, PARAM_ORDERQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.StockedQty, PARAM_STOCKEDQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.ScrappedQty, PARAM_SCRAPPEDQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EndDate), PARAM_ENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.DueDate, PARAM_DUEDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ScrapReasonID), PARAM_SCRAPREASONID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_WORKORDER))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.WorkOrderID, PARAM_WORKORDERID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public WorkOrderRouting GetWorkOrderRoutingsQuery()
        {
            return new WorkOrderRouting {                
                                                                            WorkOrderID = this.WorkOrderID  
                                                                            };
        }
        
        public WorkOrderRouting[] WorkOrderRoutingList()
        {
            return GetWorkOrderRoutingsQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
