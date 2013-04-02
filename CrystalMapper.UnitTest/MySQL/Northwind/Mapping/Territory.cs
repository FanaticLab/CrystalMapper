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
    public partial class Territory : IRecord, INotifyPropertyChanging, INotifyPropertyChanged
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "territories";	
     
		public const string COL_TERRITORYID = "TerritoryID";
		public const string COL_TERRITORYDESCRIPTION = "TerritoryDescription";
		public const string COL_REGIONID = "RegionID";
		
        public const string PARAM_TERRITORYID = "@TerritoryID";	
        public const string PARAM_TERRITORYDESCRIPTION = "@TerritoryDescription";	
        public const string PARAM_REGIONID = "@RegionID";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_TERRITORIES = "INSERT INTO territories (TerritoryID, TerritoryDescription, RegionID) VALUES ( @TerritoryID, @TerritoryDescription, @RegionID);"  ;
		
		private const string SQL_UPDATE_TERRITORIES = "UPDATE territories SETTerritoryDescription = @TerritoryDescription, RegionID = @RegionID WHERE TerritoryID = @TerritoryID";
		
		private const string SQL_DELETE_TERRITORIES = "DELETE FROM territories WHERE  TerritoryID = @TerritoryID ";
		
        #endregion
        	  	
        #region Declarations

		protected string territoryid = default(string);
	
		protected string territorydescription = default(string);
	
		protected int regionid = default(int);
	
		protected Region regionRef;
	
        
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
            get 
            { 
                if(this.regionRef == null)
                    this.regionRef = this.CreateQuery<Region>().First(p => p.RegionID == this.RegionID);                    
                
                return this.regionRef; 
            }
			set	
            { 
                if(this.regionRef != value)
                {
                    this.OnPropertyChanging("RegionRef");
                    
                    this.regionid = (this.regionRef = value) != null ? this.regionRef.RegionID : default(int);                  
                    
                    this.OnPropertyChanged("RegionRef");
                }   
            }
        }	
		
        public IQueryable<EmployeeTerritory> EmployeeTerritories 
        { 
            get { return this.CreateQuery<EmployeeTerritory>().Where(r => r.TerritoryID == TerritoryID); }
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