using UnityEngine;

namespace Core
{
    public sealed class Range
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        public Range(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public int GetRandom() => Random.Range(Min, Max);
    }
}
