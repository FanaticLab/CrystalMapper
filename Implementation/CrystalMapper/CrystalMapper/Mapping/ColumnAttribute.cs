/*
 * Author: Faraz Masood Khan 
 * 
 * Date: 6/5/2009 2:09:52 PM
 * 
 * Class: ColumnAttribute
 * 
 * Copyright: Faraz Masood Khan @ Copyright ©  2009
 * 
 * Email: mk.faraz@gmail.com
 * 
 * Blogs: http://csharplive.wordpress.com, http://farazmasoodkhan.wordpress.com
 * 
 */

using System;

namespace CrystalMapper.Mapping
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        private string columnName;
        private string paramName;
        //private bool isSensitiveColumn;

        public string ColumnName
        {
            get { return this.columnName; }
        }

        public string ParamName
        {
            get { return this.paramName; }
        }

        //public bool IsSensitiveColumn
        //{
        //    get { return this.isSensitiveColumn; }
        //}

        public ColumnAttribute(string columnName, string paramName)            
        {
            this.columnName = columnName;
            this.paramName = paramName;
        }

        //public ColumnAttribute(string columnName, string paramName, bool isSensitiveColumn)
        //{
        //    this.paramName = paramName;
        //    this.columnName = columnName;            
        //    this.isSensitiveColumn = isSensitiveColumn;
        //}
    }
}

