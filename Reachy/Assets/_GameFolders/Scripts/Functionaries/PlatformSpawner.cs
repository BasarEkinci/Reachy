using System.Collections.Generic;
using _GameFolders.Scripts.Controllers;
using _GameFolders.Scripts.Managers;
using _GameFolders.Scripts.Objects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _GameFolders.Scripts.Functionaries
{
    public class PlatformSpawner : MonoBehaviour
    {
        public List<Platform> Platforms => _spawnedPlatforms;
        
        [Header("Spawn Settings")]
        [SerializeField] private float maxZ = 3.5f;
        [SerializeField] private float minZ = 1.5f;
        [SerializeField] private float maxY = 2f;
        [SerializeField] private float minY = 0f;
        [SerializeField] private int maxPlatformCount = 10;
        [Header("References")]
        [SerializeField] private Platform platformPrefab;

        private Vector3 _lastSpawnPosition = Vector3.zero;
        private List<Platform> _spawnedPlatforms;
        
        private void Start()
        {
            _spawnedPlatforms = new List<Platform>();
            for (int i = 0; i < maxPlatformCount; i++)
            {
                Platform platform = Instantiate(platformPrefab, _lastSpawnPosition, Quaternion.identity);
                _spawnedPlatforms.Add(platform);
                _lastSpawnPosition = CreateRandomPosition(_lastSpawnPosition);
            }
        }

        private Vector3 CreateRandomPosition(Vector3 lastPosition)
        {
            float randomZ = Random.Range(minZ, maxZ);
            float randomY = Random.Range(minY, maxY);
            return new Vector3(0, lastPosition.y + randomY, lastPosition.z + randomZ);
        }
    }
}