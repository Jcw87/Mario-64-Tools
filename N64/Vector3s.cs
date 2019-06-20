using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64
{
    public struct Vector3s : IEquatable<Vector3s>
    {
        public short X;
        public short Y;
        public short Z;

        public Vector3s(short x, short y, short z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3s(int x, int y, int z)
        {
            X = (short)x;
            Y = (short)y;
            Z = (short)z;
        }

        public Vector3s(Vector3s v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        public short this[int idx]
        {
            get
            {
                if (idx == 0) return X;
                if (idx == 1) return Y;
                if (idx == 2) return Z;
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (idx == 0) X = value;
                if (idx == 1) Y = value;
                if (idx == 2) Z = value;
                throw new IndexOutOfRangeException();
            }
        }

        public static readonly Vector3s Zero = new Vector3s(0, 0, 0);

        public static Vector3s Add(Vector3s a, Vector3s b)
        {
            Add(ref a, ref b, out a);
            return a;
        }

        public static void Add(ref Vector3s a, ref Vector3s b, out Vector3s result)
        {
            result.X = (short)(a.X + b.X);
            result.Y = (short)(a.Y + b.Y);
            result.Z = (short)(a.Z + b.Z);
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

        public void WriteTo(Stream stream)
        {
            stream.WriteBE(X);
            stream.WriteBE(Y);
            stream.WriteBE(Z);
        }
    }
}
