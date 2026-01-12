namespace WinFormsApp1
{
    partial class Form15
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form15));
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(248, 247, 244);
            label1.Font = new Font("Leelawadee UI Semilight", 14F);
            label1.Location = new Point(141, 222);
            label1.Name = "label1";
            label1.Size = new Size(510, 32);
            label1.TabIndex = 0;
            label1.Text = "ขอบคุณสำหรับการสั่งซื้อนะคะ ระบบได้รับข้อมูลเรียบร้อย";
            // 
            // Form15
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "Form15";
            Text = "Form15";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    }
}