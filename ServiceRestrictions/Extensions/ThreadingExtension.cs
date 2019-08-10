using ICities;
using ServiceRestrictions.GUI;
using ServiceRestrictions.GUI.Districts;
using ServiceRestrictions.Internal;
using UnityEngine;

namespace ServiceRestrictions.Extensions
{
    public class ThreadingExtension : ThreadingExtensionBase
    {
        public override void OnUpdate(float realTimeDelta, float simulationTimeDelta)
        {
            base.OnUpdate(realTimeDelta, simulationTimeDelta);

            if (!LoadingExtension._isDoneLoading)
                return;

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (RestrictedDistrictsPanel.Instance != null)
                {
                    if (RestrictedDistrictsPanel.Instance.CampusPanelWrapper != null &&
                        RestrictedDistrictsPanel.Instance.CampusPanelWrapper.isVisible)
                    {
                        RestrictedDistrictsPanel.Instance.CampusPanelWrapper.isVisible = false;
                        UIUtils.DeepDestroy(RestrictedDistrictsPanel.Instance.CampusPanelWrapper);
                        return;
                    }

                    if (RestrictedDistrictsPanel.Instance.IndustriesPanelWrapper != null &&
                        RestrictedDistrictsPanel.Instance.IndustriesPanelWrapper.isVisible)
                    {
                        RestrictedDistrictsPanel.Instance.IndustriesPanelWrapper.isVisible = false;
                        UIUtils.DeepDestroy(RestrictedDistrictsPanel.Instance.IndustriesPanelWrapper);
                        return;
                    }

                    if (RestrictedDistrictsPanel.Instance.ParkPanelWrapper != null &&
                        RestrictedDistrictsPanel.Instance.ParkPanelWrapper.isVisible)
                    {
                        RestrictedDistrictsPanel.Instance.ParkPanelWrapper.isVisible = false;
                        UIUtils.DeepDestroy(RestrictedDistrictsPanel.Instance.ParkPanelWrapper);
                        return;
                    }
                }

                if (ServiceRestrictTool.instance.RestrictedDistrictsPanelWrapper != null &&
                    ServiceRestrictTool.instance.RestrictedDistrictsPanelWrapper.isVisible)
                {
                    ServiceRestrictTool.instance.RestrictedDistrictsPanelWrapper.isVisible = false;
                    UIUtils.DeepDestroy(ServiceRestrictTool.instance.RestrictedDistrictsPanelWrapper);
                }
            }
        }
    }
}