/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: JobCandidate
 *    
 */

using System;
using System.Data.Common;
using System.Diagnostics;
using System.Collections.Generic;

using CoreSystem.Data;

using CrystalMapper;
using CrystalMapper.Data;
using CrystalMapper.Mapping;

namespace CrystalMapper.Generated.BusinessObjects
{
	[Table(TABLE_NAME)]
    public partial class JobCandidate : Entity< JobCandidate>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "HumanResources.JobCandidate";	
     
		public const string COL_JOBCANDIDATEID = "JobCandidateID";
		public const string COL_EMPLOYEEID = "EmployeeID";
		public const string COL_RESUME = "Resume";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_JOBCANDIDATEID = "@JobCandidateID";	
        public const string PARAM_EMPLOYEEID = "@EmployeeID";	
        public const string PARAM_RESUME = "@Resume";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_JOBCANDIDATE = "INSERT INTO HumanResources.JobCandidate([EmployeeID],[Resume],[ModifiedDate]) VALUES (@EmployeeID,@Resume,@ModifiedDate);";
		
		private const string SQL_UPDATE_JOBCANDIDATE = "UPDATE HumanResources.JobCandidate SET [EmployeeID] = @EmployeeID, [Resume] = @Resume, [ModifiedDate] = @ModifiedDate,  WHERE [JobCandidateID] = @JobCandidateID";
		
		private const string SQL_DELETE_JOBCANDIDATE = "DELETE FROM HumanResources.JobCandidate WHERE  [JobCandidateID] = @JobCandidateID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_JOBCANDIDATEID, PARAM_JOBCANDIDATEID, default(int))]
                              public virtual int JobCandidateID  { get; set; }		
		
        
	    [Column( COL_EMPLOYEEID, PARAM_EMPLOYEEID )]
                              public virtual int? EmployeeID  { get; set; }	      
        
	    [Column( COL_RESUME, PARAM_RESUME )]
                              public virtual System.Xml.XmlDocument Resume  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.JobCandidateID = (int)reader[COL_JOBCANDIDATEID];
			this.EmployeeID = DbConvert.ToNullable< int >(reader[COL_EMPLOYEEID]);
			this.Resume = (System.Xml.XmlDocument)reader[COL_RESUME];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_JOBCANDIDATE))
            {	
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EmployeeID), PARAM_EMPLOYEEID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Resume), PARAM_RESUME));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.JobCandidateID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_JOBCANDIDATE))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.JobCandidateID, PARAM_JOBCANDIDATEID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EmployeeID), PARAM_EMPLOYEEID));
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
        
        #region Children
        
        
        
        
        #endregion
    }
}
