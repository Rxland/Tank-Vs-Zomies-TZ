using _GAME.Code.Factories;
using _GAME.Code.Features;
using _GAME.Code.Logic.Game_Behavior;
using _GAME.Code.UI;
using _GAME.Code.UI.Hud_Window;
using Zenject;

namespace _GAME.Code
{
    public class GameInstaller : MonoInstaller
    {
        public WindowsController WindowsController;
        public ConfigsFeature ConfigsFeature;
        public CameraFeature CameraFeature;
        public GameBehavior GameBehavior;
        
        public override void InstallBindings()
        {
            Container.Bind<HudWindowViewViewModel>().AsSingle().NonLazy();

            Container.Bind<GameFactory>().AsSingle().NonLazy();
            Container.Bind<GunFeature>().AsSingle().NonLazy();
            Container.Bind<LevelFeature>().AsSingle().NonLazy();
            
            Container.Bind<LevelsFactory>().AsSingle().NonLazy();
            Container.Bind<EnemiesFactory>().AsSingle().NonLazy();
            
            Container.Bind<WindowsController>().FromInstance(WindowsController).AsSingle().NonLazy();
            Container.Bind<ConfigsFeature>().FromInstance(ConfigsFeature).AsSingle().NonLazy();
            Container.Bind<CameraFeature>().FromInstance(CameraFeature).AsSingle().NonLazy();
            Container.Bind<GameBehavior>().FromInstance(GameBehavior).AsSingle().NonLazy();
        }
    }
}