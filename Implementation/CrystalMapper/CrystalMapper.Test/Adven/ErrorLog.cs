/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, November 11, 2009 9:50 AM
 * 
 * Class: ErrorLog
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
    public partial class ErrorLog : Entity< ErrorLog>  
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "dbo.ErrorLog";	
     
		public const string COL_ERRORLOGID = "ErrorLogID";
		public const string COL_ERRORTIME = "ErrorTime";
		public const string COL_USERNAME = "UserName";
		public const string COL_ERRORNUMBER = "ErrorNumber";
		public const string COL_ERRORSEVERITY = "ErrorSeverity";
		public const string COL_ERRORSTATE = "ErrorState";
		public const string COL_ERRORPROCEDURE = "ErrorProcedure";
		public const string COL_ERRORLINE = "ErrorLine";
		public const string COL_ERRORMESSAGE = "ErrorMessage";
		
        public const string PARAM_ERRORLOGID = "@ErrorLogID";	
        public const string PARAM_ERRORTIME = "@ErrorTime";	
        public const string PARAM_USERNAME = "@UserName";	
        public const string PARAM_ERRORNUMBER = "@ErrorNumber";	
        public const string PARAM_ERRORSEVERITY = "@ErrorSeverity";	
        public const string PARAM_ERRORSTATE = "@ErrorState";	
        public const string PARAM_ERRORPROCEDURE = "@ErrorProcedure";	
        public const string PARAM_ERRORLINE = "@ErrorLine";	
        public const string PARAM_ERRORMESSAGE = "@ErrorMessage";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_ERRORLOG = "INSERT INTO dbo.ErrorLog([ErrorTime],[UserName],[ErrorNumber],[ErrorSeverity],[ErrorState],[ErrorProcedure],[ErrorLine],[ErrorMessage]) VALUES (@ErrorTime,@UserName,@ErrorNumber,@ErrorSeverity,@ErrorState,@ErrorProcedure,@ErrorLine,@ErrorMessage);"   + "SELECT @@IDENTITY;" ;
		
		private const string SQL_UPDATE_ERRORLOG = "UPDATE dbo.ErrorLog SET  [ErrorTime] = @ErrorTime, [UserName] = @UserName, [ErrorNumber] = @ErrorNumber, [ErrorSeverity] = @ErrorSeverity, [ErrorState] = @ErrorState, [ErrorProcedure] = @ErrorProcedure, [ErrorLine] = @ErrorLine, [ErrorMessage] = @ErrorMessage WHERE [ErrorLogID] = @ErrorLogID";
		
		private const string SQL_DELETE_ERRORLOG = "DELETE FROM dbo.ErrorLog WHERE  [ErrorLogID] = @ErrorLogID ";
		
        #endregion        
        
        #region Hash Code       
        
        private volatile int hashCode = 0;
        
        #endregion
        
        #region Declarations
        
		protected int errorlogid = default(int);
	
		protected System.DateTime errortime = default(System.DateTime);
	
		protected string username = default(string);
	
		protected int errornumber = default(int);
	
		protected int? errorseverity = default(int?);
	
		protected int? errorstate = default(int?);
	
		protected string errorprocedure = default(string);
	
		protected int? errorline = default(int?);
	
		protected string errormessage = default(string);
	
        #endregion

 		#region Properties	

        [Column( COL_ERRORLOGID, PARAM_ERRORLOGID, default(int))]
                              public virtual int ErrorLogID 
        {
            get { return this.errorlogid; }
			set	{ 
                  if(this.errorlogid != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ErrorLogID"));  
                        this.errorlogid = value; 
                        this.hashCode = 0;
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ErrorLogID"));
                    }   
                }
        }	
		
        [Column( COL_ERRORTIME, PARAM_ERRORTIME, typeof(System.DateTime))]
                              public virtual System.DateTime ErrorTime 
        {
            get { return this.errortime; }
			set	{ 
                  if(this.errortime != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ErrorTime"));  
                        this.errortime = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ErrorTime"));
                    }   
                }
        }	
		
        [Column( COL_USERNAME, PARAM_USERNAME )]
                              public virtual string UserName 
        {
            get { return this.username; }
			set	{ 
                  if(this.username != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("UserName"));  
                        this.username = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("UserName"));
                    }   
                }
        }	
		
        [Column( COL_ERRORNUMBER, PARAM_ERRORNUMBER, default(int))]
                              public virtual int ErrorNumber 
        {
            get { return this.errornumber; }
			set	{ 
                  if(this.errornumber != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ErrorNumber"));  
                        this.errornumber = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ErrorNumber"));
                    }   
                }
        }	
		
        [Column( COL_ERRORSEVERITY, PARAM_ERRORSEVERITY )]
                              public virtual int? ErrorSeverity 
        {
            get { return this.errorseverity; }
			set	{ 
                  if(this.errorseverity != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ErrorSeverity"));  
                        this.errorseverity = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ErrorSeverity"));
                    }   
                }
        }	
		
        [Column( COL_ERRORSTATE, PARAM_ERRORSTATE )]
                              public virtual int? ErrorState 
        {
            get { return this.errorstate; }
			set	{ 
                  if(this.errorstate != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ErrorState"));  
                        this.errorstate = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ErrorState"));
                    }   
                }
        }	
		
        [Column( COL_ERRORPROCEDURE, PARAM_ERRORPROCEDURE )]
                              public virtual string ErrorProcedure 
        {
            get { return this.errorprocedure; }
			set	{ 
                  if(this.errorprocedure != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ErrorProcedure"));  
                        this.errorprocedure = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ErrorProcedure"));
                    }   
                }
        }	
		
        [Column( COL_ERRORLINE, PARAM_ERRORLINE )]
                              public virtual int? ErrorLine 
        {
            get { return this.errorline; }
			set	{ 
                  if(this.errorline != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ErrorLine"));  
                        this.errorline = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ErrorLine"));
                    }   
                }
        }	
		
        [Column( COL_ERRORMESSAGE, PARAM_ERRORMESSAGE )]
                              public virtual string ErrorMessage 
        {
            get { return this.errormessage; }
			set	{ 
                  if(this.errormessage != value)
                    {
                        this.OnPropertyChanging(new PropertyChangingEventArgs("ErrorMessage"));  
                        this.errormessage = value; 
                        this.OnPropertyChanged(new PropertyChangedEventArgs("ErrorMessage"));
                    }   
                }
        }	
		
        
        #endregion        
        
        #region Methods     
		
        public ErrorLog()
        {
        }
        
        public override int GetHashCode()
        {      
            if(this.hashCode == 0)
            {
                int result = 7;            
                result = (11 * result) + this.errorlogid.GetHashCode();
                this.hashCode = result;
             }           
            return this.hashCode;          
        }
        
        public override bool Equals(object obj)
        {
            ErrorLog entity = obj as ErrorLog;           
            
            return (
                    object.ReferenceEquals(this, entity)                    
                    || (
                        entity != null            
                        && this.ErrorLogID == entity.ErrorLogID
                        && this.ErrorLogID != default(int)
                        )
                    );           
        }
        
		public override void Read(DbDataReader reader)
		{       
			this.errorlogid = (int)reader[COL_ERRORLOGID];
			this.errortime = (System.DateTime)reader[COL_ERRORTIME];
			this.username = (string)reader[COL_USERNAME];
			this.errornumber = (int)reader[COL_ERRORNUMBER];
			this.errorseverity = DbConvert.ToNullable< int >(reader[COL_ERRORSEVERITY]);
			this.errorstate = DbConvert.ToNullable< int >(reader[COL_ERRORSTATE]);
			this.errorprocedure = DbConvert.ToString(reader[COL_ERRORPROCEDURE]);
			this.errorline = DbConvert.ToNullable< int >(reader[COL_ERRORLINE]);
			this.errormessage = (string)reader[COL_ERRORMESSAGE];
            this.hashCode = 0;
            
            base.Read(reader);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_ERRORLOG))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ErrorTime, PARAM_ERRORTIME));
				command.Parameters.Add(dataContext.CreateParameter(this.UserName, PARAM_USERNAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ErrorNumber, PARAM_ERRORNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ErrorSeverity), PARAM_ERRORSEVERITY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ErrorState), PARAM_ERRORSTATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ErrorProcedure), PARAM_ERRORPROCEDURE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ErrorLine), PARAM_ERRORLINE));
				command.Parameters.Add(dataContext.CreateParameter(this.ErrorMessage, PARAM_ERRORMESSAGE));
                this.ErrorLogID = Convert.ToInt32(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_ERRORLOG))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ErrorLogID, PARAM_ERRORLOGID));
				command.Parameters.Add(dataContext.CreateParameter(this.ErrorTime, PARAM_ERRORTIME));
				command.Parameters.Add(dataContext.CreateParameter(this.UserName, PARAM_USERNAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ErrorNumber, PARAM_ERRORNUMBER));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ErrorSeverity), PARAM_ERRORSEVERITY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ErrorState), PARAM_ERRORSTATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ErrorProcedure), PARAM_ERRORPROCEDURE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ErrorLine), PARAM_ERRORLINE));
				command.Parameters.Add(dataContext.CreateParameter(this.ErrorMessage, PARAM_ERRORMESSAGE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_ERRORLOG))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ErrorLogID, PARAM_ERRORLOGID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Entity Relationship Functions
        
        #endregion
    }
}
