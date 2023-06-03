using Leopotam.Ecs;
using Components;
using Core;

namespace Systems
{
    public sealed class HealthSystem : IEcsRunSystem
    {
        private EcsFilter<PersonComponent, HealthDecComponent>.Exclude<HealthIncComponent> _healthDecFilter;
        private EcsFilter<PersonComponent, HealthIncComponent>.Exclude<HealthDecComponent> _healthIncFilter;

        public void Run()
        {
            foreach (var i in _healthDecFilter)
            {
                var person = _healthDecFilter.Get1(i).Person;
                var decValue = _healthDecFilter.Get2(i).Value;

                person.Parameters.Get(ParameterType.Health).Dec(decValue);
            }

            foreach (var i in _healthIncFilter)
            {
                var person = _healthIncFilter.Get1(i).Person;
                var incValue = _healthIncFilter.Get2(i).Value;

                person.Parameters.Get(ParameterType.Health).Inc(incValue);
            }
        }
    }
}
