using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.F3D.Commands
{
    public class Vtx : Base
    {
        private static BitFieldAccessor64 VertCountAccessor = new BitFieldAccessor64(52, 4);
        public byte VertCount
        {
            get => (byte)(VertCountAccessor.Get(Data) + 1u);
            set
            {
                Data = VertCountAccessor.Set(Data, value - 1u);
                DataLength = (ushort)(value * 0x10u);
            }
        }

        private static BitFieldAccessor64 BufferOffsetAccessor = new BitFieldAccessor64(48, 4);
        public byte BufferOffset
        {
            get => (byte)BufferOffsetAccessor.Get(Data);
            set => Data = BufferOffsetAccessor.Set(Data, value);
        }

        private static BitFieldAccessor64 DataLengthAccessor = new BitFieldAccessor64(32, 16);
        public ushort DataLength
        {
            get => (ushort)DataLengthAccessor.Get(Data);
            set => Data = DataLengthAccessor.Set(Data, value);
        }

        private static BitFieldAccessor64 SegAddressAccessor = new BitFieldAccessor64(0, 32);
        public uint SegAddress
        {
            get => (uint)SegAddressAccessor.Get(Data);
            set => Data = SegAddressAccessor.Set(Data, value);
        }

        public Vtx() : base(Command.Vtx) { }
        public Vtx(byte vertcount, byte bufferoffset, uint segaddress) : this()
        {
            VertCount = vertcount;
            BufferOffset = bufferoffset;
            SegAddress = segaddress;
        }
    }
}
