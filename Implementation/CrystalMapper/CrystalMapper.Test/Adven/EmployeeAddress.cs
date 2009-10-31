/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: EmployeeAddress
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
    public partial class EmployeeAddress : Entity< EmployeeAddress>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "HumanResources.EmployeeAddress";	
     
		public const string COL_EMPLOYEEID = "EmployeeID";
		public const string COL_ADDRESSID = "AddressID";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_EMPLOYEEID = "@EmployeeID";	
        public const string PARAM_ADDRESSID = "@AddressID";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_EMPLOYEEADDRESS = "INSERT INTO HumanResources.EmployeeAddress([EmployeeID],[AddressID],[rowguid],[ModifiedDate]) VALUES (@EmployeeID,@AddressID,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_EMPLOYEEADDRESS = "UPDATE HumanResources.EmployeeAddress SET [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [EmployeeID] = @EmployeeID AND [AddressID] = @AddressID";
		
		private const string SQL_DELETE_EMPLOYEEADDRESS = "DELETE FROM HumanResources.EmployeeAddress WHERE  [EmployeeID] = @EmployeeID AND [AddressID] = @AddressID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_EMPLOYEEID, PARAM_EMPLOYEEID, default(int))]
                              public virtual int EmployeeID  { get; set; }		
		[Column( COL_ADDRESSID, PARAM_ADDRESSID, default(int))]
                              public virtual int AddressID  { get; set; }		
		
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.EmployeeID = (int)reader[COL_EMPLOYEEID];
			this.AddressID = (int)reader[COL_ADDRESSID];
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_EMPLOYEEADDRESS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.EmployeeID, PARAM_EMPLOYEEID));
				command.Parameters.Add(dataContext.CreateParameter(this.AddressID, PARAM_ADDRESSID));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_EMPLOYEEADDRESS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.EmployeeID, PARAM_EMPLOYEEID));
				command.Parameters.Add(dataContext.CreateParameter(this.AddressID, PARAM_ADDRESSID));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_EMPLOYEEADDRESS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.EmployeeID, PARAM_EMPLOYEEID));				
				command.Parameters.Add(dataContext.CreateParameter(this.AddressID, PARAM_ADDRESSID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
