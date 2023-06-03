using System.Threading.Tasks;
using System.Threading;
using Leopotam.Ecs;
using Components;

namespace Systems
{
    public sealed class RotateSystem : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        private EcsFilter<CharacterComponent, ModelComponent, DirectionComponent, RotateComponent> _characterFilter;
        private EcsFilter<EnemyComponent, ModelComponent, RotateComponent> _enemyFilter;

        private CancellationTokenSource _cancelSource;

        public void Init()
        {
            _cancelSource = new CancellationTokenSource();
        }

        public async void Run()
        {
            foreach (var i in _characterFilter)
            {
                var directionX = _characterFilter.Get3(i).Direction.x;

                if (directionX == 0f)
                    continue;

                _characterFilter.Get4(i).Renderer.flipX = directionX < 0f;
            }

            await RotateEnemies();
        }

        public void Destroy()
        {
            _cancelSource.Cancel();
        }

        private async Task RotateEnemies()
        {
            var task = new Task(() =>
            {
                foreach (var index in _enemyFilter)
                {
                    var enemyPosX = _enemyFilter.Get2(index).Transform.position.x;
                    var renderer = _enemyFilter.Get3(index).Renderer;

                    foreach (var i in _characterFilter)
                    {
                        var directionX = _characterFilter.Get3(i).Direction.x;
                        var characterPosX = _characterFilter.Get2(i).Transform.position.x;

                        renderer.flipX = characterPosX <= enemyPosX;
                    }
                }
            }, _cancelSource.Token);
            task.RunSynchronously();

            await task;
        }
    }
}
