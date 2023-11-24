using _GAME.Code.Logic.Zombie;
using UnityEngine;

namespace _GAME.Code.Configs_Data
{
    [CreateAssetMenu(fileName = "Zombie Config", menuName = "Configs/Zombies/Zombie Config")]
    public class ZombieConfig : ScriptableObject
    {
        public Zombie ZombiePrefab;
        [Space] 
        
        public StatsConfig Stats;
        [Space] 
        
        public float Damage;
    }
}