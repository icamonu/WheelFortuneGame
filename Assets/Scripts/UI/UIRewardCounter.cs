using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using WheelFortune.Core;

namespace WheelFortune.UI
{
    public class UIRewardCounter: MonoBehaviour
    {
        [SerializeField] private ItemType itemType;
        [SerializeField] private RewardCounts rewardCounts;
        [SerializeField] private TMP_Text rewardCountText;
        private int oldCount;
        private void Awake()
        {
            rewardCounts.OnRewardCounted += OnRewardCounted;
        }
        
        private void OnDestroy()
        {
            rewardCounts.OnRewardCounted -= OnRewardCounted;
        }

        private async void OnEnable()
        {
            await Count(rewardCounts.GetRewardCount(itemType), 0);
        }

        private async void OnRewardCounted(ItemType rewardItemType, int rewardCount)
        {
            int count = oldCount;
            if (rewardItemType == itemType)
            {
                await Count(rewardCount, count);
                oldCount = rewardCount;
            }
        }

        private async Task Count(int rewardCount, int count, int countDuration = 300)
        {
            while (count<rewardCount)
            {
                count++;
                rewardCountText.text = count.ToString();
                await Task.Delay(countDuration / (rewardCount - oldCount));
            }
        }
    }
}