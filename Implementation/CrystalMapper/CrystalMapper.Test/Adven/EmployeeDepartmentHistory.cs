/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: EmployeeDepartmentHistory
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
    public partial class EmployeeDepartmentHistory : Entity< EmployeeDepartmentHistory>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "HumanResources.EmployeeDepartmentHistory";	
     
		public const string COL_BUSINESSENTITYID = "BusinessEntityID";
		public const string COL_DEPARTMENTID = "DepartmentID";
		public const string COL_SHIFTID = "ShiftID";
		public const string COL_STARTDATE = "StartDate";
		public const string COL_ENDDATE = "EndDate";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_BUSINESSENTITYID = "@BusinessEntityID";	
        public const string PARAM_DEPARTMENTID = "@DepartmentID";	
        public const string PARAM_SHIFTID = "@ShiftID";	
        public const string PARAM_STARTDATE = "@StartDate";	
        public const string PARAM_ENDDATE = "@EndDate";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_EMPLOYEEDEPARTMENTHISTORY = "INSERT INTO HumanResources.EmployeeDepartmentHistory([BusinessEntityID],[DepartmentID],[ShiftID],[StartDate],[EndDate],[ModifiedDate]) VALUES (@BusinessEntityID,@DepartmentID,@ShiftID,@StartDate,@EndDate,@ModifiedDate);"  ;
		
		private const string SQL_UPDATE_EMPLOYEEDEPARTMENTHISTORY = "UPDATE HumanResources.EmployeeDepartmentHistory SET  [EndDate] = @EndDate, [ModifiedDate] = @ModifiedDate WHERE [BusinessEntityID] = @BusinessEntityID AND [StartDate] = @StartDate AND [DepartmentID] = @DepartmentID AND [ShiftID] = @ShiftID";
		
		private const string SQL_DELETE_EMPLOYEEDEPARTMENTHISTORY = "DELETE FROM HumanResources.EmployeeDepartmentHistory WHERE  [BusinessEntityID] = @BusinessEntityID AND [StartDate] = @StartDate AND [DepartmentID] = @DepartmentID AND [ShiftID] = @ShiftID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int businessentityid = default(int);
	
		protected short departmentid = default(short);
	
		protected byte shiftid = default(byte);
	
		protected System.DateTime startdate = default(System.DateTime);
	
		protected System.DateTime? enddate = default(System.DateTime?);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected Department departmentEntity;
	
		protected Employee employeeEntity;
	
		protected Shift shiftEntity;
	
        #endregion

 		#region Properties	

        [Column( COL_STARTDATE, PARAM_STARTDATE, typeof(System.DateTime))]
                              public virtual System.DateTime StartDate 
        {
            get { return this.startdate; }
			set	{ 
                  if(this.startdate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("StartDate"));  
                        this.startdate = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("StartDate"));
                    }   
                }
        }	
		
        [Column( COL_ENDDATE, PARAM_ENDDATE )]
                              public virtual System.DateTime? EndDate 
        {
            get { return this.enddate; }
			set	{ 
                  if(this.enddate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("EndDate"));  
                        this.enddate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("EndDate"));
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
		
        [Column( COL_DEPARTMENTID, PARAM_DEPARTMENTID, default(short))]
                              public virtual short DepartmentID                
        {
            get
            {
                if(this.departmentEntity == null)
                    return this.departmentid ;
                
                return this.departmentEntity.DepartmentID;            
            }
            set
            {
                if(this.departmentid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("DepartmentID"));                    
                    this.departmentid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("DepartmentID"));
                    
                    this.departmentEntity = null;
                }                
            }          
        }	
        
        [Column( COL_BUSINESSENTITYID, PARAM_BUSINESSENTITYID, default(int))]
                              public virtual int BusinessEntityID                
        {
            get
            {
                if(this.employeeEntity == null)
                    return this.businessentityid ;
                
                return this.employeeEntity.BusinessEntityID;            
            }
            set
            {
                if(this.businessentityid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("BusinessEntityID"));                    
                    this.businessentityid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("BusinessEntityID"));
                    
                    this.employeeEntity = null;
                }                
            }          
        }	
        
        [Column( COL_SHIFTID, PARAM_SHIFTID, default(byte))]
                              public virtual byte ShiftID                
        {
            get
            {
                if(this.shiftEntity == null)
                    return this.shiftid ;
                
                return this.shiftEntity.ShiftID;            
            }
            set
            {
                if(this.shiftid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ShiftID"));                    
                    this.shiftid = value;                    
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ShiftID"));
                    
                    this.shiftEntity = null;
                }                
            }          
        }	
        
        public Department DepartmentEntity
        {
            get { 
                    if(this.departmentEntity == null
                       && this.departmentid != default(short)) 
                    {
                        Department departmentQuery = new Department {
                                                        DepartmentID = this.departmentid  
                                                        };
                        
                        Department[]  departments = departmentQuery.ToList();                        
                        if(departments.Length == 1)
                            this.departmentEntity = departments[0];                        
                    }
                    
                    return this.departmentEntity; 
                }
			set	{ 
                  if(this.departmentEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("DepartmentEntity"));
                        if (this.departmentEntity != null)
                            this.Parents.Remove(this.departmentEntity);                            
                        
                        if((this.departmentEntity = value) != null) 
                            this.Parents.Add(this.departmentEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("DepartmentEntity"));
                        
                        this.departmentid = this.DepartmentEntity.DepartmentID;
                    }   
                }
        }	
		
        public Employee EmployeeEntity
        {
            get { 
                    if(this.employeeEntity == null
                       && this.businessentityid != default(int)) 
                    {
                        Employee employeeQuery = new Employee {
                                                        BusinessEntityID = this.businessentityid  
                                                        };
                        
                        Employee[]  employees = employeeQuery.ToList();                        
                        if(employees.Length == 1)
                            this.employeeEntity = employees[0];                        
                    }
                    
                    return this.employeeEntity; 
                }
			set	{ 
                  if(this.employeeEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("EmployeeEntity"));
                        if (this.employeeEntity != null)
                            this.Parents.Remove(this.employeeEntity);                            
                        
                        if((this.employeeEntity = value) != null) 
                            this.Parents.Add(this.employeeEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("EmployeeEntity"));
                        
                        this.businessentityid = this.EmployeeEntity.BusinessEntityID;
                    }   
                }
        }	
		
        public Shift ShiftEntity
        {
            get { 
                    if(this.shiftEntity == null
                       && this.shiftid != default(byte)) 
                    {
                        Shift shiftQuery = new Shift {
                                                        ShiftID = this.shiftid  
                                                        };
                        
                        Shift[]  shifts = shiftQuery.ToList();                        
                        if(shifts.Length == 1)
                            this.shiftEntity = shifts[0];                        
                    }
                    
                    return this.shiftEntity; 
                }
			set	{ 
                  if(this.shiftEntity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ShiftEntity"));
                        if (this.shiftEntity != null)
                            this.Parents.Remove(this.shiftEntity);                            
                        
                        if((this.shiftEntity = value) != null) 
                            this.Parents.Add(this.shiftEntity); 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ShiftEntity"));
                        
                        this.shiftid = this.ShiftEntity.ShiftID;
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
		
        public EmployeeDepartmentHistory()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.businessentityid.GetHashCode();
                result = (11 * result) + this.startdate.GetHashCode();
                result = (11 * result) + this.departmentid.GetHashCode();
                result = (11 * result) + this.shiftid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            EmployeeDepartmentHistory entity = obj as EmployeeDepartmentHistory;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.BusinessEntityID == entity.BusinessEntityID
                        && this.StartDate == entity.StartDate
                        && this.DepartmentID == entity.DepartmentID
                        && this.ShiftID == entity.ShiftID
                        && this.BusinessEntityID != default(int)
                        && this.StartDate != default(System.DateTime)
                        && this.DepartmentID != default(short)
                        && this.ShiftID != default(byte)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.businessentityid = (int)reader[COL_BUSINESSENTITYID];
			this.departmentid = (short)reader[COL_DEPARTMENTID];
			this.shiftid = (byte)reader[COL_SHIFTID];
			this.startdate = (System.DateTime)reader[COL_STARTDATE];
			this.enddate = DbConvert.ToNullable< System.DateTime >(reader[COL_ENDDATE]);
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_EMPLOYEEDEPARTMENTHISTORY))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));
				command.Parameters.Add(dataContext.CreateParameter(this.DepartmentID, PARAM_DEPARTMENTID));
				command.Parameters.Add(dataContext.CreateParameter(this.ShiftID, PARAM_SHIFTID));
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EndDate), PARAM_ENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_EMPLOYEEDEPARTMENTHISTORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));
				command.Parameters.Add(dataContext.CreateParameter(this.DepartmentID, PARAM_DEPARTMENTID));
				command.Parameters.Add(dataContext.CreateParameter(this.ShiftID, PARAM_SHIFTID));
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EndDate), PARAM_ENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_EMPLOYEEDEPARTMENTHISTORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.BusinessEntityID, PARAM_BUSINESSENTITYID));				
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));				
				command.Parameters.Add(dataContext.CreateParameter(this.DepartmentID, PARAM_DEPARTMENTID));				
				command.Parameters.Add(dataContext.CreateParameter(this.ShiftID, PARAM_SHIFTID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
