using System.Linq;
using ColossalFramework.Plugins;
using CustomizeItExtended.External;
using ServiceRestrictions.Internal;

namespace ServiceRestrictions.Compatibility
{
    public class CustomizeItExtendedCompatibility
    {
        public static bool IsCustomizeItExtendedActive()
        {
            return PluginManager.instance.GetPluginsInfo().Where(x => x.isEnabled)
                .Any(plugin => plugin.publishedFileID.AsUInt64 == 1806759255);
        }

        public static string RetrieveBuildingName()
        {
            var info = BuildingManager.instance.m_buildings.m_buffer[ServiceRestrictTool.instance.SelectedBuildingID]
                .Info;

            if (!IsCustomizeItExtendedActive())
                return BuildingManager.instance.GetBuildingName(ServiceRestrictTool.instance.SelectedBuildingID,
                    InstanceID.Empty);

            if (!CustomizeItExtendedAccess.CustomBuildingNames.TryGetValue(info.name, out var nameProps))
                return BuildingManager.instance.GetBuildingName(ServiceRestrictTool.instance.SelectedBuildingID,
                    InstanceID.Empty);

            if (nameProps.DefaultName &&
                !nameProps.Unaffected.Contains(ServiceRestrictTool.instance.SelectedBuildingID))
                return nameProps.CustomName;

            if (nameProps.Unaffected.Contains(ServiceRestrictTool.instance.SelectedBuildingID))
                return BuildingManager.instance.GetBuildingName(ServiceRestrictTool.instance.SelectedBuildingID,
                    InstanceID.Empty);

            return BuildingManager.instance.GetBuildingName(ServiceRestrictTool.instance.SelectedBuildingID,
                InstanceID.Empty);
        }

        public static string RetrieveBuildingName(ushort buildingID)
        {
            var info = BuildingManager.instance.m_buildings.m_buffer[buildingID]
                .Info;

            if (!IsCustomizeItExtendedActive())
                return BuildingManager.instance.GetBuildingName(buildingID,
                    InstanceID.Empty);

            if (!CustomizeItExtendedAccess.CustomBuildingNames.TryGetValue(info.name, out var nameProps))
                return BuildingManager.instance.GetBuildingName(buildingID,
                    InstanceID.Empty);

            if (nameProps.DefaultName &&
                !nameProps.Unaffected.Contains(buildingID))
                return nameProps.CustomName;

            if (nameProps.Unaffected.Contains(buildingID))
                return BuildingManager.instance.GetBuildingName(buildingID,
                    InstanceID.Empty);

            return BuildingManager.instance.GetBuildingName(buildingID,
                InstanceID.Empty);
        }
    }
}