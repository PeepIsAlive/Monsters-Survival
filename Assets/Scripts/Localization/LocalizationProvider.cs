using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using System.Collections.Generic;
using UnityEngine.Localization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using UnityEngine;

namespace Localization
{
    public static class LocalizationProvider
    {
        private static Dictionary<string, LocalizationFileData> _localizationFiles;

        static LocalizationProvider()
        {
            _localizationFiles = new Dictionary<string, LocalizationFileData>();
        }

        public static async Task Initialze(Locale locale)
        {
            await Setup(locale);
        }

        public static string GetText(LocalizedText asset, string key)
        {
            var fileDataKey = GetFileDataKey(asset.TableReference.TableCollectionName, asset.TableEntryReference.KeyId);
            var text = string.Empty;

            if (_localizationFiles.TryGetValue(fileDataKey, out var fileData))
                fileData.TryGetValue(key, out text);

            return text;
        }

        private static async Task Setup(Locale locale)
        {
            await LoadLocalizationAsync(locale);
        }

        private static async Task LoadLocalizationAsync(Locale locale)
        {
            var tables = await LocalizationSettings.AssetDatabase.GetAllTables(locale).Task;
            var tablesEntry = tables.SelectMany(t => t.Values);
            var tasks = new List<Task>();

            foreach (var entry in tablesEntry)
                tasks.Add(LoadFileLocalizationAsync(entry, locale));

            await Task.WhenAll(tasks);
        }

        private static async Task LoadFileLocalizationAsync(AssetTableEntry entry, Locale locale)
        {
            var tableName = entry.Table.TableCollectionName;
            var entryKeyId = entry.KeyId;
            var textAsset = await LocalizationSettings.AssetDatabase
                .GetLocalizedAssetAsync<TextAsset>(tableName, entryKeyId, locale, FallbackBehavior.UseFallback).Task;

            var localizationFileData = GetData(textAsset);
            var fileDataKey = GetFileDataKey(tableName, entryKeyId);

            if (!_localizationFiles.ContainsKey(fileDataKey))
                _localizationFiles.Add(fileDataKey, localizationFileData);
        }

        private static LocalizationFileData GetData(TextAsset file)
        {
            var data = JsonConvert.DeserializeObject<List<LocalizationItem>>(file.text);
            var loadedData = new LocalizationFileData();

            data.ForEach(item =>
            {
                var key = string.Join("/", item.Tags).ToLower();

                if (!loadedData.ContainsKey(key))
                    loadedData.Add(key, item.Topic);
            });

            return loadedData;
        }

        private static string GetFileDataKey(string tableName, long entrykeyId)
        {
            return string.Join("/", new string[] { tableName, entrykeyId.ToString() });
        }
    }
}
