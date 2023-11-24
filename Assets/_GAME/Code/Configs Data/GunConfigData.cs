using _GAME.Code.Types;
using UnityEngine;

namespace _GAME.Code.Configs_Data
{
    [CreateAssetMenu(fileName = "Gun Config Data", menuName = "Configs/Gun Config Data")]
    public class GunConfigData : ScriptableObject
    {
        public GunType GunType;
        [Space]
        
        public float Damage;
    }
}