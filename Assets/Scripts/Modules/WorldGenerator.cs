using Settings;
using System;
using Core;

namespace Modules
{
    public sealed class WorldGenerator
    {
        private CharacterCreationSettings _characterCreationSettings;
        private EnemyCreationSettings _enemyCreationSettings;

        public Character CreateCharacter(out Person person)
        {
            _characterCreationSettings ??= SettingsProvider.Load<CharacterCreationSettings>();
            var character = _characterCreationSettings.GetCharacter();

            person = character;

            return character;
        }

        public Enemy CreateEnemy(EnemyType type, out Person person)
        {
            _enemyCreationSettings ??= SettingsProvider.Load<EnemyCreationSettings>();
            var enemy = _enemyCreationSettings.GetEnemy(type);

            person = enemy;

            return enemy;
        }
    }
}