/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: ProductInventory
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
    public partial class ProductInventory : Entity< ProductInventory>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.ProductInventory";	
     
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_LOCATIONID = "LocationID";
		public const string COL_SHELF = "Shelf";
		public const string COL_BIN = "Bin";
		public const string COL_QUANTITY = "Quantity";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_LOCATIONID = "@LocationID";	
        public const string PARAM_SHELF = "@Shelf";	
        public const string PARAM_BIN = "@Bin";	
        public const string PARAM_QUANTITY = "@Quantity";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PRODUCTINVENTORY = "INSERT INTO Production.ProductInventory([ProductID],[LocationID],[Shelf],[Bin],[Quantity],[rowguid],[ModifiedDate]) VALUES (@ProductID,@LocationID,@Shelf,@Bin,@Quantity,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_PRODUCTINVENTORY = "UPDATE Production.ProductInventory SET [Shelf] = @Shelf, [Bin] = @Bin, [Quantity] = @Quantity, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [ProductID] = @ProductID AND [LocationID] = @LocationID";
		
		private const string SQL_DELETE_PRODUCTINVENTORY = "DELETE FROM Production.ProductInventory WHERE  [ProductID] = @ProductID AND [LocationID] = @LocationID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID  { get; set; }		
		[Column( COL_LOCATIONID, PARAM_LOCATIONID, default(short))]
                              public virtual short LocationID  { get; set; }		
		
        
	    [Column( COL_SHELF, PARAM_SHELF )]
                              public virtual string Shelf  { get; set; }	      
        
	    [Column( COL_BIN, PARAM_BIN, default(byte))]
                              public virtual byte Bin  { get; set; }	      
        
	    [Column( COL_QUANTITY, PARAM_QUANTITY, default(short))]
                              public virtual short Quantity  { get; set; }	      
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.ProductID = (int)reader[COL_PRODUCTID];
			this.LocationID = (short)reader[COL_LOCATIONID];
			this.Shelf = (string)reader[COL_SHELF];
			this.Bin = (byte)reader[COL_BIN];
			this.Quantity = (short)reader[COL_QUANTITY];
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTINVENTORY))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.LocationID, PARAM_LOCATIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.Shelf, PARAM_SHELF));
				command.Parameters.Add(dataContext.CreateParameter(this.Bin, PARAM_BIN));
				command.Parameters.Add(dataContext.CreateParameter(this.Quantity, PARAM_QUANTITY));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCTINVENTORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.LocationID, PARAM_LOCATIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.Shelf, PARAM_SHELF));
				command.Parameters.Add(dataContext.CreateParameter(this.Bin, PARAM_BIN));
				command.Parameters.Add(dataContext.CreateParameter(this.Quantity, PARAM_QUANTITY));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCTINVENTORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));				
				command.Parameters.Add(dataContext.CreateParameter(this.LocationID, PARAM_LOCATIONID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
