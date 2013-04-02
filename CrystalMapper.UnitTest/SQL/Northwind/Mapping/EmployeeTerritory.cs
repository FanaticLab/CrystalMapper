/*********************************************************************
 * Author: CrystalMapper (Generated)
 * Date:  Monday, April 01, 2013 7:10 PM
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

namespace CrystalMapper.UnitTest.SQL.Northwind
{
	[Table(TABLE_NAME)]
    public partial class EmployeeTerritory : IRecord, INotifyPropertyChanging, INotifyPropertyChanged
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "dbo.EmployeeTerritories";	
     
		public const string COL_EMPLOYEEID = "EmployeeID";
		public const string COL_TERRITORYID = "TerritoryID";
		
        public const string PARAM_EMPLOYEEID = "@EmployeeID";	
        public const string PARAM_TERRITORYID = "@TerritoryID";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_EMPLOYEETERRITORIES = "INSERT INTO dbo.EmployeeTerritories (EmployeeID, TerritoryID) VALUES ( @EmployeeID, @TerritoryID);"  ;
		
		private const string SQL_UPDATE_EMPLOYEETERRITORIES = "UPDATE dbo.EmployeeTerritories SET WHERE EmployeeID = @EmployeeID AND TerritoryID = @TerritoryID";
		
		private const string SQL_DELETE_EMPLOYEETERRITORIES = "DELETE FROM dbo.EmployeeTerritories WHERE  EmployeeID = @EmployeeID AND TerritoryID = @TerritoryID ";
		
        #endregion
        	  	
        #region Declarations

		protected int employeeid = default(int);
	
		protected string territoryid = default(string);
	
		protected Employee employeeRef;
	
		protected Territory territoryRef;
	
        
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

        [Column(COL_EMPLOYEEID, PARAM_EMPLOYEEID, default(int))]
        public virtual int EmployeeID                
        {
            get
            {
                if(this.employeeRef == null)
                    return this.employeeid ;
                
                return this.employeeRef.EmployeeID;            
            }
            set
            {
                if(this.employeeid != value)
                {
                    this.OnPropertyChanging("EmployeeID");                    
                    this.employeeid = value;                    
                    this.OnPropertyChanged("EmployeeID");
                    
                    this.employeeRef = null;
                }                
            }          
        }	
        
        [Column(COL_TERRITORYID, PARAM_TERRITORYID )]
        public virtual string TerritoryID                
        {
            get
            {
                if(this.territoryRef == null)
                    return this.territoryid ;
                
                return this.territoryRef.TerritoryID;            
            }
            set
            {
                if(this.territoryid != value)
                {
                    this.OnPropertyChanging("TerritoryID");                    
                    this.territoryid = value;                    
                    this.OnPropertyChanged("TerritoryID");
                    
                    this.territoryRef = null;
                }                
            }          
        }	
        
        public Employee EmployeeRef
        {
            get 
            { 
                if(this.employeeRef == null)
                    this.employeeRef = this.CreateQuery<Employee>().First(p => p.EmployeeID == this.EmployeeID);                    
                
                return this.employeeRef; 
            }
			set	
            { 
                if(this.employeeRef != value)
                {
                    this.OnPropertyChanging("EmployeeRef");
                    
                    this.employeeid = (this.employeeRef = value) != null ? this.employeeRef.EmployeeID : default(int);                  
                    
                    this.OnPropertyChanged("EmployeeRef");
                }   
            }
        }	
		
        public Territory TerritoryRef
        {
            get 
            { 
                if(this.territoryRef == null)
                    this.territoryRef = this.CreateQuery<Territory>().First(p => p.TerritoryID == this.TerritoryID);                    
                
                return this.territoryRef; 
            }
			set	
            { 
                if(this.territoryRef != value)
                {
                    this.OnPropertyChanging("TerritoryRef");
                    
                    this.territoryid = (this.territoryRef = value) != null ? this.territoryRef.TerritoryID : default(string);                  
                    
                    this.OnPropertyChanged("TerritoryRef");
                }   
            }
        }	
		
        #endregion        
        
        #region Methods
        
        public override bool Equals(object obj)
        {
            EmployeeTerritory record = obj as EmployeeTerritory;           
            
            return (object.ReferenceEquals(this, record)                    
                    || (record != null            
                        && this.EmployeeID == record.EmployeeID
                        && this.TerritoryID == record.TerritoryID
                        && this.EmployeeID != default(int)
                                                && this.TerritoryID != default(string)
                        )
                    );           
        }
        
        public override int GetHashCode()
        {            
            int hashCode = 7;
            
            hashCode = (11 * hashCode) + this.employeeid.GetHashCode();
            hashCode = (11 * hashCode) + this.territoryid.GetHashCode();
                        
            return hashCode;          
        }
        
		void IRecord.Read(DbDataReader reader)
		{       
			this.employeeid = (int)reader[COL_EMPLOYEEID];
			this.territoryid = (string)reader[COL_TERRITORYID];
		}
		
		bool IRecord.Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_EMPLOYEETERRITORIES))
            {	
				command.Parameters.Add(dataContext.CreateParameter(PARAM_EMPLOYEEID, this.EmployeeID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_TERRITORYID, this.TerritoryID));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		bool IRecord.Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_EMPLOYEETERRITORIES))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_EMPLOYEEID, this.EmployeeID));
				command.Parameters.Add(dataContext.CreateParameter(PARAM_TERRITORYID, this.TerritoryID));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		bool IRecord.Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_EMPLOYEETERRITORIES))
            {							
				command.Parameters.Add(dataContext.CreateParameter(PARAM_EMPLOYEEID, this.EmployeeID));
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