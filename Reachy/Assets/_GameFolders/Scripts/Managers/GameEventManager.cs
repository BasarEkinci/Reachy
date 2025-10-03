using System;

namespace _GameFolders.Scripts.Managers
{
    public static class GameEventManager
    {
        public static event Action OnPathGrowCompleted;
        public static event Action OnPathRotateCompleted;
        
        public static void RaisePathRotateCompleted()
        {
            OnPathRotateCompleted?.Invoke();
        }
        
        public static void RaisePathGrowCompleted()
        {
            OnPathGrowCompleted?.Invoke();
        }
    }
}