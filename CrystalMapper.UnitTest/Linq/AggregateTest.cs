using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrystalMapper.UnitTest.SQL.Northwind;
using System.Data.SqlClient;
using System.Configuration;
using CrystalMapper.Context;

namespace CrystalMapper.UnitTest.Linq
{
    /// <summary>
    /// Summary description for AggregateTest
    /// </summary>
    [TestClass]
    public class AggregateTest
    {
        private DbContext db = new DbContext();

        [TestMethod]
        public void Sum()
        {

            Assert.AreEqual(TestHelper.ExecuteScalar<decimal?>("SELECT SUM(FREIGHT) FROM ORDERS")
                            , db.Query<Order>().Sum(o => o.Freight));
        }

        [TestMethod]
        public void Average()
        {
            Assert.AreEqual(TestHelper.ExecuteScalar<decimal?>("SELECT AVG(FREIGHT) FROM ORDERS")
                            , db.Query<Order>().Average(o => o.Freight));
        }

        [TestMethod]
        public void Max()
        {
            Assert.AreEqual(TestHelper.ExecuteScalar<decimal?>("SELECT MAX(FREIGHT) FROM ORDERS")
                            , db.Query<Order>().Max(o => o.Freight));
        }

        [TestMethod]
        public void Min()
        {
            Assert.AreEqual(TestHelper.ExecuteScalar<decimal?>("SELECT MIN(FREIGHT) FROM ORDERS"), db.Query<Order>().Min(o => o.Freight));
        }

        [TestMethod]
        public void Count()
        {
            Assert.AreEqual(TestHelper.ExecuteScalar<int>("SELECT COUNT(*) FROM ORDERS"), db.Query<Order>().Count());
        }

        [TestMethod]
        public void LongCount()
        {
            var longcount = db.Query<Order>().LongCount();

            Assert.AreEqual(TestHelper.ExecuteScalar<long>("SELECT COUNT(*) FROM ORDERS"), longcount);
            Assert.AreEqual(typeof(long), longcount.GetType());
        }
    }
}
