using System;

namespace Core
{
    public sealed class WorldGenerator
    {
        private string _id => Guid.NewGuid().ToString();

        public Character CreateCharacter()
        {
            return new Character(_id);
        }

        public Enemy CreateEnemy()
        {
            return new Enemy(_id);
        }
    }
}