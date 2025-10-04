using _GameFolders.Scripts.Controllers;
using _GameFolders.Scripts.Functionaries;
using _GameFolders.Scripts.Inputs;
using UnityEngine;
using static _GameFolders.Scripts.Managers.GameEventManager;


namespace _GameFolders.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Platform Settings")]
        [SerializeField] private float rotateTimer;
        [SerializeField] private float rotateAngle;
        [SerializeField] private float growAmount = 5f;
        
        [Header("References")]
        [SerializeField] private BallMovementController ball;
        [SerializeField] private PlatformSpawner platformSpawner;

        private enum PlatformLineState
        {
            Idle,
            Growing,
            Rotating
        }
        
        private PlatformController _currentPlatform;
        private PlatformController _nextPlatform;
        private PlatformLineState _currentState;

        private float _timeAmount;
        private bool _canMove;

        private void Start()
        {
            _canMove = true;
        }

        private void OnEnable()
        {
            OnCurrentPlatformChanged += CurrentPlatformChanged;
            OnLineRotateCompleted += ball.MoveNextPlatform;
            OnLineGrowCompleted += LineGrowCompletedHandler;
        }

        private void Update()
        {
            HandleInput();
            HandlePlatformLineState();
        }
        
        private void OnDisable()
        {
            OnCurrentPlatformChanged -= CurrentPlatformChanged;
            OnLineRotateCompleted -= ball.MoveNextPlatform;
            OnLineGrowCompleted -= LineGrowCompletedHandler;
        }

        private void LineGrowCompletedHandler()
        {
            _currentState = PlatformLineState.Rotating;
        }
        private void HandleInput()
        {
            Debug.Log("Can Move: " + _canMove);
            if (_canMove)
            {
                if (InputManager.Instance.IsPressed())
                {
                    _currentState = PlatformLineState.Growing;
                    Debug.Log("Pressed");
                }

                if (InputManager.Instance.WasReleasedThisFrame())
                {
                    _currentState = PlatformLineState.Rotating;
                    Debug.Log("Released");
                    _canMove = false;
                }
            }
        }
        
        private void HandlePlatformLineState()
        {
            switch (_currentState)
            {
                case PlatformLineState.Growing:
                    _currentPlatform.PlatformLine.GrowPlatform(growAmount);
                    break;
                case PlatformLineState.Rotating:
                    _timeAmount += Time.deltaTime;
                    _currentPlatform.PlatformLine.RotatePlatform(rotateAngle * Time.deltaTime);
                    if (_timeAmount >= rotateTimer)
                    {
                        _currentState = PlatformLineState.Idle;
                        _timeAmount = 0f;
                    }
                    break;
            }
        }
        
        private void CurrentPlatformChanged(PlatformController current)
        {
            if (_currentPlatform != null)
            {
                _currentPlatform.ResetThis();
            }
            _currentPlatform = current;
            _currentPlatform.SetThisAsCurrent();
            int nextPlatformIndex = platformSpawner.Platforms.IndexOf(current);
            _nextPlatform = platformSpawner.Platforms[nextPlatformIndex];
            _currentPlatform.PlatformLine.Activate();
            ball.SetTargetPoint(_nextPlatform.BallTargetPoint);
            _canMove = true;
            _timeAmount = 0f;
            _currentState = PlatformLineState.Idle;
        }
    }
}