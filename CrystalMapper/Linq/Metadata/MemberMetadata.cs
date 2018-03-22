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

            this.ColumnName = attributes.Length == 0 ? memberInfo.Name : attributes[0].ColumnName;
            this.Member = memberInfo;
        }

        public static MemberMetadata[] GetMembersMetadata(Type type)
        {
            List<MemberMetadata> membersMetadata = new List<MemberMetadata>();
            foreach (var memberInfo in type.GetProperties())
            {
                var propertyType = memberInfo.PropertyType;
                if (propertyType.IsPrimitive || propertyType == typeof(string) || propertyType == typeof(DateTime) || (propertyType.IsGenericType
                       && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    membersMetadata.Add(new MemberMetadata(memberInfo));
                //ColumnAttribute[] columnAttributes;
                //if ((columnAttributes = (ColumnAttribute[])memberInfo.GetCustomAttributes(typeof(ColumnAttribute), true)) != null && columnAttributes.Length == 1)
                //    membersMetadata.Add(new MemberMetadata(memberInfo));
            }

            return membersMetadata.ToArray();
        }
    }
}
