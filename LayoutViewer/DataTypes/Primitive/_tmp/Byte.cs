using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutViewer.DataTypes.Primitive
{
    class Byte : PrimitiveTypeBase, IDataType
    {
        public byte Value { get; set; }

        #region IDataType Implementation

        public int Length { get { return 1; } }

        public byte[] Buffer
        {
            get
            {
                return new byte[] { Value };
            }

            set
            {
                if (value.Length > 0)
                    Value = value[0];
                else
                    Value = 0;
            }
        }
        public void Read(Stream stream)
        {
            Value = ReadBytes(stream, 1)[0];
        }

        public void Write(Stream stream)
        {
            base.WriteBytes(stream, this.Buffer);
        }

        public void Set(byte[] buff)
        {
            this.Buffer = buff;
        }

        public byte[] Get()
        {
            return this.Buffer;
        }

        #endregion

        #region Constructors

        public Byte(byte b)
        {
            this.Value = b;
        }

        public Byte() : this(0) { }

        #endregion

        #region Operators

        public static implicit operator byte(Byte b)
        {
            return b.Value;
        }

        public static implicit operator Byte(byte b)
        {
            return new Byte(b);
        }


        #endregion
    }
}
