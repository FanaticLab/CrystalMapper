using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using CrystalMapper.Mapping;

namespace CrystalMapper.Linq.Metadata
{
    internal class MemberMetadata
    {
        public MemberInfo Member { get; private set; }

        public string ColumnName { get; private set; }

        public MemberMetadata(MemberInfo memberInfo)
        {
            ColumnAttribute[] attributes = (ColumnAttribute[])memberInfo.GetCustomAttributes(typeof(ColumnAttribute), true);

            this.ColumnName = attributes.Length != 0
                ? attributes[0].ColumnName
                : memberInfo.DeclaringType != null
                ? memberInfo.Name
                : "*";

            this.Member = memberInfo;
        }

        public static MemberMetadata[] GetMembersMetadata(Type type)
        {
            List<MemberMetadata> membersMetadata = new List<MemberMetadata>();
            foreach (var propertyInfo in type.GetProperties())
            {
                var propertyType = propertyInfo.PropertyType;
                if (propertyInfo.CanRead && propertyInfo.CanWrite && !propertyInfo.IsDefined(typeof(ExcludeAttribute), true)
                    && (propertyType.IsPrimitive || propertyType == typeof(string) || propertyType == typeof(DateTime) || propertyType.IsEnum
                    || (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))))
                    membersMetadata.Add(new MemberMetadata(propertyInfo));
            }

            return membersMetadata.ToArray();
        }
    }
}
