using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LayoutViewer.DataTypes.Primitive
{
    public class PrimitiveType<T> : PrimitiveTypeBase, IDataType
    {
        #region Properties

        public T Value { get; set; }

        #endregion

        #region Fields



        #endregion

        #region Constructors

        public PrimitiveType(T value)
        {
            if (!typesDict.ContainsKey(typeof(T)))
                throw new ArgumentException($"Generic type is not supported: {typeof(T).FullName}");

            Value = value;
        }

        public PrimitiveType() : this(default(T)) { }

        #endregion

        #region IDataType Implementation

        public override int Length
        {
            get
            {
                return Marshal.SizeOf(default(T));
            }
        }

        public override byte[] Get()
        {
            return BitConverter.GetBytes((dynamic)Value);
        }

        public override void Read(Stream stream)
        {
            byte[] buff = base.ReadBytes(stream, Length);
            object value;

            switch (typesDict[typeof(T)])
            {
                case TypeNames.Byte:
                case TypeNames.SByte:
                    value = buff[0];
                    break;
                case TypeNames.Short:
                    value = BitConverter.ToInt16(buff, 0);
                    break;
                case TypeNames.UShort:
                    value = BitConverter.ToUInt16(buff, 0);
                    break;
                case TypeNames.Int:
                    value = BitConverter.ToInt32(buff, 0);
                    break;
                case TypeNames.UInt:
                    value = BitConverter.ToUInt32(buff, 0);
                    break;
                case TypeNames.Long:
                    value = BitConverter.ToInt64(buff, 0);
                    break;
                case TypeNames.ULong:
                    value = BitConverter.ToUInt64(buff, 0);
                    break;
                case TypeNames.Double:
                    value = BitConverter.ToDouble(buff, 0);
                    break;
                case TypeNames.Float:
                    value = BitConverter.ToSingle(buff, 0);
                    break;
                case TypeNames.Decimal:
                    value = new decimal(
                        new int[] {
                            BitConverter.ToInt32(buff, 0),
                            BitConverter.ToInt32(buff, 4),
                            BitConverter.ToInt32(buff, 8),
                            BitConverter.ToInt32(buff, 12)
                            }
                        );
                    break;
                default:
                    throw new ArgumentException($"Generic type is not supported: {typeof(T).FullName}");
            }

            this.Value = (T)value;
        }

        #endregion

        #region Operator Overloads

        public static implicit operator T(PrimitiveType<T> inst)
        {
            return inst.Value;
        }

        public static implicit operator PrimitiveType<T>(T val)
        {
            return new PrimitiveType<T>(val);
        }

        #endregion
    }
}
