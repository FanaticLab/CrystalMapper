using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Mapping;

namespace CrystalMapper.Linq.Metadata
{
    internal static class MetadataProvider
    {
        private static Dictionary<Type, TableMetadata> tablesMetadata = new Dictionary<Type, TableMetadata>();

        public static TableMetadata GetMetadata(Type type)
        {
            TableMetadata tableMetadata;
            if (!tablesMetadata.TryGetValue(type, out tableMetadata))
            {
                try
                {
                    TableAttribute[] tableAttributes = (TableAttribute[])type.GetCustomAttributes(typeof(TableAttribute), true);
                    if (tableAttributes.Length > 0)
                    {
                        tableMetadata = new TableMetadata(type);
                        tablesMetadata.Add(type, tableMetadata);
                    }
                }
                catch { }
            }

            return tableMetadata;
        }
    }
}
