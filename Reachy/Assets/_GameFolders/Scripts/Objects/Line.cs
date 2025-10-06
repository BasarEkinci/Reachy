using DG.Tweening;
using UnityEngine;

namespace _GameFolders.Scripts.Objects
{
    public class Line : MonoBehaviour
    {
        private void OnEnable()
        {
            transform.DORotate(Vector3.right * -90f, 0.3f).SetEase(Ease.Linear);
        }
    }
}