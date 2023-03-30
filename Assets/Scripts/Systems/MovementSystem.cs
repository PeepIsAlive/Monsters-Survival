using Leopotam.Ecs;
using Components;

namespace Systems
{
    public sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<MovementComponent, DirectionComponent> _movementFilter;

        public void Run()
        {
            foreach (var i in _movementFilter)
            {

            }
        }
    }
}
