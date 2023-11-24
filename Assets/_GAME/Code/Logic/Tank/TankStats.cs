using _GAME.Code.Features;
using _GAME.Code.Logic.Character;
using Zenject;

namespace _GAME.Code.Logic.Tank
{
    public class TankStats : CharacterStats
    {
        [Inject] private LevelFeature _levelFeature;
        
        public override void Die()
        {
            base.Die();
            
            _levelFeature.RestartLevel();
        }
    }
}