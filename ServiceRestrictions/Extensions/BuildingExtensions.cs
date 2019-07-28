using ColossalFramework.UI;
using ServiceRestrictions.GUI.Districts;
using ServiceRestrictions.Internal;
using UIUtils = ServiceRestrictions.GUI.UIUtils;

namespace ServiceRestrictions.Extensions
{
    public static class BuildingExtensions
    {
        public static RestrictedDistrictPanelWrapper GenerateDistrictsPanelWrapper(this ushort buildingID)
        {
            ServiceRestrictTool.instance.SelectedBuildingID = buildingID;

            if (ServiceRestrictTool.instance.RestrictedDistrictsPanelWrapper != null)
                UIUtils.DeepDestroy(ServiceRestrictTool.instance.RestrictedDistrictsPanelWrapper);

            return UIView.GetAView().AddUIComponent(typeof(RestrictedDistrictPanelWrapper)) as
                RestrictedDistrictPanelWrapper;
        }
    }
}