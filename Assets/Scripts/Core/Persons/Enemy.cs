namespace Core
{
    public sealed class Enemy : Person
    {
        public EnemyType Type { get; private set; }
        public int DamageAmount { get; private set; }

        public Enemy(string id) : base(id) { }

        public Enemy(string id, float speed, int damageAmount, EnemyType type, Parameters parameters)
            : base(id, speed, parameters)
        {
            DamageAmount = damageAmount;
            Type = type;
        }
    }
}
