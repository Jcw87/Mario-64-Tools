using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.F3D.Commands
{
    // Command 0xFD
    public class SetTImg : Base
    {
        private static BitFieldAccessor64 FormatAccessor = new BitFieldAccessor64(53, 3);
        public PixelFormat Format
        {
            get => (PixelFormat)FormatAccessor.Get(Data);
            set => Data = FormatAccessor.Set(Data, (ulong)value);
        }

        private static BitFieldAccessor64 BitsPerPixelAccessor = new BitFieldAccessor64(51, 2);
        public BitsPerPixel BitsPerPixel
        {
            get => (BitsPerPixel)BitsPerPixelAccessor.Get(Data);
            set => Data = BitsPerPixelAccessor.Set(Data, (ulong)value);
        }

        private static BitFieldAccessor64 SegAddressAccessor = new BitFieldAccessor64(0, 32);
        public uint SegAddress
        {
            get => (uint)SegAddressAccessor.Get(Data);
            set => Data = SegAddressAccessor.Set(Data, value);
        }

        public SetTImg() : base(Command.SetTImg) { }
        public SetTImg(PixelFormat format, BitsPerPixel bpp, uint segaddress) : this()
        {
            Format = format;
            BitsPerPixel = bpp;
            SegAddress = segaddress;
        }
    }
}
