/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: EmployeeDepartmentHistory
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
    public partial class EmployeeDepartmentHistory : Entity< EmployeeDepartmentHistory>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "HumanResources.EmployeeDepartmentHistory";	
     
		public const string COL_EMPLOYEEID = "EmployeeID";
		public const string COL_DEPARTMENTID = "DepartmentID";
		public const string COL_SHIFTID = "ShiftID";
		public const string COL_STARTDATE = "StartDate";
		public const string COL_ENDDATE = "EndDate";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_EMPLOYEEID = "@EmployeeID";	
        public const string PARAM_DEPARTMENTID = "@DepartmentID";	
        public const string PARAM_SHIFTID = "@ShiftID";	
        public const string PARAM_STARTDATE = "@StartDate";	
        public const string PARAM_ENDDATE = "@EndDate";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_EMPLOYEEDEPARTMENTHISTORY = "INSERT INTO HumanResources.EmployeeDepartmentHistory([EmployeeID],[DepartmentID],[ShiftID],[StartDate],[EndDate],[ModifiedDate]) VALUES (@EmployeeID,@DepartmentID,@ShiftID,@StartDate,@EndDate,@ModifiedDate);";
		
		private const string SQL_UPDATE_EMPLOYEEDEPARTMENTHISTORY = "UPDATE HumanResources.EmployeeDepartmentHistory SET [EndDate] = @EndDate, [ModifiedDate] = @ModifiedDate,  WHERE [EmployeeID] = @EmployeeID AND [StartDate] = @StartDate AND [DepartmentID] = @DepartmentID AND [ShiftID] = @ShiftID";
		
		private const string SQL_DELETE_EMPLOYEEDEPARTMENTHISTORY = "DELETE FROM HumanResources.EmployeeDepartmentHistory WHERE  [EmployeeID] = @EmployeeID AND [StartDate] = @StartDate AND [DepartmentID] = @DepartmentID AND [ShiftID] = @ShiftID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_EMPLOYEEID, PARAM_EMPLOYEEID, default(int))]
                              public virtual int EmployeeID  { get; set; }		
		[Column( COL_STARTDATE, PARAM_STARTDATE, typeof(System.DateTime))]
                              public virtual System.DateTime StartDate  { get; set; }		
		[Column( COL_DEPARTMENTID, PARAM_DEPARTMENTID, default(short))]
                              public virtual short DepartmentID  { get; set; }		
		[Column( COL_SHIFTID, PARAM_SHIFTID, default(byte))]
                              public virtual byte ShiftID  { get; set; }		
		
        
	    [Column( COL_ENDDATE, PARAM_ENDDATE )]
                              public virtual System.DateTime? EndDate  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.EmployeeID = (int)reader[COL_EMPLOYEEID];
			this.DepartmentID = (short)reader[COL_DEPARTMENTID];
			this.ShiftID = (byte)reader[COL_SHIFTID];
			this.StartDate = (System.DateTime)reader[COL_STARTDATE];
			this.EndDate = DbConvert.ToNullable< System.DateTime >(reader[COL_ENDDATE]);
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_EMPLOYEEDEPARTMENTHISTORY))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.EmployeeID, PARAM_EMPLOYEEID));
				command.Parameters.Add(dataContext.CreateParameter(this.DepartmentID, PARAM_DEPARTMENTID));
				command.Parameters.Add(dataContext.CreateParameter(this.ShiftID, PARAM_SHIFTID));
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EndDate), PARAM_ENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_EMPLOYEEDEPARTMENTHISTORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.EmployeeID, PARAM_EMPLOYEEID));
				command.Parameters.Add(dataContext.CreateParameter(this.DepartmentID, PARAM_DEPARTMENTID));
				command.Parameters.Add(dataContext.CreateParameter(this.ShiftID, PARAM_SHIFTID));
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EndDate), PARAM_ENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_EMPLOYEEDEPARTMENTHISTORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.EmployeeID, PARAM_EMPLOYEEID));				
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));				
				command.Parameters.Add(dataContext.CreateParameter(this.DepartmentID, PARAM_DEPARTMENTID));				
				command.Parameters.Add(dataContext.CreateParameter(this.ShiftID, PARAM_SHIFTID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
