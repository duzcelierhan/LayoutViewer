using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutViewer.DataTypes.Primitive
{
    class UInt : PrimitiveTypeBase, IDataType
    {
        public uint Value { get; set; }

        #region Constructors

        public UInt(uint value)
        {
            this.Value = value;
        }

        public UInt() : this(0) { }

        #endregion

        #region IDataType Implementation

        public byte[] Buffer
        {
            get
            {
                return BitConverter.GetBytes(this.Value);
            }

            set
            {
                Read(new MemoryStream(value));
            }
        }

        public int Length
        {
            get
            {
                return sizeof(uint);
            }
        }

        public byte[] Get()
        {
            return this.Buffer;
        }

        public void Read(Stream stream)
        {
            this.Value = BitConverter.ToUInt32(base.ReadBytes(stream, Length), 0);
        }

        public void Set(byte[] buff)
        {
            this.Buffer = buff;
        }

        public void Write(Stream stream)
        {
            base.WriteBytes(stream, this.Buffer);
        }

        #endregion

        #region Operator Overloads

        public static implicit operator uint(UInt b)
        {
            return b.Value;
        }

        public static implicit operator UInt(uint b)
        {
            return new UInt(b);
        }

        #endregion
    }
}
