/*
 * Author: CrystalMapper
 * 
 * Date:  Sunday, November 01, 2009 2:37 AM
 * 
 * Class: EmployeesTerritory
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

namespace Northwind
{
	[Table(TABLE_NAME)]
    public partial class EmployeesTerritory : Entity< EmployeesTerritory>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "EmployeesTerritories";	
     
		public const string COL_EMPLOYEEID = "EmployeeID";
		public const string COL_TERRITORYID = "TerritoryID";
		
        public const string PARAM_EMPLOYEEID = ":EmployeeID";	
        public const string PARAM_TERRITORYID = ":TerritoryID";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_EMPLOYEESTERRITORIES = "INSERT INTO EmployeesTerritories([EmployeeID],[TerritoryID]) VALUES (:EmployeeID,:TerritoryID);"  ;
		
		private const string SQL_UPDATE_EMPLOYEESTERRITORIES = "UPDATE EmployeesTerritories SET  WHERE [EmployeeID] = :EmployeeID AND [TerritoryID] = :TerritoryID";
		
		private const string SQL_DELETE_EMPLOYEESTERRITORIES = "DELETE FROM EmployeesTerritories WHERE  [EmployeeID] = :EmployeeID AND [TerritoryID] = :TerritoryID ";
		
        #endregion
        
        #region Properties	
		
		[Column( COL_EMPLOYEEID, PARAM_EMPLOYEEID, default(long))]
                              public virtual long EmployeeID  { get; set; }		
		[Column( COL_TERRITORYID, PARAM_TERRITORYID, default(long))]
                              public virtual long TerritoryID  { get; set; }		
		
        
        #endregion        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.EmployeeID = (long)reader[COL_EMPLOYEEID];
			this.TerritoryID = (long)reader[COL_TERRITORYID];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_EMPLOYEESTERRITORIES))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.EmployeeID, PARAM_EMPLOYEEID));
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_EMPLOYEESTERRITORIES))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.EmployeeID, PARAM_EMPLOYEEID));
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_EMPLOYEESTERRITORIES))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.EmployeeID, PARAM_EMPLOYEEID));				
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
