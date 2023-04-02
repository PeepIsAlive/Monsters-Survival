using Leopotam.Ecs;
using Components;
using Events;

namespace Systems
{
    public sealed class CharacterCreationSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<CharacterComponent> _characterFilter;

        public void Init()
        {
            EventSystem.Subscribe<CharacterCreationEvent>(CreateCharacter);
        }

        public void Destroy()
        {
            EventSystem.Unsubscribe<CharacterCreationEvent>(CreateCharacter);
        }

        private void CreateCharacter(CharacterCreationEvent e)
        {
            foreach (var i in _characterFilter)
            {
                UnityEngine.Debug.Log("create character");
            }
        }
    }
}
