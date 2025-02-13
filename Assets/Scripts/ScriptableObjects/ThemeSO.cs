using UnityEngine;

namespace WheelFortune.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ThemeSO", menuName = "Scriptable Objects/ThemeSO", order = 0)]
    public class ThemeSO: ScriptableObject
    {
        public Sprite wheelSprite;
        public Sprite indicatorSprite;
    }
}