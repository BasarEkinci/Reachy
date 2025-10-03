using _GameFolders.Scripts.Managers;
using _GameFolders.Scripts.Objects;
using UnityEngine;

namespace _GameFolders.Scripts.Controllers
{
    public class BallMovementController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        private Rigidbody _rb;
        private bool _canMove;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }
        private void OnEnable()
        {
            _canMove = false;
            GameEventManager.OnPathRotateCompleted += StartMovement;
        }

        private void FixedUpdate()
        { 
            if (_canMove)
            {
                StartMovement();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("NextPlatform"))
            {
                _canMove = false;
                Platform platform = other.GetComponent<Platform>();
                platform.enabled = true;
                StopMovement();
            }
        }

        private void OnDisable()
        {
            GameEventManager.OnPathRotateCompleted -= StartMovement;
        }

        private void StartMovement()
        {
            _canMove = true;
            _rb.isKinematic = false;
            _rb.linearVelocity = new Vector3(_rb.linearVelocity.x,_rb.linearVelocity.y,moveSpeed);
        }

        private void StopMovement()
        {
            _canMove = false;
            _rb.linearVelocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            _rb.isKinematic = true;
        }
    }
}