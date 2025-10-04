using UnityEngine;

namespace _GameFolders.Scripts.Controllers
{
    public class PlatformController : MonoBehaviour
    {
        [SerializeField] private PlatformLineController platformLine;
        [SerializeField] private Transform ballTargetPoint;
        
        public bool IsCurrent => _isCurrent;
        public Transform BallTargetPoint => ballTargetPoint;
        public PlatformLineController PlatformLine => platformLine;

        private bool _isCurrent;
        private void OnEnable()
        {
            _isCurrent = false;
        }
        
        internal void SetThisAsCurrent()
        {
            _isCurrent = true;
        }

        internal void ResetThis()
        {
            _isCurrent = false;
        }
    }
}
