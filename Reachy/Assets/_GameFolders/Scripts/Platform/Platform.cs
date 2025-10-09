using UnityEngine;

namespace _GameFolders.Scripts.Platform
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private PlatformLine line;
        public bool IsCurrent => _isCurrent;
        public PlatformLine Line => line;
        private bool _isCurrent;
    }
}