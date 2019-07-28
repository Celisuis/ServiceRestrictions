using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ColossalFramework.UI;
using ServiceRestricter.Internal;
using UnityEngine;

namespace ServiceRestricter.GUI
{
    public class UiTitleBar : UIPanel
    {
        public static UiTitleBar Instance;
        private UIButton _closeButton;
        private UILabel _titleLabel;
        public UIDragHandle DragHandle;

        public override void Start()
        {
            base.Start();
            Instance = this;
            SetupControls();
        }

        private void SetupControls()
        {
            name = "ServiceRestricterTitlebar";
            isVisible = false;
            canFocus = true;
            isInteractive = true;
            relativePosition = Vector3.zero;
            width = parent.width;
            height = 40f;

            DragHandle = AddUIComponent<UIDragHandle>();
            DragHandle.height = height;
            DragHandle.relativePosition = Vector3.zero;
            DragHandle.target = parent;
            DragHandle.eventMouseUp += (c, e) =>
            {
                ServiceResticterMod.Settings.PanelX = parent.relativePosition.x;
                ServiceResticterMod.Settings.PanelY = parent.relativePosition.y;
                ServiceResticterMod.Settings.Save();
            };

            _titleLabel = AddUIComponent<UILabel>();
            _titleLabel.text = "District Restrictions";
            _titleLabel.textScale = 0.9f;
            _titleLabel.isInteractive = false;

            _closeButton = AddUIComponent<UIButton>();
            _closeButton.size = new Vector2(20, 20);
            _closeButton.relativePosition = new Vector3(width - _closeButton.width - 10f, 10f);
            _closeButton.normalBgSprite = "DeleteLineButton";
            _closeButton.hoveredBgSprite = "DeleteLineButtonHovered";
            _closeButton.pressedBgSprite = "DeleteLineButtonPressed";
            _closeButton.eventClick += (component, param) =>
            {

                ServiceRestrictTool.instance.RestrictedDistrictsPanelWrapper.isVisible = false;
                UIUtils.DeepDestroy(ServiceRestrictTool.instance.RestrictedDistrictsPanelWrapper);
            };

        }

        public void RecenterElements()
        {
            _closeButton.relativePosition = new Vector3(width - _closeButton.width - 10f, 10f);
            _titleLabel.relativePosition =
                new Vector3((width - _titleLabel.width) / 2f, (height - _titleLabel.height) / 2);
        }
    }

}
