using System;
using TMPro;
using UnityEngine;
using WheelFortune.Core;
using WheelFortune.State;

namespace WheelFortune.UI
{
    public class UIZoneText : StateListenerBase<ZoneStateController, ZoneState>
    {
        [SerializeField] private TMP_Text zoneText;

        protected override void OnStateChanged(ZoneState newState, ZoneState oldState)
        {
            SetText();
        }
        
        private void SetText()
        {
            switch (controller.CurrentState)
            {
                case ZoneState.Normal:
                    zoneText.text = "";
                    break;
                case ZoneState.Safe:
                    zoneText.text = "Safe Zone";
                    break;
                case ZoneState.Super:
                    zoneText.text = "Super Zone";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}