/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: ShipMethod
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
    public partial class ShipMethod : Entity< ShipMethod>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Purchasing.ShipMethod";	
     
		public const string COL_SHIPMETHODID = "ShipMethodID";
		public const string COL_NAME = "Name";
		public const string COL_SHIPBASE = "ShipBase";
		public const string COL_SHIPRATE = "ShipRate";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SHIPMETHODID = "@ShipMethodID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_SHIPBASE = "@ShipBase";	
        public const string PARAM_SHIPRATE = "@ShipRate";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SHIPMETHOD = "INSERT INTO Purchasing.ShipMethod([Name],[ShipBase],[ShipRate],[rowguid],[ModifiedDate]) VALUES (@Name,@ShipBase,@ShipRate,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_SHIPMETHOD = "UPDATE Purchasing.ShipMethod SET [Name] = @Name, [ShipBase] = @ShipBase, [ShipRate] = @ShipRate, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [ShipMethodID] = @ShipMethodID";
		
		private const string SQL_DELETE_SHIPMETHOD = "DELETE FROM Purchasing.ShipMethod WHERE  [ShipMethodID] = @ShipMethodID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_SHIPMETHODID, PARAM_SHIPMETHODID, default(int))]
                              public virtual int ShipMethodID  { get; set; }		
		
        
	    [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name  { get; set; }	      
        
	    [Column( COL_SHIPBASE, PARAM_SHIPBASE, typeof(decimal))]
                              public virtual decimal ShipBase  { get; set; }	      
        
	    [Column( COL_SHIPRATE, PARAM_SHIPRATE, typeof(decimal))]
                              public virtual decimal ShipRate  { get; set; }	      
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< PurchaseOrderHeader> PurchaseOrderHeaders
        {
            get {
                  foreach(PurchaseOrderHeader purchaseOrderHeader in PurchaseOrderHeaderList())
                    yield return purchaseOrderHeader; 
                }
        }
        
        public IEnumerable< SalesOrderHeader> SalesOrderHeaders
        {
            get {
                  foreach(SalesOrderHeader salesOrderHeader in SalesOrderHeaderList())
                    yield return salesOrderHeader; 
                }
        }
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.ShipMethodID = (int)reader[COL_SHIPMETHODID];
			this.Name = (string)reader[COL_NAME];
			this.ShipBase = (decimal)reader[COL_SHIPBASE];
			this.ShipRate = (decimal)reader[COL_SHIPRATE];
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SHIPMETHOD))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ShipBase, PARAM_SHIPBASE));
				command.Parameters.Add(dataContext.CreateParameter(this.ShipRate, PARAM_SHIPRATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.ShipMethodID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SHIPMETHOD))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ShipMethodID, PARAM_SHIPMETHODID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ShipBase, PARAM_SHIPBASE));
				command.Parameters.Add(dataContext.CreateParameter(this.ShipRate, PARAM_SHIPRATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SHIPMETHOD))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ShipMethodID, PARAM_SHIPMETHODID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public PurchaseOrderHeader GetPurchaseOrderHeadersQuery()
        {
            return new PurchaseOrderHeader {                
                                                                            ShipMethodID = this.ShipMethodID  
                                                                            };
        }
        
        public PurchaseOrderHeader[] PurchaseOrderHeaderList()
        {
            return GetPurchaseOrderHeadersQuery().ToList();
        }  
        
        public SalesOrderHeader GetSalesOrderHeadersQuery()
        {
            return new SalesOrderHeader {                
                                                                            ShipMethodID = this.ShipMethodID  
                                                                            };
        }
        
        public SalesOrderHeader[] SalesOrderHeaderList()
        {
            return GetSalesOrderHeadersQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
