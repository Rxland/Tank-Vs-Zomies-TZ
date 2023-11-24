using _GAME.Code.Types;
using NodeCanvas.Framework;

namespace _GAME.Code.Logic.Game_Behavior.Actions
{
    public class LoadLevelAction : ActionTask<GameBehavior>
    {
        protected override void OnExecute()
        {
            agent.LevelsFactory.SpawnLevel(0, OnLoad);
        }

        private void OnLoad()
        {
            agent.GlobalBlackboard.SetVariableValue(GlobalBackboardType.CurrentGameState.ToString(), GameState.StartLevel);
            
            EndAction();
        }
    }
}