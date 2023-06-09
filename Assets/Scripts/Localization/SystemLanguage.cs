using UnityEngine.Localization.Metadata;
using UnityEngine.Localization;
using UnityEngine;
using System;

namespace Localization.Metadata
{
    [DisplayName("System Language")]
    [Metadata(AllowedTypes = MetadataType.Locale)]
    [Serializable]
    public sealed class SystemLanguageMetadata : IMetadata
    {
        public SystemLanguage Language = SystemLanguage.English;
    }
}