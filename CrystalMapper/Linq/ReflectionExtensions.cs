/***********************************************
 * Author: Faraz Masood Khan 
 * Description: Result type return by sql query
 * Project: http://crystalmapper.codeplex.com
 * Copyright (c) 2013 FanaticLab
 ***********************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CrystalMapper.Linq
{
    /// <summary>
    /// Contains extension functions for .NET reflection objects
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Return the value of reflected member of the object
        /// </summary>
        /// <param name="member">Relected member</param>
        /// <param name="instance">Object instance</param>
        /// <returns>Value of member</returns>
        public static object GetValue(this MemberInfo member, object instance)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Property:
                    return ((PropertyInfo)member).GetValue(instance, null);
                case MemberTypes.Field:
                    return ((FieldInfo)member).GetValue(instance);
                default:
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Set value of of reflected member of the object
        /// </summary>
        /// <param name="member">Reflected member</param>
        /// <param name="instance">Object instance</param>
        /// <param name="value">Value of member</param>
        public static void SetValue(this MemberInfo member, object instance, object value)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Property:
                    ((PropertyInfo)member).SetValue(instance, value, null);
                    break;
                case MemberTypes.Field:
                     ((FieldInfo)member).SetValue(instance, value);
                     break;
                default:
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Gets return type of reflected member of object
        /// </summary>
        /// <param name="member">Reflected member</param>
        /// <returns>Type of return value</returns>
        public static Type GetMemberType(this MemberInfo member)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Property:
                    return ((PropertyInfo)member).PropertyType;
                case MemberTypes.Field:
                    return ((FieldInfo)member).FieldType;
                default:
                    return null;
            }
        }
    }
}
