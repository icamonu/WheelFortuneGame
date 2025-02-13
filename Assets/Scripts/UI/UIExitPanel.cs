using UnityEngine;
using WheelFortune.Core;
using WheelFortune.State;

namespace WheelFortune.UI
{
    public class UIExitPanel: StateListenerBase<GameStateController, GameState>
    {
        [SerializeField] private GameObject exitPanel;

        protected override void OnStateChanged(GameState newState, GameState oldState)
        {
            exitPanel.gameObject.SetActive(newState == GameState.Left);
        }
    }
}