using _GAME.Code.Features;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Logic.Tank
{
    public class TankMovement : MonoBehaviour
    {
        [SerializeField] private Tank _tank;
        
        [Inject] private ConfigsFeature _configsFeature;
        [Inject] private CameraFeature _cameraFeature;
        
        Vector3 rotateDir = Vector3.zero;
        
        public void Move(Vector2 direction)
        {
            if (direction == Vector2.zero)
            {
                _tank.Rigidbody.velocity  = Vector3.zero;
                return;
            }
            
            _tank.Rigidbody.velocity = transform.forward * _configsFeature.TankConfigData.MoveSpeed;
            
            rotateDir = Vector3.zero;
            rotateDir += _cameraFeature.Camera.transform.right * direction.x;
            rotateDir += _cameraFeature.Camera.transform.forward * direction.y;

            Quaternion newRotation = Quaternion.LookRotation(rotateDir, Vector3.up);
            newRotation = Quaternion.Euler(0f, newRotation.eulerAngles.y, newRotation.eulerAngles.z);
            newRotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * _configsFeature.TankConfigData.TurnSpeed);

            transform.rotation = newRotation;
        }

        private void OnValidate()
        {
            _tank = GetComponent<Tank>();
        }
    }
}