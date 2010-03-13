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

            //var q3 = from c in Customer.Query()
            //         from o in Order.Query().Where(o => o.OrderID > 100)
            //         select new { c, o };

            //var r3 = q3.ToArray();

            var q4 = from o in Order.Query()
                    group o by o.CustomerID into g
                    select new { g.Key, Count = g.Count(), Avg = g.Average(o => o.OrderID), Min = g.Min(o => o.OrderID) };

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


//  #region AdventureWorks
//  Stopwatch stopwatch = new Stopwatch();

//  //WorkOrder query = new WorkOrder { OrderQty = 9 };
//  //stopwatch.Start();
//  //for (int i = 0; i < 1; i++)
//  //{
//  //    WorkOrder[] workOrder = WorkOrder.List();// query.ToList();
//  //}
//  //stopwatch.Stop();
//  //Console.WriteLine("WorkORder loading without cache 10 times: {0}", stopwatch.Elapsed);
//  CachePolicy p = new CachePolicy(typeof(WorkOrder), new TimeSpan(1, 0, 0), CrystalMapper.Cache.CacheType.Select, DateTime.MinValue);
//  PolicyManager.Initialize(new CachePolicy[] { p });
//  WorkOrder w = new WorkOrder { OrderQty = 9 };
//  WorkOrder[] workOrder2 = w.ToList();
//  while (p.IsExpired)
//      Thread.Sleep(1000);
//  WorkOrder query2 = new WorkOrder { OrderQty = 9 };

//  stopwatch.Reset();
//  stopwatch.Start();

//  for (int i = 0; i < 1; i++)
//  {
//      WorkOrder[] workOrder3 = WorkOrder.List();
//  }

//  stopwatch.Stop();
//  Console.WriteLine("WorkORder loading without cache 10 times: {0}", stopwatch.Elapsed);
////  Console.ReadLine();
//  #endregion

//Stopwatch stopwatch = new Stopwatch();

//TblOrder query1 = new TblOrder { OrderStatus = "Approved" };

//stopwatch.Reset();
//stopwatch.Start();

//for (int i = 0; i < 1; i++)
//{
//    TblOrder[] orders =  TblOrder.List();
//}

//stopwatch.Stop();
//Console.WriteLine("Order loading without cache 10 times: {0}", stopwatch.Elapsed);

//CachePolicy p = new CachePolicy(typeof(TblOrder), new TimeSpan(1, 0, 0), CrystalMapper.Cache.CacheType.Select, DateTime.MinValue);
//PolicyManager.Initialize(new CachePolicy[] { p });

//TblOrder[] orders3 = TblOrder.List();
//while (p.IsExpired)
//    Thread.Sleep(1000);
//TblOrder query = new TblOrder { OrderStatus = "Approved" };

//stopwatch.Reset();
//stopwatch.Start();

//TblOrder[] orders2;

//for (int i = 0; i < 1; i++)
//{
//    orders2 = TblOrder.List();
//}

//stopwatch.Stop();
//Console.WriteLine("Orders loading with cache 10 times: {0}", stopwatch.Elapsed);

//Console.ReadLine();
