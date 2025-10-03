using System;
using _GameFolders.Scripts.Managers;
using UnityEngine;

namespace _GameFolders.Scripts.Objects
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private ResizeDirection resizeDirection;
        [SerializeField] private Transform pathSize;
        [SerializeField] private float resizeAmount = 2f;
        [SerializeField] private float fallTimer = 3f;
        [SerializeField] private Platform platform;
        private PlatformDetector _detector;
        private bool _isRotatingStart;
        private float _rotateTimer;
        private bool _isMovementCompleted;
        private enum ResizeDirection { X, Y, Z }

        private void OnEnable()
        {
            _detector = GetComponentInChildren<PlatformDetector>();
            _isRotatingStart = false;
            _isMovementCompleted = false;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Resize(resizeDirection);
            }

            if (Input.GetMouseButtonUp(0) && platform.IsActivated)
            {
                _isRotatingStart = true;
            }
            if (!_detector.IsPlatformDetected && _rotateTimer < fallTimer && _isRotatingStart)
            {
                transform.Rotate(Vector3.right * (45 * Time.deltaTime));
                _rotateTimer += Time.deltaTime;
                _isMovementCompleted = false;
            }

            if (_rotateTimer >= fallTimer && !_isMovementCompleted)
            {
                GameEventManager.RaisePathMovementCompleted();
                _isMovementCompleted = true;
            }
        }

        private void Resize(ResizeDirection direction)
        {
            transform.localScale += direction switch
            {
                ResizeDirection.X => Vector3.right * (resizeAmount * Time.deltaTime),
                ResizeDirection.Y => Vector3.up * (resizeAmount * Time.deltaTime),
                ResizeDirection.Z => Vector3.forward * (resizeAmount * Time.deltaTime),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }
    }
}
