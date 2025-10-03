using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _GameFolders.Scripts.Functionaries
{
    public class PlatformSpawner : MonoBehaviour
    {
        [Header("Spawn Settings")]
        [SerializeField] private float maxZ = 3.5f;
        [SerializeField] private float minZ = 1.5f;
        [SerializeField] private float maxY = 2f;
        [SerializeField] private float minY = -2f;
        [SerializeField] private float spawnRate = 2f;
        [SerializeField] private int maxPlatformCount = 10;
        [Header("References")]
        [SerializeField] private GameObject platformPrefab;

        private Vector3 _lastSpawnPosition = Vector3.zero;
        private List<GameObject> _spawnedPlatforms = new List<GameObject>();
        
        private void Start()
        {
            for (int i = 0; i < 2; i++)
            {
                _lastSpawnPosition = CreateRandomPosition(_lastSpawnPosition);
                GameObject platform = Instantiate(platformPrefab, _lastSpawnPosition, Quaternion.identity);
                _spawnedPlatforms.Add(platform);
            }
            _spawnedPlatforms[0].tag = "NextPlatform";
            _spawnedPlatforms[0].transform.GetChild(0).tag = "NextPlatform";
        }

        private Vector3 CreateRandomPosition(Vector3 lastPosition)
        {
            float randomZ = Random.Range(minZ, maxZ);
            float randomY = Random.Range(minY, maxY);
            return new Vector3(0, randomY, lastPosition.z + randomZ);
        }
    }
}