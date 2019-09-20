using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64.F3D
{
    public class DisplayList : List<Commands.Base>
    {
        public class EndDl : Commands.Base { public EndDl() : base(Command.EndDl) { } }
        public readonly static EndDl End = new EndDl();
    }
}
