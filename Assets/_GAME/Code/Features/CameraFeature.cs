using System.Collections;
using _GAME.Code.Factories;
using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Features
{
    public class CameraFeature : MonoBehaviour
    {
        public Camera Camera;
        public CinemachineVirtualCamera VirtualCamera;
        
        [ReadOnly] public CinemachineFramingTransposer CinemachineFramingTransposer;
        
        [Inject] private LevelsFactory _levelsFactory;
        
        public void Init()
        {
            if (_levelsFactory.Level)
            {
                if (Camera)
                    Camera.gameObject.SetActive(false);
                
                if (VirtualCamera)
                    VirtualCamera.gameObject.SetActive(false);
                
                Camera = _levelsFactory.Level.Camera;
                VirtualCamera = _levelsFactory.Level.VirtualCamera;
                CinemachineFramingTransposer = VirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            }
        }
        
        public void SetFollowTarget(Transform target)
        {
            StartCoroutine(SetFollowTargetIE(target));
        }
        
        private IEnumerator SetFollowTargetIE(Transform target)
        {
            CinemachineFramingTransposer.m_XDamping = 0f;
            CinemachineFramingTransposer.m_YDamping = 0f;
            CinemachineFramingTransposer.m_ZDamping = 0f;
            
            VirtualCamera.Follow = target;
            
            yield return null;
            
            CinemachineFramingTransposer.m_XDamping = 1f;
            CinemachineFramingTransposer.m_YDamping = 1f;
            CinemachineFramingTransposer.m_ZDamping = 1f;
        }
        
    }
}