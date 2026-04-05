using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace captionai
{
    public partial class T_7_SaveImages : Form
    {
        public T_7_SaveImages()
        {
            InitializeComponent();
            pictureBox7.Image = (Image)Image.FromFile(Program.OrginalFilePath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnnrnn obj = new cnnrnn();

            Bitmap finalbmp = obj.cnnlayer(txtobjects.Text + Program.ccap + txtcaption.Text, (Bitmap)Bitmap.FromFile(Program.OrginalFilePath));
            pictureBox7.Image = (Bitmap)finalbmp;

            SaveFile();
            MessageBox.Show("File saved");
            this.Close();
        }

        public void SaveFile()
        {
            string[] filelist = Directory.GetFiles(Application.StartupPath + "\\dataset", "*.png");
            int i = filelist.Length;
            i++;
            Bitmap bmp1 = new Bitmap(pictureBox7.Image);
            bmp1.Save(Application.StartupPath + "\\dataset\\dataset_" + i.ToString() + ".png", ImageFormat.Png);

            string[] filelist1 = Directory.GetFiles(Application.StartupPath + "\\Temp", "*.png");
            int i1 = filelist.Length;
            i1++;
            Bitmap bmp2 = Program.croppedimage;
            bmp2.Save(Application.StartupPath + "\\Temp\\" + i1.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            i1++;
            bmp2 = Program.canny;
            bmp2.Save(Application.StartupPath + "\\Temp\\" + i1.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            i1++;
            bmp2 = Program.hflipimage;
            bmp2.Save(Application.StartupPath + "\\Temp\\" + i1.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);


            i1++;
            bmp2 = Program.vflipimage;
            bmp2.Save(Application.StartupPath + "\\Temp\\" + i1.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            i1++;
            bmp2 = Program.hog;
            bmp2.Save(Application.StartupPath + "\\Temp\\" + i1.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp1.Dispose();

            i1++;
            bmp2 = Program.a1;
            bmp2.Save(Application.StartupPath + "\\Temp\\" + i1.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp1.Dispose();

            i1++;
            bmp2 = Program.a2;
            bmp2.Save(Application.StartupPath + "\\Temp\\" + i1.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp1.Dispose();

            i1++;
            bmp2 = Program.a3;
            bmp2.Save(Application.StartupPath + "\\Temp\\" + i1.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp1.Dispose();

            i1++;
            bmp2 = Program.a4;
            bmp2.Save(Application.StartupPath + "\\Temp\\" + i1.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp1.Dispose();


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
