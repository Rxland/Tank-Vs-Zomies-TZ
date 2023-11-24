using _GAME.Code.Factories;
using _GAME.Code.Logic.Game_Behavior;
using _GAME.Code.Types;
using Zenject;

namespace _GAME.Code.Features
{
    public class LevelFeature
    {
        [Inject] private LevelsFactory _levelsFactory;
        [Inject] private GameBehavior _gameBehavior;
        
        public void RestartLevel()
        {
            _levelsFactory.UnloadLevel(0, () =>
            {
                _gameBehavior.GlobalBlackboard.SetVariableValue(GlobalBackboardType.CurrentGameState.ToString(), GameState.LoadLevel);
            });
        }
    }
}