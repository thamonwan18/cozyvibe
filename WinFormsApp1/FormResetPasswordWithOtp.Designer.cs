namespace WinFormsApp1
{
    partial class FormResetPasswordWithOtp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResetPasswordWithOtp));
            labelEmail = new Label();
            groupBoxNewPassword = new GroupBox();
            buttonResetPassword = new Button();
            textBoxConfirmPassword = new Label();
            textBoxNewPassword = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            textBoxOtp = new TextBox();
            buttonVerifyOtp = new Button();
            groupBoxNewPassword.SuspendLayout();
            SuspendLayout();
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.BackColor = SystemColors.ButtonHighlight;
            labelEmail.Font = new Font("Segoe UI", 12F);
            labelEmail.Location = new Point(137, 254);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(101, 28);
            labelEmail.TabIndex = 0;
            labelEmail.Text = "labelEmail";
            labelEmail.Click += labelEmail_Click;
            // 
            // groupBoxNewPassword
            // 
            groupBoxNewPassword.BackColor = SystemColors.ButtonHighlight;
            groupBoxNewPassword.Controls.Add(buttonResetPassword);
            groupBoxNewPassword.Controls.Add(textBoxConfirmPassword);
            groupBoxNewPassword.Controls.Add(textBoxNewPassword);
            groupBoxNewPassword.Controls.Add(textBox2);
            groupBoxNewPassword.Controls.Add(textBox1);
            groupBoxNewPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBoxNewPassword.Location = new Point(667, 67);
            groupBoxNewPassword.Name = "groupBoxNewPassword";
            groupBoxNewPassword.Size = new Size(419, 455);
            groupBoxNewPassword.TabIndex = 1;
            groupBoxNewPassword.TabStop = false;
            groupBoxNewPassword.Text = "Reset Password";
            // 
            // buttonResetPassword
            // 
            buttonResetPassword.Location = new Point(104, 303);
            buttonResetPassword.Name = "buttonResetPassword";
            buttonResetPassword.Size = new Size(181, 45);
            buttonResetPassword.TabIndex = 7;
            buttonResetPassword.Text = "Sent";
            buttonResetPassword.UseVisualStyleBackColor = true;
            buttonResetPassword.Click += buttonResetPassword_Click_1;
            // 
            // textBoxConfirmPassword
            // 
            textBoxConfirmPassword.AutoSize = true;
            textBoxConfirmPassword.Location = new Point(63, 204);
            textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            textBoxConfirmPassword.Size = new Size(168, 28);
            textBoxConfirmPassword.TabIndex = 6;
            textBoxConfirmPassword.Text = "Confirm Password";
            // 
            // textBoxNewPassword
            // 
            textBoxNewPassword.AutoSize = true;
            textBoxNewPassword.Location = new Point(63, 104);
            textBoxNewPassword.Name = "textBoxNewPassword";
            textBoxNewPassword.Size = new Size(137, 28);
            textBoxNewPassword.TabIndex = 5;
            textBoxNewPassword.Text = "New Password";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(63, 233);
            textBox2.MaxLength = 255;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(280, 34);
            textBox2.TabIndex = 4;
            textBox2.UseSystemPasswordChar = true;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(63, 132);
            textBox1.MaxLength = 255;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(280, 34);
            textBox1.TabIndex = 3;
            textBox1.UseSystemPasswordChar = true;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBoxOtp
            // 
            textBoxOtp.Font = new Font("Segoe UI", 12F);
            textBoxOtp.Location = new Point(187, 299);
            textBoxOtp.MaxLength = 6;
            textBoxOtp.Multiline = true;
            textBoxOtp.Name = "textBoxOtp";
            textBoxOtp.Size = new Size(280, 46);
            textBoxOtp.TabIndex = 2;
            textBoxOtp.TextChanged += textBoxOtp_TextChanged;
            // 
            // buttonVerifyOtp
            // 
            buttonVerifyOtp.Font = new Font("Segoe UI", 12F);
            buttonVerifyOtp.Location = new Point(238, 370);
            buttonVerifyOtp.Name = "buttonVerifyOtp";
            buttonVerifyOtp.Size = new Size(181, 45);
            buttonVerifyOtp.TabIndex = 3;
            buttonVerifyOtp.Text = "Sent";
            buttonVerifyOtp.UseVisualStyleBackColor = true;
            buttonVerifyOtp.Click += buttonVerifyOtp_Click_1;
            // 
            // FormResetPasswordWithOtp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1182, 661);
            Controls.Add(buttonVerifyOtp);
            Controls.Add(textBoxOtp);
            Controls.Add(groupBoxNewPassword);
            Controls.Add(labelEmail);
            DoubleBuffered = true;
            Name = "FormResetPasswordWithOtp";
            Text = "FormResetPasswordWithOtp";
            Load += FormResetPasswordWithOtp_Load;
            groupBoxNewPassword.ResumeLayout(false);
            groupBoxNewPassword.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelEmail;
        private GroupBox groupBoxNewPassword;
        private TextBox textBoxOtp;
        private Button buttonVerifyOtp;
        private Button buttonResetPassword;
        private Label textBoxConfirmPassword;
        private Label textBoxNewPassword;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}