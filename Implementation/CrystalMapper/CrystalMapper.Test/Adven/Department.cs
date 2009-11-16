/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: Department
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
    public partial class Department : Entity< Department>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "HumanResources.Department";	
     
		public const string COL_DEPARTMENTID = "DepartmentID";
		public const string COL_NAME = "Name";
		public const string COL_GROUPNAME = "GroupName";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_DEPARTMENTID = "@DepartmentID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_GROUPNAME = "@GroupName";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_DEPARTMENT = "INSERT INTO HumanResources.Department([Name],[GroupName],[ModifiedDate]) VALUES (@Name,@GroupName,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_DEPARTMENT = "UPDATE HumanResources.Department SET  [Name] = @Name, [GroupName] = @GroupName, [ModifiedDate] = @ModifiedDate WHERE [DepartmentID] = @DepartmentID";
		
		private const string SQL_DELETE_DEPARTMENT = "DELETE FROM HumanResources.Department WHERE  [DepartmentID] = @DepartmentID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected short departmentid = default(short);
	
		protected string name = default(string);
	
		protected string groupname = default(string);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
        protected EntityCollection< EmployeeDepartmentHistory> employeeDepartmentHistories ;
        
        #endregion

 		#region Properties	

        [Column( COL_DEPARTMENTID, PARAM_DEPARTMENTID, default(short))]
                              public virtual short DepartmentID 
        {
            get { return this.departmentid; }
			set	{ 
                  if(this.departmentid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("DepartmentID"));  
                        this.departmentid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("DepartmentID"));
                    }   
                }
        }	
		
        [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name 
        {
            get { return this.name; }
			set	{ 
                  if(this.name != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Name"));  
                        this.name = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Name"));
                    }   
                }
        }	
		
        [Column( COL_GROUPNAME, PARAM_GROUPNAME )]
                              public virtual string GroupName 
        {
            get { return this.groupname; }
			set	{ 
                  if(this.groupname != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("GroupName"));  
                        this.groupname = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("GroupName"));
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
		
        public EntityCollection< EmployeeDepartmentHistory> EmployeeDepartmentHistories 
        {
            get { return this.employeeDepartmentHistories;}
        }
        
        
        #endregion        
        
        #region Methods     
		
        public Department()
        {
             this.employeeDepartmentHistories = new EntityCollection< EmployeeDepartmentHistory>(this, new Associate< EmployeeDepartmentHistory>(this.AssociateEmployeeDepartmentHistories), new DeAssociate< EmployeeDepartmentHistory>(this.DeAssociateEmployeeDepartmentHistories), new GetChildren< EmployeeDepartmentHistory>(this.GetChildrenEmployeeDepartmentHistories));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.departmentid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            Department entity = obj as Department;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.DepartmentID == entity.DepartmentID
                        && this.DepartmentID != default(short)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.departmentid = (short)reader[COL_DEPARTMENTID];
			this.name = (string)reader[COL_NAME];
			this.groupname = (string)reader[COL_GROUPNAME];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_DEPARTMENT))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.GroupName, PARAM_GROUPNAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.DepartmentID = Convert.ToInt16(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_DEPARTMENT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.DepartmentID, PARAM_DEPARTMENTID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.GroupName, PARAM_GROUPNAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_DEPARTMENT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.DepartmentID, PARAM_DEPARTMENTID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateEmployeeDepartmentHistories(EmployeeDepartmentHistory employeeDepartmentHistory)
        {
           employeeDepartmentHistory.DepartmentEntity = this;
        }
        
        private void DeAssociateEmployeeDepartmentHistories(EmployeeDepartmentHistory employeeDepartmentHistory)
        {
          if(employeeDepartmentHistory.DepartmentEntity == this)
             employeeDepartmentHistory.DepartmentEntity = null;
        }
        
        private EmployeeDepartmentHistory[] GetChildrenEmployeeDepartmentHistories()
        {
            EmployeeDepartmentHistory childrenQuery = new EmployeeDepartmentHistory();
            childrenQuery.DepartmentEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
