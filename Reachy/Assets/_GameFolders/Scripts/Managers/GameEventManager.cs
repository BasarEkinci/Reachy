using System;
using _GameFolders.Scripts.Controllers;
using _GameFolders.Scripts.Objects;
using UnityEngine.Rendering.Universal;

namespace _GameFolders.Scripts.Managers
{
    public static class GameEventManager
    {
        public static event Action OnLineMoveCompleted;
        public static event Action<Platform> OnCurrentPlatformChanged;
        public static event Action OnGameOver;
        public static event Action OnGameRestart;
        public static event Action OnGameStart;
        
        public static void RaiseGameStart()
        {
            OnGameStart?.Invoke();
        }
        public static void RaiseGameRestart()
        {
            OnGameRestart?.Invoke();
        }
        
        public static void RaiseGameOver()
        {
            OnGameOver?.Invoke();
        }
        public static void RaiseLineMovementCompleted()
        {
            OnLineMoveCompleted?.Invoke();
        }
        public static void RaiseCurrentPlatformChanged(Platform current)
        {
            OnCurrentPlatformChanged?.Invoke(current);
        }
    }
}