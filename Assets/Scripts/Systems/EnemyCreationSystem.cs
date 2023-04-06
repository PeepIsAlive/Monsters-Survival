using Leopotam.Ecs;
using Components;
using Events;
using Core;

namespace Systems
{
    public sealed class EnemyCreationSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private readonly EcsFilter<EnemyComponent> _enemyFilter;
        private readonly WorldGenerator _worldGenerator;

        public void Init()
        {
            EventSystem.Subscribe<EnemyCreationEvent>(CreateEnemy);
        }

        public void Destroy()
        {
            EventSystem.Unsubscribe<EnemyCreationEvent>(CreateEnemy);
        }

        private void CreateEnemy(EnemyCreationEvent e)
        {
            foreach (var i in _enemyFilter)
            {
                ref var component = ref _enemyFilter.Get1(i);

                component.Enemy = _worldGenerator.CreateEnemy();
            }
        }
    }
}
