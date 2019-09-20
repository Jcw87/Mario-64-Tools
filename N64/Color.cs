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

        public uint ToRgba8888()
        {
            return (uint)((R << 24) | (G << 16) | (B << 8) | A);
        }

        public ushort ToRgba5551()
        {
            var r = R >> 3;
            var g = G >> 3;
            var b = B >> 3;
            var a = A >> 7;
            return (ushort)((r << 11) | (g << 6) | (b << 1) | a);
        }

        public ushort ToIA88()
        {
            var i = ToI8();
            return (ushort)((i << 8) | A);
        }

        public byte ToIA44()
        {
            var i = ToI4();
            var a = A >> 4;
            return (byte)((i << 4) | a);
        }

        public byte ToIA31()
        {
            var i = ToI8() >> 5;
            var a = A >> 7;
            return (byte)((i << 1) | a);
        }

        public byte ToI8()
        {
            return (byte)((R + G + B) / 3);
        }

        public byte ToI4()
        {
            return (byte)(ToI8() >> 4);
        }

        public static Color FromRgba8888(uint encoded)
        {
            return new Color((byte)((encoded >> 24) & 0xFF), (byte)((encoded >> 16) & 0xFF), (byte)((encoded >> 8) & 0xFF), (byte)(encoded & 0xFF));
        }

        public static Color FromRgba5551(ushort encoded)
        {
            var r = (encoded >> 11) & 0x1F;
            var g = (encoded >> 6) & 0x1F;
            var b = (encoded >> 1) & 0x1F;
            var a = (encoded) & 0x01;
            return new Color((byte)(r << 3 | r >> 2), (byte)(g << 3 | g >> 2), (byte)(b << 3 | b >> 2), (byte)(a > 0 ? 0xFF : 0x00));
        }

        public static Color FromIA88(ushort encoded)
        {
            var i = (byte)((encoded >> 8) & 0xFF);
            var a = (byte)(encoded & 0xFF);
            return new Color(i, i, i, a);
        }

        public static Color FromIA44(byte encoded)
        {
            var i = (encoded >> 4) & 0x0F;
            var a = encoded & 0x0F;
            var i2 = (byte)(i << 4 | i);
            var a2 = (byte)(a << 4 | a);
            return new Color(i2, i2, i2, a2);
        }

        public static Color FromIA31(byte encoded)
        {
            var i = (encoded >> 1) & 0x07;
            var a = encoded & 0x01;
            var i2 = (byte)(i << 5 | i << 2 | i >> 1);
            var a2 = (byte)(a > 0 ? 0xFF : 0x00);
            return new Color(i2, i2, i2, a2);
        }

        public static Color FromI8(byte encoded)
        {
            return new Color(encoded, encoded, encoded, 0xFF);
        }

        public static Color FromI4(byte encoded)
        {
            var i = (byte)((encoded << 4) | encoded);
            return new Color(i, i, i, 0xFF);
        }
    }
}
