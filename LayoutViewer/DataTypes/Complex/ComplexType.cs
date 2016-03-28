using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutViewer.DataTypes.Complex
{
    class ComplexType : IDataType
    {
        #region IDataType

        public byte[] Buffer
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public byte[] Get()
        {
            throw new NotImplementedException();
        }

        public void Read(Stream stream)
        {
            throw new NotImplementedException();
        }

        public void Set(byte[] buff)
        {
            throw new NotImplementedException();
        }

        public void Write(Stream stream)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
