using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using System.Diagnostics;
using CoreSystem.Data;
using CrystalMapper.Generated.BusinessObjects;
using System.Data.SqlClient;

namespace CrystalMapper.Test
{   
    class Program
    {
        static void Main(string[] args)
        {
            #region Simple Queries

            WorkOrder workOrder = new WorkOrder { ProductID = 722 };
            WorkOrder[] orders = workOrder.ToList();
            Console.WriteLine("Total order of product Id: {0} are: {1}", workOrder.ProductID, orders.Length);
            
            ProductReview productReview = new ProductReview { ReviewerName = "%John%" };
            ProductReview[] reviews = productReview.ToList();
            foreach (ProductReview review in reviews)
            {
                Console.WriteLine("Product: {0} reviewd by: {1}", review.ProductID, review.ReviewerName);
            }

            #endregion

            #region Little Complex Queries
            
            foreach (WorkOrder workOrder1 in WorkOrder.OrdersWithQtyGreaterThen(8))
            {
                Console.WriteLine("Order ID: {0}, Due Date: {1:f}", workOrder1.WorkOrderID, workOrder1.DueDate); 
            }

            #endregion

            UpdateProductReviews();

            Console.ReadLine();
        }
        
        #region Bulk Update Example

        public static void UpdateProductReviews()
        {
            ProductReview productReview = new ProductReview { ReviewerName = "%John%" };
            ProductReview[] reviews = productReview.ToList();
            foreach (ProductReview review in reviews)
            {
                review.ReviewerName = "Faraz";
            }

            ProductReview.Update(reviews); // Updates all reviews in a transaction
            // Or Simple call review.Update() for individual object update
            // Or Use review.Update(DataContext) function for update in transaction
        }

        #endregion

        #region Performance test

        public static void DoTest()
        {
            DataTableTest(WorkOrder.TABLE_NAME);
            CrystalMapperTest<WorkOrder>();
        }

        public static T[] CrystalMapperTest<T>() where T : Entity<T>, new()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            T searchT = new T();
            T[] searchTToList = searchT.ToList();
            stopWatch.Stop();
            Console.WriteLine("Number of records fetch: {0} by Crystal Mapper of in Time Seconds: {1} ", searchTToList.Length, stopWatch.Elapsed.TotalSeconds);
            return searchTToList;
        }

        public static DataTable DataTableTest(string tableName)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            using (SqlConnection conn = new SqlConnection(@"Data Source=DEV-MAC\SQLEXPRESS;Initial Catalog=AdventureWorks;Integrated Security=True"))
            {
                using (SqlCommand com = new SqlCommand("SELECT * FROM " + tableName, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(com);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset, tableName);
                    stopWatch.Stop();
                    Console.WriteLine("Number of records fetch: {0} through DataSet in Time Seconds: {1} ", dataset.Tables[tableName].Rows.Count, stopWatch.Elapsed.TotalSeconds);
                    return dataset.Tables[tableName];
                }
            }
        }

        #endregion
    }
}
