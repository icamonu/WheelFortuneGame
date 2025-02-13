using System;
using System.Collections.Generic;
using UnityEngine;

namespace WheelFortune.Core
{
    public class RewardCounts : MonoBehaviour
    {
        [SerializeField] private RewardCollection rewardCollection;
        private Dictionary<ItemType, int> rewardCounts = new Dictionary<ItemType, int>();
        public Action<ItemType, int> OnRewardCounted;

        private void Awake()
        {
            rewardCollection.OnRewardCollected += OnRewardCollected;
        }
        
        private void OnDestroy()
        {
            rewardCollection.OnRewardCollected -= OnRewardCollected;
        }

        private void OnRewardCollected(ItemType rewardItem, int rewardAmount)
        {
            if (!rewardCounts.TryAdd(rewardItem, rewardAmount))
                rewardCounts[rewardItem] += rewardAmount;
            
            OnRewardCounted?.Invoke(rewardItem, rewardCounts[rewardItem]);
        }
        
        public int GetRewardCount(ItemType itemType)
        {
            return rewardCounts.ContainsKey(itemType) ? rewardCounts[itemType] : 0;
        }
    }
}