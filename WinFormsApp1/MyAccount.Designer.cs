namespace WinFormsApp1
{
    partial class MyAccount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            flowOrders = new FlowLayoutPanel();
            button4 = new Button();
            label2 = new Label();
            label1 = new Label();
            button3 = new Button();
            pictureBox1 = new PictureBox();
            Address = new Label();
            Phone = new Label();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            button2 = new Button();
            Password = new Label();
            Email = new Label();
            Lastname = new Label();
            Firstname = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button1 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.FromArgb(248, 247, 244);
            panel1.Controls.Add(flowOrders);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(Address);
            panel1.Controls.Add(Phone);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(Password);
            panel1.Controls.Add(Email);
            panel1.Controls.Add(Lastname);
            panel1.Controls.Add(Firstname);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1902, 1033);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // flowOrders
            // 
            flowOrders.AutoScroll = true;
            flowOrders.Location = new Point(400, 723);
            flowOrders.Name = "flowOrders";
            flowOrders.Size = new Size(1144, 645);
            flowOrders.TabIndex = 58;
            flowOrders.WrapContents = false;
            flowOrders.Paint += flowOrders_Paint;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            button4.Location = new Point(12, 12);
            button4.Name = "button4";
            button4.Size = new Size(218, 57);
            button4.TabIndex = 57;
            button4.Text = "Go Back";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Garamond", 26F);
            label2.Location = new Point(455, 664);
            label2.Name = "label2";
            label2.Size = new Size(264, 50);
            label2.TabIndex = 55;
            label2.Text = "Order History";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Garamond", 26F);
            label1.Location = new Point(728, 66);
            label1.Name = "label1";
            label1.Size = new Size(336, 50);
            label1.TabIndex = 53;
            label1.Text = "Profile And Order";
            label1.Click += label1_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.Black;
            button3.Location = new Point(498, 519);
            button3.Name = "button3";
            button3.Size = new Size(232, 47);
            button3.TabIndex = 52;
            button3.Text = "Edit Image";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(498, 211);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(232, 267);
            pictureBox1.TabIndex = 51;
            pictureBox1.TabStop = false;
            // 
            // Address
            // 
            Address.AutoSize = true;
            Address.BackColor = Color.White;
            Address.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            Address.Location = new Point(835, 426);
            Address.Name = "Address";
            Address.Size = new Size(80, 28);
            Address.TabIndex = 50;
            Address.Text = "Address";
            // 
            // Phone
            // 
            Phone.AutoSize = true;
            Phone.BackColor = Color.White;
            Phone.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            Phone.Location = new Point(833, 377);
            Phone.Name = "Phone";
            Phone.Size = new Size(134, 28);
            Phone.TabIndex = 48;
            Phone.Text = "Phonenumber";
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.White;
            textBox5.Font = new Font("Goudy Old Style", 14F);
            textBox5.Location = new Point(986, 436);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(487, 152);
            textBox5.TabIndex = 47;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.White;
            textBox4.Font = new Font("Goudy Old Style", 14F);
            textBox4.Location = new Point(986, 376);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(487, 36);
            textBox4.TabIndex = 46;
            textBox4.UseSystemPasswordChar = true;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.White;
            textBox3.Font = new Font("Goudy Old Style", 14F);
            textBox3.Location = new Point(986, 269);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(487, 36);
            textBox3.TabIndex = 45;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            button2.Location = new Point(986, 322);
            button2.Name = "button2";
            button2.Size = new Size(252, 38);
            button2.TabIndex = 44;
            button2.Text = "Change";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.BackColor = Color.White;
            Password.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            Password.Location = new Point(833, 327);
            Password.Name = "Password";
            Password.Size = new Size(94, 28);
            Password.TabIndex = 43;
            Password.Text = "Password";
            // 
            // Email
            // 
            Email.AutoSize = true;
            Email.BackColor = Color.White;
            Email.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            Email.Location = new Point(835, 271);
            Email.Name = "Email";
            Email.Size = new Size(60, 28);
            Email.TabIndex = 42;
            Email.Text = "Email";
            // 
            // Lastname
            // 
            Lastname.AutoSize = true;
            Lastname.BackColor = Color.White;
            Lastname.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            Lastname.Location = new Point(835, 220);
            Lastname.Name = "Lastname";
            Lastname.Size = new Size(95, 28);
            Lastname.TabIndex = 41;
            Lastname.Text = "Lastname";
            // 
            // Firstname
            // 
            Firstname.AutoSize = true;
            Firstname.BackColor = Color.White;
            Firstname.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            Firstname.Location = new Point(833, 170);
            Firstname.Name = "Firstname";
            Firstname.Size = new Size(97, 28);
            Firstname.TabIndex = 40;
            Firstname.Text = "Firstname";
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.White;
            textBox2.Font = new Font("Goudy Old Style", 14F);
            textBox2.Location = new Point(986, 211);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(487, 36);
            textBox2.TabIndex = 39;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.Font = new Font("Goudy Old Style", 14F);
            textBox1.Location = new Point(986, 162);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(487, 36);
            textBox1.TabIndex = 38;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(1078, 617);
            button1.Name = "button1";
            button1.Size = new Size(282, 47);
            button1.TabIndex = 37;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // MyAccount
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1902, 1033);
            Controls.Add(panel1);
            Name = "MyAccount";
            Text = "My Account";
            Load += MyAccount_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label Address;
        private Label Phone;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private Button button2;
        private Label Password;
        private Label Email;
        private Label Lastname;
        private Label Firstname;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button1;
        private PictureBox pictureBox1;
        private Button button3;
        private Label label1;
        private Label label2;
        private Button button4;
        private FlowLayoutPanel flowOrders;
    }
}