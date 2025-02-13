using UnityEngine;
using UnityEngine.UI;
using WheelFortune.Core;
using WheelFortune.State;

namespace WheelFortune.UI
{
    public class UISpinButton : StateListenerBase<GameStateController, GameState>
    {
        [SerializeField] private Button spinButton;
        [SerializeField] private RotationAngleController rotationAngleController;

        protected override void Awake()
        {
            base.Awake();
            spinButton.onClick.AddListener(OnSpinButtonClicked);
        }
        
        void OnDestroy()
        {
            spinButton.onClick.RemoveListener(OnSpinButtonClicked);
        }

        protected override void OnStateChanged(GameState newState, GameState oldState)
        {
            spinButton.interactable = newState == GameState.ReadyToSpin;
        }

        private void OnSpinButtonClicked()
        {
            rotationAngleController.Spin();
        }
    }
}