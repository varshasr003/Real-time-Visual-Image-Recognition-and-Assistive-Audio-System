using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace captionai
{
    public partial class Student_Home : Form
    {
        BaseConnection con = new BaseConnection();
        public Student_Home()
        {
            InitializeComponent();
           // Program.username = "anu123";
            //Program.picpath = Application.StartupPath + "\\ProfilePictures\\Thumbnails\\106.jpg";
           // toolStripButton8.Image = (Image)Image.FromFile(Program.picpath);
          //  toolStripButton8.Text = "Welcome " + Program.username;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

           
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            StudentViewNotes obj = new StudentViewNotes();
            obj.Show();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            CaptureImage obj = new CaptureImage();
            obj.Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
