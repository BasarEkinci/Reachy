using _GameFolders.Scripts.Controllers;
using _GameFolders.Scripts.Managers;
using UnityEngine;

namespace _GameFolders.Scripts.Objects
{
    public class NextPlatformTrigger : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<Platform>(out var platform))
            {
                if (platform.IsNext)
                {
                    GameEventManager.RaiseLineRotateCompleted();
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("PlatformBound"))
            {
                GameEventManager.RaiseGameOver();
            }
        }
    }
}
