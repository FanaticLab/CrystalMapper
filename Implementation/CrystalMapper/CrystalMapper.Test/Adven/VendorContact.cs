/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: VendorContact
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
    public partial class VendorContact : Entity< VendorContact>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Purchasing.VendorContact";	
     
		public const string COL_VENDORID = "VendorID";
		public const string COL_CONTACTID = "ContactID";
		public const string COL_CONTACTTYPEID = "ContactTypeID";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_VENDORID = "@VendorID";	
        public const string PARAM_CONTACTID = "@ContactID";	
        public const string PARAM_CONTACTTYPEID = "@ContactTypeID";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_VENDORCONTACT = "INSERT INTO Purchasing.VendorContact([VendorID],[ContactID],[ContactTypeID],[ModifiedDate]) VALUES (@VendorID,@ContactID,@ContactTypeID,@ModifiedDate);";
		
		private const string SQL_UPDATE_VENDORCONTACT = "UPDATE Purchasing.VendorContact SET [ContactTypeID] = @ContactTypeID, [ModifiedDate] = @ModifiedDate,  WHERE [VendorID] = @VendorID AND [ContactID] = @ContactID";
		
		private const string SQL_DELETE_VENDORCONTACT = "DELETE FROM Purchasing.VendorContact WHERE  [VendorID] = @VendorID AND [ContactID] = @ContactID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_VENDORID, PARAM_VENDORID, default(int))]
                              public virtual int VendorID  { get; set; }		
		[Column( COL_CONTACTID, PARAM_CONTACTID, default(int))]
                              public virtual int ContactID  { get; set; }		
		
        
	    [Column( COL_CONTACTTYPEID, PARAM_CONTACTTYPEID, default(int))]
                              public virtual int ContactTypeID  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.VendorID = (int)reader[COL_VENDORID];
			this.ContactID = (int)reader[COL_CONTACTID];
			this.ContactTypeID = (int)reader[COL_CONTACTTYPEID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_VENDORCONTACT))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.VendorID, PARAM_VENDORID));
				command.Parameters.Add(dataContext.CreateParameter(this.ContactID, PARAM_CONTACTID));
				command.Parameters.Add(dataContext.CreateParameter(this.ContactTypeID, PARAM_CONTACTTYPEID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_VENDORCONTACT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.VendorID, PARAM_VENDORID));
				command.Parameters.Add(dataContext.CreateParameter(this.ContactID, PARAM_CONTACTID));
				command.Parameters.Add(dataContext.CreateParameter(this.ContactTypeID, PARAM_CONTACTTYPEID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_VENDORCONTACT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.VendorID, PARAM_VENDORID));				
				command.Parameters.Add(dataContext.CreateParameter(this.ContactID, PARAM_CONTACTID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
