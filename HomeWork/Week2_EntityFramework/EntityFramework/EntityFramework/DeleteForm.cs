using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFramework
{
    public partial class DeleteForm : Form
    {
        public DeleteForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Models i = new Models();
            var data = i.ItemTable.Find(int.Parse(textBox1.Text));
            try
            {
                if (data != null)
                {
                    i.ItemTable.Remove(data);
                    i.SaveChanges();
                    MessageBox.Show(data.Name + " delete success!");
                    ClearTextBoxes();
                }
                else
                {
                    MessageBox.Show("無此商品，請輸入已存在商品ID");
                }

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message); 
            }

        }
        private void ClearTextBoxes()
        {
            textBox1.Clear();
        }
    }
}
