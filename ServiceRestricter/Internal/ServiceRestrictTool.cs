using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ColossalFramework;
using ColossalFramework.UI;
using ServiceRestricter.Extensions;
using ServiceRestricter.GUI;
using ServiceRestricter.Internal.Options;
using UnityEngine;
using UIUtils = ServiceRestricter.GUI.UIUtils;

namespace ServiceRestricter.Internal
{
    public class ServiceRestrictTool : Singleton<ServiceRestrictTool>
    {
        internal Dictionary<ushort, ServiceBuildingOptions> CustomServiceBuildingOptions = new Dictionary<ushort, ServiceBuildingOptions>();

        internal CityServiceWorldInfoPanel ServiceInfoPanel;

        private bool _isInitialized;

        private bool _isPanelInitialized;

        internal ushort SelectedBuildingID;

        internal RestrictedDistrictPanelWrapper RestrictedDistrictsPanelWrapper;

        private UIButton _toggleButton;

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

            AddButton(ServiceInfoPanel, out _toggleButton, new Vector3(1100f, 430f));

            _isPanelInitialized = true;
        }

        private void AddButton(CityServiceWorldInfoPanel infoPanel, out UIButton button, Vector3 position)
        {
            button = UIUtils.CreateToggleButton(infoPanel.component, position, UIAlignAnchor.BottomLeft, (component, e) =>
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
