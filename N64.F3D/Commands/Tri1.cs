using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.F3D.Commands
{
    public class Tri1 : Base
    {
        private static BitFieldAccessor64 Idx1Accessor = new BitFieldAccessor64(16, 8);
        public byte Idx1
        {
            get => (byte)(Idx1Accessor.Get(Data) / 0x0A);
            set => Data = Idx1Accessor.Set(Data, value * 0x0Au);
        }

        private static BitFieldAccessor64 Idx2Accessor = new BitFieldAccessor64(8, 8);
        public byte Idx2
        {
            get => (byte)(Idx2Accessor.Get(Data) / 0x0A);
            set => Data = Idx2Accessor.Set(Data, value * 0x0Au);
        }

        private static BitFieldAccessor64 Idx3Accessor = new BitFieldAccessor64(0, 8);
        public byte Idx3
        {
            get => (byte)(Idx3Accessor.Get(Data) / 0x0A);
            set => Data = Idx3Accessor.Set(Data, value * 0x0Au);
        }

        public Tri1() : base(Command.Tri1) { }
        public Tri1(byte idx1, byte idx2, byte idx3) : this()
        {
            Idx1 = idx1;
            Idx2 = idx2;
            Idx3 = idx3;
        }
    }
}
