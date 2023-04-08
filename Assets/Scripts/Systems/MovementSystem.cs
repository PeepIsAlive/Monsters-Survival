using Leopotam.Ecs;
using UnityEngine;
using Components;

namespace Systems
{
    public sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MovementComponent, DirectionComponent> _movementFilter;

        public void Run()
        {
            foreach (var i in _movementFilter)
            {
                var direction = _movementFilter.Get2(i).Direction;
                var controller = _movementFilter.Get1(i).Controller;

                var speed = 2f;

                controller.Move(direction * speed * Time.fixedDeltaTime);
            }
        }
    }
}
