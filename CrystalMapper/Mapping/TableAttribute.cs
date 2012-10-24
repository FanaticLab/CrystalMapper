/*
 * Author: Faraz Masood Khan 
 * 
 * Date: 6/5/2009 2:09:52 PM
 * 
 * Class: TableAttribute
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
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        private string tableName;

        public string TableName
        {
            get { return this.tableName; }
        }

        public TableAttribute(string tableName)
        {
            this.tableName = tableName;
        }
    }
}
