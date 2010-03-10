#region Copyright (c) 2008 Microsoft Corporation.  All rights reserved.
// Copyright (c) 2008 Microsoft Corporation.  All rights reserved.
// 
// THIS SOFTWARE COMES "AS IS", WITH NO WARRANTIES.  THIS
// MEANS NO EXPRESS, IMPLIED OR STATUTORY WARRANTY, INCLUDING
// WITHOUT LIMITATION, WARRANTIES OF MERCHANTABILITY OR FITNESS
// FOR A PARTICULAR PURPOSE OR ANY WARRANTY OF TITLE OR
// NON-INFRINGEMENT.
//
// MICROSOFT WILL NOT BE LIABLE FOR ANY DAMAGES RELATED TO
// THE SOFTWARE, INCLUDING DIRECT, INDIRECT, SPECIAL,
// CONSEQUENTIAL OR INCIDENTAL DAMAGES, TO THE MAXIMUM EXTENT
// THE LAW PERMITS, NO MATTER WHAT LEGAL THEORY IT IS
// BASED ON.
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CrystalMapper.Linq.Helper
{
    internal static class FormatHelper
    {
        public static string EscapeSingleQuotes(string str)
        {
            if (str.IndexOf('\'') < 0)
            {
                return str;
            }
            StringBuilder builder = new StringBuilder();
            foreach (char ch in str)
            {
                if (ch == '\'')
                    builder.Append("''");
                else
                    builder.Append(ch);
            }
            return builder.ToString();
        }

        public static string WrapInBrackets(string column)
        {
            column = column.Trim();

            if (column[0] == '[' && column[column.Length - 1] == ']')
                return column;

            return "[" + column + "]";
        }

        public static string FormatDbValue(object value)
        {
            if (value == null)
            {
                return "NULL";
            }
            Type type = value.GetType();
            if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(Nullable<>)))
            {
                type = type.GetGenericArguments()[0];
            }
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Object:
                    if (!(value is Guid))
                        throw new NotSupportedException(string.Format("The constant for '{0}' is not supported", value));

                    return "'" + value + "'";

                case TypeCode.Boolean:
                    return (bool)value ? "1" : "0"; ;

                case TypeCode.Char:
                case TypeCode.DateTime:
                case TypeCode.String:
                    return "'" + EscapeSingleQuotes(value.ToString()) + "'";

                default:
                    return value.ToString();
            }
        }

    }
}
