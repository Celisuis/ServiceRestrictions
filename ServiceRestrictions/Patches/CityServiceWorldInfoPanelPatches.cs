using System.Reflection;
using ColossalFramework.UI;
using Harmony;
using ServiceRestrictions.Helpers;

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


            if (building.GetService() == ItemClass.Service.FireDepartment ||
                building.GetService() == ItemClass.Service.Garbage ||
                building.GetService() == ItemClass.Service.HealthCare ||
                building.GetService() == ItemClass.Service.Disaster ||
                building.GetService() == ItemClass.Service.PoliceDepartment)
                return;

            if (BuildingHelper.DisplayDistrictsButton(building.m_buildingAI))
                return;

            var toggleButton = __instance.component.Find("ServiceRestrictionToggleButton") as UIButton;

            if (toggleButton == null)
                return;
            toggleButton.isEnabled = false;
            toggleButton.tooltip = "Service Restrictions does not currently cover this building.";
        }
    }
}