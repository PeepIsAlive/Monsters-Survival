using Leopotam.Ecs;
using UnityEngine;
using Components;

namespace Systems
{
    public sealed class CharacterInputSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter<CharacterComponent, DirectionComponent> _directionFilter;
        private CharacterInput _characterInput;

        private Vector2 _direction => _characterInput.Character.Move.ReadValue<Vector2>();

        public void Init()
        {
            InitializeInput();
        }

        public void Run()
        {
            if (_characterInput == null)
                return;

            foreach (var i in _directionFilter)
            {
                _directionFilter.Get2(i).Direction = _direction;
            }
        }

        private void InitializeInput()
        {
            _characterInput = new CharacterInput();
            _characterInput.Enable();
        }
    }
}
