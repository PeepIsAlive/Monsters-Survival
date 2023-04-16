using UnityEngine;
using System;
using Core;

namespace Settings
{
    [Serializable]
    public sealed class PersonPreset
    {
        [SerializeField] private float _speed;

        public void GenerateParameters()
        {
            _speed = UnityEngine.Random.Range(2f, 10f);
        }

        public Person GetPerson()
        {
            return new Person
                (
                    Guid.NewGuid().ToString(),
                    _speed
                );
        }
    }
}
