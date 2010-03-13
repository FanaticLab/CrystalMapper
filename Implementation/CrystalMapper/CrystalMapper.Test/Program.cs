using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using System.Diagnostics;
using CoreSystem.Data;
using System.Data.SqlClient;
using CrystalMapper.Policy;
using System.Threading;
using CrystalMapper.Test.Northwind;
using CrystalMapper.Linq;
using CrystalMapper.Data;



namespace CrystalMapper.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = Customer.Query().Where(c => Order.Query().Select(o => o.CustomerID).Contains(c.CustomerID));

            var s = new { O = new { I = new { OrderId = 100 } }, CustomerId = "ALFKI" };

            var q2 = (from c in Customer.Query()
                      join o in Order.Query().Select(o => new { o.CustomerID, OrderID = o.OrderID - 1000 }) on c.CustomerID equals o.CustomerID
                      where o.OrderID > s.O.I.OrderId && c.CustomerID == s.CustomerId
                      select new { c, o });

            var r2 = q2.ToArray();

            var q3 = from c in Customer.Query()
                     from o in Order.Query().Where(o => o.OrderID > 100)
                     select new { c, o };

            var r3 = q3.ToArray();

            var q4 = from c in Customer.Query()
                     join o in Order.Query() on c.CustomerID equals o.CustomerID
                     group o by o.CustomerID into g           
                     select new { g.Key, Count = g.Count(), Avg = g.Average(o => o.OrderID), Min = g.Min(o => o.OrderID),  };

            var r4 = q4.ToArray();

            Console.ReadLine();
        }

        static void SimpleSelectQuery()
        {
            var q = from c in Customer.Query()
                    select c;

            var r = q.ToArray();
        }
    }
}
