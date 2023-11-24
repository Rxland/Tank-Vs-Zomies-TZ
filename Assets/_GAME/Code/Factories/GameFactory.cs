﻿using _GAME.Code.Features;
using _GAME.Code.Logic.Tank;
using UnityEngine.SceneManagement;
using Zenject;

namespace _GAME.Code.Factories
{
    public class GameFactory
    {
        private Tank _palyer;
        public Tank Player => _palyer;

        [Inject] private LevelsFactory _levelsFactory;
        [Inject] private ConfigsFeature _configsFeature;
        [Inject] private CameraFeature _cameraFeature;
        [Inject] private DiContainer _diContainer;

        public void SpawnPlayer()
        {
            _palyer = _diContainer.InstantiatePrefabForComponent<Tank>(_configsFeature.TankConfigData.TankPrefab);
            _palyer.transform.position = _levelsFactory.Level.PlayerSpawnPoint.transform.position;

            _cameraFeature.SetFollowTarget(_palyer.transform);
            
            SceneManager.MoveGameObjectToScene(_palyer.gameObject, SceneManager.GetActiveScene());
        }
    }
}