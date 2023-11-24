using System;
using System.Collections.Generic;
using _GAME.Code.Factories;
using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Zenject;

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
            if (!SceneManager.GetActiveScene().name.Contains("_Root"))
            {
                SceneManager.LoadScene("_Root");
            }
            else
            {
                OnLevelLoaded?.Invoke();
            }
        }
    }
}