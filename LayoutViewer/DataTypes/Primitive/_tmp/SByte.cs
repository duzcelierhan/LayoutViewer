using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutViewer.DataTypes.Primitive
{
    class SByte : PrimitiveTypeBase, IDataType
    {

        public sbyte Value { get; set; }


        #region Constructors

        public SByte(sbyte value)
        {
            this.Value = value;
        }

        public SByte() : this(0) { }

        #endregion

        #region IData Implementation

        public int Length
        {
            get
            {
                return sizeof(sbyte);
            }
        }

        public byte[] Buffer
        {
            get
            {
                return new byte[] { (byte)Value };
            }

            set
            {
                if (value.Length > 0)
                    Value = (sbyte)value[0];
                else
                    Value = 0;
            }
        }

        public byte[] Get()
        {
            return this.Buffer;
        }

        public void Read(Stream stream)
        {
            Value = (sbyte)base.ReadBytes(stream, 1)[0];
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

        #region Operator Overloading

        public static implicit operator sbyte(SByte b)
        {
            return b.Value;
        }

        public static implicit operator SByte(sbyte b)
        {
            return new SByte(b);
        }

        #endregion
    }
}
