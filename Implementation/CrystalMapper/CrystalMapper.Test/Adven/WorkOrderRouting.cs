/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: WorkOrderRouting
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
		
		private const string SQL_INSERT_WORKORDERROUTING = "INSERT INTO Production.WorkOrderRouting([WorkOrderID],[ProductID],[OperationSequence],[LocationID],[ScheduledStartDate],[ScheduledEndDate],[ActualStartDate],[ActualEndDate],[ActualResourceHrs],[PlannedCost],[ActualCost],[ModifiedDate]) VALUES (@WorkOrderID,@ProductID,@OperationSequence,@LocationID,@ScheduledStartDate,@ScheduledEndDate,@ActualStartDate,@ActualEndDate,@ActualResourceHrs,@PlannedCost,@ActualCost,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_WORKORDERROUTING = "UPDATE Production.WorkOrderRouting SET  [LocationID] = @LocationID, [ScheduledStartDate] = @ScheduledStartDate, [ScheduledEndDate] = @ScheduledEndDate, [ActualStartDate] = @ActualStartDate, [ActualEndDate] = @ActualEndDate, [ActualResourceHrs] = @ActualResourceHrs, [PlannedCost] = @PlannedCost, [ActualCost] = @ActualCost, [ModifiedDate] = @ModifiedDate WHERE [WorkOrderID] = @WorkOrderID AND [ProductID] = @ProductID AND [OperationSequence] = @OperationSequence";
		
		private const string SQL_DELETE_WORKORDERROUTING = "DELETE FROM Production.WorkOrderRouting WHERE  [WorkOrderID] = @WorkOrderID AND [ProductID] = @ProductID AND [OperationSequence] = @OperationSequence ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int workorderid = default(int);
	
		protected int productid = default(int);
	
		protected short operationsequence = default(short);
	
		protected short locationid = default(short);
	
		protected System.DateTime scheduledstartdate = default(System.DateTime);
	
		protected System.DateTime scheduledenddate = default(System.DateTime);
	
		protected System.DateTime? actualstartdate = default(System.DateTime?);
	
		protected System.DateTime? actualenddate = default(System.DateTime?);
	
		protected decimal? actualresourcehr = default(decimal?);
	
		protected decimal plannedcost = default(decimal);
	
		protected decimal? actualcost = default(decimal?);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected Location locationEntity;
	
		protected WorkOrder workOrderEntity;
	
        #endregion

 		#region Properties	

        [Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID 
        {
            get { return this.productid; }
			set	{ 
                  if(this.productid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductID"));  
                        this.productid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductID"));
                    }   
                }
        }	
		
        [Column( COL_OPERATIONSEQUENCE, PARAM_OPERATIONSEQUENCE, default(short))]
                              public virtual short OperationSequence 
        {
            get { return this.operationsequence; }
			set	{ 
                  if(this.operationsequence != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("OperationSequence"));  
                        this.operationsequence = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("OperationSequence"));
                    }   
                }
        }	
		
        [Column( COL_SCHEDULEDSTARTDATE, PARAM_SCHEDULEDSTARTDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ScheduledStartDate 
        {
            get { return this.scheduledstartdate; }
			set	{ 
                  if(this.scheduledstartdate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ScheduledStartDate"));  
                        this.scheduledstartdate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ScheduledStartDate"));
                    }   
                }
        }	
		
        [Column( COL_SCHEDULEDENDDATE, PARAM_SCHEDULEDENDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ScheduledEndDate 
        {
            get { return this.scheduledenddate; }
			set	{ 
                  if(this.scheduledenddate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ScheduledEndDate"));  
                        this.scheduledenddate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ScheduledEndDate"));
                    }   
                }
        }	
		
        [Column( COL_ACTUALSTARTDATE, PARAM_ACTUALSTARTDATE )]
                              public virtual System.DateTime? ActualStartDate 
        {
            get { return this.actualstartdate; }
			set	{ 
                  if(this.actualstartdate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ActualStartDate"));  
                        this.actualstartdate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ActualStartDate"));
                    }   
                }
        }	
		
        [Column( COL_ACTUALENDDATE, PARAM_ACTUALENDDATE )]
                              public virtual System.DateTime? ActualEndDate 
        {
            get { return this.actualenddate; }
			set	{ 
                  if(this.actualenddate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ActualEndDate"));  
                        this.actualenddate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ActualEndDate"));
                    }   
                }
        }	
		
        [Column( COL_ACTUALRESOURCEHRS, PARAM_ACTUALRESOURCEHRS )]
                              public virtual decimal? ActualResourceHrs 
        {
            get { return this.actualresourcehr; }
			set	{ 
                  if(this.actualresourcehr != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ActualResourceHrs"));  
                        this.actualresourcehr = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ActualResourceHrs"));
                    }   
                }
        }	
		
        [Column( COL_PLANNEDCOST, PARAM_PLANNEDCOST, typeof(decimal))]
                              public virtual decimal PlannedCost 
        {
            get { return this.plannedcost; }
			set	{ 
                  if(this.plannedcost != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("PlannedCost"));  
                        this.plannedcost = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("PlannedCost"));
                    }   
                }
        }	
		
        [Column( COL_ACTUALCOST, PARAM_ACTUALCOST )]
                              public virtual decimal? ActualCost 
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
		
        [Column( COL_LOCATIONID, PARAM_LOCATIONID, default(short))]
                              public virtual short LocationID                
        {
            get
            {
                if(this.locationEntity == null)
                    return this.locationid ;
                
                return this.locationEntity.LocationID;            
            }
            set
            {
                if(this.locationid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("LocationID"));                    
                    this.locationid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("LocationID"));
                    
                    this.locationEntity = null;
                }                
            }          
        }	
        
        [Column( COL_WORKORDERID, PARAM_WORKORDERID, default(int))]
                              public virtual int WorkOrderID                
        {
            get
            {
                if(this.workOrderEntity == null)
                    return this.workorderid ;
                
                return this.workOrderEntity.WorkOrderID;            
            }
            set
            {
                if(this.workorderid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("WorkOrderID"));                    
                    this.workorderid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("WorkOrderID"));
                    
                    this.workOrderEntity = null;
                }                
            }          
        }	
        
        public Location LocationEntity
        {
            get { 
                    if(this.locationEntity == null
                       && this.locationid != default(short)) 
                    {
                        Location locationQuery = new Location {
                                                        LocationID = this.locationid  
                                                        };
                        
                        Location[]  locations = locationQuery.ToList();                        
                        if(locations.Length == 1)
                            this.locationEntity = locations[0];                        
                    }
                    
                    return this.locationEntity; 
                }
			set	{ 
                  if(this.locationEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("LocationEntity"));
                        if (this.locationEntity != null)
                            this.Parents.Remove(this.locationEntity);                            
                        
                        if((this.locationEntity = value) != null) 
                            this.Parents.Add(this.locationEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("LocationEntity"));
                        
                        this.locationid = this.LocationEntity.LocationID;
                    }   
                }
        }	
		
        public WorkOrder WorkOrderEntity
        {
            get { 
                    if(this.workOrderEntity == null
                       && this.workorderid != default(int)) 
                    {
                        WorkOrder workOrderQuery = new WorkOrder {
                                                        WorkOrderID = this.workorderid  
                                                        };
                        
                        WorkOrder[]  workOrders = workOrderQuery.ToList();                        
                        if(workOrders.Length == 1)
                            this.workOrderEntity = workOrders[0];                        
                    }
                    
                    return this.workOrderEntity; 
                }
			set	{ 
                  if(this.workOrderEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("WorkOrderEntity"));
                        if (this.workOrderEntity != null)
                            this.Parents.Remove(this.workOrderEntity);                            
                        
                        if((this.workOrderEntity = value) != null) 
                            this.Parents.Add(this.workOrderEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("WorkOrderEntity"));
                        
                        this.workorderid = this.WorkOrderEntity.WorkOrderID;
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
		
        public WorkOrderRouting()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.workorderid.GetHashCode();
                result = (11 * result) + this.productid.GetHashCode();
                result = (11 * result) + this.operationsequence.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            WorkOrderRouting entity = obj as WorkOrderRouting;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.WorkOrderID == entity.WorkOrderID
                        && this.ProductID == entity.ProductID
                        && this.OperationSequence == entity.OperationSequence
                        && this.WorkOrderID != default(int)
                        && this.ProductID != default(int)
                        && this.OperationSequence != default(short)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.workorderid = (int)reader[COL_WORKORDERID];
			this.productid = (int)reader[COL_PRODUCTID];
			this.operationsequence = (short)reader[COL_OPERATIONSEQUENCE];
			this.locationid = (short)reader[COL_LOCATIONID];
			this.scheduledstartdate = (System.DateTime)reader[COL_SCHEDULEDSTARTDATE];
			this.scheduledenddate = (System.DateTime)reader[COL_SCHEDULEDENDDATE];
			this.actualstartdate = DbConvert.ToNullable< System.DateTime >(reader[COL_ACTUALSTARTDATE]);
			this.actualenddate = DbConvert.ToNullable< System.DateTime >(reader[COL_ACTUALENDDATE]);
			this.actualresourcehr = DbConvert.ToNullable< decimal >(reader[COL_ACTUALRESOURCEHRS]);
			this.plannedcost = (decimal)reader[COL_PLANNEDCOST];
			this.actualcost = DbConvert.ToNullable< decimal >(reader[COL_ACTUALCOST]);
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
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
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
