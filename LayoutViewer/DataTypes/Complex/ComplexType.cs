using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LayoutViewer.DataTypes.Complex
{
    class ComplexType : IDataType
    {
        #region Fields

        private byte[] _buffer;
        private readonly List<IDataType> _dataTypes = new List<IDataType>();
        private LengthType _lengthType;
        private XmlNode _xmlNode;

        #endregion

        #region Constructor(s)

        public ComplexType(XmlNode xmlElement)
        {
            _xmlNode = xmlElement;
            Initialize();
        }

        #endregion

        #region Inner Types

        enum LengthType
        {
            Fixed = 0x01,
            Dynamic = 0x02
        };

        #endregion

        #region Public Methods

        public void Parse()
        {
            
        }

        #endregion

        #region Properties

        public List<IDataType> DataTypes => _dataTypes;

        #endregion

        #region IDataType

        public byte[] Buffer
        {
            get { return _buffer; }

            set { _buffer = value; }
        }

        public int Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name { get; set; }

        public byte[] Get()
        {
            return Buffer;
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

        #region Private Methods

        private void Initialize()
        {
            if(_xmlNode.Name != "Complex")
                throw new ArgumentException("Invalid Xml Node type");

            this.Name = _xmlNode.Attributes?["name"]?.Value;
        }

        #endregion
    }
}
