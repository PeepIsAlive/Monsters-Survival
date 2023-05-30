using UnityEngine;
using System;
using Core;

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

        public Person GetPerson()
        {
            return new Person
                (
                    Guid.NewGuid().ToString(),
                    Speed
                );
        }
    }
}
