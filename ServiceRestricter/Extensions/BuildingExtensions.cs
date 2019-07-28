using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ColossalFramework.UI;
using ServiceRestricter.GUI;
using ServiceRestricter.Internal;
using UIUtils = ServiceRestricter.GUI.UIUtils;

namespace ServiceRestricter.Extensions
{
    public static class BuildingExtensions
    {
        public static RestrictedDistrictPanelWrapper GenerateDistrictsPanelWrapper(this ushort buildingID)
        {
            ServiceRestrictTool.instance.SelectedBuildingID = buildingID;

            if(ServiceRestrictTool.instance.RestrictedDistrictsPanelWrapper != null)
                UIUtils.DeepDestroy(ServiceRestrictTool.instance.RestrictedDistrictsPanelWrapper);

            return UIView.GetAView().AddUIComponent(typeof(RestrictedDistrictPanelWrapper)) as
                RestrictedDistrictPanelWrapper;
        }
    }
}
