namespace Core
{
    public sealed class Enemy : Person
    {
        public Enemy(string id) : base(id) { }

        public Enemy(string id, float speed) : base(id, speed)
        {

        }
    }
}
