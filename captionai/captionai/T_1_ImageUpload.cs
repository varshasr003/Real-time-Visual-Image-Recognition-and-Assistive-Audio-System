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
    public partial class T_1_ImageUpload : Form
    {
        public T_1_ImageUpload()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            // openFileDialog1.Filter = "Image Files|*.png;...";

            DialogResult result = openFileDialog1.ShowDialog();


            if (result == DialogResult.OK) // Test result.
            {
                textBox1.Text = openFileDialog1.FileName.ToString();
                pictureBox1.ImageLocation = textBox1.Text;
                Program.OrginalFilePath = textBox1.Text;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //T_2_ImageCropping obj = new T_2_ImageCropping(Program.OrginalFilePath);

            //ActiveForm.Hide();
            //obj.Show();

            Program.croppedimage = (Bitmap)pictureBox1.Image;
            T_3_DataAugmentation_Rotate obj = new T_3_DataAugmentation_Rotate();
            // T_3_DataAugmentation_Flip obj = new T_3_DataAugmentation_Flip();
            ActiveForm.Hide();
            obj.Show();
        }
    }
}
