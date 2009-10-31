/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: ContactCreditCard
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
    public partial class ContactCreditCard : Entity< ContactCreditCard>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.ContactCreditCard";	
     
		public const string COL_CONTACTID = "ContactID";
		public const string COL_CREDITCARDID = "CreditCardID";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_CONTACTID = "@ContactID";	
        public const string PARAM_CREDITCARDID = "@CreditCardID";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_CONTACTCREDITCARD = "INSERT INTO Sales.ContactCreditCard([ContactID],[CreditCardID],[ModifiedDate]) VALUES (@ContactID,@CreditCardID,@ModifiedDate);";
		
		private const string SQL_UPDATE_CONTACTCREDITCARD = "UPDATE Sales.ContactCreditCard SET [ModifiedDate] = @ModifiedDate,  WHERE [ContactID] = @ContactID AND [CreditCardID] = @CreditCardID";
		
		private const string SQL_DELETE_CONTACTCREDITCARD = "DELETE FROM Sales.ContactCreditCard WHERE  [ContactID] = @ContactID AND [CreditCardID] = @CreditCardID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_CONTACTID, PARAM_CONTACTID, default(int))]
                              public virtual int ContactID  { get; set; }		
		[Column( COL_CREDITCARDID, PARAM_CREDITCARDID, default(int))]
                              public virtual int CreditCardID  { get; set; }		
		
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.ContactID = (int)reader[COL_CONTACTID];
			this.CreditCardID = (int)reader[COL_CREDITCARDID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_CONTACTCREDITCARD))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ContactID, PARAM_CONTACTID));
				command.Parameters.Add(dataContext.CreateParameter(this.CreditCardID, PARAM_CREDITCARDID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_CONTACTCREDITCARD))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ContactID, PARAM_CONTACTID));
				command.Parameters.Add(dataContext.CreateParameter(this.CreditCardID, PARAM_CREDITCARDID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_CONTACTCREDITCARD))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ContactID, PARAM_CONTACTID));				
				command.Parameters.Add(dataContext.CreateParameter(this.CreditCardID, PARAM_CREDITCARDID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
