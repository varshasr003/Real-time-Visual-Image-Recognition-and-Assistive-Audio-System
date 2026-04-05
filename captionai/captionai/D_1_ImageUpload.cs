using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace captionai
{
    public partial class D_1_ImageUpload : Form
    {
        public D_1_ImageUpload()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string path = Application.StartupPath + "\\dataset";
            openFileDialog1.InitialDirectory = path;
            openFileDialog1.Filter = "Image Files|*.png;...";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                textBox1.Text = openFileDialog1.FileName.ToString();
                pictureBox1.ImageLocation = textBox1.Text;
                Program.detectionFilePath = textBox1.Text;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
