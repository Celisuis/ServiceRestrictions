using ColossalFramework.UI;
using ServiceRestrictions.GUI.Districts;
using ServiceRestrictions.Internal;
using UnityEngine;

namespace ServiceRestrictions.GUI
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
            name = "ServiceRestrictionTitlebar";
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
                ServiceRestrictionsMod.Settings.PanelX = parent.relativePosition.x;
                ServiceRestrictionsMod.Settings.PanelY = parent.relativePosition.y;
                ServiceRestrictionsMod.Settings.Save();
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
                if (RestrictedDistrictsPanel.Instance.CampusPanelWrapper != null)
                {
                    RestrictedDistrictsPanel.Instance.CampusPanelWrapper.isVisible = false;
                    UIUtils.DeepDestroy(RestrictedDistrictsPanel.Instance.CampusPanelWrapper);
                }

                if (RestrictedDistrictsPanel.Instance.IndustriesPanelWrapper != null)
                {
                    RestrictedDistrictsPanel.Instance.IndustriesPanelWrapper.isVisible = false;
                    UIUtils.DeepDestroy(RestrictedDistrictsPanel.Instance.IndustriesPanelWrapper);
                }

                if (RestrictedDistrictsPanel.Instance.ParkPanelWrapper != null)
                {
                    RestrictedDistrictsPanel.Instance.ParkPanelWrapper.isVisible = false;
                    UIUtils.DeepDestroy(RestrictedDistrictsPanel.Instance.ParkPanelWrapper);
                }

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

    public class UiIndustriesTitleBar : UIPanel
    {
        public static UiIndustriesTitleBar Instance;
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
            name = "ServiceRestrictionIndustriesTitlebar";
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

            _titleLabel = AddUIComponent<UILabel>();
            _titleLabel.text = "Industry Restrictions";
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
                RestrictedDistrictsPanel.Instance.IndustriesPanelWrapper.isVisible = false;
                UIUtils.DeepDestroy(RestrictedDistrictsPanel.Instance.IndustriesPanelWrapper);
            };
        }

        public void RecenterElements()
        {
            _closeButton.relativePosition = new Vector3(width - _closeButton.width - 10f, 10f);
            _titleLabel.relativePosition =
                new Vector3((width - _titleLabel.width) / 2f, (height - _titleLabel.height) / 2);
        }
    }

    public class UiTitleParksBar : UIPanel
    {
        public static UiTitleParksBar Instance;
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
            name = "ServiceRestrictionParksTitlebar";
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

            _titleLabel = AddUIComponent<UILabel>();
            _titleLabel.text = "Park Restrictions";
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
                RestrictedDistrictsPanel.Instance.ParkPanelWrapper.isVisible = false;
                UIUtils.DeepDestroy(RestrictedDistrictsPanel.Instance.ParkPanelWrapper);
            };
        }

        public void RecenterElements()
        {
            _closeButton.relativePosition = new Vector3(width - _closeButton.width - 10f, 10f);
            _titleLabel.relativePosition =
                new Vector3((width - _titleLabel.width) / 2f, (height - _titleLabel.height) / 2);
        }
    }

    public class UiCampusTitleBar : UIPanel
    {
        public static UiCampusTitleBar Instance;
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
            name = "ServiceRestrictionTitlebar";
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

            _titleLabel = AddUIComponent<UILabel>();
            _titleLabel.text = "Campus Restrictions";
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
                RestrictedDistrictsPanel.Instance.CampusPanelWrapper.isVisible = false;
                UIUtils.DeepDestroy(RestrictedDistrictsPanel.Instance.CampusPanelWrapper);
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