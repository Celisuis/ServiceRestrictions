using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ColossalFramework.UI;
using Harmony;

namespace ServiceRestrictions.Patches
{
    [HarmonyPatch(typeof(CityServiceWorldInfoPanel), "OnSetTarget")]
    public static class PanelOnSetTargetPatch
    {
        public static void Postfix(CityServiceWorldInfoPanel __instance)
        {
            InstanceID instanceID = (InstanceID) __instance.GetType()
                .GetField("m_InstanceID", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(__instance);

            var building = BuildingManager.instance.m_buildings.m_buffer[instanceID.Building].Info;

            if (building.m_buildingAI.GetType().IsInstanceOfType(typeof(ExtractingFacilityAI)) ||
                building.m_buildingAI.GetType().IsInstanceOfType(typeof(ProcessingFacilityAI)) ||
                building.m_buildingAI.GetType().IsInstanceOfType(typeof(AuxiliaryBuildingAI)) || 
                building.m_buildingAI.GetType().IsInstanceOfType(typeof(MainIndustryBuildingAI)) || 
                building.m_buildingAI.GetType().IsInstanceOfType(typeof(IndustryBuildingAI)) ||
                building.m_buildingAI.GetType().IsInstanceOfType(typeof(MainCampusBuildingAI)) ||
                building.m_buildingAI.GetType().IsInstanceOfType(typeof(ParkBuildingAI)) ||
                building.m_buildingAI.GetType().IsInstanceOfType(typeof(ParkGateAI)))
            {

                var toggleButton = __instance.component.Find("ServiceRestrictionToggleButton") as UIButton;

                if (toggleButton == null)
                    return;
                toggleButton.isEnabled = false;
                toggleButton.tooltip = "Service Restrictions does not currently cover this building.";
            }
        }
    }
}
