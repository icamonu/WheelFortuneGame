using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using WheelFortune.ScriptableObjects;
using WheelFortune.State;

namespace WheelFortune.Core
{
    public class ZoneItemsController:StateListenerBase<GameStateController, GameState>
    {
        [SerializeField] private SpinCounter spinCounter; 
        [SerializeField] public List<ZoneItems> zoneItems;
        [SerializeField] private ZoneItems currentZoneItems;
        [SerializeField] private List<MonoBehaviour> zoneItemBehaviours;
        [SerializeField] private ZoneStateController zoneStateController;
        private List<IZoneItemCommand> zoneItemCommands = new List<IZoneItemCommand>();
        
        protected override void Awake()
        {
            base.Awake();
            CreateCommandList();
            SetZoneItems();
        }

        protected override async void OnStateChanged(GameState newState, GameState oldState)
        {
            if (newState != GameState.ReadyToSpin)
                return;

            await Task.Delay(5);
            currentZoneItems = zoneItems[(int)zoneStateController.CurrentState]; 
            SetZoneItems();
        }
        
        private void OnValidate()
        {
            CreateCommandList();
            SetZoneItems();
        }
        
        private void CreateCommandList()
        {
            zoneItemCommands.Clear();
            foreach (var item in zoneItemBehaviours)
            {
                if (item is not IZoneItemCommand command)
                {
                    Debug.LogWarning("Zone Item Behaviour is not of type IZoneItemCommand");
                    continue;
                }
                zoneItemCommands.Add(command);
            }
        }
        
        private void SetZoneItems()
        {
            foreach (var command in zoneItemCommands)
            {
                command.Execute(currentZoneItems);
            }
        }
    }
}