using _GAME.Code.Types;
using NodeCanvas.Framework;

namespace _GAME.Code.Logic.Game_Behavior.Conditions
{
    public class GameStateCondition : ConditionTask<GameBehavior>
    {
        public BBParameter<GameState> CurrentState;
        public GameState NeedState;
        
        protected override bool OnCheck()
        {
            if (CurrentState.value == NeedState)
                return true;

            return false;
        }
    }
}