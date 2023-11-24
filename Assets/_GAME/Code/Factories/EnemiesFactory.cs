using _GAME.Code.Configs_Data;
using _GAME.Code.Features;
using _GAME.Code.Logic.Zombie;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using Zenject;

namespace _GAME.Code.Factories
{
    public class EnemiesFactory
    {
        [Inject] private ConfigsFeature _configsFeature;
        [Inject] private CameraFeature _cameraFeature;
        [Inject] private DiContainer _diContainer;
        [Inject] private LevelsFactory _levelsFactory;
        
        public void SpawnRandomZombie()
        {
            Vector3 spawnPosition = CalculateRandomSpawnPosition();

            ZombieConfig zombieConfig = _configsFeature.AllZombiesConfig.ZombieConfigs[Random.Range(0, _configsFeature.AllZombiesConfig.ZombieConfigs.Count)];
            
            Zombie zombie = _diContainer.InstantiatePrefabForComponent<Zombie>(zombieConfig.ZombiePrefab);
            
            zombie.Stats.Init(zombieConfig.Stats);
            zombie.Attack.Init(zombieConfig.Damage);
            
            NavMeshHit hit;
            if (NavMesh.SamplePosition(spawnPosition, out hit, 5f, NavMesh.AllAreas))
            {
                zombie.Agent.Warp(hit.position);
            }
            else
            {
                GameObject.Destroy(zombie.gameObject);
            }
            
            SceneManager.MoveGameObjectToScene(zombie.gameObject, SceneManager.GetActiveScene());
            
            _levelsFactory.Level.AllSpawnedZombies.Add(zombie);
        }
        
        Vector3 CalculateRandomSpawnPosition()
        {
            Camera mainCamera = _cameraFeature.Camera;
            float spawnDistance = 50f;

            float randomX = Random.Range(-spawnDistance, spawnDistance);
            float randomZ = Random.Range(-spawnDistance, spawnDistance);

            Vector3 cameraPosition = mainCamera.transform.position;
            Vector3 spawnPosition = new Vector3(cameraPosition.x + randomX, 0f, cameraPosition.z + randomZ);

            return spawnPosition;
        }

        public void RemoveZombie(Zombie zombie)
        {
            _levelsFactory.Level.AllSpawnedZombies.Remove(zombie);
        }
    }
}