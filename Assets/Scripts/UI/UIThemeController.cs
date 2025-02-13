using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WheelFortune.Core;
using WheelFortune.ScriptableObjects;
using WheelFortune.State;

namespace WheelFortune.UI
{
    public class UIThemeController: StateListenerBase<ZoneStateController, ZoneState>
    {
        [SerializeField] private SpinCounter spinCounter;
        [SerializeField] private List<ThemeSO> themes;
        [SerializeField] private Image wheelImage;
        [SerializeField] private Image indicatorImage;
        
        protected override void OnStateChanged(ZoneState newState, ZoneState oldState)
        {
            SetTheme((int)newState);
        }
        
        private void SetTheme(int zoneIndex)
        {
            wheelImage.sprite = themes[zoneIndex].wheelSprite;
            indicatorImage.sprite = themes[zoneIndex].indicatorSprite;
        }
    }
}