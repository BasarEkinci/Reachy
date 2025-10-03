using _GameFolders.Scripts.Managers;
using UnityEngine;

namespace _GameFolders.Scripts.Objects
{
    public class PlatformDetector : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("NextPlatform"))
            {
                GameEventManager.RaisePathGrowCompleted();
            }
        }
    }
}
