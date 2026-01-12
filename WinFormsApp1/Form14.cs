using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form14 : Form
    {
        private byte[] slipBytes = null;
        private int userId;
        public Form14(int userIdFromFormCategoryViewer)
        {
            InitializeComponent();
            userId = userIdFromFormCategoryViewer;


        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;user=root;password=;database=order;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        private MySqlConnection stockDatabaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;user=root;password=;database=stock;charset=utf8;";
            return new MySqlConnection(connectionString);
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            label3.Text = GetOrderSummaryText();

            string query = "SELECT firstname, lastname, phonenumber, address FROM user WHERE id = @userId";

            using (MySqlConnection conn = databaseConnection()) // ✅ ใช้ฐานเดียว
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string fullName = reader["firstname"].ToString() + " " + reader["lastname"].ToString();
                        textBox1.Text = fullName;
                        textBox2.Text = reader["phonenumber"].ToString();
                        textBox3.Text = reader["address"].ToString();
                    }
                }
            }
        }

        private string GetOrderSummaryText()
        {
            if (CartManager.Items.Count == 0)
                return "ไม่มีสินค้าในตะกร้า";

            var sb = new StringBuilder();
            decimal subtotal = 0;

            foreach (var item in CartManager.Items)
            {
                decimal itemTotal = item.Price * item.Quantity;
                sb.AppendLine($"• {item.Name} x {item.Quantity} = ฿{itemTotal:N0}");
                subtotal += itemTotal;
            }

            decimal vat = subtotal * 0.07m;
            decimal totalWithVat = subtotal + vat;

            sb.AppendLine("------------------------------");
            sb.AppendLine($"รวมเป็นเงิน: ฿{subtotal:N2}");
            sb.AppendLine($"VAT 7%: ฿{vat:N2}");
            sb.AppendLine($"รวมทั้งสิ้น: ฿{totalWithVat:N2}");

            return sb.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void address_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Address2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (slipBytes == null || slipBytes.Length == 0)
            {
                MessageBox.Show("กรุณาเลือกไฟล์สลิปที่ถูกต้อง");
                return;
            }

            string items = string.Join(", ", CartManager.Items.Select(i => $"{i.Name} x{i.Quantity}"));
            decimal totalPrice = CartManager.Items.Sum(i => i.Price * i.Quantity * 1.07m);
            string orderDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var orderedItems = CartManager.Items.ToList();

            using (var conn = databaseConnection())
            {
                conn.Open();
                string sql = "INSERT INTO `order` (user_id, name, phonenumber, address, items, total_price, order_date, file_path, status) " +
                             "VALUES (@user_id, @name, @phonenumber, @address, @items, @total_price, @order_date, @file_path, @status)";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@user_id", userId); // ✅ ใช้ userId จาก constructor
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@phonenumber", textBox2.Text);
                cmd.Parameters.AddWithValue("@address", textBox3.Text);
                cmd.Parameters.AddWithValue("@items", items);
                cmd.Parameters.AddWithValue("@total_price", totalPrice);
                cmd.Parameters.AddWithValue("@order_date", orderDate);
                cmd.Parameters.AddWithValue("@file_path", slipBytes);
                cmd.Parameters.AddWithValue("@status", "รอตรวจสอบ");

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกคำสั่งซื้อ: " + ex.Message);
                    return;
                }
            }

            UpdateStockForOrder(orderedItems);
            CartManager.ClearCart();

            string receiptFolder = @"D:\c#";
            Directory.CreateDirectory(receiptFolder);

            string customerName = textBox1.Text.Trim();
            foreach (char c in Path.GetInvalidFileNameChars())
                customerName = customerName.Replace(c.ToString(), "");

            string safeDateStamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string receiptFileName = $"ใบเสร็จ{customerName}_{safeDateStamp}.pdf";
            string receiptPath = Path.Combine(receiptFolder, receiptFileName);

            DateTime parsedDate = DateTime.Parse(orderDate);
            GenerateReceiptPDF(receiptPath, textBox1.Text, textBox2.Text, textBox3.Text, orderedItems, totalPrice, parsedDate);

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = receiptPath,
                UseShellExecute = true
            });

            Form15 f15 = new Form15();
            f15.Show();
            this.Close();
        }
        private void UpdateStockForOrder(List<CartItem> items)
        {
            using (MySqlConnection stockConn = stockDatabaseConnection())
            {
                stockConn.Open();

                foreach (var item in items)
                {
                    string updateStockSql = "UPDATE stock SET amount = amount - @qty WHERE name = @name";
                    MySqlCommand updateCmd = new MySqlCommand(updateStockSql, stockConn);
                    updateCmd.Parameters.AddWithValue("@qty", item.Quantity); // ✅ ใช้ Quantity จาก CartItem
                    updateCmd.Parameters.AddWithValue("@name", item.Name);    // ✅ ใช้ name จาก CartItem
                    updateCmd.ExecuteNonQuery();
                }
            }
        }

        private void nameuser_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ตรวจสอบว่าทุกช่องกรอกครบหรือยัง
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบทุกช่องก่อนกดบันทึก");
                return;
            }

            // แสดงผลใน Label แบบต่อท้ายข้อความแม่แบบ
            nameuser.Text = $"Name : {textBox1.Text}";
            Phonenumber2.Text = $"Phone Number : {textBox2.Text}";
            Address2.Text = $"Address : {textBox3.Text}";
        }


        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "เลือกไฟล์สลิป";
            openFileDialog.InitialDirectory = @"D:\c#";
            openFileDialog.Filter = "ไฟล์รูปภาพ (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // ✅ แปลงไฟล์เป็น byte[] แล้วเก็บไว้ในตัวแปร
                slipBytes = File.ReadAllBytes(filePath);

                // ✅ แสดงภาพใน pictureBox2
                pictureBox2.Image = System.Drawing.Image.FromFile(filePath);
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom; // ✅ ปรับขนาดให้พอดี
            }
        }



        private void GenerateReceiptPDF(string filePath, string name, string phone, string address, List<CartItem> items, decimal total, DateTime date)
        {
            var doc = new iTextSharp.text.Document(PageSize.A4, 36, 36, 36, 36);
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            var fontPath = @"C:\Users\HP\Downloads\THSarabunNew.ttf";
            var baseFont = iTextSharp.text.pdf.BaseFont.CreateFont(fontPath, iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.EMBEDDED);
            var font = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL);
            var boldFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD);

            // หัวร้าน
            var storeFont = new iTextSharp.text.Font(baseFont, 20, iTextSharp.text.Font.BOLD);
            Paragraph storeName = new Paragraph("COZY VIBE", storeFont);
            storeName.Alignment = Element.ALIGN_CENTER;
            doc.Add(storeName);
            doc.Add(new Paragraph("ใบเสร็จรับเงิน", boldFont) { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Paragraph("เบอร์ติดต่อ 0925853555 ", font));
            doc.Add(new Paragraph("อีเมล thamonwan.sri@kkumail.com", font));
            doc.Add(new Paragraph("ที่อยู่ 91 หมู่ 1 ตำบลเนินยาง อำเภอคำม่วง จังหวัดกาฬสินธุ์ 46180", font));
            doc.Add(new Paragraph("เลขประจำตัวผู้เสียภาษี 0145754824757", font) );
            doc.Add(new Paragraph("----------------------------------------------------------------------------------------------------------------------------------------------------------------------", font));
            
            // ข้อมูลลูกค้า
            doc.Add(new Paragraph($"ลูกค้า {name}", font));
            doc.Add(new Paragraph($"เบอร์โทร {phone}", font));
            doc.Add(new Paragraph($"ที่อยู่ {address}", font));
            doc.Add(new Paragraph($"วันที่ {date.ToString("dd/MM/yyyy HH:mm:ss")}", font));
            doc.Add(new Paragraph("----------------------------------------------------------------------------------------------------------------------------------------------------------------------", font));
            doc.Add(new Paragraph("รายการสินค้า", boldFont));
            PdfPTable itemTable = new PdfPTable(4);
            itemTable.WidthPercentage = 100;
            itemTable.SetWidths(new float[] { 45f, 15f, 20f, 20f });
            string[] headers = { "สินค้า", "จำนวน", "ราคาต่อชิ้น", "ราคารวม" };
            foreach (string h in headers)
            {
                PdfPCell cell = new PdfPCell(new Phrase(h, boldFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                itemTable.AddCell(cell);
            }

            foreach (var item in items)
            {
                string nameText = item.Name;
                string qtyText = $"x{item.Quantity}";
                string unitPrice = item.Price.ToString("N0");
                string totalPrice = (item.Price * item.Quantity).ToString("N0") + " บาท";

                PdfPCell nameCell = new PdfPCell(new Phrase(nameText, font));
                PdfPCell qtyCell = new PdfPCell(new Phrase(qtyText, font));
                PdfPCell priceCell = new PdfPCell(new Phrase(unitPrice, font));
                PdfPCell totalCell = new PdfPCell(new Phrase(totalPrice, font));

                nameCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                qtyCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                priceCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                totalCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                // ✅ จัดแนวให้ตรง
                nameCell.HorizontalAlignment = Element.ALIGN_LEFT;
                qtyCell.HorizontalAlignment = Element.ALIGN_CENTER;
                priceCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                totalCell.HorizontalAlignment = Element.ALIGN_RIGHT;

                // ✅ ป้องกันตัดคำ
                nameCell.NoWrap = true;

                itemTable.AddCell(nameCell);
                itemTable.AddCell(qtyCell);
                itemTable.AddCell(priceCell);
                itemTable.AddCell(totalCell);
            }
            doc.Add(itemTable);

            // คำนวณ VAT และยอดรวม
            // total คือยอดรวมที่รวม VAT แล้ว
            decimal subtotal = total / 1.07m;              // หายอดก่อน VAT
            decimal vat = total - subtotal;                // คำนวณ VAT จากยอดรวม

            doc.Add(new Paragraph("----------------------------------------------------------------------------------------------------------------------------------------------------------------------", font));
            doc.Add(new Paragraph($"รวมเป็นเงิน: {subtotal:N2} บาท", boldFont) { Alignment = Element.ALIGN_RIGHT }); // ✅ ยอดก่อน VAT
            doc.Add(new Paragraph($"VAT 7%: {vat:N2} บาท", boldFont) { Alignment = Element.ALIGN_RIGHT });             // ✅ VAT แยก
            doc.Add(new Paragraph($"รวมทั้งสิ้น: {total:N2} บาท", boldFont) { Alignment = Element.ALIGN_RIGHT });     // ✅ ยอดรวมตรงกับตะกร้า
            doc.Add(new Paragraph("----------------------------------------------------------------------------------------------------------------------------------------------------------------------", font));
            // ข้อความท้าย
            doc.Add(new Paragraph("ขอบคุณที่ใช้บริการ", font) { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Paragraph("กรุณาเก็บใบเสร็จไว้เป็นหลักฐาน", font) { Alignment = Element.ALIGN_CENTER });

            doc.Close();
        }
    }
}
