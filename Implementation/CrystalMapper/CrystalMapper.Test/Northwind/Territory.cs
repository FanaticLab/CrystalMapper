/*
 * Author: CrystalMapper
 * 
 * Date:  Sunday, November 01, 2009 2:37 AM
 * 
 * Class: Territory
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
    public partial class Territory : Entity< Territory>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Territories";	
     
		public const string COL_TERRITORYID = "TerritoryID";
		public const string COL_TERRITORYDESCRIPTION = "TerritoryDescription";
		public const string COL_REGIONID = "RegionID";
		
        public const string PARAM_TERRITORYID = ":TerritoryID";	
        public const string PARAM_TERRITORYDESCRIPTION = ":TerritoryDescription";	
        public const string PARAM_REGIONID = ":RegionID";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_TERRITORIES = "INSERT INTO Territories([TerritoryID],[TerritoryDescription],[RegionID]) VALUES (:TerritoryID,:TerritoryDescription,:RegionID);"  ;
		
		private const string SQL_UPDATE_TERRITORIES = "UPDATE Territories SET [TerritoryDescription] = :TerritoryDescription, [RegionID] = :RegionID,  WHERE [TerritoryID] = :TerritoryID";
		
		private const string SQL_DELETE_TERRITORIES = "DELETE FROM Territories WHERE  [TerritoryID] = :TerritoryID ";
		
        #endregion
        
        #region Properties	
		
		[Column( COL_TERRITORYID, PARAM_TERRITORYID, default(long))]
                              public virtual long TerritoryID  { get; set; }		
		
        
	    [Column( COL_TERRITORYDESCRIPTION, PARAM_TERRITORYDESCRIPTION )]
                              public virtual string TerritoryDescription  { get; set; }	      
        
	    [Column( COL_REGIONID, PARAM_REGIONID, default(long))]
                              public virtual long RegionID  { get; set; }	      
        
        public IEnumerable< EmployeesTerritory> EmployeesTerritories
        {
            get {
                  foreach(EmployeesTerritory employeesTerritory in EmployeesTerritoryList())
                    yield return employeesTerritory; 
                }
        }
        
        public IEnumerable< Employee> Employees
        {
            get {                         
                    foreach(Employee employee in EmployeeList())
                        yield return employee; 
                }         
        }    
        #endregion        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.TerritoryID = (long)reader[COL_TERRITORYID];
			this.TerritoryDescription = (string)reader[COL_TERRITORYDESCRIPTION];
			this.RegionID = (long)reader[COL_REGIONID];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_TERRITORIES))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryDescription, PARAM_TERRITORYDESCRIPTION));
				command.Parameters.Add(dataContext.CreateParameter(this.RegionID, PARAM_REGIONID));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_TERRITORIES))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryDescription, PARAM_TERRITORYDESCRIPTION));
				command.Parameters.Add(dataContext.CreateParameter(this.RegionID, PARAM_REGIONID));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_TERRITORIES))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public EmployeesTerritory GetEmployeesTerritoriesQuery()
        {
            return new EmployeesTerritory {                
                                                                            TerritoryID = this.TerritoryID  
                                                                            };
        }
        
        public EmployeesTerritory[] EmployeesTerritoryList()
        {
            return GetEmployeesTerritoriesQuery().ToList();
        }  
        
        
        
        public Employee[] EmployeeList()
        {
            string sqlQuery = @"SELECT Employees.*
                                FROM EmployeesTerritories
                                INNER JOIN Employees ON                                                                            
                                EmployeesTerritories.[EmployeeID] = Employees.[EmployeeID] AND
                                EmployeesTerritories.[TerritoryID] = :TerritoryID  
                                ";
                                
            Dictionary<string, object> parameterValues = new Dictionary<string, object>();
            parameterValues.Add(PARAM_TERRITORYID, this.TerritoryID);
            
            return Employee.ToList(sqlQuery, parameterValues);
            
        }    
        
        #endregion
    }
}
