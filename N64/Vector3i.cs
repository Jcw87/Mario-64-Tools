using System;
using System.Numerics;

namespace N64
{
    public readonly struct Vector3i : IEquatable<Vector3i>
    {
        public readonly int X;
        public readonly int Y;
        public readonly int Z;

        public Vector3i(int value) { X = value; Y = value; Z = value; }
        public Vector3i(int x, int y, int z) { X = x; Y = y; Z = z; }
        public Vector3i(in Vector3i v) { X = v.X; Y = v.Y; Z = v.Z; }
        public Vector3i(in Vector3 v) { X = (int)v.X; Y = (int)v.Y; Z = (int)v.Z; }

        public static readonly Vector3i Zero = new Vector3i(0, 0, 0);
        public static readonly Vector3i One = new Vector3i(1, 1, 1);
        public static readonly Vector3i UnitX = new Vector3i(1, 0, 0);
        public static readonly Vector3i UnitY = new Vector3i(0, 1, 0);
        public static readonly Vector3i UnitZ = new Vector3i(0, 0, 1);

        public static Vector3i Add(in Vector3i a, in Vector3i b) => new Vector3i(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vector3i Subtract(in Vector3i a, in Vector3i b) => new Vector3i(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static Vector3i Multiply(in Vector3i a, in Vector3i b) => new Vector3i(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        public static Vector3i Multiply(in Vector3i v, in int s) => new Vector3i(v.X * s, v.Y * s, v.Z * s);
        public static Vector3i Divide(in Vector3i a, in Vector3i b) => new Vector3i(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
        public static Vector3i Divide(in Vector3i v, int s) => new Vector3i(v.X / s, v.Y / s, v.Z / s);
        public static Vector3i Min(in Vector3i a, in Vector3i b) => new Vector3i(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y), Math.Min(a.Z, b.Z));
        public static Vector3i Max(in Vector3i a, in Vector3i b) => new Vector3i(Math.Max(a.X, b.X), Math.Max(a.Y, b.Y), Math.Max(a.Z, b.Z));
        public static Vector3i Clamp(in Vector3i v, in Vector3i min, in Vector3i max) => Max(Min(v, max), min);

        public static void Add(in Vector3i a, in Vector3i b, out Vector3i result) { result = new Vector3i(a.X + b.X, a.Y + b.Y, a.Z + b.Z); }
        public static void Subtract(in Vector3i a, in Vector3i b, out Vector3i result) { result = new Vector3i(a.X - b.X, a.Y - b.Y, a.Z - b.Z); }
        public static void Multiply(in Vector3i a, in Vector3i b, out Vector3i result) { result = new Vector3i(a.X * b.X, a.Y * b.Y, a.Z * b.Z); }
        public static void Multiply(in Vector3i v, int s, out Vector3i result) { result = new Vector3i(v.X * s, v.Y * s, v.Z * s); }
        public static void Divide(in Vector3i a, in Vector3i b, out Vector3i result) { result = new Vector3i(a.X / b.X, a.Y / b.Y, a.Z / b.Z); }
        public static void Divide(in Vector3i v, int s, out Vector3i result) { result = new Vector3i(v.X / s, v.Y / s, v.Z / s); }
        public static void Min(in Vector3i a, in Vector3i b, out Vector3i result) { result = new Vector3i(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y), Math.Min(a.Z, b.Z)); }
        public static void Max(in Vector3i a, in Vector3i b, out Vector3i result) { result = new Vector3i(Math.Max(a.X, b.X), Math.Max(a.Y, b.Y), Math.Max(a.Z, b.Z)); }
        public static void Clamp(in Vector3i v, in Vector3i min, in Vector3i max, out Vector3i result) { Min(v, max, out result); Max(v, min, out result); }

        public static Vector3i operator +(in Vector3i a, in Vector3i b) => new Vector3i(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vector3i operator -(in Vector3i a, in Vector3i b) => new Vector3i(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static Vector3i operator -(in Vector3i v) => new Vector3i(-v.X, -v.Y, -v.Z);
        public static Vector3i operator *(in Vector3i a, in Vector3i b) => new Vector3i(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        public static Vector3i operator *(Vector3i v, int s) => new Vector3i(v.X * s, v.Y * s, v.Z * s);
        public static Vector3i operator *(int s, Vector3i v) => new Vector3i(v.X * s, v.Y * s, v.Z * s);
        public static Vector3i operator /(in Vector3i a, in Vector3i b) => new Vector3i(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
        public static Vector3i operator /(Vector3i v, int s) => new Vector3i(v.X / s, v.Y / s, v.Z / s);
        public static bool operator ==(Vector3i a, Vector3i b) => a.Equals(b);
        public static bool operator !=(Vector3i a, Vector3i b) => !a.Equals(b);

        public int this[int idx]
        {
            get
            {
                if (idx == 0) return X;
                if (idx == 1) return Y;
                if (idx == 2) return Z;
                throw new IndexOutOfRangeException();
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Of(X).And(Y).And(Z);
        }

        public bool Equals(Vector3i other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector3i) return Equals((Vector3i)obj);
            return false;
        }

        public Vector3 ToVector3() => new Vector3(X, Y, Z);
    }
}
