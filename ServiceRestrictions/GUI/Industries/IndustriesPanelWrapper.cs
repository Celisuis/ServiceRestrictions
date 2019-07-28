using System.Reflection;
using ColossalFramework.UI;
using ServiceRestrictions.Internal;
using UnityEngine;

namespace ServiceRestrictions.GUI.Industries
{
    public class IndustriesPanelWrapper : UIPanel
    {
        public static IndustriesPanelWrapper Instance;

        private IndustriesPanel _panel;
        private UiIndustriesTitleBar _titlebar;

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
            name = "ServiceRestrictionIndustriesPanelWrapper";
            padding = new RectOffset(10, 10, 4, 4);
            relativePosition = new Vector3(ServiceRestrictionsMod.Settings.PanelX,
                ServiceRestrictionsMod.Settings.PanelY);
            backgroundSprite = "MenuPanel";
            _titlebar = AddUIComponent<UiIndustriesTitleBar>();
            _panel = AddUIComponent<IndustriesPanel>();
        }
    }
}