using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace N64
{
    public class Triangle3s
    {
        public readonly Vector3s[] Vertices;
        public Vector3 Normal { get; private set; }
        public float OriginOffset { get; private set; }
        public Triangle3s() { Vertices = new Vector3s[3]; }
        public Triangle3s(Vector3s a, Vector3s b, Vector3s c) { Vertices = new Vector3s[] { a, b, c }; }

        public void Recalculate()
        {
            Normal = Vector3.Normalize(Vector3s.Cross(Vertices[1] - Vertices[0], Vertices[2] - Vertices[1]).ToVector3());
            OriginOffset = -Vector3.Dot(Vertices[0].ToVector3(), Normal);
        }

        public bool PointInside(Vector3s pos)
        {
            var p = pos.Xz;
            var a = Vertices[0].Xz;
            var b = Vertices[1].Xz;
            var c = Vertices[2].Xz;

            if (Vector2s.PerpDot(a - p, b - a) < 0) return false;
            if (Vector2s.PerpDot(b - p, c - b) < 0) return false;
            if (Vector2s.PerpDot(c - p, a - c) < 0) return false;
            return true;
        }

        public float HeightAt(Vector3s pos)
        {
            return -(pos.X * Normal.X + Normal.Z * pos.Z + OriginOffset) / Normal.Y;
        }

        public bool IsFloor() => Normal.Y > 0;
        public bool IsWall() => Normal.Y == 0;
        public bool IsCeiling() => Normal.Y < 0;
    }
}
