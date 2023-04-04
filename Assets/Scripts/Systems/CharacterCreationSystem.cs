using Leopotam.Ecs;
using Components;
using System;
using Events;
using Core;

namespace Systems
{
    public sealed class CharacterCreationSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private readonly EcsFilter<CharacterComponent> _characterFilter;

        private readonly string _id = Guid.NewGuid().ToString();

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
                ref var component = ref _characterFilter.Get1(i);

                component.Character = new Character(_id);
            }
        }
    }
}
