using Leopotam.Ecs;
using Components;
using Modules;
using Events;

namespace Systems
{
    public sealed class EnemyCreationSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private readonly EcsWorld _world;
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
            var enemy = _worldGenerator.CreateEnemy();

            e.EnemyMonobehaviour.SetEnemy(enemy);
            _world.NewEntity().Replace(new EnemyComponent
            {
                Enemy = enemy
            });
        }
    }
}
