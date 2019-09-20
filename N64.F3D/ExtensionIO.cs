using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Jcw87.IO;

namespace N64.F3D
{
    public static class ExtensionIO
    {
        public static void WriteBE(this Stream stream, Commands.Base cmd) { stream.WriteBE(cmd.Data); }
        public static void WriteBE(this Stream stream, ICollection<Commands.Base> cmds)
        {
            foreach (var cmd in cmds) stream.WriteBE(cmd);
            stream.WriteBE(DisplayList.End);
        }
    }
}
