using UnityEngine;
using Core;

namespace Settings
{
    [CreateAssetMenu(fileName = "CharacterPreset", menuName = "Settings/Presets/CharacterPreset", order = 0)]
    public sealed class CharacterPreset : Preset
    {
        public Person Person => _personPreset.GetPerson();

        [SerializeField] private PersonPreset _personPreset;

        protected override void RegenerateParameters()
        {
            _personPreset ??= new PersonPreset();

            _personPreset.GenerateParameters();
        }
    }
}
