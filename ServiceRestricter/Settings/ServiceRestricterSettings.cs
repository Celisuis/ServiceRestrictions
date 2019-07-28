using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using ColossalFramework.IO;

namespace ServiceRestricter.Settings
{
    public class ServiceRestricterSettings
    {
        [XmlIgnore] private static readonly string ConfigPath =
            Path.Combine(DataLocation.localApplicationData, "ServiceRestrictSettings.xml");

        public float PanelX = 8f;

        public float PanelY = 65f;

        public void Save()
        {

            var serializer = new XmlSerializer(typeof(ServiceRestricterSettings));

            using (var writer = new StreamWriter(ConfigPath))
            {
                serializer.Serialize(writer, ServiceResticterMod.Settings);
            }
        }

        public static ServiceRestricterSettings Load()
        {
            var serializer = new XmlSerializer(typeof(ServiceRestricterSettings));
            try
            {
                using (var reader = new StreamReader(ConfigPath))
                {
                    return (ServiceRestricterSettings)serializer.Deserialize(reader);
                }
            }
            catch (Exception e)
            {
                return new ServiceRestricterSettings();
            }
        }
    }
}
