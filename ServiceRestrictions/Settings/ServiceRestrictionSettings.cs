using System;
using System.IO;
using System.Xml.Serialization;
using ColossalFramework.IO;

namespace ServiceRestrictions.Settings
{
    public class ServiceRestrictionSettings
    {

        public enum NewDistrictMode
        {
            NoCoverage,
            CloseCoverage,
            MediumCoverage,
            FarCoverage,
            AlwaysCoverage
        }

        [XmlIgnore] private static readonly string ConfigPath =
            Path.Combine(DataLocation.localApplicationData, "ServiceRestrictSettings.xml");

        public float PanelX = 8f;

        public float PanelY = 65f;

        public NewDistrictMode DistrictMode;

        public NewDistrictMode ParkMode;

        public void Save()
        {
            var serializer = new XmlSerializer(typeof(ServiceRestrictionSettings));

            using (var writer = new StreamWriter(ConfigPath))
            {
                serializer.Serialize(writer, ServiceRestrictionsMod.Settings);
            }
        }

        public static ServiceRestrictionSettings Load()
        {
            var serializer = new XmlSerializer(typeof(ServiceRestrictionSettings));
            try
            {
                using (var reader = new StreamReader(ConfigPath))
                {
                    return (ServiceRestrictionSettings) serializer.Deserialize(reader);
                }
            }
            catch (Exception)
            {
                return new ServiceRestrictionSettings();
            }
        }
    }
}