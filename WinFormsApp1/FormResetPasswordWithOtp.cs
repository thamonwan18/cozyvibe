using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net;
using System.Net.Mail;

namespace WinFormsApp1
{
    public partial class FormResetPasswordWithOtp : Form
    {
        private string userEmail;

        public FormResetPasswordWithOtp(string email)
        {
            InitializeComponent();
            userEmail = email;
            labelEmail.Text = $"รีเซ็ตรหัสผ่านสำหรับ: {userEmail}";
            groupBoxNewPassword.Enabled = false;
        }

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;user=root;password=;database=order;";
            return new MySqlConnection(connectionString);
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

        private void FormResetPasswordWithOtp_Load(object sender, EventArgs e)
        {

        }

        private void buttonVerifyOtp_Click_1(object sender, EventArgs e)
        {
            string otp = textBoxOtp.Text.Trim();

            if (string.IsNullOrWhiteSpace(otp))
            {
                MessageBox.Show("กรุณากรอก OTP");
                return;
            }

            if (VerifyOtp(userEmail, otp))
            {
                MessageBox.Show("OTP ถูกต้อง กรุณาตั้งรหัสผ่านใหม่");
                textBoxOtp.Clear();
                groupBoxNewPassword.Enabled = true;
            }
            else
            {
                MessageBox.Show("OTP ไม่ถูกต้องหรือหมดอายุ");
            }
        }
        private void buttonResetPassword_Click_1(object sender, EventArgs e)
        {
            string newPass = textBox1.Text.Trim();
            string confirmPass = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(newPass) || string.IsNullOrWhiteSpace(confirmPass))
            {
                MessageBox.Show("กรุณากรอกรหัสผ่านให้ครบ");
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("รหัสผ่านไม่ตรงกัน");
                return;
            }

            using (var conn = databaseConnection())
            {
                conn.Open();
                string sql = "UPDATE user SET password = @pass, otp_code = NULL, otp_expire = NULL WHERE email = @email";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pass", newPass);
                cmd.Parameters.AddWithValue("@email", userEmail);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("ตั้งรหัสผ่านใหม่เรียบร้อยแล้ว");
            this.Close();
        }
        private void labelEmail_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxOtp_TextChanged(object sender, EventArgs e)
        {

        }
    }
}