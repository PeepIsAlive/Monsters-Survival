namespace Core
{
    public class Person : BaseObject
    {
        public Parameters Parameters { get; private set; }
        public float Speed { get; private set; }

        public Person(string id) : base(id) { }

        public Person (string id, float speed, Parameters parameters = null) : base(id)
        {
            Speed = speed;
            Parameters = parameters != null ? parameters : new Parameters();
        }
    }
}