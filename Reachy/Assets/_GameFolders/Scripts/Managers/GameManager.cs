using _GameFolders.Scripts.Controllers;
using _GameFolders.Scripts.Functionaries;
using _GameFolders.Scripts.Inputs;
using UnityEngine;

namespace _GameFolders.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Platform Settings")]
        [SerializeField] private float platformGrowAmount = 1f;
        [SerializeField] private float platformRotateAngle = 90f;
        
        [Header("Ball Settings")]
        [SerializeField] private float ballMoveSpeed = 5f;
        
        [Header("References")]
        [SerializeField] private PlatformHandler platformHandler;
        [SerializeField] private BallMovementController ball;
        
        private enum GameState
        {
            LineGrowing,
            LineRotating,
            BallMoving,
            BallIdle,
            GameOver
        }

        private float _timer;
        private bool _canGrow;
        private GameState _currentState;
        
        private void OnEnable()
        {
            GameEventManager.OnLineRotateCompleted += HandleLineRotateCompleted;
            GameEventManager.OnBallMoveCompleted += HandleBallMoveCompleted;
            GameEventManager.OnGameOver += HandleGameOver;
            _currentState = GameState.BallIdle;
            _canGrow = true;
        }

        private void HandleBallMoveCompleted()
        {
            _currentState = GameState.BallIdle;
            platformHandler.ChangeCurrentPlatform();
            ball.SetTargetPoint(platformHandler.NextPlatform.BallTargetPoint.position);
        }

        private void OnDisable()
        {
            GameEventManager.OnLineRotateCompleted -= HandleLineRotateCompleted;
            GameEventManager.OnBallMoveCompleted -= HandleBallMoveCompleted;
            GameEventManager.OnGameOver -= HandleGameOver;
        }

        private void HandleGameOver()
        {
            _currentState = GameState.GameOver;
        }

        private void HandleLineRotateCompleted()
        {
            ball.SetTargetPoint(platformHandler.NextPlatform.BallTargetPoint.position);
            _currentState = GameState.BallMoving;
        }

        private void Update()
        {
            HandleInput();
            HandleGameState();
        }

        private void HandleInput()
        {
            if (_canGrow)
            {
                if (InputManager.Instance.IsPressed())
                {
                    _currentState = GameState.LineGrowing;
                }
                if (InputManager.Instance.WasReleasedThisFrame())
                { 
                    _currentState = GameState.LineRotating;
                }    
            }
        }

        private void HandleGameState()
        {
            switch (_currentState)
            {
                case GameState.LineGrowing:
                    platformHandler.CurrentPlatform.PlatformLine.GrowPlatform(platformGrowAmount);
                    break;
                case GameState.LineRotating:
                    platformHandler.CurrentPlatform.PlatformLine.RotatePlatform(platformRotateAngle);
                    _canGrow = false;
                    break;
                case GameState.BallMoving:
                    _canGrow = false;
                    break;
                case GameState.BallIdle:
                    _canGrow = true;
                    break;
                case GameState.GameOver:
                    _canGrow = false;
                    break;
            }
        }
    }
}