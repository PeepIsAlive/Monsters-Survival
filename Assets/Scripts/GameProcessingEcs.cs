using Leopotam.Ecs;
using UnityEngine;

namespace MonstersSurvival
{
    public sealed class GameProcessingEcs : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;
        private EcsSystems _fixedSystems;

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _fixedSystems = new EcsSystems(_world);
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void FixedUpdate()
        {
            _fixedSystems?.Run();
        }

        private void OnDestroy()
        {
            _world?.Destroy();
            _world = null;

            _systems?.Destroy();
            _systems = null;

            _fixedSystems?.Destroy();
            _fixedSystems = null;
        }
    }
}
