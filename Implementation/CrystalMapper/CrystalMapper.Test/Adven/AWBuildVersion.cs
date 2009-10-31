/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: AWBuildVersion
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
    public partial class AWBuildVersion : Entity< AWBuildVersion>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "dbo.AWBuildVersion";	
     
		public const string COL_SYSTEMINFORMATIONID = "SystemInformationID";
		public const string COL_DATABASE_VERSION = "Database Version";
		public const string COL_VERSIONDATE = "VersionDate";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SYSTEMINFORMATIONID = "@SystemInformationID";	
        public const string PARAM_DATABASE_VERSION = "@Database_Version";	
        public const string PARAM_VERSIONDATE = "@VersionDate";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_AWBUILDVERSION = "INSERT INTO dbo.AWBuildVersion([Database Version],[VersionDate],[ModifiedDate]) VALUES (@Database_Version,@VersionDate,@ModifiedDate);";
		
		private const string SQL_UPDATE_AWBUILDVERSION = "UPDATE dbo.AWBuildVersion SET [Database Version] = @Database_Version, [VersionDate] = @VersionDate, [ModifiedDate] = @ModifiedDate,  WHERE [SystemInformationID] = @SystemInformationID";
		
		private const string SQL_DELETE_AWBUILDVERSION = "DELETE FROM dbo.AWBuildVersion WHERE  [SystemInformationID] = @SystemInformationID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_SYSTEMINFORMATIONID, PARAM_SYSTEMINFORMATIONID, default(byte))]
                              public virtual byte SystemInformationID  { get; set; }		
		
        
	    [Column( COL_DATABASE_VERSION, PARAM_DATABASE_VERSION )]
                              public virtual string DatabaseVersion  { get; set; }	      
        
	    [Column( COL_VERSIONDATE, PARAM_VERSIONDATE, typeof(System.DateTime))]
                              public virtual System.DateTime VersionDate  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.SystemInformationID = (byte)reader[COL_SYSTEMINFORMATIONID];
			this.DatabaseVersion = (string)reader[COL_DATABASE_VERSION];
			this.VersionDate = (System.DateTime)reader[COL_VERSIONDATE];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_AWBUILDVERSION))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.DatabaseVersion, PARAM_DATABASE_VERSION));
				command.Parameters.Add(dataContext.CreateParameter(this.VersionDate, PARAM_VERSIONDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.SystemInformationID = Convert.ToByte(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_AWBUILDVERSION))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SystemInformationID, PARAM_SYSTEMINFORMATIONID));
				command.Parameters.Add(dataContext.CreateParameter(this.DatabaseVersion, PARAM_DATABASE_VERSION));
				command.Parameters.Add(dataContext.CreateParameter(this.VersionDate, PARAM_VERSIONDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_AWBUILDVERSION))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SystemInformationID, PARAM_SYSTEMINFORMATIONID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
