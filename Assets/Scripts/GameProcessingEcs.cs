using Leopotam.Ecs;
using Voody.UniLeo;
using UnityEngine;
using Systems;
using Core;

namespace MonstersSurvival
{
    public sealed class GameProcessingEcs : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;
        private EcsSystems _fixedSystems;

        private void Awake()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _fixedSystems = new EcsSystems(_world);
        }

        private void Start()
        {
            AddSystems();
            AddFixedSystems();

            _systems.ConvertScene();
            _fixedSystems.ConvertScene();

            _systems.Init();
            _fixedSystems.Init();
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

        private void AddSystems()
        {
            _systems
                .Add(new CharacterInputSystem())
                .Add(new RotateSystem())
                .Add(new CharacterCreationSystem())
                .Inject(new WorldGenerator());
        }

        private void AddFixedSystems()
        {
            _fixedSystems
                .Add(new MovementSystem());
        }
    }
}
