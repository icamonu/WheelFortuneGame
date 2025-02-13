using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using WheelFortune.Core;
using WheelFortune.ScriptableObjects;

namespace WheelFortune.UI
{
    public class UIRewardAnimation: MonoBehaviour
    {
        [SerializeField] private RewardCollection rewardCollection;
        [SerializeField] private List<IndicatorTransforms> rewardIndicators;
        [SerializeField] private Transform initialPositionReference;
        [SerializeField] private Image image;
        
        private Transform targetPositionReference;

        private void Awake()
        {
            rewardCollection.OnRewardCollected += OnRewardCollected;
            image.enabled = false;
        }
        
        private void OnDestroy()
        {
            rewardCollection.OnRewardCollected -= OnRewardCollected;
        }
        
        private void OnRewardCollected(ItemType rewardItem, int rewardAmount)
        {
            transform.position = initialPositionReference.position;
            for (int i = 0; i < rewardIndicators.Count; i++)
            {
                if (rewardItem==rewardIndicators[i].item.itemType)
                {
                    targetPositionReference = rewardIndicators[i].indicatorTransform;
                    image.sprite = rewardIndicators[i].item.itemSprite;
                    image.enabled = true;
                    break;
                }
            }

            transform.DOMove(targetPositionReference.position, 1f).SetEase(Ease.InCubic)
                .OnComplete(()=>image.enabled = false);
        }
    }

    [System.Serializable]
    public class IndicatorTransforms
    {
        public ItemSO item;
        public Transform indicatorTransform;
    }
}