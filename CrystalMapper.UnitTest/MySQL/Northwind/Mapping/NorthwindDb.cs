/*****************************************************************
 * Author: CrystalMapper (Generated)
 * Date:  Monday, April 01, 2013 8:37 PM
 * Project: http://crystalmapper.codeplex.com
 * Copyright (c) 2013 FanaticLab
 *****************************************************************/

using System;
using System.Linq;
using CrystalMapper.Context;

namespace CrystalMapper.UnitTest.MySQL.Northwind
{
    /// <summary>
    /// Query provider for "northwind" database
    /// </summary>
    public partial class NorthwindDb : DbContext
    {
        /// <summary>
        /// Static instance of "northwind" database
        /// </summary>
        public static readonly NorthwindDb Context;

        static NorthwindDb()
        {
            Context = new NorthwindDb();
        }

        public NorthwindDb() : base("Northwind.MySQL") { }

        /// <summary>
        /// Queryable object for "categories"
        /// <summary>
        public IQueryable<Category> Categories
        {
            get { return this.Query<Category>(); }
        }

        /// <summary>
        /// Queryable object for "customers"
        /// <summary>
        public IQueryable<Customer> Customers
        {
            get { return this.Query<Customer>(); }
        }

        /// <summary>
        /// Queryable object for "customer_customer_demo"
        /// <summary>
        public IQueryable<CustomerCustomerDemo> CustomerCustomerDemos
        {
            get { return this.Query<CustomerCustomerDemo>(); }
        }

        /// <summary>
        /// Queryable object for "customer_demographics"
        /// <summary>
        public IQueryable<CustomerDemographic> CustomerDemographics
        {
            get { return this.Query<CustomerDemographic>(); }
        }

        /// <summary>
        /// Queryable object for "employees"
        /// <summary>
        public IQueryable<Employee> Employees
        {
            get { return this.Query<Employee>(); }
        }

        /// <summary>
        /// Queryable object for "employee_territories"
        /// <summary>
        public IQueryable<EmployeeTerritory> EmployeeTerritories
        {
            get { return this.Query<EmployeeTerritory>(); }
        }

        /// <summary>
        /// Queryable object for "order details"
        /// <summary>
        public IQueryable<OrderDetail> OrderDetails
        {
            get { return this.Query<OrderDetail>(); }
        }

        /// <summary>
        /// Queryable object for "orders"
        /// <summary>
        public IQueryable<Order> Orders
        {
            get { return this.Query<Order>(); }
        }

        /// <summary>
        /// Queryable object for "products"
        /// <summary>
        public IQueryable<Product> Products
        {
            get { return this.Query<Product>(); }
        }

        /// <summary>
        /// Queryable object for "region"
        /// <summary>
        public IQueryable<Region> Regions
        {
            get { return this.Query<Region>(); }
        }

        /// <summary>
        /// Queryable object for "shippers"
        /// <summary>
        public IQueryable<Shipper> Shippers
        {
            get { return this.Query<Shipper>(); }
        }

        /// <summary>
        /// Queryable object for "suppliers"
        /// <summary>
        public IQueryable<Supplier> Suppliers
        {
            get { return this.Query<Supplier>(); }
        }

        /// <summary>
        /// Queryable object for "territories"
        /// <summary>
        public IQueryable<Territory> Territories
        {
            get { return this.Query<Territory>(); }
        }

        /// <summary>
        /// Returns a opened database connection using static instance "Context"
        /// </summary>
        /// <returns>Database connection wrapper</returns>
        /// <remarks>_ to differentciates with instance GetDataContext</remarks>
        public static DataContext _GetDataContext()
        {
            // Open a new database connection using static instance
            return Context.GetDataContext();
        }
    }
}