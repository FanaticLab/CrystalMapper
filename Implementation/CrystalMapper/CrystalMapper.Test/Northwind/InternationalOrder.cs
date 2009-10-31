/*
 * Author: CrystalMapper
 * 
 * Date:  Sunday, November 01, 2009 2:37 AM
 * 
 * Class: InternationalOrder
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

namespace Northwind
{
	[Table(TABLE_NAME)]
    public partial class InternationalOrder : Entity< InternationalOrder>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "InternationalOrders";	
     
		public const string COL_ORDERID = "OrderID";
		public const string COL_CUSTOMSDESCRIPTION = "CustomsDescription";
		public const string COL_EXCISETAX = "ExciseTax";
		
        public const string PARAM_ORDERID = ":OrderID";	
        public const string PARAM_CUSTOMSDESCRIPTION = ":CustomsDescription";	
        public const string PARAM_EXCISETAX = ":ExciseTax";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_INTERNATIONALORDERS = "INSERT INTO InternationalOrders([OrderID],[CustomsDescription],[ExciseTax]) VALUES (:OrderID,:CustomsDescription,:ExciseTax);"  ;
		
		private const string SQL_UPDATE_INTERNATIONALORDERS = "UPDATE InternationalOrders SET [CustomsDescription] = :CustomsDescription, [ExciseTax] = :ExciseTax,  WHERE [OrderID] = :OrderID";
		
		private const string SQL_DELETE_INTERNATIONALORDERS = "DELETE FROM InternationalOrders WHERE  [OrderID] = :OrderID ";
		
        #endregion
        
        #region Properties	
		
		[Column( COL_ORDERID, PARAM_ORDERID, default(long))]
                              public virtual long OrderID  { get; set; }		
		
        
	    [Column( COL_CUSTOMSDESCRIPTION, PARAM_CUSTOMSDESCRIPTION )]
                              public virtual string CustomsDescription  { get; set; }	      
        
	    [Column( COL_EXCISETAX, PARAM_EXCISETAX, typeof(decimal))]
                              public virtual decimal ExciseTax  { get; set; }	      
        
        #endregion        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.OrderID = (long)reader[COL_ORDERID];
			this.CustomsDescription = (string)reader[COL_CUSTOMSDESCRIPTION];
			this.ExciseTax = (decimal)reader[COL_EXCISETAX];
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_INTERNATIONALORDERS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(this.OrderID, PARAM_ORDERID));
				command.Parameters.Add(dataContext.CreateParameter(this.CustomsDescription, PARAM_CUSTOMSDESCRIPTION));
				command.Parameters.Add(dataContext.CreateParameter(this.ExciseTax, PARAM_EXCISETAX));
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_INTERNATIONALORDERS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.OrderID, PARAM_ORDERID));
				command.Parameters.Add(dataContext.CreateParameter(this.CustomsDescription, PARAM_CUSTOMSDESCRIPTION));
				command.Parameters.Add(dataContext.CreateParameter(this.ExciseTax, PARAM_EXCISETAX));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_INTERNATIONALORDERS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.OrderID, PARAM_ORDERID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        
        
        
        #endregion
    }
}
