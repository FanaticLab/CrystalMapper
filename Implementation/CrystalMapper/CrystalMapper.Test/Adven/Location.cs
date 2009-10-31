/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: Location
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
    public partial class Location : Entity< Location>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.Location";	
     
		public const string COL_LOCATIONID = "LocationID";
		public const string COL_NAME = "Name";
		public const string COL_COSTRATE = "CostRate";
		public const string COL_AVAILABILITY = "Availability";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_LOCATIONID = "@LocationID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_COSTRATE = "@CostRate";	
        public const string PARAM_AVAILABILITY = "@Availability";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_LOCATION = "INSERT INTO Production.Location([Name],[CostRate],[Availability],[ModifiedDate]) VALUES (@Name,@CostRate,@Availability,@ModifiedDate);";
		
		private const string SQL_UPDATE_LOCATION = "UPDATE Production.Location SET [Name] = @Name, [CostRate] = @CostRate, [Availability] = @Availability, [ModifiedDate] = @ModifiedDate,  WHERE [LocationID] = @LocationID";
		
		private const string SQL_DELETE_LOCATION = "DELETE FROM Production.Location WHERE  [LocationID] = @LocationID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_LOCATIONID, PARAM_LOCATIONID, default(short))]
                              public virtual short LocationID  { get; set; }		
		
        
	    [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name  { get; set; }	      
        
	    [Column( COL_COSTRATE, PARAM_COSTRATE, typeof(decimal))]
                              public virtual decimal CostRate  { get; set; }	      
        
	    [Column( COL_AVAILABILITY, PARAM_AVAILABILITY, typeof(decimal))]
                              public virtual decimal Availability  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< ProductInventory> ProductInventories
        {
            get {
                  foreach(ProductInventory productInventory in ProductInventoryList())
                    yield return productInventory; 
                }
        }
        
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
			this.LocationID = (short)reader[COL_LOCATIONID];
			this.Name = (string)reader[COL_NAME];
			this.CostRate = (decimal)reader[COL_COSTRATE];
			this.Availability = (decimal)reader[COL_AVAILABILITY];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_LOCATION))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.CostRate, PARAM_COSTRATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Availability, PARAM_AVAILABILITY));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.LocationID = Convert.ToInt16(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_LOCATION))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.LocationID, PARAM_LOCATIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.CostRate, PARAM_COSTRATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Availability, PARAM_AVAILABILITY));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_LOCATION))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.LocationID, PARAM_LOCATIONID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public ProductInventory GetProductInventoriesQuery()
        {
            return new ProductInventory {                
                                                                            LocationID = this.LocationID  
                                                                            };
        }
        
        public ProductInventory[] ProductInventoryList()
        {
            return GetProductInventoriesQuery().ToList();
        }  
        
        public WorkOrderRouting GetWorkOrderRoutingsQuery()
        {
            return new WorkOrderRouting {                
                                                                            LocationID = this.LocationID  
                                                                            };
        }
        
        public WorkOrderRouting[] WorkOrderRoutingList()
        {
            return GetWorkOrderRoutingsQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
