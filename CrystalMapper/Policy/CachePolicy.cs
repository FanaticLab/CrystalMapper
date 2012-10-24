using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Cache;

namespace CrystalMapper.Policy
{
    public class CachePolicy : EntityPolicy
    {
        private DateTime expireTime;

        public TimeSpan ExpireDuration { get; private set; }

        public CacheType CacheType { get; private set; }

        public DateTime ExpireTime
        {
            get { return this.expireTime; }
            set { this.expireTime = value; }
        }

        public DateTime LastUpdated
        {
            get { return this.ExpireTime.Subtract(this.ExpireDuration); }
        }

        public bool IsExpired
        {
            get { return (DateTime.Now > this.ExpireTime); }
        }

        public CachePolicy(Type typeOfEntity, TimeSpan expireDuration, CacheType cacheType, DateTime expireTime)
            :base(typeOfEntity)
        {
            this.ExpireDuration = expireDuration;
            this.CacheType = cacheType;
            this.ExpireTime = expireTime;
        }

        public void CacheUpdated()
        {
            this.ExpireTime = DateTime.Now.Add(this.ExpireDuration);
        }
    }
}
