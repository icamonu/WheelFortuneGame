using UnityEngine;
using WheelFortune.Core;
using DG.Tweening;
using WheelFortune.ScriptableObjects;
using WheelFortune.State;

namespace WheelFortune.UI
{
    public class UIWheelRotationController: StateListenerBase<GameStateController, GameState>
    {
        [SerializeField] private Transform wheel;
        [SerializeField] private RotationAngleController rotationAngleController;
        [SerializeField] private WheelSpinSettings wheelSpinSettings;

        protected override void OnStateChanged(GameState newState, GameState oldState)
        {
            if (newState == GameState.Spinning)
                Spin();
        }

        private void Spin()
        {
            float rotationAngle = rotationAngleController.TargetRotationAngle;
            float rotationDuration = wheelSpinSettings.rotationDuration;

            wheel.DORotate(new Vector3(0, 0, rotationAngle), rotationDuration, RotateMode.FastBeyond360)
                .SetEase(Ease.OutQuint);
        }
    }
}