using _GameFolders.Scripts.Controllers;
using UnityEngine;

namespace _GameFolders.Scripts.Objects
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private PlatformLineController platformLine;
        [SerializeField] private Transform ballTargetPoint;
        [SerializeField] private GameObject bounds;
        public bool IsNext => _isNext;
        public bool IsCurrent => _isCurrent;
        public Transform BallTargetPoint => ballTargetPoint;
        public PlatformLineController PlatformLine => platformLine;

        private bool _isCurrent;
        private bool _isNext;
        private void OnEnable()
        {
            _isCurrent = false;
            platformLine.gameObject.SetActive(false);
            bounds.SetActive(false);
            ballTargetPoint.gameObject.SetActive(false);
        }
        
        internal void SetThisAsCurrent()
        {
            _isNext = false;
            _isCurrent = true;
            platformLine.gameObject.SetActive(true);
            ballTargetPoint.gameObject.SetActive(false);
            bounds.SetActive(false);
        }
        internal void SetThisAsNext()
        {
            _isCurrent = false;
            _isNext = true;
            ballTargetPoint.gameObject.SetActive(true);
            bounds.SetActive(true);
        }
        internal void ResetThis()
        {
            _isCurrent = false;
            _isNext = false;
        }
    }
}
