using _GAME.Code.Configs_Data;
using _GAME.Code.Factories;
using _GAME.Code.Logic.Character;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Logic.Zombie
{
    public class ZombieStats : CharacterStats
    {
        [SerializeField] private Zombie _zombie;

        [Inject] private EnemiesFactory _enemiesFactory;

        public override void Init(StatsConfig statsConfig)
        {
            base.Init(statsConfig);
            
            _zombie.Agent.speed = statsConfig.MoveSpeed;
            _zombie.Agent.angularSpeed = statsConfig.TurnSpeed;
        }

        public override void Die()
        {
            base.Die();
            
            _enemiesFactory.RemoveZombie(_zombie);
            Destroy(gameObject);
        }
    }
}