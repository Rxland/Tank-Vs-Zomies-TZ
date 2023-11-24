using System;
using System.Collections;
using _GAME.Code.Logic;
using _GAME.Code.Tools;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace _GAME.Code.Factories
{
    public class LevelsFactory
    {
        [Inject] private ZenjectSceneLoader _zenjectSceneLoader;
        
        private Level _level;
        public Level Level => _level;
        
        public void SpawnLevel(int levelId, Action OnLevelLoaded)
        {
            MainThreadDispatcher.StartUpdateMicroCoroutine(SpawnLevelIE(levelId, OnLevelLoaded)); 
        }
        
        public void UnloadLevel(int levelIdToUnload, Action callAfterUnload)
        {
            MainThreadDispatcher.StartUpdateMicroCoroutine(UnLoadLLevelIE(levelIdToUnload, callAfterUnload));
        }
        
        private IEnumerator SpawnLevelIE(int levelId, Action OnLevelLoaded)
        {
            string levelName = $"Level_{levelId + 1}";

            if (!GameExtensions.IsSceneExists(levelName))
            {
                levelName = $"Level_{1}";
            }
            
            AsyncOperation asyncLoad = _zenjectSceneLoader.LoadSceneAsync(levelName, LoadSceneMode.Additive,container => { }, LoadSceneRelationship.Child);
            
            while (!asyncLoad.isDone)
            {
                float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            
                // _windowFactory.LoadingWindow.LoadingSlider.value = progress;
            
                yield return null;
            }
            _level = GameObject.FindObjectOfType<Level>();
            
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(levelName));
            
            OnLevelLoaded?.Invoke();
        }
        
        private IEnumerator UnLoadLLevelIE(int levelIdToUnload, Action callAfterUnload)
        {
            AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync($"Level_{levelIdToUnload + 1}");
            
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            callAfterUnload?.Invoke();
        }
    }
}