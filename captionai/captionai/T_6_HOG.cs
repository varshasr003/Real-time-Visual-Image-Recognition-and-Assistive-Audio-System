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

using AForge.Math;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.Textures;
using AForge;

namespace captionai
{
    public partial class T_6_HOG : Form
    {
        private byte threshold = 128;
        public static int windowsize = 8;
        public T_6_HOG()
        {
            InitializeComponent();
            canny.Image = (System.Drawing.Image)Program.canny;
            //  Bitmap newImage = (Bitmap)Bitmap.FromFile(Application.StartupPath + "\\Training\\cropped.jpg");
            Bitmap newImage = Program.croppedimage;
            Program.blackImage = new Bitmap(newImage.Width, newImage.Height);
            imageToByteArray(canny.Image);
        }

        public void imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            OrientationImage newImg = FromByteArray(ms.ToArray());
            byte[] finalarray = ToByteArray(newImg);
            MemoryStream ms1 = new MemoryStream(finalarray);

            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms1);
            hogcanny.Image = returnImage;
            Show(newImg, Graphics.FromImage(hogcanny.Image));
            newimage(newImg);


        }

        public void newimage(OrientationImage orImg)
        {

            Graphics g = Graphics.FromImage(Program.blackImage);

            int lineLength = windowsize / 2;
            Pen greenPen = new Pen(Brushes.Green) { Width = 2 };
            Pen redPen = new Pen(Brushes.Red) { Width = 2 };
            Pen currentPen;

            for (int i = 0; i < orImg.Height; i++)
                for (int j = 0; j < orImg.Width; j++)
                {
                    double angle;
                    if (orImg.IsNullBlock(i, j))
                    {
                        currentPen = redPen;
                        angle = 0;
                    }
                    else
                    {
                        currentPen = greenPen;
                        angle = orImg.AngleInRadians(i, j);
                    }
                    //double angle = orImg.IsNullBlock(i, j) ? 0 : orImg.AngleInRadians(i, j);
                    int x = j * windowsize + windowsize / 2;
                    int y = i * windowsize + windowsize / 2;

                    Point p0 = new Point
                    {
                        X = Convert.ToInt32(x - lineLength * Math.Cos(angle)),
                        Y = Convert.ToInt32(y - lineLength * Math.Sin(angle))
                    };

                    Point p1 = new Point
                    {
                        X = Convert.ToInt32(x + lineLength * Math.Cos(angle)),
                        Y = Convert.ToInt32(y + lineLength * Math.Sin(angle))
                    };

                    g.DrawLine(currentPen, p0, p1);
                }
            hogpattern.Image = Program.blackImage;


        }
        public void Show(OrientationImage orImg, Graphics g)
        {

            // int lineLength = orImg.WindowSize / 2;
            int lineLength = windowsize / 2;
            Pen greenPen = new Pen(Brushes.Green) { Width = 2 };
            Pen redPen = new Pen(Brushes.Red) { Width = 2 };
            Pen currentPen;

            for (int i = 0; i < orImg.Height; i++)
                for (int j = 0; j < orImg.Width; j++)
                {
                    double angle;
                    if (orImg.IsNullBlock(i, j))
                    {
                        currentPen = redPen;
                        angle = 0;
                    }
                    else
                    {
                        currentPen = greenPen;
                        angle = orImg.AngleInRadians(i, j);
                    }
                    //double angle = orImg.IsNullBlock(i, j) ? 0 : orImg.AngleInRadians(i, j);
                    int x = j * windowsize + windowsize / 2;
                    int y = i * windowsize + windowsize / 2;

                    Point p0 = new Point
                    {
                        X = Convert.ToInt32(x - lineLength * Math.Cos(angle)),
                        Y = Convert.ToInt32(y - lineLength * Math.Sin(angle))
                    };

                    Point p1 = new Point
                    {
                        X = Convert.ToInt32(x + lineLength * Math.Cos(angle)),
                        Y = Convert.ToInt32(y + lineLength * Math.Sin(angle))
                    };

                    g.DrawLine(currentPen, p0, p1);
                    // showgridlines(orImg, g);
                }
        }
        public static byte[] ToByteArray(OrientationImage orImg)
        {
            byte[] bytes = new byte[orImg.Width * orImg.Height + 3];
            bytes[0] = orImg.WindowSize;
            bytes[1] = orImg.Height;
            bytes[2] = orImg.Width;
            int k = 3;
            for (int i = 0; i < orImg.Height; i++)
                for (int j = 0; j < orImg.Width; j++)
                    if (orImg.IsNullBlock(i, j))
                        bytes[k++] = 255;
                    else
                        bytes[k++] = Convert.ToByte(Math.Round(orImg.AngleInRadians(i, j) * 180 / Math.PI));
            return bytes;
        }

        public static OrientationImage FromByteArray(byte[] bytes)
        {
            byte height = bytes[1];
            byte width = bytes[2];
            byte[,] orientations = new byte[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i * width + j + 3 < bytes.Length)
                    {
                        orientations[i, j] = Convert.ToByte(bytes[i * width + j + 3]);
                    }
                }
            }

            OrientationImage orImg = new OrientationImage(width, height, orientations, bytes[0]);
            return orImg;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.hog = (Bitmap)hogpattern.Image;
            TrainingFinal obj=new TrainingFinal();
           // T_7_SaveImages obj = new T_7_SaveImages();
            ActiveForm.Hide();
            obj.Show();
        }
    }
}
