using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using JeremyAnsel.Media.WavefrontObj;

namespace N64.TextureTool
{
    public static class Extension
    {
        public static Texture ToN64Texture(this BitmapSource src, TextureFormat format = TextureFormat.RGBA5551)
        {
            var texture = new Texture(src.PixelWidth, src.PixelHeight, format);
            // convert to known color format
            var converted = new FormatConvertedBitmap(src, PixelFormats.Bgra32, null, 0);
            var pixelcount = src.PixelWidth * src.PixelHeight;
            var bytesperpixel = (converted.Format.BitsPerPixel / 8);
            var size = pixelcount * bytesperpixel;
            var srcbytes = new byte[size];
            converted.CopyPixels(srcbytes, src.PixelWidth * bytesperpixel, 0);

            using (var stream = new MemoryStream(texture.Pixels))
            {
                for (var y = 0; y < texture.Height; y++)
                {
                    for (var x = 0; x < texture.Width; x++)
                    {
                        var i = y * texture.Width + x;
                        var color = new Color(srcbytes[i * 4 + 2], srcbytes[i * 4 + 1], srcbytes[i * 4 + 0], srcbytes[i * 4 + 3]);
                        texture.SetPixel(x, y, color);
                    }
                }
            }

            return texture;
        }

        public static ObjVertex ToObjVertex(this Vector3 v) => new ObjVertex(v.X, v.Y, v.Z);
        public static ObjVector3 ToObjVector3(this Vector3 v) => new ObjVector3(v.X, v.Y, v.Z);
        public static ObjVector3 ToObjVector3(this Vector2 v) => new ObjVector3(v.X, v.Y, 0);
        public static int AddUniqueIndex<T>(this Dictionary<T, int> dict, T o)
        {
            if (!dict.ContainsKey(o)) dict[o] = dict.Count + 1;
            return dict[o];
        }
    }
}
