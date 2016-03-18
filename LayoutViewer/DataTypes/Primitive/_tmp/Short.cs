using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutViewer.DataTypes.Primitive
{
    class Short : PrimitiveTypeBase, IDataType
    {
        public short Value { get; set; }

        #region Constructors

        public Short(short value)
        {
            this.Value = value;
        }

        public Short() : this(0) { }

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
                return sizeof(short);
            }
        }

        public byte[] Get()
        {
            return this.Buffer;
        }

        public void Read(Stream stream)
        {
            this.Value = BitConverter.ToInt16(base.ReadBytes(stream, 2), 0);
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

        public static implicit operator short(Short b)
        {
            return b.Value;
        }

        public static implicit operator Short(short b)
        {
            return new Short(b);
        }

        #endregion
    }
}
