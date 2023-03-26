using Newtonsoft.Json;
using UnityEngine;
using System.IO;
using System;
using Core;

namespace Services.Saves
{
    public sealed class JsonSaveService : ISaveService
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

            var path = GetPath(key);

            using (var sr = new StreamReader(path))
            {
                var json = sr.ReadToEnd();
                var data = JsonConvert.DeserializeObject<T>(json);

                callback?.Invoke(data);
            }
        }

        public void Save(string key, object data, Action<bool> callback = null)
        {
            if (string.IsNullOrEmpty(key))
            {
                callback?.Invoke(false);
                return;
            }

            var path = GetPath(key);
            var json = JsonConvert.SerializeObject(data);

            using (var sw = new StreamWriter(path))
            {
                sw.Write(json);
            }

            callback?.Invoke(true);
        }

        private static string GetPath(string key)
        {
            return Path.Combine(Application.persistentDataPath, key);
        }
    }
}
