/*
 * Author: CrystalMapper
 * 
 * Date:  Sunday, November 01, 2009 2:37 AM
 * 
 * Class: Order
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
    public partial class Order : Entity< Order>
    {		
		#region Table Schema
		
        public const string TABLE_NAME = "Orders";	
     
		public const string COL_ORDERID = "OrderID";
		public const string COL_CUSTOMERID = "CustomerID";
		public const string COL_EMPLOYEEID = "EmployeeID";
		public const string COL_ORDERDATE = "OrderDate";
		public const string COL_REQUIREDDATE = "RequiredDate";
		public const string COL_SHIPPEDDATE = "ShippedDate";
		public const string COL_FREIGHT = "Freight";
		public const string COL_SHIPNAME = "ShipName";
		public const string COL_SHIPADDRESS = "ShipAddress";
		public const string COL_SHIPCITY = "ShipCity";
		public const string COL_SHIPREGION = "ShipRegion";
		public const string COL_SHIPPOSTALCODE = "ShipPostalCode";
		public const string COL_SHIPCOUNTRY = "ShipCountry";
		
        public const string PARAM_ORDERID = ":OrderID";	
        public const string PARAM_CUSTOMERID = ":CustomerID";	
        public const string PARAM_EMPLOYEEID = ":EmployeeID";	
        public const string PARAM_ORDERDATE = ":OrderDate";	
        public const string PARAM_REQUIREDDATE = ":RequiredDate";	
        public const string PARAM_SHIPPEDDATE = ":ShippedDate";	
        public const string PARAM_FREIGHT = ":Freight";	
        public const string PARAM_SHIPNAME = ":ShipName";	
        public const string PARAM_SHIPADDRESS = ":ShipAddress";	
        public const string PARAM_SHIPCITY = ":ShipCity";	
        public const string PARAM_SHIPREGION = ":ShipRegion";	
        public const string PARAM_SHIPPOSTALCODE = ":ShipPostalCode";	
        public const string PARAM_SHIPCOUNTRY = ":ShipCountry";	
		
        #endregion
		
		#region Queries
		
		private const string SQL_INSERT_ORDERS = "INSERT INTO Orders([CustomerID],[EmployeeID],[OrderDate],[RequiredDate],[ShippedDate],[Freight],[ShipName],[ShipAddress],[ShipCity],[ShipRegion],[ShipPostalCode],[ShipCountry]) VALUES (:CustomerID,:EmployeeID,:OrderDate,:RequiredDate,:ShippedDate,:Freight,:ShipName,:ShipAddress,:ShipCity,:ShipRegion,:ShipPostalCode,:ShipCountry);"   + "SELECT last_insert_rowid();" ;
		
		private const string SQL_UPDATE_ORDERS = "UPDATE Orders SET [CustomerID] = :CustomerID, [EmployeeID] = :EmployeeID, [OrderDate] = :OrderDate, [RequiredDate] = :RequiredDate, [ShippedDate] = :ShippedDate, [Freight] = :Freight, [ShipName] = :ShipName, [ShipAddress] = :ShipAddress, [ShipCity] = :ShipCity, [ShipRegion] = :ShipRegion, [ShipPostalCode] = :ShipPostalCode, [ShipCountry] = :ShipCountry,  WHERE [OrderID] = :OrderID";
		
		private const string SQL_DELETE_ORDERS = "DELETE FROM Orders WHERE  [OrderID] = :OrderID ";
		
        #endregion
        
        #region Properties	
		
		[Column( COL_ORDERID, PARAM_ORDERID, default(long))]
                              public virtual long OrderID  { get; set; }		
		
        
	    [Column( COL_CUSTOMERID, PARAM_CUSTOMERID )]
                              public virtual string CustomerID  { get; set; }	      
        
	    [Column( COL_EMPLOYEEID, PARAM_EMPLOYEEID )]
                              public virtual long? EmployeeID  { get; set; }	      
        
	    [Column( COL_ORDERDATE, PARAM_ORDERDATE )]
                              public virtual System.DateTime? OrderDate  { get; set; }	      
        
	    [Column( COL_REQUIREDDATE, PARAM_REQUIREDDATE )]
                              public virtual System.DateTime? RequiredDate  { get; set; }	      
        
	    [Column( COL_SHIPPEDDATE, PARAM_SHIPPEDDATE )]
                              public virtual System.DateTime? ShippedDate  { get; set; }	      
        
	    [Column( COL_FREIGHT, PARAM_FREIGHT )]
                              public virtual decimal? Freight  { get; set; }	      
        
	    [Column( COL_SHIPNAME, PARAM_SHIPNAME )]
                              public virtual string ShipName  { get; set; }	      
        
	    [Column( COL_SHIPADDRESS, PARAM_SHIPADDRESS )]
                              public virtual string ShipAddress  { get; set; }	      
        
	    [Column( COL_SHIPCITY, PARAM_SHIPCITY )]
                              public virtual string ShipCity  { get; set; }	      
        
	    [Column( COL_SHIPREGION, PARAM_SHIPREGION )]
                              public virtual string ShipRegion  { get; set; }	      
        
	    [Column( COL_SHIPPOSTALCODE, PARAM_SHIPPOSTALCODE )]
                              public virtual string ShipPostalCode  { get; set; }	      
        
	    [Column( COL_SHIPCOUNTRY, PARAM_SHIPCOUNTRY )]
                              public virtual string ShipCountry  { get; set; }	      
        
        public IEnumerable< InternationalOrder> InternationalOrders
        {
            get {
                  foreach(InternationalOrder internationalOrder in InternationalOrderList())
                    yield return internationalOrder; 
                }
        }
        
        public IEnumerable< OrderDetail> OrderDetails
        {
            get {
                  foreach(OrderDetail orderDetail in OrderDetailList())
                    yield return orderDetail; 
                }
        }
        
        #endregion        
        
        #region Methods     
		
		public override void Read(DbDataReader reader)
		{
			this.OrderID = (long)reader[COL_ORDERID];
			this.CustomerID = DbConvert.ToString(reader[COL_CUSTOMERID]);
			this.EmployeeID = DbConvert.ToNullable< long >(reader[COL_EMPLOYEEID]);
			this.OrderDate = DbConvert.ToNullable< System.DateTime >(reader[COL_ORDERDATE]);
			this.RequiredDate = DbConvert.ToNullable< System.DateTime >(reader[COL_REQUIREDDATE]);
			this.ShippedDate = DbConvert.ToNullable< System.DateTime >(reader[COL_SHIPPEDDATE]);
			this.Freight = DbConvert.ToNullable< decimal >(reader[COL_FREIGHT]);
			this.ShipName = DbConvert.ToString(reader[COL_SHIPNAME]);
			this.ShipAddress = DbConvert.ToString(reader[COL_SHIPADDRESS]);
			this.ShipCity = DbConvert.ToString(reader[COL_SHIPCITY]);
			this.ShipRegion = DbConvert.ToString(reader[COL_SHIPREGION]);
			this.ShipPostalCode = DbConvert.ToString(reader[COL_SHIPPOSTALCODE]);
			this.ShipCountry = DbConvert.ToString(reader[COL_SHIPCOUNTRY]);
		}
		
		public override bool Create(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_INSERT_ORDERS))
            {	
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CustomerID), PARAM_CUSTOMERID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EmployeeID), PARAM_EMPLOYEEID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.OrderDate), PARAM_ORDERDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.RequiredDate), PARAM_REQUIREDDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShippedDate), PARAM_SHIPPEDDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Freight), PARAM_FREIGHT));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipName), PARAM_SHIPNAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipAddress), PARAM_SHIPADDRESS));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipCity), PARAM_SHIPCITY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipRegion), PARAM_SHIPREGION));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipPostalCode), PARAM_SHIPPOSTALCODE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipCountry), PARAM_SHIPCOUNTRY));
                this.OrderID = Convert.ToInt64(command.ExecuteScalar());
                return true;                
            }
        }

		public override bool Update(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_UPDATE_ORDERS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.OrderID, PARAM_ORDERID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CustomerID), PARAM_CUSTOMERID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EmployeeID), PARAM_EMPLOYEEID));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.OrderDate), PARAM_ORDERDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.RequiredDate), PARAM_REQUIREDDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShippedDate), PARAM_SHIPPEDDATE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Freight), PARAM_FREIGHT));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipName), PARAM_SHIPNAME));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipAddress), PARAM_SHIPADDRESS));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipCity), PARAM_SHIPCITY));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipRegion), PARAM_SHIPREGION));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipPostalCode), PARAM_SHIPPOSTALCODE));
				command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipCountry), PARAM_SHIPCOUNTRY));
			
                return (command.ExecuteNonQuery() == 1);
            }
        }

		public override bool Delete(DataContext dataContext)
        {
            using(DbCommand command  = dataContext.CreateCommand(SQL_DELETE_ORDERS))
            {							
				command.Parameters.Add(dataContext.CreateParameter(this.OrderID, PARAM_ORDERID));				
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion
        
        #region Children
        
        public InternationalOrder GetInternationalOrdersQuery()
        {
            return new InternationalOrder {                
                                                                            OrderID = this.OrderID  
                                                                            };
        }
        
        public InternationalOrder[] InternationalOrderList()
        {
            return GetInternationalOrdersQuery().ToList();
        }  
        
        public OrderDetail GetOrderDetailsQuery()
        {
            return new OrderDetail {                
                                                                            OrderID = this.OrderID  
                                                                            };
        }
        
        public OrderDetail[] OrderDetailList()
        {
            return GetOrderDetailsQuery().ToList();
        }  
        
        
        
        
        #endregion
    }
}
