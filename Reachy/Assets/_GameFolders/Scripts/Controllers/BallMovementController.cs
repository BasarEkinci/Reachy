using System;
using _GameFolders.Scripts.Managers;
using DG.Tweening;
using UnityEngine;

namespace _GameFolders.Scripts.Controllers
{
    public class BallMovementController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private GameObject mesh;
        private Rigidbody _rb;
        private Vector3 _targetPoint;
        private bool _canMove;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            GameEventManager.OnLineRotateCompleted += HandleLineRotateCompleted;
        }

        private void FixedUpdate()
        {
            if (!_canMove)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    _targetPoint,
                    moveSpeed * Time.fixedDeltaTime
                );
                _canMove = !(Vector3.Distance(transform.position, _targetPoint) < 0.1f);
            }
        }

        private void OnDisable()
        {
            GameEventManager.OnLineRotateCompleted -= HandleLineRotateCompleted;
        }

        private void HandleLineRotateCompleted()
        {
            _canMove = true;
        }
        internal void SetTargetPoint(Vector3 targetPoint)
        {
            _targetPoint = new Vector3(targetPoint.x, transform.position.y, targetPoint.z);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("PlatformBound"))
            {
                GameEventManager.RaiseGameOver();
                _canMove = false;
            }
        }
    }
}