using NodeCanvas.Framework;

namespace _GAME.Code.Logic.Zombie.Behavior_AI.Actions
{
    public class ZombieHitTankAction : ActionTask<Zombie>
    {
        protected override void OnExecute()
        {
            agent.GameFactory.Player.Stats.TakeDamage(agent.Attack.Damage);

            EndAction();
        }
    }
}