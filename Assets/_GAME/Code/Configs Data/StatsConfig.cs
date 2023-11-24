using UnityEngine;

namespace _GAME.Code.Configs_Data
{
    [CreateAssetMenu(fileName = "Stats Config", menuName = "Configs/Stats Config", order = 0)]
    public class StatsConfig : ScriptableObject
    {
        public float MoveSpeed;
        public float TurnSpeed;
        [Space]
        
        public float Health;
        public float Armor;
    }
}