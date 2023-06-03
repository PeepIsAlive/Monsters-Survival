using UnityEngine;
using System;

namespace Core
{
    public sealed class Parameter
    {
        public event Action<float, float> OnValueChanged;

        public FloatRange Range { get; private set; }
        public float PreviousValue { get; private set; }
        public float Value { get; private set; }


        public Parameter(float value, FloatRange range)
        {
            Value = Mathf.Clamp(value, range.Min, range.Max);
            PreviousValue = value;
            Range = range;
        }

        public void Inc(float value)
        {
            if (Value == Range.Max)
                return;

            PreviousValue = Value;
            Value += value;
            Value = Mathf.Clamp(Value, Range.Min, Range.Max);

            OnValueChanged?.Invoke(Value, PreviousValue);
        }

        public void Dec(float value)
        {
            if (Value == Range.Min)
                return;

            Value -= value;
            Value = Mathf.Clamp(Value, Range.Min, Range.Max);

            OnValueChanged?.Invoke(Value, PreviousValue);
        }
    }
}
