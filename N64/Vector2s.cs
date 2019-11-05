using System;
using System.Numerics;

namespace N64
{
    public readonly struct Vector2s : IEquatable<Vector2s>
    {
        public readonly short X;
        public readonly short Y;

        public Vector2s(short value) { X = value; Y = value; }
        public Vector2s(short x, short y) { X = x; Y = y; }
        public Vector2s(int x, int y) { X = (short)x; Y = (short)y; }
        public Vector2s(in Vector2s v) { X = v.X; Y = v.Y; }
        public Vector2s(in Vector2 v) { X = (short)v.X; Y = (short)v.Y; }

        public static readonly Vector2s Zero = new Vector2s(0, 0);
        public static readonly Vector2s One = new Vector2s(1, 1);
        public static readonly Vector2s UnitX = new Vector2s(1, 0);
        public static readonly Vector2s UnitY = new Vector2s(0, 1);

        public static Vector2s Add(in Vector2s a, in Vector2s b) => new Vector2s(a.X + b.X, a.Y + b.Y);
        public static Vector2s Subtract(in Vector2s a, in Vector2s b) => new Vector2s(a.X - b.X, a.Y - b.Y);
        public static Vector2s Multiply(in Vector2s a, in Vector2s b) => new Vector2s(a.X * b.X, a.Y * b.Y);
        public static Vector2s Multiply(in Vector2s v, in short s) => new Vector2s(v.X * s, v.Y * s);
        public static Vector2s Divide(in Vector2s a, in Vector2s b) => new Vector2s(a.X / b.X, a.Y / b.Y);
        public static Vector2s Divide(in Vector2s v, short s) => new Vector2s(v.X / s, v.Y / s);
        public static Vector2s Min(in Vector2s a, in Vector2s b) => new Vector2s(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y));
        public static Vector2s Max(in Vector2s a, in Vector2s b) => new Vector2s(Math.Max(a.X, b.X), Math.Max(a.Y, b.Y));
        public static Vector2s Clamp(in Vector2s v, in Vector2s min, in Vector2s max) => Max(Min(v, max), min);
        public static int Dot(in Vector2s a, in Vector2s b) => a.X * b.X + a.Y * b.Y;
        public static int PerpDot(in Vector2s a, in Vector2s b) => a.Y * b.X - a.X * b.Y;

        public static void Add(in Vector2s a, in Vector2s b, out Vector2s result) { result = new Vector2s(a.X + b.X, a.Y + b.Y); }
        public static void Subtract(in Vector2s a, in Vector2s b, out Vector2s result) { result = new Vector2s(a.X - b.X, a.Y - b.Y); }
        public static void Multiply(in Vector2s a, in Vector2s b, out Vector2s result) { result = new Vector2s(a.X * b.X, a.Y * b.Y); }
        public static void Multiply(in Vector2s v, short s, out Vector2s result) { result = new Vector2s(v.X * s, v.Y * s); }
        public static void Divide(in Vector2s a, in Vector2s b, out Vector2s result) { result = new Vector2s(a.X / b.X, a.Y / b.Y); }
        public static void Divide(in Vector2s v, short s, out Vector2s result) { result = new Vector2s(v.X / s, v.Y / s); }
        public static void Min(in Vector2s a, in Vector2s b, out Vector2s result) { result = new Vector2s(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y)); }
        public static void Max(in Vector2s a, in Vector2s b, out Vector2s result) { result = new Vector2s(Math.Max(a.X, b.X), Math.Max(a.Y, b.Y)); }
        public static void Clamp(in Vector2s v, in Vector2s min, in Vector2s max, out Vector2s result) { Min(v, max, out result); Max(v, min, out result); }
        public static void Dot(in Vector2s a, in Vector2s b, out int result) { result = a.X * b.X + a.Y * b.Y; }
        public static void PerpDot(in Vector2s a, in Vector2s b, out int result) { result = a.Y * b.X - a.X * b.Y; }

        public static Vector2s operator +(in Vector2s a, in Vector2s b) => new Vector2s(a.X + b.X, a.Y + b.Y);
        public static Vector2s operator -(in Vector2s a, in Vector2s b) => new Vector2s(a.X - b.X, a.Y - b.Y);
        public static Vector2s operator -(in Vector2s v) => new Vector2s(-v.X, -v.Y);
        public static Vector2s operator *(in Vector2s a, in Vector2s b) => new Vector2s(a.X * b.X, a.Y * b.Y);
        public static Vector2s operator *(Vector2s v, short s) => new Vector2s(v.X * s, v.Y * s);
        public static Vector2s operator *(short s, Vector2s v) => new Vector2s(v.X * s, v.Y * s);
        public static Vector2s operator /(in Vector2s a, in Vector2s b) => new Vector2s(a.X / b.X, a.Y / b.Y);
        public static Vector2s operator /(Vector2s v, short s) => new Vector2s(v.X / s, v.Y / s);
        public static bool operator ==(Vector2s a, Vector2s b) => a.Equals(b);
        public static bool operator !=(Vector2s a, Vector2s b) => !a.Equals(b);

        public short this[int idx]
        {
            get
            {
                if (idx == 0) return X;
                if (idx == 1) return Y;
                throw new IndexOutOfRangeException();
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Of(X).And(Y);
        }

        public bool Equals(Vector2s other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2s) return Equals((Vector2s)obj);
            return false;
        }
    }
}
