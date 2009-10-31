/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:51 PM
 * 
 * Class: SpecialOfferProduct
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
    public partial class SpecialOfferProduct : Entity< SpecialOfferProduct>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.SpecialOfferProduct";	
     
		public const string COL_SPECIALOFFERID = "SpecialOfferID";
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_ROWGUID = "rowguid";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SPECIALOFFERID = "@SpecialOfferID";	
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_ROWGUID = "@rowguid";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SPECIALOFFERPRODUCT = "INSERT INTO Sales.SpecialOfferProduct([SpecialOfferID],[ProductID],[rowguid],[ModifiedDate]) VALUES (@SpecialOfferID,@ProductID,@rowguid,@ModifiedDate);";
		
		private const string SQL_UPDATE_SPECIALOFFERPRODUCT = "UPDATE Sales.SpecialOfferProduct SET [rowguid] = @rowguid, [ModifiedDate] = @ModifiedDate,  WHERE [SpecialOfferID] = @SpecialOfferID AND [ProductID] = @ProductID";
		
		private const string SQL_DELETE_SPECIALOFFERPRODUCT = "DELETE FROM Sales.SpecialOfferProduct WHERE  [SpecialOfferID] = @SpecialOfferID AND [ProductID] = @ProductID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_SPECIALOFFERID, PARAM_SPECIALOFFERID, default(int))]
                              public virtual int SpecialOfferID  { get; set; }		
		[Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID  { get; set; }		
		
        
	    [Column( COL_ROWGUID, PARAM_ROWGUID, typeof(System.Guid))]
                              public virtual System.Guid Rowguid  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        public IEnumerable< SalesOrderDetail> SalesOrderDetails
        {
            get {
                  foreach(SalesOrderDetail salesOrderDetail in SalesOrderDetailList())
                    yield return salesOrderDetail; 
                }
        }
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.SpecialOfferID = (int)reader[COL_SPECIALOFFERID];
			this.ProductID = (int)reader[COL_PRODUCTID];
			this.Rowguid = (System.Guid)reader[COL_ROWGUID];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SPECIALOFFERPRODUCT))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.SpecialOfferID, PARAM_SPECIALOFFERID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SPECIALOFFERPRODUCT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SpecialOfferID, PARAM_SPECIALOFFERID));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.Rowguid, PARAM_ROWGUID));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SPECIALOFFERPRODUCT))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.SpecialOfferID, PARAM_SPECIALOFFERID));				
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public SalesOrderDetail GetSalesOrderDetailsQuery()
        {
            return new SalesOrderDetail {                
                                                                            SpecialOfferID = this.SpecialOfferID   , 
                                                                            ProductID = this.ProductID  
                                                                            };
        }
        
        public SalesOrderDetail[] SalesOrderDetailList()
        {
            return GetSalesOrderDetailsQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
