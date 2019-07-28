using System;
using System.Collections.Generic;
using ServiceRestrictions.Internal.Options;

namespace ServiceRestrictions.Internal
{
    [Serializable]
    public class BuildingOptionsEntry
    {
        public ushort Key;

        public ServiceBuildingOptions Value;

        public BuildingOptionsEntry()
        {
        }

        public BuildingOptionsEntry(ushort key, ServiceBuildingOptions options)
        {
            Key = key;
            Value = options;
        }

        public static implicit operator BuildingOptionsEntry(KeyValuePair<ushort, ServiceBuildingOptions> kvp)
        {
            return new BuildingOptionsEntry(kvp.Key, kvp.Value);
        }

        public static implicit operator KeyValuePair<ushort, ServiceBuildingOptions>(BuildingOptionsEntry entry)
        {
            return new KeyValuePair<ushort, ServiceBuildingOptions>(entry.Key, entry.Value);
        }
    }
}