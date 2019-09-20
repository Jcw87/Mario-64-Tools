using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.TextureTool
{
    public class ConvertOptions
    {
        public enum Output
        {
            Obj,
            RawImage,
            EndCake,
        }

        public string InputFileName { get; set; }
        public Output OutputType { get; set; }

        public TextureFormat OutputFormat { get; set; } = TextureFormat.RGBA5551;

        public int? ImageWidth { get; set; }
        public int? ImageHeight { get; set; }

        public int TileWidth { get; set; }
        public int TileHeight { get; set; }

        public string OutputFolder { get; set; }
    }
}
