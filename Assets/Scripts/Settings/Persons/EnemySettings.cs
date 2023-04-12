using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    public sealed class EnemySettings : ScriptableObject
    {
        [Header("Creation presets")]
        [field: SerializeField] public List<EnemyPreset> Presets;
    }
}
