using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ColossalFramework;
using ServiceRestricter.GUI;
using ServiceRestricter.Internal.Options;
using UnityEngine;

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

            RestrictedDistrictsPanelWrapper =
                ServiceInfoPanel.component.AddUIComponent<RestrictedDistrictPanelWrapper>();

            _isPanelInitialized = true;
        }

    }
}
