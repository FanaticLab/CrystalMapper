using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using CrystalMapper.Context;
using CrystalMapper.Linq;

namespace CrystalMapper.Test.Northwind
{
    public partial class Customer
    {
        public IQueryable<Order> Orders
        {
            get
            {
                return this.CreateQuery<Order>().Where(o => o.CustomerID == this.CustomerID);
            }
        }
    }
}
