/*
 * Author: CrystalMapper (Generated)
 * 
 * Date:  Thursday, March 28, 2013 7:07 PM
 * 
 * Class: Region
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

namespace CrystalMapper.Test.Northwind
{
	[Table(TABLE_NAME)]
    public partial class Region : IRecord 
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "dbo.Region";	
     
		public const string COL_REGIONID = "RegionID";
		public const string COL_REGIONDESCRIPTION = "RegionDescription";
		
        public const string PARAM_REGIONID = "@RegionID";	
        public const string PARAM_REGIONDESCRIPTION = "@RegionDescription";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_REGION = "INSERT INTO dbo.Region ( [RegionID], [RegionDescription]) VALUES ( @RegionID, @RegionDescription);"  ;
		
		private const string SQL_UPDATE_REGION = "UPDATE dbo.Region SET [RegionDescription] = @RegionDescription WHERE [RegionID] = @RegionID";
		
		private const string SQL_DELETE_REGION = "DELETE FROM dbo.Region WHERE  [RegionID] = @RegionID ";
		
        #endregion
        	  	
        #region Declarations
        
		protected int regionid = default(int);
	
		protected string regiondescription = default(string);
	
        #endregion

 		#region Properties	
        
        public event PropertyChangedEventHandler PropertyChanged;

        public event PropertyChangingEventHandler PropertyChanging;

        [Column(COL_REGIONID, PARAM_REGIONID, default(int))]
        public virtual int RegionID 
        {
            get { return this.regionid; }
			set	{ 
                  if(this.regionid != value)
                    {
                        this.OnPropertyChanging("RegionID");  
                        this.regionid = value;                        
                        this.OnPropertyChanged("RegionID");
                    }   
                }
        }	
		
        [Column(COL_REGIONDESCRIPTION, PARAM_REGIONDESCRIPTION )]
        public virtual string RegionDescription 
        {
            get { return this.regiondescription; }
			set	{ 
                  if(this.regiondescription != value)
                    {
                        this.OnPropertyChanging("RegionDescription");  
                        this.regiondescription = value;                        
                        this.OnPropertyChanged("RegionDescription");
                    }   
                }
        }	
		
        #endregion        
        
        #region Methods     
        
        public override bool Equals(object obj)
        {
            Region record = obj as Region;           
            
            return (object.ReferenceEquals(this, record)                    
                    || (record != null            
                        && this.RegionID == record.RegionID
                        && this.RegionID != default(int)
                        )
                    );           
        }
        
        public override int GetHashCode()
        {            
            int hashCode = 7;
            
            hashCode = (11 * hashCode) + this.regionid.GetHashCode();
                        
            return hashCode;          
        }
        
		void IRecord.Read(DbDataReader reader)
		{       
			this.regionid = (int)reader[COL_REGIONID];
			this.regiondescription = (string)reader[COL_REGIONDESCRIPTION];
		}
		
		bool IRecord.Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_REGION))
            {	
				command.Parameters.Add(dataContext.CreateParameter(PARAM_REGIONID, this.RegionID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_REGIONDESCRIPTION, this.RegionDescription));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		bool IRecord.Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_REGION))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_REGIONID, this.RegionID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_REGIONDESCRIPTION, this.RegionDescription));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		bool IRecord.Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_REGION))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_REGIONID, this.RegionID));
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