using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrystalMapper.UnitTest.Northwind;

namespace CrystalMapper.UnitTest.Linq
{
    /// <summary>
    /// Summary description for JoinTest
    /// </summary>
    [TestClass]    
    public class JoinTest
    {
        public JoinTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [TestMethod]
        public void CrossJoinTest()
        {
            var count = (from c in Customer.Query()
                             from o in Order.Query()
                             select new { Customer = c, Order = o }).Count();

            Assert.AreEqual(TestHelper.ExecuteScalar("SELECT COUNT(*) FROM CUSTOMERS CROSS JOIN ORDERS"), count);
        }

        [TestMethod]
        public void InnerJoinTest()
        {
            var count = (from c in Customer.Query()
                         join o in Order.Query() on c.CustomerID equals o.CustomerID
                         select new { Customer = c, Order = o }).Count();

            Assert.AreEqual(TestHelper.ExecuteScalar(@"SELECT COUNT(*) 
                                                      FROM CUSTOMERS C
                                                      INNER JOIN ORDERS O ON C.CUSTOMERID = O.CUSTOMERID"), count);
        }

        [TestMethod]
        public void LeftOuterJoinTest()
        {
            var count = (from c in Customer.Query()
                         join o in Order.Query() on c.CustomerID equals o.CustomerID into l
                         from ol in l.DefaultIfEmpty()
                         select new { Customer = c, Order = ol }).Count();

            Assert.AreEqual(TestHelper.ExecuteScalar(@"SELECT COUNT(*) 
                                                      FROM CUSTOMERS C
                                                      LEFT OUTER JOIN ORDERS O ON C.CUSTOMERID = O.CUSTOMERID"), count);
        }
    }
}
