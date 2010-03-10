using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrystalMapper.UnitTest.Northwind;

namespace CrystalMapper.UnitTest.Linq
{
    /// <summary>
    /// Summary description for WhereTest
    /// </summary>
    [TestClass]
    public class WhereTest
    {
        public WhereTest()
        {
            //
            // TODO: Add constructor logic here
            //
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
        public void WhereEqualTest()
        {
            var customers = Customer.Query().Where(c => c.CustomerID == "ALFKI").ToList();

            Assert.AreEqual(1, customers.Count);
        }

        [TestMethod]
        public void WhereNotEqualTest()
        {
            var customers = Customer.Query().Where(c => c.CustomerID != "ALFKI").ToList();

            Assert.AreNotEqual(0, customers.Count);
        }
    }
}
