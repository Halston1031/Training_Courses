using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(Button1_Click);
            button2.Click += new EventHandler(Button2_Click); //hand write this, otherwise just double click the button, then can don't write
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Calculate(true);
        }

        private void Calculate(bool isAdd)
        {
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            if (!isAdd)
            {
                y = -y;
            }
            label1.Text = (x + y).ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Calculate(false);
        }
    }
}
