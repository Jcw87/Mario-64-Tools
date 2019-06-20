using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64
{
    public class BitFieldAccessor64
    {
        public byte Shift { get; }
        public byte Size { get; }
        public ulong Mask { get; }

        public BitFieldAccessor64(byte shift, byte size)
        {
            Shift = shift;
            Size = size;
            if (Shift > 63) throw new ArgumentException("Shift too large");
            if (Size == 0) throw new ArgumentException("Size cannot be zero");
            if (Shift + Size > 64) throw new ArgumentException("Shift + Size too large");
            Mask = (((ulong)1 << Size) - 1) << Shift;
        }

        public ulong Get(ulong data) => ((data & Mask) >> Shift);
        public ulong Set(ulong data, ulong value) => (data & ~Mask) | ((value << Shift) & Mask);
    }
}
