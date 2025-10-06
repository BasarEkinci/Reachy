using System;
using _GameFolders.Scripts.Controllers;
using _GameFolders.Scripts.Objects;

namespace _GameFolders.Scripts.Managers
{
    public static class GameEventManager
    {
        public static event Action OnLineMoveCompleted;
        public static event Action<Platform> OnCurrentPlatformChanged;
        public static event Action OnGameOver;
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