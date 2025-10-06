using System;
using _GameFolders.Scripts.Managers;
using _GameFolders.Scripts.Objects;
using UnityEngine;

namespace _GameFolders.Scripts.Controllers
{
    public class BallMovementController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float surfaceCheckDistance = 1.0f;
        [SerializeField] private float targetPointCheckDistance = 0.5f;
        [SerializeField] private float targetPointOffset = 0.5f;
        [SerializeField] private float offset;
        [SerializeField] private LayerMask surfaceLayer;
        
        private bool _canMove;
        private Vector3 _position;
        private Platform _targetPlatform;
        
        private void OnEnable()
        {
            GameEventManager.OnLineMoveCompleted += HandleLineMovementCompleted;
        }

        private void OnDisable()
        {
            GameEventManager.OnLineMoveCompleted -= HandleLineMovementCompleted;
        }

        private void Update()
        {
            if (!IsReachedTargetPoint() && _canMove)
            {
                MoveForwardAndFollowSurface();
            }
        }

        private void MoveForwardAndFollowSurface()
        {
            Vector3 forwardMove = transform.forward * (moveSpeed * Time.deltaTime);
            Vector3 nextPosition = transform.position + forwardMove;
            if (Physics.Raycast(nextPosition, Vector3.down, out var hit, surfaceCheckDistance, surfaceLayer))
            {
                if (hit.collider.TryGetComponent<Platform>(out var platform))
                {
                    if (platform != null && !platform.IsCurrent)
                    {
                        _targetPlatform = platform;
                    }           
                }
                nextPosition.y = hit.point.y + offset;
            }
            transform.position = nextPosition;
        }
        
        private bool IsReachedTargetPoint()
        {
            if (Physics.Raycast(transform.position, Vector3.forward + Vector3.down * targetPointOffset, out var hit, targetPointCheckDistance, surfaceLayer))
            {
                if (hit.collider.CompareTag("BallTargetPoint"))
                {
                    _canMove = false;
                    GameEventManager.RaiseCurrentPlatformChanged(_targetPlatform);
                    return true;
                }
                if (hit.collider.CompareTag("Platform"))
                {
                    GameEventManager.RaiseGameOver();
                    _canMove = false;
                }
            }
            return false;
        }
        
        private void HandleLineMovementCompleted()
        {
            _canMove = true;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position - transform.up * surfaceCheckDistance);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.forward * targetPointCheckDistance);
        }
    }
}