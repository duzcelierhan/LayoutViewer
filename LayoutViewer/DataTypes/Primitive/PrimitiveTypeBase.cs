using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutViewer.DataTypes.Primitive
{
    public abstract class PrimitiveTypeBase
    {
        public enum TypeNames { Byte, SByte, Short, UShort, Int, UInt, Long, ULong, Double, Float, Decimal }

        #region Fields

        public static Dictionary<Type, TypeNames> typesDict = new Dictionary<Type, TypeNames>
        {
            {typeof(byte),      TypeNames.Byte},
            {typeof(sbyte),     TypeNames.SByte},
            {typeof(short),     TypeNames.Short},
            {typeof(ushort),    TypeNames.UShort},
            {typeof(int),       TypeNames.Int},
            {typeof(uint),      TypeNames.UInt},
            {typeof(long),      TypeNames.Long},
            {typeof(ulong),     TypeNames.ULong},
            {typeof(double),    TypeNames.Double},
            {typeof(float),     TypeNames.Float},
            {typeof(decimal),   TypeNames.Decimal}
        };

        #endregion

        #region Public Methods

        public byte[] ReadBytes(Stream stream, int length)
        {
            byte[] buff = new byte[length];
            int readBytes = Math.Min((int)(stream.Length - stream.Position), length);

            stream.Read(buff, 0, (int)readBytes);

            return buff;
        }

        public void WriteBytes(Stream stream, byte[] buffer)
        {
            stream.Write(buffer, 0, buffer.Length);
        }

        public byte[] Buffer
        {
            get
            {
                return Get();
            }

            set
            {
                Read(new MemoryStream(value));
            }
        }

        public abstract byte[] Get();

        public abstract void Read(Stream stream);

        public abstract int Length { get; }

        public void Write(Stream stream)
        {
            WriteBytes(stream, Buffer);
        }

        public void Set(byte[] buff)
        {
            this.Buffer = buff;
        }

        #endregion
    }
}
