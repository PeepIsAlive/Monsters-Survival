using UnityEngine;
using System;
using Core;

namespace Settings
{
    [CreateAssetMenu(fileName = "EnemyPreset", menuName = "Settings/Presets/EnemyPreset", order = 0)]
    public sealed class EnemyPreset : Preset
    {
        [field: SerializeField] public EnemyType Type { get; private set; }

        [SerializeField] private PersonPreset _personPreset;
        private string _id => Guid.NewGuid().ToString();

        public Enemy GetEnemy()
        {
            return new Enemy(_id, _personPreset.Speed, Type);
        }

        protected override void RegenerateParameters()
        {
            _personPreset ??= new PersonPreset();

            _personPreset.GenerateParameters();
        }
    }
}
