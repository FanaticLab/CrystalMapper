using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Mapping;

namespace CrystalMapper.Linq.Metadata
{
    internal class TableMetadata
    {
        public Type Type { get; private set; }

        public string TableName { get; private set; }

        public MemberMetadata[] Members { get; private set; }

        public TableMetadata(Type type) : this(type, GetTableAttribute(type))
        { }

        public TableMetadata(Type type, TableAttribute attribute)
        {
            this.Type = type;
            this.TableName = attribute.TableName;
            this.Members = MemberMetadata.GetMembersMetadata(this.Type);
        }

        private static TableAttribute GetTableAttribute(Type type)
        {
            TableAttribute[] tableAttributes = (TableAttribute[])type.GetCustomAttributes(typeof(TableAttribute), true);
            if (tableAttributes.Length == 0)
                return new TableAttribute(type.Name);

            return tableAttributes[0];
        }
    }
}
