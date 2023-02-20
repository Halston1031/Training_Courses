using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventSamples
{
    public partial class Form1 : Form
    {
        private MyClass obj;
        public Form1()
        {
            InitializeComponent();
            obj = new MyClass();
            obj.XChanged += Obj_XChanged;
        }
        private void Obj_XChanged(object sender, EventArgs e)
        {
            MessageBox.Show("x 的值改變了");
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            obj.X += 1;
        }
    }
}
