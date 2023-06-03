using Leopotam.Ecs;
using Components;

namespace Systems
{
    public sealed class EnemyAnimationSystem : IEcsRunSystem
    {
        private EcsFilter<EnemyComponent, AnimationComponent> _enemiesFilter;

        public void Run()
        {
            
        }
    }
}
