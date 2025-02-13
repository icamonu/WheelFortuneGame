using UnityEngine;
using UnityEngine.UI;
using WheelFortune.Core;
using WheelFortune.State;

namespace WheelFortune.UI
{
    public class UIExitButton: StateListenerBase<GameStateController, GameState>
    {
        [SerializeField] private Button exitButton;
        [SerializeField] private ZoneStateController zoneStateController;
        
        protected override void Awake()
        {
            base.Awake();
            exitButton.onClick.AddListener(OnExitButtonClicked);
        }

        protected override void OnStateChanged(GameState newState, GameState oldState)
        {
            exitButton.interactable = (zoneStateController.CurrentState == ZoneState.Super 
                                       || zoneStateController.CurrentState == ZoneState.Safe 
                                       || newState != GameState.Spinning);
        }

        private void OnDestroy()
        {
            exitButton.onClick.RemoveListener(OnExitButtonClicked);
        }

        private void OnExitButtonClicked()
        {
            controller.SetState(GameState.Left);
        }
    }
}