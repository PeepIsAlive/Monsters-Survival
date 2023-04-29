using Settings;
using System;
using Core;

namespace Modules
{
    public sealed class WorldGenerator
    {
        private string _id => Guid.NewGuid().ToString();

        public Character CreateCharacter(out Person person)
        {
            var creationSettings = SettingsProvider.Load<CharacterCreationSettings>();
            var character = creationSettings.GetCharacter();

            person = creationSettings.GetPerson();

            return character;
        }

        public Enemy CreateEnemy()
        {
            return new Enemy(_id);
        }
    }
}