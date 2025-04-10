using UnityEngine;

namespace ChestSystem.Utilities
{
    public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T>
    {
        private static T _instance;
        private static T Instance
        {
            get { return _instance; }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = (T)this;
            }
            else
            {
                Destroy(_instance);
            }
        }
    }
}
