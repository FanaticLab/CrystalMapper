using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrystalMapper.UnitTest.SQL.Northwind;
using CrystalMapper.Context;

namespace CrystalMapper.UnitTest.Linq
{
    /// <summary>
    /// Summary description for ProjectionTest
    /// </summary>
    [TestClass]
    public class ProjectionTest
    {
        private DbContext db = new DbContext();

        [TestMethod]
        public void ProjectionPrimitivePropertyTypeTest()
        {
            var customers = (from c in db.Query<Customer>()
                             select new { c.CustomerID, CustomerName = c.ContactName }).ToList();

            Assert.AreEqual(TestHelper.ExecuteScalar("SELECT COUNT(*) FROM CUSTOMERS"), customers.Count);

            foreach (var customer in db.ToList<Customer>())
            {
                Assert.IsNotNull(customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID));
                Assert.IsNotNull(customers.FirstOrDefault(c => c.CustomerName == customer.ContactName));
            }
        }

        [TestMethod]
        public void ProjectionNestedAnonymousTypeTest()
        {
            var customers = (from c in db.Query<Customer>()
                             select new { c.CustomerID, CustomerName = c.ContactName });

            var orders = (from o in db.Query<Order>()
                          join c in customers on o.CustomerID equals c.CustomerID
                          select new { c.CustomerName, OrderID = o.OrderID }).ToList();


            Assert.AreEqual(TestHelper.ExecuteScalar(@"SELECT COUNT(*)
                                                      FROM (SELECT CUSTOMERID, CONTACTNAME AS CUSTOMERNAME
                                                            FROM CUSTOMERS) C
                                                      INNER JOIN ORDERS O ON C.CUSTOMERID = O.CUSTOMERID")
                            , orders.Count);

        }

        [TestMethod]
        public void ProjectionComputedPropertyTest()
        {
            var orders = (from o in db.Query<Order>()
                          select new { o.CustomerID, OrderID = o.OrderID + 1000 }).ToList();

            Assert.AreEqual(TestHelper.ExecuteScalar("SELECT COUNT(*) FROM ORDERS"), orders.Count);

            foreach (Order order in db.ToList<Order>())
            {
                Assert.IsNotNull(orders.FirstOrDefault(o => o.OrderID == order.OrderID + 1000));
            }
        }

        [TestMethod]
        public void ProjectionComplextObjectPropertyTest()
        {
            var results = (from c in db.Query<Customer>()
                           join o in db.Query<Order>() on c.CustomerID equals o.CustomerID
                           select new { Customer = c, Order = o }).ToList();


            Assert.AreEqual(TestHelper.ExecuteScalar(@"SELECT COUNT(*) 
                                                       FROM CUSTOMERS C 
                                                       INNER JOIN ORDERS O ON C.CUSTOMERID = O.CUSTOMERID")
                            , results.Count);

            results.ForEach(r => Assert.IsNotNull(r.Customer));
            results.ForEach(r => Assert.IsNotNull(r.Order));
        }
    }
}
