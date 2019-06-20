using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.F3D.Commands
{
    // Command 0xBB
    public class Texture : Base
    {
        private static BitFieldAccessor64 MipmapLevelsAccessor = new BitFieldAccessor64(43, 3);
        public byte MipmapLevels
        {
            get => (byte)MipmapLevelsAccessor.Get(Data);
            set => Data = MipmapLevelsAccessor.Set(Data, value);
        }

        private static BitFieldAccessor64 TileDescriptorAccessor = new BitFieldAccessor64(40, 3);
        public byte TileDescriptor
        {
            get => (byte)TileDescriptorAccessor.Get(Data);
            set => Data = TileDescriptorAccessor.Set(Data, value);
        }

        private static BitFieldAccessor64 TileDescriptorEnabledAccessor = new BitFieldAccessor64(32, 8);
        public byte TileDescriptorEnabled
        {
            get => (byte)TileDescriptorEnabledAccessor.Get(Data);
            set => Data = TileDescriptorEnabledAccessor.Set(Data, value);
        }

        private static BitFieldAccessor64 ScaleSAccessor = new BitFieldAccessor64(16, 16);
        public ushort ScaleS
        {
            get => (ushort)ScaleSAccessor.Get(Data);
            set => Data = ScaleSAccessor.Set(Data, value);
        }

        private static BitFieldAccessor64 ScaleTAccessor = new BitFieldAccessor64(0, 16);
        public ushort ScaleT
        {
            get => (ushort)ScaleTAccessor.Get(Data);
            set => Data = ScaleTAccessor.Set(Data, value);
        }

        public Texture() : base(Command.Texture) { }
        public Texture(byte mipmapLevels, byte tileDescriptor, byte tileDescriptorEnabled, ushort scaleS, ushort scaleT) : this()
        {
            MipmapLevels = mipmapLevels;
            TileDescriptor = tileDescriptor;
            TileDescriptorEnabled = tileDescriptorEnabled;
            ScaleS = scaleS;
            ScaleT = scaleT;
        }
    }
}
