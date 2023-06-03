using UnityEngine;
using System;
using Core;

namespace Settings
{
    [Serializable]
    public sealed class ParameterSettings
    {
        [field: SerializeField] public ParameterType Type { get; private set; }
        [field: SerializeField] public FloatRange Range { get; private set; }
    }
}
