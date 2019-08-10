using Harmony;
using ServiceRestrictions.Internal;
using ServiceRestrictions.Settings;

namespace ServiceRestrictions.Patches
{
    [HarmonyPatch(typeof(DistrictManager), "ReleaseDistrict")]
    public static class ReleaseDistrictPatch
    {
        public static void Postfix(byte district)
        {
            for (ushort x = 0; x < ServiceRestrictTool.instance.CustomServiceBuildingOptions.Count; x++)
                if (ServiceRestrictTool.instance.CustomServiceBuildingOptions[x].CoveredDistricts.Contains(district))
                    ServiceRestrictTool.instance.CustomServiceBuildingOptions[x].CoveredDistricts.Remove(district);
        }
    }

    [HarmonyPatch(typeof(DistrictManager), "ReleasePark")]
    public static class ReleaseParkPatch
    {
        public static void Postfix(byte park)
        {
            for (ushort x = 0; x < ServiceRestrictTool.instance.CustomServiceBuildingOptions.Count; x++)
                if (ServiceRestrictTool.instance.CustomServiceBuildingOptions[x].CoveredParks.Contains(park))
                    ServiceRestrictTool.instance.CustomServiceBuildingOptions[x].CoveredParks.Remove(park);
        }
    }

    [HarmonyPatch(typeof(DistrictManager), "CreateDistrict")]
    public static class CreateDistrictPatch
    {
        public static void Postfix(byte district)
        {
            if (ServiceRestrictionsMod.Settings.DistrictMode ==
                ServiceRestrictionSettings.NewDistrictMode.AlwaysCoverage)
                for (ushort x = 0; x < ServiceRestrictTool.instance.CustomServiceBuildingOptions.Count; x++)
                    ServiceRestrictTool.instance.CustomServiceBuildingOptions[x].CoveredDistricts.Add(district);
        }
    }

    [HarmonyPatch(typeof(DistrictManager), "CreatePark")]
    public static class CreateParkPatch
    {
        public static void Postfix(byte park)
        {
            if (ServiceRestrictionsMod.Settings.ParkMode ==
                ServiceRestrictionSettings.NewDistrictMode.AlwaysCoverage)
                for (ushort x = 0; x < ServiceRestrictTool.instance.CustomServiceBuildingOptions.Count; x++)
                    ServiceRestrictTool.instance.CustomServiceBuildingOptions[x].CoveredParks.Add(park);
        }
    }
}