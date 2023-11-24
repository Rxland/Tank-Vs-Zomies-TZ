using _GAME.Code.Factories;
using _GAME.Code.Features;
using NodeCanvas.BehaviourTrees;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Logic.Spawners.Zombie_Spawner_Behavior
{
    public class ZombieSpawnerBehavior : MonoBehaviour
    {
        [ReadOnly] [Inject] public LevelsFactory LevelsFactory;
        [ReadOnly] [Inject] public ConfigsFeature ConfigsFeature;
        [ReadOnly] [Inject] public EnemiesFactory EnemiesFactory;
        
        [SerializeField] private BehaviourTreeOwner _spawnerBehaviourTree;

        public void Init()
        {
            _spawnerBehaviourTree.enabled = true;
        }
    }
}