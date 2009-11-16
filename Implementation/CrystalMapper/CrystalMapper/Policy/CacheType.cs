using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystalMapper.Cache
{
    [Flags]
    public enum CacheType
    {
        Select = 1,

        Create = 2,

        Update = 4,

        Delete = 8
    }
}
