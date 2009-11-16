/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: AWBuildVersion
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
		
		private const string SQL_INSERT_AWBUILDVERSION = "INSERT INTO dbo.AWBuildVersion([Database Version],[VersionDate],[ModifiedDate]) VALUES (@Database_Version,@VersionDate,@ModifiedDate);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_AWBUILDVERSION = "UPDATE dbo.AWBuildVersion SET  [Database Version] = @Database_Version, [VersionDate] = @VersionDate, [ModifiedDate] = @ModifiedDate WHERE [SystemInformationID] = @SystemInformationID";
		
		private const string SQL_DELETE_AWBUILDVERSION = "DELETE FROM dbo.AWBuildVersion WHERE  [SystemInformationID] = @SystemInformationID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected byte systeminformationid = default(byte);
	
		protected string databaseVersion = default(string);
	
		protected System.DateTime versiondate = default(System.DateTime);
	
		protected System.DateTime modifieddate = default(System.DateTime);
	
        #endregion

 		#region Properties	

        [Column( COL_SYSTEMINFORMATIONID, PARAM_SYSTEMINFORMATIONID, default(byte))]
                              public virtual byte SystemInformationID 
        {
            get { return this.systeminformationid; }
			set	{ 
                  if(this.systeminformationid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("SystemInformationID"));  
                        this.systeminformationid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("SystemInformationID"));
                    }   
                }
        }	
		
        [Column( COL_DATABASE_VERSION, PARAM_DATABASE_VERSION )]
                              public virtual string DatabaseVersion 
        {
            get { return this.databaseVersion; }
			set	{ 
                  if(this.databaseVersion != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("DatabaseVersion"));  
                        this.databaseVersion = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("DatabaseVersion"));
                    }   
                }
        }	
		
        [Column( COL_VERSIONDATE, PARAM_VERSIONDATE, typeof(System.DateTime))]
                              public virtual System.DateTime VersionDate 
        {
            get { return this.versiondate; }
			set	{ 
                  if(this.versiondate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("VersionDate"));  
                        this.versiondate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("VersionDate"));
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
		
        
        #endregion        
        
        #region Methods     
		
        public AWBuildVersion()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.systeminformationid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            AWBuildVersion entity = obj as AWBuildVersion;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.SystemInformationID == entity.SystemInformationID
                        && this.SystemInformationID != default(byte)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.systeminformationid = (byte)reader[COL_SYSTEMINFORMATIONID];
			this.databaseVersion = (string)reader[COL_DATABASE_VERSION];
			this.versiondate = (System.DateTime)reader[COL_VERSIONDATE];
			this.modifieddate = (System.DateTime)reader[COL_MODIFIEDDATE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_AWBUILDVERSION))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.DatabaseVersion, PARAM_DATABASE_VERSION));
				command.Parameters.Add(dataContext.CreateParameter(this.VersionDate, PARAM_VERSIONDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                this.SystemInformationID = Convert.ToByte(command.ExecuteScalar());
                return true;                
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
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
