using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace N64
{
    public struct Color
    {
        public byte R;
        public byte G;
        public byte B;
        public byte A;

        public Color(byte r, byte g, byte b, byte a = 0xFF)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public ushort ToRgba5551()
        {
            var r = R >> 3;
            var g = G >> 3;
            var b = B >> 3;
            var a = A >> 7;
            return (ushort)((r << 11) | (g << 6) | (b << 1) | a);
        }

        public uint ToRgba8888()
        {
            return (uint)((R << 24) | (G << 16) | (B << 8) | A);
        }

        public static Color FromRgba5551(ushort encoded)
        {
            var r = (encoded >> 11) & 0x1F;
            var g = (encoded >> 6) & 0x1F;
            var b = (encoded >> 1) & 0x1F;
            var a = (encoded) & 0x01;
            return new Color((byte)(r << 3 | r >> 2), (byte)(g << 3 | g >> 2), (byte)(b << 3 | b >> 2), (byte)(a > 0 ? 0xFF : 0x00));
        }

        public static Color FromRgba8888(uint encoded)
        {
            return new Color((byte)((encoded >> 24) & 0xFF), (byte)((encoded >> 16) & 0xFF), (byte)((encoded >> 8) & 0xFF), (byte)(encoded & 0xFF));
        }

        public void WriteRGBA8888To(Stream stream)
        {
            stream.WriteByte(R);
            stream.WriteByte(G);
            stream.WriteByte(B);
            stream.WriteByte(A);
        }
    }
}
