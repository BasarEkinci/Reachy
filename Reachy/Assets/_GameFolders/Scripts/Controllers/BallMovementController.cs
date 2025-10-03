using System;
using _GameFolders.Scripts.Managers;
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
            GameEventManager.OnPathMovementCompleted += ()=> _canMove = true;
        }
        private void OnDisable()
        {
            GameEventManager.OnPathMovementCompleted -= ()=> _canMove = true;
        }

        private void FixedUpdate()
        {
            if (_canMove)
            {
                MoveBallForward();
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Path"))
            {
                _canMove = false;
                _rb.isKinematic = true;
                Debug.Log("Movement Stopped");
            }
        }

        private void MoveBallForward()
        {
            transform.position += transform.forward * (moveSpeed * Time.fixedDeltaTime);                   
        }
    }
}