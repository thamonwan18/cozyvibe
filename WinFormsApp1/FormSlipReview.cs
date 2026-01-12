using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
    {
    public partial class FormSlipReview : Form

    {

        public FormSlipReview()
        {
            InitializeComponent();

            // ตั้งค่า FlowLayoutPanel
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
        }

        private int currentOrderId;

        private MySqlConnection orderDatabaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;user=root;password=;database=order;charset=utf8;";
            return new MySqlConnection(connectionString);
        }

        public void SetSlipData(string name, string phone, string address, string items, string price, string date, string status, Image slip, int orderId)
        {
            // ข้อมูลทั้งหมด
            (string label, string value)[] fields = {
                ("👤 ชื่อ", name),
                ("📞 เบอร์", phone),
                ("📍 ที่อยู่", address),
                ("🛒 สินค้า", items),
                ("💰 รวม", $"฿{price}"),
                ("📅 วันที่สั่ง", date),
                ("📦 สถานะเดิม", status)
            };

            flowLayoutPanel1.Controls.Clear();

            foreach (var (labelText, valueText) in fields)
            {
                Label lblTitle = new Label
                {
                    Text = labelText,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    AutoSize = true,
                    MaximumSize = new Size(flowLayoutPanel1.Width - 30, 0),
                    Margin = new Padding(0, 0, 0, 2)
                };

                Label lblValue = new Label
                {
                    Text = valueText,
                    Font = new Font("Segoe UI", 10),
                    AutoSize = true,
                    MaximumSize = new Size(flowLayoutPanel1.Width - 30, 0),
                    Padding = new Padding(5),
                    Margin = new Padding(0, 0, 0, 10),
                    BackColor = Color.WhiteSmoke,
                    TextAlign = ContentAlignment.TopLeft
                };

                flowLayoutPanel1.Controls.Add(lblTitle);
                flowLayoutPanel1.Controls.Add(lblValue);
            }

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] {
                "รอตรวจสอบ", "กำลังจัดส่ง", "จัดส่งแล้ว", "ยกเลิก", "สลิปไม่ถูกต้อง"
            });
            comboBox1.SelectedItem = status;

            pictureBox1.Image = slip;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            currentOrderId = orderId;
        }
        public event Action StatusUpdated;

        private void button1_Click(object sender, EventArgs e)
        {
            string newStatus = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(newStatus))
            {
                MessageBox.Show("กรุณาเลือกสถานะก่อนอัปเดต");
                return;
            }

            using (MySqlConnection conn = orderDatabaseConnection())
            {
                conn.Open();
                string sql = "UPDATE `order` SET status = @status WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@id", currentOrderId);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("อัปเดตสถานะเรียบร้อยแล้ว");
            StatusUpdated?.Invoke(); // ✅ แจ้งฟอร์มหลักให้รีเฟรช

            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormSlipReview_Load(object sender, EventArgs e)
        {

        }
    }
}