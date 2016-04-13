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
        private Enums.LengthType _lengthType;
        private Enums.ElementsType _elementsType;
        private XmlNode _xmlNode;

        #endregion

        #region Constructor(s)

        public ComplexType(XmlNode xmlElement)
        {
            _xmlNode = xmlElement;
            Initialize();
        }

        #endregion

        #region Public Methods

        public void Parse()
        {
            
        }

        public XmlElement SerializeType(XmlDocument xmlDoc)
        {
            XmlElement node = xmlDoc.CreateElement("Complex");
            XmlAttribute name = xmlDoc.CreateAttribute("name");
            XmlAttribute ltype = xmlDoc.CreateAttribute("ltype");
            XmlAttribute etype = xmlDoc.CreateAttribute("etype");

            name.Value = this.Name;
            ltype.Value = this._lengthType.ToString();
            etype.Value = this._elementsType.ToString();

            node.Attributes.Append(name);
            node.Attributes.Append(ltype);
            node.Attributes.Append(etype);

            foreach (IDataType dataType in this._dataTypes)
            {
                node.AppendChild(dataType.SerializeType(xmlDoc));
            }

            return node;
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
            if (this._lengthType == Enums.LengthType.Fixed)
                stream.Read(this.Buffer, 0, this.Length);
            else
            {
                throw new NotImplementedException("Dynamic length buffer read is not implemented yet");
            }
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
            Enums.LengthType.TryParse(_xmlNode.Attributes?["ltype"]?.Value ?? "Fixed", true, out this._lengthType);
            Enums.ElementsType.TryParse(_xmlNode.Attributes?["etype"]?.Value ?? "Fixed", true, out this._elementsType);
        }

        #endregion
    }
}
