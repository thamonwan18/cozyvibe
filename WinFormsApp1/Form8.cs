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
    public partial class Form8 : Form
    {
        private int userId;
        public Form8(int userIdFromLogin)
        {
            InitializeComponent();
            userId = userIdFromLogin;
        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;user=root;password=;database=order;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string oldPassword = textBox1.Text.Trim();
            string newPassword = textBox2.Text.Trim();
            string confirmPassword = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบทุกช่อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("รหัสผ่านใหม่และยืนยันไม่ตรงกัน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = databaseConnection())
            {
                conn.Open();

                // ✅ เปรียบเทียบรหัสผ่านแบบ plain text
                string checkSql = "SELECT COUNT(*) FROM user WHERE id = @id AND password = @oldPassword";
                MySqlCommand checkCmd = new MySqlCommand(checkSql, conn);
                checkCmd.Parameters.AddWithValue("@id", userId);
                checkCmd.Parameters.AddWithValue("@oldPassword", oldPassword);

                int match = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (match == 0)
                {
                    MessageBox.Show("รหัสผ่านเดิมไม่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ✅ อัปเดตรหัสผ่านใหม่แบบ plain text
                string updateSql = "UPDATE user SET password = @newPassword WHERE id = @id";
                MySqlCommand updateCmd = new MySqlCommand(updateSql, conn);
                updateCmd.Parameters.AddWithValue("@newPassword", newPassword);
                updateCmd.Parameters.AddWithValue("@id", userId);
                updateCmd.ExecuteNonQuery();

                MessageBox.Show("เปลี่ยนรหัสผ่านเรียบร้อยแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
