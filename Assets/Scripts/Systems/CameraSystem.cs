using Leopotam.Ecs;
using Components;

namespace Systems
{
    public sealed class CameraSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter<CameraComponent> _cameraFilter;
        private EcsFilter<CharacterComponent, ModelComponent> _characterFilter;

        public void Init()
        {

        }

        public void Run()
        {

        }
    }
}
