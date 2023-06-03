using System.Collections.Generic;
using System;

namespace Core
{
    public readonly struct Vector2 : IEquatable<Vector2>
    {
        public readonly int X;
        public readonly int Y;

        private static double Sqrt = Math.Sqrt(2);

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        #region operators
        public static implicit operator Vector2(UnityEngine.Vector3 vector)
        {
            return new Vector2((int)vector.x, (int)vector.y);
        }

        public static implicit operator UnityEngine.Vector2(Vector2 vector)
        {
            return new UnityEngine.Vector2(vector.X, vector.Y);
        }

        public static implicit operator Vector2(UnityEngine.Vector2 vector)
        {
            return new Vector2((int)vector.x, (int)vector.y);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }

        public static bool operator ==(Vector2 a, Vector2 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Vector2 a, Vector2 b)
        {
            return !a.Equals(b);
        }
        #endregion

        public double DistanceEstimate()
        {
            int linearSteps = Math.Abs(Math.Abs(X) - Math.Abs(Y));
            int diagonalSteps = Math.Max(Math.Abs(X), Math.Abs(Y)) - linearSteps;

            return linearSteps + Sqrt * diagonalSteps;
        }

        public bool Equals(Vector2 other)
        {
            return other.X == X && other.Y == Y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector2))
                return false;

            return Equals((Vector2)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override string ToString()
        {
            return $"{X}, {Y}";
        }
    }
}
