/**********************************
 * Author: Faraz Masood Khan 
 * Description: Table column mapping attribute
 * Project: http://www.fanaticlab.com/projects/crystalmapper/
 * Copyright (c) 2013 FanaticLab
 **********************************/

using System;

namespace CrystalMapper.Mapping
{
    /// <summary>
    /// Property and column mapping attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        /// <summary>
        /// Name of the column to map
        /// </summary>
        public string ColumnName { get; private set; }

        /// <summary>
        /// Parameter name to use when query database against this column
        /// </summary>
        public string ParamName { get; private set; }

        /// <summary>
        /// Default value of the property
        /// </summary>
        public object DefValue { get; private set; }

        /// <summary>
        /// Creates mapping between column and property
        /// </summary>
        /// <param name="columnName">Name of the column to map</param>
        /// <param name="paramName">Name of the parameter to use in mapping</param>
        public ColumnAttribute(string columnName, string paramName)
            : this(columnName, paramName, (object)null)
        {

        }

        /// <summary>
        /// Creates mapping between column and property
        /// </summary>
        /// <param name="columnName">Name of the column to map</param>
        /// <param name="paramName">Name of the parameter to use in mapping</param>
        /// <param name="defValue">Default value of the property</param>
        public ColumnAttribute(string columnName, string paramName, object defValue)
        {
            this.ColumnName = columnName;
            this.ParamName = paramName;
            this.DefValue = defValue;
        }

        /// <summary>
        /// Creates mapping between column and property
        /// </summary>
        /// <param name="columnName">Name of the column to map</param>
        /// <param name="paramName">Name of the parameter to use in mapping</param>
        /// <param name="defValueType">Creates default value from type</param>
        public ColumnAttribute(string columnName, string paramName, Type defValueType)
            : this(columnName, paramName, Activator.CreateInstance(defValueType))
        { }
    }
}

