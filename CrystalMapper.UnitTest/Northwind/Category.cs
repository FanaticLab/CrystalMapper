/*
 * Author: CrystalMapper (Generated)
 * 
 * Date:  Thursday, March 28, 2013 7:47 PM
 * 
 * Class: Category
 * 
 * Email: info@fanaticlab.com
 * 
 * Project: http://crystalmapper.codeplex.com
 *
 * Copyright (c) 2013 FanaticLab
 *
/*/

using System;
using System.Data.Common;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;

using CoreSystem.Data;

using CrystalMapper;
using CrystalMapper.Context;
using CrystalMapper.Mapping;

namespace CrystalMapper.UnitTest.Northwind
{
	[Table(TABLE_NAME)]
    public partial class Category : IRecord 
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
		
		private const string SQL_INSERT_CATEGORIES = "INSERT INTO dbo.Categories ( [CategoryName], [Description], [Picture]) VALUES ( @CategoryName, @Description, @Picture);"   + " SELECT SCOPE_IDENTITY();" ;
		
		private const string SQL_UPDATE_CATEGORIES = "UPDATE dbo.Categories SET [CategoryName] = @CategoryName, [Description] = @Description, [Picture] = @Picture WHERE [CategoryID] = @CategoryID";
		
		private const string SQL_DELETE_CATEGORIES = "DELETE FROM dbo.Categories WHERE  [CategoryID] = @CategoryID ";
		
        #endregion
        	  	
        #region Declarations
        
		protected int categoryid = default(int);
	
		protected string categoryname = default(string);
	
		protected string description = default(string);
	
		protected byte[] picture = default(byte[]);
	
        #endregion

 		#region Properties	
        
        public event PropertyChangedEventHandler PropertyChanged;

        public event PropertyChangingEventHandler PropertyChanging;

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
            if(this.PropertyChanging != null)
                this.PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if(this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}