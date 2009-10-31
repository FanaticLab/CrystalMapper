/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: Shift
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
    public partial class Shift : Entity< Shift>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "HumanResources.Shift";	
     
		public const string COL_SHIFTID = "ShiftID";
		public const string COL_NAME = "Name";
		public const string COL_STARTTIME = "StartTime";
		public const string COL_ENDTIME = "EndTime";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SHIFTID = "@ShiftID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_STARTTIME = "@StartTime";	
        public const string PARAM_ENDTIME = "@EndTime";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SHIFT = "INSERT INTO HumanResources.Shift([Name],[StartTime],[EndTime],[ModifiedDate]) VALUES (@Name,@StartTime,@EndTime,@ModifiedDate);";
		
		private const string SQL_UPDATE_SHIFT = "UPDATE HumanResources.Shift SET [Name] = @Name, [StartTime] = @StartTime, [EndTime] = @EndTime, [ModifiedDate] = @ModifiedDate,  WHERE [ShiftID] = @ShiftID";
		
		private const string SQL_DELETE_SHIFT = "DELETE FROM HumanResources.Shift WHERE  [ShiftID] = @ShiftID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_SHIFTID, PARAM_SHIFTID, default(byte))]
                              public virtual byte ShiftID  { get; set; }		
		
        
	    [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name  { get; set; }	      
        
	    [Column( COL_STARTTIME, PARAM_STARTTIME, typeof(System.DateTime))]
                              public virtual System.DateTime StartTime  { get; set; }	      
        
	    [Column( COL_ENDTIME, PARAM_ENDTIME, typeof(System.DateTime))]
                              public virtual System.DateTime EndTime  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< EmployeeDepartmentHistory> EmployeeDepartmentHistories
        {
            get {
                  foreach(EmployeeDepartmentHistory employeeDepartmentHistory in EmployeeDepartmentHistoryList())
                    yield return employeeDepartmentHistory; 
                }
        }
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.ShiftID = (byte)reader[COL_SHIFTID];
			this.Name = (string)reader[COL_NAME];
			this.StartTime = (System.DateTime)reader[COL_STARTTIME];
			this.EndTime = (System.DateTime)reader[COL_ENDTIME];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SHIFT))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.StartTime, PARAM_STARTTIME));
				command.Parameters.Add(dataContext.CreateParameter(this.EndTime, PARAM_ENDTIME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.ShiftID = Convert.ToByte(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SHIFT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ShiftID, PARAM_SHIFTID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.StartTime, PARAM_STARTTIME));
				command.Parameters.Add(dataContext.CreateParameter(this.EndTime, PARAM_ENDTIME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SHIFT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ShiftID, PARAM_SHIFTID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public EmployeeDepartmentHistory GetEmployeeDepartmentHistoriesQuery()
        {
            return new EmployeeDepartmentHistory {                
                                                                            ShiftID = this.ShiftID  
                                                                            };
        }
        
        public EmployeeDepartmentHistory[] EmployeeDepartmentHistoryList()
        {
            return GetEmployeeDepartmentHistoriesQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
