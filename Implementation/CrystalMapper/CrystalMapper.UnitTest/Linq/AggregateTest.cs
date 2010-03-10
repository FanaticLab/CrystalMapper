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

        private decimal sumFreight;
        private decimal avgFreight;
        private decimal minFreight;
        private decimal maxFreight;
        private int totalOrders;

        public AggregateTest()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Constant.DbName].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM ORDERS", connection))
                {
                    connection.Open();
                    totalOrders = Convert.ToInt32(command.ExecuteScalar());

                    command.CommandText = "SELECT SUM(FREIGHT) FROM ORDERS";
                    sumFreight = Convert.ToDecimal(command.ExecuteScalar());


                    command.CommandText = "SELECT AVG(FREIGHT) FROM ORDERS";
                    avgFreight = Convert.ToDecimal(command.ExecuteScalar());

                    command.CommandText = "SELECT MIN(FREIGHT) FROM ORDERS";
                    minFreight = Convert.ToDecimal(command.ExecuteScalar());

                    command.CommandText = "SELECT MAX(FREIGHT) FROM ORDERS";
                    maxFreight = Convert.ToDecimal(command.ExecuteScalar());

                    connection.Close();
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

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Sum()
        {
            var sum = Order.Query().Sum(o => o.Freight);
        }

        [TestMethod]
        public void Average()
        {
            Assert.AreEqual(avgFreight, Order.Query().Average(o => o.Freight));
        }

        [TestMethod]
        public void Max()
        {
            Assert.AreEqual(maxFreight, Order.Query().Max(o => o.Freight));
        }

        [TestMethod]
        public void Min()
        {
            Assert.AreEqual(minFreight, Order.Query().Min(o => o.Freight));
        }

        [TestMethod]
        public void Count()
        {
            Assert.AreEqual(totalOrders, Order.Query().Count());
        }

        [TestMethod]
        public void LongCount()
        {
            var longcount = Order.Query().LongCount();

            Assert.AreEqual(totalOrders, longcount);
            Assert.AreEqual(typeof(long), longcount.GetType());
        }
    }
}
