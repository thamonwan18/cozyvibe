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

namespace WinFormsApp1
{
    public partial class Form5 : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;user=root;password=;database=admin;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Form5()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("กรุณากรอกอีเมลและรหัสผ่าน");
                return;
            }

            using (var conn = databaseConnection())
            {
                conn.Open();
                string sql = "SELECT role FROM admin WHERE email=@email AND password=@pass";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@pass", password);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string role = reader.GetString("role");
                        Form6 form6 = new Form6(role);
                        form6.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("อีเมลหรือรหัสผ่านไม่ถูกต้อง");
                    }
                }
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !textBox2.UseSystemPasswordChar;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
