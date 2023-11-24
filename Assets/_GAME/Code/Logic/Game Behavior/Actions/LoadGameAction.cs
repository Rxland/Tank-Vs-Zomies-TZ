using _GAME.Code.Types;
using NodeCanvas.Framework;

namespace _GAME.Code.Logic.Game_Behavior.Actions
{
    public class LoadGameAction : ActionTask<GameBehavior>
    {
        protected override void OnExecute()
        {
            agent.WindowsController.LoadingWindow.Open();
            
            agent.GlobalBlackboard.SetVariableValue(GlobalBackboardType.CurrentGameState.ToString(), GameState.LoadLevel);
            agent.GlobalBlackboard.SetVariableValue(GlobalBackboardType.IsGameLoaded.ToString(), true);
            
            EndAction();
        }
    }
}