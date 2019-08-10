using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Harmony;
using ServiceRestrictions.Internal;

namespace ServiceRestrictions.Patches
{
    [HarmonyPatch(typeof(DistrictManager), "ReleaseDistrict")]
    public static class ReleaseDistrictPatch
    {
        public static void Postfix(byte district)
        {
            for (ushort x = 0; x < ServiceRestrictTool.instance.CustomServiceBuildingOptions.Count; x++)
            {
                if (ServiceRestrictTool.instance.CustomServiceBuildingOptions[x].CoveredDistricts.Contains(district))
                {
                    ServiceRestrictTool.instance.CustomServiceBuildingOptions[x].CoveredDistricts.Remove(district);
                }

            }
        }
    }

    [HarmonyPatch(typeof(DistrictManager), "ReleasePark")]
    public static class ReleaseParkPatch
    {
        public static void Postfix(byte park)
        {
            for (ushort x = 0; x < ServiceRestrictTool.instance.CustomServiceBuildingOptions.Count; x++)
            {
                if (ServiceRestrictTool.instance.CustomServiceBuildingOptions[x].CoveredParks.Contains(park))
                {
                    ServiceRestrictTool.instance.CustomServiceBuildingOptions[x].CoveredParks.Remove(park);
                }
            }
        }
    }
}
