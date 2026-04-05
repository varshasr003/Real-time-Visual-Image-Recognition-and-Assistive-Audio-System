using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;


namespace captionai
{
    public partial class T_2_ImageCropping : Form
    {
        private Image _originalImage;
        private bool _selecting;
        private Rectangle _selection;
        private Image Img;
        private Size OriginalImageSize;
        private Size ModifiedImageSize;
        int cropX;
        int cropY;
        int cropWidth;
        int cropHeight;
        int oCropX;
        int oCropY;
        public Pen cropPen;
        public DashStyle cropDashStyle = DashStyle.DashDot;
        public bool Makeselection = false;
        public bool CreateText = false;

        public T_2_ImageCropping()
        {
            InitializeComponent();
        }
        public T_2_ImageCropping(string orgfilepath)
        {
            InitializeComponent();
            picMRI.ImageLocation = orgfilepath;
            PictureBox1.ImageLocation = orgfilepath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Makeselection = true;
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            if (Makeselection)
            {

                try
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        Cursor = Cursors.Cross;
                        cropX = e.X;
                        cropY = e.Y;

                        cropPen = new Pen(Color.Yellow, 1);
                        cropPen.DashStyle = DashStyle.DashDotDot;


                    }
                    PictureBox1.Refresh();
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            Cursor = Cursors.Default;
            if (Makeselection)
            {

                try
                {
                    if (PictureBox1.Image == null)
                        return;


                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        PictureBox1.Refresh();
                        cropWidth = e.X - cropX;
                        cropHeight = e.Y - cropY;
                        PictureBox1.CreateGraphics().DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight);
                    }



                }
                catch (Exception ex)
                {
                    //if (ex.Number == 5)
                    //    return;
                }
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (Makeselection)
            {
                Cursor = Cursors.Default;

            }
        }

        private void PictureBoxLocation()
        {
            int _x = 0;
            int _y = 0;
            if (splitContainer1.Panel1.Width > PictureBox1.Width)
            {
                _x = (splitContainer1.Panel1.Width - PictureBox1.Width) / 2;
            }
            if (splitContainer1.Panel1.Height > PictureBox1.Height)
            {
                _y = (splitContainer1.Panel1.Height - PictureBox1.Height) / 2;
            }
            PictureBox1.Location = new Point(_x, _y);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (cropWidth < 1)
                {
                    return;
                }
                Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
                //First we define a rectangle with the help of already calculated points
                Bitmap OriginalImage = new Bitmap(PictureBox1.Image, PictureBox1.Width, PictureBox1.Height);
                //Original image
                Bitmap _img = new Bitmap(cropWidth, cropHeight);
                // for cropinf image
                Graphics g = Graphics.FromImage(_img);
                // create graphics
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                //set image attributes
                g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);

                PictureBox1.Image = _img;
                PictureBox1.Width = _img.Width;
                PictureBox1.Height = _img.Height;
                PictureBoxLocation();

            }
            catch (Exception ex)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

           // SaveFile();
            Program.croppedimage = (Bitmap)PictureBox1.Image;
            T_3_DataAugmentation_Rotate obj = new T_3_DataAugmentation_Rotate();
           // T_3_DataAugmentation_Flip obj = new T_3_DataAugmentation_Flip();
            ActiveForm.Hide();
            obj.Show();

        }
        public void SaveFile()
        {

            Bitmap bmp1 = new Bitmap(PictureBox1.Image);

            if (System.IO.File.Exists(Application.StartupPath + "\\Training\\cropped.jpg"))
            {
                System.IO.File.Delete(Application.StartupPath + "\\Training\\cropped.jpg");
            }

            bmp1.Save(Application.StartupPath + "\\Training\\cropped.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            // Dispose of the image files.
            bmp1.Dispose();
        }
    }
}
