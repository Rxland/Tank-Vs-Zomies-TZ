using _GAME.Code.Factories;
using _GAME.Code.Logic.Character;
using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace _GAME.Code.Logic.Zombie
{
    public class Zombie : MonoBehaviour
    {
        public Animator Animator;
        public NavMeshAgent Agent;
        [Space]
        
        public CharacterStats Stats;
        public ZombieAttack Attack;
        [Space] 
        
        public Blackboard Blackboard;
        
        [HideInInspector] [Inject] public GameFactory GameFactory;
    }
}