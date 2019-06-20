using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.F3D
{
    public struct Vertex
    {
        public Vector3s Position;
        public short U;
        public short V;
        public Color Color;

        public void WriteTo(Stream stream)
        {
            Position.WriteTo(stream);
            stream.WriteByte(0);
            stream.WriteByte(0);
            stream.WriteBE(U);
            stream.WriteBE(V);
            Color.WriteRGBA8888To(stream);
        }
    }
}
