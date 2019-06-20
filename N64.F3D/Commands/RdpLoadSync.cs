using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.F3D.Commands
{
    // Command 0xE6
    public class RdpLoadSync : Base
    {
        public RdpLoadSync() : base(Command.RdpLoadSync) { }
    }
}
