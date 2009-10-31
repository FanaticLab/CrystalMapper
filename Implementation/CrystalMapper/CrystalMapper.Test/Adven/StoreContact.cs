/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:51 PM
 * 
 * Class: StoreContact
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
    public partial class StoreContact : Entity< StoreContact>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.StoreContact";	
     
		public const string COL_CUSTOMERID = "CustomerID";
		public const string COL_CONTACTID = "ContactID";
		public const string COL_CONTACTTYPEID = "ContactTypeID";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_CUSTOMERID = "@CustomerID";	
        public const string PARAM_CONTACTID = "@ContactID";	
        public const string PARAM_CONTACTTYPEID = "@ContactTypeID";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_STORECONTACT = "INSERT INTO Sales.StoreContact([CustomerID],[ContactID],[ContactTypeID],[rowguid],[ModifiedDate]) VALUES (@CustomerID,@ContactID,@ContactTypeID,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_STORECONTACT = "UPDATE Sales.StoreContact SET [ContactTypeID] = @ContactTypeID, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [CustomerID] = @CustomerID AND [ContactID] = @ContactID";
		
		private const string SQL_DELETE_STORECONTACT = "DELETE FROM Sales.StoreContact WHERE  [CustomerID] = @CustomerID AND [ContactID] = @ContactID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_CUSTOMERID, PARAM_CUSTOMERID, default(int))]
                              public virtual int CustomerID  { get; set; }		
		[Column( COL_CONTACTID, PARAM_CONTACTID, default(int))]
                              public virtual int ContactID  { get; set; }		
		
        
	    [Column( COL_CONTACTTYPEID, PARAM_CONTACTTYPEID, default(int))]
                              public virtual int ContactTypeID  { get; set; }	      
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.CustomerID = (int)reader[COL_CUSTOMERID];
			this.ContactID = (int)reader[COL_CONTACTID];
			this.ContactTypeID = (int)reader[COL_CONTACTTYPEID];
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_STORECONTACT))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));
				command.Parameters.Add(dataContext.CreateParameter(this.ContactID, PARAM_CONTACTID));
				command.Parameters.Add(dataContext.CreateParameter(this.ContactTypeID, PARAM_CONTACTTYPEID));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_STORECONTACT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));
				command.Parameters.Add(dataContext.CreateParameter(this.ContactID, PARAM_CONTACTID));
				command.Parameters.Add(dataContext.CreateParameter(this.ContactTypeID, PARAM_CONTACTTYPEID));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_STORECONTACT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));				
				command.Parameters.Add(dataContext.CreateParameter(this.ContactID, PARAM_CONTACTID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
