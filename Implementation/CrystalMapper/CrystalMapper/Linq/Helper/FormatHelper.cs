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

        public static string RemovesBrackets(string value)
        {
            if (value != null)
            {
                value = value.TrimStart(' ');

                if (value.StartsWith("("))
                    return value.Substring(1, value.LastIndexOf(')'));
            }

            return value;
        }
    }
}
