using UnityEngine;

namespace _GameFolders.Scripts.Platform
{
    public class PlatformLine : MonoBehaviour
    {
        internal void Grow(float growAmount, float minScale,float maxScale)
        {
            int multiplier = 0;
            if (transform.localScale.z >= maxScale)
                multiplier = -1;
            else if (transform.localScale.z <= minScale)
                multiplier = 1;
            transform.localScale += Vector3.forward * growAmount * Time.deltaTime * multiplier;
        }

        internal float Rotate(float rotationSpeed)
        {
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
            return transform.eulerAngles.x;
        }
    }
}