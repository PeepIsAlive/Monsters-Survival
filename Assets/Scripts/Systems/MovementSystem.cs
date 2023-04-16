using Leopotam.Ecs;
using UnityEngine;
using Components;

namespace Systems
{
    public sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MovementComponent, DirectionComponent, PersonComponent> _movementFilter;

        public void Run()
        {
            foreach (var i in _movementFilter)
            {
                var direction = _movementFilter.Get2(i).Direction;

                if (direction == Vector2.zero)
                    continue;

                var controller = _movementFilter.Get1(i).Controller;
                var speed = _movementFilter.Get3(i).Person.Speed;

                controller.Move(direction * speed * Time.fixedDeltaTime);
            }
        }
    }
}
