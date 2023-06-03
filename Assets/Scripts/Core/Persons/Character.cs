using Systems;
using Events;

namespace Core
{
    public sealed class Character : Person
    {
        public Character(string id) : base(id) { }

        public Character(string id, float speed, Parameters parameters)
            : base(id, speed, parameters)
        {
            parameters.OnParamerValueChanged += SendParameterChangedEvent;
        }

        private void SendParameterChangedEvent(ParameterType type, float value, float previousValue)
        {
            EventSystem.Send(new CharacterParameterValueChangedEvent
            {
                ParameterType = type,
                Value = value,
                PreviousValue = previousValue
            });
        }
    }
}
