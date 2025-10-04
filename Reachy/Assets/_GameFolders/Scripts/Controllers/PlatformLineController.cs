using System;
using _GameFolders.Scripts.Managers;
using DG.Tweening;
using UnityEngine;

namespace _GameFolders.Scripts.Controllers
{
    public class PlatformLineController : MonoBehaviour
    {
        internal void Activate()
        {
            transform.DOLocalRotate(Vector3.right * -90f,0.5f).SetEase(Ease.Linear);
        }

        internal void GrowPlatform(float growAmount)
        {
            transform.localScale += Vector3.forward * (growAmount * Time.deltaTime);
        }

        internal void RotatePlatform(float angle)
        {
            transform.Rotate(Vector3.right * angle);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<PlatformController>(out var platform))
            {
                if (platform.IsCurrent)
                {
                    Debug.Log("Platform Line Rotation Completed");
                    GameEventManager.RaiseLineRotateCompleted();
                }
            }
        }
    }
}