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
        private Stream PixelStream { get; set; }

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
            PixelStream = new MemoryStream(Pixels);
        }

        public Color GetPixel(int x, int y)
        {
            if (x < 0 || x >= Width) throw new ArgumentException("Invalid range", "x");
            if (y < 0 || y >= Height) throw new ArgumentException("Invalid range", "y");
            var pixelnum = (y * Width + x);
            var index = pixelnum * (BitsPerPixel / 8);
            PixelStream.Position = index;
            switch (Format)
            {
                case TextureFormat.RGBA8888:
                    return Color.FromRgba8888(PixelStream.ReadUInt32BE());
                case TextureFormat.RGBA5551:
                    return Color.FromRgba5551(PixelStream.ReadUInt16BE());
                case TextureFormat.IA88:
                    return Color.FromIA88(PixelStream.ReadUInt16BE());
                case TextureFormat.IA44:
                    return Color.FromIA44(Pixels[index]);
                case TextureFormat.I8:
                    return Color.FromI8(Pixels[index]);
                case TextureFormat.IA31:
                    var encoded = (byte)(pixelnum % 2 == 0 ? Pixels[index] & 0x0F : Pixels[index] >> 4);
                    return Color.FromIA31(encoded);
                case TextureFormat.I4:
                    encoded = (byte)(pixelnum % 2 == 0 ? Pixels[index] & 0x0F : Pixels[index] >> 4);
                    return Color.FromI4(encoded);
                default: throw new NotImplementedException();
            }
        }

        private void SetPixel4(int index, bool even, byte c)
        {
            Pixels[index] = (byte)(even ? (Pixels[index] & 0xF0) | c : (Pixels[index] & 0x0F) | (c << 4));
        }

        public void SetPixel(int x, int y, Color color)
        {
            if (x < 0 || x >= Width) throw new ArgumentException("Invalid range", "x");
            if (y < 0 || y >= Height) throw new ArgumentException("Invalid range", "y");
            var pixelnum = (y * Width + x);
            var index = pixelnum * (BitsPerPixel / 8);
            PixelStream.Position = index;
            switch (Format)
            {
                case TextureFormat.RGBA8888: PixelStream.WriteBE(color.ToRgba8888()); break;
                case TextureFormat.RGBA5551: PixelStream.WriteBE(color.ToRgba5551()); break;
                case TextureFormat.IA88: PixelStream.WriteBE(color.ToIA88()); break;
                case TextureFormat.IA44: Pixels[index] = color.ToIA44(); break;
                case TextureFormat.I8: Pixels[index] = color.ToI8(); break;
                case TextureFormat.IA31: SetPixel4(index, pixelnum % 2 == 0, color.ToIA31()); break;
                case TextureFormat.I4: SetPixel4(index, pixelnum % 2 == 0, color.ToI4()); break;
                default: throw new NotImplementedException();
            }
        }
    }
}
