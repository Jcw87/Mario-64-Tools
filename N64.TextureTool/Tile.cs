using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.TextureTool
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
        public int TextureWidth => NextPowerOf2(ImageWidth);
        public int TextureHeight => NextPowerOf2(ImageHeight);

        private int NextPowerOf2(int input)
        {
            return 1 << (int)Math.Ceiling(Math.Log(input, 2));
        }

    }
}
