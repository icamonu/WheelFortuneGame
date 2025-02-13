using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using WheelFortune.ScriptableObjects;
using WheelFortune.State;

namespace WheelFortune.Core
{
    public class RewardCollection : StateListenerBase<GameStateController, GameState>, IZoneItemCommand
    {
        [SerializeField] private RotationAngleController rotationAngleController;
        [SerializeField] private WheelSpinSettings wheelSpinSettings;
        [SerializeField] private SpinCounter spinCounter;
        
        private List<ZoneItem> zoneItems;
        public Action<ItemType, int> OnRewardCollected;

        protected override void OnStateChanged(GameState newState, GameState oldState)
        {
            if (newState == GameState.Spinning)
                SetStateStopped();
            
            if (newState == GameState.Stopped)
                GetReward();
        }
        
        public void Execute(ZoneItems items)
        {
            zoneItems = items.zoneItems;
        }
        
        private async void GetReward()
        {
            ItemType reward = zoneItems[rotationAngleController.TargetRewardIndex].item.itemType;
            int rewardAmount = zoneItems[rotationAngleController.TargetRewardIndex].amount;

            if(reward==ItemType.Bomb)
                SetStateGameOver();
            else
                await SetStateReadyToSpin(rewardAmount, reward);
        }

        private async Task SetStateReadyToSpin(int rewardAmount, ItemType reward)
        {
            OnRewardCollected?.Invoke(reward, rewardAmount);
            await Task.Delay(1000);
            controller.SetState(GameState.ReadyToSpin);
        }

        private async void SetStateStopped()
        {
            await Task.Delay((int)wheelSpinSettings.rotationDuration * 1000);
            controller.SetState(GameState.Stopped);
        }
        
        private void SetStateGameOver()
        {
            controller.SetState(GameState.GameOver);
        }
    }
}