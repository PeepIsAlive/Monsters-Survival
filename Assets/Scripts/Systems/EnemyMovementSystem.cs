using System.Threading.Tasks;
using System.Threading;
using Leopotam.Ecs;
using UnityEngine;
using Components;

namespace Systems
{
    public sealed class EnemyMovementSystem : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        private EcsFilter<CharacterMovementComponent, ModelComponent> _characterFilter;
        private EcsFilter<EnemyComponent, ModelComponent, DirectionComponent> _enemiesFilter;

        private CancellationTokenSource _cancelSource;

        public void Init()
        {
            _cancelSource = new CancellationTokenSource();
        }

        public async void Run()
        {
            await MoveEnemies();
        }

        public void Destroy()
        {
            _cancelSource.Cancel();
        }

        private async Task MoveEnemies()
        {
            var task = new Task(() =>
            {
                foreach (var j in _characterFilter)
                {
                    var characterTransform = _characterFilter.GetEntity(j).Get<ModelComponent>().Transform;

                    foreach (var i in _enemiesFilter)
                    {
                        var enemyTransform = _enemiesFilter.Get2(i).Transform;
                        var enemy = _enemiesFilter.Get1(i).Enemy;

                        if (Vector2.Distance(enemyTransform.position, characterTransform.position) > 1f)
                        {
                            enemyTransform.position =
                                Vector2.MoveTowards(enemyTransform.position, characterTransform.position, enemy.Speed * Time.fixedDeltaTime);
                        }
                    }
                }
            });
            task.RunSynchronously();

            await task;
        }
    }
}
