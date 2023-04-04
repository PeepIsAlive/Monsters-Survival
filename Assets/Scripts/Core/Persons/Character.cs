namespace Core
{
    public sealed class Character : Person
    {
        public Character(string id) : base(id) { }

        public Character(string id, float speed) : base(id, speed)
        {

        }
    }
}
