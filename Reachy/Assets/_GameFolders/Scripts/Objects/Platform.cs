using System;
using DG.Tweening;
using UnityEngine;

namespace _GameFolders.Scripts.Objects
{
    public class Platform : MonoBehaviour
    {
        public Transform Line => line;
        public Transform BallTargetPoint => ballTargetPoint;
        public bool IsCurrent => _isCurrent;
        
        [Header("Settings")] 
        [SerializeField] private float lineGrowAmount;
        [SerializeField] private float lineMaxScale;
        [SerializeField] private float lineMinScale;
        [SerializeField] private float lineRotateAngle;
        
        [Header("References")]
        [SerializeField] private Transform line;
        [SerializeField] private Transform ballTargetPoint;
        [SerializeField] private Transform platformBound;
        
        private int _lineGrowMultiplier;
        private bool _isCurrent;

        private void OnEnable()
        {
            SetActive(false);
        }

        internal void SetActive(bool isActive)
        {
            _isCurrent = isActive;
            ballTargetPoint.gameObject.SetActive(!isActive);
            line.gameObject.SetActive(isActive);
            ballTargetPoint.gameObject.SetActive(!isActive);
        }

        internal void GrowLine()
        {
            if (line.localScale.z >= lineMaxScale)
                _lineGrowMultiplier = -1;
            else if (line.localScale.z <= lineMinScale)
                _lineGrowMultiplier = 1;
            line.localScale += Vector3.forward * (_lineGrowMultiplier * Time.deltaTime * lineGrowAmount);
        }

        internal void RotateLine()
        {
            line.Rotate(Vector3.right * (lineRotateAngle * Time.deltaTime));
        }
    }
}
