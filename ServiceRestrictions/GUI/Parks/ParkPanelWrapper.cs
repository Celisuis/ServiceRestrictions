using System.Reflection;
using ColossalFramework.UI;
using ServiceRestrictions.Internal;
using UnityEngine;

namespace ServiceRestrictions.GUI.Parks
{
    public class ParkPanelWrapper : UIPanel
    {
        public static ParkPanelWrapper Instance;

        private ParksPanel _panel;
        private UiTitleParksBar _titlebar;

        public override void Start()
        {
            base.Start();
            Instance = this;
            Setup();
        }

        public override void Update()
        {
            base.Update();

            InstanceID instance = (InstanceID) ServiceRestrictTool.instance.ServiceInfoPanel.GetType()
                .GetField("m_InstanceID", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(ServiceRestrictTool.instance.ServiceInfoPanel);

            if (instance.Building != ServiceRestrictTool.instance.SelectedBuildingID) UIUtils.DeepDestroy(this);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            UIUtils.DeepDestroy(this);
        }

        private void Setup()
        {
            isVisible = false;
            isInteractive = false;
            name = "ServiceRestrictionParksPanelWrapper";
            padding = new RectOffset(10, 10, 4, 4);
            relativePosition = new Vector3(ServiceRestrictionsMod.Settings.PanelX,
                ServiceRestrictionsMod.Settings.PanelY);
            backgroundSprite = "MenuPanel";
            _titlebar = AddUIComponent<UiTitleParksBar>();
            _panel = AddUIComponent<ParksPanel>();
        }
    }
}