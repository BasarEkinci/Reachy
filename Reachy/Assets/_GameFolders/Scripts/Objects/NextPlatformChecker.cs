using _GameFolders.Scripts.Managers;
using UnityEngine;

namespace _GameFolders.Scripts.Objects
{
    public class NextPlatformChecker : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            Platform platform = other.gameObject.GetComponent<Platform>();
            if (platform != null && !platform.IsCurrent)
            {
                GameEventManager.RaiseLineMovementCompleted();                
            }
        }
    }
}