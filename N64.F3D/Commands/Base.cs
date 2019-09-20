using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace N64.F3D.Commands
{
    public abstract class Base
    {
        internal ulong Data = 0;

        private static BitFieldAccessor64 CommandAccessor = new BitFieldAccessor64(56, 8);
        public Command Command
        {
            get => (Command) CommandAccessor.Get(Data);
            private set => Data = CommandAccessor.Set(Data, (ulong)value);
        }

        protected Base(Command command) { Command = command; }
        protected Base(ulong raw) { Data = raw; }
    }

    
}
