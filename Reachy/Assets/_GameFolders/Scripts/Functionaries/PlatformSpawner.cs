using System.Collections.Generic;
using _GameFolders.Scripts.Controllers;
using _GameFolders.Scripts.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _GameFolders.Scripts.Functionaries
{
    public class PlatformSpawner : MonoBehaviour
    {
        public List<PlatformController> Platforms => _spawnedPlatforms;
        
        [Header("Spawn Settings")]
        [SerializeField] private float maxZ = 3.5f;
        [SerializeField] private float minZ = 1.5f;
        [SerializeField] private float maxY = 2f;
        [SerializeField] private float minY = -2f;
        [SerializeField] private int maxPlatformCount = 10;
        [Header("References")]
        [SerializeField] private PlatformController platformPrefab;

        private Vector3 _lastSpawnPosition = Vector3.zero;
        private List<PlatformController> _spawnedPlatforms;
        
        private void Start()
        {
            _spawnedPlatforms = new List<PlatformController>();
            for (int i = 0; i < maxPlatformCount; i++)
            {
                _lastSpawnPosition = CreateRandomPosition(_lastSpawnPosition);
                PlatformController platform = Instantiate(platformPrefab, _lastSpawnPosition, Quaternion.identity);
                _spawnedPlatforms.Add(platform);
            }
        }

        private Vector3 CreateRandomPosition(Vector3 lastPosition)
        {
            float randomZ = Random.Range(minZ, maxZ);
            float randomY = Random.Range(minY, maxY);
            return new Vector3(0, randomY, lastPosition.z + randomZ);
        }
    }
}