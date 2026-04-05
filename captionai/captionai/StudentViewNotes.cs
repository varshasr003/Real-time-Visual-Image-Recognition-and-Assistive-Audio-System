using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace captionai
{
    public partial class StudentViewNotes: Form
    {
        string tessDataPath = Application.StartupPath + @"\tessdata";
        string selectedImagePath = "";
        public StudentViewNotes()
        {
            InitializeComponent();
        }

        private void StudentViewNotes_Load(object sender, EventArgs e)
        {
            LoadNotes();
        }
        private void LoadNotes()
        {
            

            //using (SqlConnection con = new SqlConnection(DatabaseConnection.connStr))
            //{
            //    string query = "SELECT NoteID, Subject, Topic, Description, FileType, FilePath FROM TeacherNotes WHERE Status = 0";
            //    SqlDataAdapter da = new SqlDataAdapter(query, con);
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);
            //    dataGridView1.DataSource = dt;
            //}
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PerformOCR(selectedImagePath);
        }
        private void PerformOCR(string imagePath)
        {
            try
            {
                using (var engine = new TesseractEngine(tessDataPath, "eng", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(imagePath))
                    {
                        using (var page = engine.Process(img))
                        {
                            string text = page.GetText();
                            txtExtracted.Text = text;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OCR Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtExtracted.Text))
            {
                SpeechSynthesizer synth = new SpeechSynthesizer();
                synth.SpeakAsync(txtExtracted.Text);
            }
            else
            {
                MessageBox.Show("No text available to read.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                textBox1.Text = openFileDialog1.FileName.ToString();
                pictureBox1.ImageLocation = textBox1.Text;
                selectedImagePath = textBox1.Text;



            }
        }
    }
}
