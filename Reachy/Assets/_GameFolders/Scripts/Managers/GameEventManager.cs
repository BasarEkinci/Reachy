using System;
using _GameFolders.Scripts.Controllers;
using _GameFolders.Scripts.Objects;

namespace _GameFolders.Scripts.Managers
{
    public static class GameEventManager
    {
        public static event Action OnLineGrowCompleted;
        public static event Action OnLineRotateCompleted;
        public static event Action<Platform> OnCurrentPlatformChanged;
        public static event Action OnBallMoveCompleted;
        public static event Action OnGameOver;
        
        public static void RaiseGameOver()
        {
            OnGameOver?.Invoke();
        }
        public static void RaiseBallMoveCompleted()
        {
            OnBallMoveCompleted?.Invoke();
        }
        public static void RaiseLineRotateCompleted()
        {
            OnLineRotateCompleted?.Invoke();
        }
        
        public static void RaiseLineGrowCompleted()
        {
            OnLineGrowCompleted?.Invoke();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current">The platform that ball stays</param>
        /// <param name="next">The platform that next to current</param>
        public static void RaiseCurrentPlatformChanged(Platform current)
        {
            OnCurrentPlatformChanged?.Invoke(current);
        }
    }
}