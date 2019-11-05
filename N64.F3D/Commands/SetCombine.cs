using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.F3D.Commands
{
    public enum CCMUXA
    {
        COMBINED = 0,
        TEXEL0 = 1,
        TEXEL1 = 2,
        PRIMITIVE = 3,
        SHADE = 4,
        ENVIRONMENT = 5,
        ONE = 6,
        NOISE = 7,
        ZERO = 15,
    }

    public enum CCMUXB
    {
        COMBINED = 0,
        TEXEL0 = 1,
        TEXEL1 = 2,
        PRIMITIVE = 3,
        SHADE = 4,
        ENVIRONMENT = 5,
        CENTER = 6,
        K4 = 7,
        ZERO = 15,
    }

    public enum CCMUXC
    {
        COMBINED = 0,
        TEXEL0 = 1,
        TEXEL1 = 2,
        PRIMITIVE = 3,
        SHADE = 4,
        ENVIRONMENT = 5,
        SCALE = 6,
        COMBINED_ALPHA = 7,
        TEXEL0_ALPHA = 8,
        TEXEL1_ALPHA = 9,
        PRIMITIVE_ALPHA = 10,
        SHADE_ALPHA = 11,
        ENV_ALPHA = 12,
        LOD_FRACTION = 13,
        PRIM_LOD_FRAC = 14,
        K5 = 15,
        ZERO = 31,
    }

    public enum CCMUXD
    {
        COMBINED = 0,
        TEXEL0 = 1,
        TEXEL1 = 2,
        PRIMITIVE = 3,
        SHADE = 4,
        ENVIRONMENT = 5,
        ONE = 6,
        ZERO = 7,
    }

    public enum ACMUX
    {
        COMBINED = 0,
        TEXEL0 = 1,
        TEXEL1 = 2,
        PRIMITIVE = 3,
        SHADE = 4,
        ENVIRONMENT = 5,
        ONE = 6,
        ZERO = 7,
    }

    public enum ACMUXC
    {
        LOD_FRACTION = 0,
        TEXEL0 = 1,
        TEXEL1 = 2,
        PRIMITIVE = 3,
        SHADE = 4,
        ENVIRONMENT = 5,
        PRIM_LOD_FRAC = 6,
        ZERO = 7,
    }

    // Command 0xFC
    public class SetCombine : Base
    {
        public static BitFieldAccessor64 Ca0Accessor = new BitFieldAccessor64(52, 4);
        public CCMUXA Ca0
        {
            get => (CCMUXA)Ca0Accessor.Get(Data);
            set => Data = Ca0Accessor.Set(Data, (ulong)value);
        }

        public static BitFieldAccessor64 Cc0Accessor = new BitFieldAccessor64(47, 5);
        public CCMUXC Cc0
        {
            get => (CCMUXC)Cc0Accessor.Get(Data);
            set => Data = Cc0Accessor.Set(Data, (ulong)value);
        }

        public static BitFieldAccessor64 Aa0Accessor = new BitFieldAccessor64(44, 3);
        public ACMUX Aa0
        {
            get => (ACMUX)Aa0Accessor.Get(Data);
            set => Data = Aa0Accessor.Set(Data, (ulong)value);
        }

        public static BitFieldAccessor64 Ac0Accessor = new BitFieldAccessor64(41, 3);
        public ACMUXC Ac0
        {
            get => (ACMUXC)Ac0Accessor.Get(Data);
            set => Data = Ac0Accessor.Set(Data, (ulong)value);
        }

        public static BitFieldAccessor64 Ca1Accessor = new BitFieldAccessor64(37, 4);
        public CCMUXA Ca1
        {
            get => (CCMUXA)Ca1Accessor.Get(Data);
            set => Data = Ca1Accessor.Set(Data, (ulong)value);
        }

        public static BitFieldAccessor64 Cc1Accessor = new BitFieldAccessor64(32, 5);
        public CCMUXC Cc1
        {
            get => (CCMUXC)Cc1Accessor.Get(Data);
            set => Data = Cc1Accessor.Set(Data, (ulong)value);
        }

        public static BitFieldAccessor64 Cb0Accessor = new BitFieldAccessor64(28, 4);
        public CCMUXB Cb0
        {
            get => (CCMUXB)Cb0Accessor.Get(Data);
            set => Data = Cb0Accessor.Set(Data, (ulong)value);
        }

        public static BitFieldAccessor64 Cb1Accessor = new BitFieldAccessor64(24, 4);
        public CCMUXB Cb1
        {
            get => (CCMUXB)Cb1Accessor.Get(Data);
            set => Data = Cb1Accessor.Set(Data, (ulong)value);
        }

        public static BitFieldAccessor64 Aa1Accessor = new BitFieldAccessor64(21, 3);
        public ACMUX Aa1
        {
            get => (ACMUX)Aa1Accessor.Get(Data);
            set => Data = Aa1Accessor.Set(Data, (ulong)value);
        }

        public static BitFieldAccessor64 Ac1Accessor = new BitFieldAccessor64(18, 3);
        public ACMUXC Ac1
        {
            get => (ACMUXC)Ac1Accessor.Get(Data);
            set => Data = Ac1Accessor.Set(Data, (ulong)value);
        }

        public static BitFieldAccessor64 Cd0Accessor = new BitFieldAccessor64(15, 3);
        public CCMUXD Cd0
        {
            get => (CCMUXD)Cd0Accessor.Get(Data);
            set => Data = Cd0Accessor.Set(Data, (ulong)value);
        }

        public static BitFieldAccessor64 Ab0Accessor = new BitFieldAccessor64(12, 3);
        public ACMUX Ab0
        {
            get => (ACMUX)Ab0Accessor.Get(Data);
            set => Data = Ab0Accessor.Set(Data, (ulong)value);
        }

        public static BitFieldAccessor64 Ad0Accessor = new BitFieldAccessor64(9, 3);
        public ACMUX Ad0
        {
            get => (ACMUX)Ad0Accessor.Get(Data);
            set => Data = Ad0Accessor.Set(Data, (ulong)value);
        }

        public static BitFieldAccessor64 Cd1Accessor = new BitFieldAccessor64(6, 3);
        public CCMUXD Cd1
        {
            get => (CCMUXD)Cd1Accessor.Get(Data);
            set => Data = Cd1Accessor.Set(Data, (ulong)value);
        }

        public static BitFieldAccessor64 Ab1Accessor = new BitFieldAccessor64(3, 3);
        public ACMUX Ab1
        {
            get => (ACMUX)Ab1Accessor.Get(Data);
            set => Data = Ab1Accessor.Set(Data, (ulong)value);
        }

        public static BitFieldAccessor64 Ad1Accessor = new BitFieldAccessor64(0, 3);
        public ACMUX Ad1
        {
            get => (ACMUX)Ad1Accessor.Get(Data);
            set => Data = Ad1Accessor.Set(Data, (ulong)value);
        }

        public SetCombine() : base(Command.SetCombine) { }
        public SetCombine(ulong raw) : base(raw)
        {
            if (Command != Command.SetCombine) throw new ArgumentException();
        }

        public SetCombine(CCMUXA Ca0, CCMUXB Cb0, CCMUXC Cc0, CCMUXD Cd0, ACMUX Aa0, ACMUX Ab0, ACMUXC Ac0, ACMUX Ad0, CCMUXA Ca1, CCMUXB Cb1, CCMUXC Cc1, CCMUXD Cd1, ACMUX Aa1, ACMUX Ab1, ACMUXC Ac1, ACMUX Ad1) : base(Command.SetCombine)
        {
            this.Ca0 = Ca0;
            this.Cb0 = Cb0;
            this.Cc0 = Cc0;
            this.Cd0 = Cd0;
            this.Aa0 = Aa0;
            this.Ab0 = Ab0;
            this.Ac0 = Ac0;
            this.Ad0 = Ad0;
            this.Ca1 = Ca1;
            this.Cb1 = Cb1;
            this.Cc1 = Cc1;
            this.Cd1 = Cd1;
            this.Aa1 = Aa1;
            this.Ab1 = Ab1;
            this.Ac1 = Ac1;
            this.Ad1 = Ad1;
        }
    }
}
