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
using CoreSystem.Dynamic;
using System.Data.Common;

namespace CrystalMapper.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            //Order order = new Order { OrderID = 722 };
            //Order[] orders = order.ToList(); // Orders array containing one order;


            // Using 'Default-Db' connection string
            using (DataContext dataContext2 = new DataContext())
            {
                // Getting Order Date greater than now
                using (DbCommand command = dataContext2.CreateCommand("SELECT * FROM Orders WHERE OrderDate > @OrderDate"))
                {
                    command.Parameters.Add(dataContext2.CreateParameter(DateTime.Now, "@OrderDate"));
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        // Converting results to Order's array
                        Order[] orders1 = Order.ToList(reader);
                    }
                }
            }

            Order[] orders;
            // Using 'Default-Db' connection string
            orders = (from order in Order.Query()
                      where order.OrderDate > DateTime.Now
                      select order).ToArray();

            // Using 'MyAdventuresDb' connnection string
            orders = (from order in Order.Query("MyAdventuresDb")
                      where order.OrderDate > DateTime.Now
                      select order).ToArray();

            // Using same 'MyAdventuresDb' connnection for all queries
            using (DataContext dataContext1 = new DataContext("MyAdventuresDb"))
            {
                Order[] todayOrders = (from order in Order.Query(dataContext1)
                                       where order.OrderDate > DateTime.Today
                                       select order).ToArray();

                Order[] futureOrders = (from order in Order.Query(dataContext1)
                                        where order.RequiredDate > DateTime.Today
                                        select order).ToArray();

            }

            using (DataContext dataCotnext = new DataContext())
            {
                // Begining transaction
                dataCotnext.BeginTransaction();

                Customer customer = new Customer { ContactName = "Faraz Masood Khan", CompanyName = "FanaticLab" };
                customer.Save(dataContext);

                Order order = new Order { CustomerRef = customer, 
            }


            var s = Order.Query().Where(o => o.Freight < 100).Count();

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

        class Class1
        {
            public string prp { get; set; }
        }

        static void Write(IEnumerable collection)
        {
            int count = 0;
            foreach (var obj in collection)
                Console.WriteLine("{0}: {1}", count++, obj);
        }
    }
}
