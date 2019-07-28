using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using ICities;
using ServiceRestricter.Internal;
using ServiceRestricter.Internal.Options;

namespace ServiceRestricter.Extensions
{
    public class SerializationExtension : SerializableDataExtensionBase
    {
        private static readonly string _dataId = "Service-Restricter";

        private ServiceRestrictTool Instance => ServiceRestrictTool.instance;

        private List<BuildingOptionsEntry> CustomBuildingOptions
        {
            get
            {
                var list = new List<BuildingOptionsEntry>();

                if (Instance.CustomServiceBuildingOptions == null)
                    return list;

                foreach(var item in Instance.CustomServiceBuildingOptions)
                    list.Add(item);

                return list;
            }
            set
            {
                var collection = new Dictionary<ushort, ServiceBuildingOptions>();

                if (value == null)
                    return;

                foreach(var item in value)
                    collection.Add(item.Key, item.Value);

                Instance.CustomServiceBuildingOptions = collection;
            }
        }

        public override void OnSaveData()
        {
            base.OnSaveData();

            if (Instance.CustomServiceBuildingOptions == null)
                return;

            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, CustomBuildingOptions);

                serializableDataManager.SaveData(_dataId, stream.ToArray());
            }
        }

        public override void OnLoadData()
        {
            base.OnLoadData();

            var data = serializableDataManager.LoadData(_dataId);

            if (data == null || data.Length == 0)
                return;

            using (var stream = new MemoryStream(data))
            {
                var formatter = new BinaryFormatter();
                CustomBuildingOptions = formatter.Deserialize(stream) as List<BuildingOptionsEntry>;
            }
        }
    }
}
