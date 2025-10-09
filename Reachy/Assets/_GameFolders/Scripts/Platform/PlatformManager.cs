using _GameFolders.Scripts.Inputs;
using UnityEngine;

namespace _GameFolders.Scripts.Platform
{

    public class PlatformManager : MonoBehaviour
    {
        [Header("Line Settings")] 
        [SerializeField] private float lineRotateBound;
        [SerializeField] private float lineMaxScale;
        [SerializeField] private float lineMinScale;
        [SerializeField] private float lineGrowAmount;
        [SerializeField] private float lineRotationSpeed;
        private enum PlatformState { Idle, Growing, Rotating, Completed }
        private Platform _currentPlatform;
        private PlatformState _currentState;
        private bool _canGrow;
        private void OnEnable()
        {
            InputManager.OnTouchPressed += OnTouchPressed;
            InputManager.OnTouchReleased += OnTouchReleased;
        }
        private void OnDisable()
        {
            InputManager.OnTouchPressed -= OnTouchPressed;
            InputManager.OnTouchReleased -= OnTouchReleased;
        }

        private void Update()
        {
            switch (_currentState)
            {
                case PlatformState.Idle:
                    break;
                case PlatformState.Growing:
                    _currentPlatform.Line.Grow(lineGrowAmount, lineMinScale, lineMaxScale);
                    break;
                case PlatformState.Rotating:
                    _currentPlatform.Line.Rotate(lineRotationSpeed);
                    if (_currentPlatform.Line.transform.eulerAngles.x >= lineRotateBound)
                    {
                        _currentState = PlatformState.Completed;
                        _canGrow = false;
                    }
                    break;
            }
        }

        private void OnTouchPressed()
        {
            if (!_canGrow && _currentState != PlatformState.Idle)
            {
                _canGrow = true;
                _currentState = PlatformState.Growing;
            }
        }
        private void OnTouchReleased()
        {
            if (_currentState == PlatformState.Growing)
            {
                _currentState = PlatformState.Rotating;
            }
        }
    }
}