using UnityEngine;

namespace _GameFolders.Scripts.Ball
{
    public class BallMovementController : MonoBehaviour
    {
        [Header("Ball Movement Settings")]
        [SerializeField] private Transform targetPoint;
        [SerializeField] private float moveForce = 10f;
        [SerializeField] private float stopDistance = 0.2f;
        [SerializeField] private float extraGravityForce = 20f; 

        private Rigidbody _rb;
        private bool _isMoving = false;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MoveToTarget(targetPoint);
            }
        }

        private void FixedUpdate()
        {
            if (_isMoving && targetPoint != null)
            {
                Vector3 direction = (targetPoint.position - transform.position);
                float distance = direction.magnitude;
                if (distance <= stopDistance)
                {
                    _rb.linearVelocity = Vector3.zero;
                    _rb.angularVelocity = Vector3.zero;
                    _isMoving = false;
                    _rb.isKinematic = true;
                    return;
                }
                _rb.AddForce(direction.normalized * moveForce, ForceMode.Force);
                _rb.AddForce(Vector3.down * extraGravityForce, ForceMode.Force);
            }
        }

        private void MoveToTarget(Transform target)
        {
            targetPoint = target;
            _isMoving = true;
            _rb.isKinematic = false;
        }
    }
}
