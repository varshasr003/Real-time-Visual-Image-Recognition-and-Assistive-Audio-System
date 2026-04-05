using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace captionai
{
    public partial class Login : Form
    {
        BaseConnection con = new BaseConnection();
        public Login()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParms = base.CreateParams;
                handleParms.ExStyle |= 0x02000000;
                return handleParms;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select * from logintb where username='" + user.Text + "'";
            SqlDataReader sdr = con.ret_dr(query);
            if (sdr.Read())
            {
                if (user.Text == sdr[0].ToString() && pwd.Text == sdr[1].ToString())
                {
                    if (sdr[2].ToString() == "1".ToString())
                    {

                        UserHome obj = new UserHome();
                        ActiveForm.Hide();
                        obj.Show();

                    }
                    else if (sdr[2].ToString() == "0".ToString())
                    {
                        //Basepapge obj = new Basepapge();
                        //ActiveForm.Hide();
                        //obj.Show();
                    }
                    else
                    {
                        MessageBox.Show("invalid user ");
                    }

                }
                else
                {
                    MessageBox.Show("invalid user ");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration obj = new Registration();
            obj.Show();
        }
    }
}
