using System.Collections;
using _GameFolders.Scripts.Controllers;
using _GameFolders.Scripts.Objects;
using UnityEngine;

namespace _GameFolders.Scripts.Functionaries
{
    public class PlatformHandler : MonoBehaviour
    {
        public Platform CurrentPlatform => _currentPlatform;
        public Platform NextPlatform => _nextPlatform;
        [SerializeField] private PlatformSpawner platformSpawner;
        
        private Platform _currentPlatform;
        private Platform _nextPlatform;
        
        private IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();
            if (platformSpawner.Platforms.Count > 0)
            {
                _currentPlatform = platformSpawner.Platforms[0];
                _currentPlatform.SetThisAsCurrent();
                if (platformSpawner.Platforms.Count > 1)
                {
                    _nextPlatform = platformSpawner.Platforms[1];
                    _nextPlatform.SetThisAsNext();
                }
            }
        }

        internal void ChangeCurrentPlatform()
        {
            int currentIndex = platformSpawner.Platforms.IndexOf(_currentPlatform);
            _currentPlatform.ResetThis();
            if (currentIndex + 1 < platformSpawner.Platforms.Count)
            {
                _currentPlatform = platformSpawner.Platforms[currentIndex + 1];
                _currentPlatform.SetThisAsCurrent();
                if (currentIndex + 2 < platformSpawner.Platforms.Count)
                {
                    _nextPlatform = platformSpawner.Platforms[currentIndex + 2];
                    _nextPlatform.SetThisAsNext();
                }
            }
        }
    }
}