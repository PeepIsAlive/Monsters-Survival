using Core.Monobehaviour;
using Leopotam.Ecs;
using System.Linq;
using UnityEngine;
using Settings;
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
                    Vector2.zero,
                    isAutoExpand: true
                );
        }

        public void Run()
        {

        }
    }
}
