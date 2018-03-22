/*********************************************************************
 * Author: CrystalMapper (Generated)
 * Date:  Saturday, March 30, 2013 6:24 PM
 * Project: http://www.fanaticlab.com/projects/crystalmapper/
 * Copyright (c) 2013 FanaticLab
 *********************************************************************/

using System;
using System.Linq;
using System.Data.Common;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;

using CoreSystem.Data;

using CrystalMapper;
using CrystalMapper.Linq;
using CrystalMapper.Context;
using CrystalMapper.Mapping;

namespace CrystalMapper.Test.Northwind
{
    [Table(TABLE_NAME)]
    public partial class Order
    {
        #region Table Schema

        public const string TABLE_NAME = "Orders";

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

        private const string SQL_INSERT_ORDERS = "INSERT INTO Orders ( [CustomerID], [EmployeeID], [OrderDate], [RequiredDate], [ShippedDate], [ShipVia], [Freight], [ShipName], [ShipAddress], [ShipCity], [ShipRegion], [ShipPostalCode], [ShipCountry]) VALUES ( @CustomerID, @EmployeeID, @OrderDate, @RequiredDate, @ShippedDate, @ShipVia, @Freight, @ShipName, @ShipAddress, @ShipCity, @ShipRegion, @ShipPostalCode, @ShipCountry);" + " SELECT SCOPE_IDENTITY();";

        private const string SQL_UPDATE_ORDERS = "UPDATE Orders SET [CustomerID] = @CustomerID, [EmployeeID] = @EmployeeID, [OrderDate] = @OrderDate, [RequiredDate] = @RequiredDate, [ShippedDate] = @ShippedDate, [ShipVia] = @ShipVia, [Freight] = @Freight, [ShipName] = @ShipName, [ShipAddress] = @ShipAddress, [ShipCity] = @ShipCity, [ShipRegion] = @ShipRegion, [ShipPostalCode] = @ShipPostalCode, [ShipCountry] = @ShipCountry WHERE [OrderID] = @OrderID";

        private const string SQL_DELETE_ORDERS = "DELETE FROM Orders WHERE  [OrderID] = @OrderID ";

        #endregion

        #region Declarations

        protected long orderid = default(int);

        protected string customerid = default(string);

        protected long? employeeid = default(int?);

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


        private event PropertyChangingEventHandler propertyChanging;

        private event PropertyChangedEventHandler propertyChanged;
        #endregion




        [Column(COL_ORDERID, PARAM_ORDERID, default(int))]
        public virtual long OrderID { get; set; }

        [Column(COL_ORDERDATE, PARAM_ORDERDATE)]
        public virtual System.DateTime? OrderDate { get; set; }

        [Column(COL_REQUIREDDATE, PARAM_REQUIREDDATE)]
        public virtual System.DateTime? RequiredDate { get; set; }


        [Column(COL_SHIPPEDDATE, PARAM_SHIPPEDDATE)]
        public virtual System.DateTime? ShippedDate { get; set; }

        [Column(COL_FREIGHT, PARAM_FREIGHT)]
        public virtual decimal? Freight { get; set; }

        [Column(COL_SHIPNAME, PARAM_SHIPNAME)]
        public virtual string ShipName { get; set; }

        [Column(COL_SHIPADDRESS, PARAM_SHIPADDRESS)]
        public virtual string ShipAddress { get; set; }

        [Column(COL_SHIPCITY, PARAM_SHIPCITY)]
        public virtual string ShipCity { get; set; }

        [Column(COL_SHIPREGION, PARAM_SHIPREGION)]
        public virtual string ShipRegion { get; set; }

        [Column(COL_SHIPPOSTALCODE, PARAM_SHIPPOSTALCODE)]
        public virtual string ShipPostalCode { get; set; }

        [Column(COL_SHIPCOUNTRY, PARAM_SHIPCOUNTRY)]
        public virtual string ShipCountry { get; set; }

        [Column(COL_CUSTOMERID, PARAM_CUSTOMERID)]
        public virtual string CustomerID { get; set; }

        [Column(COL_EMPLOYEEID, PARAM_EMPLOYEEID)]
        public virtual long? EmployeeID { get; set; }


        public Customer CustomerRef
        {
            get
            {


                return this.customerRef;
            }
            set
            {
                if (this.customerRef != value)
                {
                    this.OnPropertyChanging("CustomerRef");

                    this.customerid = (this.customerRef = value) != null ? this.customerRef.CustomerID : default(string);

                    this.OnPropertyChanged("CustomerRef");
                }
            }
        }

        public Employee EmployeeRef
        {
            get
            {


                return this.employeeRef;
            }
            set
            {
                if (this.employeeRef != value)
                {
                    this.OnPropertyChanging("EmployeeRef");

                    this.employeeid = (this.employeeRef = value) != null ? this.employeeRef.EmployeeID : default(int);

                    this.OnPropertyChanged("EmployeeRef");
                }
            }
        }





        #region Methods

        public override bool Equals(object obj)
        {
            Order record = obj as Order;

            return (object.ReferenceEquals(this, record)
                    || (record != null
                        && this.OrderID == record.OrderID
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

        protected virtual void OnPropertyChanging(string propertyName)
        {
            if (this.propertyChanging != null)
                this.propertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.propertyChanged != null)
                this.propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}