using MySql.Data.MySqlClient;
using ScottPlot;
using ScottPlot.Plottables;
using ScottPlot.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iTextSharp.text.pdf.events.IndexEvents;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form6 : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;user=root;password=;database=stock;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private string loggedInRole;


        public Form6(string role)
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.DrawItem += tabControl1_DrawItem;
            loggedInRole = role;
        }
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            TabPage tabPage = tabControl.TabPages[e.Index];
            System.Drawing.Rectangle tabRect = tabControl.GetTabRect(e.Index);

            bool isSelected = (e.Index == tabControl.SelectedIndex);

            // สีพื้นหลัง
            System.Drawing.Color backColor = isSelected ? System.Drawing.Color.LightSkyBlue : System.Drawing.Color.LightGray;
            // สีตัวอักษร
            System.Drawing.Color textColor = isSelected ? System.Drawing.Color.DarkBlue : System.Drawing.Color.Black;

            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, tabRect);
            }

            TextRenderer.DrawText(
                e.Graphics,
                tabPage.Text,
                tabControl.Font,
                tabRect,
                textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }
        private void showstock()
        {
            using (MySqlConnection conn = databaseConnection())
            {
                DataSet ds = new DataSet();
                try
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        SELECT
                            id,
                            ROW_NUMBER() OVER (ORDER BY id) AS no,
                            name,
                            category_id,
                            amount,
                            price,
                            file_path
                        FROM stock ORDER BY id"; // เพิ่ม ORDER BY id เพื่อให้ ROW_NUMBER() มีความสอดคล้องกัน

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(ds);

                    datastock.DataSource = ds.Tables[0].DefaultView;

                    // ซ่อนคอลัมน์ ID จากผู้ใช้ หากมีอยู่ (แต่ยังคงเข้าถึงได้ในโค้ด)
                    if (datastock.Columns.Contains("id"))
                    {
                        datastock.Columns["id"].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูลสินค้า: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            showstock();
            LoadCategories();
            showOrder();
            showCategory();

            // ปีนี้และปีหน้า + "ทุกปี"
            int thisYear = DateTime.Now.Year;
            comboBox3.Items.Add("ทุกปี");
            comboBox3.Items.Add(thisYear.ToString());
            comboBox3.Items.Add((thisYear + 1).ToString());
            comboBox3.SelectedIndex = 1;

            // เดือน 01–12 + "ทุกเดือน"
            comboBox2.Items.Add("ทุกเดือน");
            for (int m = 1; m <= 12; m++)
            {
                comboBox2.Items.Add(m.ToString("D2"));
            }
            comboBox2.SelectedIndex = 1;

            // วัน 01–31 + "ทุกวัน"
            comboBox1.Items.Add("ทุกวัน");
            for (int d = 1; d <= 31; d++)
            {
                comboBox1.Items.Add(d.ToString("D2"));
            }
            comboBox1.SelectedIndex = 1;
            comboBox5.Items.Clear();
            comboBox5.Items.Add("admin");
            comboBox5.Items.Add("staff");
            comboBox5.SelectedIndex = 0;

            updateReportFromComboBoxes();
            formsPlot1_Load(null, null);
            formsPlot2_Load(null, null);
            formsPlot3_Load(null, null);
            formsPlot4_Load(null, null);
            showSalesSummary();
            LoadAdminsToFlow();

            ApplyTabAccessByRole(loggedInRole);



        }
        private void LoadCategories()
        {
            comboBox4.Items.Clear();

            using (var conn = databaseConnection())
            {
                conn.Open();
                string sql = "SELECT id, name FROM category ORDER BY id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                int no = 1; // เริ่มลำดับที่ 1
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string name = reader.GetString("name");

                    // ✅ แสดงเป็น "1 - เครื่องเขียน" โดยใช้ลำดับแทน id
                    comboBox4.Items.Add(new ComboBoxItem(id, $"{no} - {name}"));
                    no++;
                }
            }

            if (comboBox4.Items.Count > 0)
                comboBox4.SelectedIndex = 0;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();

            try
            {
                string sql = "INSERT INTO stock (name, category_id, amount, price, file_path) VALUES (@name, @category_id, @amount, @price, @file_path)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                var selectedCategory = comboBox4.SelectedItem as ComboBoxItem;
                if (selectedCategory == null)
                {
                    MessageBox.Show("กรุณาเลือกหมวดหมู่");
                    return;
                }

                cmd.Parameters.AddWithValue("@category_id", selectedCategory.Id);
                cmd.Parameters.AddWithValue("@amount", textBox3.Text);
                cmd.Parameters.AddWithValue("@price", textBox4.Text);
                cmd.Parameters.AddWithValue("@file_path", textBox5.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("เพิ่มข้อมูลเรียบร้อย");

                showstock(); // refresh datagrid
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
            conn.Close();
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            if (datastock.CurrentRow != null)
            {
                int selectedRow = datastock.CurrentRow.Index;
                string id = datastock.Rows[selectedRow].Cells["id"].Value.ToString();

                MySqlConnection conn = databaseConnection();
                conn.Open();

                try
                {
                    string sql = "DELETE FROM stock WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ลบข้อมูลเรียบร้อย");

                    showstock(); // refresh datagrid
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("กรุณาเลือกแถวที่จะลบ");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "เลือกไฟล์";
            openFileDialog.InitialDirectory = @"D:\c#";
            openFileDialog.Filter = "ไฟล์ทั้งหมด (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // แสดง path ของไฟล์ที่เลือกใน textbox5
                textBox5.Text = filePath;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (datastock.CurrentRow != null)
            {
                int selectedRow = datastock.CurrentRow.Index;
                string id = datastock.Rows[selectedRow].Cells["id"].Value.ToString();

                MySqlConnection conn = databaseConnection();
                conn.Open();

                try
                {
                    string sql = "UPDATE stock SET name = @name, category_id = @category_id, amount = @amount, price = @price, file_path = @file_path WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    var selectedCategory = comboBox4.SelectedItem as ComboBoxItem;
                    if (selectedCategory == null)
                    {
                        MessageBox.Show("กรุณาเลือกหมวดหมู่");
                        return;
                    }

                    cmd.Parameters.AddWithValue("@category_id", selectedCategory.Id);
                    cmd.Parameters.AddWithValue("@amount", textBox3.Text);
                    cmd.Parameters.AddWithValue("@price", textBox4.Text);
                    cmd.Parameters.AddWithValue("@file_path", textBox5.Text);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("แก้ไขข้อมูลเรียบร้อย");

                    showstock(); // refresh datagrid
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("กรุณาเลือกแถวที่จะแก้ไข");
            }
        }



        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Close();
        }

        private MySqlConnection orderDatabaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;user=root;password=;database=order;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private DataTable orderTable;
        private void showOrder()
        {
            MySqlConnection conn = orderDatabaseConnection();
            conn.Open();

            try
            {
                string sql = @"SELECT 
                    id,
                    name,
                    phonenumber,
                    address,
                    items,
                    FORMAT(total_price, 2) AS total_price,
                    order_date,
                    status
                FROM `order`";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                orderTable = new DataTable();
                adapter.Fill(orderTable);
                dataGridView1.DataSource = orderTable;

                if (!dataGridView1.Columns.Contains("ตรวจสอบ"))
                {

                    DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn
                    {
                        HeaderText = "ตรวจสอบ",
                        Name = "ตรวจสอบ",
                        Text = "🔍 ตรวจสอบ",
                        UseColumnTextForButtonValue = true,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                        FlatStyle = FlatStyle.Flat
                    };

                    btnCol.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                    btnCol.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;

                    dataGridView1.Columns.Add(btnCol);
                }
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    if (col.Name == "id")
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        col.Width = 50; // ปรับตามต้องการ
                    }
                    else if (col.Name == "items")
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        col.Width = 250; // ✅ จำกัดความกว้าง
                        col.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // ✅ ให้ขึ้นบรรทัดใหม่
                    }
                    else if (col.Name == "total_price")
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        col.Width = 110;
                    }
                    else if (col.Name == "order_date" || col.Name == "status")
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        col.Width = 170;
                    }
                    else
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.RowTemplate.Height = 60; // หรือมากกว่านี้ถ้าข้อความยาว
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูล order: " + ex.Message);
            }

            conn.Close();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string keyword = textBoxSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                dataGridView1.DataSource = orderTable; // แสดงทั้งหมดถ้าไม่มีคำค้น
                return;
            }

            // สร้าง filter expression สำหรับค้นหาในหลายคอลัมน์
            string filter = $"Convert(id, 'System.String') LIKE '%{keyword}%' OR " +
                            $"name LIKE '%{keyword}%' OR " +
                            $"phonenumber LIKE '%{keyword}%' OR " +
                            $"status LIKE '%{keyword}%'";

            DataView dv = new DataView(orderTable);
            dv.RowFilter = filter;

            dataGridView1.DataSource = dv;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "ตรวจสอบ")
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int orderId = Convert.ToInt32(row.Cells["id"].Value);

                System.Drawing.Image slipImage = null;
                using (MySqlConnection conn = orderDatabaseConnection())
                {
                    conn.Open();
                    string sql = "SELECT file_path FROM `order` WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", orderId);

                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result is byte[] imageBytes)
                    {
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            slipImage = System.Drawing.Image.FromStream(ms);
                        }
                    }
                }

                FormSlipReview reviewForm = new FormSlipReview();
                reviewForm.SetSlipData(
                    row.Cells["name"].Value.ToString(),
                    row.Cells["phonenumber"].Value.ToString(),
                    row.Cells["address"].Value.ToString(),
                    row.Cells["items"].Value.ToString(),
                    row.Cells["total_price"].Value.ToString(),
                    row.Cells["order_date"].Value.ToString(),
                    row.Cells["status"].Value.ToString(),
                    slipImage,
                    orderId // ✅ ส่งไปเพื่อใช้ตอนอัปเดต
                );
                reviewForm.StatusUpdated += () =>
                {
                    showOrder(); // ✅ รีเฟรชทันที
                };
                reviewForm.ShowDialog();

            }
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Close();
        }
        private void updateReportFromComboBoxes()
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null)
                return;

            string day = comboBox1.SelectedItem.ToString();
            string month = comboBox2.SelectedItem.ToString();
            string year = comboBox3.SelectedItem.ToString();

            if (year == "ทุกปี")
            {
                showReport("all_years", "");
            }
            else if (month == "ทุกเดือน")
            {
                showReport("yearly", year);
            }
            else if (day == "ทุกวัน")
            {
                string selectedMonth = $"{year}-{month}";
                showReport("monthly", selectedMonth);
            }
            else
            {
                string selectedDate = $"{year}-{month}-{day}";
                showReport("daily", selectedDate);
            }
        }
        private void showReport(string period, string value)
        {
            MySqlConnection conn = orderDatabaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            string sql = "";

            if (period == "daily")
            {
                sql = @"SELECT order_date, name, items, FORMAT(total_price, 2) AS total_price
                FROM `order`
                WHERE DATE(order_date) = @value";
            }
            else if (period == "monthly")
            {
                sql = @"SELECT order_date, name, items, FORMAT(total_price, 2) AS total_price
                FROM `order`
                WHERE DATE_FORMAT(order_date, '%Y-%m') = @value";
            }
            else if (period == "yearly")
            {
                sql = @"SELECT order_date, name, items, FORMAT(total_price, 2) AS total_price
                FROM `order`
                WHERE YEAR(order_date) = @value";
            }
            else if (period == "all_years")
            {
                sql = @"SELECT order_date, name, items, FORMAT(total_price, 2) AS total_price
                FROM `order`";
            }

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            if (period != "all_years")
                cmd.Parameters.AddWithValue("@value", value);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0].DefaultView;

            decimal total = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (decimal.TryParse(row["total_price"].ToString(), out decimal price))
                {
                    total += price;
                }
            }

            label6.Text = $"ยอดรวมช่วง {value}: {total:N0} บาท";
            conn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            updateReportFromComboBoxes();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            updateReportFromComboBoxes();
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            updateReportFromComboBoxes();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {


        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {
            var labels = new List<string>();
            var values = new List<double>();

            using (var conn = orderDatabaseConnection())
            {
                conn.Open();
                string query = "SELECT DATE(order_date) AS day, SUM(total_price) AS total FROM `order` GROUP BY day ORDER BY day";
                var cmd = new MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["day"] != DBNull.Value && reader["total"] != DBNull.Value)
                    {
                        labels.Add(Convert.ToDateTime(reader["day"]).ToString("dd/MM"));
                        values.Add(Convert.ToDouble(reader["total"]));
                    }
                }
            }

            formsPlot1.Plot.Clear();

            var barPlot = formsPlot1.Plot.Add.Bars(values.ToArray());
            barPlot.Color = ScottPlot.Colors.SkyBlue;
            var xTicks = new ScottPlot.Tick[labels.Count];
            for (int i = 0; i < labels.Count; i++)
            {
                xTicks[i] = new ScottPlot.Tick(i, labels[i]);
            }
            formsPlot1.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(xTicks);
            formsPlot1.Refresh();
        }

        private void formsPlot2_Load(object sender, EventArgs e)
        {
            var labels = new List<string>();
            var values = new List<double>();

            using (var conn = orderDatabaseConnection())
            {
                conn.Open();
                string query = "SELECT DATE_FORMAT(order_date, '%Y-%m') AS month, SUM(total_price) AS total FROM `order` GROUP BY month ORDER BY month";
                var cmd = new MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["month"] != DBNull.Value && reader["total"] != DBNull.Value)
                    {
                        labels.Add(reader["month"].ToString());
                        values.Add(Convert.ToDouble(reader["total"]));
                    }
                }
            }

            var barPlot = formsPlot2.Plot.Add.Bars(values.ToArray());
            barPlot.Color = ScottPlot.Colors.SkyBlue;
            var xTicks = new ScottPlot.Tick[labels.Count];
            for (int i = 0; i < labels.Count; i++)
            {
                xTicks[i] = new ScottPlot.Tick(i, labels[i]);
            }
            formsPlot2.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(xTicks);
            formsPlot2.Refresh();
        }

        private void formsPlot3_Load(object sender, EventArgs e)
        {
            var labels = new List<string>();
            var values = new List<double>();

            using (var conn = orderDatabaseConnection())
            {
                conn.Open();
                string query = "SELECT YEAR(order_date) AS year, SUM(total_price) AS total FROM `order` GROUP BY year ORDER BY year";
                var cmd = new MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["year"] != DBNull.Value && reader["total"] != DBNull.Value)
                    {
                        labels.Add(reader["year"].ToString());
                        values.Add(Convert.ToDouble(reader["total"]));
                    }
                }
            }

            formsPlot3.Plot.Clear();

            var barPlot = formsPlot3.Plot.Add.Bars(values.ToArray());
            barPlot.Color = ScottPlot.Colors.SkyBlue;
            var xTicks = new ScottPlot.Tick[labels.Count];
            for (int i = 0; i < labels.Count; i++)
            {
                xTicks[i] = new ScottPlot.Tick(i, labels[i]);
            }
            formsPlot3.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(xTicks);
            formsPlot3.Refresh();
        }



        private void formsPlot4_Load(object sender, EventArgs e)
        {
            var itemCounts = new Dictionary<string, double>();

            using (var conn = orderDatabaseConnection())
            {
                conn.Open();
                string query = "SELECT items FROM `order`";
                var cmd = new MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["items"] != DBNull.Value)
                    {
                        string itemsText = reader["items"].ToString() ?? "";

                        // แยกรายการด้วยคอมมา
                        string[] entries = itemsText.Split(',', StringSplitOptions.RemoveEmptyEntries);

                        foreach (string entry in entries)
                        {
                            string trimmed = entry.Trim(); 
                            int xIndex = trimmed.LastIndexOf('x');

                            if (xIndex > 0 && xIndex < trimmed.Length - 1)
                            {
                                string name = trimmed.Substring(0, xIndex).Trim();
                                string qtyText = trimmed.Substring(xIndex + 1).Trim();

                                if (int.TryParse(qtyText, out int qty))
                                {
                                    if (itemCounts.ContainsKey(name))
                                        itemCounts[name] += qty;
                                    else
                                        itemCounts[name] = qty;
                                }
                            }
                        }
                    }
                }
            }

            var labels = itemCounts.Keys.ToList();
            var values = itemCounts.Values.ToList();

            formsPlot4.Plot.Clear();

            var barPlot = formsPlot4.Plot.Add.Bars(values.ToArray());
            barPlot.Color = ScottPlot.Colors.SkyBlue;

            var xTicks = new ScottPlot.Tick[labels.Count];
            for (int i = 0; i < labels.Count; i++)
            {
                xTicks[i] = new ScottPlot.Tick(i, labels[i]);
            }

            formsPlot4.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(xTicks);
            formsPlot4.Plot.Axes.Bottom.TickLabelStyle.FontName = "Tahoma";
            formsPlot4.Plot.Axes.Bottom.TickLabelStyle.FontSize = 12;
            formsPlot4.Plot.Axes.Bottom.TickLabelStyle.Rotation = 45;
            formsPlot4.Refresh();
        }

        private void showSalesSummary()
        {
            var itemCounts = new Dictionary<string, double>();
            var dailySales = new Dictionary<string, double>();
            var monthlySales = new Dictionary<string, double>();
            var yearlySales = new Dictionary<string, double>();

            using (var conn = orderDatabaseConnection())
            {
                conn.Open();

                // โหลด items
                var itemTable = new DataTable();
                new MySqlDataAdapter("SELECT items FROM `order`", conn).Fill(itemTable);
                foreach (DataRow row in itemTable.Rows)
                {
                    string itemsText = row["items"].ToString() ?? "";
                    string[] entries = itemsText.Split(',', StringSplitOptions.RemoveEmptyEntries);

                    foreach (string entry in entries)
                    {
                        string trimmed = entry.Trim();
                        int xIndex = trimmed.LastIndexOf('x');

                        if (xIndex > 0 && xIndex < trimmed.Length - 1)
                        {
                            string name = trimmed.Substring(0, xIndex).Trim();
                            string qtyText = trimmed.Substring(xIndex + 1).Trim();

                            if (int.TryParse(qtyText, out int qty))
                            {
                                if (itemCounts.ContainsKey(name))
                                    itemCounts[name] += qty;
                                else
                                    itemCounts[name] = qty;
                            }
                        }
                    }
                }

                // รายวัน
                var dayTable = new DataTable();
                new MySqlDataAdapter("SELECT DATE(order_date) AS day, SUM(total_price) AS total FROM `order` GROUP BY day", conn).Fill(dayTable);
                foreach (DataRow row in dayTable.Rows)
                {
                    if (row["day"] != DBNull.Value && row["total"] != DBNull.Value)
                    {
                        string day = Convert.ToDateTime(row["day"]).ToString("dd/MM/yyyy");
                        double total = Convert.ToDouble(row["total"]);
                        dailySales[day] = total;
                    }
                }

                // รายเดือน
                var monthTable = new DataTable();
                new MySqlDataAdapter("SELECT DATE_FORMAT(order_date, '%M %Y') AS month, SUM(total_price) AS total FROM `order` GROUP BY month", conn).Fill(monthTable);
                foreach (DataRow row in monthTable.Rows)
                {
                    if (row["month"] != DBNull.Value && row["total"] != DBNull.Value)
                    {
                        string month = row["month"].ToString();
                        double total = Convert.ToDouble(row["total"]);
                        monthlySales[month] = total;
                    }
                }

                // รายปี
                var yearTable = new DataTable();
                new MySqlDataAdapter("SELECT YEAR(order_date) AS year, SUM(total_price) AS total FROM `order` GROUP BY year", conn).Fill(yearTable);
                foreach (DataRow row in yearTable.Rows)
                {
                    if (row["year"] != DBNull.Value && row["total"] != DBNull.Value)
                    {
                        string year = row["year"].ToString();
                        double total = Convert.ToDouble(row["total"]);
                        yearlySales[year] = total;
                    }
                }
            }

            // สรุปข้อมูล
            int totalItems = itemCounts.Count;
            double totalQuantity = itemCounts.Values.Sum();
            var top3 = itemCounts.OrderByDescending(x => x.Value).Take(3).ToList();
            var minItem = itemCounts.Any() ? itemCounts.OrderBy(x => x.Value).First() : new KeyValuePair<string, double>("ไม่มีข้อมูล", 0.0);
            var topDay = dailySales.Any() ? dailySales.OrderByDescending(x => x.Value).First() : new KeyValuePair<string, double>("ไม่มีข้อมูล", 0.0);
            var topMonth = monthlySales.Any() ? monthlySales.OrderByDescending(x => x.Value).First() : new KeyValuePair<string, double>("ไม่มีข้อมูล", 0.0);
            var topYear = yearlySales.Any() ? yearlySales.OrderByDescending(x => x.Value).First() : new KeyValuePair<string, double>("ไม่มีข้อมูล", 0.0);

            // label11: สรุปสินค้า
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- จำนวนสินค้าทั้งหมด : {totalItems} รายการ");
            sb.AppendLine($"- ยอดขายรวม : {totalQuantity} ชิ้น");
            sb.AppendLine($"- สินค้าขายดี 3 อันดับแรก :");

            if (top3.Any())
            {
                foreach (var item in top3)
                    sb.AppendLine($"   • {item.Key} ({item.Value} ชิ้น)");
            }
            else
            {
                sb.AppendLine("   • ไม่มีข้อมูลสินค้าขายดี");
            }

            sb.AppendLine($"- สินค้าที่ขายได้น้อยที่สุด : {minItem.Key} \n({minItem.Value} ชิ้น)");
            label11.Text = sb.ToString();
            label12.Text = $"- วันที่ขายดีที่สุด :\n {topDay.Key} ({topDay.Value:N2} บาท)";
            label13.Text = $"- เดือนที่ขายดีที่สุด :\n {topMonth.Key} ({topMonth.Value:N2} บาท)";
            label14.Text = $"- รวมยอดขายในปีนี้ :\n {topYear.Key} ({topYear.Value:N2} บาท)";
        }
        private void showCategory()
        {
            try
            {
                using (MySqlConnection conn = databaseConnection())
                {
                    conn.Open();

                    string sql = @"
                SELECT 
                    id,
                    ROW_NUMBER() OVER (ORDER BY id) AS no,
                    name,
                    image_path 
                FROM category 
                ORDER BY id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView3.DataSource = dt;
                    }

                    // ปรับขนาดคอลัมน์
                    foreach (DataGridViewColumn col in dataGridView3.Columns)
                    {
                        switch (col.Name)
                        {
                            case "no":
                                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                                col.Width = 60;
                                break;
                            case "name":
                                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                                col.Width = 200;
                                break;
                            case "image_path":
                                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                                break;
                        }
                    }

                    if (dataGridView3.Columns.Contains("id"))
                    {
                        dataGridView3.Columns["id"].Visible = false;
                    }

                    dataGridView3.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูล category: " + ex.Message);
            }
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBoxSlip_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void datastock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)

        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("กรุณากรอกชื่อหมวดหมู่", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("กรุณาเลือกหรือกรอก Path รูปภาพหมวดหมู่", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
                return;
            }

            using (MySqlConnection conn = databaseConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO category (name, image_path) VALUES (@name, @image_path)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@name", textBox2.Text.Trim()); // ใช้ textBox2
                    cmd.Parameters.AddWithValue("@image_path", textBox6.Text.Trim()); // ใช้ textBox6

                    int affectedRows = cmd.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("เพิ่มหมวดหมู่เรียบร้อยแล้ว!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showCategory();   // รีเฟรช DataGridView
                        LoadCategories(); // รีเฟรช ComboBox ในส่วนของ Stock ด้วย

                        textBox2.Clear(); // ล้างช่องกรอกข้อมูล
                        textBox6.Clear();
                    }
                    else
                    {
                        MessageBox.Show("ไม่สามารถเพิ่มหมวดหมู่ได้ (ไม่มีการเปลี่ยนแปลงในฐานข้อมูล)", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการเพิ่มหมวดหมู่: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Event Handler สำหรับปุ่ม "ลบ" หมวดหมู่ (button12)
        private void button10_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null)
            {
                MessageBox.Show("กรุณาเลือกแถวหมวดหมู่ที่จะลบก่อน", "ไม่มีรายการที่เลือก", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedRowIndex = dataGridView3.CurrentRow.Index;
            if (!dataGridView3.Columns.Contains("id") || dataGridView3.Rows[selectedRowIndex].Cells["id"].Value == null)
            {
                MessageBox.Show("ไม่พบข้อมูลรหัสหมวดหมู่ในแถวที่เลือก (คอลัมน์ 'id' หายไป หรือเป็นค่าว่าง)", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string id = dataGridView3.Rows[selectedRowIndex].Cells["id"].Value.ToString();
            string name = dataGridView3.Rows[selectedRowIndex].Cells["name"].Value?.ToString() ?? "ไม่ระบุ"; // เพิ่ม null-check

            if (MessageBox.Show($"คุณแน่ใจหรือไม่ว่าจะลบหมวดหมู่ '{name}' (ID: {id}) นี้?\n" +
                               "การลบหมวดหมู่อาจส่งผลกระทบต่อสินค้าที่อยู่ในหมวดหมู่นี้",
                               "ยืนยันการลบหมวดหมู่", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return; 
            }

            using (MySqlConnection conn = databaseConnection())
            {
                try
                {
                    conn.Open();
                    string checkSql = "SELECT COUNT(*) FROM stock WHERE category_id = @id";
                    MySqlCommand checkCmd = new MySqlCommand(checkSql, conn);
                    checkCmd.Parameters.AddWithValue("@id", id);
                    int productCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (productCount > 0)
                    {
                        MessageBox.Show($"ไม่สามารถลบหมวดหมู่ '{name}' ได้เนื่องจากมีสินค้า ({productCount} รายการ) ที่ใช้หมวดหมู่นี้อยู่\n" +
                                        "กรุณาลบหรือย้ายสินค้าเหล่านั้นก่อน", "ไม่สามารถลบได้", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    string deleteSql = "DELETE FROM category WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(deleteSql, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        MessageBox.Show($"ลบหมวดหมู่ '{name}' เรียบร้อยแล้ว!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showCategory();   
                        LoadCategories(); 
                        textBox2.Clear();
                        textBox6.Clear();
                    }
                    else
                    {
                        MessageBox.Show($"ไม่พบหมวดหมู่ ID: {id} ที่จะลบ หรือหมวดหมู่ถูกลบไปแล้ว", "ไม่สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการลบหมวดหมู่: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Event Handler สำหรับปุ่ม "แก้ไข" หมวดหมู่ (button13)
        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null)
            {
                MessageBox.Show("กรุณาเลือกแถวหมวดหมู่ที่จะแก้ไขก่อน", "ไม่มีรายการที่เลือก", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedRowIndex = dataGridView3.CurrentRow.Index;
            string id = dataGridView3.Rows[selectedRowIndex].Cells["id"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("ไม่พบข้อมูลรหัสหมวดหมู่ในแถวที่เลือก (คอลัมน์ 'id' หายไป หรือเป็นค่าว่าง)", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ใช้ textBox2 สำหรับชื่อหมวดหมู่
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("กรุณากรอกชื่อหมวดหมู่", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            // ใช้ textBox6 สำหรับ Path รูปภาพหมวดหมู่
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("กรุณาเลือกหรือกรอก Path รูปภาพหมวดหมู่", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // button8_Click(sender, e); // เรียกให้เปิด File Dialog โดยตรงถ้าต้องการ
                return;
            }

            using (MySqlConnection conn = databaseConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"
                        UPDATE category 
                        SET name = @name, 
                            image_path = @image_path 
                        WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", textBox2.Text.Trim()); // ใช้ textBox2
                    cmd.Parameters.AddWithValue("@image_path", textBox6.Text.Trim()); // ใช้ textBox6
                    cmd.Parameters.AddWithValue("@id", id);

                    int affected = cmd.ExecuteNonQuery();
                    if (affected > 0)
                    {
                        MessageBox.Show("แก้ไขหมวดหมู่เรียบร้อยแล้ว!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showCategory();   // รีเฟรช DataGridView
                        LoadCategories(); // รีเฟรช ComboBox ในส่วนของ Stock ด้วย
                        textBox2.Clear(); // ล้างช่องกรอกข้อมูล
                        textBox6.Clear();
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบหมวดหมู่ที่จะแก้ไข หรือข้อมูลเดิมเหมือนกัน", "ไม่สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการแก้ไขหมวดหมู่: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "เลือกไฟล์รูปภาพหมวดหมู่";
            openFileDialog.InitialDirectory = @"D:\c#"; // เปลี่ยนเป็น Path เริ่มต้นที่ต้องการ
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                textBox6.Text = filePath; // ใช้ textBox6 สำหรับ image_path
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private byte[] imageBytes;

        private MySqlConnection databasedAdminConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;user=root;password=;database=admin;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(open.FileName);
                    imageBytes = File.ReadAllBytes(open.FileName);
                }
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            string name = textBox7.Text.Trim();
            string email = textBox8.Text.Trim();
            string password = textBox9.Text.Trim();
            string role = comboBox5.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(role) || imageBytes == null)
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ");
                return;
            }

            using (var conn = databasedAdminConnection())
            {
                conn.Open();
                MySqlCommand cmd;

                if (editingEmail == null)
                {
                    // เพิ่มใหม่
                    string sql = "INSERT INTO admin (name, email, password, role, image_path) VALUES (@name, @email, @pass, @role, @image)";
                    cmd = new MySqlCommand(sql, conn);
                }
                else
                {
                    // แก้ไข
                    string sql = "UPDATE admin SET name=@name, password=@pass, role=@role, image_path=@image WHERE email=@email";
                    cmd = new MySqlCommand(sql, conn);
                }

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.Parameters.AddWithValue("@role", role);
                cmd.Parameters.AddWithValue("@image", imageBytes);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show(editingEmail == null ? "เพิ่มข้อมูลเรียบร้อย" : "แก้ไขข้อมูลเรียบร้อย");
            ClearTabPage6Form();
            LoadAdminsToFlow();
        }
        private void LoadAdminsToFlow()
        {
            flowAdmins.Controls.Clear();

            using (var conn = databasedAdminConnection())
            {
                conn.Open();
                string sql = "SELECT name, email, password, role, image_path FROM admin";
                var cmd = new MySqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader.GetString("name");
                    string email = reader.GetString("email");
                    string password = reader.GetString("password");
                    string role = reader.GetString("role");
                    byte[] imgBytes = (byte[])reader["image_path"];

                    PictureBox pic = new PictureBox
                    {
                        Width = 100,
                        Height = 100,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Image = System.Drawing.Image.FromStream(new MemoryStream(imgBytes))
                    };

                    System.Windows.Forms.Label lbl = new System.Windows.Forms.Label()
                    {
                        Text = $"ชื่อ: {name}\nอีเมล: {email}\nบทบาท: {role}",
                        AutoSize = true
                    };

                    Panel panel = new Panel
                    {
                        Width = 650,
                        Height = 300,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    System.Windows.Forms.Button btnDelete = new System.Windows.Forms.Button
                    {
                        Text = "ลบ",
                        Location = new Point(520, 10),
                        Width = 100
                    };
                    btnDelete.Click += (s, e) => DeleteAdmin(email);

                    System.Windows.Forms.Button btnEdit = new System.Windows.Forms.Button
                    {
                        Text = "แก้ไข",
                        Location = new Point(520, 50),
                        Width = 100
                    };
                    btnDelete.AutoSize = true;
                    btnEdit.AutoSize = true;
                    btnEdit.Click += (s, e) => LoadAdminToForm(name, email, password, role, imgBytes);
                    panel.Controls.Add(pic);
                    panel.Controls.Add(lbl);
                    panel.Controls.Add(btnDelete);
                    panel.Controls.Add(btnEdit);

                    lbl.Location = new Point(0, 105);

                    flowAdmins.Controls.Add(panel);
                }
                flowAdmins.FlowDirection = FlowDirection.TopDown;
                flowAdmins.WrapContents = false;

            }
        }
        private void ClearTabPage6Form()
        {
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            comboBox5.SelectedIndex = 0;
            pictureBox1.Image = null;
            imageBytes = null;
        }
        private void DeleteAdmin(string email)
        {
            var confirm = MessageBox.Show("คุณแน่ใจว่าต้องการลบ?", "ยืนยัน", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (var conn = databasedAdminConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM admin WHERE email = @email";
                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.ExecuteNonQuery();
                }
                LoadAdminsToFlow();
            }
        }
        private string editingEmail = null;

        private void LoadAdminToForm(string name, string email, string role, string password, byte[] imgBytes)
        {
            textBox7.Text = name;
            textBox8.Text = email;
            textBox9.Text = password;
            comboBox5.SelectedItem = role;
            pictureBox1.Image = System.Drawing.Image.FromStream(new MemoryStream(imgBytes));
            imageBytes = imgBytes;
            editingEmail = email; // ใช้เป็นตัวบอกว่าแก้ไขอยู่
        }

        private void flowAdmins_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ApplyTabAccessByRole(string role)
        {
            // แสดงทุก tab สำหรับ admin
            if (role == "admin")
            {
                return;
            }

            // สำหรับ staff: ลบ tabPage ที่ไม่อนุญาต
            var allowedTabs = new[] { tabPage1, tabPage2, tabPage5 };

            foreach (TabPage tab in tabControl1.TabPages.Cast<TabPage>().ToList())
            {
                if (!allowedTabs.Contains(tab))
                {
                    tabControl1.TabPages.Remove(tab);
                }
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}

