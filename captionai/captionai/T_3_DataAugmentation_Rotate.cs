using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging;
using AForge.Imaging.Filters;


namespace captionai
{
    public partial class T_3_DataAugmentation_Rotate : Form
    {
        private FilterRotate filter = null;
        private FilterRotate filter1 = null;
        private FilterRotate filter2 = null;
        private FilterRotate filter3 = null;
        private System.Drawing.Bitmap backup = null;
        private System.Drawing.Bitmap image = null;
        private string fileName = null;
        private int width;
        private int height;
        private float zoom = 1;
        private IDocumentsHost host = null;
        private bool cropping = false;
        private bool dragging = false;
        private Point start, end, startW, endW;
        public T_3_DataAugmentation_Rotate()
        {
            InitializeComponent();
           // pictureBox1.Image = (System.Drawing.Image)Bitmap.FromFile(Application.StartupPath + "\\Training\\cropped.jpg");
            pictureBox1.Image = Program.croppedimage;
        }

        private void ApplyFilter1(IFilter filter, IFilter filter1, IFilter filter2, IFilter filter3)
        {
            try
            {
               // Bitmap c = (Bitmap)Bitmap.FromFile(Application.StartupPath + "\\Training\\cropped.jpg");
                Bitmap c = Program.croppedimage;
                // set wait cursor
                this.Cursor = Cursors.WaitCursor;
                Bitmap nimage = c;
                Bitmap newImage = filter.Apply(nimage);
                pictureBox2.Image = (System.Drawing.Image)newImage;
                Program.a1 = (Bitmap)pictureBox2.Image;

                Bitmap newImage1 = filter1.Apply(nimage);
                pictureBox3.Image = (System.Drawing.Image)newImage1;
                Program.a2 = (Bitmap)pictureBox3.Image;


                Bitmap newImage2 = filter2.Apply(nimage);
                pictureBox5.Image = (System.Drawing.Image)newImage2;
                Program.a3 = (Bitmap)pictureBox5.Image;


                Bitmap newImage3 = filter3.Apply(nimage);
                pictureBox4.Image = (System.Drawing.Image)newImage3;
                Program.a4 = (Bitmap)pictureBox4.Image;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Selected filter can not be applied to the image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // restore cursor
                this.Cursor = Cursors.Default;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int angle1 = rnd.Next(10, 80);  // creates a number between 1 and 12
            int angle2 = rnd.Next(100, 165);   // creates a number between 1 and 6
            int angle3 = rnd.Next(185, 265);  // creates a number between 1 and 12
            int angle4 = rnd.Next(275, 355);

            textBox1.Text = angle1.ToString();
            textBox2.Text = angle2.ToString();
            textBox3.Text = angle3.ToString();
            textBox4.Text = angle4.ToString();

            //double angle = double.Parse(angleBox.Text);
            filter = new RotateBilinear(angle1);
            filter1 = new RotateBilinear(angle2);
            filter2 = new RotateBilinear(angle3);
            filter3 = new RotateBilinear(angle4);
            ApplyFilter1(filter, filter1, filter2, filter3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            T_5_Binarization obj = new T_5_Binarization();
            ActiveForm.Hide();
            obj.Show();
        }

        private void ApplyFilter(IFilter filter)
        {
            try
            {
                // set wait cursor
                this.Cursor = Cursors.WaitCursor;

                // apply filter to the image
                Bitmap newImage = filter.Apply(image);

                if (host.CreateNewDocumentOnChange)
                {
                    // open new image in new document
                    host.NewDocument(newImage);
                }
                else
                {
                    if (host.RememberOnChange)
                    {
                        // backup current image
                        if (backup != null)
                            backup.Dispose();

                        backup = image;
                    }
                    else
                    {
                        // release current image
                        image.Dispose();
                    }

                    image = newImage;

                    // update
                    UpdateNewImage();
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Selected filter can not be applied to the image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // restore cursor
                this.Cursor = Cursors.Default;
            }
        }
        private void UpdateNewImage()
        {
            // update size
            UpdateSize();
            // repaint
            Invalidate();


        }
        private void UpdateSize()
        {
            // image dimension
            width = image.Width;
            height = image.Height;

            // scroll bar size
            this.AutoScrollMinSize = new Size((int)(width * zoom), (int)(height * zoom));
        }
    }
}
