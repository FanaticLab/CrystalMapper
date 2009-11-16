/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: DatabaseLog
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
		
		private const string SQL_INSERT_DATABASELOG = "INSERT INTO dbo.DatabaseLog([PostTime],[DatabaseUser],[Event],[Schema],[Object],[TSQL],[XmlEvent]) VALUES (@PostTime,@DatabaseUser,@Event,@Schema,@Object,@TSQL,@XmlEvent);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_DATABASELOG = "UPDATE dbo.DatabaseLog SET  [PostTime] = @PostTime, [DatabaseUser] = @DatabaseUser, [Event] = @Event, [Schema] = @Schema, [Object] = @Object, [TSQL] = @TSQL, [XmlEvent] = @XmlEvent WHERE [DatabaseLogID] = @DatabaseLogID";
		
		private const string SQL_DELETE_DATABASELOG = "DELETE FROM dbo.DatabaseLog WHERE  [DatabaseLogID] = @DatabaseLogID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int databaselogid = default(int);
	
		protected System.DateTime posttime = default(System.DateTime);
	
		protected string databaseuser = default(string);
	
		protected string eventName = default(string);
	
		protected string schema = default(string);
	
		protected string objectName = default(string);
	
		protected string tsql = default(string);
	
		protected System.Xml.XmlDocument xmlevent = default(System.Xml.XmlDocument);
	
        #endregion

 		#region Properties	

        [Column( COL_DATABASELOGID, PARAM_DATABASELOGID, default(int))]
                              public virtual int DatabaseLogID 
        {
            get { return this.databaselogid; }
			set	{ 
                  if(this.databaselogid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("DatabaseLogID"));  
                        this.databaselogid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("DatabaseLogID"));
                    }   
                }
        }	
		
        [Column( COL_POSTTIME, PARAM_POSTTIME, typeof(System.DateTime))]
                              public virtual System.DateTime PostTime 
        {
            get { return this.posttime; }
			set	{ 
                  if(this.posttime != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("PostTime"));  
                        this.posttime = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("PostTime"));
                    }   
                }
        }	
		
        [Column( COL_DATABASEUSER, PARAM_DATABASEUSER )]
                              public virtual string DatabaseUser 
        {
            get { return this.databaseuser; }
			set	{ 
                  if(this.databaseuser != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("DatabaseUser"));  
                        this.databaseuser = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("DatabaseUser"));
                    }   
                }
        }	
		
        [Column( COL_EVENT, PARAM_EVENT )]
                              public virtual string EventName 
        {
            get { return this.eventName; }
			set	{ 
                  if(this.eventName != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Event"));  
                        this.eventName = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Event"));
                    }   
                }
        }	
		
        [Column( COL_SCHEMA, PARAM_SCHEMA )]
                              public virtual string Schema 
        {
            get { return this.schema; }
			set	{ 
                  if(this.schema != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Schema"));  
                        this.schema = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Schema"));
                    }   
                }
        }	
		
        [Column( COL_OBJECT, PARAM_OBJECT )]
                              public virtual string Object 
        {
            get { return this.objectName; }
			set	{ 
                  if(this.objectName != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Object"));  
                        this.objectName = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Object"));
                    }   
                }
        }	
		
        [Column( COL_TSQL, PARAM_TSQL )]
                              public virtual string Tsql 
        {
            get { return this.tsql; }
			set	{ 
                  if(this.tsql != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("Tsql"));  
                        this.tsql = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("Tsql"));
                    }   
                }
        }	
		
        [Column( COL_XMLEVENT, PARAM_XMLEVENT )]
                              public virtual System.Xml.XmlDocument XmlEvent 
        {
            get { return this.xmlevent; }
			set	{ 
                  if(this.xmlevent != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("XmlEvent"));  
                        this.xmlevent = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("XmlEvent"));
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
		
        public DatabaseLog()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.databaselogid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            DatabaseLog entity = obj as DatabaseLog;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.DatabaseLogID == entity.DatabaseLogID
                        && this.DatabaseLogID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.databaselogid = (int)reader[COL_DATABASELOGID];
			this.posttime = (System.DateTime)reader[COL_POSTTIME];
			this.databaseuser = (string)reader[COL_DATABASEUSER];
			this.eventName = (string)reader[COL_EVENT];
			this.schema = DbConvert.ToString(reader[COL_SCHEMA]);
			this.objectName = DbConvert.ToString(reader[COL_OBJECT]);
			this.tsql = (string)reader[COL_TSQL];
			this.xmlevent = (System.Xml.XmlDocument)reader[COL_XMLEVENT];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_DATABASELOG))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.PostTime, PARAM_POSTTIME));
				command.Parameters.Add(dataContext.CreateParameter(this.DatabaseUser, PARAM_DATABASEUSER));
				command.Parameters.Add(dataContext.CreateParameter(this.EventName, PARAM_EVENT));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Schema), PARAM_SCHEMA));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Object), PARAM_OBJECT));
				command.Parameters.Add(dataContext.CreateParameter(this.Tsql, PARAM_TSQL));
				command.Parameters.Add(dataContext.CreateParameter(this.XmlEvent, PARAM_XMLEVENT));
                this.DatabaseLogID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_DATABASELOG))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.DatabaseLogID, PARAM_DATABASELOGID));
				command.Parameters.Add(dataContext.CreateParameter(this.PostTime, PARAM_POSTTIME));
				command.Parameters.Add(dataContext.CreateParameter(this.DatabaseUser, PARAM_DATABASEUSER));
				command.Parameters.Add(dataContext.CreateParameter(this.EventName, PARAM_EVENT));
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
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
