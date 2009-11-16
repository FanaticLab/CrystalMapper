/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: ProductReview
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
    public partial class ProductReview : Entity< ProductReview>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.ProductReview";	
     
		public const string COL_PRODUCTREVIEWID = "ProductReviewID";
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_REVIEWERNAME = "ReviewerName";
		public const string COL_REVIEWDATE = "ReviewDate";
		public const string COL_EMAILADDRESS = "EmailAddress";
		public const string COL_RATING = "Rating";
		public const string COL_COMMENTS = "Comments";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PRODUCTREVIEWID = "@ProductReviewID";	
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_REVIEWERNAME = "@ReviewerName";	
        public const string PARAM_REVIEWDATE = "@ReviewDate";	
        public const string PARAM_EMAILADDRESS = "@EmailAddress";	
        public const string PARAM_RATING = "@Rating";	
        public const string PARAM_COMMENTS = "@Comments";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PRODUCTREVIEW = "INSERT INTO Production.ProductReview([ProductID],[ReviewerName],[ReviewDate],[EmailAddress],[Rating],[Comments],[ModifiedDate]) VALUES (@ProductID,@ReviewerName,@ReviewDate,@EmailAddress,@Rating,@Comments,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_PRODUCTREVIEW = "UPDATE Production.ProductReview SET  [ProductID] = @ProductID, [ReviewerName] = @ReviewerName, [ReviewDate] = @ReviewDate, [EmailAddress] = @EmailAddress, [Rating] = @Rating, [Comments] = @Comments, [ModifiedDate] = @ModifiedDate WHERE [ProductReviewID] = @ProductReviewID";
		
		private const string SQL_DELETE_PRODUCTREVIEW = "DELETE FROM Production.ProductReview WHERE  [ProductReviewID] = @ProductReviewID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int productreviewid = default(int);
	
		protected int productid = default(int);
	
		protected string reviewername = default(string);
	
		protected System.DateTime reviewdate = default(System.DateTime);
	
		protected string emailaddress = default(string);
	
		protected int rating = default(int);
	
		protected string comment = default(string);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected Product productEntity;
	
        #endregion

 		#region Properties	

        [Column( COL_PRODUCTREVIEWID, PARAM_PRODUCTREVIEWID, default(int))]
                              public virtual int ProductReviewID 
        {
            get { return this.productreviewid; }
			set	{ 
                  if(this.productreviewid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductReviewID"));  
                        this.productreviewid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductReviewID"));
                    }   
                }
        }	
		
        [Column( COL_REVIEWERNAME, PARAM_REVIEWERNAME )]
                              public virtual string ReviewerName 
        {
            get { return this.reviewername; }
			set	{ 
                  if(this.reviewername != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ReviewerName"));  
                        this.reviewername = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ReviewerName"));
                    }   
                }
        }	
		
        [Column( COL_REVIEWDATE, PARAM_REVIEWDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ReviewDate 
        {
            get { return this.reviewdate; }
			set	{ 
                  if(this.reviewdate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ReviewDate"));  
                        this.reviewdate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ReviewDate"));
                    }   
                }
        }	
		
        [Column( COL_EMAILADDRESS, PARAM_EMAILADDRESS )]
                              public virtual string EmailAddress 
        {
            get { return this.emailaddress; }
			set	{ 
                  if(this.emailaddress != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("EmailAddress"));  
                        this.emailaddress = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("EmailAddress"));
                    }   
                }
        }	
		
        [Column( COL_RATING, PARAM_RATING, default(int))]
                              public virtual int Rating 
        {
            get { return this.rating; }
			set	{ 
                  if(this.rating != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Rating"));  
                        this.rating = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Rating"));
                    }   
                }
        }	
		
        [Column( COL_COMMENTS, PARAM_COMMENTS )]
                              public virtual string Comments 
        {
            get { return this.comment; }
			set	{ 
                  if(this.comment != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Comments"));  
                        this.comment = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Comments"));
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
		
        [Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID                
        {
            get
            {
                if(this.productEntity == null)
                    return this.productid ;
                
                return this.productEntity.ProductID;            
            }
            set
            {
                if(this.productid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ProductID"));                    
                    this.productid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ProductID"));
                    
                    this.productEntity = null;
                }                
            }          
        }	
        
        public Product ProductEntity
        {
            get { 
                    if(this.productEntity == null
                       && this.productid != default(int)) 
                    {
                        Product productQuery = new Product {
                                                        ProductID = this.productid  
                                                        };
                        
                        Product[]  products = productQuery.ToList();                        
                        if(products.Length == 1)
                            this.productEntity = products[0];                        
                    }
                    
                    return this.productEntity; 
                }
			set	{ 
                  if(this.productEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ProductEntity"));
                        if (this.productEntity != null)
                            this.Parents.Remove(this.productEntity);                            
                        
                        if((this.productEntity = value) != null) 
                            this.Parents.Add(this.productEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ProductEntity"));
                        
                        this.productid = this.ProductEntity.ProductID;
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
		
        public ProductReview()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.productreviewid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            ProductReview entity = obj as ProductReview;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.ProductReviewID == entity.ProductReviewID
                        && this.ProductReviewID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.productreviewid = (int)reader[COL_PRODUCTREVIEWID];
			this.productid = (int)reader[COL_PRODUCTID];
			this.reviewername = (string)reader[COL_REVIEWERNAME];
			this.reviewdate = (System.DateTime)reader[COL_REVIEWDATE];
			this.emailaddress = (string)reader[COL_EMAILADDRESS];
			this.rating = (int)reader[COL_RATING];
			this.comment = DbConvert.ToString(reader[COL_COMMENTS]);
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTREVIEW))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.ReviewerName, PARAM_REVIEWERNAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ReviewDate, PARAM_REVIEWDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.EmailAddress, PARAM_EMAILADDRESS));
				command.Parameters.Add(dataContext.CreateParameter(this.Rating, PARAM_RATING));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Comments), PARAM_COMMENTS));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.ProductReviewID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCTREVIEW))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductReviewID, PARAM_PRODUCTREVIEWID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.ReviewerName, PARAM_REVIEWERNAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ReviewDate, PARAM_REVIEWDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.EmailAddress, PARAM_EMAILADDRESS));
				command.Parameters.Add(dataContext.CreateParameter(this.Rating, PARAM_RATING));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Comments), PARAM_COMMENTS));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCTREVIEW))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductReviewID, PARAM_PRODUCTREVIEWID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
