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
        private object defTypeValue;

        public string ColumnName
        {
            get { return this.columnName; }
        }

        public string ParamName
        {
            get { return this.paramName; }
        }

        public object DefTypeValue
        {
            get { return this.defTypeValue; }
        }

        public ColumnAttribute(string columnName, string paramName)
            : this(columnName, paramName, (object)null)
        {

        }
        
        public ColumnAttribute(string columnName, string paramName, object defTypeValue)
        {
            this.columnName = columnName;
            this.paramName = paramName;
            this.defTypeValue = defTypeValue;
        }

        public ColumnAttribute(string columnName, string paramName, Type type)
            : this(columnName, paramName, Activator.CreateInstance(type))
        { }
    }
}

