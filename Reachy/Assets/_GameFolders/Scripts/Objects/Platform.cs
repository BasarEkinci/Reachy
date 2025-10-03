using UnityEngine;

namespace _GameFolders.Scripts.Objects
{
    public class Platform : MonoBehaviour
    {
        public bool IsActivated => _isActivated;

        private bool _isActivated;

        private void OnEnable()
        {
            _isActivated = false;
        }
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Path"))
            {
                _isActivated = true;
            }
        }
    }
}