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
    /// Summary description for JoinTest
    /// </summary>
    [TestClass]
    public class JoinTest
    {
        private DbContext db = new DbContext();

        public JoinTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [TestMethod]
        public void CrossJoinTest()
        {
            var count = (from c in db.Query<Customer>()
                         from o in db.Query<Order>()
                         select new { Customer = c, Order = o }).Count();

            Assert.AreEqual(TestHelper.ExecuteScalar("SELECT COUNT(*) FROM CUSTOMERS CROSS JOIN ORDERS"), count);
        }

        [TestMethod]
        public void InnerJoinTest()
        {
            var count = (from c in db.Query<Customer>()
                         join o in db.Query<Order>() on c.CustomerID equals o.CustomerID
                         select new { Customer = c, Order = o }).Count();

            Assert.AreEqual(TestHelper.ExecuteScalar(@"SELECT COUNT(*) 
                                                      FROM CUSTOMERS C
                                                      INNER JOIN ORDERS O ON C.CUSTOMERID = O.CUSTOMERID"), count);
        }

        [TestMethod]
        public void LeftOuterJoinTest()
        {
            var count = (from c in db.Query<Customer>()
                         join o in db.Query<Order>() on c.CustomerID equals o.CustomerID into l
                         from ol in l.DefaultIfEmpty()
                         select new { Customer = c, Order = ol }).Count();

            Assert.AreEqual(TestHelper.ExecuteScalar(@"SELECT COUNT(*) 
                                                      FROM CUSTOMERS C
                                                      LEFT OUTER JOIN ORDERS O ON C.CUSTOMERID = O.CUSTOMERID"), count);
        }
    }
}
