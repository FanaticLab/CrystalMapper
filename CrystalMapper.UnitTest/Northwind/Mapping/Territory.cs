/*
 * Author: CrystalMapper (Generated)
 * 
 * Date:  Friday, March 29, 2013 9:13 PM
 * 
 * Class: Territory
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
    public partial class Territory : IRecord, INotifyPropertyChanging, INotifyPropertyChanged
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "dbo.Territories";	
     
		public const string COL_TERRITORYID = "TerritoryID";
		public const string COL_TERRITORYDESCRIPTION = "TerritoryDescription";
		public const string COL_REGIONID = "RegionID";
		
        public const string PARAM_TERRITORYID = "@TerritoryID";	
        public const string PARAM_TERRITORYDESCRIPTION = "@TerritoryDescription";	
        public const string PARAM_REGIONID = "@RegionID";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_TERRITORIES = "INSERT INTO dbo.Territories ( [TerritoryID], [TerritoryDescription], [RegionID]) VALUES ( @TerritoryID, @TerritoryDescription, @RegionID);"  ;
		
		private const string SQL_UPDATE_TERRITORIES = "UPDATE dbo.Territories SET [TerritoryDescription] = @TerritoryDescription, [RegionID] = @RegionID WHERE [TerritoryID] = @TerritoryID";
		
		private const string SQL_DELETE_TERRITORIES = "DELETE FROM dbo.Territories WHERE  [TerritoryID] = @TerritoryID ";
		
        #endregion
        	  	
        #region Declarations
        
		protected string territoryid = default(string);
	
		protected string territorydescription = default(string);
	
		protected int regionid = default(int);
	
		protected Region regionRef;
	
        #endregion

 		#region Properties	
        
        public event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged;

        public event PropertyChangingEventHandler INotifyPropertyChanging.PropertyChanging;
        
        public IQueryProvider IRecord.Provider { get; set; }

        [Column(COL_TERRITORYID, PARAM_TERRITORYID )]
        public virtual string TerritoryID 
        {
            get { return this.territoryid; }
			set	{ 
                  if(this.territoryid != value)
                    {
                        this.OnPropertyChanging("TerritoryID");  
                        this.territoryid = value;                        
                        this.OnPropertyChanged("TerritoryID");
                    }   
                }
        }	
		
        [Column(COL_TERRITORYDESCRIPTION, PARAM_TERRITORYDESCRIPTION )]
        public virtual string TerritoryDescription 
        {
            get { return this.territorydescription; }
			set	{ 
                  if(this.territorydescription != value)
                    {
                        this.OnPropertyChanging("TerritoryDescription");  
                        this.territorydescription = value;                        
                        this.OnPropertyChanged("TerritoryDescription");
                    }   
                }
        }	
		
        [Column(COL_REGIONID, PARAM_REGIONID, default(int))]
        public virtual int RegionID                
        {
            get
            {
                if(this.regionRef == null)
                    return this.regionid ;
                
                return this.regionRef.RegionID;            
            }
            set
            {
                if(this.regionid != value)
                {
                    this.OnPropertyChanging("RegionID");                    
                    this.regionid = value;                    
                    this.OnPropertyChanged("RegionID");
                    
                    this.regionRef = null;
                }                
            }          
        }	
        
        public Region RegionRef
        {
            get { return this.regionRef; }
			set	
            { 
                if(this.regionRef != value)
                {
                    this.OnPropertyChanging("RegionRef");
                    
                    if((this.regionRef = value) != null) 
                    {
                        this.regionid = this.regionRef.RegionID;
                    }
                    else
                    {
		                this.regionid = default(int);
                    }
                    
                    this.OnPropertyChanged("RegionRef");
                }   
             }
        }	
		
        #endregion        
        
        #region Methods     
        
        public override bool Equals(object obj)
        {
            Territory record = obj as Territory;           
            
            return (object.ReferenceEquals(this, record)                    
                    || (record != null            
                        && this.TerritoryID == record.TerritoryID
                        && this.TerritoryID != default(string)
                        )
                    );           
        }
        
        public override int GetHashCode()
        {            
            int hashCode = 7;
            
            hashCode = (11 * hashCode) + this.territoryid.GetHashCode();
                        
            return hashCode;          
        }
        
		void IRecord.Read(DbDataReader reader)
		{       
			this.territoryid = (string)reader[COL_TERRITORYID];
			this.territorydescription = (string)reader[COL_TERRITORYDESCRIPTION];
			this.regionid = (int)reader[COL_REGIONID];
		}
		
		bool IRecord.Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_TERRITORIES))
            {	
				command.Parameters.Add(dataContext.CreateParameter(PARAM_TERRITORYID, this.TerritoryID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_TERRITORYDESCRIPTION, this.TerritoryDescription));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_REGIONID, this.RegionID));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		bool IRecord.Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_TERRITORIES))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_TERRITORYID, this.TerritoryID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_TERRITORYDESCRIPTION, this.TerritoryDescription));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_REGIONID, this.RegionID));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		bool IRecord.Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_TERRITORIES))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_TERRITORYID, this.TerritoryID));
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