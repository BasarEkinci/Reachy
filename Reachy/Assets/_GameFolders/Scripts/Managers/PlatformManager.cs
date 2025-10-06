using _GameFolders.Scripts.Inputs;
using _GameFolders.Scripts.Objects;
using UnityEngine;

namespace _GameFolders.Scripts.Managers
{
    public class PlatformManager : MonoBehaviour
    {
        private Platform _currentPlatform;

        private enum PlatformState { Idle, Growing, Rotating }
        private PlatformState _currentPlatformState;
        private bool _canPlatformMove;

        private void Start()
        {
            _currentPlatformState = PlatformState.Idle;
        }

        private void OnEnable()
        {
            GameEventManager.OnCurrentPlatformChanged += HandlePlatformChanged;
            GameEventManager.OnLineMoveCompleted += HandleLineMoveCompleted;
        }

        private void OnDisable()
        {
            GameEventManager.OnCurrentPlatformChanged -= HandlePlatformChanged;
            GameEventManager.OnLineMoveCompleted -= HandleLineMoveCompleted;
        }

        private void HandleLineMoveCompleted()
        {
            _canPlatformMove = false;
            _currentPlatformState = PlatformState.Idle;
        }

        private void Update()
        {
            HandlePlatformState();
        }


        private void HandlePlatformState()
        {
            if (_canPlatformMove)
            {
                if (InputManager.Instance.IsPressed())
                    _currentPlatformState = PlatformState.Growing;
                else if (InputManager.Instance.WasReleasedThisFrame())
                    _currentPlatformState = PlatformState.Rotating;
            }
            
            switch (_currentPlatformState)
            {
                case PlatformState.Idle:
                    _canPlatformMove = true;
                    break;
                case PlatformState.Growing:
                    _currentPlatform.GrowLine();
                    break;
                case PlatformState.Rotating:
                    _currentPlatform.RotateLine();
                    _canPlatformMove = false;
                    if (_currentPlatform.Line.localRotation.x >= 0f)
                    {
                        _currentPlatformState = PlatformState.Idle;
                        GameEventManager.RaiseGameOver();
                        Debug.Log("Can not reach next platform. Game Over!");
                    }
                    break;
            }
        }
        
        private void HandlePlatformChanged(Platform platform)
        {
            _currentPlatform = platform;
            _currentPlatformState = PlatformState.Idle;
            _currentPlatform.SetActive(true);
        }
    }
}