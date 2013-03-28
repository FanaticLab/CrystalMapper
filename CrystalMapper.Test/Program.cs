using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using System.Diagnostics;
using CoreSystem.Data;
using System.Data.SqlClient;
using System.Threading;
using CrystalMapper.Test.Northwind;
using CrystalMapper.Linq;
using CrystalMapper.Context;
using System.Collections;
using CoreSystem.Dynamic;
using System.Data.Common;

namespace CrystalMapper.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DbContext();
            var s = db.Query<Order>().Where(o => o.Freight < 100).Count();

            var r = db.Query<Customer>()
                    .Where(c => db.Query<Order>()
                                  .Select(o => o.CustomerID)
                                  .Contains(c.CustomerID)).ToArray();
            Write(r);

            int orderId = 100;

            var q2 = (from c in db.Query<Customer>()
                      join o in db.Query<Order>().Select(o => new { o.CustomerID, OrderID = o.OrderID - 1000 }) on c.CustomerID equals o.CustomerID
                      where o.OrderID > orderId
                      select new { c, o });

            var r2 = q2.ToArray();
            Write(r2);

            var q3 = (from c in db.Query<Customer>()
                      from o in db.Query<Order>().Where(o => o.OrderID > 100)
                      select new { c, o }).Take(1000);

            var r3 = q3.ToArray();

            Write(r3);

            var query = from c in db.Query<Customer>()
                        join o in db.Query<Order>() on c.CustomerID equals o.CustomerID
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
