/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: ContactType
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
    public partial class ContactType : Entity< ContactType>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Person.ContactType";	
     
		public const string COL_CONTACTTYPEID = "ContactTypeID";
		public const string COL_NAME = "Name";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_CONTACTTYPEID = "@ContactTypeID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_CONTACTTYPE = "INSERT INTO Person.ContactType([Name],[ModifiedDate]) VALUES (@Name,@ModifiedDate);";
		
		private const string SQL_UPDATE_CONTACTTYPE = "UPDATE Person.ContactType SET [Name] = @Name, [ModifiedDate] = @ModifiedDate,  WHERE [ContactTypeID] = @ContactTypeID";
		
		private const string SQL_DELETE_CONTACTTYPE = "DELETE FROM Person.ContactType WHERE  [ContactTypeID] = @ContactTypeID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_CONTACTTYPEID, PARAM_CONTACTTYPEID, default(int))]
                              public virtual int ContactTypeID  { get; set; }		
		
        
	    [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< VendorContact> VendorContacts
        {
            get {
                  foreach(VendorContact vendorContact in VendorContactList())
                    yield return vendorContact; 
                }
        }
        
        public IEnumerable< StoreContact> StoreContacts
        {
            get {
                  foreach(StoreContact storeContact in StoreContactList())
                    yield return storeContact; 
                }
        }
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.ContactTypeID = (int)reader[COL_CONTACTTYPEID];
			this.Name = (string)reader[COL_NAME];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_CONTACTTYPE))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.ContactTypeID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_CONTACTTYPE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ContactTypeID, PARAM_CONTACTTYPEID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_CONTACTTYPE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ContactTypeID, PARAM_CONTACTTYPEID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public VendorContact GetVendorContactsQuery()
        {
            return new VendorContact {                
                                                                            ContactTypeID = this.ContactTypeID  
                                                                            };
        }
        
        public VendorContact[] VendorContactList()
        {
            return GetVendorContactsQuery().ToList();
        }  
        
        public StoreContact GetStoreContactsQuery()
        {
            return new StoreContact {                
                                                                            ContactTypeID = this.ContactTypeID  
                                                                            };
        }
        
        public StoreContact[] StoreContactList()
        {
            return GetStoreContactsQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
