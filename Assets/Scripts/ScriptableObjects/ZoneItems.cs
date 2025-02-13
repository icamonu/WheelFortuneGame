using System.Collections.Generic;
using UnityEngine;

namespace WheelFortune.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ZoneItems", menuName = "Scriptable Objects/ZoneItems", order = 0)]
    public class ZoneItems: ScriptableObject
    {
        public List<ZoneItem> zoneItems;
    }
}