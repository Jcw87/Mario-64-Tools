using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jcw87.IO
{
    public static class ExtensionIO
    {
        public static byte ReadByte(this byte[] bytes, int offset) { return bytes[offset]; }
        public static byte[] ReadBytes(this byte[] bytes, int offset, int count)
        {
            var data = new byte[count];
            Array.Copy(bytes, offset, data, 0, count);
            return data;
        }

        public static void WriteByte(this byte[] bytes, int offset, byte data) { bytes[offset] = data; }
        public static void WriteBytes(this byte[] bytes, int offset, byte[] data) { Array.Copy(data, 0, bytes, offset, data.Length); }

        public static uint ReadUInt24LE(this Stream stream)
        {
            var bytes = new byte[4];
            stream.Read(bytes, 0, 3);
            if (!BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
        }

        public static uint ReadUInt24BE(this Stream stream)
        {
            var bytes = new byte[4];
            stream.Read(bytes, 1, 3);
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
        }

        public static void WriteUInt24LE(this Stream stream, uint value)
        {
            var bytes = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) Array.Reverse(bytes);
            stream.Write(bytes, 0, 3);
        }

        public static void WriteUInt24BE(this Stream stream, uint value)
        {
            var bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            stream.Write(bytes, 1, 3);
        }
    }
}
