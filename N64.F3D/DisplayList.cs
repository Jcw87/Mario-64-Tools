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
        private class EndDl : Commands.Base { public EndDl() : base(Command.EndDl) { } }
        private static EndDl End = new EndDl();

        public void WriteTo(Stream stream)
        {
            foreach (var command in this) command.WriteTo(stream);
            End.WriteTo(stream);
        }
    }
}
