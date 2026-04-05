using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace captionai
{
    public partial class BlocksXOR : Form
    {
        public BlocksXOR()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LookupTable obj = new LookupTable();
            ActiveForm.Hide();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = listBox1.Items.Count;
            for (int j = 0; j < listBox1.Items.Count / 2; j++)
            {
                listBox1.SelectedIndex=j;
                
                
                listBox2.Items.Add(listBox1.SelectedItem.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            String str;
            str=Program.binary;
            int page = 0;
            int pageSize = 128; //
            while (true)
            {
                string subStr = new string(str.Skip(page * pageSize).Take(pageSize).ToArray());
                listBox1.Items.Add(subStr);
                listBox1.Refresh();
                
                page++;

                if (page * pageSize >= str.Length)
                    break;
            }
        }

        private void BlocksXOR_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
