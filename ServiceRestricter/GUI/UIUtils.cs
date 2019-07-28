using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ColossalFramework.UI;
using ServiceRestricter.Helpers;
using ServiceRestricter.Internal;
using ServiceRestricter.Internal.Options;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ServiceRestricter.GUI
{
    public class UIUtils
    {
        public const float FieldHeight = 23f;
        public const float FieldWidth = 100f;
        public const float FieldMargin = 5f;


        public static void DeepDestroy(UIComponent comp)
        {
            if (comp == null)
                return;

            var childrenComps = comp.GetComponentsInChildren<UIComponent>();

            if (!(childrenComps?.Length > 0))
                return;

            foreach (var t in childrenComps)
                if (t.parent == comp)
                    DeepDestroy(t);

            Object.Destroy(comp);
            comp = null;
        }

        public static UICheckBox CreateCheckbox(UIComponent parent, string name)
        {
            var checkBox = parent.AddUIComponent<UICheckBox>();

            checkBox.name = name;
            checkBox.width = 20f;
            checkBox.height = 20f;
            checkBox.relativePosition = Vector3.zero;

            var sprite = checkBox.AddUIComponent<UISprite>();
            sprite.spriteName = "ToggleBase";
            sprite.size = new Vector2(16f, 16f);
            sprite.relativePosition = new Vector3(2f, 2f);

            checkBox.checkedBoxObject = sprite.AddUIComponent<UISprite>();
            ((UISprite)checkBox.checkedBoxObject).spriteName = "ToggleBaseFocused";
            checkBox.checkedBoxObject.size = new Vector2(16f, 16f);
            checkBox.checkedBoxObject.relativePosition = Vector3.zero;

            checkBox.eventCheckChanged += OnCheckChanged;

            checkBox.isChecked = ServiceRestrictTool.instance.CustomServiceBuildingOptions.TryGetValue(
                                     ServiceRestrictTool.instance.SelectedBuildingID, out var options) && options.CoveredDistricts.Contains(DistrictHelper.RetrieveDistrictIDFromName(name));


            return checkBox;
        }

        public static UICheckBox CreateParkCheckbox(UIComponent parent, string name)
        {
            var checkBox = parent.AddUIComponent<UICheckBox>();

            checkBox.name = name;
            checkBox.width = 20f;
            checkBox.height = 20f;
            checkBox.relativePosition = Vector3.zero;

            var sprite = checkBox.AddUIComponent<UISprite>();
            sprite.spriteName = "ToggleBase";
            sprite.size = new Vector2(16f, 16f);
            sprite.relativePosition = new Vector3(2f, 2f);

            checkBox.checkedBoxObject = sprite.AddUIComponent<UISprite>();
            ((UISprite)checkBox.checkedBoxObject).spriteName = "ToggleBaseFocused";
            checkBox.checkedBoxObject.size = new Vector2(16f, 16f);
            checkBox.checkedBoxObject.relativePosition = Vector3.zero;

            checkBox.eventCheckChanged += OnParkCheckChanged;

            checkBox.isChecked = ServiceRestrictTool.instance.CustomServiceBuildingOptions.TryGetValue(
                                     ServiceRestrictTool.instance.SelectedBuildingID, out var options) && options.CoveredDistricts.Contains(DistrictHelper.RetrieveDistrictIDFromName(name));


            return checkBox;
        }

        public static UIButton CreateButton(UIComponent parent, string name, MouseEventHandler handler, float textScale = 0.8f, float width = FieldWidth)
        {
            var button = parent.AddUIComponent<UIButton>();
            button.name = $"{name}Button";
            button.text = name;
            button.width = width;
            button.height = FieldHeight;
            button.textPadding = new RectOffset(0, 0, 5, 0);
            button.horizontalAlignment = UIHorizontalAlignment.Center;
            button.textVerticalAlignment = UIVerticalAlignment.Middle;
            button.textScale = textScale;
            button.atlas = UIView.GetAView().defaultAtlas;
            button.normalBgSprite = "ButtonMenu";
            button.disabledBgSprite = "ButtonMenuDisabled";
            button.hoveredBgSprite = "ButtonMenuHovered";
            button.focusedBgSprite = "ButtonMenu";
            button.pressedBgSprite = "ButtonMenuPressed";
            button.eventClick += handler;
            
            return button;
        }

        public static UIButton CreateToggleButton(UIComponent parent, Vector3 position, UIAlignAnchor anchor,
            MouseEventHandler handler)
        {
            var button = UIView.GetAView().AddUIComponent(typeof(UIButton)) as UIButton;
            button.name = $"ServiceRestricterToggleButton";
            button.text = "Districts";
            button.width = FieldWidth;
            button.height = FieldHeight;
            button.textPadding = new RectOffset(0, 0, 5, 0);
            button.horizontalAlignment = UIHorizontalAlignment.Center;
            button.textVerticalAlignment = UIVerticalAlignment.Middle;
            button.textScale = 0.8f;
            button.atlas = UIView.GetAView().defaultAtlas;
            button.normalBgSprite = "ButtonMenu";
            button.disabledBgSprite = "ButtonMenuDisabled";
            button.hoveredBgSprite = "ButtonMenuHovered";
            button.focusedBgSprite = "ButtonMenu";
            button.pressedBgSprite = "ButtonMenuPressed";
            button.eventClick += handler;
            button.AlignTo(parent, anchor);
            button.absolutePosition = position;

            return button;
        }

        private static void OnCheckChanged(UIComponent comp, bool value)
        {
            ServiceBuildingOptions options =
                ServiceRestrictTool.instance.CustomServiceBuildingOptions.TryGetValue(
                    ServiceRestrictTool.instance.SelectedBuildingID, out var props)
                    ? props
                    : new ServiceBuildingOptions();

            if (value)
            {
                options.CoveredDistricts.Add(DistrictHelper.RetrieveDistrictIDFromName(comp.name));
            }
            else
            {
                options.CoveredDistricts.Remove(DistrictHelper.RetrieveDistrictIDFromName(comp.name));
            }

            if (ServiceRestrictTool.instance.CustomServiceBuildingOptions.TryGetValue(
                ServiceRestrictTool.instance.SelectedBuildingID, out var _))
                ServiceRestrictTool.instance.CustomServiceBuildingOptions[
                    ServiceRestrictTool.instance.SelectedBuildingID] = options;
            else
            {
                ServiceRestrictTool.instance.CustomServiceBuildingOptions.Add(ServiceRestrictTool.instance.SelectedBuildingID, options);
            }
        }

        private static void OnParkCheckChanged(UIComponent comp, bool value)
        {
            ServiceBuildingOptions options =
                ServiceRestrictTool.instance.CustomServiceBuildingOptions.TryGetValue(
                    ServiceRestrictTool.instance.SelectedBuildingID, out var props)
                    ? props
                    : new ServiceBuildingOptions();

            if (value)
            {
                options.CoveredDistricts.Add(DistrictHelper.RetrieveParkIDFromName(comp.name));
            }
            else
            {
                options.CoveredDistricts.Remove(DistrictHelper.RetrieveParkIDFromName(comp.name));
            }

            if (ServiceRestrictTool.instance.CustomServiceBuildingOptions.TryGetValue(
                ServiceRestrictTool.instance.SelectedBuildingID, out var _))
                ServiceRestrictTool.instance.CustomServiceBuildingOptions[
                    ServiceRestrictTool.instance.SelectedBuildingID] = options;
            else
            {
                ServiceRestrictTool.instance.CustomServiceBuildingOptions.Add(ServiceRestrictTool.instance.SelectedBuildingID, options);
            }
        }

    }
}
