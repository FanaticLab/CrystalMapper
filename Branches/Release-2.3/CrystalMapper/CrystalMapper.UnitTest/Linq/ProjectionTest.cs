using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrystalMapper.UnitTest.Northwind;

namespace CrystalMapper.UnitTest.Linq
{
    /// <summary>
    /// Summary description for ProjectionTest
    /// </summary>
    [TestClass]
    public class ProjectionTest
    {
        [TestMethod]
        public void ProjectionPrimitivePropertyTypeTest()
        {
            var customers = (from c in Customer.Query()
                             select new { c.CustomerID, CustomerName = c.ContactName }).ToList();

            Assert.AreEqual(TestHelper.ExecuteScalar("SELECT COUNT(*) FROM CUSTOMERS"), customers.Count);

            foreach (var customer in Customer.List().ToList())
            {
                Assert.IsNotNull(customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID));
                Assert.IsNotNull(customers.FirstOrDefault(c => c.CustomerName == customer.ContactName));
            }
        }

        [TestMethod]
        public void ProjectionNestedAnonymousTypeTest()
        {
            var customers = (from c in Customer.Query()
                             select new { c.CustomerID, CustomerName = c.ContactName });

            var orders = (from o in Order.Query()
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
            var orders = (from o in Order.Query()
                             select new { o.CustomerID, OrderID = o.OrderID  + 1000 }).ToList();

            Assert.AreEqual(TestHelper.ExecuteScalar("SELECT COUNT(*) FROM ORDERS"), orders.Count);

            foreach (Order order in Order.List())
            {
                Assert.IsNotNull(orders.FirstOrDefault(o => o.OrderID == order.OrderID + 1000));
            }
        }

        [TestMethod]
        public void ProjectionComplextObjectPropertyTest()
        {
            var results = (from c in Customer.Query()
                          join o in Order.Query() on c.CustomerID equals o.CustomerID
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
