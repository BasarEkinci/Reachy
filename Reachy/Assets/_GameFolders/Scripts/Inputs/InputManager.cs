using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _GameFolders.Scripts.Inputs
{
    public class InputManager : MonoBehaviour
    {
        public static event Action OnTouchPressed;
        public static event Action OnTouchReleased;
        private InputActions _inputActions;
        private void Awake()
        {
            _inputActions = new InputActions();
        }
        private void OnEnable()
        {
            _inputActions.Enable();
            _inputActions.Gameplay.Tap.performed += OnPressed;
            _inputActions.Gameplay.Tap.canceled += OnReleased;
        }
        private void OnDisable()
        {
            _inputActions.Gameplay.Tap.performed -= OnPressed;
            _inputActions.Gameplay.Tap.canceled -= OnReleased;
            _inputActions.Disable();
        }
        private void OnPressed(InputAction.CallbackContext obj)
        { 
            OnTouchPressed?.Invoke();
        }
        private void OnReleased(InputAction.CallbackContext obj)
        {
            OnTouchReleased?.Invoke();
        }
    }
}
