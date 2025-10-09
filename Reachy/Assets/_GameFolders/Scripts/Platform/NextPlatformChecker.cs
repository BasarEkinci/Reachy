using UnityEngine;

namespace _GameFolders.Scripts.Platform
{
    public class NextPlatformChecker : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<Platform>(out var platform))
            {
                if (platform.IsCurrent)
                {
                    //Raise event to completed rotation
                }
            }
        }
    }
}