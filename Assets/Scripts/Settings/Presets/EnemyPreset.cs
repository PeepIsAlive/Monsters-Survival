using UnityEngine;
using System;
using Core;

namespace Settings
{
    [CreateAssetMenu(fileName = "EnemyPreset", menuName = "Settings/Presets/EnemyPreset", order = 0)]
    public sealed class EnemyPreset : Preset
    {
        [field: SerializeField] public EnemyType Type { get; private set; }
        [field: Range(1, 5)] [field: SerializeField] public int Damage { get; private set; }

        [Header("Person preset")]
        [SerializeField] private PersonPreset _personPreset;
        private string _id => Guid.NewGuid().ToString();

        public Enemy GetEnemy()
        {
            return new Enemy
                (
                    _id,
                    _personPreset.Speed,
                    Type,
                    new Parameters(_personPreset.ParametersSettings)
                );
        }

        protected override void RegenerateParameters()
        {
            _personPreset ??= new PersonPreset();

            Damage = UnityEngine.Random.Range(1, 5);
            _personPreset.GenerateParameters();
        }
    }
}
