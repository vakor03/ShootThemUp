using UnityEngine;

namespace ShootThemUp
{
    public class InputReader : MonoBehaviour
    {
        private PlayerInputActions _playerInputActions;

        public Vector2 Move => _playerInputActions.Player.Move.ReadValue<Vector2>();
        public bool Fire => _playerInputActions.Player.Fire.ReadValue<float>() > 0f;

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