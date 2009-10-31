/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:50 PM
 * 
 * Class: ProductListPriceHistory
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
    public partial class ProductListPriceHistory : Entity< ProductListPriceHistory>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Production.ProductListPriceHistory";	
     
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_STARTDATE = "StartDate";
		public const string COL_ENDDATE = "EndDate";
		public const string COL_LISTPRICE = "ListPrice";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_STARTDATE = "@StartDate";	
        public const string PARAM_ENDDATE = "@EndDate";	
        public const string PARAM_LISTPRICE = "@ListPrice";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_PRODUCTLISTPRICEHISTORY = "INSERT INTO Production.ProductListPriceHistory([ProductID],[StartDate],[EndDate],[ListPrice],[ModifiedDate]) VALUES (@ProductID,@StartDate,@EndDate,@ListPrice,@ModifiedDate);";
		
		private const string SQL_UPDATE_PRODUCTLISTPRICEHISTORY = "UPDATE Production.ProductListPriceHistory SET [EndDate] = @EndDate, [ListPrice] = @ListPrice, [ModifiedDate] = @ModifiedDate,  WHERE [ProductID] = @ProductID AND [StartDate] = @StartDate";
		
		private const string SQL_DELETE_PRODUCTLISTPRICEHISTORY = "DELETE FROM Production.ProductListPriceHistory WHERE  [ProductID] = @ProductID AND [StartDate] = @StartDate ";
		
        #endregion
        #region Properties	
		
		[Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID  { get; set; }		
		[Column( COL_STARTDATE, PARAM_STARTDATE, typeof(System.DateTime))]
                              public virtual System.DateTime StartDate  { get; set; }		
		
        
	    [Column( COL_ENDDATE, PARAM_ENDDATE )]
                              public virtual System.DateTime? EndDate  { get; set; }	      
        
	    [Column( COL_LISTPRICE, PARAM_LISTPRICE, typeof(decimal))]
                              public virtual decimal ListPrice  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.ProductID = (int)reader[COL_PRODUCTID];
			this.StartDate = (System.DateTime)reader[COL_STARTDATE];
			this.EndDate = DbConvert.ToNullable< System.DateTime >(reader[COL_ENDDATE]);
			this.ListPrice = (decimal)reader[COL_LISTPRICE];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_PRODUCTLISTPRICEHISTORY))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EndDate), PARAM_ENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.ListPrice, PARAM_LISTPRICE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_PRODUCTLISTPRICEHISTORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EndDate), PARAM_ENDDATE));
				command.Parameters.Add(dataContext.CreateParameter(this.ListPrice, PARAM_LISTPRICE));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_PRODUCTLISTPRICEHISTORY))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));				
				command.Parameters.Add(dataContext.CreateParameter(this.StartDate, PARAM_STARTDATE));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
