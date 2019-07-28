﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ColossalFramework.UI;
using ServiceRestricter.Helpers;
using ServiceRestricter.Internal;
using ServiceRestricter.Internal.Options;
using UnityEngine;

namespace ServiceRestricter.GUI
{
    public class RestrictedDistrictsPanel : UIPanel
    {
        public static RestrictedDistrictsPanel Instance;

        internal List<UIComponent> Inputs;

        private List<UILabel> _labels;

        internal IndustriesPanelWrapper IndustriesPanelWrapper;

        internal ParkPanelWrapper ParkPanelWrapper;

        internal CampusPanelWrapper CampusPanelWrapper;

        public override void Start()
        {
            base.Start();
            Instance = this;
            Setup();
        }

        private void Setup()
        {
            name = "ServiceRestricterRestrictDistrictsPanel";
            isVisible = false;
            canFocus = true;
            isInteractive = true;
            relativePosition = new Vector3(0f, UiTitleBar.Instance.height);
            width = parent.width;

            float widestWidth = 0f;

            Inputs = new List<UIComponent>();
            _labels = new List<UILabel>();

            foreach (var district in DistrictHelper.RetrieveAllDistrictNames().Where(x =>
                x != DistrictManager.instance.GetDistrictName(DistrictManager.instance.GetDistrict(BuildingManager.instance.m_buildings.m_buffer[ServiceRestrictTool.instance.SelectedBuildingID].m_position))))
            {
                var label = AddUIComponent<UILabel>();
                label.name = district + "Label";
                label.text = district;
                label.textScale = 0.9f;
                label.isInteractive = false;

                try
                {
                    Inputs.Add(UIUtils.CreateCheckbox(this, district));
                    _labels.Add(label);


                    if (label.width + UIUtils.FieldWidth + UIUtils.FieldMargin * 6 > widestWidth)
                        widestWidth = label.width + UIUtils.FieldWidth + UIUtils.FieldMargin * 6;

                }
                catch (Exception e)
                {
                    Debug.Log($"Couldn't create Checkbox for {district}. {e.Message} - {e.StackTrace}");
                }
            }

            Inputs.Sort((x, y) => x.name.CompareTo(y.name));
            _labels.Sort((x, y) => x.name.CompareTo(y.name));

            Inputs.Add(UIUtils.CreateButton(this, $"Restrict Emptying", (component, e) =>
            {
                var button = component as UIButton;

                ServiceBuildingOptions options =
                    ServiceRestrictTool.instance.CustomServiceBuildingOptions.TryGetValue(
                        ServiceRestrictTool.instance.SelectedBuildingID, out var props)
                        ? props
                        : new ServiceBuildingOptions();

                options.RestrictEmptying = !options.RestrictEmptying;

                button.normalBgSprite = options.RestrictEmptying ? "ButtonMenuHovered" : "ButtonMenu";

                if (ServiceRestrictTool.instance.CustomServiceBuildingOptions.TryGetValue(
                    ServiceRestrictTool.instance.SelectedBuildingID, out var _))
                    ServiceRestrictTool.instance.CustomServiceBuildingOptions[
                        ServiceRestrictTool.instance.SelectedBuildingID] = options;
                else
                {
                    ServiceRestrictTool.instance.CustomServiceBuildingOptions.Add(ServiceRestrictTool.instance.SelectedBuildingID, options);
                }
            }, 0.6f));

            Inputs.Add(UIUtils.CreateButton(this, "Parks", (component, e) => {}, 0.8f, 80f));
            Inputs.Add(UIUtils.CreateButton(this, "Industries", (component, e) =>
            {
                if (IndustriesPanelWrapper != null)
                {
                    IndustriesPanelWrapper.isVisible = false;
                    UIUtils.DeepDestroy(IndustriesPanelWrapper);
                }
                else
                {
                    IndustriesPanelWrapper =
                        UIView.GetAView().AddUIComponent(typeof(IndustriesPanelWrapper)) as IndustriesPanelWrapper;
                }
            }, 0.8f, 80f));
            Inputs.Add(UIUtils.CreateButton(this, "Campuses", (component, e) => { }, 0.8f, 80f));

            width = RestrictedDistrictPanelWrapper.Instance.width =
                UiTitleBar.Instance.width = UiTitleBar.Instance.DragHandle.width = widestWidth;

            UiTitleBar.Instance.RecenterElements();
            Align();
            AlignButtons();

            height = Inputs.Count * (UIUtils.FieldHeight + UIUtils.FieldMargin) + UIUtils.FieldMargin * 3;

            RestrictedDistrictPanelWrapper.Instance.height = height + UiTitleBar.Instance.height;

            RestrictedDistrictPanelWrapper.Instance.relativePosition = new Vector3(ServiceResticterMod.Settings.PanelX, ServiceResticterMod.Settings.PanelY);

            isVisible = RestrictedDistrictPanelWrapper.Instance.isVisible =
                UiTitleBar.Instance.isVisible = UiTitleBar.Instance.DragHandle.isVisible = true;



        }

        private float finalY;

        private void Align()
        {
            var inputX = width - UIUtils.FieldWidth - UIUtils.FieldMargin * 2;

            for (var x = 0; x < Inputs.Count; x++)
            {
                 finalY = x * UIUtils.FieldHeight + UIUtils.FieldMargin * (x + 2);

                if (x < _labels.Count)
                {
                    var labelX = inputX - _labels[x].width - UIUtils.FieldMargin * 2;
                    _labels[x].relativePosition = new Vector3(labelX, finalY + 4);
                }

                Inputs[x].relativePosition = Inputs[x] is UICheckBox
                    ? new Vector3(inputX + (UIUtils.FieldWidth - Inputs[x].width) / 2,
                        finalY + (UIUtils.FieldHeight - Inputs[x].height) / 2)
                    : new Vector3(inputX, finalY);
            }
        }

        private void AlignParksButton()
        {
            Inputs.Find(x => x.name == $"ParksButton").relativePosition = new Vector3(192f, finalY);
        }

        private void AlignIndustriesButton()
        {
            Inputs.Find(x => x.name == "IndustriesButton").relativePosition = new Vector3(102f, finalY);
        }

        private void AlignCampusesButton()
        {
            Inputs.Find(x => x.name == "CampusesButton").relativePosition = new Vector3(10f, finalY);
        }

        private void AlignButtons()
        {
           AlignParksButton();
           AlignIndustriesButton();
           AlignCampusesButton();
        }


    }
}