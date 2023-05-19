using System.Collections.Generic;
using UnityEngine;
using System;

namespace Settings
{
    public static class SettingsProvider
    {
        private static Dictionary<Type, ScriptableObject> _settings;
        private const string SETTINGS_PATH = "Settings/{0}";

        static SettingsProvider()
        {
            _settings = new Dictionary<Type, ScriptableObject>();
        }

        public static T Load<T>() where T : ScriptableObject
        {
            var type = typeof(T);

            if (_settings.ContainsKey(type))
                return (T)_settings[type];

            var path = string.Format(SETTINGS_PATH, type.Name);
            var so = Resources.Load<T>(path);

            _settings.Add(type, so);

            return so;
        }
    }
}
