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
    public partial class Startup : Form
    {
        BaseConnection con = new BaseConnection();
        public Startup()
        {
            InitializeComponent();
        }

        private void Startup_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
//           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usertype = "";
            
                string query = "select * from logintb where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
                SqlDataReader dr = con.ret_dr(query);
            if (dr.Read())
            {
                Program.userid = dr[0].ToString();
                usertype = dr[2].ToString();

                if (usertype == "0")
                {
                    Admin_Home obj = new Admin_Home();
                    ActiveForm.Hide();
                    obj.Show();


                }
                else if (usertype == "1")
                {

                    Student_Home obj = new Student_Home();
                    ActiveForm.Hide();
                    obj.Show();
                }
                else
                {
                    MessageBox.Show("Invalid user.....");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Invalid user.....");
                textBox1.Text = "";
                textBox2.Text = "";
            }

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Registration obj = new Registration();
           // ActiveForm.Hide();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text ="";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
