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

            Assert.AreEqual(db.ToScalar<decimal?>("SELECT SUM(FREIGHT) FROM ORDERS")
                            , db.Query<Order>().Sum(o => o.Freight));
        }

        [TestMethod]
        public void Average()
        {
            Assert.AreEqual(db.ToScalar<decimal?>("SELECT AVG(FREIGHT) FROM ORDERS")
                            , db.Query<Order>().Average(o => o.Freight));
        }

        [TestMethod]
        public void Max()
        {
            Assert.AreEqual(db.ToScalar<decimal?>("SELECT MAX(FREIGHT) FROM ORDERS")
                            , db.Query<Order>().Max(o => o.Freight));
        }

        [TestMethod]
        public void Min()
        {
            Assert.AreEqual(db.ToScalar<decimal?>("SELECT MIN(FREIGHT) FROM ORDERS"), db.Query<Order>().Min(o => o.Freight));
        }

        [TestMethod]
        public void Count()
        {
            Assert.AreEqual(db.ToScalar<int>("SELECT COUNT(*) FROM ORDERS"), db.Query<Order>().Count());
        }

        [TestMethod]
        public void LongCount()
        {
            var longcount = db.Query<Order>().LongCount();

            Assert.AreEqual(db.ToScalar<long>("SELECT COUNT(*) FROM ORDERS"), longcount);
            Assert.AreEqual(typeof(long), longcount.GetType());
        }
    }
}
