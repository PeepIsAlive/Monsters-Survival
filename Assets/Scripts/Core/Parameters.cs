using System.Collections.Generic;
using Settings;
using System;

namespace Core
{
    public sealed class Parameters
    {
        public event Action<ParameterType, float, float> OnParamerValueChanged;

        private Dictionary<ParameterType, Parameter> _parameters;

        public Parameters(List<ParameterSettings> parameterSettings = null)
        {
            _parameters = new Dictionary<ParameterType, Parameter>();

            if (parameterSettings != null)
            {
                parameterSettings.ForEach(x =>
                {
                    Add(x.Type, new Parameter(x.Range.Max, x.Range));
                });
            }
        }

        public void Add(ParameterType type, Parameter parameter)
        {
            if (_parameters.ContainsKey(type))
                return;

            _parameters.Add(type, parameter);
            _parameters[type].OnValueChanged += (value, previousValue) =>
            {
                OnParamerValueChanged?.Invoke(type, value, previousValue);
            };
        }

        public void Remove(ParameterType type)
        {
            if (!_parameters.ContainsKey(type))
                return;

            _parameters.Remove(type);
            _parameters[type].OnValueChanged -= (value, previousValue) =>
            {
                OnParamerValueChanged?.Invoke(type, value, previousValue);
            };
        }

        public Parameter Get(ParameterType type)
        {
            _parameters.TryGetValue(type, out var parameter);

            return parameter;
        }
    }
}
