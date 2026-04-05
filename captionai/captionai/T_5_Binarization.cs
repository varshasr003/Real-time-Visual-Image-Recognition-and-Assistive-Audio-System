using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Math;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.Textures;
using AForge;
using System.Drawing.Imaging;


namespace captionai
{
    public partial class T_5_Binarization : Form
    {
        public CannyEdgeDetector filter = new CannyEdgeDetector();

        private byte threshold = 128;
        public static int windowsize = 8;
        public T_5_Binarization()
        {
            InitializeComponent();
            DoAlpha();
        }

        public IFilter Filter
        {
            get { return filter; }
        }
        public void bayerdither()
        {
            Threshold filter = new Threshold();
            filter.ThresholdValue = threshold;
            //  Bitmap.newim
            // Bitmap newImage = filter.Apply((Bitmap)Bitmap.FromFile(Application.StartupPath + "\\Training\\cropped.jpg"));
            Bitmap newImage = Program.croppedimage;
            Bayer.Image = newImage;

        }
        public void cannyf()
        {

            IFilter filler = new SobelEdgeDetector();
            // Bitmap newImage = filler.Apply((Bitmap)Bitmap.FromFile(Program.detectororginalfilepath));
            Bitmap newImage = filler.Apply((Bitmap)alpha.Image);
            canny.Image = newImage;

        }
        private void DoAlpha()
        {
            int threshold = 150;
            this.Cursor = Cursors.WaitCursor;
            //Bitmap newImage = filter.Apply((Bitmap)Bitmap.FromFile(Program.detectororginalfilepath));
           // Bitmap oldBitmap = (Bitmap)Bitmap.FromFile(Application.StartupPath + "\\Training\\cropped.jpg");
            Bitmap oldBitmap =Program.croppedimage;
            Bitmap newBitmap = new Bitmap(oldBitmap.Width, oldBitmap.Height, PixelFormat.Format32bppArgb);

            //A VERY inefficient way to go about this
            for (int y = 0; y < oldBitmap.Height; y++)
            {
                for (int x = 0; x < oldBitmap.Width; x++)
                {

                    int[] sampleGrid = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                    Color color = oldBitmap.GetPixel(x, y);
                    int X = oldBitmap.Width - 1;
                    int Y = oldBitmap.Height - 1;

                    for (int i = 0; i < 9; i++)
                    {
                        Color sample;

                        //SOOOOOOO inefficient!
                        #region Get sample
                        try
                        {
                            switch (i)
                            {
                                //TopLeft
                                case 0:
                                    sample = (x > 0 && y > 0) ? oldBitmap.GetPixel(x - 1, y - 1) : oldBitmap.GetPixel(x, y);
                                    sampleGrid[i] = (sample.R + sample.G + sample.B) / 3;
                                    break;

                                //TopCenter
                                case 1:
                                    sample = (y > 0) ? oldBitmap.GetPixel(x, y - 1) : oldBitmap.GetPixel(x, y);
                                    sampleGrid[i] = (sample.R + sample.G + sample.B) / 3;
                                    break;

                                //TopRight
                                case 2:
                                    sample = (x < X && y > 0) ? oldBitmap.GetPixel(x + 1, y - 1) : oldBitmap.GetPixel(x, y);
                                    sampleGrid[i] = (sample.R + sample.G + sample.B) / 3;
                                    break;

                                //MiddleLeft
                                case 3:
                                    sample = (x > 0) ? sample = oldBitmap.GetPixel(x - 1, y) : oldBitmap.GetPixel(x, y);
                                    sampleGrid[i] = (sample.R + sample.G + sample.B) / 3;
                                    break;

                                //Centerpoint
                                case 4:
                                    sample = oldBitmap.GetPixel(x, y);
                                    sampleGrid[i] = (sample.R + sample.G + sample.B) / 3;
                                    break;

                                //MiddleRight
                                case 5:
                                    sample = (x < X) ? oldBitmap.GetPixel(x + 1, y) : oldBitmap.GetPixel(x, y);
                                    sampleGrid[i] = (sample.R + sample.G + sample.B) / 3;
                                    break;

                                //BottomLeft
                                case 6:
                                    sample = (x > 0 && y < Y) ? oldBitmap.GetPixel(x - 1, y + 1) : oldBitmap.GetPixel(x, y);
                                    sampleGrid[i] = (sample.R + sample.G + sample.B) / 3;
                                    break;

                                //BottomCenter
                                case 7:
                                    sample = (y < Y) ? oldBitmap.GetPixel(x, y + 1) : oldBitmap.GetPixel(x, y);
                                    sampleGrid[i] = (sample.R + sample.G + sample.B) / 3;
                                    break;

                                //BottomRight
                                case 8:
                                    sample = (x < X && y < Y) ? oldBitmap.GetPixel(x + 1, y + 1) : oldBitmap.GetPixel(x, y);
                                    sampleGrid[i] = (sample.R + sample.G + sample.B) / 3;
                                    break;

                                //Should never happen
                                default:
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            ex = ex;
                            sample = oldBitmap.GetPixel(x, y);
                            sampleGrid[i] = (sample.R + sample.G + sample.B) / 3;
                            continue;
                        }
                        #endregion
                    }

                    int A = 0;
                    for (int i = 0; i < 9; i++)
                        A += sampleGrid[i];

                    A = 255 - (A / 9);
                    if (A > threshold)
                        A = 255;

                    newBitmap.SetPixel(x, y, Color.FromArgb(A, color));
                }
            }

            alpha.Image = newBitmap;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bayerdither();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cannyf();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.canny = (Bitmap)canny.Image;
            T_6_HOG obj = new T_6_HOG();
            ActiveForm.Hide();
            obj.Show();
        }
    }
}
