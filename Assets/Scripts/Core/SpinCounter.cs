using UnityEngine;
using WheelFortune.State;

namespace WheelFortune.Core
{
    public class SpinCounter: StateListenerBase<GameStateController, GameState>
    {
        public int SpinCount { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            SpinCount = 1;
        }

        protected override void OnStateChanged(GameState newState, GameState oldState)
        {
            if (newState == GameState.ReadyToSpin)
                IncreaseSpinCount();
        }

        private void IncreaseSpinCount()
        {
            SpinCount++;
        }
    }
}