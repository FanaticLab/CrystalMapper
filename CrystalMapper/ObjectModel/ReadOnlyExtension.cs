/****************************************************************
 * Author: Faraz Masood Khan 
 * Description: Extension functions for ObjectModel
 * Project: http://crystalmapper.codeplex.com
 * Copyright (c) 2013 FanaticLab
 ****************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace CrystalMapper.ObjectModel
{
    /// <summary>
    /// Contains extension functions for ObjectModel
    /// </summary>
    public static class ReadOnlyExtension
    {
        /// <summary>
        /// Returns readonly collection
        /// </summary>
        /// <typeparam name="T">Type of collection</typeparam>
        /// <param name="collection">Source collection</param>
        /// <returns>Readonly collection</returns>
        public static ReadOnlyCollection<T> ToReadOnly<T>(this IEnumerable<T> collection)
        {
            return (new List<T>(collection)).AsReadOnly();
        }
    }
}
