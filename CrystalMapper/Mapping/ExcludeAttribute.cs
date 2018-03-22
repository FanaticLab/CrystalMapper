using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystalMapper.Mapping
{
    /// <summary>
    /// Property to exclude column from mapping
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ExcludeAttribute : Attribute
    {

    }
}
