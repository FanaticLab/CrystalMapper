/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: ProductReview
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
		
		private const string SQL_INSERT_PRODUCTREVIEW = "INSERT INTO Production.ProductReview([ProductID],[ReviewerName],[ReviewDate],[EmailAddress],[Rating],[Comments],[ModifiedDate]) VALUES (@ProductID,@ReviewerName,@ReviewDate,@EmailAddress,@Rating,@Comments,@ModifiedDate);";
		
		private const string SQL_UPDATE_PRODUCTREVIEW = "UPDATE Production.ProductReview SET [ProductID] = @ProductID, [ReviewerName] = @ReviewerName, [ReviewDate] = @ReviewDate, [EmailAddress] = @EmailAddress, [Rating] = @Rating, [Comments] = @Comments, [ModifiedDate] = @ModifiedDate,  WHERE [ProductReviewID] = @ProductReviewID";
		
		private const string SQL_DELETE_PRODUCTREVIEW = "DELETE FROM Production.ProductReview WHERE  [ProductReviewID] = @ProductReviewID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_PRODUCTREVIEWID, PARAM_PRODUCTREVIEWID, default(int))]
                              public virtual int ProductReviewID  { get; set; }		
		
        
	    [Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID  { get; set; }	      
        
	    [Column( COL_REVIEWERNAME, PARAM_REVIEWERNAME )]
                              public virtual string ReviewerName  { get; set; }	      
        
	    [Column( COL_REVIEWDATE, PARAM_REVIEWDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ReviewDate  { get; set; }	      
        
	    [Column( COL_EMAILADDRESS, PARAM_EMAILADDRESS )]
                              public virtual string EmailAddress  { get; set; }	      
        
	    [Column( COL_RATING, PARAM_RATING, default(int))]
                              public virtual int Rating  { get; set; }	      
        
	    [Column( COL_COMMENTS, PARAM_COMMENTS )]
                              public virtual string Comments  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.ProductReviewID = (int)reader[COL_PRODUCTREVIEWID];
			this.ProductID = (int)reader[COL_PRODUCTID];
			this.ReviewerName = (string)reader[COL_REVIEWERNAME];
			this.ReviewDate = (System.DateTime)reader[COL_REVIEWDATE];
			this.EmailAddress = (string)reader[COL_EMAILADDRESS];
			this.Rating = (int)reader[COL_RATING];
			this.Comments = DbConvert.ToString(reader[COL_COMMENTS]);
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
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
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.ProductReviewID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
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
        
        #region Children
        
        
        
        
        #endregion
    }
}
