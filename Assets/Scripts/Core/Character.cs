using Core.Interfaces;

namespace Core
{
    public sealed class Character : Person, IMovable, IRotable
    {
        public Character(string id) : base(id) { }

        public void Move()
        {
            
        }

        public void Rotate()
        {
            
        }
    }
}
