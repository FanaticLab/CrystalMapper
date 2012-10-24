using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystalMapper
{
    public enum PersistedStatus
    {
        New = 0,
        
        Dirty = 1,
     
        Updated = 2,

        Deleted = 3
    }
}
