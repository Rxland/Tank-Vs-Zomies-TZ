using UnityEngine;
using UnityEngine.InputSystem;

namespace _GAME.Code.Logic.Tank
{
    public class TankController : MonoBehaviour
    {
        [SerializeField] private Tank _tank;

        private PlayerInputs playerInputs;
        
        private void Awake()
        {
            playerInputs = new PlayerInputs();
            playerInputs.Enable();
            playerInputs.Player.Shoot.performed += Shoot;
        }



        private void FixedUpdate()
        {
            _tank.Movement.Move(playerInputs.Player.Move.ReadValue<Vector2>());
        }

        private void Move(InputAction.CallbackContext context)
        {
            Vector2 inputVector = context.ReadValue<Vector2>();
            _tank.Movement.Move(inputVector);
        }
        
        private void Shoot(InputAction.CallbackContext context)
        {
            _tank.Shoot.Shoot();
        }
        
        private void OnValidate()
        {
            _tank = GetComponent<Tank>();
        }
    }
}