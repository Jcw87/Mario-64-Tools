using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace N64
{
    public class BinaryReaderEndian : BinaryReader
    {
        private byte[] m_buffer2;
        private bool m_nativeEndian = true;
        private bool m_bigEndian = !BitConverter.IsLittleEndian;

        public BinaryReaderEndian(Stream input) : this(input, Encoding.UTF8) { }
        public BinaryReaderEndian(Stream input, Encoding encoding) : this(input, encoding, false) { }
        public BinaryReaderEndian(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
        {
            var minBufferSize = encoding.GetMaxByteCount(1);  // max bytes per one char
            if (minBufferSize < 16) minBufferSize = 16;
            m_buffer2 = new byte[minBufferSize];
        }

        public bool BigEndian {
            get { return m_bigEndian; }
            set
            {
                m_bigEndian = value;
                m_nativeEndian = BitConverter.IsLittleEndian != m_bigEndian;
            }
        }

        public override short ReadInt16()
        {
            BaseStream.Read(m_buffer2, 0, 2);
            if (m_bigEndian)
            {
                return (short)(m_buffer2[1] | m_buffer2[0] << 8);
            }
            return (short)(m_buffer2[0] | m_buffer2[1] << 8);
        }

        public override ushort ReadUInt16()
        {
            BaseStream.Read(m_buffer2, 0, 2);
            if (m_bigEndian)
            {
                return (ushort)(m_buffer2[1] | m_buffer2[0] << 8);
            }
            return (ushort)(m_buffer2[0] | m_buffer2[1] << 8);
        }
        /*
        public virtual int ReadInt24()
        {
            BaseStream.Read(m_buffer2, 0, 3);
            if (m_bigEndian)
            {
                return (int)(m_buffer2[2] | m_buffer2[1] << 8 | m_buffer2[0] << 16);
            }
            return (int)(m_buffer2[0] | m_buffer2[1] << 8 | m_buffer2[2] << 16);
        }
        */
        public virtual uint ReadUInt24()
        {
            BaseStream.Read(m_buffer2, 0, 3);
            if (m_bigEndian)
            {
                return (uint)(m_buffer2[2] | m_buffer2[1] << 8 | m_buffer2[0] << 16);
            }
            return (uint)(m_buffer2[0] | m_buffer2[1] << 8 | m_buffer2[2] << 16);
        }

        public override int ReadInt32()
        {
            BaseStream.Read(m_buffer2, 0, 4);
            if (m_bigEndian)
            {
                return (int)(m_buffer2[3] | m_buffer2[2] << 8 | m_buffer2[1] << 16 | m_buffer2[0] << 24);
            }
            return (int)(m_buffer2[0] | m_buffer2[1] << 8 | m_buffer2[2] << 16 | m_buffer2[3] << 24);
        }

        public override uint ReadUInt32()
        {
            BaseStream.Read(m_buffer2, 0, 4);
            if (m_bigEndian)
            {
                return (uint)(m_buffer2[3] | m_buffer2[2] << 8 | m_buffer2[1] << 16 | m_buffer2[0] << 24);
            }
            return (uint)(m_buffer2[0] | m_buffer2[1] << 8 | m_buffer2[2] << 16 | m_buffer2[3] << 24);
        }

        public override long ReadInt64()
        {
            BaseStream.Read(m_buffer2, 0, 8);
            if (m_bigEndian)
            {
                uint lo = (uint)(m_buffer2[7] | m_buffer2[6] << 8 | m_buffer2[5] << 16 | m_buffer2[4] << 24);
                uint hi = (uint)(m_buffer2[3] | m_buffer2[2] << 8 | m_buffer2[1] << 16 | m_buffer2[0] << 24);
                return (long)((ulong)hi) << 32 | lo;
            }
            else
            {
                uint lo = (uint)(m_buffer2[0] | m_buffer2[1] << 8 | m_buffer2[2] << 16 | m_buffer2[3] << 24);
                uint hi = (uint)(m_buffer2[4] | m_buffer2[5] << 8 | m_buffer2[6] << 16 | m_buffer2[7] << 24);
                return (long)((ulong)hi) << 32 | lo;
            }
        }
        public override ulong ReadUInt64()
        {
            BaseStream.Read(m_buffer2, 0, 8);
            if (m_bigEndian)
            {
                uint lo = (uint)(m_buffer2[7] | m_buffer2[6] << 8 | m_buffer2[5] << 16 | m_buffer2[4] << 24);
                uint hi = (uint)(m_buffer2[3] | m_buffer2[2] << 8 | m_buffer2[1] << 16 | m_buffer2[0] << 24);
                return (ulong)((ulong)hi) << 32 | lo;
            }
            else
            {
                uint lo = (uint)(m_buffer2[0] | m_buffer2[1] << 8 | m_buffer2[2] << 16 | m_buffer2[3] << 24);
                uint hi = (uint)(m_buffer2[4] | m_buffer2[5] << 8 | m_buffer2[6] << 16 | m_buffer2[7] << 24);
                return (ulong)((ulong)hi) << 32 | lo;
            }
        }
        public override float ReadSingle()
        {
            var bytes = ReadBytes(4);
            if (!m_nativeEndian) Array.Reverse(bytes);
            return BitConverter.ToSingle(bytes, 0);
        }
        public override double ReadDouble()
        {
            var bytes = ReadBytes(8);
            if (!m_nativeEndian) Array.Reverse(bytes);
            return BitConverter.ToDouble(bytes, 0);
        }
    }
}
