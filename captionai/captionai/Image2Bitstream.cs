using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace captionai
{
    public partial class Image2Bitstream : Form
    {
        public Image2Bitstream()
        {
            InitializeComponent();
            pictureBox1.Image = System.Drawing.Image.FromFile(Program.orgfilepath);
          
        }
        public string imagetobase64(Image simage, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                simage.Save(ms, ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = imagetobase64(pictureBox1.Image, ImageFormat.Png);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BlockDivision obj = new BlockDivision(textBox1.Text);
            ActiveForm.Hide();
            obj.Show();
        }
    }
}
