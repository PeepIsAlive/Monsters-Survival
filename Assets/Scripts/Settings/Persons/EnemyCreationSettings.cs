using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Core;

namespace Settings
{
    [CreateAssetMenu(fileName = "EnemyCreationSettings", menuName = "Settings/Creation/EnemyCreationSettings", order = 0)]
    public sealed class EnemyCreationSettings : ScriptableObject
    {
        [field: SerializeField] public List<EnemyPreset> Presets { get; private set; }

        public Enemy GetEnemy(EnemyType type)
        {
            return Presets.First(x => x.Type == type).GetEnemy();
        }
    }
}
