using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WheelFortune.Core;
using WheelFortune.ScriptableObjects;

namespace WheelFortune.UI
{
    public class UIWheelItemsChanger: MonoBehaviour, IZoneItemCommand
    {
        [SerializeField] private List<Image> wheelItemImages;
        [SerializeField] private List<TMP_Text> wheelItemTexts;

        public void Execute(ZoneItems currentZoneItems)
        {
            for(int i=0; i<currentZoneItems.zoneItems.Count; i++)
            {
                wheelItemImages[i].sprite = currentZoneItems.zoneItems[i].item.itemSprite;
                wheelItemTexts[i].text = currentZoneItems.zoneItems[i].item.itemType != ItemType.Bomb 
                    ? $"x{currentZoneItems.zoneItems[i].amount}" 
                    : "";
            }
        }
    }
}