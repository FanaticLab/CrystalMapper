/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: JobCandidate
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
    public partial class JobCandidate : Entity< JobCandidate>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "HumanResources.JobCandidate";	
     
		public const string COL_JOBCANDIDATEID = "JobCandidateID";
		public const string COL_BUSINESSENTITYID = "BusinessEntityID";
		public const string COL_RESUME = "Resume";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_JOBCANDIDATEID = "@JobCandidateID";	
        public const string PARAM_BUSINESSENTITYID = "@BusinessEntityID";	
        public const string PARAM_RESUME = "@Resume";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_JOBCANDIDATE = "INSERT INTO HumanResources.JobCandidate([BusinessEntityID],[Resume],[ModifiedDate]) VALUES (@BusinessEntityID,@Resume,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_JOBCANDIDATE = "UPDATE HumanResources.JobCandidate SET  [BusinessEntityID] = @BusinessEntityID, [Resume] = @Resume, [ModifiedDate] = @ModifiedDate WHERE [JobCandidateID] = @JobCandidateID";
		
		private const string SQL_DELETE_JOBCANDIDATE = "DELETE FROM HumanResources.JobCandidate WHERE  [JobCandidateID] = @JobCandidateID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int jobcandidateid = default(int);
	
		protected int? businessentityid = default(int?);
	
		protected System.Xml.XmlDocument resume = default(System.Xml.XmlDocument);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
		protected Employee employeeEntity;
	
        #endregion

 		#region Properties	

        [Column( COL_JOBCANDIDATEID, PARAM_JOBCANDIDATEID, default(int))]
                              public virtual int JobCandidateID 
        {
            get { return this.jobcandidateid; }
			set	{ 
                  if(this.jobcandidateid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("JobCandidateID"));  
                        this.jobcandidateid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("JobCandidateID"));
                    }   
                }
        }	
		
        [Column( COL_RESUME, PARAM_RESUME )]
                              public virtual System.Xml.XmlDocument Resume 
        {
            get { return this.resume; }
			set	{ 
                  if(this.resume != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Resume"));  
                        this.resume = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Resume"));
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
		
        [Column( COL_BUSINESSENTITYID, PARAM_BUSINESSENTITYID )]
                              public virtual int? BusinessEntityID                
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
        
        public Employee EmployeeEntity
        {
            get { 
                    if(this.employeeEntity == null
                       && this.businessentityid.HasValue )
                    {
                        Employee employeeQuery = new Employee {
                                                        BusinessEntityID = this.businessentityid.Value  
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
		
        
        #endregion        
        
        #region Methods     
		
        public JobCandidate()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.jobcandidateid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            JobCandidate entity = obj as JobCandidate;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.JobCandidateID == entity.JobCandidateID
                        && this.JobCandidateID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.jobcandidateid = (int)reader[COL_JOBCANDIDATEID];
			this.businessentityid = DbConvert.ToNullable< int >(reader[COL_BUSINESSENTITYID]);
			this.resume = (System.Xml.XmlDocument)reader[COL_RESUME];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_JOBCANDIDATE))
            {	
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.BusinessEntityID), PARAM_BUSINESSENTITYID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Resume), PARAM_RESUME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.JobCandidateID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_JOBCANDIDATE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.JobCandidateID, PARAM_JOBCANDIDATEID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.BusinessEntityID), PARAM_BUSINESSENTITYID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Resume), PARAM_RESUME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_JOBCANDIDATE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.JobCandidateID, PARAM_JOBCANDIDATEID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
