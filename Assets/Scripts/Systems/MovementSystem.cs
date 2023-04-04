using Leopotam.Ecs;
using UnityEngine;
using Components;

namespace Systems
{
    public sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<PersonComponent, MovementComponent, DirectionComponent> _movementFilter;

        public void Run()
        {
            foreach (var i in _movementFilter)
            {
                var direction = _movementFilter.Get3(i).Direction;
                var controller = _movementFilter.Get2(i).Controller;
                //var speed = _movementFilter.Get1(i).Person.Speed;

                var speed = 2f;

                controller.Move(direction * speed * Time.fixedDeltaTime);
            }
        }
    }
}
