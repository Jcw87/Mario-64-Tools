using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Jcw87.IO;

namespace N64
{
    public enum TextureFormat
    {
        RGBA8888,
        RGBA5551,
        IA88,
        IA44,
        IA31,
        I8,
        I4,
    }

    public class Texture
    {
        public int Width { get; }
        public int Height { get; }
        public TextureFormat Format { get; }
        public int BitsPerPixel { get; }
        public byte[] Pixels { get; }

        public Texture(int width, int height, TextureFormat format)
        {
            Width = width;
            Height = height;
            Format = format;
            switch (Format)
            {
                case TextureFormat.RGBA8888: BitsPerPixel = 32; break;
                case TextureFormat.RGBA5551:
                case TextureFormat.IA88: BitsPerPixel = 16; break;
                case TextureFormat.IA44:
                case TextureFormat.I8: BitsPerPixel =  8; break;
                case TextureFormat.IA31:
                case TextureFormat.I4: BitsPerPixel =  4; break;
                default: throw new NotImplementedException();
            }
            var size = Width * Height * BitsPerPixel / 8;
            Pixels = new byte[size];
        }

        private byte GetPixel4(int index, bool even)
        {
            return (byte)(even ? Pixels[index] >> 4 : Pixels[index] & 0x0F);
        }

        public Color GetPixel(int x, int y)
        {
            if (x < 0 || x >= Width) throw new ArgumentException("Invalid range", "x");
            if (y < 0 || y >= Height) throw new ArgumentException("Invalid range", "y");
            var pixelnum = (y * Width + x);
            var index = pixelnum * BitsPerPixel / 8;
            switch (Format)
            {
                case TextureFormat.RGBA8888:
                    return Color.FromRgba8888(Pixels.ReadUInt32BE(index));
                case TextureFormat.RGBA5551:
                    return Color.FromRgba5551(Pixels.ReadUInt16BE(index));
                case TextureFormat.IA88:
                    return Color.FromIA88(Pixels.ReadUInt16BE(index));
                case TextureFormat.IA44:
                    return Color.FromIA44(Pixels[index]);
                case TextureFormat.I8:
                    return Color.FromI8(Pixels[index]);
                case TextureFormat.IA31:
                    return Color.FromIA31(GetPixel4(index, pixelnum % 2 == 0));
                case TextureFormat.I4:
                    return Color.FromI4(GetPixel4(index, pixelnum % 2 == 0));
                default: throw new NotImplementedException();
            }
        }

        private void SetPixel4(int index, bool even, byte c)
        {
            Pixels[index] = (byte)(even ? (Pixels[index] & 0x0F) | (c << 4) : (Pixels[index] & 0xF0) | c);
        }

        public void SetPixel(int x, int y, Color color)
        {
            if (x < 0 || x >= Width) throw new ArgumentException("Invalid range", "x");
            if (y < 0 || y >= Height) throw new ArgumentException("Invalid range", "y");
            var pixelnum = (y * Width + x);
            var index = pixelnum * BitsPerPixel / 8;
            switch (Format)
            {
                case TextureFormat.RGBA8888: Pixels.WriteBE(index, color.ToRgba8888()); break;
                case TextureFormat.RGBA5551: Pixels.WriteBE(index, color.ToRgba5551()); break;
                case TextureFormat.IA88: Pixels.WriteBE(index, color.ToIA88()); break;
                case TextureFormat.IA44: Pixels[index] = color.ToIA44(); break;
                case TextureFormat.I8: Pixels[index] = color.ToI8(); break;
                case TextureFormat.IA31: SetPixel4(index, pixelnum % 2 == 0, color.ToIA31()); break;
                case TextureFormat.I4: SetPixel4(index, pixelnum % 2 == 0, color.ToI4()); break;
                default: throw new NotImplementedException();
            }
        }
    }
}
