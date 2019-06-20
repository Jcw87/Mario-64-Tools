using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace N64
{
    public class N64ROM : IDisposable
    {
        private static byte[] header_bigendian = new byte[] { 0x80, 0x37, 0x12, 0x40 };
        private static byte[] header_smallendian = new byte[] { 0x40, 0x12, 0x37, 0x80 };
        private static byte[] header_mixedendian = new byte[] { 0x37, 0x80, 0x40, 0x12 };

        private enum CIC : byte
        {
            NUS_6101,
            NUS_6102, // NUS_7101
            NUS_6103,
            NUS_6105,
            NUS_6106,
        }

        private static Dictionary<string, CIC> bootcode_hashes = new Dictionary<string, CIC>
        {
            { "900B4A5B68EDB71F4C7ED52ACD814FC5", CIC.NUS_6101 },
            { "E24DD796B2FA16511521139D28C8356B", CIC.NUS_6102 },
            { "319038097346E12C26C3C21B56F86F23", CIC.NUS_6103 },
            { "FF22A296E55D34AB0A077DC2BA5F5796", CIC.NUS_6105 },
            { "6460387749AC0BD925AA5430BC7864FE", CIC.NUS_6106 },
        };

        private static uint[] CIC_offsets = new uint[]
        {
            0x0, 0x0, 0x100000, 0x0, 0x200000
        };

        public enum RegionCode : byte
        {
            China_iQue = 0x00,
            Beta = 0x37,
            Asia = 0x41,
            Brazil = 0x42,
            China = 0x43,
            Germany = 0x44,
            USA = 0x45,
            France = 0x46,
            Italy = 0x49,
            Japan = 0x4A,
            Korea = 0x4B,
            Canada = 0x4E,
            Europe = 0x50,
            Spain = 0x53,
            Australia = 0x55,
        }

        private bool ByteCompare(int offset, byte[] data)
        {
            for (var i = 0; i < data.Length; i++)
            {
                if (bytes[offset + i] != data[i]) return false;
            }
            return true;
        }

        private void ConvertSmallToBig()
        {
            var temp = new byte[4];
            for (var i = 0; i < bytes.Length; i += 4)
            {
                for (var j = 0; j < 4; j++) temp[j] = bytes[i + j];
                for (var j = 0; j < 4; j++) bytes[i + j] = temp[3 - j];
            }
        }

        private void ConvertMixedToBig()
        {
            for (var i = 0; i < bytes.Length; i += 2)
            {
                var temp = bytes[i];
                bytes[i] = bytes[i + 1];
                bytes[i + 1] = temp;
            }
        }

        protected byte[] bytes;
        private CIC cic;
        //public Stream Stream { get; private set; }
        //public BinaryReader Reader { get; private set; }
        //public BinaryWriter Writer { get; private set; }

        public string FilePath { get; private set; }
        public int Length => bytes.Length;
        public uint BaseVirtualAddress => ReadUInt32(0x08) - CIC_offsets[(byte)cic];
        public string InternalName
        {
            // Offset: 0x20, Length: 20
            get
            {
                return Encoding.ASCII.GetString(bytes, 0x20, 20).TrimEnd();
            }
            set
            {
                var str = Encoding.ASCII.GetBytes(value);
                var len = Math.Min(str.Length, 20);
                Array.Copy(str, 0, bytes, 0x20, len);

                // Pad with ASCII spaces
                for (var i = len; i < 20; i++) bytes[0x20 + i] = 0x20; 
            }
        }
        public string ID => Encoding.ASCII.GetString(bytes, 0x3C, 2);
        public RegionCode Region => (RegionCode)bytes[0x3E];
        public byte Revision => bytes[0x3F];

        public N64ROM(string Filename)
        {
            FilePath = Filename;

            bytes = File.ReadAllBytes(Filename);
            if (bytes.Length <= 0x1000) throw new Exception("Not a valid N64 ROM");
            if (bytes.Length % 4 != 0) throw new Exception("bad ROM length");

            // Determine ROM format. Native format is big endian.
            // Lazily designed rom dumpers introduced 2 additional formats, little endian and mixed.
            // The first 4 bytes of every N64 rom configure the Peripheral Interface.
            // In theory, these could be anything. In practice, every commercial N64 game uses the same values.
            // Check these values to determine rom format.

            if (ByteCompare(0, header_bigendian))
            {
                Console.WriteLine("ROM is big endian format.");
            }
            else if (ByteCompare(0, header_smallendian))
            {
                Console.WriteLine("ROM is in little endian format, converting to big endian.");
                ConvertSmallToBig();
            }
            else if (ByteCompare(0, header_mixedendian))
            {
                Console.WriteLine("ROM is in mixed endian format, converting to big endian.");
                ConvertMixedToBig();
            }
            else Console.WriteLine("Unable to determine ROM format, assuming big endian.");

            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(bytes, 0x40, 0x1000 - 0x40);
                var hashstr = String.Concat(hash.Select(x => x.ToString("X2")));
                if (bootcode_hashes.ContainsKey(hashstr))
                {
                    cic = bootcode_hashes[hashstr];
                }
                else
                {
                    // Assume most common CIC
                    cic = CIC.NUS_6102;
                    Console.WriteLine("WARNING! Unknown ROM bootcode");
                }
            }

            //Stream = new MemoryStream(bytes, true);
            //Reader = new BinaryReaderEndian(Stream, Encoding.ASCII, true) { BigEndian = true };
            //Writer = new BinaryWriterEndian(Stream, Encoding.ASCII, true) { BigEndian = true };
        }

        public void Dispose()
        {
            //Writer.Dispose();
            //Reader.Dispose();
            //Stream.Dispose();
        }

        public UInt32 VAddressToROMOffset(UInt32 VAddress) => VAddress - BaseVirtualAddress + 0x1000;

        public byte ReadByte(int offset) { return bytes[offset]; }

        public byte[] ReadBytes(int offset, int size)
        {
            var data = new byte[size];
            Array.Copy(bytes, offset, data, 0, size);
            return data;
        }

        public Int16 ReadInt16(int offset)
        {
            var data = ReadBytes(offset, 2);
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            return BitConverter.ToInt16(data, 0);
        }

        public UInt16 ReadUInt16(int offset)
        {
            var data = ReadBytes(offset, 2);
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            return BitConverter.ToUInt16(data, 0);
        }

        public Int32 ReadInt32(int offset)
        {
            var data = ReadBytes(offset, 4);
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            return BitConverter.ToInt32(data, 0);
        }

        public UInt32 ReadUInt32(int offset)
        {
            var data = ReadBytes(offset, 4);
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            return BitConverter.ToUInt32(data, 0);
        }

        public Single ReadSingle(int offset)
        {
            var data = ReadBytes(offset, 4);
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            return BitConverter.ToSingle(data, 0);
        }

        public void WriteByte(int offset, byte data) { bytes[offset] = data; }

        public void WriteBytes(int offset, byte[] data) { Array.Copy(data, 0, bytes, offset, data.Length); }

        public void WriteInt16(int offset, Int16 value)
        {
            var data = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) data.Reverse();
            WriteBytes(offset, data);
        }

        public void WriteUInt16(int offset, UInt16 value)
        {
            var data = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            WriteBytes(offset, data);
        }

        public void WriteInt32(int offset, Int32 value)
        {
            var data = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            WriteBytes(offset, data);
        }

        public void WriteUInt32(int offset, UInt32 value)
        {
            var data = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            WriteBytes(offset, data);
        }

        public void WriteSingle(int offset, Single value)
        {
            var data = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(data);
            WriteBytes(offset, data);
        }
    }
}
