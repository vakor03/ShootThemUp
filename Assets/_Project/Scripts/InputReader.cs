using System;
using UnityEngine;

namespace ShootThemUp._Project.Scripts
{
    public class InputReader : MonoBehaviour
    {
        private PlayerInputActions _playerInputActions;

        public Vector2 Move => _playerInputActions.Player.Move.ReadValue<Vector2>();
        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();
        }
        
        private void OnEnable()
        {
            _playerInputActions.Player.Enable();
        }
        
        private void OnDisable()
        {
            _playerInputActions.Player.Disable();
        }
    }
}