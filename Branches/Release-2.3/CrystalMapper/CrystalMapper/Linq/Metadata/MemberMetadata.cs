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

        public object DefTypeValue { get; private set; }

        public string ParamName { get; private set; }

        public MemberMetadata(MemberInfo memberInfo)
        {
            ColumnAttribute[] columnAttributes = (ColumnAttribute[])memberInfo.GetCustomAttributes(typeof(ColumnAttribute), true);

            if (columnAttributes != null && columnAttributes.Length > 0)
            {
                this.ColumnName = columnAttributes[0].ColumnName;
                this.ParamName = columnAttributes[0].ParamName;
                this.DefTypeValue = columnAttributes[0].DefTypeValue;    
            }
            else
            {
                this.ColumnName = memberInfo.Name;
                this.ParamName = "@" + memberInfo.Name;
            }

            this.Member = memberInfo;
        }

        public static MemberMetadata[] GetMembersMetadata(Type type)
        {
            List<MemberMetadata> membersMetadata = new List<MemberMetadata>();
            foreach (MemberInfo memberInfo in type.GetMembers())
            {
                ColumnAttribute[] columnAttributes;
                if ((columnAttributes = (ColumnAttribute[])memberInfo.GetCustomAttributes(typeof(ColumnAttribute), true)) != null && columnAttributes.Length == 1)
                    membersMetadata.Add(new MemberMetadata(memberInfo));
            }

            return membersMetadata.ToArray();
        }
    }
}
