namespace WinFormsApp1
{
    partial class Form8
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
            textBox3 = new TextBox();
            Email = new Label();
            Lastname = new Label();
            Firstname = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            btnChangePassword = new Button();
            SuspendLayout();
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.White;
            textBox3.Font = new Font("Goudy Old Style", 14F);
            textBox3.Location = new Point(308, 219);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(383, 36);
            textBox3.TabIndex = 51;
            textBox3.UseSystemPasswordChar = true;
            // 
            // Email
            // 
            Email.AutoSize = true;
            Email.BackColor = Color.White;
            Email.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            Email.Location = new Point(109, 220);
            Email.Name = "Email";
            Email.Size = new Size(170, 28);
            Email.TabIndex = 50;
            Email.Text = "Confirm Password";
            // 
            // Lastname
            // 
            Lastname.AutoSize = true;
            Lastname.BackColor = Color.White;
            Lastname.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            Lastname.Location = new Point(109, 169);
            Lastname.Name = "Lastname";
            Lastname.Size = new Size(139, 28);
            Lastname.TabIndex = 49;
            Lastname.Text = "New Password";
            // 
            // Firstname
            // 
            Firstname.AutoSize = true;
            Firstname.BackColor = Color.White;
            Firstname.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            Firstname.Location = new Point(107, 119);
            Firstname.Name = "Firstname";
            Firstname.Size = new Size(131, 28);
            Firstname.TabIndex = 48;
            Firstname.Text = "Old Password";
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.White;
            textBox2.Font = new Font("Goudy Old Style", 14F);
            textBox2.Location = new Point(308, 161);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(383, 36);
            textBox2.TabIndex = 47;
            textBox2.UseSystemPasswordChar = true;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.Font = new Font("Goudy Old Style", 14F);
            textBox1.Location = new Point(308, 111);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(383, 36);
            textBox1.TabIndex = 46;
            textBox1.UseSystemPasswordChar = true;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            btnChangePassword.Location = new Point(257, 310);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(256, 47);
            btnChangePassword.TabIndex = 52;
            btnChangePassword.Text = "Save";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // Form8
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 247, 244);
            ClientSize = new Size(800, 450);
            Controls.Add(btnChangePassword);
            Controls.Add(textBox3);
            Controls.Add(Email);
            Controls.Add(Lastname);
            Controls.Add(Firstname);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Form8";
            Text = "Form8";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox3;
        private Label Email;
        private Label Lastname;
        private Label Firstname;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button btnChangePassword;
    }
}