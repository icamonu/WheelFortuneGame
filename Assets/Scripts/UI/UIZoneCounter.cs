using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using WheelFortune.Core;
using WheelFortune.State;

namespace WheelFortune.UI
{
    public class UIZoneCounter : StateListenerBase<GameStateController, GameState>
    {
        [SerializeField] private SpinCounter spinCounter;
        [SerializeField] private TMP_Text zoneCounterText;
        
        protected override void OnStateChanged(GameState newState, GameState oldState)
        {
            if (newState == GameState.ReadyToSpin)
                SetText();
        }

        private async void SetText()
        {
            await Task.Delay(5);
            zoneCounterText.text=spinCounter.SpinCount.ToString();
        }
    }
}