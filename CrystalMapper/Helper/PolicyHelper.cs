using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Policy;

namespace CrystalMapper.Helper
{
    public static class PolicyHelper<T> 
        where T: IRecord, new()
    {
        public static readonly CachePolicy CachePolicy;

        static PolicyHelper()
        {
            CachePolicy = PolicyManager.GetCachePolicy(typeof(T));
        }
    }
}
