/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: Individual
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
    public partial class Individual : Entity< Individual>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.Individual";	
     
		public const string COL_CUSTOMERID = "CustomerID";
		public const string COL_CONTACTID = "ContactID";
		public const string COL_DEMOGRAPHICS = "Demographics";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_CUSTOMERID = "@CustomerID";	
        public const string PARAM_CONTACTID = "@ContactID";	
        public const string PARAM_DEMOGRAPHICS = "@Demographics";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_INDIVIDUAL = "INSERT INTO Sales.Individual([CustomerID],[ContactID],[Demographics],[ModifiedDate]) VALUES (@CustomerID,@ContactID,@Demographics,@ModifiedDate);";
		
		private const string SQL_UPDATE_INDIVIDUAL = "UPDATE Sales.Individual SET [ContactID] = @ContactID, [Demographics] = @Demographics, [ModifiedDate] = @ModifiedDate,  WHERE [CustomerID] = @CustomerID";
		
		private const string SQL_DELETE_INDIVIDUAL = "DELETE FROM Sales.Individual WHERE  [CustomerID] = @CustomerID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_CUSTOMERID, PARAM_CUSTOMERID, default(int))]
                              public virtual int CustomerID  { get; set; }		
		
        
	    [Column( COL_CONTACTID, PARAM_CONTACTID, default(int))]
                              public virtual int ContactID  { get; set; }	      
        
	    [Column( COL_DEMOGRAPHICS, PARAM_DEMOGRAPHICS )]
                              public virtual System.Xml.XmlDocument Demographics  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.CustomerID = (int)reader[COL_CUSTOMERID];
			this.ContactID = (int)reader[COL_CONTACTID];
			this.Demographics = (System.Xml.XmlDocument)reader[COL_DEMOGRAPHICS];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_INDIVIDUAL))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));
				command.Parameters.Add(dataContext.CreateParameter(this.ContactID, PARAM_CONTACTID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Demographics), PARAM_DEMOGRAPHICS));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_INDIVIDUAL))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));
				command.Parameters.Add(dataContext.CreateParameter(this.ContactID, PARAM_CONTACTID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Demographics), PARAM_DEMOGRAPHICS));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_INDIVIDUAL))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.CustomerID, PARAM_CUSTOMERID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
