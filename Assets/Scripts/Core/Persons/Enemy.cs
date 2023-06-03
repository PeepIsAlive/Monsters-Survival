namespace Core
{
    public sealed class Enemy : Person
    {
        public EnemyType Type { get; private set; }

        public Enemy(string id) : base(id) { }

        public Enemy(string id, float speed, EnemyType type) : base(id, speed)
        {
            Type = type;
        }
    }
}
