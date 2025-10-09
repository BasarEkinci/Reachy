using UnityEngine;

namespace _GameFolders.Scripts.Extensions
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        public static T Instance { get; private set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void CreateInstance()
        {
            if (Instance == null)
            {
                GameObject obj = new GameObject(typeof(T).Name);
                Instance = obj.AddComponent<T>();
                DontDestroyOnLoad(obj);
            }
        }

        protected virtual void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = (T)this;
        }
    }
}