using UnityEngine;
using WheelFortune.Core;
using WheelFortune.State;

namespace WheelFortune.UI
{
    public class UIGameOverPanel: StateListenerBase<GameStateController, GameState>
    {
        [SerializeField] private GameObject gameOverPanel;

        protected override void OnStateChanged(GameState newState, GameState oldState)
        {
            gameOverPanel.gameObject.SetActive(newState == GameState.GameOver);
        }
    }
}