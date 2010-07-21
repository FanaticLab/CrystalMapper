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
using System.Collections;



namespace CrystalMapper.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = Customer.Query()
                    .Where(c => Order.Query()
                    .Select(o => o.CustomerID).Contains(c.CustomerID)).ToArray();
            Write(r);

            int orderId = 100;

            var q2 = (from c in Customer.Query()
                      join o in Order.Query().Select(o => new { o.CustomerID, OrderID = o.OrderID - 1000 }) on c.CustomerID equals o.CustomerID
                      where o.OrderID > orderId
                      select new { c, o });

            var r2 = q2.ToArray();
            Write(r2);

            var q3 = (from c in Customer.Query()
                      from o in Order.Query().Where(o => o.OrderID > 100)
                      select new { c, o }).Take(1000);

            var r3 = q3.ToArray();
            Write(r3);

            var query = from c in Customer.Query()
                     join o in Order.Query() on c.CustomerID equals o.CustomerID
                     group o by o.CustomerID into g
                     select new { g.Key, Count = g.Count(), Avg = g.Average(o => o.OrderID) };

            var result = query.ToArray();

            Write(result);

            Console.ReadLine();
        }

        static void Write(IEnumerable collection)
        {
            int count = 0;
            foreach (var obj in collection)
                Console.WriteLine("{0}: {1}", count++, obj);
        }
    }
}
