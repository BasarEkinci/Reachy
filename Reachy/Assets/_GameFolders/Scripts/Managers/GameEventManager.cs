using System;

namespace _GameFolders.Scripts.Managers
{
    public static class GameEventManager
    {
        public static event Action OnPathMovementCompleted;
        
        public static void RaisePathMovementCompleted()
        {
            OnPathMovementCompleted?.Invoke();
        }
    }
}