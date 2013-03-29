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
            IEnumerable result;
            var db = new DbContext();
           // var oCount = db.Query<Order>().Where(o => o.Freight < 100).Count();

            // Loading customers whole placed at least one order
            var customers = db.Query<Customer>()
                    .Where(c => db.Query<Order>()
                                  .Select(o => o.CustomerID)
                                  .Contains(c.CustomerID));
            
            //result = customers.ToArray();
            //Write(result);

            var customer = customers.First();
            var orders = customer.Orders.ToArray();

            // Loading Customer and their Orders
            var customerOrders = (from c in db.Query<Customer>()
                                  join o in db.Query<Order>().Select(o => new { o.CustomerID, OrderID = o.OrderID - 1000 }) on c.CustomerID equals o.CustomerID
                                  select new { Customer = c, Order = o });

            result = customerOrders.ToArray();
            Write(result);

            // Loading
            var customerOrders2 = (from c in db.Query<Customer>()
                                   from o in db.Query<Order>().Where(o => o.OrderID > 100)
                                   select new { c, o }).Take(1000);

            result = customerOrders2.ToArray();
            Write(result);

            var groupBy = from c in db.Query<Customer>()
                          join o in db.Query<Order>() on c.CustomerID equals o.CustomerID
                          group o by o.CustomerID into g
                          select new { g.Key, Count = g.Count(), Avg = g.Average(o => o.OrderID) };

            Write(groupBy.ToArray());

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
