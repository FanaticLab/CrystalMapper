using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrystalMapper.UnitTest.Northwind;
using System.Data.SqlClient;
using System.Configuration;

namespace CrystalMapper.UnitTest.Linq
{
    /// <summary>
    /// Summary description for AggregateTest
    /// </summary>
    [TestClass]
    public class AggregateTest
    {

        [TestMethod]
        public void Sum()
        {
            Assert.AreEqual(TestHelper.ExecuteScalar<decimal?>("SELECT SUM(FREIGHT) FROM ORDERS")
                            , Order.Query().Sum(o => o.Freight));
        }

        [TestMethod]
        public void Average()
        {
            Assert.AreEqual(TestHelper.ExecuteScalar<decimal?>("SELECT AVG(FREIGHT) FROM ORDERS")
                            , Order.Query().Average(o => o.Freight));
        }

        [TestMethod]
        public void Max()
        {
            Assert.AreEqual(TestHelper.ExecuteScalar<decimal?>("SELECT MAX(FREIGHT) FROM ORDERS")
                            , Order.Query().Max(o => o.Freight));
        }

        [TestMethod]
        public void Min()
        {
            Assert.AreEqual(TestHelper.ExecuteScalar<decimal?>("SELECT MIN(FREIGHT) FROM ORDERS"), Order.Query().Min(o => o.Freight));
        }

        [TestMethod]
        public void Count()
        {
            Assert.AreEqual(TestHelper.ExecuteScalar<int>("SELECT COUNT(*) FROM ORDERS"), Order.Query().Count());
        }

        [TestMethod]
        public void LongCount()
        {
            var longcount = Order.Query().LongCount();

            Assert.AreEqual(TestHelper.ExecuteScalar<long>("SELECT COUNT(*) FROM ORDERS"), longcount);
            Assert.AreEqual(typeof(long), longcount.GetType());
        }
    }
}
