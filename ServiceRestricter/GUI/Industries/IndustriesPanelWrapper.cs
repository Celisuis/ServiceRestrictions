using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ColossalFramework.UI;
using ServiceRestricter.GUI.Industries;
using ServiceRestricter.GUI.Parks;
using ServiceRestricter.Internal;
using UnityEngine;

namespace ServiceRestricter.GUI
{
    public class IndustriesPanelWrapper : UIPanel
    {
        public static IndustriesPanelWrapper Instance;
        private UiIndustriesTitleBar _titlebar;

        private IndustriesPanel _panel;

        public override void Start()
        {
            base.Start();
            Instance = this;
            Setup();
        }

        public override void Update()
        {
            base.Update();

            InstanceID instance = (InstanceID)ServiceRestrictTool.instance.ServiceInfoPanel.GetType()
                .GetField("m_InstanceID", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(ServiceRestrictTool.instance.ServiceInfoPanel);

            if (instance.Building != ServiceRestrictTool.instance.SelectedBuildingID)
            {
                UIUtils.DeepDestroy(this);
            }
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
            name = "ServiceRestricterIndustriesPanelWrapper";
            padding = new RectOffset(10, 10, 4, 4);
            relativePosition = new Vector3(ServiceResticterMod.Settings.PanelX,
                ServiceResticterMod.Settings.PanelY);
            backgroundSprite = "MenuPanel";
            _titlebar = AddUIComponent<UiIndustriesTitleBar>();
            _panel = AddUIComponent<IndustriesPanel>();
        }
    }
}
