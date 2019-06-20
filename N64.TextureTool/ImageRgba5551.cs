using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace N64.TextureTool
{
    public class ImageRgba5551
    {
        private byte[] Pixels;

        public int Width { get; set; }
        public int Height { get; set; }

        public ImageRgba5551(int width, int height)
        {
            Width = width;
            Height = height;
            Pixels = new byte[width * height * 2];
        }

        public ImageRgba5551(BitmapSource src) : this(src.PixelWidth, src.PixelHeight)
        {
            // convert to known color format
            var converted = new FormatConvertedBitmap(src, PixelFormats.Bgra32, null, 0);
            var pixelcount = Width * Height;
            var bytesperpixel = (converted.Format.BitsPerPixel / 8);
            var size = pixelcount * bytesperpixel;
            var srcbytes = new byte[size];
            converted.CopyPixels(srcbytes, Width * bytesperpixel, 0);

            // convert to target format
            for (var i = 0; i < pixelcount; i++)
            {
                var color = new Color(srcbytes[i * 4 + 2], srcbytes[i * 4 + 1], srcbytes[i * 4 + 0], srcbytes[i * 4 + 3]);
                var encodedcolor = color.ToRgba5551();
                var bytes = BitConverter.GetBytes(encodedcolor);
                if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
                bytes.CopyTo(Pixels, i * 2);
            }
        }

        public void SetColor(int x, int y, Color color)
        {
            if (x < 0 || x > Width) throw new ArgumentException("Out of range", "x");
            if (y < 0 || y > Height) throw new ArgumentException("Out of range", "y");
            var encodedcolor = color.ToRgba5551();
            var bytes = BitConverter.GetBytes(encodedcolor);
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            bytes.CopyTo(Pixels, (y * Width + x) * 2);
        }

        public Color GetColor(int x, int y)
        {
            if (x < 0 || x > Width) throw new ArgumentException("Out of range", "x");
            if (y < 0 || y > Height) throw new ArgumentException("Out of range", "y");
            var bytes = new byte[2];
            Array.Copy(Pixels, (y * Width + x) * 2, bytes, 0, 2);
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            var encodedcolor = BitConverter.ToUInt16(bytes, 0);
            var color = Color.FromRgba5551(encodedcolor);
            return color;
        }

        public void WriteTo(Stream stream)
        {
            stream.Write(Pixels, 0, Pixels.Length);
        }
  
    }
}
