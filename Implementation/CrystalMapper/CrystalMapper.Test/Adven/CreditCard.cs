/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: CreditCard
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
    public partial class CreditCard : Entity< CreditCard>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.CreditCard";	
     
		public const string COL_CREDITCARDID = "CreditCardID";
		public const string COL_CARDTYPE = "CardType";
		public const string COL_CARDNUMBER = "CardNumber";
		public const string COL_EXPMONTH = "ExpMonth";
		public const string COL_EXPYEAR = "ExpYear";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_CREDITCARDID = "@CreditCardID";	
        public const string PARAM_CARDTYPE = "@CardType";	
        public const string PARAM_CARDNUMBER = "@CardNumber";	
        public const string PARAM_EXPMONTH = "@ExpMonth";	
        public const string PARAM_EXPYEAR = "@ExpYear";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_CREDITCARD = "INSERT INTO Sales.CreditCard([CardType],[CardNumber],[ExpMonth],[ExpYear],[ModifiedDate]) VALUES (@CardType,@CardNumber,@ExpMonth,@ExpYear,@ModifiedDate);";
		
		private const string SQL_UPDATE_CREDITCARD = "UPDATE Sales.CreditCard SET [CardType] = @CardType, [CardNumber] = @CardNumber, [ExpMonth] = @ExpMonth, [ExpYear] = @ExpYear, [ModifiedDate] = @ModifiedDate,  WHERE [CreditCardID] = @CreditCardID";
		
		private const string SQL_DELETE_CREDITCARD = "DELETE FROM Sales.CreditCard WHERE  [CreditCardID] = @CreditCardID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_CREDITCARDID, PARAM_CREDITCARDID, default(int))]
                              public virtual int CreditCardID  { get; set; }		
		
        
	    [Column( COL_CARDTYPE, PARAM_CARDTYPE )]
                              public virtual string CardType  { get; set; }	      
        
	    [Column( COL_CARDNUMBER, PARAM_CARDNUMBER )]
                              public virtual string CardNumber  { get; set; }	      
        
	    [Column( COL_EXPMONTH, PARAM_EXPMONTH, default(byte))]
                              public virtual byte ExpMonth  { get; set; }	      
        
	    [Column( COL_EXPYEAR, PARAM_EXPYEAR, default(short))]
                              public virtual short ExpYear  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< ContactCreditCard> ContactCreditCards
        {
            get {
                  foreach(ContactCreditCard contactCreditCard in ContactCreditCardList())
                    yield return contactCreditCard; 
                }
        }
        
        public IEnumerable< SalesOrderHeader> SalesOrderHeaders
        {
            get {
                  foreach(SalesOrderHeader salesOrderHeader in SalesOrderHeaderList())
                    yield return salesOrderHeader; 
                }
        }
        
        
        public IEnumerable< Contact> Contacts
        {
            get {           
                
                foreach(Contact contact in ContactList())
                    yield return contact; 
                }         
        }    
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.CreditCardID = (int)reader[COL_CREDITCARDID];
			this.CardType = (string)reader[COL_CARDTYPE];
			this.CardNumber = (string)reader[COL_CARDNUMBER];
			this.ExpMonth = (byte)reader[COL_EXPMONTH];
			this.ExpYear = (short)reader[COL_EXPYEAR];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_CREDITCARD))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.CardType, PARAM_CARDTYPE));
				command.Parameters.Add(dataContext.CreateParameter(this.CardNumber, PARAM_CARDNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.ExpMonth, PARAM_EXPMONTH));
				command.Parameters.Add(dataContext.CreateParameter(this.ExpYear, PARAM_EXPYEAR));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.CreditCardID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_CREDITCARD))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CreditCardID, PARAM_CREDITCARDID));
				command.Parameters.Add(dataContext.CreateParameter(this.CardType, PARAM_CARDTYPE));
				command.Parameters.Add(dataContext.CreateParameter(this.CardNumber, PARAM_CARDNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(this.ExpMonth, PARAM_EXPMONTH));
				command.Parameters.Add(dataContext.CreateParameter(this.ExpYear, PARAM_EXPYEAR));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_CREDITCARD))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CreditCardID, PARAM_CREDITCARDID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public ContactCreditCard GetContactCreditCardsQuery()
        {
            return new ContactCreditCard {                
                                                                            CreditCardID = this.CreditCardID  
                                                                            };
        }
        
        public ContactCreditCard[] ContactCreditCardList()
        {
            return GetContactCreditCardsQuery().ToList();
        }  
        
        public SalesOrderHeader GetSalesOrderHeadersQuery()
        {
            return new SalesOrderHeader {                
                                                                            CreditCardID = this.CreditCardID  
                                                                            };
        }
        
        public SalesOrderHeader[] SalesOrderHeaderList()
        {
            return GetSalesOrderHeadersQuery().ToList();
        }  
        
        
        
        public Contact[] ContactList()
        {
            string sqlQuery = @"SELECT Person.Contact.*
                                FROM Sales.ContactCreditCard
                                INNER JOIN Person.Contact ON                                                                            
                                Sales.ContactCreditCard.[ContactID] = Person.Contact.[ContactID] AND
                                Sales.ContactCreditCard.[CreditCardID] = @CreditCardID  
                                ";
                                
            Dictionary<string, object> parameterValues = new Dictionary<string, object>();
            parameterValues.Add(PARAM_CREDITCARDID, this.CreditCardID);
            
            return Contact.ToList(sqlQuery, parameterValues);
            
        }    
        
        #endregion
    }
}
