using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;user=root;password=;database=order;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }


        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private byte[] selectedImageBytes = null;
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบทุกช่อง");
                return;
            }
            if (selectedImageBytes == null || selectedImageBytes.Length == 0)
            {
                MessageBox.Show("กรุณาเลือกไฟล์สลิปที่ถูกต้อง");
                return;
            }

            using (MySqlConnection conn = databaseConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"INSERT INTO user 
                           (firstname, lastname, email, password, phonenumber, address, profile_image) 
                           VALUES 
                           (@fname, @lname, @email, @password, @phone, @address, @image)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@fname", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@lname", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", textBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", textBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", textBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", textBox6.Text.Trim());

                    if (selectedImageBytes != null)
                    {
                        cmd.Parameters.Add("@image", MySqlDbType.LongBlob).Value = selectedImageBytes;
                    }
                    else
                    {
                        cmd.Parameters.Add("@image", MySqlDbType.LongBlob).Value = DBNull.Value;
                    }

                    int rows = cmd.ExecuteNonQuery();
                    MessageBox.Show(rows > 0 ? "ลงทะเบียนเรียบร้อยแล้ว" : "ไม่สามารถลงทะเบียนได้");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = !textBox4.UseSystemPasswordChar;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "เลือกรูปโปรไฟล์";
            dialog.InitialDirectory = @"D:\c#";
            dialog.Filter = "ไฟล์รูปภาพ (*.jpg;*.png)|*.jpg;*.png";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.FileName;
                selectedImageBytes = File.ReadAllBytes(path);
                pictureBox1.Image = Image.FromFile(path);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }

        }
    }
}

