/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: DatabaseLog
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
    public partial class DatabaseLog : Entity< DatabaseLog>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "dbo.DatabaseLog";	
     
		public const string COL_DATABASELOGID = "DatabaseLogID";
		public const string COL_POSTTIME = "PostTime";
		public const string COL_DATABASEUSER = "DatabaseUser";
		public const string COL_EVENT = "Event";
		public const string COL_SCHEMA = "Schema";
		public const string COL_OBJECT = "Object";
		public const string COL_TSQL = "TSQL";
		public const string COL_XMLEVENT = "XmlEvent";
		
        public const string PARAM_DATABASELOGID = "@DatabaseLogID";	
        public const string PARAM_POSTTIME = "@PostTime";	
        public const string PARAM_DATABASEUSER = "@DatabaseUser";	
        public const string PARAM_EVENT = "@Event";	
        public const string PARAM_SCHEMA = "@Schema";	
        public const string PARAM_OBJECT = "@Object";	
        public const string PARAM_TSQL = "@TSQL";	
        public const string PARAM_XMLEVENT = "@XmlEvent";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_DATABASELOG = "INSERT INTO dbo.DatabaseLog([PostTime],[DatabaseUser],[Event],[Schema],[Object],[TSQL],[XmlEvent]) VALUES (@PostTime,@DatabaseUser,@Event,@Schema,@Object,@TSQL,@XmlEvent);";
		
		private const string SQL_UPDATE_DATABASELOG = "UPDATE dbo.DatabaseLog SET [PostTime] = @PostTime, [DatabaseUser] = @DatabaseUser, [Event] = @Event, [Schema] = @Schema, [Object] = @Object, [TSQL] = @TSQL, [XmlEvent] = @XmlEvent,  WHERE [DatabaseLogID] = @DatabaseLogID";
		
		private const string SQL_DELETE_DATABASELOG = "DELETE FROM dbo.DatabaseLog WHERE  [DatabaseLogID] = @DatabaseLogID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_DATABASELOGID, PARAM_DATABASELOGID, default(int))]
                              public virtual int DatabaseLogID  { get; set; }		
		
        
	    [Column( COL_POSTTIME, PARAM_POSTTIME, typeof(System.DateTime))]
                              public virtual System.DateTime PostTime  { get; set; }	      
        
	    [Column( COL_DATABASEUSER, PARAM_DATABASEUSER )]
                              public virtual string DatabaseUser  { get; set; }	      
        
	    [Column( COL_EVENT, PARAM_EVENT )]
                              public virtual string Event  { get; set; }	      
        
	    [Column( COL_SCHEMA, PARAM_SCHEMA )]
                              public virtual string Schema  { get; set; }	      
        
	    [Column( COL_OBJECT, PARAM_OBJECT )]
                              public virtual string Object  { get; set; }	      
        
	    [Column( COL_TSQL, PARAM_TSQL )]
                              public virtual string Tsql  { get; set; }	      
        
	    [Column( COL_XMLEVENT, PARAM_XMLEVENT )]
                              public virtual System.Xml.XmlDocument XmlEvent  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.DatabaseLogID = (int)reader[COL_DATABASELOGID];
			this.PostTime = (System.DateTime)reader[COL_POSTTIME];
			this.DatabaseUser = (string)reader[COL_DATABASEUSER];
			this.Event = (string)reader[COL_EVENT];
			this.Schema = DbConvert.ToString(reader[COL_SCHEMA]);
			this.Object = DbConvert.ToString(reader[COL_OBJECT]);
			this.Tsql = (string)reader[COL_TSQL];
			this.XmlEvent = (System.Xml.XmlDocument)reader[COL_XMLEVENT];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_DATABASELOG))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.PostTime, PARAM_POSTTIME));
				command.Parameters.Add(dataContext.CreateParameter(this.DatabaseUser, PARAM_DATABASEUSER));
				command.Parameters.Add(dataContext.CreateParameter(this.Event, PARAM_EVENT));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Schema), PARAM_SCHEMA));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Object), PARAM_OBJECT));
				command.Parameters.Add(dataContext.CreateParameter(this.Tsql, PARAM_TSQL));
				command.Parameters.Add(dataContext.CreateParameter(this.XmlEvent, PARAM_XMLEVENT));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.DatabaseLogID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_DATABASELOG))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.DatabaseLogID, PARAM_DATABASELOGID));
				command.Parameters.Add(dataContext.CreateParameter(this.PostTime, PARAM_POSTTIME));
				command.Parameters.Add(dataContext.CreateParameter(this.DatabaseUser, PARAM_DATABASEUSER));
				command.Parameters.Add(dataContext.CreateParameter(this.Event, PARAM_EVENT));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Schema), PARAM_SCHEMA));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Object), PARAM_OBJECT));
				command.Parameters.Add(dataContext.CreateParameter(this.Tsql, PARAM_TSQL));
				command.Parameters.Add(dataContext.CreateParameter(this.XmlEvent, PARAM_XMLEVENT));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_DATABASELOG))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.DatabaseLogID, PARAM_DATABASELOGID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
