/*
 * Author: Faraz Masood Khan 
 * 
 * Date: 6/5/2009 4:03:38 PM
 * 
 * Class: WorkOrder
 * 
 * Copyright: Faraz Masood Khan @ Copyright ©  2009
 * 
 * Email: mk.faraz@gmail.com
 * 
 * Blogs: http://csharplive.wordpress.com, http://farazmasoodkhan.wordpress.com
 * 
 */

using CoreSystem.Data;

using CrystalMapper;
using CrystalMapper.Data;

using System.Data.Common;
using System.Data;

namespace CrystalMapper.Generated.BusinessObjects
{
    public partial class WorkOrder
    {
        public static WorkOrder[] OrdersWithQtyGreaterThen(int quantity)
        {
             using(DataContext dataContext = new DataContext(DbFactory.GetDefaultDatabase()))
             {
                 using(DbCommand command = dataContext.CreateCommand("SELECT * FROM Production.WorkOrder WHERE OrderQty > @OrderQty"))
                 {
                     command.Parameters.Add(dataContext.CreateParameter(quantity, PARAM_ORDERQTY));
                     return WorkOrder.ToList(command.ExecuteReader(CommandBehavior.SequentialAccess));
                 }
             }
        }
    }
}
