using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LayoutViewer.DataTypes.Primitive;

namespace LayoutViewer
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
            Trial();
        }

        public void Trial()
        {
            PrimitiveType<int> val1 = new PrimitiveType<int>((int)0x7EFDCBA9);
            PrimitiveType<ulong> val2 = new PrimitiveType<ulong>(0xFEDCBA9876543210);
            PrimitiveType<byte> val3 = new PrimitiveType<byte>(0xAB);

            listBox1.Items.Add(new DataViewer(val1));
            listBox1.Items.Add(new DataViewer(val2));
            listBox1.Items.Add(new DataViewer(val3));

            this.Controls.Add(new DataViewer(val2));
        }
    }
}
