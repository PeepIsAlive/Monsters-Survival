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
            var enemy = _worldGenerator.CreateEnemy(e.EnemyMonobehaviour.Type, out var person);
            e.EnemyMonobehaviour.SetEnemy(enemy);

            _world.NewEntity().Replace(new ModelComponent
            {
                Transform = e.EnemyMonobehaviour.Transform
            })
            .Replace(new RotateComponent
            {
                Renderer = e.EnemyMonobehaviour.Renderer
            })
            .Replace(new DirectionComponent())
            .Replace(new PersonComponent
            {
                Person = person
            })
            .Replace(new EnemyComponent
            {
                Enemy = enemy,
            });

            e.EnemyMonobehaviour.gameObject.SetActive(true); // to do: del this
        }
    }
}
