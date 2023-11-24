using NodeCanvas.Framework;

namespace _GAME.Code.Logic.Spawners.Zombie_Spawner_Behavior.Conditions
{
    public class CanSpawnZombieCondition : ConditionTask<ZombieSpawnerBehavior>
    {
        protected override bool OnCheck()
        {
            if (agent.LevelsFactory.Level && agent.LevelsFactory.Level.AllSpawnedZombies.Count >= agent.ConfigsFeature.AllZombiesConfig.MaxZombiesOnMapAmount)
            {
                return false;
            }
            return true;
        }
    }
}