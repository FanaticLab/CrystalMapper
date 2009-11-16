/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: CreditCard
 * 
 * Email: mk.faraz@gmail.com
 * 
 * Blogs: http://csharplive.wordpress.com, http://farazmasoodkhan.wordpress.com
 *
 * Website: http://www.linkedin.com/in/farazmasoodkhan
 *
 * Copyright: Faraz Masood Khan @ Copyright 2009
 *
/*/

using System;
using System.Data.Common;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;

using CoreSystem.Data;

using CrystalMapper;
using CrystalMapper.Data;
using CrystalMapper.Mapping;

namespace feedbook.Model
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
		
		private const string SQL_INSERT_CREDITCARD = "INSERT INTO Sales.CreditCard([CardType],[CardNumber],[ExpMonth],[ExpYear],[ModifiedDate]) VALUES (@CardType,@CardNumber,@ExpMonth,@ExpYear,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_CREDITCARD = "UPDATE Sales.CreditCard SET  [CardType] = @CardType, [CardNumber] = @CardNumber, [ExpMonth] = @ExpMonth, [ExpYear] = @ExpYear, [ModifiedDate] = @ModifiedDate WHERE [CreditCardID] = @CreditCardID";
		
		private const string SQL_DELETE_CREDITCARD = "DELETE FROM Sales.CreditCard WHERE  [CreditCardID] = @CreditCardID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int creditcardid = default(int);
	
		protected string cardtype = default(string);
	
		protected string cardnumber = default(string);
	
		protected byte expmonth = default(byte);
	
		protected short expyear = default(short);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
        protected EntityCollection< PersonCreditCard> personCreditCards ;
        
        protected EntityCollection< SalesOrderHeader> salesOrderHeaders ;
        
        #endregion

 		#region Properties	

        [Column( COL_CREDITCARDID, PARAM_CREDITCARDID, default(int))]
                              public virtual int CreditCardID 
        {
            get { return this.creditcardid; }
			set	{ 
                  if(this.creditcardid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CreditCardID"));  
                        this.creditcardid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CreditCardID"));
                    }   
                }
        }	
		
        [Column( COL_CARDTYPE, PARAM_CARDTYPE )]
                              public virtual string CardType 
        {
            get { return this.cardtype; }
			set	{ 
                  if(this.cardtype != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CardType"));  
                        this.cardtype = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CardType"));
                    }   
                }
        }	
		
        [Column( COL_CARDNUMBER, PARAM_CARDNUMBER )]
                              public virtual string CardNumber 
        {
            get { return this.cardnumber; }
			set	{ 
                  if(this.cardnumber != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CardNumber"));  
                        this.cardnumber = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CardNumber"));
                    }   
                }
        }	
		
        [Column( COL_EXPMONTH, PARAM_EXPMONTH, default(byte))]
                              public virtual byte ExpMonth 
        {
            get { return this.expmonth; }
			set	{ 
                  if(this.expmonth != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ExpMonth"));  
                        this.expmonth = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ExpMonth"));
                    }   
                }
        }	
		
        [Column( COL_EXPYEAR, PARAM_EXPYEAR, default(short))]
                              public virtual short ExpYear 
        {
            get { return this.expyear; }
			set	{ 
                  if(this.expyear != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ExpYear"));  
                        this.expyear = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ExpYear"));
                    }   
                }
        }	
		
        [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate 
        {
            get { return this.modifieddate; }
			set	{ 
                  if(this.modifieddate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ModifiedDate"));  
                        this.modifieddate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ModifiedDate"));
                    }   
                }
        }	
		
        public EntityCollection< PersonCreditCard> PersonCreditCards 
        {
            get { return this.personCreditCards;}
        }
        
        public EntityCollection< SalesOrderHeader> SalesOrderHeaders 
        {
            get { return this.salesOrderHeaders;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public CreditCard()
        {
             this.personCreditCards = new EntityCollection< PersonCreditCard>(this, new Associate< PersonCreditCard>(this.AssociatePersonCreditCards), new DeAssociate< PersonCreditCard>(this.DeAssociatePersonCreditCards), new GetChildren< PersonCreditCard>(this.GetChildrenPersonCreditCards));
             this.salesOrderHeaders = new EntityCollection< SalesOrderHeader>(this, new Associate< SalesOrderHeader>(this.AssociateSalesOrderHeaders), new DeAssociate< SalesOrderHeader>(this.DeAssociateSalesOrderHeaders), new GetChildren< SalesOrderHeader>(this.GetChildrenSalesOrderHeaders));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.creditcardid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            CreditCard entity = obj as CreditCard;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.CreditCardID == entity.CreditCardID
                        && this.CreditCardID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.creditcardid = (int)reader[COL_CREDITCARDID];
			this.cardtype = (string)reader[COL_CARDTYPE];
			this.cardnumber = (string)reader[COL_CARDNUMBER];
			this.expmonth = (byte)reader[COL_EXPMONTH];
			this.expyear = (short)reader[COL_EXPYEAR];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
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
                this.CreditCardID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
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
        
        #region Entity Relationship Functions
        
        private void AssociatePersonCreditCards(PersonCreditCard personCreditCard)
        {
           personCreditCard.CreditCardEntity = this;
        }
        
        private void DeAssociatePersonCreditCards(PersonCreditCard personCreditCard)
        {
          if(personCreditCard.CreditCardEntity == this)
             personCreditCard.CreditCardEntity = null;
        }
        
        private PersonCreditCard[] GetChildrenPersonCreditCards()
        {
            PersonCreditCard childrenQuery = new PersonCreditCard();
            childrenQuery.CreditCardEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        private void AssociateSalesOrderHeaders(SalesOrderHeader salesOrderHeader)
        {
           salesOrderHeader.CreditCardEntity = this;
        }
        
        private void DeAssociateSalesOrderHeaders(SalesOrderHeader salesOrderHeader)
        {
          if(salesOrderHeader.CreditCardEntity == this)
             salesOrderHeader.CreditCardEntity = null;
        }
        
        private SalesOrderHeader[] GetChildrenSalesOrderHeaders()
        {
            SalesOrderHeader childrenQuery = new SalesOrderHeader();
            childrenQuery.CreditCardEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
