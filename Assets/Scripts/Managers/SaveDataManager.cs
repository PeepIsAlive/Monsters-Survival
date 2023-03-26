using Services.Saves;
using UnityEditor;

namespace Managers
{
    public sealed class SaveDataManager
    {
        private readonly JsonSaveService _jsonService;
        private readonly PrefsSaveService _prefsService;

        public SaveDataManager()
        {
            _jsonService = new JsonSaveService();
            _prefsService = new PrefsSaveService();
        }

#if UNITY_EDITOR
        [MenuItem("Saves/Clear saves & prefs")]
        public static void ClearSaves()
        {

        }

        [MenuItem("Saves/Clear prefs")]
        public static void ClearPrefs()
        {

        }
#endif
    }
}
