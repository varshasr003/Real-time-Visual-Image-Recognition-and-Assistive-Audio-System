using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace captionai
{
    public partial class UserHome : Form
    {
        public UserHome()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            D_1_ImageUpload obj = new D_1_ImageUpload();
            obj.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            CaptureImage obj = new CaptureImage();
            obj.Show();
        }
    }
}
