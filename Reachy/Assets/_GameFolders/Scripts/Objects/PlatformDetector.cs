using _GameFolders.Scripts.Managers;
using UnityEngine;

namespace _GameFolders.Scripts.Objects
{
    public class PlatformDetector : MonoBehaviour
    {
        public bool IsPlatformDetected { get; private set; }
        [SerializeField] private float detectionRange = 3f;
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("NextPlatform"))
            {
                Debug.Log("Platform Detected");
                IsPlatformDetected = true;
                GameEventManager.RaisePathMovementCompleted();
            }
        }
    }
}
