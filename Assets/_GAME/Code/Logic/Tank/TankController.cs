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
            playerInputs.Player.NextWeapon.performed += NextWeapon;
            playerInputs.Player.PrevWeapon.performed += PrevWeapon;
        }

        
        private void FixedUpdate()
        {
            Move(playerInputs.Player.Move.ReadValue<Vector2>());
        }

        private void Move(Vector2 direction)
        {
            _tank.Movement.Move(direction);
        }
        
        private void Shoot(InputAction.CallbackContext context)
        {
            _tank.Shoot.Shoot();
        }

        private void NextWeapon(InputAction.CallbackContext obj)
        {
            _tank.WeaponChange.SetNextWeapon();
        }

        private void PrevWeapon(InputAction.CallbackContext obj)
        {
            _tank.WeaponChange.SetPrevWeapon();
        }

        private void OnValidate()
        {
            _tank = GetComponent<Tank>();
        }
    }
}