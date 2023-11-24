using NodeCanvas.Framework;

namespace _GAME.Code.Logic.Zombie.Behavior_AI.Actions
{
    public class ZombieFollowAction : ActionTask<Zombie>
    {
        protected override void OnUpdate()
        {
            agent.Agent.SetDestination(agent.GameFactory.Player.transform.position);
        }
    }
}