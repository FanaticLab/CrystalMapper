/*****************************************************************
 * Author: CrystalMapper (Generated)
 * Date:  Monday, April 01, 2013 7:10 PM
 * Project: http://crystalmapper.codeplex.com
 * Copyright (c) 2013 FanaticLab
 *****************************************************************/

using System;
using System.Linq;
using CrystalMapper.Context;

namespace CrystalMapper.UnitTest.SQL.Northwind
{
    /// <summary>
    /// Query provider for "Northwind" database
    /// </summary>
    public partial class NorthwindDb : DbContext
    {	
        /// <summary>
        /// Static instance of "Northwind" database
        /// </summary>
        public static readonly NorthwindDb Context;
    
        static NorthwindDb()
        {
            Context = new NorthwindDb();
        }
    
		public NorthwindDb(): base("Northwind") {}
        
        /// <summary>
        /// Queryable object for "dbo.Categories"
        /// <summary>
        public IQueryable<Category> Categories
        {
            get { return this.Query<Category>(); }
        }
        
        /// <summary>
        /// Queryable object for "dbo.CustomerCustomerDemo"
        /// <summary>
        public IQueryable<CustomerCustomerDemo> CustomerCustomerDemos
        {
            get { return this.Query<CustomerCustomerDemo>(); }
        }
        
        /// <summary>
        /// Queryable object for "dbo.CustomerDemographics"
        /// <summary>
        public IQueryable<CustomerDemographic> CustomerDemographics
        {
            get { return this.Query<CustomerDemographic>(); }
        }
        
        /// <summary>
        /// Queryable object for "dbo.Customers"
        /// <summary>
        public IQueryable<Customer> Customers
        {
            get { return this.Query<Customer>(); }
        }
        
        /// <summary>
        /// Queryable object for "dbo.Employees"
        /// <summary>
        public IQueryable<Employee> Employees
        {
            get { return this.Query<Employee>(); }
        }
        
        /// <summary>
        /// Queryable object for "dbo.EmployeeTerritories"
        /// <summary>
        public IQueryable<EmployeeTerritory> EmployeeTerritories
        {
            get { return this.Query<EmployeeTerritory>(); }
        }
        
        /// <summary>
        /// Queryable object for "dbo.Order Details"
        /// <summary>
        public IQueryable<OrderDetail> OrderDetails
        {
            get { return this.Query<OrderDetail>(); }
        }
        
        /// <summary>
        /// Queryable object for "dbo.Orders"
        /// <summary>
        public IQueryable<Order> Orders
        {
            get { return this.Query<Order>(); }
        }
        
        /// <summary>
        /// Queryable object for "dbo.Products"
        /// <summary>
        public IQueryable<Product> Products
        {
            get { return this.Query<Product>(); }
        }
        
        /// <summary>
        /// Queryable object for "dbo.Region"
        /// <summary>
        public IQueryable<Region> Regions
        {
            get { return this.Query<Region>(); }
        }
        
        /// <summary>
        /// Queryable object for "dbo.Shippers"
        /// <summary>
        public IQueryable<Shipper> Shippers
        {
            get { return this.Query<Shipper>(); }
        }
        
        /// <summary>
        /// Queryable object for "dbo.Suppliers"
        /// <summary>
        public IQueryable<Supplier> Suppliers
        {
            get { return this.Query<Supplier>(); }
        }
        
        /// <summary>
        /// Queryable object for "dbo.Territories"
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