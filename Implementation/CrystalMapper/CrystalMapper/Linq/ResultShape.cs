using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystalMapper.Linq
{
    public enum ResultShape
    {
        None,       // it means that the query is not expected to have a return value
        Singleton,  // it returns a single element
        Sequence    // it returns a sequence of elements
    }
}
