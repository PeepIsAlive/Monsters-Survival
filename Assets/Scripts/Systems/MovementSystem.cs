using Leopotam.Ecs;
using UnityEngine;
using Components;

namespace Systems
{
    public sealed class MovementSystem : IEcsRunSystem
    {
        private EcsFilter<CharacterMovementComponent, DirectionComponent, PersonComponent> _characterFilter;
        private EcsFilter<EnemyComponent, ModelComponent, DirectionComponent> _enemiesFilter;

        public void Run()
        {
            foreach (var i in _characterFilter)
            {
                var direction = _characterFilter.Get2(i).Direction;

                if (direction == Vector2.zero)
                    continue;

                var controller = _characterFilter.Get1(i).Controller;
                var speed = _characterFilter.Get3(i).Person.Speed;

                controller.Move(direction * speed * Time.fixedDeltaTime);
            }
        }
    }
}
