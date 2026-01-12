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
    public partial class Form7 : Form
    {
        public int userId;
        string connectionString = "datasource=127.0.0.1;port=3306;user=root;password=;database=stock;charset=utf8;";
        public Form7(int userIdFromLogin)
        {
            InitializeComponent();
            userId = userIdFromLogin;

        }


        private void Form7_Load(object sender, EventArgs e)
        {

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT id, image_path FROM category", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int categoryId = reader.GetInt32("id");
                    string imagePath = reader.GetString("image_path");

                    // ✅ สร้าง path เต็มจากตำแหน่ง .exe
                    string fullPath = Path.Combine(Application.StartupPath, imagePath);

                    // ✅ โหลดภาพ ถ้าไม่มีให้ใช้ null
                    Image image = File.Exists(fullPath) ? Image.FromFile(fullPath) : null;

                    // ✅ PictureBox ใหญ่ขึ้น
                    PictureBox pic = new PictureBox
                    {
                        Width = 240,
                        Height = 310,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Image = image,
                        Cursor = Cursors.Hand,
                        Margin = new Padding(25),
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle,
                        Tag = categoryId
                    };

                    // ✅ คลิกเพื่อเปิด 
                    pic.Click += (s, e) =>
                    {
                        int selectedCategoryId = (int)((PictureBox)s).Tag;
                        FormCategoryViewer viewer = new FormCategoryViewer(userId, selectedCategoryId); // ✅ ส่งครบ 2 ตัวแปร
                        viewer.Show();
                        this.Hide();

                    };

                    flowLayoutPanelCategories.Controls.Add(pic);
                }
            }
        }




        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyAccount accountForm = new MyAccount(userId); // ✅ ส่งต่อ userId
            accountForm.Show();
            this.Close();

        }
    }
}
