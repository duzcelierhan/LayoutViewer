using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutViewer.DataTypes
{
    public interface IDataType
    {
        int Length { get; }
        void Read(Stream stream);
        void Write(Stream stream);
        void Set(byte[] buff);
        byte[] Get();
        byte[] Buffer { get; set; }
    }
}
