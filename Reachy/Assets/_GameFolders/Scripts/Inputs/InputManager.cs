using System;
using _GameFolders.Scripts.Extensions;
using UnityEngine;

namespace _GameFolders.Scripts.Inputs
{
    public class InputManager : MonoSingleton<InputManager>
    {
        public event Action OnTouchStarted;
        public event Action OnTouchEnded;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                OnTouchStarted?.Invoke();
            if (Input.GetMouseButtonUp(0))
                OnTouchEnded?.Invoke();
        }
    }
}
