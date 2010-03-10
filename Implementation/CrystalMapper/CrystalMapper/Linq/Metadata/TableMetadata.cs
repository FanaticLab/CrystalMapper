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

        public TableMetadata(Type type)
        {
            TableAttribute[] tableAttributes = (TableAttribute[])type.GetCustomAttributes(typeof(TableAttribute), true);
            if (tableAttributes == null || tableAttributes.Length == 0)
                throw new InvalidOperationException(string.Format("Type '{0}' is not decorated with TableAttribute", type.Name));

            this.Type = type;
            this.TableName = tableAttributes[0].TableName;
            this.Members = MemberMetadata.GetMembersMetadata(this.Type);            
        }
    }
}
