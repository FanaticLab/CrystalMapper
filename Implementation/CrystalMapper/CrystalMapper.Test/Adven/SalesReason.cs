/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:51 PM
 * 
 * Class: SalesReason
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
    public partial class SalesReason : Entity< SalesReason>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.SalesReason";	
     
		public const string COL_SALESREASONID = "SalesReasonID";
		public const string COL_NAME = "Name";
		public const string COL_REASONTYPE = "ReasonType";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SALESREASONID = "@SalesReasonID";	
        public const string PARAM_NAME = "@Name";	
        public const string PARAM_REASONTYPE = "@ReasonType";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SALESREASON = "INSERT INTO Sales.SalesReason([Name],[ReasonType],[ModifiedDate]) VALUES (@Name,@ReasonType,@ModifiedDate);";
		
		private const string SQL_UPDATE_SALESREASON = "UPDATE Sales.SalesReason SET [Name] = @Name, [ReasonType] = @ReasonType, [ModifiedDate] = @ModifiedDate,  WHERE [SalesReasonID] = @SalesReasonID";
		
		private const string SQL_DELETE_SALESREASON = "DELETE FROM Sales.SalesReason WHERE  [SalesReasonID] = @SalesReasonID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_SALESREASONID, PARAM_SALESREASONID, default(int))]
                              public virtual int SalesReasonID  { get; set; }		
		
        
	    [Column( COL_NAME, PARAM_NAME )]
                              public virtual string Name  { get; set; }	      
        
	    [Column( COL_REASONTYPE, PARAM_REASONTYPE )]
                              public virtual string ReasonType  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons
        {
            get {
                  foreach(SalesOrderHeaderSalesReason salesOrderHeaderSalesReason in SalesOrderHeaderSalesReasonList())
                    yield return salesOrderHeaderSalesReason; 
                }
        }
        
        
        public IEnumerable< SalesOrderHeader> SalesOrderHeaders
        {
            get {           
                
                foreach(SalesOrderHeader salesOrderHeader in SalesOrderHeaderList())
                    yield return salesOrderHeader; 
                }         
        }    
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.SalesReasonID = (int)reader[COL_SALESREASONID];
			this.Name = (string)reader[COL_NAME];
			this.ReasonType = (string)reader[COL_REASONTYPE];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SALESREASON))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ReasonType, PARAM_REASONTYPE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.SalesReasonID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SALESREASON))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SalesReasonID, PARAM_SALESREASONID));
				command.Parameters.Add(dataContext.CreateParameter(this.Name, PARAM_NAME));
				command.Parameters.Add(dataContext.CreateParameter(this.ReasonType, PARAM_REASONTYPE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SALESREASON))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SalesReasonID, PARAM_SALESREASONID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public SalesOrderHeaderSalesReason GetSalesOrderHeaderSalesReasonsQuery()
        {
            return new SalesOrderHeaderSalesReason {                
                                                                            SalesReasonID = this.SalesReasonID  
                                                                            };
        }
        
        public SalesOrderHeaderSalesReason[] SalesOrderHeaderSalesReasonList()
        {
            return GetSalesOrderHeaderSalesReasonsQuery().ToList();
        }  
        
        
        
        public SalesOrderHeader[] SalesOrderHeaderList()
        {
            string sqlQuery = @"SELECT Sales.SalesOrderHeader.*
                                FROM Sales.SalesOrderHeaderSalesReason
                                INNER JOIN Sales.SalesOrderHeader ON                                                                            
                                Sales.SalesOrderHeaderSalesReason.[SalesOrderID] = Sales.SalesOrderHeader.[SalesOrderID] AND
                                Sales.SalesOrderHeaderSalesReason.[SalesReasonID] = @SalesReasonID  
                                ";
                                
            Dictionary<string, object> parameterValues = new Dictionary<string, object>();
            parameterValues.Add(PARAM_SALESREASONID, this.SalesReasonID);
            
            return SalesOrderHeader.ToList(sqlQuery, parameterValues);
            
        }    
        
        #endregion
    }
}
