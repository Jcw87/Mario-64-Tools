using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.F3D.Commands
{
    public enum MDSFT
    {
        ALPHACOMPARE = 0,
        ZSRCSEL = 2,
        RENDERMODE = 3,
    }

    // Command 0xB9
    public class SetOtherModeL : Base
    {
        private static BitFieldAccessor64 SAccessor = new BitFieldAccessor64(40, 8);
        public byte S
        {
            get => (byte)SAccessor.Get(Data);
            set => Data = SAccessor.Set(Data, value);
        }

        private static BitFieldAccessor64 NAccessor = new BitFieldAccessor64(32, 8);
        public byte N
        {
            get => (byte)NAccessor.Get(Data);
            set => Data = NAccessor.Set(Data, value);
        }

        private static BitFieldAccessor64 DAccessor = new BitFieldAccessor64(0, 32);
        public uint D
        {
            get => (uint)DAccessor.Get(Data);
            set => Data = DAccessor.Set(Data, value);
        }

        public SetOtherModeL() : base(Command.SetOtherModeL) { }
        public SetOtherModeL(byte s, byte n, uint d) : this()
        {
            S = s;
            N = n;
            D = d;
        }
    }
}
