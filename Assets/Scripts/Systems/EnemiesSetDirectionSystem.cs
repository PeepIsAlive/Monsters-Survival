using Leopotam.Ecs;
using Components;

namespace Systems
{
    public sealed class EnemiesSetDirectionSystem : IEcsRunSystem
    {
        private EcsFilter<EnemyComponent, DirectionComponent, ResetDirectionComponent> _enemiesFilter;

        public void Run()
        {
            foreach (var i in _enemiesFilter)
            {
                ref var directionComp = ref _enemiesFilter.Get2(i);
                var newDirection = _enemiesFilter.Get3(i).Direction;

                directionComp.Direction = newDirection;

                _enemiesFilter.GetEntity(i).Del<ResetDirectionComponent>();
            }
        }
    }
}
