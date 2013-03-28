using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrystalMapper.UnitTest.Northwind;
using System.Data.SqlClient;
using System.Configuration;
using CrystalMapper.Context;

namespace CrystalMapper.UnitTest.Linq
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class SelectTest
    {
        private int totalCustomers;
        private string firstCustomerID;
        private string lastCustomerID;

        private DbContext db = new DbContext();

        public SelectTest()
        {
            using (var dataContext = new DataContext())
            {
                using (var command = dataContext.CreateCommand("SELECT COUNT(*) FROM CUSTOMERS"))
                {

                    totalCustomers = Convert.ToInt32(command.ExecuteScalar());

                    command.CommandText = "SELECT TOP 1 CUSTOMERID FROM CUSTOMERS";
                    firstCustomerID = Convert.ToString(command.ExecuteScalar());


                    command.CommandText = "SELECT TOP 1 CUSTOMERID FROM CUSTOMERS ORDER BY CUSTOMERID DESC";
                    lastCustomerID = Convert.ToString(command.ExecuteScalar());
                }
            }
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void SelectAll()
        {
            var customerList = db.Query<Customer>().ToList();

            Assert.AreEqual(totalCustomers, customerList.Count);
        }

        [TestMethod]
        public void SelectFirst()
        {
            var customer = db.Query<Customer>().First();

            Assert.IsNotNull(customer);
        }

        [TestMethod]
        public void SelectFirstOrDefault()
        {
            var customer = db.Query<Customer>().FirstOrDefault();
            Assert.IsNotNull(customer);

            customer = db.Query<Customer>().FirstOrDefault(c => c.CustomerID == "----");
            Assert.IsNull(customer);
        }

        [TestMethod]
        public void SelectSingle()
        {
            var customer = db.Query<Customer>().Single();

            Assert.IsNotNull(customer);
        }

        [TestMethod]
        public void SelectSingleOrDefault()
        {
            var customer = db.Query<Customer>().SingleOrDefault();
            Assert.IsNotNull(customer);

            customer = db.Query<Customer>().SingleOrDefault(c => c.CustomerID == "----");
            Assert.IsNull(customer);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SelectSelectLastWithOutOrderBy()
        {
            var customer = db.Query<Customer>().Last();
        }

        [TestMethod]
        public void SelectLast()
        {
            var customer = db.Query<Customer>().OrderBy(c => c.CustomerID).Last();

            Assert.IsNotNull(customer);
            Assert.AreEqual(lastCustomerID, customer.CustomerID);
        }

        [TestMethod]
        public void SelectLastOrDefault()
        {
            var customer = db.Query<Customer>().OrderBy(c => c.CustomerID).LastOrDefault();

            Assert.IsNotNull(customer);
            Assert.AreEqual(lastCustomerID, customer.CustomerID);

            customer = db.Query<Customer>().OrderBy(c => c.CustomerID).LastOrDefault(c => c.CustomerID == "-----");

            Assert.IsNull(customer);
        }
    }
}
