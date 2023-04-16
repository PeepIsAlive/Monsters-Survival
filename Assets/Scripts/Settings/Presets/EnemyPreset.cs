using UnityEngine;
using Core;

namespace Settings
{
    [CreateAssetMenu(fileName = "EnemyPreset", menuName = "Settings/Presets/EnemyPreset", order = 0)]
    public sealed class EnemyPreset : Preset
    {
        public Person Person => _personPreset.GetPerson();

        [SerializeField] private EnemyType _type;
        [SerializeField] private PersonPreset _personPreset;

        protected override void RegenerateParameters()
        {
            _personPreset ??= new PersonPreset();

            _personPreset.GenerateParameters();
        }
    }
}
