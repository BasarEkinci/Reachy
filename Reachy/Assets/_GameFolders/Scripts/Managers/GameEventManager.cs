using System;
using _GameFolders.Scripts.Controllers;

namespace _GameFolders.Scripts.Managers
{
    public static class GameEventManager
    {
        public static event Action OnLineGrowCompleted;
        public static event Action OnLineRotateCompleted;
        public static event Action<PlatformController> OnCurrentPlatformChanged;
        
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
        public static void RaiseCurrentPlatformChanged(PlatformController current)
        {
            OnCurrentPlatformChanged?.Invoke(current);
        }
    }
}