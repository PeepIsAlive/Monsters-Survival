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
                var direction = _movementFilter.Get2(i);
                var movement = _movementFilter.Get1(i);

                movement.Rigidbody.velocity = direction.Direction;
            }
        }
    }
}
