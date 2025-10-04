using DG.Tweening;
using UnityEngine;

namespace _GameFolders.Scripts.Controllers
{
    public class PlatformLineController : MonoBehaviour
    {
        [SerializeField] private float maxGrowLength = 7f;
        [SerializeField] private float minGrowLength = 1f;

        private int _growMultiplier;
        
        private void OnEnable()
        {
            transform.DOLocalRotate(Vector3.right * -90f,0.5f).SetEase(Ease.Linear);
        }

        internal void GrowPlatform(float growAmount)
        {
            if (transform.localScale.z >= maxGrowLength)
                _growMultiplier = -1;
            else if (transform.localScale.z <= minGrowLength)
                _growMultiplier = 1;
            transform.localScale += Vector3.forward * (growAmount * _growMultiplier * Time.deltaTime);
        }

        internal void RotatePlatform(float angle)
        {
            transform.Rotate(Vector3.right * (angle * Time.deltaTime));
        }
    }
}