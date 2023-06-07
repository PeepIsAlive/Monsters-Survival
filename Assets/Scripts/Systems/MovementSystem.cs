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

                var rigidbody = _characterFilter.Get1(i).Rigidbody;
                var speed = _characterFilter.Get3(i).Person.Speed;
                //_characterFilter.Get4(i).Transform.Translate

                rigidbody.position += direction * speed * Time.fixedDeltaTime;
            }
        }
    }
}
