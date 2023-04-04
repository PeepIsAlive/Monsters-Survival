namespace Core
{
    public class Person : BaseObject
    {
        public float Speed { get; private set; }

        public Person(string id) : base(id) { }

        public Person(string id, float speed) : base(id)
        {
            Speed = speed;
        }
    }
}
