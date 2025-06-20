using UnityEngine;

namespace Custom
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        private static object _lock = new object();
        private static bool _isApplicationQuit = false;

        public static T Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_isApplicationQuit) return null;

                    if (_instance == false) _instance = FindAnyObjectByType<T>();
                    if (_instance) return _instance;

                    GameObject obj = new GameObject(typeof(T).Name);
                    _instance = obj.AddComponent<T>();

                    return _instance;
                }
            }
        }

        protected virtual void Awake()
        {
            if (_instance)
            {
                Debug.LogWarning("More than one instance of " + typeof(T) + " exists in the scene.");
                Destroy(gameObject);
            }
            else _instance = this as T;
        }

        private void OnApplicationQuit()
        {
            _isApplicationQuit = true;
        }
    }
}