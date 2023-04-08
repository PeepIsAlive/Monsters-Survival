using Leopotam.Ecs;
using Components;

namespace Systems
{
    public sealed class RotateSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CharacterComponent, DirectionComponent, RotateComponent> _characterFilter;

        public void Run()
        {
            foreach (var i in _characterFilter)
            {
                var directionX = _characterFilter.Get2(i).Direction.x;

                if (directionX == 0f)
                    return;

                _characterFilter.Get3(i).Renderer.flipX = directionX < 0f;
            }
        }
    }
}
