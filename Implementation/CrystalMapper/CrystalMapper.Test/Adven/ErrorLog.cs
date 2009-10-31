/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: ErrorLog
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
		
		private const string SQL_INSERT_ERRORLOG = "INSERT INTO dbo.ErrorLog([ErrorTime],[UserName],[ErrorNumber],[ErrorSeverity],[ErrorState],[ErrorProcedure],[ErrorLine],[ErrorMessage]) VALUES (@ErrorTime,@UserName,@ErrorNumber,@ErrorSeverity,@ErrorState,@ErrorProcedure,@ErrorLine,@ErrorMessage);";
		
		private const string SQL_UPDATE_ERRORLOG = "UPDATE dbo.ErrorLog SET [ErrorTime] = @ErrorTime, [UserName] = @UserName, [ErrorNumber] = @ErrorNumber, [ErrorSeverity] = @ErrorSeverity, [ErrorState] = @ErrorState, [ErrorProcedure] = @ErrorProcedure, [ErrorLine] = @ErrorLine, [ErrorMessage] = @ErrorMessage,  WHERE [ErrorLogID] = @ErrorLogID";
		
		private const string SQL_DELETE_ERRORLOG = "DELETE FROM dbo.ErrorLog WHERE  [ErrorLogID] = @ErrorLogID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_ERRORLOGID, PARAM_ERRORLOGID, default(int))]
                              public virtual int ErrorLogID  { get; set; }		
		
        
	    [Column( COL_ERRORTIME, PARAM_ERRORTIME, typeof(System.DateTime))]
                              public virtual System.DateTime ErrorTime  { get; set; }	      
        
	    [Column( COL_USERNAME, PARAM_USERNAME )]
                              public virtual string UserName  { get; set; }	      
        
	    [Column( COL_ERRORNUMBER, PARAM_ERRORNUMBER, default(int))]
                              public virtual int ErrorNumber  { get; set; }	      
        
	    [Column( COL_ERRORSEVERITY, PARAM_ERRORSEVERITY )]
                              public virtual int? ErrorSeverity  { get; set; }	      
        
	    [Column( COL_ERRORSTATE, PARAM_ERRORSTATE )]
                              public virtual int? ErrorState  { get; set; }	      
        
	    [Column( COL_ERRORPROCEDURE, PARAM_ERRORPROCEDURE )]
                              public virtual string ErrorProcedure  { get; set; }	      
        
	    [Column( COL_ERRORLINE, PARAM_ERRORLINE )]
                              public virtual int? ErrorLine  { get; set; }	      
        
	    [Column( COL_ERRORMESSAGE, PARAM_ERRORMESSAGE )]
                              public virtual string ErrorMessage  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.ErrorLogID = (int)reader[COL_ERRORLOGID];
			this.ErrorTime = (System.DateTime)reader[COL_ERRORTIME];
			this.UserName = (string)reader[COL_USERNAME];
			this.ErrorNumber = (int)reader[COL_ERRORNUMBER];
			this.ErrorSeverity = DbConvert.ToNullable< int >(reader[COL_ERRORSEVERITY]);
			this.ErrorState = DbConvert.ToNullable< int >(reader[COL_ERRORSTATE]);
			this.ErrorProcedure = DbConvert.ToString(reader[COL_ERRORPROCEDURE]);
			this.ErrorLine = DbConvert.ToNullable< int >(reader[COL_ERRORLINE]);
			this.ErrorMessage = (string)reader[COL_ERRORMESSAGE];
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
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.ErrorLogID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
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
        
        #region Children
        
        
        
        
        #endregion
    }
}
