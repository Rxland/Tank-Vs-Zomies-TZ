using System;
using _GAME.Code.Types;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _GAME.Code.Logic.Tank
{
    public class TankController : MonoBehaviour
    {
        [SerializeField] private Tank _tank;
        [SerializeField] private PlayerInput _playerInput;
        
        private InputAction _moveAction;
        private InputAction _shootAction;

        private void Awake()
        {
            _moveAction = _playerInput.currentActionMap.FindAction(InputActionTypeName.Move.ToString());
            _moveAction.performed += Move;
        }

        private void Move(InputAction.CallbackContext context)
        {
            _tank.Movement.Move(context.ReadValue<Vector2>());
        }
        
        private void OnValidate()
        {
            _tank = GetComponent<Tank>();
            _playerInput = GetComponent<PlayerInput>();
        }
    }
}