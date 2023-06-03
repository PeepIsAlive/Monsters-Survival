using Core.Monobehaviour;
using Leopotam.Ecs;
using System.Linq;
using Settings;
using Events;
using Pools;
using Core;

namespace Systems
{
    public sealed class PoolEnemiesSystem : IEcsInitSystem, IEcsRunSystem
    {
        private PoolMonoBehaviour<EnemyMonobehaviour> _defaultEnemiesPool;

        public void Init()
        {
            var prefabSet = SettingsProvider.Load<PrefabSet>();
            var defaultEnemyPrefab = prefabSet.EnemiesPrefabs.First(x => x.Type == EnemyType.Default);

            _defaultEnemiesPool = new PoolMonoBehaviour<EnemyMonobehaviour>
                (
                    defaultEnemyPrefab,
                    new UnityEngine.Vector2(-21, 21),
                    isAutoExpand: true
                );

            SendEnemyCreationEvent();
        }

        public void Run()
        {

        }

        private void SendEnemyCreationEvent()
        {
            _defaultEnemiesPool.PoolObjects.ToList().ForEach(x =>
            {
                EventSystem.Send(new EnemyCreationEvent
                {
                    EnemyMonobehaviour = x,
                });
            });
        }
    }
}
