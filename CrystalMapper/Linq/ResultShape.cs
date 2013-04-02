/***********************************************
 * Author: Faraz Masood Khan 
 * Description: Result type return by sql query
 * Project: http://www.fanaticlab.com/projects/crystalmapper/
 * Copyright (c) 2013 FanaticLab
 ***********************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystalMapper.Linq
{
    /// <summary>
    /// Shape of query result
    /// </summary>
    public enum ResultShape
    {
        /// <summary>
        /// Query is not expected to have a return value return no result
        /// </summary>
        None,

        /// <summary>
        /// It returns a scalar value
        /// </summary>
        Singleton,

        /// <summary>
        /// It returns a sequence of elements
        /// </summary>
        Sequence
    }
}
