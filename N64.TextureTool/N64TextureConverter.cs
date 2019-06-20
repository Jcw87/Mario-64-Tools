using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace N64.TextureTool
{
    public class N64TextureConverter
    {
        public static void Convert(string infname, string outfname)
        {
            var uri = new Uri(infname);
            var decoder = BitmapDecoder.Create(uri, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);

            var outfile = File.Create("out.bin");
            foreach (var frame in decoder.Frames)
            {
                var converted = new ImageRgba5551(frame);
                converted.WriteTo(outfile);
            }
            outfile.Close();
        }
    }
}
