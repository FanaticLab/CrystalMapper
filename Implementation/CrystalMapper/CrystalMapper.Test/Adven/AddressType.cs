/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: AddressType
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
    public partial class AddressType : Entity< AddressType>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Person.AddressType";	
     
		public const string COL_ADDRESSTYPEID = "AddressTypeID";
		public const string COL_NAME = "Name";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_ADDRESSTYPEID = "@AddressTypeID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_ADDRESSTYPE = "INSERT INTO Person.AddressType([Name],[rowguid],[ModifiedDate]) VALUES (@Name,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_ADDRESSTYPE = "UPDATE Person.AddressType SET [Name] = @Name, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [AddressTypeID] = @AddressTypeID";
		
		private const string SQL_DELETE_ADDRESSTYPE = "DELETE FROM Person.AddressType WHERE  [AddressTypeID] = @AddressTypeID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_ADDRESSTYPEID, PARAM_ADDRESSTYPEID, default(int))]
                              public virtual int AddressTypeID  { get; set; }		
		
        
	    [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name  { get; set; }	      
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< VendorAddress> VendorAddresses
        {
            get {
                  foreach(VendorAddress vendorAddress in VendorAddressList())
                    yield return vendorAddress; 
                }
        }
        
        public IEnumerable< CustomerAddress> CustomerAddresses
        {
            get {
                  foreach(CustomerAddress customerAddress in CustomerAddressList())
                    yield return customerAddress; 
                }
        }
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.AddressTypeID = (int)reader[COL_ADDRESSTYPEID];
			this.Name = (string)reader[COL_NAME];
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_ADDRESSTYPE))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.AddressTypeID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_ADDRESSTYPE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.AddressTypeID, PARAM_ADDRESSTYPEID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_ADDRESSTYPE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.AddressTypeID, PARAM_ADDRESSTYPEID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public VendorAddress GetVendorAddressesQuery()
        {
            return new VendorAddress {                
                                                                            AddressTypeID = this.AddressTypeID  
                                                                            };
        }
        
        public VendorAddress[] VendorAddressList()
        {
            return GetVendorAddressesQuery().ToList();
        }  
        
        public CustomerAddress GetCustomerAddressesQuery()
        {
            return new CustomerAddress {                
                                                                            AddressTypeID = this.AddressTypeID  
                                                                            };
        }
        
        public CustomerAddress[] CustomerAddressList()
        {
            return GetCustomerAddressesQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
