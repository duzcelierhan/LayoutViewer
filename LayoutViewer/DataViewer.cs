using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Be.Windows.Forms;
using LayoutViewer.DataTypes;

namespace LayoutViewer
{
    public partial class DataViewer : UserControl
    {
        IDataType data;
        DataGridViewTextBoxCell columnTemplate;

        public DataViewer(IDataType data)
        {
            this.data = data;
            InitializeComponent();
            Init();
            //FormatDataGrid();
        }

        public void ShowData()
        {
            byte[] buff = this.data.Buffer;

        }

        //private void FormatDataGrid()
        //{
        //    for (int i = 0; i < 16; i++)
        //    {
        //        DataGridViewColumn col = new DataGridViewColumn();
        //        col.CellTemplate = columnTemplate;
        //        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        //        col.DividerWidth = 1;
        //        col.Resizable = DataGridViewTriState.False;
        //        col.ValueType = typeof(byte);
        //        col.Width = 25;

        //        dataGridView1.Columns.Add(col);
        //    }
        //}

        private void Init()
        {
            //columnTemplate = new DataGridViewTextBoxCell();
            //columnTemplate.ValueType = typeof(byte);
            this.hexBox1.ByteProvider = new DynamicByteProvider(this.data.Buffer);
            
            MessageBox.Show($"Vertical Byte Count: {hexBox1.VerticalByteCount}\r\nHorizontal Byte Count: {hexBox1.HorizontalByteCount}");
        }
    }
}
