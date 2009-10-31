/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: Contact
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
    public partial class Contact : Entity< Contact>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Person.Contact";	
     
		public const string COL_CONTACTID = "ContactID";
		public const string COL_NAMESTYLE = "NameStyle";
		public const string COL_TITLE = "Title";
		public const string COL_FIRSTNAME = "FirstName";
		public const string COL_MIDDLENAME = "MiddleName";
		public const string COL_LASTNAME = "LastName";
		public const string COL_SUFFIX = "Suffix";
		public const string COL_EMAILADDRESS = "EmailAddress";
		public const string COL_EMAILPROMOTION = "EmailPromotion";
		public const string COL_PHONE = "Phone";
		public const string COL_PASSWORDHASH = "PasswordHash";
		public const string COL_PASSWORDSALT = "PasswordSalt";
		public const string COL_ADDITIONALCONTACTINFO = "AdditionalContactInfo";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_CONTACTID = "@ContactID";	
        public const string PARAM_NAMESTYLE = "@NameStyle";	
        public const string PARAM_TITLE = "@Title";	
        public const string PARAM_FIRSTNAME = "@FirstName";	
        public const string PARAM_MIDDLENAME = "@MiddleName";	
        public const string PARAM_LASTNAME = "@LastName";	
        public const string PARAM_SUFFIX = "@Suffix";	
        public const string PARAM_EMAILADDRESS = "@EmailAddress";	
        public const string PARAM_EMAILPROMOTION = "@EmailPromotion";	
        public const string PARAM_PHONE = "@Phone";	
        public const string PARAM_PASSWORDHASH = "@PasswordHash";	
        public const string PARAM_PASSWORDSALT = "@PasswordSalt";	
        public const string PARAM_ADDITIONALCONTACTINFO = "@AdditionalContactInfo";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_CONTACT = "INSERT INTO Person.Contact([NameStyle],[Title],[FirstName],[MiddleName],[LastName],[Suffix],[EmailAddress],[EmailPromotion],[Phone],[PasswordHash],[PasswordSalt],[AdditionalContactInfo],[rowguid],[ModifiedDate]) VALUES (@NameStyle,@Title,@FirstName,@MiddleName,@LastName,@Suffix,@EmailAddress,@EmailPromotion,@Phone,@PasswordHash,@PasswordSalt,@AdditionalContactInfo,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_CONTACT = "UPDATE Person.Contact SET [NameStyle] = @NameStyle, [Title] = @Title, [FirstName] = @FirstName, [MiddleName] = @MiddleName, [LastName] = @LastName, [Suffix] = @Suffix, [EmailAddress] = @EmailAddress, [EmailPromotion] = @EmailPromotion, [Phone] = @Phone, [PasswordHash] = @PasswordHash, [PasswordSalt] = @PasswordSalt, [AdditionalContactInfo] = @AdditionalContactInfo, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [ContactID] = @ContactID";
		
		private const string SQL_DELETE_CONTACT = "DELETE FROM Person.Contact WHERE  [ContactID] = @ContactID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_CONTACTID, PARAM_CONTACTID, default(int))]
                              public virtual int ContactID  { get; set; }		
		
        
	    [Column( COL_NAMESTYLE, PARAM_NAMESTYLE, default(bool))]
                              public virtual bool NameStyle  { get; set; }	      
        
	    [Column( COL_TITLE, PARAM_TITLE )]
                              public virtual string Title  { get; set; }	      
        
	    [Column( COL_FIRSTNAME, PARAM_FIRSTNAME )]
                              public virtual string FirstName  { get; set; }	      
        
	    [Column( COL_MIDDLENAME, PARAM_MIDDLENAME )]
                              public virtual string MiddleName  { get; set; }	      
        
	    [Column( COL_LASTNAME, PARAM_LASTNAME )]
                              public virtual string LastName  { get; set; }	      
        
	    [Column( COL_SUFFIX, PARAM_SUFFIX )]
                              public virtual string Suffix  { get; set; }	      
        
	    [Column( COL_EMAILADDRESS, PARAM_EMAILADDRESS )]
                              public virtual string EmailAddress  { get; set; }	      
        
	    [Column( COL_EMAILPROMOTION, PARAM_EMAILPROMOTION, default(int))]
                              public virtual int EmailPromotion  { get; set; }	      
        
	    [Column( COL_PHONE, PARAM_PHONE )]
                              public virtual string Phone  { get; set; }	      
        
	    [Column( COL_PASSWORDHASH, PARAM_PASSWORDHASH )]
                              public virtual string PasswordHash  { get; set; }	      
        
	    [Column( COL_PASSWORDSALT, PARAM_PASSWORDSALT )]
                              public virtual string PasswordSalt  { get; set; }	      
        
	    [Column( COL_ADDITIONALCONTACTINFO, PARAM_ADDITIONALCONTACTINFO )]
                              public virtual System.Xml.XmlDocument AdditionalContactInfo  { get; set; }	      
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< Employee> Employees
        {
            get {
                  foreach(Employee employee in EmployeeList())
                    yield return employee; 
                }
        }
        
        public IEnumerable< VendorContact> VendorContacts
        {
            get {
                  foreach(VendorContact vendorContact in VendorContactList())
                    yield return vendorContact; 
                }
        }
        
        public IEnumerable< ContactCreditCard> ContactCreditCards
        {
            get {
                  foreach(ContactCreditCard contactCreditCard in ContactCreditCardList())
                    yield return contactCreditCard; 
                }
        }
        
        public IEnumerable< Individual> Individuals
        {
            get {
                  foreach(Individual individual in IndividualList())
                    yield return individual; 
                }
        }
        
        public IEnumerable< SalesOrderHeader> SalesOrderHeaders
        {
            get {
                  foreach(SalesOrderHeader salesOrderHeader in SalesOrderHeaderList())
                    yield return salesOrderHeader; 
                }
        }
        
        public IEnumerable< StoreContact> StoreContacts
        {
            get {
                  foreach(StoreContact storeContact in StoreContactList())
                    yield return storeContact; 
                }
        }
        
        
        public IEnumerable< CreditCard> CreditCards
        {
            get {           
                
                foreach(CreditCard creditCard in CreditCardList())
                    yield return creditCard; 
                }         
        }    
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.ContactID = (int)reader[COL_CONTACTID];
			this.NameStyle = (bool)reader[COL_NAMESTYLE];
			this.Title = DbConvert.ToString(reader[COL_TITLE]);
			this.FirstName = (string)reader[COL_FIRSTNAME];
			this.MiddleName = DbConvert.ToString(reader[COL_MIDDLENAME]);
			this.LastName = (string)reader[COL_LASTNAME];
			this.Suffix = DbConvert.ToString(reader[COL_SUFFIX]);
			this.EmailAddress = DbConvert.ToString(reader[COL_EMAILADDRESS]);
			this.EmailPromotion = (int)reader[COL_EMAILPROMOTION];
			this.Phone = DbConvert.ToString(reader[COL_PHONE]);
			this.PasswordHash = (string)reader[COL_PASSWORDHASH];
			this.PasswordSalt = (string)reader[COL_PASSWORDSALT];
			this.AdditionalContactInfo = (System.Xml.XmlDocument)reader[COL_ADDITIONALCONTACTINFO];
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_CONTACT))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.NameStyle, PARAM_NAMESTYLE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Title), PARAM_TITLE));
				command.Parameters.Add(dataContext.CreateParameter(this.FirstName, PARAM_FIRSTNAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.MiddleName), PARAM_MIDDLENAME));
				command.Parameters.Add(dataContext.CreateParameter(this.LastName, PARAM_LASTNAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Suffix), PARAM_SUFFIX));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EmailAddress), PARAM_EMAILADDRESS));
				command.Parameters.Add(dataContext.CreateParameter(this.EmailPromotion, PARAM_EMAILPROMOTION));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Phone), PARAM_PHONE));
				command.Parameters.Add(dataContext.CreateParameter(this.PasswordHash, PARAM_PASSWORDHASH));
				command.Parameters.Add(dataContext.CreateParameter(this.PasswordSalt, PARAM_PASSWORDSALT));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.AdditionalContactInfo), PARAM_ADDITIONALCONTACTINFO));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.ContactID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_CONTACT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ContactID, PARAM_CONTACTID));
				command.Parameters.Add(dataContext.CreateParameter(this.NameStyle, PARAM_NAMESTYLE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Title), PARAM_TITLE));
				command.Parameters.Add(dataContext.CreateParameter(this.FirstName, PARAM_FIRSTNAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.MiddleName), PARAM_MIDDLENAME));
				command.Parameters.Add(dataContext.CreateParameter(this.LastName, PARAM_LASTNAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Suffix), PARAM_SUFFIX));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EmailAddress), PARAM_EMAILADDRESS));
				command.Parameters.Add(dataContext.CreateParameter(this.EmailPromotion, PARAM_EMAILPROMOTION));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Phone), PARAM_PHONE));
				command.Parameters.Add(dataContext.CreateParameter(this.PasswordHash, PARAM_PASSWORDHASH));
				command.Parameters.Add(dataContext.CreateParameter(this.PasswordSalt, PARAM_PASSWORDSALT));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.AdditionalContactInfo), PARAM_ADDITIONALCONTACTINFO));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_CONTACT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ContactID, PARAM_CONTACTID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public Employee GetEmployeesQuery()
        {
            return new Employee {                
                                                                            ContactID = this.ContactID  
                                                                            };
        }
        
        public Employee[] EmployeeList()
        {
            return GetEmployeesQuery().ToList();
        }  
        
        public VendorContact GetVendorContactsQuery()
        {
            return new VendorContact {                
                                                                            ContactID = this.ContactID  
                                                                            };
        }
        
        public VendorContact[] VendorContactList()
        {
            return GetVendorContactsQuery().ToList();
        }  
        
        public ContactCreditCard GetContactCreditCardsQuery()
        {
            return new ContactCreditCard {                
                                                                            ContactID = this.ContactID  
                                                                            };
        }
        
        public ContactCreditCard[] ContactCreditCardList()
        {
            return GetContactCreditCardsQuery().ToList();
        }  
        
        public Individual GetIndividualsQuery()
        {
            return new Individual {                
                                                                            ContactID = this.ContactID  
                                                                            };
        }
        
        public Individual[] IndividualList()
        {
            return GetIndividualsQuery().ToList();
        }  
        
        public SalesOrderHeader GetSalesOrderHeadersQuery()
        {
            return new SalesOrderHeader {                
                                                                            ContactID = this.ContactID  
                                                                            };
        }
        
        public SalesOrderHeader[] SalesOrderHeaderList()
        {
            return GetSalesOrderHeadersQuery().ToList();
        }  
        
        public StoreContact GetStoreContactsQuery()
        {
            return new StoreContact {                
                                                                            ContactID = this.ContactID  
                                                                            };
        }
        
        public StoreContact[] StoreContactList()
        {
            return GetStoreContactsQuery().ToList();
        }  
        
        
        
        public CreditCard[] CreditCardList()
        {
            string sqlQuery = @"SELECT Sales.CreditCard.*
                                FROM Sales.ContactCreditCard
                                INNER JOIN Sales.CreditCard ON                                                                            
                                Sales.ContactCreditCard.[CreditCardID] = Sales.CreditCard.[CreditCardID] AND
                                Sales.ContactCreditCard.[ContactID] = @ContactID  
                                ";
                                
            Dictionary<string, object> parameterValues = new Dictionary<string, object>();
            parameterValues.Add(PARAM_CONTACTID, this.ContactID);
            
            return CreditCard.ToList(sqlQuery, parameterValues);
            
        }    
        
        #endregion
    }
}
