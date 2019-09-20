using System;
using System.IO;

namespace Jcw87.IO
{
    public static class ExtensionIOGenerated
	{
		public static Int16 ReadInt16LE(this byte[] bytes, int offset)
        {
            var data = bytes.ReadBytes(offset, sizeof(Int16));
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            return BitConverter.ToInt16(data, 0);
        }

		public static Int16 ReadInt16BE(this byte[] bytes, int offset)
        {
            var data = bytes.ReadBytes(offset, sizeof(Int16));
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            return BitConverter.ToInt16(data, 0);
        }

		public static void WriteLE(this byte[] bytes, int offset, Int16 value)
        {
            var data = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) Array.Reverse(data);
            bytes.WriteBytes(offset, data);
        }

		public static void WriteBE(this byte[] bytes, int offset, Int16 value)
        {
            var data = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            bytes.WriteBytes(offset, data);
        }

		public static Int16 ReadInt16LE(this Stream stream)
		{
			var bytes = new byte[sizeof(Int16)];
            stream.Read(bytes, 0, sizeof(Int16));
            if (!BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToInt16(bytes, 0);
		}

		public static Int16 ReadInt16BE(this Stream stream)
		{
			var bytes = new byte[sizeof(Int16)];
            stream.Read(bytes, 0, sizeof(Int16));
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToInt16(bytes, 0);
		}

		public static void WriteLE(this Stream stream, Int16 value)
		{
			var bytes = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) Array.Reverse(bytes);
            stream.Write(bytes, 0, bytes.Length);
		}

		public static void WriteBE(this Stream stream, Int16 value)
		{
			var bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            stream.Write(bytes, 0, bytes.Length);
		}

		public static Int32 ReadInt32LE(this byte[] bytes, int offset)
        {
            var data = bytes.ReadBytes(offset, sizeof(Int32));
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            return BitConverter.ToInt32(data, 0);
        }

		public static Int32 ReadInt32BE(this byte[] bytes, int offset)
        {
            var data = bytes.ReadBytes(offset, sizeof(Int32));
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            return BitConverter.ToInt32(data, 0);
        }

		public static void WriteLE(this byte[] bytes, int offset, Int32 value)
        {
            var data = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) Array.Reverse(data);
            bytes.WriteBytes(offset, data);
        }

		public static void WriteBE(this byte[] bytes, int offset, Int32 value)
        {
            var data = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            bytes.WriteBytes(offset, data);
        }

		public static Int32 ReadInt32LE(this Stream stream)
		{
			var bytes = new byte[sizeof(Int32)];
            stream.Read(bytes, 0, sizeof(Int32));
            if (!BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToInt32(bytes, 0);
		}

		public static Int32 ReadInt32BE(this Stream stream)
		{
			var bytes = new byte[sizeof(Int32)];
            stream.Read(bytes, 0, sizeof(Int32));
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToInt32(bytes, 0);
		}

		public static void WriteLE(this Stream stream, Int32 value)
		{
			var bytes = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) Array.Reverse(bytes);
            stream.Write(bytes, 0, bytes.Length);
		}

		public static void WriteBE(this Stream stream, Int32 value)
		{
			var bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            stream.Write(bytes, 0, bytes.Length);
		}

		public static Int64 ReadInt64LE(this byte[] bytes, int offset)
        {
            var data = bytes.ReadBytes(offset, sizeof(Int64));
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            return BitConverter.ToInt64(data, 0);
        }

		public static Int64 ReadInt64BE(this byte[] bytes, int offset)
        {
            var data = bytes.ReadBytes(offset, sizeof(Int64));
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            return BitConverter.ToInt64(data, 0);
        }

		public static void WriteLE(this byte[] bytes, int offset, Int64 value)
        {
            var data = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) Array.Reverse(data);
            bytes.WriteBytes(offset, data);
        }

		public static void WriteBE(this byte[] bytes, int offset, Int64 value)
        {
            var data = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            bytes.WriteBytes(offset, data);
        }

		public static Int64 ReadInt64LE(this Stream stream)
		{
			var bytes = new byte[sizeof(Int64)];
            stream.Read(bytes, 0, sizeof(Int64));
            if (!BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToInt64(bytes, 0);
		}

		public static Int64 ReadInt64BE(this Stream stream)
		{
			var bytes = new byte[sizeof(Int64)];
            stream.Read(bytes, 0, sizeof(Int64));
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToInt64(bytes, 0);
		}

		public static void WriteLE(this Stream stream, Int64 value)
		{
			var bytes = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) Array.Reverse(bytes);
            stream.Write(bytes, 0, bytes.Length);
		}

		public static void WriteBE(this Stream stream, Int64 value)
		{
			var bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            stream.Write(bytes, 0, bytes.Length);
		}

		public static UInt16 ReadUInt16LE(this byte[] bytes, int offset)
        {
            var data = bytes.ReadBytes(offset, sizeof(UInt16));
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            return BitConverter.ToUInt16(data, 0);
        }

		public static UInt16 ReadUInt16BE(this byte[] bytes, int offset)
        {
            var data = bytes.ReadBytes(offset, sizeof(UInt16));
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            return BitConverter.ToUInt16(data, 0);
        }

		public static void WriteLE(this byte[] bytes, int offset, UInt16 value)
        {
            var data = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) Array.Reverse(data);
            bytes.WriteBytes(offset, data);
        }

		public static void WriteBE(this byte[] bytes, int offset, UInt16 value)
        {
            var data = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            bytes.WriteBytes(offset, data);
        }

		public static UInt16 ReadUInt16LE(this Stream stream)
		{
			var bytes = new byte[sizeof(UInt16)];
            stream.Read(bytes, 0, sizeof(UInt16));
            if (!BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToUInt16(bytes, 0);
		}

		public static UInt16 ReadUInt16BE(this Stream stream)
		{
			var bytes = new byte[sizeof(UInt16)];
            stream.Read(bytes, 0, sizeof(UInt16));
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToUInt16(bytes, 0);
		}

		public static void WriteLE(this Stream stream, UInt16 value)
		{
			var bytes = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) Array.Reverse(bytes);
            stream.Write(bytes, 0, bytes.Length);
		}

		public static void WriteBE(this Stream stream, UInt16 value)
		{
			var bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            stream.Write(bytes, 0, bytes.Length);
		}

		public static UInt32 ReadUInt32LE(this byte[] bytes, int offset)
        {
            var data = bytes.ReadBytes(offset, sizeof(UInt32));
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            return BitConverter.ToUInt32(data, 0);
        }

		public static UInt32 ReadUInt32BE(this byte[] bytes, int offset)
        {
            var data = bytes.ReadBytes(offset, sizeof(UInt32));
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            return BitConverter.ToUInt32(data, 0);
        }

		public static void WriteLE(this byte[] bytes, int offset, UInt32 value)
        {
            var data = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) Array.Reverse(data);
            bytes.WriteBytes(offset, data);
        }

		public static void WriteBE(this byte[] bytes, int offset, UInt32 value)
        {
            var data = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            bytes.WriteBytes(offset, data);
        }

		public static UInt32 ReadUInt32LE(this Stream stream)
		{
			var bytes = new byte[sizeof(UInt32)];
            stream.Read(bytes, 0, sizeof(UInt32));
            if (!BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
		}

		public static UInt32 ReadUInt32BE(this Stream stream)
		{
			var bytes = new byte[sizeof(UInt32)];
            stream.Read(bytes, 0, sizeof(UInt32));
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
		}

		public static void WriteLE(this Stream stream, UInt32 value)
		{
			var bytes = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) Array.Reverse(bytes);
            stream.Write(bytes, 0, bytes.Length);
		}

		public static void WriteBE(this Stream stream, UInt32 value)
		{
			var bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            stream.Write(bytes, 0, bytes.Length);
		}

		public static UInt64 ReadUInt64LE(this byte[] bytes, int offset)
        {
            var data = bytes.ReadBytes(offset, sizeof(UInt64));
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            return BitConverter.ToUInt64(data, 0);
        }

		public static UInt64 ReadUInt64BE(this byte[] bytes, int offset)
        {
            var data = bytes.ReadBytes(offset, sizeof(UInt64));
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            return BitConverter.ToUInt64(data, 0);
        }

		public static void WriteLE(this byte[] bytes, int offset, UInt64 value)
        {
            var data = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) Array.Reverse(data);
            bytes.WriteBytes(offset, data);
        }

		public static void WriteBE(this byte[] bytes, int offset, UInt64 value)
        {
            var data = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            bytes.WriteBytes(offset, data);
        }

		public static UInt64 ReadUInt64LE(this Stream stream)
		{
			var bytes = new byte[sizeof(UInt64)];
            stream.Read(bytes, 0, sizeof(UInt64));
            if (!BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToUInt64(bytes, 0);
		}

		public static UInt64 ReadUInt64BE(this Stream stream)
		{
			var bytes = new byte[sizeof(UInt64)];
            stream.Read(bytes, 0, sizeof(UInt64));
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToUInt64(bytes, 0);
		}

		public static void WriteLE(this Stream stream, UInt64 value)
		{
			var bytes = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) Array.Reverse(bytes);
            stream.Write(bytes, 0, bytes.Length);
		}

		public static void WriteBE(this Stream stream, UInt64 value)
		{
			var bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            stream.Write(bytes, 0, bytes.Length);
		}

		public static Single ReadSingleLE(this byte[] bytes, int offset)
        {
            var data = bytes.ReadBytes(offset, sizeof(Single));
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            return BitConverter.ToSingle(data, 0);
        }

		public static Single ReadSingleBE(this byte[] bytes, int offset)
        {
            var data = bytes.ReadBytes(offset, sizeof(Single));
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            return BitConverter.ToSingle(data, 0);
        }

		public static void WriteLE(this byte[] bytes, int offset, Single value)
        {
            var data = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) Array.Reverse(data);
            bytes.WriteBytes(offset, data);
        }

		public static void WriteBE(this byte[] bytes, int offset, Single value)
        {
            var data = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            bytes.WriteBytes(offset, data);
        }

		public static Single ReadSingleLE(this Stream stream)
		{
			var bytes = new byte[sizeof(Single)];
            stream.Read(bytes, 0, sizeof(Single));
            if (!BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToSingle(bytes, 0);
		}

		public static Single ReadSingleBE(this Stream stream)
		{
			var bytes = new byte[sizeof(Single)];
            stream.Read(bytes, 0, sizeof(Single));
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToSingle(bytes, 0);
		}

		public static void WriteLE(this Stream stream, Single value)
		{
			var bytes = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) Array.Reverse(bytes);
            stream.Write(bytes, 0, bytes.Length);
		}

		public static void WriteBE(this Stream stream, Single value)
		{
			var bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            stream.Write(bytes, 0, bytes.Length);
		}

		public static Double ReadDoubleLE(this byte[] bytes, int offset)
        {
            var data = bytes.ReadBytes(offset, sizeof(Double));
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            return BitConverter.ToDouble(data, 0);
        }

		public static Double ReadDoubleBE(this byte[] bytes, int offset)
        {
            var data = bytes.ReadBytes(offset, sizeof(Double));
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            return BitConverter.ToDouble(data, 0);
        }

		public static void WriteLE(this byte[] bytes, int offset, Double value)
        {
            var data = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) Array.Reverse(data);
            bytes.WriteBytes(offset, data);
        }

		public static void WriteBE(this byte[] bytes, int offset, Double value)
        {
            var data = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            bytes.WriteBytes(offset, data);
        }

		public static Double ReadDoubleLE(this Stream stream)
		{
			var bytes = new byte[sizeof(Double)];
            stream.Read(bytes, 0, sizeof(Double));
            if (!BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToDouble(bytes, 0);
		}

		public static Double ReadDoubleBE(this Stream stream)
		{
			var bytes = new byte[sizeof(Double)];
            stream.Read(bytes, 0, sizeof(Double));
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToDouble(bytes, 0);
		}

		public static void WriteLE(this Stream stream, Double value)
		{
			var bytes = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) Array.Reverse(bytes);
            stream.Write(bytes, 0, bytes.Length);
		}

		public static void WriteBE(this Stream stream, Double value)
		{
			var bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            stream.Write(bytes, 0, bytes.Length);
		}

	}
}