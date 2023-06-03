using UnityEngine;
using Core;

namespace Settings
{
    [CreateAssetMenu(fileName = "CharacterCreationSettings", menuName = "Settings/Creation/CharacterCreationSettings", order = 0)]
    public sealed class CharacterCreationSettings : ScriptableObject
    {
        [SerializeField] private CharacterPreset _preset;

        public Character GetCharacter()
        {
            return _preset.GetCharacter();
        }
    }
}