using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CrystalMapper.Linq.Helper
{
    internal static class TypeHelper
    {
        /// <summary>
        /// What is the type of the current member?
        /// </summary>
        public static Type GetMemberType(MemberInfo mi)
        {
            FieldInfo info = mi as FieldInfo;
            if (info != null)
                return info.FieldType;

            PropertyInfo info2 = mi as PropertyInfo;
            if (info2 != null)
                return info2.PropertyType;

            EventInfo info3 = mi as EventInfo;
            if (info3 != null)
                return info3.EventHandlerType;

            return null;
        }

        /// <summary>
        /// If mi is a Property, then its sets it value to value
        /// If mi is a Field, it assigns value to it
        /// </summary>
        public static void SetMemberValue(
          object instance, MemberInfo mi, object value)
        {
            FieldInfo info = mi as FieldInfo;
            if (info != null)
            {
                info.SetValue(instance, value, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, null);
                return;
            }

            PropertyInfo info2 = mi as PropertyInfo;
            if (info2 != null)
            {
                info2.SetValue(instance, value, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, null, null);
                return;
            }

            throw new NotSupportedException("The member type is not supported!");
        }
    }
}
