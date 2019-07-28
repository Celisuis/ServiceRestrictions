using System;
using System.Collections.Generic;
using ColossalFramework.UI;
using ServiceRestrictions.GUI.Districts;
using ServiceRestrictions.Helpers;
using UnityEngine;

namespace ServiceRestrictions.GUI.Parks
{
    public class ParksPanel : UIPanel
    {
        public static ParksPanel Instance;

        private List<UILabel> _labels;

        internal List<UIComponent> Inputs;

        public override void Start()
        {
            base.Start();
            Instance = this;
            Setup();
        }

        private void Setup()
        {
            name = "ServiceRestrictionRestrictParksPanel";
            isVisible = false;
            canFocus = true;
            isInteractive = true;
            relativePosition = new Vector3(0f, UiTitleParksBar.Instance.height);
            width = parent.width;

            float widestWidth = 0f;

            Inputs = new List<UIComponent>();
            _labels = new List<UILabel>();

            foreach (var park in DistrictHelper.RetrieveAllParkNames())
            {
                var label = AddUIComponent<UILabel>();
                label.name = park + "Label";
                label.text = park;
                label.textScale = 0.9f;
                label.isInteractive = false;

                try
                {
                    Inputs.Add(UIUtils.CreateParkCheckbox(this, park));
                    _labels.Add(label);

                    if (label.width + UIUtils.FieldWidth + UIUtils.FieldMargin * 6 > widestWidth)
                        widestWidth = label.width + UIUtils.FieldWidth + UIUtils.FieldMargin * 6;
                }
                catch (Exception e)
                {
                    Debug.Log($"Couldn't create Checkbox for {park}. {e.Message} - {e.StackTrace}");
                }
            }

            Inputs.Sort((x, y) => x.name.CompareTo(y.name));
            _labels.Sort((x, y) => x.name.CompareTo(y.name));

            width = ParkPanelWrapper.Instance.width =
                UiTitleParksBar.Instance.width = UiTitleParksBar.Instance.DragHandle.width = widestWidth;

            UiTitleParksBar.Instance.RecenterElements();
            Align();

            height = Inputs.Count * (UIUtils.FieldHeight + UIUtils.FieldMargin) + UIUtils.FieldMargin * 3;

            ParkPanelWrapper.Instance.height = height + UiTitleParksBar.Instance.height;

            ParkPanelWrapper.Instance.relativePosition = new Vector3(
                RestrictedDistrictPanelWrapper.Instance.relativePosition.x + ParkPanelWrapper.Instance.width + 20f,
                RestrictedDistrictPanelWrapper.Instance.relativePosition.y);

            isVisible = ParkPanelWrapper.Instance.isVisible =
                UiTitleParksBar.Instance.isVisible = UiTitleParksBar.Instance.DragHandle.isVisible = true;
        }

        private void Align()
        {
            var inputX = width - UIUtils.FieldWidth - UIUtils.FieldMargin * 2;

            for (var x = 0; x < Inputs.Count; x++)
            {
                var finalY = x * UIUtils.FieldHeight + UIUtils.FieldMargin * (x + 2);

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
    }
}