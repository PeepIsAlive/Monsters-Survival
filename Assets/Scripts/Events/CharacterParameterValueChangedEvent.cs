using Core;

namespace Events
{
    public struct CharacterParameterValueChangedEvent
    {
        public ParameterType ParameterType;
        public float Value;
        public float PreviousValue;
    }
}
