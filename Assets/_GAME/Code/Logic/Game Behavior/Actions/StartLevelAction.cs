using NodeCanvas.Framework;

namespace _GAME.Code.Logic.Game_Behavior.Actions
{
    public class StartLevelAction : ActionTask<GameBehavior>
    {
        protected override void OnExecute()
        {
            agent.CameraFeature.Init();
            
            agent.WindowsController.LoadingWindow.Close();
            agent.WindowsController.HudWindow.Open();

            agent.GameFactory.SpawnPlayer();
        }
    }
}