using Leopotam.Ecs;
using UnityEngine;
using Components;

namespace Systems
{
    public sealed class CharacterAnimationSystem : IEcsRunSystem
    {
        private EcsFilter<CharacterComponent, AnimationComponent, DirectionComponent> _characterFilter;

        private const string DIRECTION_MAGNITUDE = "DirectionMagnitude";

        public void Run()
        {
            foreach (var i in _characterFilter)
            {
                var direction = _characterFilter.Get3(i).Direction;
                var animator = _characterFilter.Get2(i).Animator;

                animator.SetFloat(DIRECTION_MAGNITUDE, Mathf.Abs(direction.magnitude));
            }
        }
    }
}
