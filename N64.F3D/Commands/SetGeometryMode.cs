using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.F3D.Commands
{
    public class SetGeometryMode : Base
    {
        private static BitFieldAccessor64 ModeAccessor = new BitFieldAccessor64(0, 32);
        public GeometryMode Mode
        {
            get => (GeometryMode)ModeAccessor.Get(Data);
            set => Data = ModeAccessor.Set(Data, (ulong)value);
        }

        public SetGeometryMode() : base(Command.SetGeometryMode) { }
        public SetGeometryMode(GeometryMode mode) : this()
        {
            Mode = mode;
        }
    }
}
