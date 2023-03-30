using UnityEngine;

namespace Settings
{
    public static class SettingsProvider
    {
        private const string SETTINGS_PATH = "Settings/{0}";

        public static T Load<T>() where T : ScriptableObject
        {
            return Resources.Load<T>(string.Format(SETTINGS_PATH, nameof(T)));
        }
    }
}
