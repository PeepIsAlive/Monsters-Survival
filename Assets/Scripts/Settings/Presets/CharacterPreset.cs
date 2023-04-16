using UnityEngine;
using System;
using Core;

namespace Settings
{
    [CreateAssetMenu(fileName = "CharacterPreset", menuName = "Settings/Presets/CharacterPreset", order = 0)]
    public sealed class CharacterPreset : Preset
    {
        [SerializeField] private PersonPreset _personPreset;

        public Person GetPerson()
        {
            return _personPreset.GetPerson();
        }

        public Character GetCharacter()
        {
            return new Character(Guid.NewGuid().ToString());
        }

        protected override void RegenerateParameters()
        {
            _personPreset ??= new PersonPreset();

            _personPreset.GenerateParameters();
        }
    }
}
