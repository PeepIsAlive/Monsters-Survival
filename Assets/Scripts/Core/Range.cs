using UnityEngine;
using System;

namespace Core
{
    [Serializable]
    public sealed class Range
    {
        [field: SerializeField] public int Min { get; private set; }
        [field: SerializeField] public int Max { get; private set; }

        public Range(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public int GetRandom() => UnityEngine.Random.Range(Min, Max);
    }
}
