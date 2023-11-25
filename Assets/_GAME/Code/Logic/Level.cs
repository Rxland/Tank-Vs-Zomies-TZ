using System.Collections.Generic;
using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace _GAME.Code.Logic
{
    public class Level : MonoBehaviour
    {
        public Camera Camera;
        public CinemachineVirtualCamera VirtualCamera;
        public Transform PlayerSpawnPoint;
        [Space]
        
        [ReadOnly] public bool IsLevelLoaded;
        [Space] 
        
        [ReadOnly] public List<Zombie.Zombie> AllSpawnedZombies;

        public UnityEvent OnLevelLoaded;
        
        private void Start()
        {
            OnLevelLoaded?.Invoke();
            IsLevelLoaded = true;
        }
    }
}