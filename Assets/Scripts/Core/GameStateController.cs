using WheelFortune.State;

namespace WheelFortune.Core
{
    public class GameStateController : StateControllerBase<GameState>
    {
        public override void SetState(GameState newState)
        {
            if (newState.Equals(CurrentState)) return;
            if (CurrentState.Equals(GameState.Left)) return;

            base.SetState(newState);
        }
    }
}