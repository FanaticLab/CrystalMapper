/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: VendorAddress
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
    public partial class VendorAddress : Entity< VendorAddress>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Purchasing.VendorAddress";	
     
		public const string COL_VENDORID = "VendorID";
		public const string COL_ADDRESSID = "AddressID";
		public const string COL_ADDRESSTYPEID = "AddressTypeID";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_VENDORID = "@VendorID";	
        public const string PARAM_ADDRESSID = "@AddressID";	
        public const string PARAM_ADDRESSTYPEID = "@AddressTypeID";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_VENDORADDRESS = "INSERT INTO Purchasing.VendorAddress([VendorID],[AddressID],[AddressTypeID],[ModifiedDate]) VALUES (@VendorID,@AddressID,@AddressTypeID,@ModifiedDate);";
		
		private const string SQL_UPDATE_VENDORADDRESS = "UPDATE Purchasing.VendorAddress SET [AddressTypeID] = @AddressTypeID, [ModifiedDate] = @ModifiedDate,  WHERE [VendorID] = @VendorID AND [AddressID] = @AddressID";
		
		private const string SQL_DELETE_VENDORADDRESS = "DELETE FROM Purchasing.VendorAddress WHERE  [VendorID] = @VendorID AND [AddressID] = @AddressID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_VENDORID, PARAM_VENDORID, default(int))]
                              public virtual int VendorID  { get; set; }		
		[Column( COL_ADDRESSID, PARAM_ADDRESSID, default(int))]
                              public virtual int AddressID  { get; set; }		
		
        
	    [Column( COL_ADDRESSTYPEID, PARAM_ADDRESSTYPEID, default(int))]
                              public virtual int AddressTypeID  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.VendorID = (int)reader[COL_VENDORID];
			this.AddressID = (int)reader[COL_ADDRESSID];
			this.AddressTypeID = (int)reader[COL_ADDRESSTYPEID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_VENDORADDRESS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.VendorID, PARAM_VENDORID));
				command.Parameters.Add(dataContext.CreateParameter(this.AddressID, PARAM_ADDRESSID));
				command.Parameters.Add(dataContext.CreateParameter(this.AddressTypeID, PARAM_ADDRESSTYPEID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_VENDORADDRESS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.VendorID, PARAM_VENDORID));
				command.Parameters.Add(dataContext.CreateParameter(this.AddressID, PARAM_ADDRESSID));
				command.Parameters.Add(dataContext.CreateParameter(this.AddressTypeID, PARAM_ADDRESSTYPEID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_VENDORADDRESS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.VendorID, PARAM_VENDORID));				
				command.Parameters.Add(dataContext.CreateParameter(this.AddressID, PARAM_ADDRESSID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
