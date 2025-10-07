using _GameFolders.Scripts.Managers;
using UnityEngine;

namespace _GameFolders.Scripts.UI
{
    public class GameplayButtonController : MonoBehaviour
    {
        public void PlayGame() => GameEventManager.RaiseGameStart();
        public void RestartGame() => GameEventManager.RaiseGameRestart();
    }
}