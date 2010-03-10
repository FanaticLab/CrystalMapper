using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Generic;
using CrystalMapper.Data;

namespace CrystalMapper.Linq
{
    public static class Extension
    {
        public static IQueryable<T> Query<T>(this DataContext dataContext) where T : Entity<T>, new()
        {
            return new Query<T>(dataContext);
        }
    }
}
