/*
 * Author: CrystalMapper 
 * 
 * Date:  Wednesday, March 10, 2010 9:38 PM
 * 
 * Class: Order
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
using CrystalMapper.Generic;
using CrystalMapper.Generic.Collection;

namespace CrystalMapper.UnitTest.Northwind
{
    [Table(TABLE_NAME)]
    public partial class Order : Entity<Order>
    {
        #region Table Schema

        public const string TABLE_NAME = "dbo.Orders";

        public const string COL_ORDERID = "OrderID";
        public const string COL_CUSTOMERID = "CustomerID";
        public const string COL_EMPLOYEEID = "EmployeeID";
        public const string COL_ORDERDATE = "OrderDate";
        public const string COL_REQUIREDDATE = "RequiredDate";
        public const string COL_SHIPPEDDATE = "ShippedDate";
        public const string COL_SHIPVIA = "ShipVia";
        public const string COL_FREIGHT = "Freight";
        public const string COL_SHIPNAME = "ShipName";
        public const string COL_SHIPADDRESS = "ShipAddress";
        public const string COL_SHIPCITY = "ShipCity";
        public const string COL_SHIPREGION = "ShipRegion";
        public const string COL_SHIPPOSTALCODE = "ShipPostalCode";
        public const string COL_SHIPCOUNTRY = "ShipCountry";

        public const string PARAM_ORDERID = "@OrderID";
        public const string PARAM_CUSTOMERID = "@CustomerID";
        public const string PARAM_EMPLOYEEID = "@EmployeeID";
        public const string PARAM_ORDERDATE = "@OrderDate";
        public const string PARAM_REQUIREDDATE = "@RequiredDate";
        public const string PARAM_SHIPPEDDATE = "@ShippedDate";
        public const string PARAM_SHIPVIA = "@ShipVia";
        public const string PARAM_FREIGHT = "@Freight";
        public const string PARAM_SHIPNAME = "@ShipName";
        public const string PARAM_SHIPADDRESS = "@ShipAddress";
        public const string PARAM_SHIPCITY = "@ShipCity";
        public const string PARAM_SHIPREGION = "@ShipRegion";
        public const string PARAM_SHIPPOSTALCODE = "@ShipPostalCode";
        public const string PARAM_SHIPCOUNTRY = "@ShipCountry";

        #endregion

        #region Queries

        private const string SQL_INSERT_ORDERS = "INSERT INTO dbo.Orders( [CustomerID], [EmployeeID], [OrderDate], [RequiredDate], [ShippedDate], [ShipVia], [Freight], [ShipName], [ShipAddress], [ShipCity], [ShipRegion], [ShipPostalCode], [ShipCountry]) VALUES ( @CustomerID, @EmployeeID, @OrderDate, @RequiredDate, @ShippedDate, @ShipVia, @Freight, @ShipName, @ShipAddress, @ShipCity, @ShipRegion, @ShipPostalCode, @ShipCountry);" + "SELECT SCOPE_IDENTITY();";

        private const string SQL_UPDATE_ORDERS = "UPDATE dbo.Orders SET  [CustomerID] = @CustomerID, [EmployeeID] = @EmployeeID, [OrderDate] = @OrderDate, [RequiredDate] = @RequiredDate, [ShippedDate] = @ShippedDate, [ShipVia] = @ShipVia, [Freight] = @Freight, [ShipName] = @ShipName, [ShipAddress] = @ShipAddress, [ShipCity] = @ShipCity, [ShipRegion] = @ShipRegion, [ShipPostalCode] = @ShipPostalCode, [ShipCountry] = @ShipCountry WHERE [OrderID] = @OrderID";

        private const string SQL_DELETE_ORDERS = "DELETE FROM dbo.Orders WHERE  [OrderID] = @OrderID ";

        #endregion

        #region Declarations

        protected int orderid = default(int);

        protected string customerid = default(string);

        protected int? employeeid = default(int?);

        protected System.DateTime? orderdate = default(System.DateTime?);

        protected System.DateTime? requireddate = default(System.DateTime?);

        protected System.DateTime? shippeddate = default(System.DateTime?);

        protected int? shipvium = default(int?);

        protected decimal? freight = default(decimal?);

        protected string shipname = default(string);

        protected string shipaddress = default(string);

        protected string shipcity = default(string);

        protected string shipregion = default(string);

        protected string shippostalcode = default(string);

        protected string shipcountry = default(string);

        protected Customer customerRef;

        protected Employee employeeRef;

        protected Shipper shipperRef;

        protected EntityCollection<OrderDetail> orderDetails;

        #endregion

        #region Properties

        [Column(COL_ORDERID, PARAM_ORDERID, default(int))]
        public virtual int OrderID
        {
            get { return this.orderid; }
            set
            {
                if (this.orderid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("OrderID"));
                    this.orderid = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("OrderID"));
                }
            }
        }

        [Column(COL_ORDERDATE, PARAM_ORDERDATE)]
        public virtual System.DateTime? OrderDate
        {
            get { return this.orderdate; }
            set
            {
                if (this.orderdate != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("OrderDate"));
                    this.orderdate = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("OrderDate"));
                }
            }
        }

        [Column(COL_REQUIREDDATE, PARAM_REQUIREDDATE)]
        public virtual System.DateTime? RequiredDate
        {
            get { return this.requireddate; }
            set
            {
                if (this.requireddate != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("RequiredDate"));
                    this.requireddate = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("RequiredDate"));
                }
            }
        }

        [Column(COL_SHIPPEDDATE, PARAM_SHIPPEDDATE)]
        public virtual System.DateTime? ShippedDate
        {
            get { return this.shippeddate; }
            set
            {
                if (this.shippeddate != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ShippedDate"));
                    this.shippeddate = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ShippedDate"));
                }
            }
        }

        [Column(COL_FREIGHT, PARAM_FREIGHT)]
        public virtual decimal? Freight
        {
            get { return this.freight; }
            set
            {
                if (this.freight != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("Freight"));
                    this.freight = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("Freight"));
                }
            }
        }

        [Column(COL_SHIPNAME, PARAM_SHIPNAME)]
        public virtual string ShipName
        {
            get { return this.shipname; }
            set
            {
                if (this.shipname != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ShipName"));
                    this.shipname = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ShipName"));
                }
            }
        }

        [Column(COL_SHIPADDRESS, PARAM_SHIPADDRESS)]
        public virtual string ShipAddress
        {
            get { return this.shipaddress; }
            set
            {
                if (this.shipaddress != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ShipAddress"));
                    this.shipaddress = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ShipAddress"));
                }
            }
        }

        [Column(COL_SHIPCITY, PARAM_SHIPCITY)]
        public virtual string ShipCity
        {
            get { return this.shipcity; }
            set
            {
                if (this.shipcity != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ShipCity"));
                    this.shipcity = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ShipCity"));
                }
            }
        }

        [Column(COL_SHIPREGION, PARAM_SHIPREGION)]
        public virtual string ShipRegion
        {
            get { return this.shipregion; }
            set
            {
                if (this.shipregion != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ShipRegion"));
                    this.shipregion = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ShipRegion"));
                }
            }
        }

        [Column(COL_SHIPPOSTALCODE, PARAM_SHIPPOSTALCODE)]
        public virtual string ShipPostalCode
        {
            get { return this.shippostalcode; }
            set
            {
                if (this.shippostalcode != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ShipPostalCode"));
                    this.shippostalcode = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ShipPostalCode"));
                }
            }
        }

        [Column(COL_SHIPCOUNTRY, PARAM_SHIPCOUNTRY)]
        public virtual string ShipCountry
        {
            get { return this.shipcountry; }
            set
            {
                if (this.shipcountry != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ShipCountry"));
                    this.shipcountry = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ShipCountry"));
                }
            }
        }

        [Column(COL_CUSTOMERID, PARAM_CUSTOMERID)]
        public virtual string CustomerID
        {
            get
            {
                if (this.customerRef == null)
                    return this.customerid;

                return this.customerRef.CustomerID;
            }
            set
            {
                if (this.customerid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("CustomerID"));
                    this.customerid = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("CustomerID"));

                    this.customerRef = null;
                }
            }
        }

        [Column(COL_EMPLOYEEID, PARAM_EMPLOYEEID)]
        public virtual int? EmployeeID
        {
            get
            {
                if (this.employeeRef == null)
                    return this.employeeid;

                return this.employeeRef.EmployeeID;
            }
            set
            {
                if (this.employeeid != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("EmployeeID"));
                    this.employeeid = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("EmployeeID"));

                    this.employeeRef = null;
                }
            }
        }

        [Column(COL_SHIPVIA, PARAM_SHIPVIA)]
        public virtual int? ShipVia
        {
            get
            {
                if (this.shipperRef == null)
                    return this.shipvium;

                return this.shipperRef.ShipperID;
            }
            set
            {
                if (this.shipvium != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ShipVia"));
                    this.shipvium = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ShipVia"));

                    this.shipperRef = null;
                }
            }
        }

        public Customer CustomerRef
        {
            get
            {
                if (this.customerRef == null
                   && this.customerid != default(string))
                {
                    Customer customerQuery = new Customer
                    {
                        CustomerID = this.customerid
                    };

                    Customer[] customers = customerQuery.ToList();
                    if (customers.Length == 1)
                        this.customerRef = customers[0];
                }

                return this.customerRef;
            }
            set
            {
                if (this.customerRef != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("CustomerRef"));
                    if (this.customerRef != null)
                        this.Parents.Remove(this.customerRef);

                    if ((this.customerRef = value) != null)
                    {
                        this.Parents.Add(this.customerRef);
                        this.customerid = this.customerRef.CustomerID;
                    }
                    else
                    {
                        this.customerid = default(string);
                    }
                    this.OnPropertyChanged(new PropertyChangedEventArgs("CustomerRef"));
                }
            }
        }

        public Employee EmployeeRef
        {
            get
            {
                if (this.employeeRef == null
                   && this.employeeid.HasValue)
                {
                    Employee employeeQuery = new Employee
                    {
                        EmployeeID = this.employeeid.Value
                    };

                    Employee[] employees = employeeQuery.ToList();
                    if (employees.Length == 1)
                        this.employeeRef = employees[0];
                }

                return this.employeeRef;
            }
            set
            {
                if (this.employeeRef != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("EmployeeRef"));
                    if (this.employeeRef != null)
                        this.Parents.Remove(this.employeeRef);

                    if ((this.employeeRef = value) != null)
                    {
                        this.Parents.Add(this.employeeRef);
                        this.employeeid = this.employeeRef.EmployeeID;
                    }
                    else
                    {
                        this.employeeid = default(int);
                    }
                    this.OnPropertyChanged(new PropertyChangedEventArgs("EmployeeRef"));
                }
            }
        }

        public Shipper ShipperRef
        {
            get
            {
                if (this.shipperRef == null
                   && this.shipvium.HasValue)
                {
                    Shipper shipperQuery = new Shipper
                    {
                        ShipperID = this.shipvium.Value
                    };

                    Shipper[] shippers = shipperQuery.ToList();
                    if (shippers.Length == 1)
                        this.shipperRef = shippers[0];
                }

                return this.shipperRef;
            }
            set
            {
                if (this.shipperRef != value)
                {
                    this.OnPropertyChanging(new PropertyChangingEventArgs("ShipperRef"));
                    if (this.shipperRef != null)
                        this.Parents.Remove(this.shipperRef);

                    if ((this.shipperRef = value) != null)
                    {
                        this.Parents.Add(this.shipperRef);
                        this.shipvium = this.shipperRef.ShipperID;
                    }
                    else
                    {
                        this.shipvium = default(int);
                    }
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ShipperRef"));
                }
            }
        }

        public EntityCollection<OrderDetail> OrderDetails
        {
            get { return this.orderDetails; }
        }


        #endregion

        #region Methods

        public Order()
        {
            this.orderDetails = new EntityCollection<OrderDetail>(this, new Associate<OrderDetail>(this.AssociateOrderDetails), new DeAssociate<OrderDetail>(this.DeAssociateOrderDetails), new GetChildren<OrderDetail>(this.GetChildrenOrderDetails));
        }

        public override bool Equals(object obj)
        {
            Order entity = obj as Order;

            return (
                    object.ReferenceEquals(this, entity)
                    || (
                        entity != null
                        && this.OrderID == entity.OrderID
                        && this.OrderID != default(int)
                        )
                    );
        }

        public override int GetHashCode()
        {

            int hashCode = 7;

            hashCode = (11 * hashCode) + this.orderid.GetHashCode();

            return hashCode;
        }

        public override void Read(DbDataReader reader)
        {
            this.orderid = (int)reader[COL_ORDERID];
            this.customerid = DbConvert.ToString(reader[COL_CUSTOMERID]);
            this.employeeid = DbConvert.ToNullable<int>(reader[COL_EMPLOYEEID]);
            this.orderdate = DbConvert.ToNullable<System.DateTime>(reader[COL_ORDERDATE]);
            this.requireddate = DbConvert.ToNullable<System.DateTime>(reader[COL_REQUIREDDATE]);
            this.shippeddate = DbConvert.ToNullable<System.DateTime>(reader[COL_SHIPPEDDATE]);
            this.shipvium = DbConvert.ToNullable<int>(reader[COL_SHIPVIA]);
            this.freight = DbConvert.ToNullable<decimal>(reader[COL_FREIGHT]);
            this.shipname = DbConvert.ToString(reader[COL_SHIPNAME]);
            this.shipaddress = DbConvert.ToString(reader[COL_SHIPADDRESS]);
            this.shipcity = DbConvert.ToString(reader[COL_SHIPCITY]);
            this.shipregion = DbConvert.ToString(reader[COL_SHIPREGION]);
            this.shippostalcode = DbConvert.ToString(reader[COL_SHIPPOSTALCODE]);
            this.shipcountry = DbConvert.ToString(reader[COL_SHIPCOUNTRY]);
            base.Read(reader);
        }

        public override bool Create(DataContext dataContext)
        {
            using (DbCommand command = dataContext.CreateCommand(SQL_INSERT_ORDERS))
            {
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CustomerID), PARAM_CUSTOMERID));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EmployeeID), PARAM_EMPLOYEEID));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.OrderDate), PARAM_ORDERDATE));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.RequiredDate), PARAM_REQUIREDDATE));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShippedDate), PARAM_SHIPPEDDATE));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipVia), PARAM_SHIPVIA));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.Freight), PARAM_FREIGHT));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipName), PARAM_SHIPNAME));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipAddress), PARAM_SHIPADDRESS));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipCity), PARAM_SHIPCITY));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipRegion), PARAM_SHIPREGION));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipPostalCode), PARAM_SHIPPOSTALCODE));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipCountry), PARAM_SHIPCOUNTRY));
                this.OrderID = Convert.ToInt32(command.ExecuteScalar());
                return true;
            }
        }

        public override bool Update(DataContext dataContext)
        {
            using (DbCommand command = dataContext.CreateCommand(SQL_UPDATE_ORDERS))
            {
                command.Parameters.Add(dataContext.CreateParameter(this.OrderID, PARAM_ORDERID));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.CustomerID), PARAM_CUSTOMERID));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.EmployeeID), PARAM_EMPLOYEEID));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.OrderDate), PARAM_ORDERDATE));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.RequiredDate), PARAM_REQUIREDDATE));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShippedDate), PARAM_SHIPPEDDATE));
                command.Parameters.Add(dataContext.CreateParameter(DbConvert.DbValue(this.ShipVia), PARAM_SHIPVIA));
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
            using (DbCommand command = dataContext.CreateCommand(SQL_DELETE_ORDERS))
            {
                command.Parameters.Add(dataContext.CreateParameter(this.OrderID, PARAM_ORDERID));
                return (command.ExecuteNonQuery() == 1);
            }
        }

        #endregion

        #region Entity Relationship Functions

        private void AssociateOrderDetails(OrderDetail orderDetail)
        {
            orderDetail.OrderRef = this;
        }

        private void DeAssociateOrderDetails(OrderDetail orderDetail)
        {
            if (orderDetail.OrderRef == this)
                orderDetail.OrderRef = null;
        }


        private OrderDetail[] GetChildrenOrderDetails()
        {
            if (this.orderid != default(int))
            {
                OrderDetail childrenQuery = new OrderDetail();
                childrenQuery.OrderRef = this;

                return childrenQuery.ToList();
            }
            else return null;
        }

        #endregion
    }
}
