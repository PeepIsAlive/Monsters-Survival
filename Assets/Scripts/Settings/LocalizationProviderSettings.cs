using Localization;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(menuName = "Settings/Localization/LocalizationProviderSettings", fileName = "LocalizationProviderSettings", order = 0)]
    public sealed class LocalizationProviderSettings : ScriptableObject
    {
        [field: SerializeField] public LocalizedText DefaultLocalizedText { get; private set; }
    }
}
