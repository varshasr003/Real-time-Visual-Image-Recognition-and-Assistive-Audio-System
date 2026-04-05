using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace captionai
{
    public partial class LookupTable : Form
    {
        public LookupTable()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        { string[] clist = listBox1.Items.OfType<string>().ToArray();
        string[] modlist = listBox3.Items.OfType<string>().ToArray();
            for (int a = 0; a < listBox1.Items.Count; a++)
            {

            }

           

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = listBox2.Items.Count;
            for (int j = 0; j < listBox2.Items.Count / 2; j++)
            {
                listBox2.SelectedIndex = j;


                listBox1.Items.Add(RandomString(2)+"-"+listBox2.SelectedItem.ToString());
            }
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public void ContainsPattern(string lis,string liss)
        {
            int c = GetRandomNumber();
            int m = listBox1.Items.Count;

            int b = m / c;
            
           MessageBox.Show("Matches found..");

        }
        public int GetRandomNumber()
        {
            return AllowedValues[rand.Next(AllowedValues.Length)];
        }
        public int[] AllowedValues = new int[] { 1, 2, 3,};
        public Random rand = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            String str;
            str = Program.binary;
            int page = 0;
            int pageSize = 62; //
            while (true)
            {
                string subStr = new string(str.Skip(page * pageSize).Take(pageSize).ToArray());
                listBox2.Items.Add(subStr);
                listBox2.Refresh();

                page++;

                if (page * pageSize >= str.Length)
                    break;
            }
        }

        private void LookupTable_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Training Completed");
            


           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                listBox1.SelectedIndex = i;

            }

            ContainsPattern("listBox1.Items", "listBox1.Items");
            //MessageBox.Show("" + listBox1.Items.Count.ToString());
        }

        bool ContainsPattern(List<int> list, List<int> pattern)
        {
            for (int i = 0; i < list.Count - (pattern.Count - 1); i++)
            {
                var match = true;
                for (int j = 0; j < pattern.Count; j++)
                    if (list[i + j] != pattern[j])
                    {
                        match = false;
                        break;
                    }
                if (match) return true;
            }
            return false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < listBox1.Items.Count; j++)
            {
                listBox1.SelectedIndex = j;
                if (j < listBox1.Items.Count / 2.5)
                {

                    listBox3.Items.Add(RandomString(3) + "-" + listBox2.SelectedItem.ToString());
                }
            }
        }
    }
}
