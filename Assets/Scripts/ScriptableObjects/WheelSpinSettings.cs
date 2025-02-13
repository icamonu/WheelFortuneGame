using UnityEngine;

namespace WheelFortune.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WheelSpinSettings", menuName = "Scriptable Objects/WheelSpinSettings", order = 0)]
    public class WheelSpinSettings: ScriptableObject
    {
        public float rotationDuration;
    }
}