using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.F3D
{
    public enum Command : byte
    {
        Vtx             = 0x04,
        SetGeometryMode = 0xB7,
        EndDl           = 0xB8,
        SetOtherModeL   = 0xB9,
        Texture         = 0xBB,
        Tri1            = 0xBF,
        RdpLoadSync     = 0xE6,
        RdpPipeSync     = 0xE7,
        SetTileSize     = 0xF2,
        LoadBlock       = 0xF3,
        SetTile         = 0xF5,
        SetCombine      = 0xFC,
        SetTImg         = 0xFD,
    }

    public enum PixelFormat : byte
    {
        RGBA = 0,
        YUV = 1,
        CI = 2,
        IA = 3,
        I = 4,
    }

    public enum BitsPerPixel : byte
    {
        B4 = 0,
        B8 = 1,
        B16 = 2,
        B32 = 3,
    }

    [Flags]
    public enum GeometryMode
    {
        ZBuffer = 0x00000001,
        Shade = 0x00000004,
        ShadeSmooth = 0x00000200,
        CullFront = 0x00001000,
        CullBack = 0x00002000,
        Fog = 0x00010000,
        Lighting = 0x00020000,
        TextureGen = 0x00040000,
        TextureGenLinear = 0x00080000,
    }
}
