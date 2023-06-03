using UnityEngine;
using System;
using Core;

namespace Settings
{
    [CreateAssetMenu(fileName = "CharacterPreset", menuName = "Settings/Presets/CharacterPreset", order = 0)]
    public sealed class CharacterPreset : Preset
    {
        [SerializeField] private PersonPreset _personPreset;

        public Character GetCharacter()
        {
            return new Character
                (
                    Guid.NewGuid().ToString(),
                    _personPreset.Speed,
                    new Parameters(_personPreset.ParameterSettings)
                );
        }

        protected override void RegenerateParameters()
        {
            _personPreset ??= new PersonPreset();

            _personPreset.GenerateParameters();
        }
    }
}
