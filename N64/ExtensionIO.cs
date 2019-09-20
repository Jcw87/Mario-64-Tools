using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Jcw87.IO;

namespace N64
{
    public static class ExtensionIO
    {
        public static void WriteBE(this Stream stream, Vector3s vector)
        {
            stream.WriteBE(vector.X);
            stream.WriteBE(vector.Y);
            stream.WriteBE(vector.Z);
        }

        public static void Write(this Stream stream, Texture texture) { stream.Write(texture.Pixels, 0, texture.Pixels.Length); }
        public static void Write(this Stream stream, ICollection<Texture> textures) { foreach (var t in textures) stream.Write(t); }
        public static void Write(this Stream stream, ICollection<ICollection<Texture>> textures) { foreach (var t in textures) stream.Write(t); }
        public static void Write(this Stream stream, ICollection<ICollection<ICollection<Texture>>> textures) { foreach (var t in textures) stream.Write(t); }
    }
}
