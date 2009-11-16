using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using System.Diagnostics;
using CoreSystem.Data;
using System.Data.SqlClient;
using feedbook.Model;
using CrystalMapper.Policy;
using System.Threading;
using B2B.CRM.Model;


namespace CrystalMapper.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            #region AdventureWorks
            Stopwatch stopwatch = new Stopwatch();

            //WorkOrder query = new WorkOrder { OrderQty = 9 };
            //stopwatch.Start();
            //for (int i = 0; i < 1; i++)
            //{
            //    WorkOrder[] workOrder = WorkOrder.List();// query.ToList();
            //}
            //stopwatch.Stop();
            //Console.WriteLine("WorkORder loading without cache 10 times: {0}", stopwatch.Elapsed);
            CachePolicy p = new CachePolicy(typeof(WorkOrder), new TimeSpan(1, 0, 0), CrystalMapper.Cache.CacheType.Select, DateTime.MinValue);
            PolicyManager.Initialize(new CachePolicy[] { p });
            WorkOrder w = new WorkOrder { OrderQty = 9 };
            WorkOrder[] workOrder2 = w.ToList();
            while (p.IsExpired)
                Thread.Sleep(1000);
            WorkOrder query2 = new WorkOrder { OrderQty = 9 };

            stopwatch.Reset();
            stopwatch.Start();

            for (int i = 0; i < 1; i++)
            {
                WorkOrder[] workOrder3 = WorkOrder.List();
            }

            stopwatch.Stop();
            Console.WriteLine("WorkORder loading without cache 10 times: {0}", stopwatch.Elapsed);
          //  Console.ReadLine();
            #endregion

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
        }
    }
}
