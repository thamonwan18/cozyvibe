using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
    public partial class MyAccount : Form
    {
        private int userId;

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;user=root;password=;database=order;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        public MyAccount(int userIdFromLogin)
        {
            InitializeComponent();
            userId = userIdFromLogin;
        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void MyAccount_Load(object sender, EventArgs e)
        {


            using (MySqlConnection conn = databaseConnection())
            {
                conn.Open();
                string sql = @"SELECT firstname, lastname, email, phonenumber, address, profile_image 
                       FROM user WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", userId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBox1.Text = reader["firstname"].ToString();
                        textBox2.Text = reader["lastname"].ToString();
                        textBox3.Text = reader["email"].ToString();
                        textBox4.Text = reader["phonenumber"].ToString();
                        textBox5.Text = reader["address"].ToString();

                        if (reader["profile_image"] != DBNull.Value)
                        {
                            byte[] imageBytes = (byte[])reader["profile_image"];
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                pictureBox1.Image = Image.FromStream(ms);
                                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบข้อมูลผู้ใช้ในฐานข้อมูล");
                    }
                }
                LoadOrderData(userId);

            }
        }
        private byte[] selectedImageBytes = null; // เก็บภาพไว้ใช้ตอนบันทึก

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"D:\c#";
            dialog.Title = "เลือกรูปโปรไฟล์";
            dialog.Filter = "ไฟล์รูปภาพ (*.jpg;*.png)|*.jpg;*.png";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = dialog.FileName;

                try
                {
                    selectedImageBytes = File.ReadAllBytes(selectedPath); // ✅ เก็บเป็น byte[] สำหรับบันทึก
                    pictureBox1.Image = Image.FromFile(selectedPath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ไม่สามารถโหลดรูปภาพได้: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = databaseConnection())
            {
                conn.Open();
                string sql = @"UPDATE user SET 
                        firstname = @firstname,
                        lastname = @lastname,
                        email = @email,
                        phonenumber = @phone,
                        address = @address,
                        profile_image = @image
                       WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@firstname", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@lastname", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@email", textBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@phone", textBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@address", textBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@id", userId);

                if (selectedImageBytes != null)
                {
                    cmd.Parameters.Add("@image", MySqlDbType.LongBlob).Value = selectedImageBytes;
                }
                else
                {
                    cmd.Parameters.Add("@image", MySqlDbType.LongBlob).Value = DBNull.Value;
                }

                int affected = cmd.ExecuteNonQuery();
                MessageBox.Show(affected > 0 ? "บันทึกโปรไฟล์เรียบร้อย" : "ไม่สามารถบันทึกได้");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadOrderData(int userId)
        {

            using (MySqlConnection conn = databaseConnection())
            {
                conn.Open();

                string sql = @"SELECT id AS order_id, name, address, items, total_price, status, order_date
                       FROM `order`
                       WHERE user_id = @userId
                       ORDER BY order_date DESC";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                MySqlDataReader reader = cmd.ExecuteReader();
                bool hasOrder = false;

                while (reader.Read())
                {
                    hasOrder = true;

                    Label lblItems = new Label
                    {
                        Text = "🛒 สินค้า:\n" + FormatItems(reader["items"].ToString()),
                        Location = new Point(10, 60),
                        AutoSize = true,
                        MaximumSize = new Size(580, 0),
                        Font = new Font("Leelawadee UI", 10)
                    };


                    Label lblDate = new Label
                    {
                        Text = "📅 วันที่สั่ง: " + Convert.ToDateTime(reader["order_date"]).ToString("dd/MM/yyyy HH:mm:ss"),
                        Location = new Point(10, 10),
                        AutoSize = true,
                        Font = new Font("Leelawadee UI", 10, FontStyle.Bold)
                    };

                    string statusText = reader["status"].ToString();
                    Color statusColor;
                    float statusFontSize;

                    if (statusText == "จัดส่งแล้ว")
                    {
                        statusColor = Color.Green;
                        statusFontSize = 12f;
                    }
                    else if (statusText == "กำลังจัดส่ง")
                    {
                        statusColor = Color.Blue;
                        statusFontSize = 12f;
                    }
                    else if (statusText == "รอตรวจสอบ")
                    {
                        statusColor = Color.Orange;
                        statusFontSize = 12f;
                    }
                    else if (statusText == "ยกเลิก")
                    {
                        statusColor = Color.Gray;
                        statusFontSize = 12f;
                    }
                    else if (statusText == "สลิปไม่ถูกต้อง")
                    {
                        statusColor = Color.Red;
                        statusFontSize = 12f;
                    }
                    else
                    {
                        statusColor = Color.Black;
                        statusFontSize = 12f;
                    }

                    Label lblStatus = new Label
                    {
                        Text = "📦 สถานะ: " + statusText,
                        Location = new Point(10, 35),
                        AutoSize = true,
                        ForeColor = statusColor,
                        Font = new Font("Leelawadee UI", statusFontSize)
                    };

                    Label lblTotal = new Label
                    {
                        Text = "💰 รวม: ฿" + Convert.ToDecimal(reader["total_price"]).ToString("N0"),
                        Location = new Point(10, lblItems.Location.Y + lblItems.PreferredHeight + 5),
                        AutoSize = true,
                        Font = new Font("Leelawadee UI", 10, FontStyle.Bold)
                    };

                    Label lblAddress = new Label
                    {
                        Text = "📍 ที่อยู่: " + reader["address"].ToString(),
                        Location = new Point(10, lblTotal.Location.Y + 20),
                        AutoSize = true,
                        Font = new Font("Leelawadee UI", 10)
                    };
                    int panelHeight = lblAddress.Location.Y + lblAddress.PreferredHeight + 20;

                    Panel card = new Panel
                    {
                        Size = new Size(flowOrders.ClientSize.Width - 20, panelHeight),
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Color.WhiteSmoke,
                        Margin = new Padding(10)
                    };


                    card.Controls.AddRange(new Control[] { lblDate, lblStatus, lblItems, lblTotal, lblAddress });
                    flowOrders.Controls.Add(card);
                }

                if (!hasOrder)
                {
                    Label noOrderLabel = new Label
                    {
                        Text = "ยังไม่มีประวัติการสั่งซื้อ",
                        AutoSize = true,
                        Font = new Font("Leelawadee UI", 12, FontStyle.Italic),
                        ForeColor = Color.Gray,
                        Padding = new Padding(10),
                        Margin = new Padding(10)
                    };

                    flowOrders.Controls.Add(noOrderLabel);
                }

                flowOrders.FlowDirection = FlowDirection.TopDown;
                flowOrders.WrapContents = false;

            }
        }
        private string FormatItems(string raw)
        {
            // แยกสินค้าด้วย comma แล้วขึ้นบรรทัดใหม่
            if (string.IsNullOrWhiteSpace(raw))
                return "- ไม่มีรายการสินค้า -";

            var items = raw.Split(',');
            return string.Join("\n", items.Select(i => i.Trim()));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7(userId); // ✅ ส่ง userId กลับไป
            f7.Show();
            this.Close();
        }

        private void flowOrders_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8(userId);
            f8.Show();
        }
    }
}
