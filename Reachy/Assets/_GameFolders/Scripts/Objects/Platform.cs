using System;
using _GameFolders.Scripts.Inputs;
using _GameFolders.Scripts.Managers;
using UnityEngine;

namespace _GameFolders.Scripts.Objects
{
    public class Platform : MonoBehaviour
    {
        [Header("Path Settings")]
        [SerializeField] private GameObject path;
        [SerializeField] private float growSpeed = 2f;
        [SerializeField] private float rotateSpeed = 50f;
        [SerializeField] private float rotateDuration = 2f;

        private enum PathState { Grow,Rotate,Idle }

        private Platform _platform;
        private bool _isActivated;
        private float _timeElapsed = 0f;
        private PathState _pathState = PathState.Idle;
        private void Awake()
        {
            _platform = GetComponent<Platform>();
        }

        private void OnEnable()
        {
            _isActivated = false;
            InputManager.Instance.OnTouchStarted += StartPathMovement;
            InputManager.Instance.OnTouchEnded += StopPathMovement;
        }
        private void OnDisable()
        {
            InputManager.Instance.OnTouchStarted -= StartPathMovement;
            InputManager.Instance.OnTouchEnded -= StopPathMovement;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _isActivated = true;
            }
        }

        private void Update()
        {
            if (!_isActivated) return;
            switch (_pathState)
            {
                case PathState.Grow:
                    GrowPath();
                    break;
                case PathState.Rotate:
                    RotatePath();
                    break;
                case PathState.Idle:
                    break;
            }
        }
        private void StartPathMovement()
        {
            _pathState = PathState.Grow;
        }
        private void StopPathMovement()
        {
            _pathState = PathState.Rotate;
            GameEventManager.RaisePathGrowCompleted();
        }

        private void GrowPath()
        {
            path.transform.localScale += Vector3.forward * (growSpeed * Time.deltaTime);
        }
        
        private void RotatePath()
        {
            path.transform.Rotate(Vector3.right * (rotateSpeed * Time.deltaTime));
            _timeElapsed += Time.deltaTime;
            if (_timeElapsed >= rotateDuration)
            {
                _pathState = PathState.Idle;
                _platform.enabled = false;
                _isActivated = false;
                GameEventManager.RaisePathRotateCompleted();
            }
        }
    }
}