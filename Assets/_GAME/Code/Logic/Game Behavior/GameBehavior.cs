using _GAME.Code.Factories;
using _GAME.Code.Features;
using _GAME.Code.UI;
using NodeCanvas.Framework;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Logic.Game_Behavior
{
    public class GameBehavior : MonoBehaviour
    {
        [ReadOnly] [Inject] public WindowsController WindowsController;
        [ReadOnly] [Inject] public LevelsFactory LevelsFactory;
        [ReadOnly] [Inject] public CameraFeature CameraFeature;
        [ReadOnly] [Inject] public GameFactory GameFactory;
        
        public GlobalBlackboard GlobalBlackboard;
    }
}