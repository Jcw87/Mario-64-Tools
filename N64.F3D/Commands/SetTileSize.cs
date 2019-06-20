using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.F3D.Commands
{
    public class SetTileSize : Base
    {
        private static BitFieldAccessor64 WidthAccessor = new BitFieldAccessor64(12, 12);
        public ushort Width
        {
            get => (ushort)(WidthAccessor.Get(Data) >> 2 + 1);
            set => Data = WidthAccessor.Set(Data, (value - 1u) << 2);
        }

        private static BitFieldAccessor64 HeightAccessor = new BitFieldAccessor64(0, 12);
        public ushort Height
        {
            get => (ushort)(HeightAccessor.Get(Data) >> 2 + 1);
            set => Data = HeightAccessor.Set(Data, (value - 1u) << 2);
        }

        public SetTileSize() : base(Command.SetTileSize) { }
        public SetTileSize(ushort width, ushort height) : this()
        {
            Width = width;
            Height = height;
        }
    }
}
