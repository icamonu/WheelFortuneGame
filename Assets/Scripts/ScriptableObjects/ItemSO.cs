using UnityEngine;
using WheelFortune.Core;

namespace WheelFortune.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO", order = 0) ]
    public class ItemSO:ScriptableObject
    {
        public ItemType itemType;
        public Sprite itemSprite;
    }
}