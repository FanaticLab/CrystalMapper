using System;
using System.Dynamic;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrystalMapper.Context;
using CrystalMapper.UnitTest.SQL.Northwind;

namespace CrystalMapper.UnitTest.Linq
{
    /// <summary>
    /// Summary description for GroupByTest
    /// </summary>
    [TestClass]
    public class GroupByTest
    {
        private DbContext db = new DbContext();

        [TestMethod]
        public void GroupByCount()
        {
            var linqCustomers = (from c in db.Query<Customer>()
                                 join o in db.Query<Order>() on c.CustomerID equals o.CustomerID
                                 group o by o.CustomerID into g
                                 select new { CustomerID = g.Key, Orders = g.Count() }).ToArray();

            var sqlCustomers = db.ToDynamic(@"
SELECT C.CustomerID, COUNT(O.OrderID) Orders
FROM CUSTOMERS C
INNER JOIN ORDERS O ON C.CUSTOMERID = O.CUSTOMERID
GROUP BY C.CustomerID");

            // Customers count should be equal
            Assert.AreEqual(linqCustomers.Length, sqlCustomers.Count);

            // Each customer orders count should be equal
            foreach (var customer in linqCustomers)
                Assert.AreEqual(customer.Orders, sqlCustomers.First(c => c.CustomerID == customer.CustomerID).Orders);
        }

        [TestMethod]
        public void GroupByAverage()
        {
            var lCustomers = (from c in db.Query<Customer>()
                              join o in db.Query<Order>() on c.CustomerID equals o.CustomerID
                              group o by o.CustomerID into g
                              select new { CustomerID = g.Key, Freights = g.Average(a => a.Freight) }).ToArray();

            var dCustomers = db.ToDynamic(@"
SELECT C.CustomerID, AVG(O.Freight) Freights
FROM CUSTOMERS C
INNER JOIN ORDERS O ON C.CUSTOMERID = O.CUSTOMERID
GROUP BY C.CustomerID");

            // Customers count should be equal
            Assert.AreEqual(lCustomers.Length, dCustomers.Count);

            // Each customer orders count should be equal
            foreach (var customer in lCustomers)
                Assert.AreEqual(customer.Freights, dCustomers.First(c => c.CustomerID == customer.CustomerID).Freights);
        }

        [TestMethod]
        public void GroupByMax()
        {
            var lCustomers = (from c in db.Query<Customer>()
                              join o in db.Query<Order>() on c.CustomerID equals o.CustomerID
                              group o by o.CustomerID into g
                              select new { CustomerID = g.Key, LastOrderID = g.Max(a => a.OrderID) }).ToArray();

            var dCustomers = db.ToDynamic(@"
SELECT C.CustomerID, MAX(O.OrderID) LastOrderID
FROM CUSTOMERS C
INNER JOIN ORDERS O ON C.CUSTOMERID = O.CUSTOMERID
GROUP BY C.CustomerID");

            // Customers count should be equal
            Assert.AreEqual(lCustomers.Length, dCustomers.Count);

            // Each customer orders count should be equal
            foreach (var customer in lCustomers)
                Assert.AreEqual(customer.LastOrderID, dCustomers.First(c => c.CustomerID == customer.CustomerID).LastOrderID);
        }

        [TestMethod]
        public void GroupBySum()
        {
            var lCustomers = (from c in db.Query<Customer>()
                              join o in db.Query<Order>() on c.CustomerID equals o.CustomerID
                              group o by o.CustomerID into g
                              select new { CustomerID = g.Key, Freights = g.Sum(a => a.Freight) }).ToArray();

            var dCustomers = db.ToDynamic(@"
SELECT C.CustomerID, SUM(O.Freight) Freights
FROM CUSTOMERS C
INNER JOIN ORDERS O ON C.CUSTOMERID = O.CUSTOMERID
GROUP BY C.CustomerID");

            // Customers count should be equal
            Assert.AreEqual(lCustomers.Length, dCustomers.Count);

            // Each customer orders count should be equal
            foreach (var customer in lCustomers)
                Assert.AreEqual(customer.Freights, dCustomers.First(c => c.CustomerID == customer.CustomerID).Freights);
        }

        [TestMethod]
        public void GroupByMin()
        {
            var lCustomers = (from c in db.Query<Customer>()
                              join o in db.Query<Order>() on c.CustomerID equals o.CustomerID
                              group o by o.CustomerID into g
                              select new { CustomerID = g.Key, FirstOrderID = g.Min(a => a.OrderID) }).ToArray();

            var dCustomers = db.ToDynamic(@"
SELECT C.CustomerID, MIN(O.OrderID) FirstOrderID
FROM CUSTOMERS C
INNER JOIN ORDERS O ON C.CUSTOMERID = O.CUSTOMERID
GROUP BY C.CustomerID");

            // Customers count should be equal
            Assert.AreEqual(lCustomers.Length, dCustomers.Count);

            // Each customer orders count should be equal
            foreach (var customer in lCustomers)
                Assert.AreEqual(customer.FirstOrderID, dCustomers.First(c => c.CustomerID == customer.CustomerID).FirstOrderID);
        }

        [TestMethod]
        public void GroupByLongCount()
        {
            var linqCustomers = (from c in db.Query<Customer>()
                                 join o in db.Query<Order>() on c.CustomerID equals o.CustomerID
                                 group o by o.CustomerID into g
                                 select new { CustomerID = g.Key, Orders = g.LongCount() }).ToArray();

            var sqlCustomers = db.ToDynamic(@"
SELECT C.CustomerID, COUNT(O.OrderID) Orders
FROM CUSTOMERS C
INNER JOIN ORDERS O ON C.CUSTOMERID = O.CUSTOMERID
GROUP BY C.CustomerID");

            // Customers count should be equal
            Assert.AreEqual(linqCustomers.Length, sqlCustomers.Count);

            // Each customer orders count should be equal
            foreach (var customer in linqCustomers)
                Assert.AreEqual(customer.Orders, sqlCustomers.First(c => c.CustomerID == customer.CustomerID).Orders);
        }
    }
}
