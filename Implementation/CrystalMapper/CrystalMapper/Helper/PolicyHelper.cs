using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Policy;
using CrystalMapper.Generic;

namespace CrystalMapper.Helper
{
    public static class PolicyHelper<T> 
        where T: Entity<T>, new()
    {
        public static readonly CachePolicy CachePolicy;

        static PolicyHelper()
        {
            CachePolicy = PolicyManager.GetCachePolicy(typeof(T));
        }
    }
}
