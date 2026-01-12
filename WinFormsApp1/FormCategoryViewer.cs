using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class FormCategoryViewer : Form
    {
        private int categoryId;
        string connectionString = "datasource=127.0.0.1;port=3306;user=root;password=;database=stock;charset=utf8;";
        private int userId;

        public FormCategoryViewer(int userIdFromForm7, int selectedCategoryId)
        {
            InitializeComponent();
            this.categoryId = selectedCategoryId;
            userId = userIdFromForm7;
            // ✅ รับค่าจริงจากภายนอก
        }
        private void FormCategoryViewer_Load(object sender, EventArgs e)
        {
            int x = pictureBox1.Left;
            int y = pictureBox1.Top;
            int count = 0;

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT id, name, price, file_path, amount FROM stock WHERE category_id = @id", conn);
                cmd.Parameters.AddWithValue("@id", categoryId);

                var adapter = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    // ✅ PictureBox
                    PictureBox pb = new PictureBox
                    {
                        Size = pictureBox1.Size,
                        SizeMode = pictureBox1.SizeMode,
                        Location = new Point(x, y),
                        BorderStyle = pictureBox1.BorderStyle
                    };

                    string filePath = row["file_path"].ToString();
                    if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                    {
                        pb.Image = Image.FromFile(filePath);
                    }

                    this.Controls.Add(pb);

                    // ✅ Label
                    Label lbl = new Label
                    {
                        AutoSize = true,
                        Font = label1.Font,
                        Text = $"{row["name"]}  ฿{Convert.ToDecimal(row["price"]):N0}",
                        Location = new Point(x, pb.Bottom + 5),
                        ForeColor = label1.ForeColor
                    };

                    this.Controls.Add(lbl);

                    // ✅ Button
                    int id = Convert.ToInt32(row["id"]);
                    string name = row["name"].ToString();
                    decimal price = Convert.ToDecimal(row["price"]);
                    int stock = Convert.ToInt32(row["amount"]);

                    Button btn = new Button
                    {
                        Size = button1.Size,
                        Text = button1.Text,
                        Font = button1.Font,
                        BackColor = button1.BackColor,
                        ForeColor = button1.ForeColor,
                        FlatStyle = button1.FlatStyle,
                        Location = new Point(x, lbl.Bottom + 5)
                    };
                    btn.FlatAppearance.BorderSize = button1.FlatAppearance.BorderSize;

                    btn.Tag = new CartItem { Id = id, Name = name, Price = price };

                    btn.Click += (s, e) =>
                    {
                        if (btn.Tag is CartItem item)
                        {
                            int currentInCart = CartManager.GetQuantity(item.Id);
                            int remainingStock = stock - currentInCart;

                            if (remainingStock <= 0)
                            {
                                MessageBox.Show($"สินค้าหมดคลังแล้ว ไม่สามารถเพิ่ม {item.Name} ได้อีก\nในรถเข็นมีแล้ว {currentInCart} ชิ้น");
                                return;
                            }

                            item.Quantity = 1;
                            CartManager.AddItem(item);

                            int updatedQty = CartManager.GetQuantity(item.Id);
                            MessageBox.Show($"เพิ่ม {item.Name} x1 ลงตะกร้าแล้ว\nรวมในรถเข็น: {updatedQty} ชิ้น");
                        }
                    };

                    this.Controls.Add(btn);

                    // ✅ จัดตำแหน่งถัดไป
                    x += pictureBox1.Width + 150;
                    count++;

                    if (count % 4 == 0)
                    {
                        x = pictureBox1.Left;
                        y += pictureBox1.Height + label1.Height + button1.Height + 40;
                    }
                }

                // ✅ ซ่อนแม่แบบ
                pictureBox1.Visible = false;
                label1.Visible = false;
                button1.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7(userId); // ✅ ส่ง userId กลับไป
            f7.Show();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13();
            f13.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form14 f14 = new Form14(userId);
            f14.Show();
        }
    }
}
