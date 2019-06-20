using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.F3D.Commands
{
    // Command 0xF5
    public class SetTile : Base
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

        private static BitFieldAccessor64 Num64PerRowAccessor = new BitFieldAccessor64(41, 9);
        public ushort Num64PerRow
        {
            get => (ushort)Num64PerRowAccessor.Get(Data);
            set => Data = Num64PerRowAccessor.Set(Data, value);
        }

        private static BitFieldAccessor64 TmemOffsetAccessor = new BitFieldAccessor64(32, 9);
        public ushort TmemOffset
        {
            get => (ushort)TmemOffsetAccessor.Get(Data);
            set => Data = TmemOffsetAccessor.Set(Data, value);
        }

        private static BitFieldAccessor64 TileDescriptorAccessor = new BitFieldAccessor64(24, 3);
        public byte TileDescriptor
        {
            get => (byte)TileDescriptorAccessor.Get(Data);
            set => Data = TileDescriptorAccessor.Set(Data, value);
        }

        private static BitFieldAccessor64 PaletteAccessor = new BitFieldAccessor64(20, 4);
        public byte Palette
        {
            get => (byte)PaletteAccessor.Get(Data);
            set => Data = PaletteAccessor.Set(Data, value);
        }

        private static BitFieldAccessor64 TFlagsAccessor = new BitFieldAccessor64(18, 2);
        public byte TFlags
        {
            get => (byte)TFlagsAccessor.Get(Data);
            set => Data = TFlagsAccessor.Set(Data, value);
        }

        private static BitFieldAccessor64 TMaskAccessor = new BitFieldAccessor64(14, 4);
        public byte TMask
        {
            get => (byte)TMaskAccessor.Get(Data);
            set => Data = TMaskAccessor.Set(Data, value);
        }

        private static BitFieldAccessor64 TShiftAccessor = new BitFieldAccessor64(10, 4);
        public byte TShift
        {
            get => (byte)TShiftAccessor.Get(Data);
            set => Data = TShiftAccessor.Set(Data, value);
        }

        private static BitFieldAccessor64 SFlagsAccessor = new BitFieldAccessor64(8, 2);
        public byte SFlags
        {
            get => (byte)SFlagsAccessor.Get(Data);
            set => Data = SFlagsAccessor.Set(Data, value);
        }

        private static BitFieldAccessor64 SMaskAccessor = new BitFieldAccessor64(4, 4);
        public byte SMask
        {
            get => (byte)SMaskAccessor.Get(Data);
            set => Data = SMaskAccessor.Set(Data, value);
        }

        private static BitFieldAccessor64 SShiftAccessor = new BitFieldAccessor64(0, 4);
        public byte SShift
        {
            get => (byte)SShiftAccessor.Get(Data);
            set => Data = SShiftAccessor.Set(Data, value);
        }

        public SetTile() : base(Command.SetTile) { }
        public SetTile(PixelFormat format, BitsPerPixel bpp, ushort num64perrow, ushort tmemoffset, byte tiledescriptor, byte palette, byte tflags, byte tmask, byte tshift, byte sflags, byte smask, byte sshift) : this()
        {
            Format = format;
            BitsPerPixel = bpp;
            Num64PerRow = num64perrow;
            TmemOffset = tmemoffset;
            TileDescriptor = tiledescriptor;
            Palette = palette;
            TFlags = tflags;
            TMask = tmask;
            TShift = tshift;
            SFlags = sflags;
            SMask = smask;
            SShift = sshift;
        }

    }
}
