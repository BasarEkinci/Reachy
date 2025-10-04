using _GameFolders.Scripts.Managers;
using UnityEngine;

namespace _GameFolders.Scripts.Controllers
{
    public class BallMovementController : MonoBehaviour
    {
        private Rigidbody _rb;
        private Transform _targetPoint;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        internal void MoveNextPlatform()
        {
            _rb.MovePosition(_targetPoint.position);
        }

        internal void SetTargetPoint(Transform targetPoint)
        {
            _targetPoint = targetPoint;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<PlatformController>(out var platform))
            {
                GameEventManager.RaiseCurrentPlatformChanged(platform);
            }
        }
    }
}