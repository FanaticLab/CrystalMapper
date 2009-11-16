/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: CurrencyRate
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
    public partial class CurrencyRate : Entity< CurrencyRate>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.CurrencyRate";	
     
		public const string COL_CURRENCYRATEID = "CurrencyRateID";
		public const string COL_CURRENCYRATEDATE = "CurrencyRateDate";
		public const string COL_FROMCURRENCYCODE = "FromCurrencyCode";
		public const string COL_TOCURRENCYCODE = "ToCurrencyCode";
		public const string COL_AVERAGERATE = "AverageRate";
		public const string COL_ENDOFDAYRATE = "EndOfDayRate";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_CURRENCYRATEID = "@CurrencyRateID";	
        public const string PARAM_CURRENCYRATEDATE = "@CurrencyRateDate";	
        public const string PARAM_FROMCURRENCYCODE = "@FromCurrencyCode";	
        public const string PARAM_TOCURRENCYCODE = "@ToCurrencyCode";	
        public const string PARAM_AVERAGERATE = "@AverageRate";	
        public const string PARAM_ENDOFDAYRATE = "@EndOfDayRate";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_CURRENCYRATE = "INSERT INTO Sales.CurrencyRate([CurrencyRateDate],[FromCurrencyCode],[ToCurrencyCode],[AverageRate],[EndOfDayRate],[ModifiedDate]) VALUES (@CurrencyRateDate,@FromCurrencyCode,@ToCurrencyCode,@AverageRate,@EndOfDayRate,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_CURRENCYRATE = "UPDATE Sales.CurrencyRate SET  [CurrencyRateDate] = @CurrencyRateDate, [FromCurrencyCode] = @FromCurrencyCode, [ToCurrencyCode] = @ToCurrencyCode, [AverageRate] = @AverageRate, [EndOfDayRate] = @EndOfDayRate, [ModifiedDate] = @ModifiedDate WHERE [CurrencyRateID] = @CurrencyRateID";
		
		private const string SQL_DELETE_CURRENCYRATE = "DELETE FROM Sales.CurrencyRate WHERE  [CurrencyRateID] = @CurrencyRateID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int currencyrateid = default(int);
	
		protected System.DateTime currencyratedate = default(System.DateTime);
	
		protected string fromcurrencycode = default(string);
	
		protected string tocurrencycode = default(string);
	
		protected decimal averagerate = default(decimal);
	
		protected decimal endofdayrate = default(decimal);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected Currency fromcurrencyEntity;
	
		protected Currency tocurrencyEntity;
	
        protected EntityCollection< SalesOrderHeader> salesOrderHeaders ;
        
        #endregion

 		#region Properties	

        [Column( COL_CURRENCYRATEID, PARAM_CURRENCYRATEID, default(int))]
                              public virtual int CurrencyRateID 
        {
            get { return this.currencyrateid; }
			set	{ 
                  if(this.currencyrateid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CurrencyRateID"));  
                        this.currencyrateid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CurrencyRateID"));
                    }   
                }
        }	
		
        [Column( COL_CURRENCYRATEDATE, PARAM_CURRENCYRATEDATE, typeof(System.DateTime))]
                              public virtual System.DateTime CurrencyRateDate 
        {
            get { return this.currencyratedate; }
			set	{ 
                  if(this.currencyratedate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CurrencyRateDate"));  
                        this.currencyratedate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CurrencyRateDate"));
                    }   
                }
        }	
		
        [Column( COL_AVERAGERATE, PARAM_AVERAGERATE, typeof(decimal))]
                              public virtual decimal AverageRate 
        {
            get { return this.averagerate; }
			set	{ 
                  if(this.averagerate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("AverageRate"));  
                        this.averagerate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("AverageRate"));
                    }   
                }
        }	
		
        [Column( COL_ENDOFDAYRATE, PARAM_ENDOFDAYRATE, typeof(decimal))]
                              public virtual decimal EndOfDayRate 
        {
            get { return this.endofdayrate; }
			set	{ 
                  if(this.endofdayrate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("EndOfDayRate"));  
                        this.endofdayrate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("EndOfDayRate"));
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
		
        [Column( COL_FROMCURRENCYCODE, PARAM_FROMCURRENCYCODE )]
                              public virtual string FromCurrencyCode                
        {
            get
            {
                if(this.fromcurrencyEntity == null)
                    return this.fromcurrencycode ;
                
                return this.fromcurrencyEntity.CurrencyCode;            
            }
            set
            {
                if(this.fromcurrencycode != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("FromCurrencyCode"));                    
                    this.fromcurrencycode = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("FromCurrencyCode"));
                    
                    this.fromcurrencyEntity = null;
                }                
            }          
        }	
        
        [Column( COL_TOCURRENCYCODE, PARAM_TOCURRENCYCODE )]
                              public virtual string ToCurrencyCode                
        {
            get
            {
                if(this.tocurrencyEntity == null)
                    return this.tocurrencycode ;
                
                return this.tocurrencyEntity.CurrencyCode;            
            }
            set
            {
                if(this.tocurrencycode != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ToCurrencyCode"));                    
                    this.tocurrencycode = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ToCurrencyCode"));
                    
                    this.tocurrencyEntity = null;
                }                
            }          
        }	
        
        public Currency FromCurrencyEntity
        {
            get { 
                    if(this.fromcurrencyEntity == null
                       && this.fromcurrencycode != default(string)) 
                    {
                        Currency currencyQuery = new Currency {
                                                        CurrencyCode = this.fromcurrencycode  
                                                        };
                        
                        Currency[]  currencies = currencyQuery.ToList();                        
                        if(currencies.Length == 1)
                            this.fromcurrencyEntity = currencies[0];                        
                    }
                    
                    return this.fromcurrencyEntity; 
                }
			set	{ 
                  if(this.fromcurrencyEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("FromCurrencyEntity"));
                        if (this.fromcurrencyEntity != null)
                            this.Parents.Remove(this.fromcurrencyEntity);                            
                        
                        if((this.fromcurrencyEntity = value) != null) 
                            this.Parents.Add(this.fromcurrencyEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("FromCurrencyEntity"));
                        
                        this.fromcurrencycode = this.FromCurrencyEntity.CurrencyCode;
                    }   
                }
        }	
		
        public Currency ToCurrencyEntity
        {
            get { 
                    if(this.tocurrencyEntity == null
                       && this.tocurrencycode != default(string)) 
                    {
                        Currency currencyQuery = new Currency {
                                                        CurrencyCode = this.tocurrencycode  
                                                        };
                        
                        Currency[]  currencies = currencyQuery.ToList();                        
                        if(currencies.Length == 1)
                            this.tocurrencyEntity = currencies[0];                        
                    }
                    
                    return this.tocurrencyEntity; 
                }
			set	{ 
                  if(this.tocurrencyEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ToCurrencyEntity"));
                        if (this.tocurrencyEntity != null)
                            this.Parents.Remove(this.tocurrencyEntity);                            
                        
                        if((this.tocurrencyEntity = value) != null) 
                            this.Parents.Add(this.tocurrencyEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ToCurrencyEntity"));
                        
                        this.tocurrencycode = this.ToCurrencyEntity.CurrencyCode;
                    }   
                }
        }	
		
        public EntityCollection< SalesOrderHeader> SalesOrderHeaders 
        {
            get { return this.salesOrderHeaders;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public CurrencyRate()
        {
             this.salesOrderHeaders = new EntityCollection< SalesOrderHeader>(this, new Associate< SalesOrderHeader>(this.AssociateSalesOrderHeaders), new DeAssociate< SalesOrderHeader>(this.DeAssociateSalesOrderHeaders), new GetChildren< SalesOrderHeader>(this.GetChildrenSalesOrderHeaders));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.currencyrateid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            CurrencyRate entity = obj as CurrencyRate;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.CurrencyRateID == entity.CurrencyRateID
                        && this.CurrencyRateID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.currencyrateid = (int)reader[COL_CURRENCYRATEID];
			this.currencyratedate = (System.DateTime)reader[COL_CURRENCYRATEDATE];
			this.fromcurrencycode = (string)reader[COL_FROMCURRENCYCODE];
			this.tocurrencycode = (string)reader[COL_TOCURRENCYCODE];
			this.averagerate = (decimal)reader[COL_AVERAGERATE];
			this.endofdayrate = (decimal)reader[COL_ENDOFDAYRATE];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_CURRENCYRATE))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.CurrencyRateDate, PARAM_CURRENCYRATEDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.FromCurrencyCode, PARAM_FROMCURRENCYCODE));
				command.Parameters.Add(dataContext.CreateParameter(this.ToCurrencyCode, PARAM_TOCURRENCYCODE));
				command.Parameters.Add(dataContext.CreateParameter(this.AverageRate, PARAM_AVERAGERATE));
				command.Parameters.Add(dataContext.CreateParameter(this.EndOfDayRate, PARAM_ENDOFDAYRATE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.CurrencyRateID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_CURRENCYRATE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CurrencyRateID, PARAM_CURRENCYRATEID));
				command.Parameters.Add(dataContext.CreateParameter(this.CurrencyRateDate, PARAM_CURRENCYRATEDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.FromCurrencyCode, PARAM_FROMCURRENCYCODE));
				command.Parameters.Add(dataContext.CreateParameter(this.ToCurrencyCode, PARAM_TOCURRENCYCODE));
				command.Parameters.Add(dataContext.CreateParameter(this.AverageRate, PARAM_AVERAGERATE));
				command.Parameters.Add(dataContext.CreateParameter(this.EndOfDayRate, PARAM_ENDOFDAYRATE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_CURRENCYRATE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CurrencyRateID, PARAM_CURRENCYRATEID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateSalesOrderHeaders(SalesOrderHeader salesOrderHeader)
        {
           salesOrderHeader.CurrencyRateEntity = this;
        }
        
        private void DeAssociateSalesOrderHeaders(SalesOrderHeader salesOrderHeader)
        {
          if(salesOrderHeader.CurrencyRateEntity == this)
             salesOrderHeader.CurrencyRateEntity = null;
        }
        
        private SalesOrderHeader[] GetChildrenSalesOrderHeaders()
        {
            SalesOrderHeader childrenQuery = new SalesOrderHeader();
            childrenQuery.CurrencyRateEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
