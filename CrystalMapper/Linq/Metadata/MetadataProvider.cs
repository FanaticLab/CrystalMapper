using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalMapper.Mapping;

namespace CrystalMapper.Linq.Metadata
{
    internal static class MetadataProvider
    {
        private static ConcurrentDictionary<Type, TableMetadata> tablesMetadata = new ConcurrentDictionary<Type, TableMetadata>();

        public static TableMetadata GetMetadata(Type type)
        {
            if (!tablesMetadata.TryGetValue(type, out TableMetadata tableMetadata))
            {
                tableMetadata = new TableMetadata(type);
                tablesMetadata.TryAdd(type, tableMetadata);
            }

            return tableMetadata;
        }
    }
}
