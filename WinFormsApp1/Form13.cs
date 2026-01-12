using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public partial class Form13 : Form
    {
        string connectionString = "datasource=127.0.0.1;port=3306;user=root;password=;database=stock;charset=utf8;";

        public Form13()
        {
            InitializeComponent();
            this.AutoScroll = false;
            panel1.AutoScroll = true;
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            DisplayCart();
        }

        private int GetProductStockAmount(int Id)
        {
            int amount = 0;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT amount FROM stock WHERE Id = @Id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Id", Id);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        amount = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการดึงข้อมูลสต็อก: " + ex.Message, "ข้อผิดพลาดฐานข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return amount;
        }

        // แสดงข้อมูลสินค้าในตะกร้า
        public void DisplayCart()
        {
            var oldControls = panel1.Controls.Cast<Control>().Where(c => c.Tag as string == "auto").ToList();
            foreach (var ctrl in oldControls)
                panel1.Controls.Remove(ctrl);

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            // ซ่อน label4 ด้วย เพราะจะถูกจัดการตำแหน่งใหม่ (หรือจะให้มันแสดงตลอดก็ได้)
            label4.Visible = false; // <<< เพิ่มบรรทัดนี้

            if (CartManager.Items.Count == 0)
            {
                label1.Text = "ไม่มีสินค้าในตะกร้า";
                label1.Visible = true;
                label2.Text = "";
                label3.Text = "";
                label4.Text = "รวมทั้งหมด: ฿0";
                label4.Visible = true; // ให้ label4 แสดงเมื่อตะกร้าว่าง
                // ปรับตำแหน่ง label4 ให้เหมาะสมในกรณีตะกร้าว่าง
                label4.Location = new Point((this.ClientSize.Width - label4.Width) / 2, label1.Bottom + 10);
                return;
            }

            int panelLeftOffset = panel1.Location.X;

            int startY = label1.Top - panel1.Top;
            if (startY < 0) startY = 10;

            int spacingY = button1.Height + 10;

            for (int i = 0; i < CartManager.Items.Count; i++)
            {
                var item = CartManager.Items[i];
                int y = startY + (i * spacingY);

                Label lblName = new Label
                {
                    AutoSize = true,
                    Font = label1.Font,
                    Location = new Point(label1.Left - panelLeftOffset, y + 5),
                    Text = item.Name,
                    Tag = "auto"
                };
                panel1.Controls.Add(lblName);

                Label lblQty = new Label
                {
                    AutoSize = true,
                    Font = label2.Font,
                    Location = new Point(label2.Left - panelLeftOffset, y + 5),
                    Text = $"จำนวน {item.Quantity}",
                    Tag = "auto"
                };
                panel1.Controls.Add(lblQty);

                Label lblTotal = new Label
                {
                    AutoSize = true,
                    Font = label3.Font,
                    Location = new Point(label3.Left - panelLeftOffset, y + 5),
                    Text = $"รวม ฿{(item.Price * item.Quantity):N0}",
                    Tag = "auto"
                };
                panel1.Controls.Add(lblTotal);

                // --- ปุ่ม ➕ (เพิ่มจำนวน) ---
                Button btnAdd = CreateCloneButton(button1, button1.Left - panelLeftOffset, y, () =>
                {
                    int currentStock = GetProductStockAmount(item.Id);
                    int currentInCart = item.Quantity;

                    if (currentInCart < currentStock)
                    {
                        item.Quantity++;
                        DisplayCart();
                    }
                    else
                    {
                        MessageBox.Show($"สินค้า '{item.Name}' มีในคลังเพียง {currentStock} ชิ้นเท่านั้น\nไม่สามารถเพิ่มได้อีก (ในตะกร้ามีแล้ว {currentInCart} ชิ้น)",
                                        "สินค้าหมด/จำกัดจำนวน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                });
                panel1.Controls.Add(btnAdd);

                // --- ปุ่ม ➖ (ลดจำนวน) ---
                Button btnSubtract = CreateCloneButton(button2, button2.Left - panelLeftOffset, y, () =>
                {
                    if (item.Quantity > 1)
                    {
                        item.Quantity--;
                        DisplayCart();
                    }
                    else
                    {
                        if (MessageBox.Show($"ต้องการลบสินค้า '{item.Name}' ออกจากตะกร้าหรือไม่?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            CartManager.Items.Remove(item);
                            DisplayCart();
                        }
                    }
                });
                panel1.Controls.Add(btnSubtract);

                // --- ปุ่ม ❌ (ลบสินค้าออกจากตะกร้า) ---
                Button btnRemove = CreateCloneButton(button3, button3.Left - panelLeftOffset, y, () =>
                {
                    if (MessageBox.Show($"ต้องการลบสินค้า '{item.Name}' ออกจากตะกร้าหรือไม่?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CartManager.Items.Remove(item);
                        DisplayCart();
                    }
                });
                panel1.Controls.Add(btnRemove);
            }
            decimal subtotal = CartManager.Items.Sum(i => i.Price * i.Quantity);
            decimal vat = subtotal * 0.07m;
            decimal totalWithVat = subtotal + vat;

            label4.Text = $"รวมเป็นเงิน: ฿{subtotal:N2}\nVAT 7%: ฿{vat:N2}\nรวมทั้งสิ้น: ฿{totalWithVat:N2}";
            label4.AutoSize = true;
            label4.Visible = true;

            int finalYForLabel4 = startY + (CartManager.Items.Count * spacingY) + 20;
            int label4LeftInPanel = (panel1.Width - label4.Width) / 2;

            label4.Location = new Point(label4LeftInPanel, finalYForLabel4);
            if (!panel1.Controls.Contains(label4))
            {
                panel1.Controls.Add(label4);
            }
            label4.BringToFront();

        }


        private Button CreateCloneButton(Button template, int x, int y, Action onClick)
        {
            Button btn = new Button
            {
                Size = template.Size,
                Font = template.Font,
                Text = template.Text,
                Location = new Point(x, y),
                Tag = "auto"
            };
            btn.Click += (s, e) => onClick();
            btn.BringToFront();
            return btn;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {



        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
