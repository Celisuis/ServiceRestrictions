using System.Collections.Generic;
using System.Reflection;
using ColossalFramework;
using ColossalFramework.UI;
using ServiceRestrictions.Extensions;
using ServiceRestrictions.GUI.Districts;
using ServiceRestrictions.Internal.Options;
using UnityEngine;
using UIUtils = ServiceRestrictions.GUI.UIUtils;

namespace ServiceRestrictions.Internal
{
    public class ServiceRestrictTool : Singleton<ServiceRestrictTool>
    {
        private bool _isInitialized;

        private bool _isPanelInitialized;

        private UIButton _toggleButton;

        internal Dictionary<ushort, ServiceBuildingOptions> CustomServiceBuildingOptions =
            new Dictionary<ushort, ServiceBuildingOptions>();

        internal RestrictedDistrictPanelWrapper RestrictedDistrictsPanelWrapper;

        internal ushort SelectedBuildingID;

        internal CityServiceWorldInfoPanel ServiceInfoPanel;

        public void Initialize()
        {
            if (_isInitialized)
                return;

            AddPanel();
            _isInitialized = true;
        }

        private void AddPanel()
        {
            if (_isPanelInitialized)
                return;

            ServiceInfoPanel = GameObject.Find("(Library) CityServiceWorldInfoPanel")
                .GetComponent<CityServiceWorldInfoPanel>();

            if (ServiceInfoPanel == null)
                return;

            AddButton(ServiceInfoPanel, out _toggleButton, new Vector3(257f, 15f));

            ServiceInfoPanel.component.eventIsEnabledChanged += (component, value) =>
            {
                if (!value)
                {
                    if (RestrictedDistrictsPanel.Instance != null)
                    {
                        if (RestrictedDistrictsPanel.Instance.CampusPanelWrapper != null &&
                            RestrictedDistrictsPanel.Instance.CampusPanelWrapper.isVisible)
                        {
                            RestrictedDistrictsPanel.Instance.CampusPanelWrapper.isVisible = false;
                            UIUtils.DeepDestroy(RestrictedDistrictsPanel.Instance.CampusPanelWrapper);
                        }

                        if (RestrictedDistrictsPanel.Instance.ParkPanelWrapper != null &&
                            RestrictedDistrictsPanel.Instance.ParkPanelWrapper.isVisible)
                        {
                            RestrictedDistrictsPanel.Instance.ParkPanelWrapper.isVisible = false;
                            UIUtils.DeepDestroy(RestrictedDistrictsPanel.Instance.ParkPanelWrapper);
                        }

                        if (RestrictedDistrictsPanel.Instance.IndustriesPanelWrapper != null &&
                            RestrictedDistrictsPanel.Instance.IndustriesPanelWrapper.isVisible)
                        {
                            RestrictedDistrictsPanel.Instance.IndustriesPanelWrapper.isVisible = false;
                            UIUtils.DeepDestroy(RestrictedDistrictsPanel.Instance.IndustriesPanelWrapper);
                        }
                    }

                    if (RestrictedDistrictsPanelWrapper != null)
                    {
                        RestrictedDistrictsPanelWrapper.isVisible = false;
                        UIUtils.DeepDestroy(RestrictedDistrictsPanelWrapper);
                    }
                }
            }
            _isPanelInitialized = true;
        }

        private void AddButton(CityServiceWorldInfoPanel infoPanel, out UIButton button, Vector3 offset)
        {
            button = UIUtils.CreateToggleButton(infoPanel.component, offset, UIAlignAnchor.BottomLeft, (component, e) =>
            {
                InstanceID instanceID = (InstanceID) infoPanel.GetType()
                    .GetField("m_InstanceID", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(infoPanel);


                if (RestrictedDistrictsPanelWrapper == null || instanceID.Building != SelectedBuildingID)
                {
                    RestrictedDistrictsPanelWrapper = instanceID.Building.GenerateDistrictsPanelWrapper();
                }
                else
                {
                    RestrictedDistrictsPanelWrapper.isVisible = false;
                    UIUtils.DeepDestroy(RestrictedDistrictsPanelWrapper);
                }

                if (component.hasFocus)
                    component.Unfocus();
            });
        }

        private void OnCloseEvent(bool value)
        {

        }
    }
}