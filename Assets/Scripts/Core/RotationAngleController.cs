using System.Collections.Generic;
using UnityEngine;
using WheelFortune.ScriptableObjects;

namespace WheelFortune.Core
{
    public class RotationAngleController: MonoBehaviour, IZoneItemCommand
    {
        [SerializeField] private GameStateController gameStateController;
        private List<ZoneItem> zoneItems;
        
        public float TargetRotationAngle { get; private set; }
        public int TargetRewardIndex { get; private set; }
        public void Spin()
        {
            float sliceAngle = 360f / (float)zoneItems.Count;
            int randomValue = Random.Range(100, 200);
            float randomAngle = sliceAngle * randomValue;
            TargetRotationAngle = randomAngle;
            TargetRewardIndex = randomValue%zoneItems.Count;
            gameStateController.SetState(GameState.Spinning);
        }

        public void Execute(ZoneItems items)
        {
            zoneItems = items.zoneItems;
        }
    }
}