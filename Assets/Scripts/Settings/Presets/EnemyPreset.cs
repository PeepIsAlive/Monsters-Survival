using UnityEngine;
using Core;

namespace Settings
{
    [CreateAssetMenu(fileName = "EnemyPreset", menuName = "Settings/Presets/EnemyPreset", order = 0)]
    public sealed class EnemyPreset : Preset
    {
        [field: SerializeField] public EnemyType Type { get; private set; }
        [field: SerializeField] public PersonPreset PersonPreset { get; private set; }
    }
}
