using Leopotam.Ecs;
using Components;
using System;
using Events;
using Core;

namespace Systems
{
    public sealed class EnemyCreationSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private readonly EcsFilter<EnemyComponent> _enemyFilter;

        private string _id => Guid.NewGuid().ToString();

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

                component.Enemy = new Enemy(_id);
            }
        }
    }
}
