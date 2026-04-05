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
    public partial class BlockDivision : Form
    {
        public static string t = "";
        public BlockDivision()
        {
            InitializeComponent();
        }
        public BlockDivision(string text)
        {
            InitializeComponent();
            t = text;
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] buf = encoding.GetBytes(textBox1.Text);

            StringBuilder binaryStringBuilder = new StringBuilder();
            foreach (byte b in buf)
            {
                binaryStringBuilder.Append(Convert.ToString(b, 2));
            }
           // Console.WriteLine(binaryStringBuilder.ToString());
            textBox2.Text = binaryStringBuilder.ToString();
            label5.Text = "Digit Count : " + textBox2.Text.Length;
            Program.bitcode = textBox2.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String str = textBox2.Text;
            Program.binary = str;
            int page = 0;
            int pageSize = 128; //
            while (true)
            {
                string subStr = new string(str.Skip(page * pageSize).Take(pageSize).ToArray());
                listBox1.Items.Add(subStr);
                listBox1.Refresh();
                label4.Text = "Block Count : " + listBox1.Items.Count;


                page++;

                if (page * pageSize >= str.Length)
                    break;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = t;
            timer1.Enabled = false;
        }

        private void BlockDivision_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BlocksXOR obj = new BlocksXOR();
            ActiveForm.Hide();
            obj.Show();
        }
    }
}
