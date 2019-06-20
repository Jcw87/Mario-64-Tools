using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.F3D.Commands
{
    // Command 0xF3
    public class LoadBlock : Base
    {
        private static BitFieldAccessor64 SOffsetAccessor = new BitFieldAccessor64(44, 12);
        public ushort SOffset
        {
            get => (ushort)SOffsetAccessor.Get(Data);
            set => Data = SOffsetAccessor.Set(Data, value);
        }

        private static BitFieldAccessor64 TOffsetAccessor = new BitFieldAccessor64(32, 12);
        public ushort TOffset
        {
            get => (ushort)TOffsetAccessor.Get(Data);
            set => Data = TOffsetAccessor.Set(Data, value);
        }

        private static BitFieldAccessor64 TileDescriptorAccessor = new BitFieldAccessor64(24, 3);
        public byte TileDescriptor
        {
            get => (byte)TileDescriptorAccessor.Get(Data);
            set => Data = TileDescriptorAccessor.Set(Data, value);
        }

        private static BitFieldAccessor64 TexelCountAccessor = new BitFieldAccessor64(12, 12);
        public ushort TexelCount
        {
            get => (ushort)(TexelCountAccessor.Get(Data) + 1u);
            set => Data = TexelCountAccessor.Set(Data, value - 1u);
        }
        private static BitFieldAccessor64 DxtAccessor = new BitFieldAccessor64(0, 12);
        public ushort Dxt
        {
            get => (ushort)DxtAccessor.Get(Data);
            set => Data = DxtAccessor.Set(Data, value);
        }

        public LoadBlock() : base(Command.LoadBlock) { }
        public LoadBlock(ushort soffset, ushort toffset, byte tiledescriptor, ushort texelcount, ushort dxt) : this()
        {
            SOffset = soffset;
            TOffset = toffset;
            TileDescriptor = tiledescriptor;
            TexelCount = texelcount;
            Dxt = dxt;
        }
    }
}
