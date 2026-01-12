namespace WinFormsApp1
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            label4 = new Label();
            Firstname = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            button3 = new Button();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            pictureBox1 = new PictureBox();
            button4 = new Button();
            Address = new Label();
            Phone = new Label();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            label4.Location = new Point(825, 380);
            label4.Name = "label4";
            label4.Size = new Size(95, 28);
            label4.TabIndex = 16;
            label4.Text = "Lastname";
            label4.Click += label4_Click;
            // 
            // Firstname
            // 
            Firstname.AutoSize = true;
            Firstname.BackColor = Color.White;
            Firstname.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            Firstname.Location = new Point(825, 333);
            Firstname.Name = "Firstname";
            Firstname.Size = new Size(97, 28);
            Firstname.TabIndex = 15;
            Firstname.Text = "Firstname";
            Firstname.Click += label3_Click;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.White;
            textBox2.Font = new Font("Goudy Old Style", 14F);
            textBox2.Location = new Point(983, 372);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(450, 36);
            textBox2.TabIndex = 14;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.Font = new Font("Goudy Old Style", 14F);
            textBox1.Location = new Point(983, 325);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(450, 36);
            textBox1.TabIndex = 13;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(1065, 781);
            button1.Name = "button1";
            button1.Size = new Size(282, 47);
            button1.TabIndex = 12;
            button1.Text = "Log in";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            label1.Location = new Point(825, 479);
            label1.Name = "label1";
            label1.Size = new Size(94, 28);
            label1.TabIndex = 20;
            label1.Text = "Password";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            label2.Location = new Point(825, 431);
            label2.Name = "label2";
            label2.Size = new Size(60, 28);
            label2.TabIndex = 19;
            label2.Text = "Email";
            label2.Click += label2_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            button2.Location = new Point(49, 45);
            button2.Name = "button2";
            button2.Size = new Size(281, 55);
            button2.TabIndex = 21;
            button2.Text = "Go back to the first page";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            button3.Location = new Point(1439, 477);
            button3.Name = "button3";
            button3.Size = new Size(92, 36);
            button3.TabIndex = 24;
            button3.Text = "show";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.White;
            textBox3.Font = new Font("Goudy Old Style", 14F);
            textBox3.Location = new Point(983, 423);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(450, 36);
            textBox3.TabIndex = 25;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.White;
            textBox4.Font = new Font("Goudy Old Style", 14F);
            textBox4.Location = new Point(983, 478);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(450, 36);
            textBox4.TabIndex = 26;
            textBox4.UseSystemPasswordChar = true;
            textBox4.TextChanged += textBox4_TextChanged_1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Silver;
            pictureBox1.Location = new Point(1590, 333);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(201, 229);
            pictureBox1.TabIndex = 27;
            pictureBox1.TabStop = false;
            // 
            // button4
            // 
            button4.BackColor = Color.White;
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.Black;
            button4.Location = new Point(1590, 603);
            button4.Name = "button4";
            button4.Size = new Size(201, 47);
            button4.TabIndex = 28;
            button4.Text = "Add Image";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // Address
            // 
            Address.AutoSize = true;
            Address.BackColor = Color.White;
            Address.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            Address.Location = new Point(825, 586);
            Address.Name = "Address";
            Address.Size = new Size(80, 28);
            Address.TabIndex = 54;
            Address.Text = "Address";
            // 
            // Phone
            // 
            Phone.AutoSize = true;
            Phone.BackColor = Color.White;
            Phone.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            Phone.Location = new Point(825, 527);
            Phone.Name = "Phone";
            Phone.Size = new Size(134, 28);
            Phone.TabIndex = 53;
            Phone.Text = "Phonenumber";
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.White;
            textBox5.Font = new Font("Goudy Old Style", 14F);
            textBox5.Location = new Point(983, 526);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(450, 36);
            textBox5.TabIndex = 52;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // textBox6
            // 
            textBox6.BackColor = Color.White;
            textBox6.Font = new Font("Goudy Old Style", 14F);
            textBox6.Location = new Point(983, 586);
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(450, 155);
            textBox6.TabIndex = 51;
            textBox6.UseSystemPasswordChar = true;
            textBox6.TextChanged += textBox6_TextChanged;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1902, 1033);
            Controls.Add(Address);
            Controls.Add(Phone);
            Controls.Add(textBox5);
            Controls.Add(textBox6);
            Controls.Add(button4);
            Controls.Add(pictureBox1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(Firstname);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            DoubleBuffered = true;
            Name = "Form3";
            Text = "Register";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label Firstname;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button1;
        private Label label1;
        private Label label2;
        private Button button2;
        private Button button3;
        private TextBox textBox3;
        private TextBox textBox4;
        private PictureBox pictureBox1;
        private Button button4;
        private Label Address;
        private Label Phone;
        private TextBox textBox5;
        private TextBox textBox6;
    }
}