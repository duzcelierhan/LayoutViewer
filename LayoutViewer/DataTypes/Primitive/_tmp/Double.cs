using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutViewer.DataTypes.Primitive
{
    class Double : PrimitiveTypeBase, IDataType
    {
        public double Value { get; set; }

        #region Constructors

        public Double(double value)
        {
            this.Value = value;
        }

        public Double() : this(0) { }

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
                return sizeof(double);
            }
        }

        public byte[] Get()
        {
            return this.Buffer;
        }

        public void Read(Stream stream)
        {
            this.Value = BitConverter.ToDouble(base.ReadBytes(stream, Length), 0);
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

        public static implicit operator double(Double b)
        {
            return b.Value;
        }

        public static implicit operator Double(double b)
        {
            return new Double(b);
        }

        #endregion
    }
}
