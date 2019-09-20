using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace N64
{
    public readonly struct Vector3s : IEquatable<Vector3s>
    {
        public readonly short X;
        public readonly short Y;
        public readonly short Z;

        public Vector3s(short value) { X = value; Y = value; Z = value; }
        public Vector3s(short x, short y, short z) { X = x; Y = y; Z = z; }
        public Vector3s(int x, int y, int z) { X = (short)x; Y = (short)y; Z = (short)z; }
        public Vector3s(in Vector3s v) { X = v.X; Y = v.Y; Z = v.Z; }
        public Vector3s(in Vector3 v) { X = (short)v.X; Y = (short)v.Y; Z = (short)v.Z; }

        public static readonly Vector3s Zero = new Vector3s(0, 0, 0);
        public static readonly Vector3s One = new Vector3s(1, 1, 1);
        public static readonly Vector3s UnitX = new Vector3s(1, 0, 0);
        public static readonly Vector3s UnitY = new Vector3s(0, 1, 0);
        public static readonly Vector3s UnitZ = new Vector3s(0, 0, 1);

        public static Vector3s Add(in Vector3s a, in Vector3s b) => new Vector3s(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vector3s Subtract(in Vector3s a, in Vector3s b) => new Vector3s(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static Vector3s Multiply(in Vector3s a, in Vector3s b) => new Vector3s(a.X* b.X, a.Y* b.Y, a.Z* b.Z);
        public static Vector3s Multiply(in Vector3s v, in short s) => new Vector3s(v.X * s, v.Y * s, v.Z * s);
        public static Vector3s Divide(in Vector3s a, in Vector3s b) => new Vector3s(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
        public static Vector3s Divide(in Vector3s v, short s) => new Vector3s(v.X / s, v.Y / s, v.Z / s);
        public static Vector3s Min(in Vector3s a, in Vector3s b) => new Vector3s(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y), Math.Min(a.Z, b.Z));
        public static Vector3s Max(in Vector3s a, in Vector3s b) => new Vector3s(Math.Max(a.X, b.X), Math.Max(a.Y, b.Y), Math.Max(a.Z, b.Z));
        public static Vector3s Clamp(in Vector3s v, in Vector3s min, in Vector3s max) => Max(Min(v, max), min);

        public static void Add(in Vector3s a, in Vector3s b, out Vector3s result) { result = new Vector3s(a.X + b.X, a.Y + b.Y, a.Z + b.Z); }
        public static void Subtract(in Vector3s a, in Vector3s b, out Vector3s result) { result = new Vector3s(a.X - b.X, a.Y - b.Y, a.Z - b.Z); }
        public static void Multiply(in Vector3s a, in Vector3s b, out Vector3s result) { result = new Vector3s(a.X * b.X, a.Y * b.Y, a.Z * b.Z); }
        public static void Multiply(in Vector3s v, short s, out Vector3s result) { result = new Vector3s(v.X * s, v.Y * s, v.Z * s); }
        public static void Divide(in Vector3s a, in Vector3s b, out Vector3s result) { result = new Vector3s(a.X / b.X, a.Y / b.Y, a.Z / b.Z); }
        public static void Divide(in Vector3s v, short s, out Vector3s result) { result = new Vector3s(v.X / s, v.Y / s, v.Z / s); }
        public static void Min(in Vector3s a, in Vector3s b, out Vector3s result) { result = new Vector3s(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y), Math.Min(a.Z, b.Z)); }
        public static void Max(in Vector3s a, in Vector3s b, out Vector3s result) { result = new Vector3s(Math.Max(a.X, b.X), Math.Max(a.Y, b.Y), Math.Max(a.Z, b.Z)); }
        public static void Clamp(in Vector3s v, in Vector3s min, in Vector3s max, out Vector3s result) { Min(v, max, out result); Max(v, min, out result); }

        public static Vector3s operator +(in Vector3s a, in Vector3s b) => new Vector3s(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vector3s operator -(in Vector3s a, in Vector3s b) => new Vector3s(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static Vector3s operator -(in Vector3s v) => new Vector3s(-v.X, -v.Y, -v.Z);
        public static Vector3s operator *(in Vector3s a, in Vector3s b) => new Vector3s(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        public static Vector3s operator *(Vector3s v, short s) => new Vector3s(v.X * s, v.Y * s, v.Z * s);
        public static Vector3s operator *(short s, Vector3s v) => new Vector3s(v.X * s, v.Y * s, v.Z * s);
        public static Vector3s operator /(in Vector3s a, in Vector3s b) => new Vector3s(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
        public static Vector3s operator /(Vector3s v, short s) => new Vector3s(v.X / s, v.Y / s, v.Z / s);
        public static bool operator ==(Vector3s a, Vector3s b) => a.Equals(b);
        public static bool operator !=(Vector3s a, Vector3s b) => !a.Equals(b);

        public short this[int idx]
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

        public bool Equals(Vector3s other)
        {
            if (X != other.X) return false;
            if (Y != other.Y) return false;
            if (Z != other.Z) return false;
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector3s) return Equals((Vector3s)obj);
            return false;
        }
    }
}
