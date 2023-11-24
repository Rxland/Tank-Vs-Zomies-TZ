using Sirenix.OdinInspector;
using UnityEngine;

namespace _GAME.Code.Logic.Zombie
{
    public class ZombieAttack : MonoBehaviour
    {
        [SerializeField] private Zombie _zombie;
        
        [ReadOnly] public float Damage;

        public void Init(float damage)
        {
            Damage = damage;
        }
    }
}