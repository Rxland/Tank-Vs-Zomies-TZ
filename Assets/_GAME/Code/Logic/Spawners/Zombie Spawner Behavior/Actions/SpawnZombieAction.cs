using NodeCanvas.Framework;

namespace _GAME.Code.Logic.Spawners.Zombie_Spawner_Behavior.Actions
{
    public class SpawnZombieAction : ActionTask<ZombieSpawnerBehavior>
    {
        protected override void OnExecute()
        {
            agent.EnemiesFactory.SpawnRandomZombie();
            
            EndAction();
        }
    }
}