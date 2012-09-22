/*
 * Author: CrystalMapper 
 * 
 * Date:  Saturday, September 22, 2012 8:41 PM
 * 
 * Class: EmployeeTerritory
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

namespace CrystalMapper.Test.Northwind
{
	[Table(TABLE_NAME)]
    public partial class EmployeeTerritory : Entity< EmployeeTerritory>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "dbo.EmployeeTerritories";	
     
		public const string COL_EMPLOYEEID = "EmployeeID";
		public const string COL_TERRITORYID = "TerritoryID";
		
        public const string PARAM_EMPLOYEEID = "@EmployeeID";	
        public const string PARAM_TERRITORYID = "@TerritoryID";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_EMPLOYEETERRITORIES = "INSERT INTO dbo.EmployeeTerritories ( [EmployeeID], [TerritoryID]) VALUES ( @EmployeeID, @TerritoryID);"  ;
		
		private const string SQL_UPDATE_EMPLOYEETERRITORIES = "UPDATE dbo.EmployeeTerritories SET WHERE [EmployeeID] = @EmployeeID AND [TerritoryID] = @TerritoryID";
		
		private const string SQL_DELETE_EMPLOYEETERRITORIES = "DELETE FROM dbo.EmployeeTerritories WHERE  [EmployeeID] = @EmployeeID AND [TerritoryID] = @TerritoryID ";
		
        #endregion
        	  	
        #region Declarations
        
		protected int employeeid = default(int);
	
		protected string territoryid = default(string);
	
		protected Employee employeeRef;
	
		protected Territory territoryRef;
	
        #endregion

 		#region Properties	

        [Column( COL_EMPLOYEEID, PARAM_EMPLOYEEID, default(int))]
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
                    this.OnPropertyChanging(new PropertyChangingEventArgs("EmployeeID"));                    
                    this.employeeid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("EmployeeID"));
                    
                    this.employeeRef = null;
                }                
            }          
        }	
        
        [Column( COL_TERRITORYID, PARAM_TERRITORYID )]
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
                    this.OnPropertyChanging(new PropertyChangingEventArgs("TerritoryID"));                    
                    this.territoryid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("TerritoryID"));
                    
                    this.territoryRef = null;
                }                
            }          
        }	
        
        public Employee EmployeeRef
        {
            get { 
                    if(this.employeeRef == null
                       && this.employeeid != default(int)) 
                    {
                        Employee employeeQuery = new Employee {
                                                        EmployeeID = this.employeeid  
                                                        };
                        
                        Employee[]  employees = employeeQuery.ToList();                        
                        if(employees.Length == 1)
                            this.employeeRef = employees[0];                        
                    }
                    
                    return this.employeeRef; 
                }
			set	{ 
                  if(this.employeeRef != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("EmployeeRef"));
                        if (this.employeeRef != null)
                            this.Parents.Remove(this.employeeRef);                            
                        
                        if((this.employeeRef = value) != null) 
                        {
                            this.Parents.Add(this.employeeRef); 
                            this.employeeid = this.employeeRef.EmployeeID;
                        }
                        else
                        {
		                    this.employeeid = default(int);
                        }
                        this.OnPropertyChanged(new PropertyChangedEventArgs("EmployeeRef"));
                    }   
                }
        }	
		
        public Territory TerritoryRef
        {
            get { 
                    if(this.territoryRef == null
                       && this.territoryid != default(string)) 
                    {
                        Territory territoryQuery = new Territory {
                                                        TerritoryID = this.territoryid  
                                                        };
                        
                        Territory[]  territories = territoryQuery.ToList();                        
                        if(territories.Length == 1)
                            this.territoryRef = territories[0];                        
                    }
                    
                    return this.territoryRef; 
                }
			set	{ 
                  if(this.territoryRef != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("TerritoryRef"));
                        if (this.territoryRef != null)
                            this.Parents.Remove(this.territoryRef);                            
                        
                        if((this.territoryRef = value) != null) 
                        {
                            this.Parents.Add(this.territoryRef); 
                            this.territoryid = this.territoryRef.TerritoryID;
                        }
                        else
                        {
		                    this.territoryid = default(string);
                        }
                        this.OnPropertyChanged(new PropertyChangedEventArgs("TerritoryRef"));
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
        
        public override bool Equals(object obj)
        {
            EmployeeTerritory entity = obj as EmployeeTerritory;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.EmployeeID == entity.EmployeeID
                        && this.TerritoryID == entity.TerritoryID
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
        
		public override void Read(DbDataReader reader)
		{       
			this.employeeid = (int)reader[COL_EMPLOYEEID];
			this.territoryid = (string)reader[COL_TERRITORYID];
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_EMPLOYEETERRITORIES))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.EmployeeID, PARAM_EMPLOYEEID));
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_EMPLOYEETERRITORIES))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.EmployeeID, PARAM_EMPLOYEEID));
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_EMPLOYEETERRITORIES))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.EmployeeID, PARAM_EMPLOYEEID));				
				command.Parameters.Add(dataContext.CreateParameter(this.TerritoryID, PARAM_TERRITORYID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
    }
}
