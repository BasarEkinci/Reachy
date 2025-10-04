using _GameFolders.Scripts.Extensions;
using UnityEngine;

namespace _GameFolders.Scripts.Inputs
{
    public class InputManager : MonoSingleton<InputManager>
    {
        private InputActions _inputActions;
        protected override void Awake()
        {
            base.Awake();
            _inputActions = new InputActions();
        }
        private void OnEnable()
        {
            _inputActions.Enable();
        }
        private void OnDisable()
        {
            _inputActions.Disable();
        }
        public bool IsPressed()
        {
#if UNITY_ANDROID || UNITY_IOS
            return _inputActions.Gameplay.Touch.IsPressed();
#endif
            return _inputActions.Gameplay.MouseClick.IsPressed();
        }
        public bool WasReleasedThisFrame()
        {
#if UNITY_ANDROID || UNITY_IOS
            return _inputActions.Gameplay.Touch.WasReleasedThisFrame();
#endif
            return _inputActions.Gameplay.MouseClick.WasReleasedThisFrame();
        }
    }
}
