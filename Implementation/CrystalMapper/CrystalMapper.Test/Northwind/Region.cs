/*
 * Author: CrystalMapper
 * 
 * Date:  Sunday, November 01, 2009 2:37 AM
 * 
 * Class: Region
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
    public partial class Region : Entity< Region>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Regions";	
     
		public const string COL_REGIONID = "RegionID";
		public const string COL_REGIONDESCRIPTION = "RegionDescription";
		
        public const string PARAM_REGIONID = ":RegionID";	
        public const string PARAM_REGIONDESCRIPTION = ":RegionDescription";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_REGIONS = "INSERT INTO Regions([RegionID],[RegionDescription]) VALUES (:RegionID,:RegionDescription);"  ;
		
		private const string SQL_UPDATE_REGIONS = "UPDATE Regions SET [RegionDescription] = :RegionDescription,  WHERE [RegionID] = :RegionID";
		
		private const string SQL_DELETE_REGIONS = "DELETE FROM Regions WHERE  [RegionID] = :RegionID ";
		
        #endregion
        
        #region Properties	
		
		[Column( COL_REGIONID, PARAM_REGIONID, default(long))]
                              public virtual long RegionID  { get; set; }		
		
        
	    [Column( COL_REGIONDESCRIPTION, PARAM_REGIONDESCRIPTION )]
                              public virtual string RegionDescription  { get; set; }	      
        
        public IEnumerable< Territory> Territories
        {
            get {
                  foreach(Territory territory in TerritoryList())
                    yield return territory; 
                }
        }
        
        #endregion        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.RegionID = (long)reader[COL_REGIONID];
			this.RegionDescription = (string)reader[COL_REGIONDESCRIPTION];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_REGIONS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.RegionID, PARAM_REGIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.RegionDescription, PARAM_REGIONDESCRIPTION));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_REGIONS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.RegionID, PARAM_REGIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.RegionDescription, PARAM_REGIONDESCRIPTION));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_REGIONS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.RegionID, PARAM_REGIONID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public Territory GetTerritoriesQuery()
        {
            return new Territory {                
                                                                            RegionID = this.RegionID  
                                                                            };
        }
        
        public Territory[] TerritoryList()
        {
            return GetTerritoriesQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
