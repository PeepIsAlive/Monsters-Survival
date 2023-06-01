using UnityEngine;
using System;

namespace Settings
{
    [Serializable]
    public sealed class PersonPreset
    {
        [field: SerializeField] public float Speed { get; private set; }

        public void GenerateParameters()
        {
            Speed = UnityEngine.Random.Range(2f, 10f);
        }
    }
}
