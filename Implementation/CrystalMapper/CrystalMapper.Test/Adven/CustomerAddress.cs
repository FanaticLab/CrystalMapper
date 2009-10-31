/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: CustomerAddress
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
    public partial class CustomerAddress : Entity< CustomerAddress>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.CustomerAddress";	
     
		public const string COL_CUSTOMERID = "CustomerID";
		public const string COL_ADDRESSID = "AddressID";
		public const string COL_ADDRESSTYPEID = "AddressTypeID";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_CUSTOMERID = "@CustomerID";	
        public const string PARAM_ADDRESSID = "@AddressID";	
        public const string PARAM_ADDRESSTYPEID = "@AddressTypeID";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_CUSTOMERADDRESS = "INSERT INTO Sales.CustomerAddress([CustomerID],[AddressID],[AddressTypeID],[rowguid],[ModifiedDate]) VALUES (@CustomerID,@AddressID,@AddressTypeID,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_CUSTOMERADDRESS = "UPDATE Sales.CustomerAddress SET [AddressTypeID] = @AddressTypeID, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [CustomerID] = @CustomerID AND [AddressID] = @AddressID";
		
		private const string SQL_DELETE_CUSTOMERADDRESS = "DELETE FROM Sales.CustomerAddress WHERE  [CustomerID] = @CustomerID AND [AddressID] = @AddressID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_CUSTOMERID, PARAM_CUSTOMERID, default(int))]
                              public virtual int CustomerID  { get; set; }		
		[Column( COL_ADDRESSID, PARAM_ADDRESSID, default(int))]
                              public virtual int AddressID  { get; set; }		
		
        
	    [Column( COL_ADDRESSTYPEID, PARAM_ADDRESSTYPEID, default(int))]
                              public virtual int AddressTypeID  { get; set; }	      
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.CustomerID = (int)reader[COL_CUSTOMERID];
			this.AddressID = (int)reader[COL_ADDRESSID];
			this.AddressTypeID = (int)reader[COL_ADDRESSTYPEID];
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_CUSTOMERADDRESS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));
				command.Parameters.Add(dataContext.CreateParameter(this.AddressID, PARAM_ADDRESSID));
				command.Parameters.Add(dataContext.CreateParameter(this.AddressTypeID, PARAM_ADDRESSTYPEID));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_CUSTOMERADDRESS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));
				command.Parameters.Add(dataContext.CreateParameter(this.AddressID, PARAM_ADDRESSID));
				command.Parameters.Add(dataContext.CreateParameter(this.AddressTypeID, PARAM_ADDRESSTYPEID));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_CUSTOMERADDRESS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));				
				command.Parameters.Add(dataContext.CreateParameter(this.AddressID, PARAM_ADDRESSID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
