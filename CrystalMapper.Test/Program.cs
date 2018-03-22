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
using CrystalMapper.Test.Chinook;

namespace CrystalMapper.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable result;

            var sqDb = ChinookDb.Context;

            var db = NorthwindDb.Context; // Aliasing static instance for easyness of "Northwind" database

            try
            {
                var playlists = db.Query<Order>().Where(o => o.OrderID == -1);

                //var playlistsresult = playlists.ToArray();

                var stopwatch = Stopwatch.StartNew();
                for (int i=0; i < 500; i++)
                {
                    //playlistsresult = playlists.ToArray();
                    var query = playlists.ToString();
                }
                stopwatch.Stop();
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                throw ex;
            }



            var q = db.Query<Order>().Where(o => o.Freight < 100);
            var oCount = q.Count();

            // Loading customers whole placed at least one order
            var customers = db.Query<Customer>()
                    .Where(c => db.Query<Order>()
                                  .Select(o => o.CustomerID)
                                  .Contains(c.CustomerID));

            result = customers.ToArray();
            Write(result);

            var customer = customers.First();



            // Loading Customer with their Orders            
            var customerOrders = (from c in db.Customers
                                  from o in db.Orders
                                  select new { Customer = c, Order = o });

            result = customerOrders.ToArray();
            Write(result);

            //var today = DateTime.Today;
            //// Loading todays order with their customers
            //var customerOrders2 = (from c in db.Query<Customer>()
            //                       from o in c.Orders
            //                       where o.OrderDate == today
            //                       select new { c, o }).Take(1000);

            //result = customerOrders2.ToArray();
            //Write(result);

            //var groupBy = from c in db.Query<Customer>()
            //              join o in db.Query<Order>() on c.CustomerID equals o.CustomerID
            //              group o by o.CustomerID into g
            //              select new { g.Key, Count = g.Count(), Avg = g.Average(o => o.OrderID) };

            //Write(groupBy.ToArray());

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
