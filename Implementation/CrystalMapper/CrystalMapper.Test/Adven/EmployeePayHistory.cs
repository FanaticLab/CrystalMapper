/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: EmployeePayHistory
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
    public partial class EmployeePayHistory : Entity< EmployeePayHistory>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "HumanResources.EmployeePayHistory";	
     
		public const string COL_EMPLOYEEID = "EmployeeID";
		public const string COL_RATECHANGEDATE = "RateChangeDate";
		public const string COL_RATE = "Rate";
		public const string COL_PAYFREQUENCY = "PayFrequency";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_EMPLOYEEID = "@EmployeeID";	
        public const string PARAM_RATECHANGEDATE = "@RateChangeDate";	
        public const string PARAM_RATE = "@Rate";	
        public const string PARAM_PAYFREQUENCY = "@PayFrequency";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_EMPLOYEEPAYHISTORY = "INSERT INTO HumanResources.EmployeePayHistory([EmployeeID],[RateChangeDate],[Rate],[PayFrequency],[ModifiedDate]) VALUES (@EmployeeID,@RateChangeDate,@Rate,@PayFrequency,@ModifiedDate);";
		
		private const string SQL_UPDATE_EMPLOYEEPAYHISTORY = "UPDATE HumanResources.EmployeePayHistory SET [Rate] = @Rate, [PayFrequency] = @PayFrequency, [ModifiedDate] = @ModifiedDate,  WHERE [EmployeeID] = @EmployeeID AND [RateChangeDate] = @RateChangeDate";
		
		private const string SQL_DELETE_EMPLOYEEPAYHISTORY = "DELETE FROM HumanResources.EmployeePayHistory WHERE  [EmployeeID] = @EmployeeID AND [RateChangeDate] = @RateChangeDate ";
		
        #endregion
        #region Properties	
		
		[Column( COL_EMPLOYEEID, PARAM_EMPLOYEEID, default(int))]
                              public virtual int EmployeeID  { get; set; }		
		[Column( COL_RATECHANGEDATE, PARAM_RATECHANGEDATE, typeof(System.DateTime))]
                              public virtual System.DateTime RateChangeDate  { get; set; }		
		
        
	    [Column( COL_RATE, PARAM_RATE, typeof(decimal))]
                              public virtual decimal Rate  { get; set; }	      
        
	    [Column( COL_PAYFREQUENCY, PARAM_PAYFREQUENCY, default(byte))]
                              public virtual byte PayFrequency  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.EmployeeID = (int)reader[COL_EMPLOYEEID];
			this.RateChangeDate = (System.DateTime)reader[COL_RATECHANGEDATE];
			this.Rate = (decimal)reader[COL_RATE];
			this.PayFrequency = (byte)reader[COL_PAYFREQUENCY];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_EMPLOYEEPAYHISTORY))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.EmployeeID, PARAM_EMPLOYEEID));
				command.Parameters.Add(dataContext.CreateParameter(this.RateChangeDate, PARAM_RATECHANGEDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Rate, PARAM_RATE));
				command.Parameters.Add(dataContext.CreateParameter(this.PayFrequency, PARAM_PAYFREQUENCY));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_EMPLOYEEPAYHISTORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.EmployeeID, PARAM_EMPLOYEEID));
				command.Parameters.Add(dataContext.CreateParameter(this.RateChangeDate, PARAM_RATECHANGEDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.Rate, PARAM_RATE));
				command.Parameters.Add(dataContext.CreateParameter(this.PayFrequency, PARAM_PAYFREQUENCY));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_EMPLOYEEPAYHISTORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.EmployeeID, PARAM_EMPLOYEEID));				
				command.Parameters.Add(dataContext.CreateParameter(this.RateChangeDate, PARAM_RATECHANGEDATE));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
