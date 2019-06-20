using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.F3D.Commands
{
    // Command 0xFC
    public class SetCombine : Base
    {
        // TODO: implement this properly
        public static BitFieldAccessor64 ParamsAccessor = new BitFieldAccessor64(0, 56);
        public ulong Params
        {
            get => ParamsAccessor.Get(Data);
            set => Data = ParamsAccessor.Set(Data, value);
        }

        public SetCombine() : base(Command.SetCombine) { }
        public SetCombine(ulong raw) : base(raw)
        {
            if (Command != Command.SetCombine) throw new ArgumentException();
        }
    }
}
