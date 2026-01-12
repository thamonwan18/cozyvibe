namespace WinFormsApp1
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            button2 = new Button();
            button3 = new Button();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(327, 720);
            button1.Name = "button1";
            button1.Size = new Size(282, 47);
            button1.TabIndex = 5;
            button1.Text = "Log in";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Goudy Old Style", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(233, 485);
            textBox1.MaxLength = 100;
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(487, 50);
            textBox1.TabIndex = 8;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Goudy Old Style", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(233, 615);
            textBox2.MaxLength = 30;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(487, 44);
            textBox2.TabIndex = 9;
            textBox2.UseSystemPasswordChar = true;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(233, 425);
            label3.Name = "label3";
            label3.Size = new Size(84, 38);
            label3.TabIndex = 10;
            label3.Text = "Email";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(233, 556);
            label4.Name = "label4";
            label4.Size = new Size(130, 38);
            label4.TabIndex = 11;
            label4.Text = "Password";
            label4.Click += label4_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            button2.Location = new Point(45, 61);
            button2.Name = "button2";
            button2.Size = new Size(281, 55);
            button2.TabIndex = 22;
            button2.Text = "Go back to the first page";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI Semilight", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(735, 615);
            button3.Name = "button3";
            button3.Size = new Size(112, 50);
            button3.TabIndex = 33;
            button3.Text = "show";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.FromArgb(0, 0, 192);
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = SystemColors.ControlLightLight;
            linkLabel1.DisabledLinkColor = Color.White;
            linkLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            linkLabel1.ForeColor = SystemColors.ButtonFace;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(358, 806);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(215, 28);
            linkLabel1.TabIndex = 34;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Forgot your password ?";
            linkLabel1.VisitedLinkColor = Color.Black;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1902, 1033);
            Controls.Add(linkLabel1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Log in";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label3;
        private Label label4;
        private Button button2;
        private Button button3;
        private LinkLabel linkLabel1;
    }
}