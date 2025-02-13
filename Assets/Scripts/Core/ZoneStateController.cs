using WheelFortune.State;
using UnityEngine;
using WheelFortune.ScriptableObjects;

namespace WheelFortune.Core
{
    public class ZoneStateController: StateControllerBase<ZoneState>
    {
        [SerializeField] private GameStateController gameStateController;
        [SerializeField] private SpinCounter spinCounter;
        [SerializeField] private ZoneSettingsSO zoneSettings;

        private void Awake()
        {
            gameStateController.OnStateChanged += OnGameStateChanged;
        }

        private void OnDestroy()
        {
            gameStateController.OnStateChanged -= OnGameStateChanged;
        }

        private void OnGameStateChanged(GameState newState, GameState oldState)
        {
            if (newState!=GameState.ReadyToSpin)
                return;

            CheckZoneState(spinCounter.SpinCount);
        }
        
        private void CheckZoneState(int spinCount)
        {
            SetState(spinCount % zoneSettings.superZonePeriod == 0 ? ZoneState.Super :
                spinCount % zoneSettings.safeZonePeriod == 0 ? ZoneState.Safe :
                ZoneState.Normal);
        }
    }
}