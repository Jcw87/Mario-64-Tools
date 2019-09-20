using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcw87.IO
{
    public class BinaryWriterEndian : BinaryWriter
    {
        private byte[] m_buffer2;
        private bool m_nativeEndian = true;
        private bool m_bigEndian = !BitConverter.IsLittleEndian;

        public BinaryWriterEndian(Stream input) : this(input, Encoding.UTF8) { }
        public BinaryWriterEndian(Stream input, Encoding encoding) : this(input, encoding, false) { }
        public BinaryWriterEndian(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
        {
            var minBufferSize = encoding.GetMaxByteCount(1);  // max bytes per one char
            if (minBufferSize < 16) minBufferSize = 16;
            m_buffer2 = new byte[minBufferSize];
        }

        public bool BigEndian
        {
            get { return m_bigEndian; }
            set
            {
                m_bigEndian = value;
                m_nativeEndian = BitConverter.IsLittleEndian != m_bigEndian;
            }
        }

        public override void Write(short value)
        {
            if (BigEndian)
            {
                m_buffer2[1] = (byte)value;
                m_buffer2[0] = (byte)(value >> 8);
            }
            else
            {
                m_buffer2[0] = (byte)value;
                m_buffer2[1] = (byte)(value >> 8);
            }
            BaseStream.Write(m_buffer2, 0, 2);
        }

        public override void Write(ushort value)
        {
            if (BigEndian)
            {
                m_buffer2[1] = (byte)value;
                m_buffer2[0] = (byte)(value >> 8);
                        }
            else
            {
                m_buffer2[0] = (byte)value;
                m_buffer2[1] = (byte)(value >> 8);
            }
            BaseStream.Write(m_buffer2, 0, 2);
        }

        public override void Write(int value)
        {
            if (BigEndian)
            {
                m_buffer2[3] = (byte)value;
                m_buffer2[2] = (byte)(value >> 8);
                m_buffer2[1] = (byte)(value >> 16);
                m_buffer2[0] = (byte)(value >> 24);
            }
            else
            {
                m_buffer2[0] = (byte)value;
                m_buffer2[1] = (byte)(value >> 8);
                m_buffer2[2] = (byte)(value >> 16);
                m_buffer2[3] = (byte)(value >> 24);
            }
            BaseStream.Write(m_buffer2, 0, 4);
        }

        public override void Write(uint value)
        {
            if (BigEndian)
            {
                m_buffer2[3] = (byte)value;
                m_buffer2[2] = (byte)(value >> 8);
                m_buffer2[1] = (byte)(value >> 16);
                m_buffer2[0] = (byte)(value >> 24);
            }
            else
            {
                m_buffer2[0] = (byte)value;
                m_buffer2[1] = (byte)(value >> 8);
                m_buffer2[2] = (byte)(value >> 16);
                m_buffer2[3] = (byte)(value >> 24);
            }
            BaseStream.Write(m_buffer2, 0, 4);
        }

        public override void Write(long value)
        {
            if (BigEndian)
            {
                m_buffer2[7] = (byte)value;
                m_buffer2[6] = (byte)(value >> 8);
                m_buffer2[5] = (byte)(value >> 16);
                m_buffer2[4] = (byte)(value >> 24);
                m_buffer2[3] = (byte)(value >> 32);
                m_buffer2[2] = (byte)(value >> 40);
                m_buffer2[1] = (byte)(value >> 48);
                m_buffer2[0] = (byte)(value >> 56);
            }
            else
            {
                m_buffer2[0] = (byte)value;
                m_buffer2[1] = (byte)(value >> 8);
                m_buffer2[2] = (byte)(value >> 16);
                m_buffer2[3] = (byte)(value >> 24);
                m_buffer2[4] = (byte)(value >> 32);
                m_buffer2[5] = (byte)(value >> 40);
                m_buffer2[6] = (byte)(value >> 48);
                m_buffer2[7] = (byte)(value >> 56);
            }
            BaseStream.Write(m_buffer2, 0, 8);
        }

        public override void Write(float value)
        {
            var bytes = BitConverter.GetBytes(value);
            if (!m_nativeEndian) Array.Reverse(bytes);
            BaseStream.Write(bytes, 0, 4);
        }

        public override void Write(double value)
        {
            var bytes = BitConverter.GetBytes(value);
            if (!m_nativeEndian) Array.Reverse(bytes);
            BaseStream.Write(bytes, 0, 8);
        }
    }
}
