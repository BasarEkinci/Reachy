using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _GameFolders.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Transform ball;
        
        private Transform _ballInitialPosition;

        private void Start()
        {
            _ballInitialPosition = ball;
        }

        private void OnEnable()
        {
            GameEventManager.OnGameRestart += RestartGame;
        }
        
        private void OnDisable()
        {
            GameEventManager.OnGameRestart -= RestartGame;
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}