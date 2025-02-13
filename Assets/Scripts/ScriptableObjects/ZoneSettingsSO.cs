using UnityEngine;

namespace WheelFortune.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ZoneSettings", menuName = "Scriptable Objects/ZoneSettings", order = 0)]
    public class ZoneSettingsSO: ScriptableObject
    {
        public int safeZonePeriod;
        public int superZonePeriod;
    }
}