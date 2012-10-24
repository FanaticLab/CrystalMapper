using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Cache;

namespace CrystalMapper.Policy
{
    public static class PolicyManager
    {
        private static List<EntityPolicy> Policies = new List<EntityPolicy>();

        public static void Initialize()
        {
            throw new NotImplementedException();
        }

        public static void Initialize(IEnumerable<EntityPolicy> policies)
        {
            Policies.AddRange(policies);
            CacheManager.Initialize();
        }

        public static IEnumerable<CachePolicy> GetCachePolicies()
        {
            foreach (EntityPolicy ePolicy in Policies)
                if (ePolicy is CachePolicy)
                    yield return (CachePolicy)ePolicy;
        }

        public static CachePolicy GetCachePolicy(Type typeOfEntity)
        {
            foreach (EntityPolicy ePolicy in Policies)
                if ((ePolicy is CachePolicy) && ePolicy.EntityType.Equals(typeOfEntity))
                    return (CachePolicy)ePolicy;

            return null;
        }
    }
}
