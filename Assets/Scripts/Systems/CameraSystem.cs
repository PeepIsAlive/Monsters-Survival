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
            foreach (var i in _cameraFilter)
            {
                foreach (var j in _characterFilter)
                {
                    _cameraFilter.Get1(i).Camera.Follow = _characterFilter.Get2(j).Transform;
                }
            }
        }

        public void Run()
        {

        }
    }
}
