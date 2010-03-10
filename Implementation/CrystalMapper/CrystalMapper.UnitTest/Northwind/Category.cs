/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, March 10, 2010 9:38 PM
 * 
 * Class: Category
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
using CrystalMapper.Generic;
using CrystalMapper.Generic.Collection;

namespace CrystalMapper.UnitTest.Northwind
{
	[Table(TABLE_NAME)]
    public partial class Category : Entity< Category>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "dbo.Categories";	
     
		public const string COL_CATEGORYID = "CategoryID";
		public const string COL_CATEGORYNAME = "CategoryName";
		public const string COL_DESCRIPTION = "Description";
		public const string COL_PICTURE = "Picture";
		
        public const string PARAM_CATEGORYID = "@CategoryID";	
        public const string PARAM_CATEGORYNAME = "@CategoryName";	
        public const string PARAM_DESCRIPTION = "@Description";	
        public const string PARAM_PICTURE = "@Picture";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_CATEGORIES = "INSERT INTO dbo.Categories( [CategoryName], [Description], [Picture]) VALUES ( @CategoryName, @Description, @Picture);"   + "SELECT SCOPE_IDENTITY();" ;
		
		private const string SQL_UPDATE_CATEGORIES = "UPDATE dbo.Categories SET  [CategoryName] = @CategoryName, [Description] = @Description, [Picture] = @Picture WHERE [CategoryID] = @CategoryID";
		
		private const string SQL_DELETE_CATEGORIES = "DELETE FROM dbo.Categories WHERE  [CategoryID] = @CategoryID ";
		
        #endregion
        	  	
        #region Declarations
        
		protected int categoryid = default(int);
	
		protected string categoryname = default(string);
	
		protected string description = default(string);
	
		protected byte[] picture = default(byte[]);
	
        protected EntityCollection< Product> products ;
        
        #endregion

 		#region Properties	

        [Column( COL_CATEGORYID, PARAM_CATEGORYID, default(int))]
                              public virtual int CategoryID 
        {
            get { return this.categoryid; }
			set	{ 
                  if(this.categoryid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CategoryID"));  
                        this.categoryid = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CategoryID"));
                    }   
                }
        }	
		
        [Column( COL_CATEGORYNAME, PARAM_CATEGORYNAME )]
                              public virtual string CategoryName 
        {
            get { return this.categoryname; }
			set	{ 
                  if(this.categoryname != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("CategoryName"));  
                        this.categoryname = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("CategoryName"));
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
		
        [Column( COL_PICTURE, PARAM_PICTURE )]
                              public virtual byte[] Picture 
        {
            get { return this.picture; }
			set	{ 
                  if(this.picture != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Picture"));  
                        this.picture = value;                        
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Picture"));
                    }   
                }
        }	
		
        public EntityCollection< Product> Products 
        {
            get { return this.products;}
        }
        
        
        #endregion        
        
        #region Methods     
		
       public Category()
        {
             this.products = new EntityCollection< Product>(this, new Associate< Product>(this.AssociateProducts), new DeAssociate< Product>(this.DeAssociateProducts), new GetChildren< Product>(this.GetChildrenProducts));
        }
        
        public override bool Equals(object obj)
        {
            Category entity = obj as Category;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.CategoryID == entity.CategoryID
                        && this.CategoryID != default(int)
                        )
                    );           
        }
        
        public override int GetHashCode()
        {
            
            int hashCode = 7;
            
            hashCode = (11 * hashCode) + this.categoryid.GetHashCode();
                        
            return hashCode;          
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.categoryid = (int)reader[COL_CATEGORYID];
			this.categoryname = (string)reader[COL_CATEGORYNAME];
			this.description = DbConvert.ToString(reader[COL_DESCRIPTION]);
			this.picture = (byte[])reader[COL_PICTURE];
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_CATEGORIES))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.CategoryName, PARAM_CATEGORYNAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Description), PARAM_DESCRIPTION));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Picture), PARAM_PICTURE));
                this.CategoryID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_CATEGORIES))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CategoryID, PARAM_CATEGORYID));
				command.Parameters.Add(dataContext.CreateParameter(this.CategoryName, PARAM_CATEGORYNAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Description), PARAM_DESCRIPTION));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Picture), PARAM_PICTURE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_CATEGORIES))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CategoryID, PARAM_CATEGORYID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateProducts(Product product)
        {
           product.CategoryRef = this;
        }
        
        private void DeAssociateProducts(Product product)
        {
          if(product.CategoryRef == this)
             product.CategoryRef = null;
        }
        
            
        private Product[] GetChildrenProducts()
        {
            if (this.categoryid != default(int))
            {  
                Product childrenQuery = new Product();
                childrenQuery.CategoryRef = this;
                
                return childrenQuery.ToList(); 
            } else return null;
        }
        
        #endregion
    }
}
