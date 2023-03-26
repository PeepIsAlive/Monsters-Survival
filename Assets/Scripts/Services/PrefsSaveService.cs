using UnityEngine;
using System;
using Core;

namespace Services.Saves
{
    public sealed class PrefsSaveService : ISaveService
    {
        public void Load<T>(string key, Action<T> callback)
        {
            if (string.IsNullOrEmpty(key))
            {
#if UNITY_EDITOR
                Debug.LogWarning("key is null or empty");
#endif
                return;
            }

            if (!PlayerPrefs.HasKey(key))
            {
#if UNITY_EDITOR
                Debug.LogWarning("key doesn't exist");
#endif
                return;
            }

            if (typeof(T) == typeof(int))
                PlayerPrefs.GetInt(key);

            if (typeof(T) == typeof(string))
                PlayerPrefs.GetString(key);

            if (typeof(T) == typeof(float))
                PlayerPrefs.GetFloat(key);
        }

        public void Save(string key, object data, Action<bool> callback = null)
        {
            if (string.IsNullOrEmpty(key) || data == null)
                return;

            if (data is int)
                PlayerPrefs.SetInt(key, (int)data);

            if (data is string)
                PlayerPrefs.SetString(key, (string)data);

            if (data is float)
                PlayerPrefs.SetFloat(key, (float)data);

            callback?.Invoke(true);
        }
    }
}