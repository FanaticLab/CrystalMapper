/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: SpecialOffer
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
    public partial class SpecialOffer : Entity< SpecialOffer>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.SpecialOffer";	
     
		public const string COL_SPECIALOFFERID = "SpecialOfferID";
		public const string COL_DESCRIPTION = "Description";
		public const string COL_DISCOUNTPCT = "DiscountPct";
		public const string COL_TYPE = "Type";
		public const string COL_CATEGORY = "Category";
		public const string COL_STARTDATE = "StartDate";
		public const string COL_ENDDATE = "EndDate";
		public const string COL_MINQTY = "MinQty";
		public const string COL_MAXQTY = "MaxQty";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SPECIALOFFERID = "@SpecialOfferID";	
        public const string PARAM_DESCRIPTION = "@Description";	
        public const string PARAM_DISCOUNTPCT = "@DiscountPct";	
        public const string PARAM_TYPE = "@Type";	
        public const string PARAM_CATEGORY = "@Category";	
        public const string PARAM_STARTDATE = "@StartDate";	
        public const string PARAM_ENDDATE = "@EndDate";	
        public const string PARAM_MINQTY = "@MinQty";	
        public const string PARAM_MAXQTY = "@MaxQty";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SPECIALOFFER = "INSERT INTO Sales.SpecialOffer([Description],[DiscountPct],[Type],[Category],[StartDate],[EndDate],[MinQty],[MaxQty],[rowguid],[ModifiedDate]) VALUES (@Description,@DiscountPct,@Type,@Category,@StartDate,@EndDate,@MinQty,@MaxQty,@rowguid,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_SPECIALOFFER = "UPDATE Sales.SpecialOffer SET  [Description] = @Description, [DiscountPct] = @DiscountPct, [Type] = @Type, [Category] = @Category, [StartDate] = @StartDate, [EndDate] = @EndDate, [MinQty] = @MinQty, [MaxQty] = @MaxQty, [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate WHERE [SpecialOfferID] = @SpecialOfferID";
		
		private const string SQL_DELETE_SPECIALOFFER = "DELETE FROM Sales.SpecialOffer WHERE  [SpecialOfferID] = @SpecialOfferID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int specialofferid = default(int);
	
		protected string description = default(string);
	
		protected decimal discountpct = default(decimal);
	
		protected string type = default(string);
	
		protected string category = default(string);
	
		protected System.DateTime startdate = default(System.DateTime);
	
		protected System.DateTime enddate = default(System.DateTime);
	
		protected int minqty = default(int);
	
		protected int? maxqty = default(int?);
	
		protected System.Guid rowguid = default(System.Guid);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
        protected EntityCollection< SpecialOfferProduct> specialOfferProducts ;
        
        #endregion

 		#region Properties	

        [Column( COL_SPECIALOFFERID, PARAM_SPECIALOFFERID, default(int))]
                              public virtual int SpecialOfferID 
        {
            get { return this.specialofferid; }
			set	{ 
                  if(this.specialofferid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SpecialOfferID"));  
                        this.specialofferid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SpecialOfferID"));
                    }   
                }
        }	
		
        [Column( COL_DESCRIPTION, PARAM_DESCRIPTION )]
                              public virtual string Description 
        {
            get { return this.description; }
			set	{ 
                  if(this.description != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Description"));  
                        this.description = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Description"));
                    }   
                }
        }	
		
        [Column( COL_DISCOUNTPCT, PARAM_DISCOUNTPCT, typeof(decimal))]
                              public virtual decimal DiscountPct 
        {
            get { return this.discountpct; }
			set	{ 
                  if(this.discountpct != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("DiscountPct"));  
                        this.discountpct = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("DiscountPct"));
                    }   
                }
        }	
		
        [Column( COL_TYPE, PARAM_TYPE )]
                              public virtual string Type 
        {
            get { return this.type; }
			set	{ 
                  if(this.type != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Type"));  
                        this.type = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Type"));
                    }   
                }
        }	
		
        [Column( COL_CATEGORY, PARAM_CATEGORY )]
                              public virtual string Category 
        {
            get { return this.category; }
			set	{ 
                  if(this.category != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Category"));  
                        this.category = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Category"));
                    }   
                }
        }	
		
        [Column( COL_STARTDATE, PARAM_STARTDATE, typeof(System.DateTime))]
                              public virtual System.DateTime StartDate 
        {
            get { return this.startdate; }
			set	{ 
                  if(this.startdate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("StartDate"));  
                        this.startdate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("StartDate"));
                    }   
                }
        }	
		
        [Column( COL_ENDDATE, PARAM_ENDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime EndDate 
        {
            get { return this.enddate; }
			set	{ 
                  if(this.enddate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("EndDate"));  
                        this.enddate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("EndDate"));
                    }   
                }
        }	
		
        [Column( COL_MINQTY, PARAM_MINQTY, default(int))]
                              public virtual int MinQty 
        {
            get { return this.minqty; }
			set	{ 
                  if(this.minqty != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("MinQty"));  
                        this.minqty = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("MinQty"));
                    }   
                }
        }	
		
        [Column( COL_MAXQTY, PARAM_MAXQTY )]
                              public virtual int? MaxQty 
        {
            get { return this.maxqty; }
			set	{ 
                  if(this.maxqty != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("MaxQty"));  
                        this.maxqty = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("MaxQty"));
                    }   
                }
        }	
		
        [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid 
        {
            get { return this.rowguid; }
			set	{ 
                  if(this.rowguid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Rowguid"));  
                        this.rowguid = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Rowguid"));
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
		
        public EntityCollection< SpecialOfferProduct> SpecialOfferProducts 
        {
            get { return this.specialOfferProducts;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public SpecialOffer()
        {
             this.specialOfferProducts = new EntityCollection< SpecialOfferProduct>(this, new Associate< SpecialOfferProduct>(this.AssociateSpecialOfferProducts), new DeAssociate< SpecialOfferProduct>(this.DeAssociateSpecialOfferProducts), new GetChildren< SpecialOfferProduct>(this.GetChildrenSpecialOfferProducts));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.specialofferid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            SpecialOffer entity = obj as SpecialOffer;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.SpecialOfferID == entity.SpecialOfferID
                        && this.SpecialOfferID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.specialofferid = (int)reader[COL_SPECIALOFFERID];
			this.description = (string)reader[COL_DESCRIPTION];
			this.discountpct = (decimal)reader[COL_DISCOUNTPCT];
			this.type = (string)reader[COL_TYPE];
			this.category = (string)reader[COL_CATEGORY];
			this.startdate = (System.DateTime)reader[COL_STARTDATE];
			this.enddate = (System.DateTime)reader[COL_ENDDATE];
			this.minqty = (int)reader[COL_MINQTY];
			this.maxqty = DbConvert.ToNullable< int >(reader[COL_MAXQTY]);
			this.rowguid = (System.Guid)reader[COL_ROWGUID];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SPECIALOFFER))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Description, PARAM_DESCRIPTION));
				command.Parameters.Add(dataContext.CreateParameter(this.DiscountPct, PARAM_DISCOUNTPCT));
				command.Parameters.Add(dataContext.CreateParameter(this.Type, PARAM_TYPE));
				command.Parameters.Add(dataContext.CreateParameter(this.Category, PARAM_CATEGORY));
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.EndDate, PARAM_ENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.MinQty, PARAM_MINQTY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.MaxQty), PARAM_MAXQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.SpecialOfferID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SPECIALOFFER))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SpecialOfferID, PARAM_SPECIALOFFERID));
				command.Parameters.Add(dataContext.CreateParameter(this.Description, PARAM_DESCRIPTION));
				command.Parameters.Add(dataContext.CreateParameter(this.DiscountPct, PARAM_DISCOUNTPCT));
				command.Parameters.Add(dataContext.CreateParameter(this.Type, PARAM_TYPE));
				command.Parameters.Add(dataContext.CreateParameter(this.Category, PARAM_CATEGORY));
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.EndDate, PARAM_ENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.MinQty, PARAM_MINQTY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.MaxQty), PARAM_MAXQTY));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SPECIALOFFER))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SpecialOfferID, PARAM_SPECIALOFFERID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateSpecialOfferProducts(SpecialOfferProduct specialOfferProduct)
        {
           specialOfferProduct.SpecialOfferEntity = this;
        }
        
        private void DeAssociateSpecialOfferProducts(SpecialOfferProduct specialOfferProduct)
        {
          if(specialOfferProduct.SpecialOfferEntity == this)
             specialOfferProduct.SpecialOfferEntity = null;
        }
        
        private SpecialOfferProduct[] GetChildrenSpecialOfferProducts()
        {
            SpecialOfferProduct childrenQuery = new SpecialOfferProduct();
            childrenQuery.SpecialOfferEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
