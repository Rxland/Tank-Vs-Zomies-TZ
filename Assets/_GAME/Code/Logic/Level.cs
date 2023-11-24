using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _GAME.Code.Logic
{
    public class Level : MonoBehaviour
    {
        public Camera Camera;
        public CinemachineVirtualCamera VirtualCamera;
        public Transform PlayerSpawnPoint;
        [Space]
        
        [ReadOnly] public bool IsLevelLoaded;
        
        private void Start()
        {
            if (!SceneManager.GetActiveScene().name.Contains("_Root"))
            {
                SceneManager.LoadScene("_Root");
            }
        }
    }
}