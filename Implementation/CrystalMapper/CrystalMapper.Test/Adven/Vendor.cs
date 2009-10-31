/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: Vendor
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
    public partial class Vendor : Entity< Vendor>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Purchasing.Vendor";	
     
		public const string COL_VENDORID = "VendorID";
		public const string COL_ACCOUNTNUMBER = "AccountNumber";
		public const string COL_NAME = "Name";
		public const string COL_CREDITRATING = "CreditRating";
		public const string COL_PREFERREDVENDORSTATUS = "PreferredVendorStatus";
		public const string COL_ACTIVEFLAG = "ActiveFlag";
		public const string COL_PURCHASINGWEBSERVICEURL = "PurchasingWebServiceURL";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_VENDORID = "@VendorID";	
        public const string PARAM_ACCOUNTNUMBER = "@AccountNumber";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_CREDITRATING = "@CreditRating";	
        public const string PARAM_PREFERREDVENDORSTATUS = "@PreferredVendorStatus";	
        public const string PARAM_ACTIVEFLAG = "@ActiveFlag";	
        public const string PARAM_PURCHASINGWEBSERVICEURL = "@PurchasingWebServiceURL";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_VENDOR = "INSERT INTO Purchasing.Vendor([AccountNumber],[Name],[CreditRating],[PreferredVendorStatus],[ActiveFlag],[PurchasingWebServiceURL],[ModifiedDate]) VALUES (@AccountNumber,@Name,@CreditRating,@PreferredVendorStatus,@ActiveFlag,@PurchasingWebServiceURL,@ModifiedDate);";
		
		private const string SQL_UPDATE_VENDOR = "UPDATE Purchasing.Vendor SET [AccountNumber] = @AccountNumber, [Name] = @Name, [CreditRating] = @CreditRating, [PreferredVendorStatus] = @PreferredVendorStatus, [ActiveFlag] = @ActiveFlag, [PurchasingWebServiceURL] = @PurchasingWebServiceURL, [ModifiedDate] = @ModifiedDate,  WHERE [VendorID] = @VendorID";
		
		private const string SQL_DELETE_VENDOR = "DELETE FROM Purchasing.Vendor WHERE  [VendorID] = @VendorID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_VENDORID, PARAM_VENDORID, default(int))]
                              public virtual int VendorID  { get; set; }		
		
        
	    [Column( COL_ACCOUNTNUMBER, PARAM_ACCOUNTNUMBER )]
                              public virtual string AccountNumber  { get; set; }	      
        
	    [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name  { get; set; }	      
        
	    [Column( COL_CREDITRATING, PARAM_CREDITRATING, default(byte))]
                              public virtual byte CreditRating  { get; set; }	      
        
	    [Column( COL_PREFERREDVENDORSTATUS, PARAM_PREFERREDVENDORSTATUS, default(bool))]
                              public virtual bool PreferredVendorStatus  { get; set; }	      
        
	    [Column( COL_ACTIVEFLAG, PARAM_ACTIVEFLAG, default(bool))]
                              public virtual bool ActiveFlag  { get; set; }	      
        
	    [Column( COL_PURCHASINGWEBSERVICEURL, PARAM_PURCHASINGWEBSERVICEURL )]
                              public virtual string PurchasingWebServiceURL  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< ProductVendor> ProductVendors
        {
            get {
                  foreach(ProductVendor productVendor in ProductVendorList())
                    yield return productVendor; 
                }
        }
        
        public IEnumerable< PurchaseOrderHeader> PurchaseOrderHeaders
        {
            get {
                  foreach(PurchaseOrderHeader purchaseOrderHeader in PurchaseOrderHeaderList())
                    yield return purchaseOrderHeader; 
                }
        }
        
        public IEnumerable< VendorAddress> VendorAddresses
        {
            get {
                  foreach(VendorAddress vendorAddress in VendorAddressList())
                    yield return vendorAddress; 
                }
        }
        
        public IEnumerable< VendorContact> VendorContacts
        {
            get {
                  foreach(VendorContact vendorContact in VendorContactList())
                    yield return vendorContact; 
                }
        }
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.VendorID = (int)reader[COL_VENDORID];
			this.AccountNumber = (string)reader[COL_ACCOUNTNUMBER];
			this.Name = (string)reader[COL_NAME];
			this.CreditRating = (byte)reader[COL_CREDITRATING];
			this.PreferredVendorStatus = (bool)reader[COL_PREFERREDVENDORSTATUS];
			this.ActiveFlag = (bool)reader[COL_ACTIVEFLAG];
			this.PurchasingWebServiceURL = DbConvert.ToString(reader[COL_PURCHASINGWEBSERVICEURL]);
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_VENDOR))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.AccountNumber, PARAM_ACCOUNTNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.CreditRating, PARAM_CREDITRATING));
				command.Parameters.Add(dataContext.CreateParameter(this.PreferredVendorStatus, PARAM_PREFERREDVENDORSTATUS));
				command.Parameters.Add(dataContext.CreateParameter(this.ActiveFlag, PARAM_ACTIVEFLAG));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.PurchasingWebServiceURL), PARAM_PURCHASINGWEBSERVICEURL));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.VendorID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_VENDOR))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.VendorID, PARAM_VENDORID));
				command.Parameters.Add(dataContext.CreateParameter(this.AccountNumber, PARAM_ACCOUNTNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.CreditRating, PARAM_CREDITRATING));
				command.Parameters.Add(dataContext.CreateParameter(this.PreferredVendorStatus, PARAM_PREFERREDVENDORSTATUS));
				command.Parameters.Add(dataContext.CreateParameter(this.ActiveFlag, PARAM_ACTIVEFLAG));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.PurchasingWebServiceURL), PARAM_PURCHASINGWEBSERVICEURL));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_VENDOR))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.VendorID, PARAM_VENDORID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public ProductVendor GetProductVendorsQuery()
        {
            return new ProductVendor {                
                                                                            VendorID = this.VendorID  
                                                                            };
        }
        
        public ProductVendor[] ProductVendorList()
        {
            return GetProductVendorsQuery().ToList();
        }  
        
        public PurchaseOrderHeader GetPurchaseOrderHeadersQuery()
        {
            return new PurchaseOrderHeader {                
                                                                            VendorID = this.VendorID  
                                                                            };
        }
        
        public PurchaseOrderHeader[] PurchaseOrderHeaderList()
        {
            return GetPurchaseOrderHeadersQuery().ToList();
        }  
        
        public VendorAddress GetVendorAddressesQuery()
        {
            return new VendorAddress {                
                                                                            VendorID = this.VendorID  
                                                                            };
        }
        
        public VendorAddress[] VendorAddressList()
        {
            return GetVendorAddressesQuery().ToList();
        }  
        
        public VendorContact GetVendorContactsQuery()
        {
            return new VendorContact {                
                                                                            VendorID = this.VendorID  
                                                                            };
        }
        
        public VendorContact[] VendorContactList()
        {
            return GetVendorContactsQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
