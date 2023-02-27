using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Migrations;

namespace EntityFramework
{
    public partial class ModifyForm : Form
    {
        public ModifyForm()
        {
            InitializeComponent();
        }
        private void ClearTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Models i = new Models();
            var data = i.ItemTable.ToList().First(x => x.Id == int.Parse(textBox1.Text.Trim()));
            try
            {
                data.Name = textBox2.Text.Trim();
                data.Quantity = int.Parse(textBox3.Text);
                data.Price = decimal.Parse(textBox4.Text);
                data.Type = textBox5.Text.Trim();
                i.ItemTable.AddOrUpdate(data);
                i.SaveChanges();
                MessageBox.Show($"update success!");
                ClearTextBoxes();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message); 
            }

        }
    }
}
