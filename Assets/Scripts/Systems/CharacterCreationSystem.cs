using Leopotam.Ecs;
using Components;
using Events;

namespace Systems
{
    public sealed class CharacterCreationSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private readonly EcsFilter<CharacterComponent, PersonComponent> _characterFilter;
        private readonly WorldGenerator _worldGenerator;

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
                ref var character = ref _characterFilter.Get1(i).Character;
                ref var person = ref _characterFilter.Get2(i).Person;

                character = _worldGenerator.CreateCharacter(out person);
            }
        }
    }
}
