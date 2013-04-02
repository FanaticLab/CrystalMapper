/*********************************************************************
 * Author: CrystalMapper (Generated)
 * Date:  Monday, April 01, 2013 8:25 PM
 * Project: http://www.fanaticlab.com/projects/crystalmapper/
 * Copyright (c) 2013 FanaticLab
 *********************************************************************/

using System;
using System.Linq;
using System.Data.Common;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;

using CoreSystem.Data;

using CrystalMapper;
using CrystalMapper.Linq;
using CrystalMapper.Context;
using CrystalMapper.Mapping;

namespace CrystalMapper.UnitTest.MySQL.Northwind
{
	[Table(TABLE_NAME)]
    public partial class Category : IRecord, INotifyPropertyChanging, INotifyPropertyChanged
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "categories";	
     
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
		
		private const string SQL_INSERT_CATEGORIES = "INSERT INTO categories (CategoryName, Description, Picture) VALUES ( @CategoryName, @Description, @Picture);"   + " SELECT LAST_INSERT_ID();" ;
		
		private const string SQL_UPDATE_CATEGORIES = "UPDATE categories SETCategoryName = @CategoryName, Description = @Description, Picture = @Picture WHERE CategoryID = @CategoryID";
		
		private const string SQL_DELETE_CATEGORIES = "DELETE FROM categories WHERE  CategoryID = @CategoryID ";
		
        #endregion
        	  	
        #region Declarations

		protected int categoryid = default(int);
	
		protected string categoryname = default(string);
	
		protected string description = default(string);
	
		protected byte[] picture = default(byte[]);
	
        
        private event PropertyChangingEventHandler propertyChanging;
        
        private event PropertyChangedEventHandler propertyChanged;
        #endregion

 		#region Properties
        
        event PropertyChangingEventHandler INotifyPropertyChanging.PropertyChanging
        {
            add { this.propertyChanging += value; }
            remove { this.propertyChanging -= value; }
        }
        
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        { 
            add { this.propertyChanged += value; }
            remove { this.propertyChanged -= value; }
        }
        
        IQueryProvider IRecord.Provider { get; set; }

        [Column(COL_CATEGORYID, PARAM_CATEGORYID, default(int))]
        public virtual int CategoryID 
        {
            get { return this.categoryid; }
			set	{ 
                  if(this.categoryid != value)
                    {
                        this.OnPropertyChanging("CategoryID");  
                        this.categoryid = value;                        
                        this.OnPropertyChanged("CategoryID");
                    }   
                }
        }	
		
        [Column(COL_CATEGORYNAME, PARAM_CATEGORYNAME )]
        public virtual string CategoryName 
        {
            get { return this.categoryname; }
			set	{ 
                  if(this.categoryname != value)
                    {
                        this.OnPropertyChanging("CategoryName");  
                        this.categoryname = value;                        
                        this.OnPropertyChanged("CategoryName");
                    }   
                }
        }	
		
        [Column(COL_DESCRIPTION, PARAM_DESCRIPTION )]
        public virtual string Description 
        {
            get { return this.description; }
			set	{ 
                  if(this.description != value)
                    {
                        this.OnPropertyChanging("Description");  
                        this.description = value;                        
                        this.OnPropertyChanged("Description");
                    }   
                }
        }	
		
        [Column(COL_PICTURE, PARAM_PICTURE )]
        public virtual byte[] Picture 
        {
            get { return this.picture; }
			set	{ 
                  if(this.picture != value)
                    {
                        this.OnPropertyChanging("Picture");  
                        this.picture = value;                        
                        this.OnPropertyChanged("Picture");
                    }   
                }
        }	
		
        public IQueryable<Product> Products 
        { 
            get { return this.CreateQuery<Product>().Where(r => r.CategoryID == CategoryID); }
        }
        
        #endregion        
        
        #region Methods
        
        public override bool Equals(object obj)
        {
            Category record = obj as Category;           
            
            return (object.ReferenceEquals(this, record)                    
                    || (record != null            
                        && this.CategoryID == record.CategoryID
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
        
		void IRecord.Read(DbDataReader reader)
		{       
			this.categoryid = (int)reader[COL_CATEGORYID];
			this.categoryname = (string)reader[COL_CATEGORYNAME];
			this.description = DbConvert.ToString(reader[COL_DESCRIPTION]);
			this.picture = (byte[])reader[COL_PICTURE];
		}
		
		bool IRecord.Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_CATEGORIES))
            {	
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CATEGORYNAME, this.CategoryName));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_DESCRIPTION, DbConvert.DbValue(this.Description)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_PICTURE, DbConvert.DbValue(this.Picture)));
                this.CategoryID = Convert.ToInt32(command.ExecuteScalar());
                return true;
            }
        }

		bool IRecord.Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_CATEGORIES))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CATEGORYID, this.CategoryID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CATEGORYNAME, this.CategoryName));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_DESCRIPTION, DbConvert.DbValue(this.Description)));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_PICTURE, DbConvert.DbValue(this.Picture)));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		bool IRecord.Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_CATEGORIES))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_CATEGORYID, this.CategoryID));
                return (command.ExecuteNonQuery() == 1);
            }
        }
        
        protected virtual void OnPropertyChanging(string propertyName)
        {
            if(this.propertyChanging != null)
                this.propertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if(this.propertyChanged != null)
                this.propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}