/**********************************
 * Author: Faraz Masood Khan 
 * Description: Table mapping attribute
 * Project: http://crystalmapper.codeplex.com
 * Copyright (c) 2013 FanaticLab
 **********************************/

using System;

namespace CrystalMapper.Mapping
{
    /// <summary>
    /// Class and table mapping attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        /// <summary>
        /// Name of the table this class maps to
        /// </summary>
        public string TableName { get; private set; }

        /// <summary>
        /// Creates mapping between class and table mapping
        /// </summary>
        /// <param name="tableName">Name of the table class maps to</param>
        public TableAttribute(string tableName)
        {
            this.TableName = tableName;
        }
    }
}
