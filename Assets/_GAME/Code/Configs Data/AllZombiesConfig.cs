using System.Collections.Generic;
using UnityEngine;

namespace _GAME.Code.Configs_Data
{
    [CreateAssetMenu(fileName = "All Zombies Config", menuName = "Configs/Zombies/All Zombies Config")]
    public class AllZombiesConfig : ScriptableObject
    {
        public int MaxZombiesOnMapAmount;
        [Space]
        
        public List<ZombieConfig> ZombieConfigs;
    }
}