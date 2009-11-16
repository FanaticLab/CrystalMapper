/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: Shift
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
    public partial class Shift : Entity< Shift>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "HumanResources.Shift";	
     
		public const string COL_SHIFTID = "ShiftID";
		public const string COL_NAME = "Name";
		public const string COL_STARTTIME = "StartTime";
		public const string COL_ENDTIME = "EndTime";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SHIFTID = "@ShiftID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_STARTTIME = "@StartTime";	
        public const string PARAM_ENDTIME = "@EndTime";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SHIFT = "INSERT INTO HumanResources.Shift([Name],[StartTime],[EndTime],[ModifiedDate]) VALUES (@Name,@StartTime,@EndTime,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_SHIFT = "UPDATE HumanResources.Shift SET  [Name] = @Name, [StartTime] = @StartTime, [EndTime] = @EndTime, [ModifiedDate] = @ModifiedDate WHERE [ShiftID] = @ShiftID";
		
		private const string SQL_DELETE_SHIFT = "DELETE FROM HumanResources.Shift WHERE  [ShiftID] = @ShiftID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected byte shiftid = default(byte);
	
		protected string name = default(string);
	
		protected System.TimeSpan starttime = default(System.TimeSpan);
	
		protected System.TimeSpan endtime = default(System.TimeSpan);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
        protected EntityCollection< EmployeeDepartmentHistory> employeeDepartmentHistories ;
        
        #endregion

 		#region Properties	

        [Column( COL_SHIFTID, PARAM_SHIFTID, default(byte))]
                              public virtual byte ShiftID 
        {
            get { return this.shiftid; }
			set	{ 
                  if(this.shiftid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ShiftID"));  
                        this.shiftid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ShiftID"));
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
		
        [Column( COL_STARTTIME, PARAM_STARTTIME, typeof(System.TimeSpan))]
                              public virtual System.TimeSpan StartTime 
        {
            get { return this.starttime; }
			set	{ 
                  if(this.starttime != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("StartTime"));  
                        this.starttime = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("StartTime"));
                    }   
                }
        }	
		
        [Column( COL_ENDTIME, PARAM_ENDTIME, typeof(System.TimeSpan))]
                              public virtual System.TimeSpan EndTime 
        {
            get { return this.endtime; }
			set	{ 
                  if(this.endtime != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("EndTime"));  
                        this.endtime = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("EndTime"));
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
		
        public Shift()
        {
             this.employeeDepartmentHistories = new EntityCollection< EmployeeDepartmentHistory>(this, new Associate< EmployeeDepartmentHistory>(this.AssociateEmployeeDepartmentHistories), new DeAssociate< EmployeeDepartmentHistory>(this.DeAssociateEmployeeDepartmentHistories), new GetChildren< EmployeeDepartmentHistory>(this.GetChildrenEmployeeDepartmentHistories));
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.shiftid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            Shift entity = obj as Shift;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.ShiftID == entity.ShiftID
                        && this.ShiftID != default(byte)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.shiftid = (byte)reader[COL_SHIFTID];
			this.name = (string)reader[COL_NAME];
			this.starttime = (System.TimeSpan)reader[COL_STARTTIME];
			this.endtime = (System.TimeSpan)reader[COL_ENDTIME];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SHIFT))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.StartTime, PARAM_STARTTIME));
				command.Parameters.Add(dataContext.CreateParameter(this.EndTime, PARAM_ENDTIME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.ShiftID = Convert.ToByte(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SHIFT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ShiftID, PARAM_SHIFTID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.StartTime, PARAM_STARTTIME));
				command.Parameters.Add(dataContext.CreateParameter(this.EndTime, PARAM_ENDTIME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SHIFT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ShiftID, PARAM_SHIFTID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        private void AssociateEmployeeDepartmentHistories(EmployeeDepartmentHistory employeeDepartmentHistory)
        {
           employeeDepartmentHistory.ShiftEntity = this;
        }
        
        private void DeAssociateEmployeeDepartmentHistories(EmployeeDepartmentHistory employeeDepartmentHistory)
        {
          if(employeeDepartmentHistory.ShiftEntity == this)
             employeeDepartmentHistory.ShiftEntity = null;
        }
        
        private EmployeeDepartmentHistory[] GetChildrenEmployeeDepartmentHistories()
        {
            EmployeeDepartmentHistory childrenQuery = new EmployeeDepartmentHistory();
            childrenQuery.ShiftEntity = this;
            
            return childrenQuery.ToList(); 
        }
        
        #endregion
    }
}
