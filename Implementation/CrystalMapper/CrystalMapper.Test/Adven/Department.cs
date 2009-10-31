/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: Department
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
    public partial class Department : Entity< Department>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "HumanResources.Department";	
     
		public const string COL_DEPARTMENTID = "DepartmentID";
		public const string COL_NAME = "Name";
		public const string COL_GROUPNAME = "GroupName";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_DEPARTMENTID = "@DepartmentID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_GROUPNAME = "@GroupName";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_DEPARTMENT = "INSERT INTO HumanResources.Department([Name],[GroupName],[ModifiedDate]) VALUES (@Name,@GroupName,@ModifiedDate);";
		
		private const string SQL_UPDATE_DEPARTMENT = "UPDATE HumanResources.Department SET [Name] = @Name, [GroupName] = @GroupName, [ModifiedDate] = @ModifiedDate,  WHERE [DepartmentID] = @DepartmentID";
		
		private const string SQL_DELETE_DEPARTMENT = "DELETE FROM HumanResources.Department WHERE  [DepartmentID] = @DepartmentID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_DEPARTMENTID, PARAM_DEPARTMENTID, default(short))]
                              public virtual short DepartmentID  { get; set; }		
		
        
	    [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name  { get; set; }	      
        
	    [Column( COL_GROUPNAME, PARAM_GROUPNAME )]
                              public virtual string GroupName  { get; set; }	      
        
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
			this.DepartmentID = (short)reader[COL_DEPARTMENTID];
			this.Name = (string)reader[COL_NAME];
			this.GroupName = (string)reader[COL_GROUPNAME];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_DEPARTMENT))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.GroupName, PARAM_GROUPNAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.DepartmentID = Convert.ToInt16(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_DEPARTMENT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.DepartmentID, PARAM_DEPARTMENTID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.GroupName, PARAM_GROUPNAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_DEPARTMENT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.DepartmentID, PARAM_DEPARTMENTID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public EmployeeDepartmentHistory GetEmployeeDepartmentHistoriesQuery()
        {
            return new EmployeeDepartmentHistory {                
                                                                            DepartmentID = this.DepartmentID  
                                                                            };
        }
        
        public EmployeeDepartmentHistory[] EmployeeDepartmentHistoryList()
        {
            return GetEmployeeDepartmentHistoriesQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
