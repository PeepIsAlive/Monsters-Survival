using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "EnemyCreationSettings", menuName = "Settings/Creation/EnemyCreationSettings", order = 0)]
    public sealed class EnemyCreationSettings : ScriptableObject
    {
        [field: SerializeField] public List<EnemyPreset> Presets { get; private set; }
    }
}
