using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace captionai
{
    public partial class Registration : Form
    {
        public static string pid = "";
        BaseConnection con = new BaseConnection();
        public Registration()
        {
            InitializeComponent();
        }
        public void getdetails()
        {

            string query = "select (max(userid)+1) from usertb";
            SqlDataReader sd = con.ret_dr(query);
            if (sd.Read())
            {
                pid = sd[0].ToString();
                textBox5.Text = pid;
            }

        }

        public void insertdb()
        {
            string query = "insert into usertb values(" + textBox5.Text + ",'" + textBox1.Text + "','" + name.Text + "','" + pwd.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + textBox4.Text + "')";
            if (con.exec1(query) > 0)
            {
                //MessageBox.Show("Registration successfull....");
                //this.Close();
            }
        }
        public void insertlogin()
        {
            int s = 1;
            string query = "insert into logintb values('" + name.Text + "','" + pwd.Text + "'," + s + ")";
            if (con.exec1(query) > 0)
            {
                MessageBox.Show("Registration successfull....");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertdb();
            insertlogin();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            getdetails();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == false)
            {
                if (e.KeyChar.Equals(Convert.ToChar(Keys.Back)))
                    e.Handled = false;
                else
                    e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar == '.') || (e.KeyChar == '-') || (e.KeyChar == ' '))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
