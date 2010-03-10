using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace CrystalMapper
{
    public static class ReadOnlyExtension
    {
        public static ReadOnlyCollection<T> ToReadOnly<T>(this IEnumerable<T> collection)
        {
            return (new List<T>(collection)).AsReadOnly();
        }
    }
}
