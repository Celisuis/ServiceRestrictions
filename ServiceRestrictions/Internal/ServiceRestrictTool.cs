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
    }
}