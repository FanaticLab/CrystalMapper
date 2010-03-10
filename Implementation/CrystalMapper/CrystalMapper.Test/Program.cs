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
            //SimpleSelectQuery();


            //{
            //    var q = Customer.Query().Select(c => c.ContactTitle);

            //    var r = q.ToList();
            //}


            //{
            //    var q = Order.Query().Select(o => o.OrderID);

            //    var r = q.ToList();
            //}

            {
                //aggregate
                var count1 = Customer.Query().Count(c => c.PostalCode != null);

                var count2 = Customer.Query().LongCount(c => c.PostalCode != null);

                var avg1 = Order.Query().Average(o => o.Freight);

                var avg2 = Order.Query().Select(o => o.Freight).Average();

                var sum = Order.Query().Sum(o => o.Freight);
            }

            {

                var q = Customer.Query()
                    .Where(f => f.Fax == null)
                    .Take(10)
                    .Distinct()
                    .Select(f => new { f.CustomerID, f.Fax, f.Phone })
                    .OrderBy(f => f.Phone)
                    .ThenByDescending(f => f.Fax);


                var r = q.ToArray();
            }

            {

                var q = from c in Customer.Query()
                        from o in Order.Query()
                        where c.CustomerID == o.CustomerID
                        select new { c.CustomerID, o.OrderID, o.OrderDate };

                var r = q.ToArray();
            }


            {
                var q = Order.Query()
                    .Where(o => object.Equals(o.ShipPostalCode, null))
                    .Select(o => new { OrderID = o.OrderID - 1, T = o.OrderDate })
                    .Where(f => f.OrderID % 2 == 0)
                    .Select(f => new { f.T, f.OrderID });

                var qr = q.ToArray();
            }

            {
                var q1 = Order.Query().Select(f => f);
                var q1r = q1.ToArray();
            }

            {
                var q2 = Order.Query();
                var q2r = q2.ToArray();
            }

            {
                using (DataContext dataContext = new DataContext())
                {
                    var q = dataContext.Query<Order>().Where(o => o.OrderID > 10).Select(o => o.OrderID);
                    var r = q.ToArray();

                    var q2 = Customer.Query(dataContext).ToArray();
                }
            }

            //{
            //    var q = from f in Feed.Query()
            //            group f by f.ChannelId into g
            //            select new { g.Key, g };

            //    var r = q.ToArray();
            //}

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
