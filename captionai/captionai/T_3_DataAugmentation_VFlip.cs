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
    public partial class T_3_DataAugmentation_VFlip : Form
    {
        public T_3_DataAugmentation_VFlip()
        {
            InitializeComponent();
            pictureBox1.Image = (Image)Bitmap.FromFile(Application.StartupPath + "\\Training\\cropped.jpg");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Bitmap c = (Bitmap)Bitmap.FromFile(Application.StartupPath + "\\Training\\cropped.jpg");
            Bitmap cimage = c;
            cimage.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pictureBox2.Image = (Image)cimage;
            Program.vflipimage = (Bitmap)pictureBox2.Image;
        }

        public void SaveFile()
        {

            Bitmap bmp1 = new Bitmap(pictureBox2.Image);

            if (System.IO.File.Exists(Application.StartupPath + "\\Training\\vflip.jpg"))
            {
                System.IO.File.Delete(Application.StartupPath + "\\Training\\vflip.jpg");
            }

            bmp1.Save(Application.StartupPath + "\\Training\\vflip.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            // Dispose of the image files.
            bmp1.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFile();
            T_3_DataAugmentation_Rotate obj = new T_3_DataAugmentation_Rotate();
            ActiveForm.Hide();
            obj.Show();
        }
    }
}
