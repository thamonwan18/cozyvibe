namespace WinFormsApp1
{
    partial class Form14
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form14));
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label2 = new Label();
            name = new Label();
            address = new Label();
            phonenumber = new Label();
            nameuser = new Label();
            Phonenumber2 = new Label();
            Address2 = new Label();
            order = new Label();
            label3 = new Label();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            label5 = new Label();
            button4 = new Button();
            button3 = new Button();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(281, 899);
            button1.Name = "button1";
            button1.Size = new Size(388, 64);
            button1.TabIndex = 6;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(703, 548);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(156, 406);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(647, 56);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 12F);
            textBox2.Location = new Point(156, 524);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(647, 55);
            textBox2.TabIndex = 3;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 12F);
            textBox3.Location = new Point(156, 651);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(647, 184);
            textBox3.TabIndex = 4;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(865, 298);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 5;
            // 
            // name
            // 
            name.AutoSize = true;
            name.Font = new Font("Segoe UI", 14F, FontStyle.Italic);
            name.Location = new Point(156, 364);
            name.Name = "name";
            name.Size = new Size(78, 32);
            name.TabIndex = 8;
            name.Text = "Name";
            // 
            // address
            // 
            address.AutoSize = true;
            address.Font = new Font("Segoe UI", 14F, FontStyle.Italic);
            address.Location = new Point(156, 616);
            address.Name = "address";
            address.Size = new Size(94, 32);
            address.TabIndex = 9;
            address.Text = "Address";
            address.Click += address_Click;
            // 
            // phonenumber
            // 
            phonenumber.AutoSize = true;
            phonenumber.Font = new Font("Segoe UI", 14F, FontStyle.Italic);
            phonenumber.Location = new Point(156, 487);
            phonenumber.Name = "phonenumber";
            phonenumber.Size = new Size(172, 32);
            phonenumber.TabIndex = 10;
            phonenumber.Text = "Phone Number";
            // 
            // nameuser
            // 
            nameuser.AutoSize = true;
            nameuser.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            nameuser.Location = new Point(19, 15);
            nameuser.Name = "nameuser";
            nameuser.Size = new Size(65, 28);
            nameuser.TabIndex = 11;
            nameuser.Text = "Name";
            nameuser.Click += nameuser_Click;
            // 
            // Phonenumber2
            // 
            Phonenumber2.AutoSize = true;
            Phonenumber2.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            Phonenumber2.Location = new Point(19, 47);
            Phonenumber2.Name = "Phonenumber2";
            Phonenumber2.Size = new Size(144, 28);
            Phonenumber2.TabIndex = 12;
            Phonenumber2.Text = "Phone Number";
            // 
            // Address2
            // 
            Address2.AutoSize = true;
            Address2.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            Address2.Location = new Point(19, 79);
            Address2.Name = "Address2";
            Address2.Size = new Size(80, 28);
            Address2.TabIndex = 13;
            Address2.Text = "Address";
            Address2.Click += Address2_Click;
            // 
            // order
            // 
            order.AutoSize = true;
            order.Font = new Font("Segoe UI", 14F);
            order.Location = new Point(1102, 286);
            order.Name = "order";
            order.Size = new Size(82, 32);
            order.TabIndex = 14;
            order.Text = "Order ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(1009, 321);
            label3.Name = "label3";
            label3.Size = new Size(151, 28);
            label3.TabIndex = 15;
            label3.Text = "Order Summary";
            label3.Click += label3_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 16.2F, FontStyle.Italic);
            button2.Location = new Point(1485, 959);
            button2.Name = "button2";
            button2.Size = new Size(229, 49);
            button2.TabIndex = 7;
            button2.Text = "Finish";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1457, 166);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(290, 353);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.MistyRose;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Italic);
            label4.Location = new Point(281, 323);
            label4.Name = "label4";
            label4.Size = new Size(424, 38);
            label4.TabIndex = 16;
            label4.Text = "Please fill in the shipping address.";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.AutoSize = true;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(order);
            panel1.Controls.Add(phonenumber);
            panel1.Controls.Add(address);
            panel1.Controls.Add(name);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1902, 1163);
            panel1.TabIndex = 17;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Silver;
            pictureBox2.Location = new Point(1491, 616);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(217, 277);
            pictureBox2.TabIndex = 21;
            pictureBox2.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.MistyRose;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(1457, 574);
            label5.Name = "label5";
            label5.Size = new Size(295, 28);
            label5.TabIndex = 20;
            label5.Text = "Please upload your payment slip";
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            button4.Location = new Point(1491, 897);
            button4.Name = "button4";
            button4.Size = new Size(217, 49);
            button4.TabIndex = 19;
            button4.Text = "select image";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 16.2F, FontStyle.Italic);
            button3.Location = new Point(363, 879);
            button3.Name = "button3";
            button3.Size = new Size(229, 49);
            button3.TabIndex = 17;
            button3.Text = "save";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Snow;
            panel2.Controls.Add(nameuser);
            panel2.Controls.Add(Phonenumber2);
            panel2.Controls.Add(Address2);
            panel2.Location = new Point(884, 89);
            panel2.Name = "panel2";
            panel2.Size = new Size(465, 177);
            panel2.TabIndex = 22;
            // 
            // Form14
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            BackColor = Color.FromArgb(248, 247, 244);
            ClientSize = new Size(1902, 1033);
            Controls.Add(panel1);
            Controls.Add(button1);
            Name = "Form14";
            Text = "Form14";
            Load += Form14_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label2;
        private Label name;
        private Label address;
        private Label phonenumber;
        private Label nameuser;
        private Label Phonenumber2;
        private Label Address2;
        private Label order;
        private Label label3;
        private Button button2;
        private PictureBox pictureBox1;
        private Label label4;
        private Panel panel1;
        private Button button3;
        private Button button4;
        private Label label5;
        private PictureBox pictureBox2;
        private Panel panel2;
    }
}