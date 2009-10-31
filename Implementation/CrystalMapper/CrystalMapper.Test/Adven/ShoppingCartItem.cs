/*
 * Author: CrystalMapper
 * 
 * Date:  Saturday, October 31, 2009 10:51 PM
 * 
 * Class: ShoppingCartItem
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
    public partial class ShoppingCartItem : Entity< ShoppingCartItem>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Sales.ShoppingCartItem";	
     
		public const string COL_SHOPPINGCARTITEMID = "ShoppingCartItemID";
		public const string COL_SHOPPINGCARTID = "ShoppingCartID";
		public const string COL_QUANTITY = "Quantity";
		public const string COL_PRODUCTID = "ProductID";
		public const string COL_DATECREATED = "DateCreated";
		public const string COL_MODIFIEDDATE = "ModifiedDate";
		
        public const string PARAM_SHOPPINGCARTITEMID = "@ShoppingCartItemID";	
        public const string PARAM_SHOPPINGCARTID = "@ShoppingCartID";	
        public const string PARAM_QUANTITY = "@Quantity";	
        public const string PARAM_PRODUCTID = "@ProductID";	
        public const string PARAM_DATECREATED = "@DateCreated";	
        public const string PARAM_MODIFIEDDATE = "@ModifiedDate";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_SHOPPINGCARTITEM = "INSERT INTO Sales.ShoppingCartItem([ShoppingCartID],[Quantity],[ProductID],[DateCreated],[ModifiedDate]) VALUES (@ShoppingCartID,@Quantity,@ProductID,@DateCreated,@ModifiedDate);";
		
		private const string SQL_UPDATE_SHOPPINGCARTITEM = "UPDATE Sales.ShoppingCartItem SET [ShoppingCartID] = @ShoppingCartID, [Quantity] = @Quantity, [ProductID] = @ProductID, [DateCreated] = @DateCreated, [ModifiedDate] = @ModifiedDate,  WHERE [ShoppingCartItemID] = @ShoppingCartItemID";
		
		private const string SQL_DELETE_SHOPPINGCARTITEM = "DELETE FROM Sales.ShoppingCartItem WHERE  [ShoppingCartItemID] = @ShoppingCartItemID ";
		
        #endregion
        #region Properties	
		
		[Column( COL_SHOPPINGCARTITEMID, PARAM_SHOPPINGCARTITEMID, default(int))]
                              public virtual int ShoppingCartItemID  { get; set; }		
		
        
	    [Column( COL_SHOPPINGCARTID, PARAM_SHOPPINGCARTID )]
                              public virtual string ShoppingCartID  { get; set; }	      
        
	    [Column( COL_QUANTITY, PARAM_QUANTITY, default(int))]
                              public virtual int Quantity  { get; set; }	      
        
	    [Column( COL_PRODUCTID, PARAM_PRODUCTID, default(int))]
                              public virtual int ProductID  { get; set; }	      
        
	    [Column( COL_DATECREATED, PARAM_DATECREATED, typeof(System.DateTime))]
                              public virtual System.DateTime DateCreated  { get; set; }	      
        
	    [Column( COL_MODIFIEDDATE, PARAM_MODIFIEDDATE, typeof(System.DateTime))]
                              public virtual System.DateTime ModifiedDate  { get; set; }	      
        
        
        
        
        #endregion
        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.ShoppingCartItemID = (int)reader[COL_SHOPPINGCARTITEMID];
			this.ShoppingCartID = (string)reader[COL_SHOPPINGCARTID];
			this.Quantity = (int)reader[COL_QUANTITY];
			this.ProductID = (int)reader[COL_PRODUCTID];
			this.DateCreated = (System.DateTime)reader[COL_DATECREATED];
			this.ModifiedDate = (System.DateTime)reader[COL_MODIFIEDDATE];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_SHOPPINGCARTITEM))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.ShoppingCartID, PARAM_SHOPPINGCARTID));
				command.Parameters.Add(dataContext.CreateParameter(this.Quantity, PARAM_QUANTITY));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.DateCreated, PARAM_DATECREATED));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
                if(command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT @@IDENTITY;";
                    this.ShoppingCartItemID = Convert.ToInt32(command.ExecuteScalar());
                    return true;
                }
                return false;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_SHOPPINGCARTITEM))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ShoppingCartItemID, PARAM_SHOPPINGCARTITEMID));
				command.Parameters.Add(dataContext.CreateParameter(this.ShoppingCartID, PARAM_SHOPPINGCARTID));
				command.Parameters.Add(dataContext.CreateParameter(this.Quantity, PARAM_QUANTITY));
				command.Parameters.Add(dataContext.CreateParameter(this.ProductID, PARAM_PRODUCTID));
				command.Parameters.Add(dataContext.CreateParameter(this.DateCreated, PARAM_DATECREATED));
				command.Parameters.Add(dataContext.CreateParameter(this.ModifiedDate, PARAM_MODIFIEDDATE));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_SHOPPINGCARTITEM))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.ShoppingCartItemID, PARAM_SHOPPINGCARTITEMID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
