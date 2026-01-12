using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;user=root;password=;database=order;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        public Form2()
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

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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

            MySqlConnection conn = databaseConnection();

            try
            {
                conn.Open();

                string sql = "SELECT id FROM user WHERE email = @email AND password = @password";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int userId = Convert.ToInt32(reader["id"]);
                    Form7 f7 = new Form7(userId); // ✅ ส่ง userId ไปยัง Form7
                    f7.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("อีเมลหรือรหัสผ่านไม่ถูกต้อง");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !textBox2.UseSystemPasswordChar;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string email = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("กรุณากรอกอีเมลเพื่อรีเซ็ตรหัสผ่าน");
                return;
            }

            using (var conn = databaseConnection())
            {
                conn.Open();
                string sql = "SELECT id FROM user WHERE email = @email";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", email);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close(); // ปิดก่อนอัปเดต
                    SendOtpToEmail(email); // ✅ ส่ง OTP ไปยังอีเมล
                    MessageBox.Show("ส่งรหัส OTP ไปยังอีเมลเรียบร้อยแล้ว กรุณาตรวจสอบและกรอก OTP");
                    FormResetPasswordWithOtp resetForm = new FormResetPasswordWithOtp(email);
                    resetForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("ไม่พบอีเมลนี้ในระบบ");
                }
            }
        }
        private void SendEmail(string toEmail, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("srisawat.1804@gmail.com");
            mail.To.Add(toEmail);
            mail.Subject = subject;
            mail.Body = body;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("srisawat.1804@gmail.com", "xxnj mzvo tckn bted");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        private string GenerateOtp()
        {
            Random rnd = new Random();
            return rnd.Next(100000, 999999).ToString(); // 6 หลัก
        }

        private void SendOtpToEmail(string email)
        {
            string otp = GenerateOtp();
            DateTime expire = DateTime.Now.AddMinutes(5);

            using (var conn = databaseConnection())
            {
                conn.Open();
                string sql = "UPDATE user SET otp_code = @otp, otp_expire = @expire WHERE email = @email";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@otp", otp);
                cmd.Parameters.AddWithValue("@expire", expire);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.ExecuteNonQuery();
            }

            SendEmail(email, "รหัส OTP สำหรับรีเซ็ตรหัสผ่าน", $"รหัส OTP ของคุณคือ: {otp}\nหมดอายุภายใน 5 นาที");
        }

        private bool VerifyOtp(string email, string inputOtp)
        {
            using (var conn = databaseConnection())
            {
                conn.Open();
                string sql = "SELECT otp_code, otp_expire FROM user WHERE email = @email";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", email);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string otp = reader.GetString("otp_code");
                    DateTime expire = reader.GetDateTime("otp_expire");

                    return otp == inputOtp && DateTime.Now <= expire;
                }
            }
            return false;
        }
    }
}
